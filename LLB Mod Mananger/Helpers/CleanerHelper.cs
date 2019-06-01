using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Mono.Cecil.Cil;
using static System.Windows.Forms.ListBox;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace LLB_Mod_Mananger
{
    class CleanerHelper
    {
        private AssemblyDefinition asmDef;
        private ModuleDefinition mainModule;


        /// <summary>
        /// Checks If the game is modded
        /// </summary>
        /// <param name="_gameFolder"></param>
        /// <returns>bool isModded</returns>
        public bool CheckModStatus(string _gameDataFolder)
        {
            try
            {
                asmDef = AssemblyDefinition.ReadAssembly(_gameDataFolder + @"\Managed\Assembly-CSharp.dll");
            } catch
            {
                Debug.WriteLine("CleanerHelper.CheckModStatus: Could not find assembly");
                return false;
            }
            mainModule = asmDef.MainModule;
            var isModded = false;
            foreach(var type in mainModule.Types)
            {
                if (type.Name == "Mods")
                {
                    isModded = true;
                    Debug.WriteLine("Mod status: Modded");
                }
            }

            if (isModded == false)
            {
                Debug.WriteLine("Mod status: Clean");
            }
            asmDef.Dispose();
            return isModded;
        }

        /// <summary>
        /// Checks what mods are installed
        /// </summary>
        /// <param name="_gameFolder"></param>
        /// <returns>String[] installedModList</returns>
        public IEnumerable<string> InstalledMods(string _gameDataFolder)
        {
            try
            {
                asmDef = AssemblyDefinition.ReadAssembly(_gameDataFolder + @"\Managed\Assembly-CSharp.dll");
            }
            catch
            {
                Debug.WriteLine("CleanerHelper.InstalledMods: Could not find assembly");
                return null;
            }
            mainModule = asmDef.MainModule;
            TypeDefinition typeDef = null;

            foreach (var type in mainModule.Types)
            {
                if (type.Name == "Mods")
                {
                    typeDef = type;
                }
            }

            if (typeDef == null)
            {
                Debug.WriteLine("CleanerHelper.InstalledMods: TypeDefinition in was null");
                return null;
            }

            var counter = 0;
            String[] installedModsList = new String[typeDef.Fields.Count];
            if (typeDef != null)
            {
                foreach (var field in typeDef.Fields)
                {
                    installedModsList[counter] = field.Name;
                    counter++;
                }
            } else
            {
                return null;
            }
            asmDef.Dispose();
            return installedModsList;
        }

        /// <summary>
        /// Removes all mods from installation and deletes their files from the game folder
        /// </summary>
        /// <param name="_gameFolder"></param>
        /// <param name="_modlist"></param>
        public void RemoveMods(string _gameDataFolder, IEnumerable<string> _modlist)
        {
            foreach (var mod in _modlist)
            {
                if (File.Exists(_gameDataFolder + @"\Managed\" + mod.ToString() + ".dll"))
                {
                    File.Delete(_gameDataFolder + @"\Managed\" + mod.ToString() + ".dll");
                    Debug.WriteLine("CleanerHelper.RemoveMods: Removed " + mod.ToString() + ".dll");
                }

                if (Directory.Exists(_gameDataFolder + @"\Managed\" + mod.ToString() + "Resources"))
                {
                    Directory.Delete(_gameDataFolder + @"\Managed\" + mod.ToString() + "Resources", true);
                }
            }

            if (File.Exists(_gameDataFolder + @"\Managed\ModManagerBackup\Assembly-CSharp-Backup.dll"))
            {
                File.Delete(_gameDataFolder + @"\Managed\Assembly-CSharp.dll");
                File.Copy(_gameDataFolder + @"\Managed\ModManagerBackup\Assembly-CSharp-Backup.dll", _gameDataFolder + @"\Managed\Assembly-CSharp.dll");
                MessageBox.Show("All mods have been removed", "");
            }

        }
    }
}
