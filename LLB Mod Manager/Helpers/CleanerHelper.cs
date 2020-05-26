using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace LLB_Mod_Manager
{
    public class CleanerHelper
    {
        private AssemblyDefinition asmDef;
        private ModuleDefinition mainModule;


        public bool CheckModStatus(string _gameDataFolder)
        {
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            string assemblyPath = Path.Combine(_gameDataFolder, gameDataDirName, "Managed", "Assembly-CSharp.dll");
            try { asmDef = AssemblyDefinition.ReadAssembly(assemblyPath); }
            catch
            {
                Debug.WriteLine("CleanerHelper.CheckModStatus: Could not find assembly");
                return false;
            }
            mainModule = asmDef.MainModule;
            var isModded = false;
            foreach (var type in mainModule.Types)
            {
                if (type.Name == "Mods")
                {
                    if (type.Methods.Count > 0) isModded = true;
                }
            }

            asmDef.Dispose();
            return isModded;
        }


        public List<string> InstalledMods(string _gameDataFolder)
        {
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            string assemblyPath = Path.Combine(_gameDataFolder, gameDataDirName, "Managed", "Assembly-CSharp.dll");
            List<string> installedModsList = new List<string>();
            try { asmDef = AssemblyDefinition.ReadAssembly(assemblyPath); }
            catch
            {
                return installedModsList; ;
            }
            mainModule = asmDef.MainModule;
            TypeDefinition typeDef = null;

            foreach (var type in mainModule.Types) if (type.Name == "Mods") typeDef = type;

            if (typeDef == null)
            {
                Debug.WriteLine("CleanerHelper.InstalledMods: TypeDefinition in was null");
                asmDef.Dispose();
                return installedModsList;
            }

            if (typeDef != null) foreach (var field in typeDef.Fields) installedModsList.Add(field.Name);
            else asmDef.Dispose();

            asmDef.Dispose();
            return installedModsList;
        }


        public void RemoveMods(string _gameDataFolder, List<string> _modlist)
        {
            foreach (var mod in _modlist) RemoveMod(_gameDataFolder, mod);
        }


        public bool RemoveMod(string _gameDataFolder, string mod)
        {
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            string managedPath = Path.Combine(_gameDataFolder, gameDataDirName, "Managed");
            string assemblyPath = Path.Combine(managedPath, "Assembly-CSharp.dll");

            //Injection information
            string injectTypeName = "LLScreen.ScreenIntroTitle"; // What type to inject into in Assemby-CSharp
            string injectMethodName = "CShowTitle"; // Method name in the type
            string modMethodNames = "Initialize";

            DefaultAssemblyResolver defaultAssemblyResolver = new DefaultAssemblyResolver();
            defaultAssemblyResolver.AddSearchDirectory(managedPath);

            ReaderParameters parameters = new ReaderParameters { AssemblyResolver = defaultAssemblyResolver };

            try { asmDef = AssemblyDefinition.ReadAssembly(assemblyPath, parameters); }
            catch
            {
                MessageBox.Show("Could not find main game assembly, verify your gamefiles");
                return false;
            }

            AssemblyDefinition modAsm = null;
            try { modAsm = AssemblyDefinition.ReadAssembly(Path.Combine(managedPath, mod + ".dll")); }
            catch {}

            TypeDefinition injectPointType = asmDef.MainModule.GetType(injectTypeName);
            foreach (MethodDefinition method in injectPointType.Methods)
            {
                if (method.Name == injectMethodName)
                {
                    try
                    {
                        ILProcessor ilproc = method.Body.GetILProcessor();
                        if (ilproc.Body.Instructions.Count > 0)
                        {
                            foreach (TypeDefinition modTypeDef in modAsm.MainModule.Types)
                            {
                                foreach (MethodDefinition modMethodDef in modTypeDef.Methods)
                                {
                                    if (modMethodDef.Name == modMethodNames)
                                    {
                                        MethodReference callRef = asmDef.MainModule.ImportReference(modMethodDef);
                                        Instruction destroy = null;
                                        foreach (Instruction i in ilproc.Body.Instructions)
                                        {
                                            if (i.OpCode == OpCodes.Call && i.Operand.ToString() == callRef.ToString()) destroy = i;
                                        }
                                        ilproc.Remove(destroy);
                                        modAsm.Dispose();
                                    }
                                }
                            }
                        }
                    }
                    catch {}
                }
            }

            //Remove from mods list
            if (mod != "ModMenu")
            {
                mainModule = asmDef.MainModule;
                TypeDefinition typeDef = null;

                foreach (var type in mainModule.Types) if (type.Name == "Mods") typeDef = type;

                FieldDefinition fieldToDelete = null;
                foreach (var field in typeDef.Fields) if (field.Name == mod) fieldToDelete = field;

                if (fieldToDelete != null) typeDef.Fields.Remove(fieldToDelete);
            } else modAsm.Dispose();

            var assemblyTempPath = Path.Combine(managedPath, "Assembly-CSharp-temp.dll");

            asmDef.Write(assemblyTempPath);
            asmDef.Dispose();

            if (File.Exists(assemblyTempPath))
            {
                File.Delete(assemblyPath);
                File.Copy(assemblyTempPath, assemblyPath);
                File.Delete(assemblyTempPath);
            }


            if (Directory.Exists(Path.Combine(managedPath, mod + "Resources"))) Directory.Delete(Path.Combine(managedPath, mod + "Resources"), true);
            if (File.Exists(Path.Combine(managedPath, mod + ".dll"))) File.Delete(Path.Combine(managedPath, mod + ".dll"));

            return true;
        }


        public bool CleanGameFolder(string _gameDataFolder)
        {
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            try
            {
                string managedPath = Path.Combine(_gameDataFolder, gameDataDirName, "Managed");
                string managedTempPath = Path.Combine(managedPath, "temp");
                var bh = new BackupHelper();
                bh.DeleteBackup(_gameDataFolder);

                if (Directory.Exists(managedTempPath))
                {
                    DirectoryInfo di = new DirectoryInfo(managedTempPath);
                    foreach (DirectoryInfo dir in di.GetDirectories()) dir.Delete(true);
                    foreach (FileInfo file in di.GetFiles()) file.Delete();
                    Directory.Delete(managedTempPath);
                }

                foreach (string dirPath in Directory.GetDirectories(managedPath, " * ", SearchOption.AllDirectories))
                {
                    if (dirPath.EndsWith("Resources"))
                    {
                        foreach (string f in Directory.GetFiles(dirPath)) File.Delete(f);
                        Directory.Delete(dirPath);
                    }
                }

                return true;
            } catch
            {
                MessageBox.Show("Could not clean all mod files from folder. Please go into the "+ gameDataDirName + Path.DirectorySeparatorChar +"Managed folder and check if there is a ModManagerBackup folder. If there is, delete the Assembly-CSharp file in Managed and copy the backup file over it and remove 'backup' from its name. Also, delete the temp folder and any mod folders if they exist. Ensure that there is no ModMenu.dll present either.", "");
                return false;
            }
        }
    }
}
