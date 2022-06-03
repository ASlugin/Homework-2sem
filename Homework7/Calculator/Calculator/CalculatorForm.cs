namespace Calculator;

public partial class CalculatorForm : Form
{
    private CalculatingClass calculating = new();

    private string textForErrorBox = "Error. Possible causes of the error:\n" +
        "1. Division by zero\n2. Negative number under the square root\n" +
        "3. Keyboard input is too fast";

    public CalculatorForm()
    {
        InitializeComponent();
        textBox.DataBindings.Add("Text", calculating, "TextForTextBox", true, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void PaintTableLayoutPanel1(object sender, TableLayoutCellPaintEventArgs e)
    {
        if (e.Row == 0)
        {
            e.Graphics.FillRectangle(Brushes.White, e.CellBounds);
        }
        if (e.Row == 1)
        {
            var topLeft = e.CellBounds.Location;
            var topRight = new Point(e.CellBounds.Right, e.CellBounds.Top);
            e.Graphics.DrawLine(Pens.Black, topLeft, topRight);
        }
    }

    private void OnDigitOperationAndDotButtonClick(object sender, EventArgs e)
    {
        textBox.Text = textBox.Text + (sender as Button)?.Text;
        if (!calculating.Validation())
        {
            MessageBox.Show(textForErrorBox);
        }
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
        }
        if (!calculating.validationForBackspace())
        {
            MessageBox.Show(textForErrorBox);
        }

        textBox.Focus();
        textBox.SelectionStart = textBox.TextLength;
    }

    private void OnSqrButtonClick(object sender, EventArgs e)
    {
        textBox.Text += '²';
        if (!calculating.Validation())
        {
            MessageBox.Show(textForErrorBox);
        }

        textBox.Focus();
        textBox.SelectionStart = textBox.TextLength;
    }

    private void OnSqrtButtonClick(object sender, EventArgs e)
    {
        textBox.Text += '√';
        if (!calculating.Validation())
        {
            MessageBox.Show(textForErrorBox);
        }

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
        if (e.KeyCode == Keys.Enter)
        {
            textBox.Text += '=';
            if (!calculating.Validation())
            {
                MessageBox.Show(textForErrorBox);
            }
        }
        else if (e.KeyCode == Keys.Back)
        {
            if(!calculating.validationForBackspace())
            {
                MessageBox.Show(textForErrorBox);
            }
        }
        else
        {
            if (!calculating.Validation())
            {
                MessageBox.Show(textForErrorBox);
            }
        }

        textBox.Focus();
        textBox.SelectionStart = textBox.TextLength;
    }
}

