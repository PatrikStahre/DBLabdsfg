using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBLabs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            DBConnection dbconn = new DBConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApplicationForm(ref dbconn));
        }
    }
}
