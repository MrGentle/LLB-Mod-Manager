using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Mono.Cecil;
using Mono.Cecil.Cil;


namespace LLB_Mod_Manager
{
    public class InjectionHelper
    {
        public bool InstallSelectedMods(string _gameDataFolder, List<string> modsToInstall)
        {
            //LLBMM Paths
            string llbmm_rootDir = Directory.GetCurrentDirectory();
            string llbmm_modsDir = llbmm_rootDir + "\\mods";

            //Game Folder Paths
            string game_managedDir = _gameDataFolder + "\\Managed";
            string game_tempDir = game_managedDir + "\\temp";
            string game_mainAsmFile = game_managedDir + "\\Assembly-CSharp.dll";

            List<string> modsToInstallPaths = new List<string>(); //Will hold the file paths for the mods we recieved from the pendingMods ListBox.

            var i = 0;
            var _modList = modsToInstall;
            foreach (var mod in _modList) //Checks if a mods file exists and adds its path to a list if it does.
            {
                string modPath = llbmm_modsDir + "\\" + mod.ToString() + @"\\" + mod.ToString() + ".dll";
                if (File.Exists(modPath)) modsToInstallPaths.Add(modPath);
                else
                {
                    MessageBox.Show("Skipping " + mod + ". Can't find mod file at" + modPath + ". Please ensure that the file path matches the one in this window", "Error");
                    modsToInstall.Remove(mod);
                }
                i++;
            }

            Directory.CreateDirectory(game_tempDir);
            try { File.Copy(game_mainAsmFile, game_tempDir + "\\Assembly-CSharp.dll"); }
            catch
            {
                MessageBox.Show("Could not copy the main Assembly-CSharp.dll to temp folder. Terminating modding attempt. Please vertify your gamefiles through steam", "Error");
                return false;
            }

            foreach (var path in modsToInstallPaths)
            {
                try { File.Copy(path, game_tempDir + "\\" + Path.GetFileName(path)); }
                catch
                {
                    MessageBox.Show("Skipping mod " + Path.GetFileNameWithoutExtension(path) + ". Could not copy mod file at" + path + " to temp folder", "Error");
                    modsToInstall.Remove(Path.GetFileNameWithoutExtension(path));
                }
            }
            if (!File.Exists(game_managedDir + "\\ModMenu.dll")) File.Copy(llbmm_rootDir + "\\ModMenu\\ModMenu.dll", game_tempDir + "\\ModMenu.dll"); //If modmenu isn't installed try to install it
            else
            {
                byte[] past = File.ReadAllBytes(game_managedDir + "\\ModMenu.dll");
                byte[] present = File.ReadAllBytes(llbmm_rootDir + "\\ModMenu\\ModMenu.dll"); 

                if (past.Length != present.Length)
                { 
                    CleanerHelper ch = new CleanerHelper();
                    ch.RemoveMod(_gameDataFolder, "ModMenu");
                    File.Copy(llbmm_rootDir + "\\ModMenu\\ModMenu.dll", game_tempDir + "\\ModMenu.dll");
                }
            }


            List<string> tempFiles = Directory.EnumerateFiles(game_tempDir, "*", SearchOption.AllDirectories).Where(s => s.EndsWith(".dll") && s.Count(c => c == '.') == 1).ToList();

            //Injection information
            string injectTypeName = "LLScreen.ScreenIntroTitle"; // What type to inject into in Assemby-CSharp
            string injectMethodName = "CShowTitle"; // Method name in the type
            string modMethodNames = "Initialize";

            //Init Resolver
            DefaultAssemblyResolver defaultAssemblyResolver = new DefaultAssemblyResolver();
            defaultAssemblyResolver.AddSearchDirectory(game_managedDir);
            defaultAssemblyResolver.AddSearchDirectory(game_tempDir);
            defaultAssemblyResolver.AddSearchDirectory(llbmm_rootDir); //Test om e kan fjærn den hær og den over
            ReaderParameters parameters = new ReaderParameters { AssemblyResolver = defaultAssemblyResolver };

            //Get the assembly definitions of the main file
            AssemblyDefinition _mainFileAssemblyDef = AssemblyDefinition.ReadAssembly(game_tempDir + "\\Assembly-CSharp.dll", parameters);
            ModuleDefinition _mainFileMainModule = _mainFileAssemblyDef.MainModule;

            //Get the assembly definitions of the mod files
            List<AssemblyDefinition> _modAssemblyList= new List<AssemblyDefinition>();
            foreach (string path in tempFiles)
            {
                if (path != game_tempDir + @"\Assembly-CSharp.dll")
                {
                    try { _modAssemblyList.Add(AssemblyDefinition.ReadAssembly(path)); }
                    catch
                    {
                        MessageBox.Show("Skipping mod " + Path.GetFileNameWithoutExtension(path) +  ". Mod file " + path + " can't be injected", "Error");
                        modsToInstall.Remove(Path.GetFileNameWithoutExtension(path));
                    }
                }
            }

            TypeDefinition moddedClass = null;
            foreach (TypeDefinition type in _mainFileMainModule.Types)
            {
                if (type.Name == "Mods") moddedClass = type;
            }
            if (moddedClass == null)
            {
                //create custom class that holds mod names
                moddedClass = new TypeDefinition("", "Mods", TypeAttributes.Public | TypeAttributes.Class, _mainFileMainModule.TypeSystem.Object);
                //insert custom class into assembly
                _mainFileMainModule.Types.Add(moddedClass);
                moddedClass.Methods.Add(new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, _mainFileMainModule.TypeSystem.Void));
            }

