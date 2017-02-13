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

        //create a reference to the previous form
        public Form previousForm;

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

        /// <summary>
        /// Event Handler for calculate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _CalculateButtonClicked(object sender, EventArgs e)
        {
            this.calculate();
        }
        //function used to clear all fields
        private void clearButton() {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
           textBox5.Text = "";
            textBox7.Text = "";
            textBox6.Text = "0";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
           radioButton1.Checked = true;
        }
        //method used to calculate
        private void calculate()
        {
            // Local variables
            double carSalesPriceVal;
            double tradeInAllowanceDecimal;

            double subTotalDecimal;
            double totalDecimal;
            double salesTaxDecimal;
            double amountDueDecimal;
            try
            {
                carSalesPriceVal = Double.Parse(textBox1.Text);

                if (carSalesPriceVal <= 0)
                {
                    MessageBox.Show("The value inputted in the Car Sale Price must be above zero.", "Value too small Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    carSalesPriceVal = 0.0;
                    textBox1.Text = "0";
                }
                else
                {

                    try
                    {
                        tradeInAllowanceDecimal = Double.Parse(textBox6.Text);
                        // Trade in value cannot be below 0
                        if (tradeInAllowanceDecimal < 0)
                        {
                            MessageBox.Show("The value inputted in Trade-On Allowance must not be a negative value.", "Value too small Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tradeInAllowanceDecimal = 0.0;
                            textBox6.Text = "0";
                            textBox7.Text = textBox5.Text;
                        }
                        else
                        {
                            // Calculations
                            subTotalDecimal = this._additionalvalue + carSalesPriceVal;
                            salesTaxDecimal = subTotalDecimal * Convert.ToDouble(TAX_RATE_Decimal);
                            totalDecimal = subTotalDecimal + salesTaxDecimal;
                            amountDueDecimal = totalDecimal - tradeInAllowanceDecimal;

                            // Add all variables to the TextBoxes
                            textBox3.Text = subTotalDecimal.ToString("c");
                            textBox4.Text = salesTaxDecimal.ToString("c");
                            textBox5.Text = totalDecimal.ToString("c");
                            textBox7.Text = amountDueDecimal.ToString("c");

                        }
                    }

                    catch (FormatException exception)
                    {
                        MessageBox.Show("The value inputted in Trade-In Allowance must be a numeric value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox6.Text = "0";
                        textBox7.Text = textBox5.Text;
                    }
                }
            }
            catch (Exception flowException)
            {
                MessageBox.Show("The value inputted in the Car Sale Price must be a numeric value.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0";
            }

        }
        /// <summary>
        /// Event Handler for clear button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button2_Click(object sender, EventArgs e)
        {
            this.clearButton();
        }

        /// <summary>
        /// Event Handler for menu strip calculate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.calculate();
        }
        /// <summary>
        /// Event Handler for menu strip clear button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.clearButton();
        }
        //method used to close
        private void close()
        {
            this.previousForm.Close();
        }
        private void Clickclose(object sender, EventArgs e)
        {
            this.close();
        }
        /// <summary>
        /// Event Handler for exit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.close();
        }
        /// <summary>
        /// Event Handler for menu strip about button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("App name:- Sahrp Auto Centre \n" + "Author name:- Subham salaria \n"+"App Description :- This app is used to calculate the amount due when base price and trade allowance is entered", "About");
        }
    }
}

      