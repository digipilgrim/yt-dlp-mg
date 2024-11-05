using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yt_dlp_microGUI
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1) 
            {
                if (args[1] == "mini") Application.Run(new FormMini()); 
            }
            else  Application.Run(new FormMicro());
        }
    }
}
