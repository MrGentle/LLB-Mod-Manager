using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace LLB_Mod_Manager
{
    public class Config
    {
        public void SaveConfig(string path, bool showReadme)
        {
            using (StreamWriter sw = File.CreateText(Directory.GetCurrentDirectory() + @"\config.txt"))
            {
                sw.WriteLine(path);
                sw.WriteLine(showReadme.ToString());
                sw.Close();
            }
        }

        public List<string> LoadConfig()
        {
            List<string> returnList = new List<string>();
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\config.txt"))
            {
                Debug.WriteLine("Config file does not exist");
            }
            else
            {
                var config = File.OpenText(Directory.GetCurrentDirectory() + @"\config.txt");
                returnList.Add(config.ReadLine());
                returnList.Add(config.ReadLine());
                config.Close();
                return returnList;
            }
            return returnList;
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
