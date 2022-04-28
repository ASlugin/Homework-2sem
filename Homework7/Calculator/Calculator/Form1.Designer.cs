namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonPoint = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonMulriplication = new System.Windows.Forms.Button();
            this.buttonDivision = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.buttonSqrt = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.buttonSqr = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button0, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonPoint, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonPlus, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonMinus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonMulriplication, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivision, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackspace, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqrt, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEqual, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqr, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(553, 497);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.PaintTableLayoutPanel1);
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox, 5);
            this.textBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(3, 39);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(547, 40);
            this.textBox.TabIndex = 0;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // button0
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button0, 2);
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button0.Location = new System.Drawing.Point(1, 411);
            this.button0.Margin = new System.Windows.Forms.Padding(1);
            this.button0.MinimumSize = new System.Drawing.Size(140, 50);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(218, 85);
            this.button0.TabIndex = 1;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(1, 329);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.MinimumSize = new System.Drawing.Size(70, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 80);
            this.button1.TabIndex = 2;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(111, 329);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.MinimumSize = new System.Drawing.Size(70, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 80);
            this.button2.TabIndex = 3;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(221, 329);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.MinimumSize = new System.Drawing.Size(70, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 80);
            this.button3.TabIndex = 4;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(1, 247);
            this.button4.Margin = new System.Windows.Forms.Padding(1);
            this.button4.MinimumSize = new System.Drawing.Size(70, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(108, 80);
            this.button4.TabIndex = 5;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(111, 247);
            this.button5.Margin = new System.Windows.Forms.Padding(1);
            this.button5.MinimumSize = new System.Drawing.Size(70, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(108, 80);
            this.button5.TabIndex = 6;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(221, 247);
            this.button6.Margin = new System.Windows.Forms.Padding(1);
            this.button6.MinimumSize = new System.Drawing.Size(70, 50);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(108, 80);
            this.button6.TabIndex = 7;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button7.Location = new System.Drawing.Point(1, 165);
            this.button7.Margin = new System.Windows.Forms.Padding(1);
            this.button7.MinimumSize = new System.Drawing.Size(70, 50);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 80);
            this.button7.TabIndex = 8;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button8.Location = new System.Drawing.Point(111, 165);
            this.button8.Margin = new System.Windows.Forms.Padding(1);
            this.button8.MinimumSize = new System.Drawing.Size(70, 50);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(108, 80);
            this.button8.TabIndex = 9;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button9.Location = new System.Drawing.Point(221, 165);
            this.button9.Margin = new System.Windows.Forms.Padding(1);
            this.button9.MinimumSize = new System.Drawing.Size(70, 50);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(108, 80);
            this.button9.TabIndex = 10;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonPoint
            // 
            this.buttonPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPoint.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPoint.Location = new System.Drawing.Point(221, 411);
            this.buttonPoint.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPoint.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonPoint.Name = "buttonPoint";
            this.buttonPoint.Size = new System.Drawing.Size(108, 85);
            this.buttonPoint.TabIndex = 11;
            this.buttonPoint.Text = ",";
            this.buttonPoint.UseVisualStyleBackColor = true;
            this.buttonPoint.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPlus.Location = new System.Drawing.Point(331, 411);
            this.buttonPlus.Margin = new System.Windows.Forms.Padding(1);
            this.buttonPlus.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(108, 85);
            this.buttonPlus.TabIndex = 12;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMinus.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMinus.Location = new System.Drawing.Point(331, 329);
            this.buttonMinus.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMinus.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(108, 80);
            this.buttonMinus.TabIndex = 13;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonMulriplication
            // 
            this.buttonMulriplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMulriplication.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMulriplication.Location = new System.Drawing.Point(331, 247);
            this.buttonMulriplication.Margin = new System.Windows.Forms.Padding(1);
            this.buttonMulriplication.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonMulriplication.Name = "buttonMulriplication";
            this.buttonMulriplication.Size = new System.Drawing.Size(108, 80);
            this.buttonMulriplication.TabIndex = 14;
            this.buttonMulriplication.Text = "*";
            this.buttonMulriplication.UseVisualStyleBackColor = true;
            this.buttonMulriplication.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonDivision
            // 
            this.buttonDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivision.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDivision.Location = new System.Drawing.Point(331, 165);
            this.buttonDivision.Margin = new System.Windows.Forms.Padding(1);
            this.buttonDivision.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonDivision.Name = "buttonDivision";
            this.buttonDivision.Size = new System.Drawing.Size(108, 80);
            this.buttonDivision.TabIndex = 15;
            this.buttonDivision.Text = "/";
            this.buttonDivision.UseVisualStyleBackColor = true;
            this.buttonDivision.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClear.Location = new System.Drawing.Point(331, 83);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(1);
            this.buttonClear.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(108, 80);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBackspace.Location = new System.Drawing.Point(441, 83);
            this.buttonBackspace.Margin = new System.Windows.Forms.Padding(1);
            this.buttonBackspace.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(111, 80);
            this.buttonBackspace.TabIndex = 17;
            this.buttonBackspace.Text = "<=";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.OnBackspaceButtonClick);
            // 
            // buttonSqrt
            // 
            this.buttonSqrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqrt.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSqrt.Location = new System.Drawing.Point(441, 165);
            this.buttonSqrt.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSqrt.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonSqrt.Name = "buttonSqrt";
            this.buttonSqrt.Size = new System.Drawing.Size(111, 80);
            this.buttonSqrt.TabIndex = 18;
            this.buttonSqrt.Text = "√x";
            this.buttonSqrt.UseVisualStyleBackColor = true;
            this.buttonSqrt.Click += new System.EventHandler(this.OnSqrtButtonClick);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqual.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEqual.Location = new System.Drawing.Point(441, 329);
            this.buttonEqual.Margin = new System.Windows.Forms.Padding(1);
            this.buttonEqual.MinimumSize = new System.Drawing.Size(70, 100);
            this.buttonEqual.Name = "buttonEqual";
            this.tableLayoutPanel1.SetRowSpan(this.buttonEqual, 2);
            this.buttonEqual.Size = new System.Drawing.Size(111, 167);
            this.buttonEqual.TabIndex = 19;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonSqr
            // 
            this.buttonSqr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqr.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSqr.Location = new System.Drawing.Point(441, 247);
            this.buttonSqr.Margin = new System.Windows.Forms.Padding(1);
            this.buttonSqr.MinimumSize = new System.Drawing.Size(70, 50);
            this.buttonSqr.Name = "buttonSqr";
            this.buttonSqr.Size = new System.Drawing.Size(111, 80);
            this.buttonSqr.TabIndex = 20;
            this.buttonSqr.Text = "x²";
            this.buttonSqr.UseVisualStyleBackColor = true;
            this.buttonSqr.Click += new System.EventHandler(this.OnSqrButtonClick);
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 503);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(370, 350);
            this.Name = "CalculatorForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox;
        private Button button0;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button buttonPoint;
        private Button buttonPlus;
        private Button buttonMinus;
        private Button buttonMulriplication;
        private Button buttonDivision;
        private Button buttonClear;
        private Button buttonBackspace;
        private Button buttonSqrt;
        private Button buttonEqual;
        private Button buttonSqr;
    }
}