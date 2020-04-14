using System.IO;
using System.Windows.Forms;

namespace LLB_Mod_Manager
{
    public class BackupHelper
    {
        public void DoBackup(string gameDataFolder)
        {
            string assemblypath = gameDataFolder + @"\LLBlaze_Data\Managed\Assembly-CSharp.dll"; //Change paths after release
            string backupPath = gameDataFolder + @"\LLBlaze_Data\Managed\ModManagerBackup";

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
                    MessageBox.Show("Failed backup - Could not create backup directory or could not copy the old Assembly-CSharp file", "Error");
                }
            }
        }

        public void RestoreBackup(string gameDataFolder)
        {
            string backupPath = gameDataFolder + @"\LLBlaze_Data\Managed\ModManagerBackup";
            if (File.Exists(backupPath + @"\Assembly-CSharp-Backup.dll"))
            {
                File.Delete(gameDataFolder + @"\LLBlaze_Data\Managed\Assembly-CSharp.dll");
                File.Copy(backupPath + @"\Assembly-CSharp-Backup.dll", gameDataFolder + @"\LLBlaze_Data\Managed\Assembly-CSharp.dll");
            }
        }

        public void DeleteBackup(string gameDataFolder)
        {
            string backupPath = gameDataFolder + @"\LLBlaze_Data\Managed\ModManagerBackup";

            if (File.Exists(backupPath + @"\Assembly-CSharp-Backup.dll")) File.Delete(backupPath + @"\Assembly-CSharp-Backup.dll");
            if (Directory.Exists(backupPath)) Directory.Delete(backupPath);
        }

    }
}
