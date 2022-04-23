using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        private CalculatingClass calculating = new CalculatingClass();

        public CalculatorForm()
        {
            InitializeComponent();
            textBox.DataBindings.Add("Text", calculating, "TextForTextBox", false, DataSourceUpdateMode.OnValidation);
        }

        private void OnDigitOperationAndDotButtonClick(object sender, EventArgs e)
        {
            textBox.Text += (sender as Button).Text;
            calculating.Calculate();
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            textBox.Text = "";
        }

        private void OnBackSpaceButtonClick(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !(e.KeyChar >= 42 && e.KeyChar <= 57)) //Backspace /*-+,. and digits
            {
                e.Handled = true;
            }
        }

    }
}
