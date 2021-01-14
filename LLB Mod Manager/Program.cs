using System;
using System.Windows.Forms;

namespace LLB_Mod_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && (args[1] == "-c" || args[1] == "--console"))
            {
                CommandLineHelper _commandLineHelper = new CommandLineHelper();
                _commandLineHelper.RunFromArguments(args);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App());
        }
    }
}
