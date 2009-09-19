using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FSXi.UI.Core;

namespace FSXi.UI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// MainForm constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Toggle the status bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tspStatus.Visible = (sender as ToolStripMenuItem).Checked;
        }

        /// <summary>
        /// Display the about box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutForm = new AboutBox();
            aboutForm.ShowDialog(this);
        }
    }
}
