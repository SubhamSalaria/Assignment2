/*
 * App name :- SharpAuto Centre
 * Author's name :- Subham Salaria
 * Student ID :- 200333595
 * App Creation Date :- 2017-02-11
 * APP description :- "Thisapp is used to calculate amount due if base price is entered"
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SpalshForm : Form
    {
        public SpalshForm()
        {
            InitializeComponent();
        }

        private void splashtimer_Tick(object sender, EventArgs e)
        {
            // 1. Instantiate the next form
            SharpAutoForm sharpform = new SharpAutoForm();

            // 2. pass a reference to the current form to the next form
            sharpform.previousForm = this;

            this.splashtimer.Enabled = false;
            sharpform.Show();
            this.Hide();

        }
    }
}
