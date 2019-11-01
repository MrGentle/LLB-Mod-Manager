using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Mono.Cecil;
using Octokit;


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

        public List<string> GetModInformation(string filePath, GitHubClient GitClient)
        {
            ///Returned list: Name, version, status
            List<string> ret = new List<string>();
            ret.Add(Path.GetFileNameWithoutExtension(filePath));

            AssemblyDefinition asmDef = AssemblyDefinition.ReadAssembly(filePath);
            string currentVer = "";
            string repoOwner = "";
            string repoName = "";
            foreach (TypeDefinition t in asmDef.MainModule.Types)
            {
                foreach (FieldDefinition f in t.Fields)
                {
                    if (f.Name == "modVersion") currentVer = f.Constant.ToString();
                    if (f.Name == "repositoryOwner") repoOwner = f.Constant.ToString();
                    if (f.Name == "repositoryName") repoName = f.Constant.ToString();
                }
            }
            asmDef.Dispose();

            if (currentVer != "")
            {
                ret.Add(currentVer);

                if (repoOwner != "" && repoName != "")
                {
                    string status = CheckModStatus(repoOwner, repoName, currentVer, GitClient);
                    ret.Add(status);
                } else ret.Add("??");
            }
            else
            {
                ret.Add("??");
                ret.Add("??");
            }

            if (repoOwner != "" && repoName != "") ret.Add("https://github.com/" + repoOwner + "/" + repoName + "/releases");
            else ret.Add("??");

            return ret;
        }

        private string CheckModStatus(string repositoryOwner, string repositoryName, string currentVersion, GitHubClient GitClient)
        {
            Task<IReadOnlyList<Release>> releases = GitClient.Repository.Release.GetAll(repositoryOwner, repositoryName);
            try
            {
                releases.Wait();
                if (releases.Result[0].TagName != currentVersion) return "Outdated [Click]";
                else return "Up to date";
            }
            catch (System.AggregateException)
            {
                return "GitAPI RateLimited";
            }
        }
    }
}
