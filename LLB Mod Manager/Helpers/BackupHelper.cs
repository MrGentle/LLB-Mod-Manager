using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace LLB_Mod_Manager
{
    class BackupHelper
    {
        /// <summary>
        /// Backs up the original game files
        /// </summary>
        /// <param name="gameDataFolder"></param>
        /// <returns></returns>
        public bool DoBackup(string gameDataFolder)
        {
            string assemblypath = gameDataFolder + @"\Managed\Assembly-CSharp.dll"; //Change paths after release
            string backupPath = gameDataFolder + @"\Managed\ModManagerBackup";



            if (File.Exists(assemblypath))
            {
                if (!File.Exists(backupPath + @"\Assembly-CSharp-Backup.dll"))
                {
                    try
                    {
                        Directory.CreateDirectory(backupPath);
                        File.Copy(assemblypath, backupPath + @"\Assembly-CSharp-Backup.dll");
                    }
                    catch
                    {
                        MessageBox.Show("Failed backup - could not create backup directory or could not copy the old assembly-csharp file", "Error");
                        return false;
                    }
                } else
                {
                    Debug.WriteLine("Backup exists - skipping");
                }
            } else
            {
                MessageBox.Show("Failed backup - Specified game folder is wrong (Terminating modding session)", "Error");
                return false;
            }

            return true;
        }

    }
}
