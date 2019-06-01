using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace LLB_Mod_Mananger
{
    class InjectionHelper
    {
        public bool buildFailed = false;

        public bool CombineMods(string _gameFolder, ObjectCollection _modList)
        {
            
            string[] modArray = new string[_modList.Count];
            var _modDirectory = Directory.GetCurrentDirectory() + @"\mods";
            var count = 0;

            //Get paths for all mod files
            foreach (var item in _modList)
            {
                modArray[count] = _modDirectory + @"\" + item.ToString() + @"\" + item.ToString() + ".dll";
                if (File.Exists(modArray[count]))
                {
                    Debug.WriteLine(modArray[count] + " Exists");
                } else
                {
                    MessageBox.Show("Can't find mod file " + _modDirectory + @"\" + item.ToString() + @"\" + item.ToString() + ".dll (Terminating modding session)","Error");
                    return false;
                }
                count++;
            }

            //Create temp folder to mod the main file in
            var _tempFolderPath = _gameFolder + @"\Managed\temp";
            var _assemblyFilePath = _gameFolder + @"\Managed\Assembly-CSharp.dll";
            if (!File.Exists(_assemblyFilePath))
            {
                MessageBox.Show("This is not the correct root folder", "");
                return false;
            }

            if (!Directory.Exists(_tempFolderPath))
            {
                Directory.CreateDirectory(_gameFolder + @"\Managed\temp");
            }

            Debug.WriteLine("Copying files to temp folder");
            try
            {
                File.Copy(_assemblyFilePath, _tempFolderPath + @"\Assembly-CSharp.dll");
                Debug.WriteLine("Copying assembly file");
            } catch
            {
                MessageBox.Show("Could not copy files to temp folder (Terminating modding session)", "Error");
            }
            foreach (var path in modArray)
            {
                try
                {
                    var modName = path.Replace(Directory.GetCurrentDirectory() + @"\mods\", "");
                    var modName2 = StringBuilding.getBetweenStr(modName, @"\", ".dll");
                    File.Copy(path, _tempFolderPath + @"\" + path.Replace(Directory.GetCurrentDirectory() + @"\mods\" + modName2 + @"\", ""));
                    Debug.WriteLine("Copying " + path + " to " + _tempFolderPath + @"\" + path.Replace(Directory.GetCurrentDirectory() + @"\mods\" + modName2 + @"\", ""));
                } catch
                {
                    MessageBox.Show("Could not copy files to temp folder (Terminating modding session)", "Error");
                    buildFailed = true;
                }
            }

            var _tempFiles = Directory.EnumerateFiles(_tempFolderPath, "*", SearchOption.AllDirectories)
               .Where(s => s.EndsWith(".dll") && s.Count(c => c == '.') == 1)
               .ToList();



            ///Start combining files in temp folder
            string injectTypeName = "LLScreen.ScreenIntroTitle"; // What type to inject into in Assemby-CSharp
            string injectMethodName = "CShowTitle"; // Method name in the type

            string modMethodNames = "Initialize";

            //Init Resolver
            DefaultAssemblyResolver defaultAssemblyResolver = new DefaultAssemblyResolver();
            defaultAssemblyResolver.AddSearchDirectory(_gameFolder + @"\Managed");
            defaultAssemblyResolver.AddSearchDirectory(_gameFolder + @"\Managed\temp");
            defaultAssemblyResolver.AddSearchDirectory(Directory.GetCurrentDirectory());
            ReaderParameters parameters = new ReaderParameters
            {
                AssemblyResolver = defaultAssemblyResolver
            };

            //Get the assembly definitions of the main file
            AssemblyDefinition _mainFileAssemblyDef = AssemblyDefinition.ReadAssembly(_tempFolderPath + @"\Assembly-CSharp.dll", parameters);
            ModuleDefinition _mainFileMainModule = _mainFileAssemblyDef.MainModule;

            //Get the assembly definitions of the mod files
            AssemblyDefinition[] _modAssemblyArray = new AssemblyDefinition[_tempFiles.Count-1];
            var asmcount = 0;
            foreach (string path in _tempFiles)
            {
                if (path != _tempFolderPath + @"\Assembly-CSharp.dll")
                {
                    try
                    {
                        _modAssemblyArray[asmcount] = AssemblyDefinition.ReadAssembly(path);
                        asmcount++;
                    } catch
                    {
                        MessageBox.Show("Mod files can't be injected (Bad file)", "Error");
                    }
                }
            }



            //create custom class that holds mod names
            TypeDefinition moddedClass = new TypeDefinition("", "Mods", TypeAttributes.Public | TypeAttributes.Class, _mainFileMainModule.TypeSystem.Object);
            //insert custom class into assembly
            _mainFileMainModule.Types.Add(moddedClass);
            moddedClass.Methods.Add(new MethodDefinition(".ctor", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName, _mainFileMainModule.TypeSystem.Void));
            foreach(var mod in _modList)
            {
                moddedClass.Fields.Add(new FieldDefinition(mod.ToString(), FieldAttributes.Public, _mainFileMainModule.TypeSystem.String));
            }

            TypeDefinition injectPointType = _mainFileAssemblyDef.MainModule.GetType(injectTypeName);
            if(injectPointType == null)
            {
                buildFailed = true;
                MessageBox.Show("Bad inject point (Terminating modding session)");
            } else
            {
                if (injectPointType.Methods == null)
                {
                    buildFailed = true;
                    MessageBox.Show("Bad inject point (Terminating modding session)");
                }
            }

            if (buildFailed == false)
            {
                foreach (MethodDefinition method in injectPointType.Methods)
                {
                    if (method.Name == injectMethodName)
                    {
                        try
                        {
                            Debug.WriteLine("Trying to get method for " + method.Name);
                            ILProcessor ilproc = method.Body.GetILProcessor();
                            if (ilproc.Body.Instructions.Count > 0)
                            {
                                var modCount = 0;
                                //Create the instructions to inject
                                Instruction codePosition = ilproc.Body.Instructions[ilproc.Body.Instructions.Count - 1];
                                foreach (AssemblyDefinition modArrayDef in _modAssemblyArray)
                                {
                                    foreach (TypeDefinition modTypeDef in modArrayDef.MainModule.Types)
                                    {
                                        foreach (MethodDefinition modMethodDef in modTypeDef.Methods)
                                        {
                                            if (modMethodDef.Name == modMethodNames)
                                            {
                                                Debug.WriteLine("Found " + modMethodDef.Name + " function");
                                                MethodReference callRef = _mainFileAssemblyDef.MainModule.Import(modMethodDef);
                                                Debug.WriteLine("Found call reference " + callRef.ToString());
                                                ilproc.InsertBefore(codePosition, ilproc.Create(OpCodes.Call, callRef));
                                                modCount++;
                                            }
                                        }
                                    }
                                }
                                Debug.WriteLine("Finished injecting IL (Wrote " + modCount + " instructions)");
                            }
                        }
                        catch { MessageBox.Show("Can't get method or insert instructions"); }
                    }
                }


                //save Assembly
                try
                {
                    _mainFileAssemblyDef.Write(_tempFolderPath + @"\Assembly-CSharp-modded.dll");
                }
                catch
                {
                    MessageBox.Show("Could not write assembly! Is the game running?", "Error");
                    buildFailed = true;
                }


                _mainFileAssemblyDef.Dispose();
                foreach (var asm in _modAssemblyArray)
                {
                    asm.Dispose();
                }


                if (buildFailed == false)
                {
                    foreach (var file in _tempFiles)
                    {
                        if (file != _tempFolderPath + @"\Assembly-CSharp.dll")
                        {
                            try
                            {
                                File.Copy(file, _gameFolder + @"\Managed\" + file.Replace(_tempFolderPath + @"\", ""));
                            }
                            catch
                            {
                                Debug.WriteLine(file + " Already exists");
                            }
                        }
                    }

                    foreach(var mod in modArray)
                    {
                        foreach (var modName in _modList)
                        {
                            if (mod.Contains(modName.ToString()))
                            {
                                var modDirectory = mod.Replace(modName.ToString() + ".dll","") + modName.ToString() + "Resources";
                                if (Directory.Exists(modDirectory))
                                {
                                    Directory.CreateDirectory(_gameFolder + @"\Managed\" + modName.ToString() + "Resources");
                                    foreach (string dirPath in Directory.GetDirectories(modDirectory, "*", SearchOption.AllDirectories))
                                    {
                                        Directory.CreateDirectory(dirPath.Replace(modDirectory, _gameFolder + @"\Managed\" + modName.ToString() + "Resources"));
                                    }
                                    foreach (string newPath in Directory.GetFiles(modDirectory, "*.*", SearchOption.AllDirectories))
                                        File.Copy(newPath, newPath.Replace(modDirectory, _gameFolder + @"\Managed\" + modName.ToString() + "Resources"), true);
                                }
                            }
                        }
                    }
                }
                if (File.Exists(_assemblyFilePath) && buildFailed == false)
                {
                    File.Delete(_assemblyFilePath);
                    File.Copy(_tempFolderPath + @"\Assembly-CSharp-modded.dll", _assemblyFilePath);
                }
            }



            //Clean up temp folder
            Debug.WriteLine("Cleaning up temp files");
            try
            {
                File.Delete(_tempFolderPath + @"\Assembly-CSharp-modded.dll");
            } catch
            {
                Debug.WriteLine("Could not delete " + _tempFolderPath + @"\Assembly-CSharp-modded.dll");
            }
            foreach (var item in _tempFiles)
            {
                try
                {
                    File.Delete(item);
                } catch
                {
                    Debug.WriteLine("Could not delete " + item + " from temp folder");
                }
            }

            try
            {
                Directory.Delete(_tempFolderPath);
            }
            catch
            {
                MessageBox.Show("Could not delete temp folder for this install, please browse to your folder and remove it manually | LLBlaze_data\\Managed\\temp");
            }

            if (buildFailed == false)
            {
                Debug.WriteLine("Modding complete!");
            } else
            {
                Debug.WriteLine("Modding failed");
            }
            return true;
        }

        /// <summary>
        /// Runs all the ASMRewriter files that ships with the mods. These files apply small changes to the assembly so that the mod can gain access to the classes, methods and fields it needs
        /// </summary>
        /// <param name="_gameFolder"></param>
        public void DoRewrite(string _gameFolder)
        {
            //Run all ASMRewriters
            var _rewriters = Directory.EnumerateFiles(_gameFolder + @"\Managed", "*", SearchOption.AllDirectories)
               .Where(s => s.EndsWith("ASMRewriter.exe") && s.Count(c => c == '.') == 1)
               .ToList();

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
    }
}
