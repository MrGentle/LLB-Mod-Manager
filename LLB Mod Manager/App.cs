using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Octokit;
using System.Runtime.InteropServices;

namespace LLB_Mod_Manager
{
    public partial class App : Form
    {
        public string gameFolderPathString = "";
        public string availableModsPath = "";
        public string dataFolderEnding = "";//@"\LLBlaze_Data";

        public Config _config = new Config();
        public CleanerHelper _cleanerHelper = new CleanerHelper();
        public BackupHelper _backupHelper = new BackupHelper();
        public AvailableMods _availableMods = new AvailableMods();
        public InjectionHelper _injectionHelper = new InjectionHelper();

        private string versionString = "v1.2.0";
        public string newestVersion = "";

        public App()
        {
            InitializeComponent();
            InitStyle();
           
            string configPath = _config.LoadConfig();

            if (configPath != "") //Check if LLBMM has been launched before, and if it has, check if mods are installed. if they are, add them to the installed mods list
            {
                gameFolderPath.Text = configPath;
                gameFolderPathString = configPath;
                if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
                {
                    var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                    installedMods.Items.Clear();
                    foreach (var mod in installedModsList) installedMods.Items.Add(mod);
                }
            }

            versionLabel.Text = "LLBMM is up to date: [ " + versionString + " ]";
            CheckVersion();


            string LLBMMPath = Directory.GetCurrentDirectory();
            availableModsPath = LLBMMPath + @"\mods";
            Directory.CreateDirectory(availableModsPath);

            GetAvailableModsAndAddThemToAvailbleModsList();

            if (File.Exists(Directory.GetCurrentDirectory() + @"\Readme.rtf"))
            {
                modInfoLabel.Text = "Mod Manager information";
                readmeBox.LoadFile(Directory.GetCurrentDirectory() + @"\Readme.rtf");
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _LLBFolderFinder = new FolderBrowserDialog();
            _LLBFolderFinder.Description = "Please select the LLBlaze_Data folder in the root directory of Lethal League Blaze";

            if (_config.LoadConfig() == "") _LLBFolderFinder.SelectedPath = Directory.GetCurrentDirectory();
            else _LLBFolderFinder.SelectedPath = _config.LoadConfig();

            if (_LLBFolderFinder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _config.SaveConfig(_LLBFolderFinder.SelectedPath);
                gameFolderPath.Text = _LLBFolderFinder.SelectedPath + dataFolderEnding;
                gameFolderPathString = _LLBFolderFinder.SelectedPath + dataFolderEnding;
                if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
                {
                    var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                    installedMods.Items.Clear();
                    foreach (var mod in installedModsList) installedMods.Items.Add(mod);
                }
            }
        }

        private void UninstallModsButton_Click(object sender, EventArgs e)
        {
            if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
            {
                var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                _cleanerHelper.RemoveMods(gameFolderPathString, installedModsList);
                installedMods.Items.Clear();
                GetAvailableModsAndAddThemToAvailbleModsList();
                _cleanerHelper.CleanGameFolder(gameFolderPathString);

                installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                if (installedModsList.Count() > 0) foreach (string mod in installedModsList) installedMods.Items.Add(mod);
                else
                {
                    _cleanerHelper.RemoveMod(gameFolderPathString, "ModMenu");
                    _backupHelper.RestoreBackup(gameFolderPathString);
                    _backupHelper.DeleteBackup(gameFolderPathString);
                }
            } else _cleanerHelper.CleanGameFolder(gameFolderPathString);
        }

        private void uninstallSelectedModButton_Click(object sender, EventArgs e)
        {
            if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
            {
                if (installedMods.SelectedItem != null)
                {
                    if (_cleanerHelper.RemoveMod(gameFolderPathString, installedMods.SelectedItem.ToString()))
                    {
                        availableMods.Items.Add(installedMods.SelectedItem);
                        installedMods.Items.Remove(installedMods.SelectedItem);

                        var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                        if (installedModsList.Count() == 0)
                        {
                            _cleanerHelper.RemoveMod(gameFolderPathString, "ModMenu");
                            _backupHelper.RestoreBackup(gameFolderPathString);
                            _backupHelper.DeleteBackup(gameFolderPathString);
                        }
                    }
                }
            }
        }

        private void AvailableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableMods.SelectedItem != null)
            {
                var selectedIndexName = availableMods.SelectedItem.ToString();
                var selectedIndexReadmePath = availableModsPath + @"\" + availableMods.SelectedItem.ToString() + @"\" + availableMods.SelectedItem.ToString() + ".rtf";
                modInfoLabel.Text = availableMods.SelectedItem.ToString() + " Readme";
                if (File.Exists(selectedIndexReadmePath)) readmeBox.LoadFile(selectedIndexReadmePath);
                else readmeBox.Text = "Mod has no readme file";
            }
        }

        private void sendToPendingModsButton_Click(object sender, EventArgs e)
        {
            if (availableMods.SelectedItem != null)
            {
                pendingMods.Items.Add(availableMods.SelectedItem);
                availableMods.Items.Remove(availableMods.SelectedItem);
            }
        }

        private void returnFromPendingModsButton_Click(object sender, EventArgs e)
        {
            if (pendingMods.SelectedItem != null)
            {
                availableMods.Items.Add(pendingMods.SelectedItem);
                pendingMods.Items.Remove(pendingMods.SelectedItem);
            }
        }

        private void sendAllModsToPendingModsButton_Click(object sender, EventArgs e)
        {
            if (availableMods.Items.Count > 0)
            {
                foreach (var item in availableMods.Items) pendingMods.Items.Add(item);
                availableMods.Items.Clear();
            }
        }

