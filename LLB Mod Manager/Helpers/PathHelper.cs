using System;
using System.IO;
namespace LLB_Mod_Manager
{

    public class PathHelper
    {
        private static PathHelper ph = null;
        private bool _isWindows = false;
        private bool _isLinux = false;
        private bool _isOSX = false;

        private PathHelper()
        {
            this.SetPlatform();
        }

        public static PathHelper Get()
        {
            if (ph == null) ph = new PathHelper();
            return ph;
        }
        public string GetLLBExecutableName()
        {
            string filename = null;
            if (_isWindows) filename = "LLBlaze.exe";
            else if (_isLinux)
            {
                if (System.Environment.Is64BitOperatingSystem) filename = "LLBlaze.x86_64";
                else filename = "LLBlaze.x86";
            }
            else if (_isOSX) filename = "LLBlaze";

            return filename;
        }
        public string GetLLBExecutablePath(string gameDirPath)
        {
            string execPath = null;
            if (_isWindows || _isLinux) execPath = Path.Combine(gameDirPath, GetLLBExecutableName());
            else if (_isOSX) execPath = Path.Combine(gameDirPath, "Contents", "MacOS", GetLLBExecutableName());

            return execPath;
        }
        public string GetLLBGameDirName()
        {
            string filename = null;
            if (_isWindows) filename = "LLBlaze";
            else if (_isLinux) filename = "LLBlaze";
            else if (_isOSX) filename = "LLBlaze.app";

            return filename;
        }
        public string GetLLBGameDataDirName()
        {
            string filename = null;
            if (_isWindows) filename = "LLBlaze_Data";
            else if (_isLinux) filename = "LLBlaze_Data";
            else if (_isOSX) filename = "Data";

            return filename;
        }
        public string GetLLBGameDataDirPath(string gameDirPath)
        {
            string dataDirPath = null;
            if (_isWindows || _isLinux) dataDirPath = Path.Combine(gameDirPath, GetLLBGameDataDirName());
            else if (_isOSX) dataDirPath = Path.Combine(gameDirPath, "Contents", "Resources", GetLLBGameDataDirName());

            return dataDirPath;
        }
        public string GetLLBGameManagedDirPath(string gameDirPath)
        {
            return Path.Combine(GetLLBGameDataDirPath(gameDirPath), "Managed");
        }
        public string GetLLBGameBundleDirPath(string gameDirPath)
        {
            string bundleDirPath = null;
            if (_isWindows || _isLinux) bundleDirPath = Path.Combine(gameDirPath, "Bundles");
            else if (_isOSX) bundleDirPath = Path.Combine(GetLLBGameDataDirPath(gameDirPath), "StreamingAssets", "Bundles");

            return bundleDirPath;
        }

        private void SetPlatform()
        {
            // see https://stackoverflow.com/questions/38790802/determine-operating-system-in-net-core/38795621#38795621
            string windir = Environment.GetEnvironmentVariable("windir");
            if (!string.IsNullOrEmpty(windir) && windir.Contains(@"\") && Directory.Exists(windir))
            {
                _isWindows = true;
            }
            else if (File.Exists(@"/proc/sys/kernel/ostype"))
            {
                string osType = File.ReadAllText(@"/proc/sys/kernel/ostype");
                if (osType.StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
                {
                    // Note: Android gets here too
                    _isLinux = true;
                }
                else
                {
                    throw new PlatformNotSupportedException(osType);
                }
            }
            else if (File.Exists(@"/System/Library/CoreServices/SystemVersion.plist"))
            {
                // Note: iOS gets here too
                _isOSX = true;
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        public string getPlatform()
        {
            if (_isWindows) return "Windows";
            else if (_isLinux) return "Linux";
            else if (_isOSX) return "MacOS";
            else return "Unknown";
        }
    }
}
