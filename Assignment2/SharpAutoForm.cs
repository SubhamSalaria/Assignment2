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
    public partial class SharpAutoForm : Form
    {
        // Constant Variables
        const decimal TAX_RATE_Decimal = .13m;
        // Accessories
        const decimal STEREO_SYSTEM_Decimal = 425.76m;
        const decimal LEATHER_INTERIOR_Decimal = 987.41m;
        const decimal COMPUTER_NAVIGATION_Decimal = 1741.23m;
        const decimal TRANSMISSON_SYSTEM = 750.23m;
        // Exterior Finish
        const decimal STANDARD_Decimal = 0.00m;
        const decimal PERALIZED_Decimal = 345.72m;
        const decimal CUSTOMIZED_DETAILING_Decimal = 599.99m;
        const decimal AERO_UPGRADES = 899.99m;

        //private instance variable
        private double _additionalvalue;
        public SharpAutoForm()
        {
            InitializeComponent();
        }


      private void ColorDialog_click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
                textBox7.BackColor = colorDialog1.Color;
            }
        }

        private void FontDialog_click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
                textBox7.Font = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
            }
        }


        //evenet handler for check buttons and radio buttons
        private void gropboxvaluesclicked(object sender, EventArgs e)
        {

            this._additionalvalue = 0.0;

            if(sender is RadioButton)
            {
                RadioButton radio = sender as RadioButton;

                switch (radio.Text)
                {
                    case "Standard":
                        if (radio.Checked)
                        {
                            this._additionalvalue += Convert.ToDouble(STANDARD_Decimal);
                        }
                        break;
                    case "Pearlized":
                        if (radio.Checked)
                        {
                            this._additionalvalue += Convert.ToDouble(PERALIZED_Decimal);
                        }
                        break;
                    case "Customized Detailing":
                        if (radio.Checked)
                        {
                            this._additionalvalue += Convert.ToDouble(CUSTOMIZED_DETAILING_Decimal);
                        }
                        break;
                    case "Aero Upgrades":
                        if (radio.Checked)
                        {
                            this._additionalvalue += Convert.ToDouble(AERO_UPGRADES);
                        }
                        break;

                }
            }

            if (checkBox1.Checked)
            {
                this._additionalvalue += Convert.ToDouble(STEREO_SYSTEM_Decimal);
            }
            if (checkBox2.Checked)
            {
                this._additionalvalue += Convert.ToDouble(LEATHER_INTERIOR_Decimal);
            }
            if (checkBox3.Checked)
            {
                this._additionalvalue += Convert.ToDouble(COMPUTER_NAVIGATION_Decimal);
            }
            if (checkBox4.Checked)
            {
                this._additionalvalue += Convert.ToDouble(TRANSMISSON_SYSTEM);
            }
          

            textBox2.Text = this._additionalvalue.ToString();

        }
    }
}