        private void InstallModsButton_Click(object sender, EventArgs e)
        {
            var terminated = false;
            if (pendingMods.Items.Count > 0) //If there are pending mods
            {
                var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                if (installedModsList == null) _backupHelper.DoBackup(gameFolderPathString);

                if (_injectionHelper.InstallSelectedMods(gameFolderPathString, availableMods, pendingMods, installedMods) == true) //If we successfully combined the mod files into the assembly
                {
                    installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString); //get the installed mods
                    installedMods.Items.Clear();
                    foreach (var mod in installedModsList) { installedMods.Items.Add(mod); }  //Add them to the installed mods list
                    pendingMods.Items.Clear(); //Clear the pending mods list
                }
                else terminated = true;
            } else MessageBox.Show("You have no pending mods to install, please select mods from the available mods list before trying to install.", "Error");

            if (terminated)
            {
                Debug.WriteLine("Terminated modding attempt. Trying to scrub mod files.");
                if (_cleanerHelper.CleanGameFolder(gameFolderPathString) == true) {}
            } 
        }

        private void PendingMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingMods.SelectedItem != null)
            {
                var selectedIndexName = pendingMods.SelectedItem.ToString();
                var selectedIndexReadmePath = availableModsPath + @"\" + pendingMods.SelectedItem.ToString() + @"\" + pendingMods.SelectedItem.ToString() + ".rtf";
                modInfoLabel.Text = pendingMods.SelectedItem.ToString() + " Readme";
                if (File.Exists(selectedIndexReadmePath)) readmeBox.LoadFile(selectedIndexReadmePath);
                else readmeBox.Text = "Mod has no readme file";
            }
        }

        private void InstalledMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (installedMods.SelectedItem != null)
            {
                var selectedIndexName = installedMods.SelectedItem.ToString();
                var selectedIndexReadmePath = availableModsPath + @"\" + installedMods.SelectedItem.ToString() + @"\" + installedMods.SelectedItem.ToString() + ".rtf";
                modInfoLabel.Text = installedMods.SelectedItem.ToString() + " Readme";
                if (File.Exists(selectedIndexReadmePath)) readmeBox.LoadFile(selectedIndexReadmePath);
                else readmeBox.Text = "Mod has no readme file";
            }
        }


        private void readmeButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Readme.rtf"))
            {
                modInfoLabel.Text = "Mod Manager information";
                readmeBox.LoadFile(Directory.GetCurrentDirectory() + @"\Readme.rtf");
            }
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MrGentle/LLB-Mod-Manager/releases");
        }

        private void GetAvailableModsAndAddThemToAvailbleModsList()
        {
            var availableModsFileList = _availableMods.GetFrom(availableModsPath);
            availableMods.Items.Clear();
            foreach (string item in availableModsFileList) //Check what mods are available for installation, and which are already installed
            {
                var addmod = true;
                var formatted = Path.GetFileNameWithoutExtension(item);
                foreach (var installedMod in installedMods.Items) if (formatted == installedMod.ToString()) addmod = false;
                if (addmod == true) availableMods.Items.Add(formatted);
            }
        }

        private async Task CheckVersion()
        {
            var client = new GitHubClient(new ProductHeaderValue("LLB-Mod-Manager"));
            var releases = await client.Repository.Release.GetAll("MrGentle", "LLB-Mod-Manager");
            newestVersion = releases[0].TagName;

            if (versionString != newestVersion)
            {
                versionLabel.Text = "LLBMM is outdated. Click here to update: [ " + versionString + " ] >> [ " + newestVersion + " ]";
                versionLabel.BackColor = Color.Red;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            try { HideCaret(readmeBox.Handle); } catch { }
        }

        private void InitStyle()
        {
            BackColor = Color.FromArgb(44, 44, 44);
            availableMods.BackColor = Color.FromArgb(34, 34, 34);
            installedMods.BackColor = Color.FromArgb(34, 34, 34);
            pendingMods.BackColor = Color.FromArgb(34, 34, 34);
            gameFolderPath.BackColor = Color.FromArgb(34, 34, 34);
            readmeBox.BackColor = Color.FromArgb(34, 34, 34);
            versionLabel.BackColor = Color.FromArgb(34, 34, 34);

            availableModsLabel.BackColor = Color.FromArgb(231, 76, 60);
            pendingModsLabel.BackColor = Color.FromArgb(231, 76, 60);
            installedModsLabel.BackColor = Color.FromArgb(231, 76, 60);
            modInfoLabel.BackColor = Color.FromArgb(231, 76, 60);
            LabelGameLocation.BackColor = Color.FromArgb(231, 76, 60);

            readmeButton.BackColor = Color.FromArgb(231, 76, 60);
            readmeButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            sendAllModsToPendingModsButton.BackColor = Color.FromArgb(231, 76, 60);
            sendAllModsToPendingModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            returnFromPendingModsButton.BackColor = Color.FromArgb(231, 76, 60);
            returnFromPendingModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            BrowseButton.BackColor = Color.FromArgb(231, 76, 60);
            BrowseButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            installModsButton.BackColor = Color.FromArgb(231, 76, 60);
            installModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            uninstallModsButton.BackColor = Color.FromArgb(231, 76, 60);
            uninstallModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            uninstallSelectedModButton.BackColor = Color.FromArgb(231, 76, 60);
            uninstallSelectedModButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            sendToPendingModsButton.BackColor = Color.FromArgb(231, 76, 60);
            sendToPendingModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

        }

        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        public static extern long HideCaret(IntPtr hwnd);
    }
}
