using System;
using System.Windows.Forms;

// $G$ SFN-012 (+6) Bonus: Graphics.

// $G$ DSN-999 (-10) You should separate your solution into projects - logic and UI


namespace Othello
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new OthelloGameSettingsForm().ShowDialog();            
        }
    }
}