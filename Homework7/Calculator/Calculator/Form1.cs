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
            textBox.DataBindings.Add("Text", calculating, "TextForTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void OnDigitOperationAndDotButtonClick(object sender, EventArgs e)
        {

            textBox.Text = textBox.Text + (sender as Button).Text;
            calculating.Validation();
            textBox.Focus();
            textBox.SelectionStart = textBox.TextLength;
        }

        private void OnClearButtonClick(object sender, EventArgs e)
        {
            textBox.Text = "";
            calculating.Validation();
            textBox.Focus();
            textBox.SelectionStart = textBox.TextLength;
        }

        private void OnBackspaceButtonClick(object sender, EventArgs e)
        {
            if (textBox.Text.Length > 0)
            {
                textBox.Text = textBox.Text.Substring(0, textBox.Text.Length - 1);
                calculating.ValidationForBackspace();
            }
            textBox.Focus();
            textBox.SelectionStart = textBox.TextLength;
        }

        private void OnSqrButtonClick(object sender, EventArgs e)
        {
            calculating.ValidationForSqr();
            textBox.Focus();
            textBox.SelectionStart = textBox.TextLength;
        }

        private void OnSqrtButtonClick(object sender, EventArgs e)
        {
            calculating.ValidationForSqrt();
            textBox.Focus();
            textBox.SelectionStart = textBox.TextLength;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !(e.KeyChar >= 42 && e.KeyChar <= 57)) //Backspace /*-+,. and digits
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
        }

        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            bool needValidation = true;
            if (e.KeyCode == Keys.Enter)
            {
                textBox.Text += "=";
                calculating.Validation();
                needValidation = false;
            }
            if (e.KeyCode == Keys.Back)
            {
                if (textBox.Text.Length > 0)
                {
                    calculating.ValidationForBackspace();
                    needValidation = false;
                }
            }
            if (needValidation)
            {
                calculating.Validation();
            }
            textBox.Focus();
            textBox.SelectionStart = textBox.TextLength;
        }
    }
}
