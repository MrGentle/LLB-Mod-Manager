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
            try { asmDef = AssemblyDefinition.ReadAssembly(_gameDataFolder + @"\Managed\Assembly-CSharp.dll"); }
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
            List<string> installedModsList = new List<string>();
            try { asmDef = AssemblyDefinition.ReadAssembly(_gameDataFolder + @"\Managed\Assembly-CSharp.dll"); }
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
            //Injection information
            string injectTypeName = "LLScreen.ScreenIntroTitle"; // What type to inject into in Assemby-CSharp
            string injectMethodName = "CShowTitle"; // Method name in the type
            string modMethodNames = "Initialize";

            DefaultAssemblyResolver defaultAssemblyResolver = new DefaultAssemblyResolver();
            defaultAssemblyResolver.AddSearchDirectory(_gameDataFolder + @"\Managed\");

            ReaderParameters parameters = new ReaderParameters { AssemblyResolver = defaultAssemblyResolver };

            try { asmDef = AssemblyDefinition.ReadAssembly(_gameDataFolder + @"\Managed\Assembly-CSharp.dll", parameters); }
            catch
            {
                MessageBox.Show("Could not find main game assembly, vertify your gamefiles");
                return false;
            }

            AssemblyDefinition modAsm = null;
            try { modAsm = AssemblyDefinition.ReadAssembly(_gameDataFolder + "\\Managed\\" + mod + ".dll"); }
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

            asmDef.Write(_gameDataFolder + @"\Managed\Assembly-CSharp-temp.dll");
            asmDef.Dispose();

            if (File.Exists(_gameDataFolder + @"\Managed\Assembly-CSharp-temp.dll"))
            {
                File.Delete(_gameDataFolder + @"\Managed\Assembly-CSharp.dll");
                File.Copy(_gameDataFolder + @"\Managed\Assembly-CSharp-temp.dll", _gameDataFolder + @"\Managed\Assembly-CSharp.dll");
                File.Delete(_gameDataFolder + @"\Managed\Assembly-CSharp-temp.dll");
            }


            if (Directory.Exists(_gameDataFolder + @"\Managed\" + mod + "Resources")) Directory.Delete(_gameDataFolder + @"\Managed\" + mod + "Resources", true);
            if (File.Exists(_gameDataFolder + @"\Managed\" + mod + ".dll")) File.Delete(_gameDataFolder + @"\Managed\" + mod + ".dll");

            return true;
        }


        public bool CleanGameFolder(string _gameDataFolder)
        {
            try
            {
                var bh = new BackupHelper();
                bh.DeleteBackup(_gameDataFolder);

                if (Directory.Exists(_gameDataFolder + @"\Managed\temp"))
                {
                    DirectoryInfo di = new DirectoryInfo(_gameDataFolder + @"\Managed\temp");
                    foreach (DirectoryInfo dir in di.GetDirectories()) dir.Delete(true);
                    foreach (FileInfo file in di.GetFiles()) file.Delete();
                    Directory.Delete(_gameDataFolder + @"\Managed\temp");
                }

                foreach (string dirPath in Directory.GetDirectories(_gameDataFolder + "\\Managed", " * ", SearchOption.AllDirectories))
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
                MessageBox.Show("Could not clean all mod files from folder. Please go into the LLBlaze_Data\\Managed folder and check if there is a ModManagerBackup folder. If there is, delete the Assembly-CSharp file in Managed and copy the backup file over it and remove 'backup' from its name. Also, delete the temp folder and any mod folders if they exist. Ensure that there is no ModMenu.dll present either.", "");
                return false;
            }
        }
    }
}
