/*
 * App name :- SharpAuto Centre
 * Author's name :- Subham Salaria
 * Student ID :- 200333595
 * App Creation Date :- 2017-02-11
 * APP description :- "Thisapp is used to calculate amount due if base price is entered"
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    static class Program
    {
        //declared static form - Application global
        public static SpalshForm splahform;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Initialize Splash form
            Program.splahform = new SpalshForm();

            Application.Run(Program.splahform);
        }
    }
}
