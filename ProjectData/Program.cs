using ProjectData.Util;
using System;
using System.Windows.Forms;

namespace ProjectData
{
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

            Form1 form = new Form1();
            WinForm.current = form;
            Application.Run(form);
        }
    }
}
