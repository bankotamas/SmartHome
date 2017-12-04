using System;
using System.Windows.Forms;

namespace esp8266loader
{
    public static class Globals
    {
        public static string deviceName = "Management"; // device name for auto connect
    }

    public static class Returns
    {
        public static string NotFound = "Not found";
    }

    public static class Serial
    {
        public static int BaudRate = 921600;
    }

    public static class State
    {
        public static string Upload = "Uploading... ";
        public static string Finish = "Finished!";
    }

    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
