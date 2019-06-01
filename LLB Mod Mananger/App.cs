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

namespace LLB_Mod_Mananger
{
    public partial class App : Form
    {
        public string gameFolderPathString = "";
        public string availableModsPath = "";
        public string dataFolderEnding = "";//@"\LethalLeague_B_Data";


        public App()
        {
            InitializeComponent();
            var _config = new Config();
            string configPath = _config.LoadConfig();
            if (configPath != "")
            {
                gameFolderPath.Text = configPath;
                gameFolderPathString = configPath;
                var _cleanerHelper = new CleanerHelper();
                if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
                {
                    var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                    installedMods.Items.Clear();
                    foreach (var mod in installedModsList)
                    {
                        installedMods.Items.Add(mod);
                    }
                }
            }

            string path = Directory.GetCurrentDirectory();
            availableModsPath = path + @"\mods";

            if (!Directory.Exists(path + @"\mods"))
            {
                Directory.CreateDirectory(path + @"\mods");
            }

            var _getAvailableMods = new AvailableMods();
            var availableModsFileList = _getAvailableMods.GetFrom(availableModsPath);

            foreach (string item in availableModsFileList)
            {
                var addmod = true;
                var changedItem = item.Replace(availableModsPath + @"\", "");
                var changedItem2 = StringBuilding.getBetweenStr(changedItem, @"\", ".dll");
                foreach (var installedMod in installedMods.Items)
                {
                    if (changedItem2 == installedMod.ToString())
                    {
                        addmod = false;
                    }
                }

                if (addmod == true)
                {
                    availableMods.Items.Add(changedItem2);
                }
            }

            if (File.Exists(Directory.GetCurrentDirectory() + @"\Readme.rtf"))
            {
                groupBox1.Text = "Mod Manager information";
                richTextBox1.LoadFile(Directory.GetCurrentDirectory() + @"\Readme.rtf");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _LLBFolderFinder = new FolderBrowserDialog();
            _LLBFolderFinder.Description = "Please select the LLBlaze_Data folder in the root directory of Lethal League Blaze";
            _LLBFolderFinder.SelectedPath = @"c:\";
            if (_LLBFolderFinder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var _config = new Config();
                _config.SaveConfig(_LLBFolderFinder.SelectedPath);
                gameFolderPath.Text = _LLBFolderFinder.SelectedPath + dataFolderEnding;
                gameFolderPathString = _LLBFolderFinder.SelectedPath + dataFolderEnding;
                var _cleanerHelper = new CleanerHelper();
                if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
                {
                    var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                    installedMods.Items.Clear();
                    foreach (var mod in installedModsList)
                    {
                        installedMods.Items.Add(mod);
                    }
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var _BackupHelper = new BackupHelper();
            if (_BackupHelper.DoBackup(gameFolderPathString) == true)
            {
                var _CleanerHelper = new CleanerHelper();
                if (_CleanerHelper.CheckModStatus(gameFolderPathString) == true)
                {
                    var installedModsList = _CleanerHelper.InstalledMods(gameFolderPathString);
                    _CleanerHelper.RemoveMods(gameFolderPathString, installedModsList);
                    installedMods.Items.Clear();
                    availableMods.Items.Clear();

                    var _getAvailableMods = new AvailableMods();
                    var availableModsFileList = _getAvailableMods.GetFrom(availableModsPath);
                    foreach (string item in availableModsFileList)
                    {
                        var addmod = true;
                        var changedItem = item.Replace(availableModsPath + @"\", "");
                        var changedItem2 = StringBuilding.getBetweenStr(changedItem, @"\", ".dll");
                        foreach (var installedMod in installedMods.Items)
                        {
                            if (changedItem2 == installedMod.ToString())
                            {
                                addmod = false;
                            }
                        }

                        if (addmod == true)
                        {
                            availableMods.Items.Add(changedItem2);
                        }
                    }
                }
            }
        }

        private void availableMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableMods.SelectedItem != null)
            {
                var selectedIndexName = availableMods.SelectedItem.ToString();
                var selectedIndexReadmePath = availableModsPath + @"\" + availableMods.SelectedItem.ToString() + @"\" + availableMods.SelectedItem.ToString() + ".rtf";
                groupBox1.Text = availableMods.SelectedItem.ToString() + " Readme";
                if (File.Exists(selectedIndexReadmePath))
                {
                    richTextBox1.LoadFile(selectedIndexReadmePath);
                } else
                {
                    richTextBox1.Text = "Mod has no readme file";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (availableMods.SelectedItem != null)
            {
                pendingMods.Items.Add(availableMods.SelectedItem);
                availableMods.Items.Remove(availableMods.SelectedItem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pendingMods.SelectedItem != null)
            {
                availableMods.Items.Add(pendingMods.SelectedItem);
                pendingMods.Items.Remove(pendingMods.SelectedItem);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (availableMods.Items.Count > 0)
            {
                foreach (var item in availableMods.Items)
                {
                    pendingMods.Items.Add(item);
                }
                availableMods.Items.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var terminated = false;
            if (pendingMods.Items.Count > 0)
            {
                var _BackupHelper = new BackupHelper();
                if (_BackupHelper.DoBackup(gameFolderPathString) == true)
                {
                    var _CleanerHelper = new CleanerHelper();
                    if (_CleanerHelper.CheckModStatus(gameFolderPathString) == true)
                    {
                        var installedModsList = _CleanerHelper.InstalledMods(gameFolderPathString);
                        //_CleanerHelper.RemoveMods(gameFolderPathString, installedModsList);
                        var _InjectionHelper = new InjectionHelper();
                        if (_InjectionHelper.CombineMods(gameFolderPathString, pendingMods.Items) == true)
                        {
                            var installedModsList2 = _CleanerHelper.InstalledMods(gameFolderPathString);
                            if (installedModsList2 != null)
                            {
                                pendingMods.Items.Clear();
                                foreach (var installedMod in installedMods.Items)
                                {
                                    availableMods.Items.Add(installedMod);
                                }
                                installedMods.Items.Clear();
                                foreach (var mod in installedModsList2)
                                {
                                    installedMods.Items.Add(mod);
                                }
                            }
                        } else
                        {
                            terminated = true;
                        }
                    } else
                    {
                        var _InjectionHelper = new InjectionHelper();
                        if (_InjectionHelper.CombineMods(gameFolderPathString, pendingMods.Items) == true)
                        { 
                            var installedModsList = _CleanerHelper.InstalledMods(gameFolderPathString);
                            if (installedModsList != null)
                            {
                                pendingMods.Items.Clear();
                                foreach (var installedMod in installedMods.Items)
                                {
                                    availableMods.Items.Add(installedMod);
                                }
                                installedMods.Items.Clear();
                                foreach (var mod in installedModsList)
                                {
                                    installedMods.Items.Add(mod);
                                }
                            }
                        }
                        else
                        {
                            terminated = true;
                        }
                    }
                } else
                {
                    terminated = true;
                }
            } 

            if (terminated == true)
            {
                Debug.WriteLine("Terminated session early");
            } else
            {
                var injectionHelper = new InjectionHelper();
                injectionHelper.DoRewrite(gameFolderPathString);
            }



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pendingMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pendingMods.SelectedItem != null)
            {
                var selectedIndexName = pendingMods.SelectedItem.ToString();
                var selectedIndexReadmePath = availableModsPath + @"\" + pendingMods.SelectedItem.ToString() + @"\" + pendingMods.SelectedItem.ToString() + ".rtf";
                groupBox1.Text = pendingMods.SelectedItem.ToString() + " Readme";
                if (File.Exists(selectedIndexReadmePath))
                {
                    richTextBox1.LoadFile(selectedIndexReadmePath);
                }
                else
                {
                    richTextBox1.Text = "Mod has no readme file";
                }
            }
        }

        private void installedMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (installedMods.SelectedItem != null)
            {
                var selectedIndexName = installedMods.SelectedItem.ToString();
                var selectedIndexReadmePath = availableModsPath + @"\" + installedMods.SelectedItem.ToString() + @"\" + installedMods.SelectedItem.ToString() + ".rtf";
                groupBox1.Text = installedMods.SelectedItem.ToString() + " Readme";
                if (File.Exists(selectedIndexReadmePath))
                {
                    richTextBox1.LoadFile(selectedIndexReadmePath);
                }
                else
                {
                    richTextBox1.Text = "Mod has no readme file";
                }
            }
        }

        private void App_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Readme.rtf"))
            {
                groupBox1.Text = "Mod Manager information";
                richTextBox1.LoadFile(Directory.GetCurrentDirectory() + @"\Readme.rtf");
            }
        }
    }
}
