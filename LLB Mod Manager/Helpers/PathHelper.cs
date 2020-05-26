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
            this.setPlatform();
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
                if (System.Environment.Is64BitOperatingSystem) filename = "LLBLAZE.x86_64";
                else filename = "LLBLAZE.x86";
            }
            else if (_isOSX) filename = "";

            return filename;
        }
        public string GetLLBGameDirName()
        {
            string filename = null;
            if (_isWindows) filename = "LLBlaze";
            else if (_isLinux) filename = "LLBlaze";
            else if (_isOSX) filename = "";

            return filename;
        }
        public string GetLLBGameDataDirName()
        {
            string filename = null;
            if (_isWindows) filename = "LLBlaze_Data";
            else if (_isLinux) filename = "LLBLAZE_Data";
            else if (_isOSX) filename = "";

            return filename;
        }

        private void setPlatform()
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
    }
}
