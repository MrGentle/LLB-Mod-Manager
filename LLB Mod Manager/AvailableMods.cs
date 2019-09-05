using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.ListBox;

namespace LLB_Mod_Manager
{
    public class AvailableMods
    {
        public IEnumerable<string> GetFrom(string sourceDirectory)
        {
            var dllFiles = Directory.EnumerateFiles(sourceDirectory, "*", SearchOption.AllDirectories)
               .Where(s => s.EndsWith(".dll") && !s.Contains("Resources")).ToList();

            return dllFiles;
        }
    }
}