            foreach (var mod in modsToInstall) { moddedClass.Fields.Add(new FieldDefinition(mod.ToString(), FieldAttributes.Public, _mainFileMainModule.TypeSystem.String)); }

            TypeDefinition injectPointType = _mainFileAssemblyDef.MainModule.GetType(injectTypeName);
            if (injectPointType == null || injectPointType.Methods == null)
            {
                MessageBox.Show("Bad inject point (Terminating modding session)");
                return false;
            }

            foreach (MethodDefinition method in injectPointType.Methods)
            {
                if (method.Name == injectMethodName)
                {
                    try
                    {
                        ILProcessor ilproc = method.Body.GetILProcessor();
                        if (ilproc.Body.Instructions.Count > 0)
                        {
                            var modCount = 0;
                            //Create the instructions to inject
                            Instruction codePosition = ilproc.Body.Instructions[ilproc.Body.Instructions.Count - 1];
                            foreach (AssemblyDefinition modArrayDef in _modAssemblyList)
                            {
                                foreach (TypeDefinition modTypeDef in modArrayDef.MainModule.Types)
                                {
                                    foreach (MethodDefinition modMethodDef in modTypeDef.Methods)
                                    {
                                        if (modMethodDef.Name == modMethodNames)
                                        {
                                            Debug.WriteLine("Found " + modMethodDef.Name + " function");
                                            MethodReference callRef = _mainFileAssemblyDef.MainModule.ImportReference(modMethodDef);
                                            Debug.WriteLine("Found call reference " + callRef.ToString());
                                            ilproc.InsertBefore(codePosition, ilproc.Create(OpCodes.Call, callRef));
                                            modCount++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Can't get method or insert instructions. Try narrowing down what modfile is breaking the insertion (Terminating modding attempt)");
                        return false;
                    }
                }
            }

            //save Assembly
            try { _mainFileAssemblyDef.Write(game_tempDir + "\\Assembly-CSharp-modded.dll"); }
            catch
            {
                MessageBox.Show("Could not write assembly! Is the game running?", "Error");
                return false;
            }

            _mainFileAssemblyDef.Dispose();
            foreach (var asm in _modAssemblyList) asm.Dispose();

            foreach (var mod in modsToInstall)
            {
                var path = game_tempDir + "\\" + mod + ".dll";
                if (path != game_tempDir + @"\Assembly-CSharp.dll")
                {
                    try { File.Copy(path, game_managedDir + "\\" + Path.GetFileName(path)); }
                    catch
                    {
                        File.Delete(game_managedDir + "\\" + Path.GetFileName(path));
                        File.Copy(path, game_managedDir + "\\" + Path.GetFileName(path));
                    }
                }

                var modResourcesDir = llbmm_modsDir + "\\" + mod + "\\" + mod + "Resources";
                if (Directory.Exists(modResourcesDir))
                {
                    Directory.CreateDirectory(game_managedDir + "\\" + mod + "Resources");

                    foreach (string dirPath in Directory.GetDirectories(modResourcesDir, "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(modResourcesDir, game_managedDir + "\\" + mod + "Resources")); 
                    foreach (string newPath in Directory.GetFiles(modResourcesDir, "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(modResourcesDir, game_managedDir + "\\" + mod + "Resources"), true);
                }
            }


            if (File.Exists(game_mainAsmFile))
            {
                File.Delete(game_mainAsmFile);
                File.Copy(game_tempDir + @"\Assembly-CSharp-modded.dll", game_mainAsmFile);
            }

            foreach (var mod in modsToInstall)
            {
                if (File.Exists(game_managedDir + "\\" + mod + "Resources\\ASMRewriter.exe"))
                {
                    RunRewriter(_gameDataFolder, game_managedDir + "\\" + mod + "Resources\\ASMRewriter.exe");
                }
            }
            try
            {
                File.Copy(game_tempDir + "\\ModMenu.dll", game_managedDir + "\\ModMenu.dll");
                RunRewriter(_gameDataFolder, llbmm_rootDir + "\\ModMenu\\ASMRewriter.exe");
            }
            catch { }

            if (Directory.Exists(game_tempDir))
            {
                DirectoryInfo di = new DirectoryInfo(game_tempDir);
                foreach (DirectoryInfo dir in di.GetDirectories()) dir.Delete(true);
                foreach (FileInfo file in di.GetFiles()) file.Delete();
                Directory.Delete(game_tempDir);
            }

            Debug.WriteLine("Modding complete!");
            return true;
        }


        public void RefreshInstalledMods(string _gameFolder, List<string> installedMods)
        {
            string managedFolder = _gameFolder + "\\Managed\\";
            string modsFolder = Directory.GetCurrentDirectory() + "\\mods\\";
            foreach(string mod in installedMods)
            {
                if (File.Exists(managedFolder + mod + ".dll") && File.Exists(modsFolder + mod + "\\" + mod + ".dll"))
                {
                    File.Delete(managedFolder + mod + ".dll");
                    File.Copy(modsFolder + mod + "\\" + mod + ".dll", managedFolder + mod + ".dll");

                    if (Directory.Exists(managedFolder + mod + "Resources") && Directory.Exists(modsFolder + mod + "\\" + mod + "Resources"))
                    {
                        foreach (string f in Directory.GetFiles(managedFolder + mod + "Resources")) File.Delete(f);
                        foreach (string dirPath in Directory.GetDirectories(modsFolder + mod + "\\" + mod + "Resources", "*", SearchOption.AllDirectories)) Directory.CreateDirectory(dirPath.Replace(modsFolder + mod + "\\" + mod + "Resources", managedFolder + mod + "Resources"));
                        foreach (string newPath in Directory.GetFiles(modsFolder + mod + "\\" + mod + "Resources", "*.*", SearchOption.AllDirectories)) File.Copy(newPath, newPath.Replace(modsFolder + mod + "\\" + mod + "Resources", managedFolder +  mod + "Resources"), true);
                    }
                }
            }
        }


        public void DoRewrite(string _gameFolder)
        {
            //Run all ASMRewriters
            var _rewriters = Directory.EnumerateFiles(_gameFolder + @"\Managed", "*", SearchOption.AllDirectories)
               .Where(s => s.EndsWith("ASMRewriter.exe") && s.Count(c => c == '.') == 1)
               .ToList();
            _rewriters.Add(Directory.GetCurrentDirectory() + @"\ModMenu\" + "ASMRewriter.exe");

            if (_rewriters != null)
            {
                foreach (var writer in _rewriters)
                {
                    var arg = _gameFolder + @"\Managed";
                    var newarg = arg.Replace(" ", "%20");
                    Process ExternalProcess = new Process();
                    ExternalProcess.StartInfo.FileName = writer;
                    ExternalProcess.StartInfo.Arguments = newarg; // supplies the exe with the needed path
                    ExternalProcess.Start();
                    ExternalProcess.WaitForExit();
                    ExternalProcess.Dispose();
                }
            }
        }

        public void RunRewriter(string _gameFolder, string path)
        {
            var arg = _gameFolder + @"\Managed";
            var newarg = arg.Replace(" ", "%20");
            Process ExternalProcess = new Process();
            ExternalProcess.StartInfo.FileName = path;
            ExternalProcess.StartInfo.Arguments = newarg; // supplies the exe with the needed path
            ExternalProcess.Start();
            ExternalProcess.WaitForExit();
            ExternalProcess.Dispose();
        }
    }
}
