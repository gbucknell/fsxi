using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FSXi.Sim;
using FSXi.UI;

namespace FSXi
{
    static class FSXi
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create the main form
            MainForm mainForm = new MainForm();

            // Get the handle for the form
            IntPtr handle = mainForm.Handle;

            // Initialise SimManager with the given handle
            SimManager.Initialise(handle);

            // Open the GUI
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}