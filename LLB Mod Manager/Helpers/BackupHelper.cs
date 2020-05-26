using System.IO;
using System.Windows.Forms;

namespace LLB_Mod_Manager
{
    public class BackupHelper
    {
        public void DoBackup(string gameDataFolder)
        {
            string assemblyPath = Path.Combine(gameDataFolder, "LLBlaze_Data", "Managed", "Assembly-CSharp.dll");
            string backupPath = Path.Combine(gameDataFolder, "LLBlaze_Data", "Managed", "ModManagerBackup");
            string backupAssemblyPath = Path.Combine(backupPath, "Assembly-CSharp-Backup.dll");

            if (File.Exists(assemblyPath))
            {
                if (File.Exists(backupAssemblyPath)) File.Delete(backupAssemblyPath);

                try
                {
                    Directory.CreateDirectory(backupPath);
                    File.Copy(assemblyPath, backupAssemblyPath);
                }
                catch
                {
                    MessageBox.Show("Failed backup - Could not create backup directory or could not copy the old Assembly-CSharp file", "Error");
                }
            }
        }

        public void RestoreBackup(string gameDataFolder)
        {
            string assemblyPath = Path.Combine(gameDataFolder, "LLBlaze_Data", "Managed", "Assembly-CSharp.dll");
            string backupPath = Path.Combine(gameDataFolder, "LLBlaze_Data", "Managed", "ModManagerBackup");
            string backupAssemblyPath = Path.Combine(backupPath, "Assembly-CSharp-Backup.dll");
            if (File.Exists(backupAssemblyPath))
            {
                File.Delete(assemblyPath);
                File.Copy(backupAssemblyPath, assemblyPath);
            }
        }

        public void DeleteBackup(string gameDataFolder)
        {
            string backupPath = Path.Combine(gameDataFolder, "LLBlaze_Data", "Managed", "ModManagerBackup");
            string backupAssemblyPath = Path.Combine(backupPath, "Assembly-CSharp-Backup.dll");

            if (File.Exists(backupAssemblyPath)) File.Delete(backupAssemblyPath);
            if (Directory.Exists(backupPath)) Directory.Delete(backupPath);
        }

    }
}
