using System.IO;
using System.Windows.Forms;

namespace LLB_Mod_Manager
{
    public class BackupHelper
    {
        public void DoBackup(string gameDataFolder)
        {
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            string assemblyPath = Path.Combine(gameDataFolder, gameDataDirName, "Managed", "Assembly-CSharp.dll");
            string backupPath = Path.Combine(gameDataFolder, gameDataDirName, "Managed", "ModManagerBackup");
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
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            string assemblyPath = Path.Combine(gameDataFolder, gameDataDirName, "Managed", "Assembly-CSharp.dll");
            string backupPath = Path.Combine(gameDataFolder, gameDataDirName, "Managed", "ModManagerBackup");
            string backupAssemblyPath = Path.Combine(backupPath, "Assembly-CSharp-Backup.dll");
            if (File.Exists(backupAssemblyPath))
            {
                File.Delete(assemblyPath);
                File.Copy(backupAssemblyPath, assemblyPath);
            }
        }

        public void DeleteBackup(string gameDataFolder)
        {
            string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
            string backupPath = Path.Combine(gameDataFolder, gameDataDirName, "Managed", "ModManagerBackup");
            string backupAssemblyPath = Path.Combine(backupPath, "Assembly-CSharp-Backup.dll");

            if (File.Exists(backupAssemblyPath)) File.Delete(backupAssemblyPath);
            if (Directory.Exists(backupPath)) Directory.Delete(backupPath);
        }

    }
}
