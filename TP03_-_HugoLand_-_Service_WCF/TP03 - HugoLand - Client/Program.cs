using HugoWorld.Vue;
using HugoWorld_Client.Vue;
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
            try
            {
                Application.Run(new HugoWorld());
            }
            catch (Exception ex)
            {
                MessageBox.Show("PLEASE RECONNECT " + ex.Message, "Connection error",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
    }
}