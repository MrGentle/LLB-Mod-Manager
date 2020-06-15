using System;
using System.Collections.Generic;

namespace LLB_Mod_Manager
{
    public class CommandLineHelper
    {

        private string gameFolderPathString = null;

        public void RunFromArguments(String[] args)
        {
            Config _config = new Config();
            gameFolderPathString = _config.LoadConfig()[0];

            List<string> modsToInstall = new List<string>();
            List<string> modsToUninstall = new List<string>();
            bool willRefresh = false;
            bool willUninstallAll = false;
            bool willPrintUsage = false;
            bool safeInstall = true;

            for (int i = 2; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "--help":
                    case "-h":
                    case "-?":
                        willPrintUsage = true;
                        return;

                    case "--unsafe-install":
                        safeInstall = false;
                        break;

                    case "-ua":
                    case "--uninstall-all":
                        willUninstallAll = true;
                        break;

                    case "-u":
                    case "--uninstall":
                        modsToUninstall.Add(args[i]);
                        break;

                    case "-i":
                    case "--install":
                        if ((i + 1) < args.Length)
                        {
                            i++;
                            modsToInstall.Add(args[i]);
                        }
                        break;

                    case "-r":
                    case "--refresh":
                        willRefresh = true;
                        break;

                    default:
                        Console.WriteLine("Warning: Unkown argument: " + args[i]);
                        Console.WriteLine("Aborting...");
                        return;
                }
            }

            if (willPrintUsage)
            {
                PrintUsage();
                return;
            }
            if (willUninstallAll) UninstallAllMods();

            if (modsToUninstall.Count > 0)
            {
                UninstallMods(modsToUninstall);
            }

            if (willRefresh) RefreshInstalledMods();

            if (modsToInstall.Count > 0)
            {
                InstallMods(modsToInstall, safeInstall);
            }
        }

        private void UninstallAllMods()
        {
            CleanerHelper _cleanerHelper = new CleanerHelper();
            BackupHelper _backupHelper = new BackupHelper();

            //copy pasted
            if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
            {
                var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                _cleanerHelper.RemoveMods(gameFolderPathString, installedModsList);
                _cleanerHelper.CleanGameFolder(gameFolderPathString);
                _cleanerHelper.RemoveMod(gameFolderPathString, "ModMenu");
                _backupHelper.RestoreBackup(gameFolderPathString);
                _backupHelper.DeleteBackup(gameFolderPathString);
                Console.WriteLine("Uninstalled All mods");
            }
            else
            {
                Console.WriteLine("CheckModStatus failed");
                _cleanerHelper.CleanGameFolder(gameFolderPathString);
            }
        }

        private void UninstallMods(List<string> modsToUninstall)
        {
            CleanerHelper _cleanerHelper = new CleanerHelper();
            BackupHelper _backupHelper = new BackupHelper();

            // mostly copy pasted
            if (_cleanerHelper.CheckModStatus(gameFolderPathString) == true)
            {
                foreach (var mod in modsToUninstall)
                {
                    if (_cleanerHelper.RemoveMod(gameFolderPathString, mod))
                    {
                        var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                        if (installedModsList.Count == 0)
                        {
                            _cleanerHelper.RemoveMod(gameFolderPathString, "ModMenu");
                            _backupHelper.RestoreBackup(gameFolderPathString);
                            _backupHelper.DeleteBackup(gameFolderPathString);
                        }
                    }
                }
            }
        }

        private void InstallMods(List<string> modsToInstall, bool safeInstall = true)
        {
            CleanerHelper _cleanerHelper = new CleanerHelper();
            InjectionHelper _injectionHelper = new InjectionHelper();
            BackupHelper _backupHelper = new BackupHelper();

            if (modsToInstall.Count > 0)
            {
                var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
                if (installedModsList == null) _backupHelper.DoBackup(gameFolderPathString);

                foreach (string installedMod in installedModsList)
                {
                    if (modsToInstall.Contains(installedMod))
                    {
                        Console.WriteLine("Warning: Tried to install an already installed mod");
                        if (safeInstall)
                        {
                            Console.WriteLine("Safe install is on, aborting. To turn it of, use the --unsafe-install option");
                            return;
                        }
                        else
                        {
                            modsToInstall.Remove(installedMod);
                            Console.WriteLine("Continuing installation");
                        }
                    }
                }

                if (_injectionHelper.InstallSelectedMods(gameFolderPathString, modsToInstall) == true) //If we successfully combined the mod files into the assembly
                {
                    Console.WriteLine("Installation successfull");
                }
                else
                {
                    Console.WriteLine("Installation failed.");
                    Console.WriteLine("Terminated modding attempt. Trying to scrub mod files.");
                    if (_cleanerHelper.CleanGameFolder(gameFolderPathString) == true) { }
                }
            }
        }


        private void RefreshInstalledMods()
        {
            CleanerHelper _cleanerHelper = new CleanerHelper();
            InjectionHelper _injectionHelper = new InjectionHelper();

            //copy pasted
            var installedModsList = _cleanerHelper.InstalledMods(gameFolderPathString);
            if (installedModsList.Count > 0)
            {
                _injectionHelper.RefreshInstalledMods(gameFolderPathString, installedModsList);
                Console.WriteLine("Mods Refreshed");

            }
        }

        private void PrintUsage()
        {
            Console.WriteLine(Environment.GetCommandLineArgs()[0] + " [-c|--console] [commands...]");
        }
    }
}
