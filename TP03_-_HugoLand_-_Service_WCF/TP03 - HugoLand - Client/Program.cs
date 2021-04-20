using HugoWorld.Vue;
using System;
using System.Windows.Forms;

namespace HugoWorld {

    internal static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HugoWorld());
            //Application.Run(new ClassCreator());
        }
    }
}