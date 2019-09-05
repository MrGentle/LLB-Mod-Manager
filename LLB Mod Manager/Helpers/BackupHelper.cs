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
    public class BackupHelper
    {
        public void DoBackup(string gameDataFolder)
        {
            string assemblypath = gameDataFolder + @"\Managed\Assembly-CSharp.dll"; //Change paths after release
            string backupPath = gameDataFolder + @"\Managed\ModManagerBackup";

            if (File.Exists(assemblypath))
            {
                if (File.Exists(backupPath + @"\Assembly-CSharp-Backup.dll")) File.Delete(backupPath + @"\Assembly-CSharp-Backup.dll");

                try
                {
                    Directory.CreateDirectory(backupPath);
                    File.Copy(assemblypath, backupPath + @"\Assembly-CSharp-Backup.dll");
                }
                catch
                {
                    MessageBox.Show("Failed backup - could not create backup directory or could not copy the old assembly-csharp file", "Error");
                }
            }
        }

        public void RestoreBackup(string gameDataFolder)
        {
            string backupPath = gameDataFolder + @"\Managed\ModManagerBackup";
            if (File.Exists(backupPath + @"\Assembly-CSharp-Backup.dll"))
            {
                File.Delete(gameDataFolder + @"\Managed\Assembly-CSharp.dll");
                File.Copy(backupPath + @"\Assembly-CSharp-Backup.dll", gameDataFolder + @"\Managed\Assembly-CSharp.dll");
            }
        }

        public void DeleteBackup(string gameDataFolder)
        {
            string backupPath = gameDataFolder + @"\Managed\ModManagerBackup";
            if (File.Exists(backupPath + @"\Assembly-CSharp-Backup.dll"))
            {
                File.Delete(backupPath + @"\Assembly-CSharp-Backup.dll");
            }

            if (Directory.Exists(gameDataFolder + @"\Managed\ModManagerBackup"))
            {
                Directory.Delete(gameDataFolder + @"\Managed\ModManagerBackup");
            }
        }

    }
}
