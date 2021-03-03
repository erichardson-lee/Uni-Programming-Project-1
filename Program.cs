using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace O_Neillo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Args.Length > 0)
            {
                MainGame mainGame = new MainGame(Args[0]);
                Application.Run(mainGame);
            }
            else
            {
                MainGame mainGame = new MainGame();
                Application.Run(mainGame);
            }
        }
    }
}

