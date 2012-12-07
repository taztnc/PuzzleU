using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ServicesClient
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
            //Application.Run(new FormAlbums());
            //Application.Run(new FormUserName());
            //Application.Run(new FormImages());
            Application.Run(new FormPuzzles());
        }
    }
}
