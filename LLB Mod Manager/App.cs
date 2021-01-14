using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public string dataFolderEnding = "";

        public Config _config = new Config();
        public CleanerHelper _cleanerHelper = new CleanerHelper();
        public BackupHelper _backupHelper = new BackupHelper();
        public AvailableMods _availableMods = new AvailableMods();
        public InjectionHelper _injectionHelper = new InjectionHelper();

        public GitHubClient GitClient = new GitHubClient(new ProductHeaderValue("LLBMM"));
        public Dictionary<string, List<string>> modsInformation = new Dictionary<string, List<string>>();

        private string versionString = "v1.3.0";
        public string newestVersion = "";

        public App()
        {
            InitializeComponent();

            InitStyle(); //Visual stuff
            InitConfig(); //Grab Configs and set paths

            InitToolTip();

            CheckVersion(); //Check if LLBMM is the latest version

            SetupInstalledModsDGV();
            GetInstalledModsAndAddThemToInstalledModsList();

            SetupAvailableModsDGV();
            GetAvailableModsAndAddThemToAvailbleModsList();

            ResizeWindow();
        }

        private void SetupAvailableModsDGV()
        {
            AvailableModsDGV.Columns.Add("Name", "Name");
            AvailableModsDGV.Columns[0].Width = 280;
            AvailableModsDGV.Columns.Add("Version", "Version");
            AvailableModsDGV.Columns[1].Width = 50;
            AvailableModsDGV.Columns.Add("Status", "Status");
            AvailableModsDGV.Columns[2].Width = 100;
            DataGridViewCheckBoxColumn installCollumn = new DataGridViewCheckBoxColumn();
            installCollumn.Width = 50;
            installCollumn.HeaderText = "Install";
            AvailableModsDGV.Columns.Add(installCollumn);
        }

        private void SetupInstalledModsDGV()
        {
            InstalledModsDGV.Columns.Add("Name", "Name");
            InstalledModsDGV.Columns[0].Width = 280;
            InstalledModsDGV.Columns.Add("Version", "Version");
            InstalledModsDGV.Columns[1].Width = 50;
            InstalledModsDGV.Columns.Add("Status", "Status");
            InstalledModsDGV.Columns[2].Width = 100;
            DataGridViewCheckBoxColumn removeCollumn = new DataGridViewCheckBoxColumn();
            removeCollumn.Width = 50;
            removeCollumn.HeaderText = "Remove";
            InstalledModsDGV.Columns.Add(removeCollumn);
        }

        private void GetAvailableModsAndAddThemToAvailbleModsList()
        {
            var availableModsFileList = _availableMods.GetFrom(availableModsPath);
            AvailableModsDGV.Rows.Clear();
            foreach (string item in availableModsFileList) //Check what mods are available for installation, and which are already installed
            {
                var addmod = true;
                foreach (DataGridViewRow row in InstalledModsDGV.Rows) if (Path.GetFileNameWithoutExtension(item) == row.Cells[0].Value.ToString()) addmod = false;
                if (addmod == true)
                {
                    var alreadyAdded = false;
                    foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (keyVal.Key == Path.GetFileNameWithoutExtension(item)) alreadyAdded = true;
                    if (!alreadyAdded)
                    {
                        List<string> modInfo = _availableMods.GetModInformation(item, GitClient);
                        modsInformation.Add(Path.GetFileNameWithoutExtension(item), modInfo);
                        AvailableModsDGV.Rows.Add(modInfo[0], modInfo[1], modInfo[2]);
                    }
                    else foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (keyVal.Key == Path.GetFileNameWithoutExtension(item)) AvailableModsDGV.Rows.Add(keyVal.Value[0], keyVal.Value[1], keyVal.Value[2]);

                }
            }

            if (AvailableModsDGV.Rows.Count < 7) AvailableModsDGV.Columns[0].Width = 297;
            else AvailableModsDGV.Columns[0].Width = 280;
        }

        private void GetInstalledModsAndAddThemToInstalledModsList()
        {
            var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
            if (installedModsList != null)
            {
                foreach (string mod in installedModsList)
                {
                    var alreadyAdded = false;
                    foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (keyVal.Key == mod) alreadyAdded = true;
                    if (!alreadyAdded)
                    {
                        List<string> modInfo = _availableMods.GetModInformation(Path.Combine(gameFolderPathString, PathHelper.Get().GetLLBGameDataDirName(), "Managed", mod + ".dll"), GitClient);
                        modsInformation.Add(Path.GetFileNameWithoutExtension(mod), modInfo);
                        InstalledModsDGV.Rows.Add(modInfo[0], modInfo[1], modInfo[2]);
                    }
                    else foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (keyVal.Key == Path.GetFileNameWithoutExtension(mod)) InstalledModsDGV.Rows.Add(keyVal.Value[0], keyVal.Value[1], keyVal.Value[2]);

                }
            }

            if (InstalledModsDGV.Rows.Count < 7) InstalledModsDGV.Columns[0].Width = 297;
            else InstalledModsDGV.Columns[0].Width = 280;
        }

        private void CheckVersion()
        {
            versionLabel.Text = "LLBMM is up to date: [ " + versionString + " ]";
            Task<IReadOnlyList<Release>> releases = GitClient.Repository.Release.GetAll("MrGentle", "LLB-Mod-Manager");
            try
            {
                releases.Wait();
                newestVersion = releases.Result[0].TagName;

                if (versionString != newestVersion)
                {
                    versionLabel.Text = "LLBMM is outdated. Click here to update: [ " + versionString + " ] >> [ " + newestVersion + " ]";
                    versionLabel.BackColor = Color.Red;
                }
            }
            catch (System.AggregateException)
            {
                MessageBox.Show("GitHub API RateLimit for checking mod updates has been reached. This limit is set at 60 requests for unauthenticated users.");
                versionLabel.Text = "GitHub API RateLimit Reached";
            }
        }

        private void InitStyle()
        {
            BackColor = Color.FromArgb(44, 44, 44);
            gameFolderPath.BackColor = Color.FromArgb(34, 34, 34);
            readmeBox.BackColor = Color.FromArgb(34, 34, 34);
            versionLabel.BackColor = Color.FromArgb(34, 34, 34);

            AvailableModsDGV.BackgroundColor = Color.FromArgb(34, 34, 34);
            AvailableModsDGV.ForeColor = Color.White;
            AvailableModsDGV.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            AvailableModsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 34, 34);
            AvailableModsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            AvailableModsDGV.GridColor = Color.FromArgb(44, 44, 44);

            AvailableModsDGV.EnableHeadersVisualStyles = false;
            AvailableModsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            AvailableModsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            InstalledModsDGV.BackgroundColor = Color.FromArgb(34, 34, 34);
            InstalledModsDGV.ForeColor = Color.White;
            InstalledModsDGV.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
            InstalledModsDGV.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 34, 34);
            InstalledModsDGV.RowsDefaultCellStyle.SelectionForeColor = Color.White;
            InstalledModsDGV.GridColor = Color.FromArgb(44, 44, 44);

            InstalledModsDGV.EnableHeadersVisualStyles = false;
            InstalledModsDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44);
            InstalledModsDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            availableModsLabel.BackColor = Color.FromArgb(231, 76, 60);
            installedModsLabel.BackColor = Color.FromArgb(231, 76, 60);
            modInfoLabel.BackColor = Color.FromArgb(231, 76, 60);
            LabelGameLocation.BackColor = Color.FromArgb(231, 76, 60);
            showReadmeLabel.BackColor = Color.FromArgb(231, 76, 60);

            readmeButton.BackColor = Color.FromArgb(231, 76, 60);
            readmeButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            stepByStepGuideButton.BackColor = Color.FromArgb(231, 76, 60);
            stepByStepGuideButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            BrowseButton.BackColor = Color.FromArgb(231, 76, 60);
            BrowseButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            SelectAllButton.BackColor = Color.FromArgb(231, 76, 60);
            SelectAllButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            DeselectAllButton.BackColor = Color.FromArgb(231, 76, 60);
            DeselectAllButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            installModsButton.BackColor = Color.FromArgb(231, 76, 60);
            installModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            uninstallModsButton.BackColor = Color.FromArgb(231, 76, 60);
            uninstallModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            uninstallSelectedModButton.BackColor = Color.FromArgb(231, 76, 60);
            uninstallSelectedModButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);

            refreshInstalledModsButton.BackColor = Color.FromArgb(231, 76, 60);
            refreshInstalledModsButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);
        }

        private void InitConfig()
        {
            List<string> configPath = _config.LoadConfig();

            if (configPath.Count > 0)
            {
                string gameDataDirName = PathHelper.Get().GetLLBGameDataDirName();
                string gameDirName = PathHelper.Get().GetLLBGameDirName();
                if (configPath[0].Contains(Path.DirectorySeparatorChar + gameDataDirName))
                {
                    MessageBox.Show("LLBMM has detected that you have "+ gameDataDirName +
                        " as your selected game folder. This version requires you to set your selected folder to "+
                        gameDirName +" instead. (The folder containing the exe)", "Warning");
                }
                gameFolderPath.Text = configPath[0];
                gameFolderPathString = configPath[0];
                if (configPath[1] == "True") showReadmeCheckbox.Checked = true;
                else showReadmeCheckbox.Checked = false;
                ResizeWindow();
            }

            string LLBMMPath = Directory.GetCurrentDirectory();
            availableModsPath = Path.Combine(LLBMMPath, "mods");
            Directory.CreateDirectory(availableModsPath);

            if (File.Exists(Path.Combine(LLBMMPath, "Readme.rtf")))
            {
                modInfoLabel.Text = "Mod Manager information";
                readmeBox.LoadFile(Path.Combine(LLBMMPath, "Readme.rtf"));
            }

            var token = _config.LoadGitToken();
            if (token != "")
            { 
                GitClient.Credentials = new Credentials(token);
                Debug.WriteLine("Loaded token " + token);
            }
        }

        private void InitToolTip()
        {
            ToolTip TT = new ToolTip();

            TT.AutoPopDelay = 5000;
            TT.InitialDelay = 1000;
            TT.ReshowDelay = 500;

            TT.ShowAlways = true;

            TT.SetToolTip(installModsButton, "Install every mod checked for installation");
            TT.SetToolTip(refreshInstalledModsButton, "Reinstalls the Resource and .dll files for every installed mod without having to inject code or reinstall ASMRewriters");
            TT.SetToolTip(uninstallSelectedModButton, "Uninstall every mod checked for removal");
            TT.SetToolTip(uninstallModsButton, "Uninstall every mod including ModMenu");
            TT.SetToolTip(stepByStepGuideButton, "Opens the step by step mod creation doc in a browser");
            TT.SetToolTip(readmeButton, "Shows the LLBMM instructions in the readme window");
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            string gameExecFilename = PathHelper.Get().GetLLBExecutableName();
            string gameDirName = PathHelper.Get().GetLLBGameDirName();

            FolderBrowserDialog _LLBFolderFinder = new FolderBrowserDialog();
            _LLBFolderFinder.Description = "Please select the "+ gameDirName + " folder (The folder where the .exe is located)";

            if (_config.LoadConfig().Count == 0) _LLBFolderFinder.SelectedPath = Directory.GetCurrentDirectory();
            else _LLBFolderFinder.SelectedPath = _config.LoadConfig()[0];

            if (_LLBFolderFinder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!File.Exists(Path.Combine(_LLBFolderFinder.SelectedPath, gameExecFilename)))
                {
                    MessageBox.Show("The selected directory does not contain "+ gameExecFilename + ", please select the folder containing said file.", "Warning");
                }
                _config.SaveConfig(_LLBFolderFinder.SelectedPath, showReadmeCheckbox.Checked);
                gameFolderPath.Text = _LLBFolderFinder.SelectedPath + dataFolderEnding;
                gameFolderPathString = _LLBFolderFinder.SelectedPath + dataFolderEnding;
                if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
                {
                    InstalledModsDGV.Rows.Clear();
                    GetInstalledModsAndAddThemToInstalledModsList();
                }
            }
        }

        private void ToggleCheckBox(DataGridViewCheckBoxCell checkBoxCell)
        {
            if (checkBoxCell.Selected)
            {
                if (checkBoxCell.Value == null || !checkBoxCell.Value.Equals(true))
                {
                    checkBoxCell.Value = true;
                }
                else
                {
                    checkBoxCell.Value = false;
                }
            }
        }
        private void AvailableModsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in AvailableModsDGV.Rows)
            {
                ToggleCheckBox(row.Cells[3] as DataGridViewCheckBoxCell);

                if (row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected || row.Cells[3].Selected)
                {
                    ReadmeBox_LoadMod(row.Cells[0].Value.ToString());
                }

                if (row.Cells[2].Selected) foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (row.Cells[0].Value.Equals(keyVal.Key) && keyVal.Value[3] != "??") Process.Start(keyVal.Value[3]);
            }
        }

        private void AvailableModsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in AvailableModsDGV.Rows)
            {
                if (row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected || row.Cells[3].Selected)
                {
                    ReadmeBox_LoadMod(row.Cells[0].Value.ToString());
                }
            }
        }

        private void InstalledModsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in InstalledModsDGV.Rows)
            {
                ToggleCheckBox(row.Cells[3] as DataGridViewCheckBoxCell);

                if (row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected || row.Cells[3].Selected)
                {
                    ReadmeBox_LoadMod(row.Cells[0].Value.ToString());
                }

                if (row.Cells[2].Selected) foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (row.Cells[0].Value.Equals(keyVal.Key) && keyVal.Value[3] != "??") Process.Start(keyVal.Value[3]);
            }
        }

        private void InstalledModsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in InstalledModsDGV.Rows)
            {
                if (row.Cells[0].Selected || row.Cells[1].Selected || row.Cells[2].Selected || row.Cells[3].Selected)
                {
                    ReadmeBox_LoadMod(row.Cells[0].Value.ToString());
                }
            }
        }

        private void ReadmeBox_LoadMod(string modName)
        {
            var modReadmePath = Path.Combine(availableModsPath, modName, modName + ".rtf");
            modInfoLabel.Text = modName + " Readme";
            if (File.Exists(modReadmePath)) readmeBox.LoadFile(modReadmePath);
            else readmeBox.Text = "Mod has no readme file";
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AvailableModsDGV.Rows) row.Cells[3].Value = true;
        }

        private void DeselectAllButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AvailableModsDGV.Rows) row.Cells[3].Value = false;
        }

        private void UninstallModsButton_Click(object sender, EventArgs e)
        {
            if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
            {
                var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                if (installedModsList.Count > 0)
                {
                    _cleanerHelper.RemoveMods(gameFolderPathString, installedModsList);
                    InstalledModsDGV.Rows.Clear();
                    GetAvailableModsAndAddThemToAvailbleModsList();
                    _cleanerHelper.CleanGameFolder(gameFolderPathString);
                }
                try
                {
                    _cleanerHelper.RemoveMod(gameFolderPathString, "ModMenu");
                    _backupHelper.RestoreBackup(gameFolderPathString);
                    _backupHelper.DeleteBackup(gameFolderPathString);
                } catch { Debug.WriteLine("Could not remove ModMenu. Please verify your files"); }
            } else _cleanerHelper.CleanGameFolder(gameFolderPathString);
        }

        private void uninstallSelectedModButton_Click(object sender, EventArgs e)
        {
            if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
            {
                List<string> modsToRemove = new List<string>();
                foreach (DataGridViewRow row in InstalledModsDGV.Rows) if (row.Cells[3].Value != null && row.Cells[3].Value.Equals(true)) modsToRemove.Add(row.Cells[0].Value.ToString());

                if (modsToRemove.Count > 0)
                {
                    foreach (var mod in modsToRemove)
                    {
                        if (_cleanerHelper.RemoveMod(gameFolderPathString, mod))
                        {
                            DataGridViewRow rowToRemove = null;
                            foreach (DataGridViewRow row in InstalledModsDGV.Rows) if (row.Cells[0].Value.ToString() == mod) rowToRemove = row;

                            InstalledModsDGV.Rows.Remove(rowToRemove);

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

                GetAvailableModsAndAddThemToAvailbleModsList();
            }
        }

        private void refreshInstalledModsButton_Click(object sender, EventArgs e)
        {
            var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
            if (installedModsList.Count > 0 && RefreshResetTimer.Enabled == false)
            {
                _injectionHelper.RefreshInstalledMods(gameFolderPathString, installedModsList);
                refreshInstalledModsButton.Text = "Mods Refreshed";
                refreshInstalledModsButton.Font = new Font(refreshInstalledModsButton.Font, FontStyle.Bold);
                RefreshResetTimer.Enabled = true;
            }
        }

        private void RefreshResetTimer_Tick(object sender, EventArgs e)
        {
            refreshInstalledModsButton.Text = "Refresh Installed Mods";
            refreshInstalledModsButton.Font = new Font(refreshInstalledModsButton.Font, FontStyle.Regular);
            RefreshResetTimer.Enabled = false;
        }

        private void InstallModsButton_Click(object sender, EventArgs e)
        {
            var terminated = false;
            List<string> modsToInstall = new List<string>();
            foreach(DataGridViewRow row in AvailableModsDGV.Rows) if (row.Cells[3].Value != null && row.Cells[3].Value.Equals(true)) modsToInstall.Add(row.Cells[0].Value.ToString());

            if (modsToInstall.Count > 0)
            {
                var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                if (installedModsList == null) _backupHelper.DoBackup(gameFolderPathString);

                if (_injectionHelper.InstallSelectedMods(gameFolderPathString, modsToInstall) == true) //If we successfully combined the mod files into the assembly
                {
                    installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString); //get the installed mods
                    InstalledModsDGV.Rows.Clear();
                    foreach (string mod in installedModsList)
                    {
                        var alreadyAdded = false;
                        foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (keyVal.Key == mod) alreadyAdded = true;
                        if (!alreadyAdded)
                        {
                            List<string> modInfo = _availableMods.GetModInformation(Path.Combine(gameFolderPathString, PathHelper.Get().GetLLBGameDataDirName(), "Managed", mod + ".dll"), GitClient);
                            modsInformation.Add(Path.GetFileNameWithoutExtension(mod), modInfo);
                            InstalledModsDGV.Rows.Add(modInfo[0], modInfo[1], modInfo[2]);
                        }
                        else foreach (KeyValuePair<string, List<string>> keyVal in modsInformation) if (keyVal.Key == mod) InstalledModsDGV.Rows.Add(keyVal.Value[0], keyVal.Value[1], keyVal.Value[2]);
                    }

                    GetAvailableModsAndAddThemToAvailbleModsList();

                    if (InstalledModsDGV.Rows.Count < 7) InstalledModsDGV.Columns[0].Width = 297;
                    else InstalledModsDGV.Columns[0].Width = 280;
                }
                else terminated = true;
            }

            if (terminated)
            {
                Debug.WriteLine("Terminated modding attempt. Trying to scrub mod files.");
                if (_cleanerHelper.CleanGameFolder(gameFolderPathString) == true) {}
            } 
        }

        private void readmeButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(),"Readme.rtf")))
            {
                modInfoLabel.Text = "Mod Manager information";
                readmeBox.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), "Readme.rtf"));
            }
        }

        private void stepByStepGuideButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://docs.google.com/document/d/18CHOzfFKfhW9Ch-zbERdJ5kGqhePSTJ3D3EEeA6R1-Q/edit?usp=sharing");
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MrGentle/LLB-Mod-Manager/releases");
        }

        private void readmeBox_Enter(object sender, EventArgs e)
        {
            AvailableModsDGV.Focus();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            try { HideCaret(readmeBox.Handle); } catch { }
        }

        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        public static extern long HideCaret(IntPtr hwnd);

        private void showReadmeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ResizeWindow();

            List<string> config = new List<string>();
            config = _config.LoadConfig();

            if (config.Count == 2) _config.SaveConfig(config[0], showReadmeCheckbox.Checked);
            else _config.SaveConfig(@"c:\", showReadmeCheckbox.Checked); // TODO I don't get this one
        }

        private void ResizeWindow()
        {
            //if (!showReadmeCheckbox.Checked) this.Size = new Size(540, 590);
            //else this.Size = new Size(1070, 590);
        }

        private void buyMeACoffeeButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.buymeacoffee.com/MrGentle");
        }
    }
}
