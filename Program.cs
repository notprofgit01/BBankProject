using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBankProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new Donor());
            //Application.Run(new ViewDonar());
            //Application.Run(new Patient());
            //Application.Run(new ViewPatients());
            //Application.Run(new DonateBlood());
            //Application.Run(new BloodStock());
            Application.Run(new Login());
            //Application.Run(new Login());
            //Application.Run(new Login());
            //Application.Run(new Login());
            //Application.Run(new Login());


        }
    }
}
