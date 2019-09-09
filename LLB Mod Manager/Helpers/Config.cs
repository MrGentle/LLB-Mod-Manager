using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace LLB_Mod_Manager
{
    public class Config
    {
        public void SaveConfig(string path)
        {
            using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + @"\config.txt"))
            {
                sw.WriteLine(path);
                sw.Close();
            }
        }

        public string LoadConfig()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\config.txt"))
            {
                Debug.WriteLine("Config file does not exist");
            }
            else
            {
                var config = File.OpenText(Directory.GetCurrentDirectory() + @"\config.txt");
                var returnString = config.ReadLine();
                config.Close();
                return returnString;
            }
            return "";
        }

        public string LoadGitToken()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\token.txt")) { }
            else
            {
                var token = File.OpenText(Directory.GetCurrentDirectory() + @"\token.txt");
                var returnString = token.ReadLine();
                token.Close();
                return returnString;
            }
            return "";
        }

    }
}
