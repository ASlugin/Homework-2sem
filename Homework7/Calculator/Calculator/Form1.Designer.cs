namespace Calculator
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonMultiplication = new System.Windows.Forms.Button();
            this.buttonDivision = new System.Windows.Forms.Button();
            this.buttonBackspace = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonSqrt = new System.Windows.Forms.Button();
            this.buttonSqr = new System.Windows.Forms.Button();
            this.buttonDot = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button5, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button0, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonEqual, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonPlus, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonMinus, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonMultiplication, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDivision, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonBackspace, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqrt, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonSqr, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonDot, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(300, 300);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(376, 447);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox, 5);
            this.textBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(3, 37);
            this.textBox.MinimumSize = new System.Drawing.Size(300, 0);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(370, 34);
            this.textBox.TabIndex = 0;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(0, 296);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.MinimumSize = new System.Drawing.Size(60, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 74);
            this.button1.TabIndex = 1;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(75, 296);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.MinimumSize = new System.Drawing.Size(60, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 74);
            this.button2.TabIndex = 2;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(150, 296);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.MinimumSize = new System.Drawing.Size(60, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 74);
            this.button3.TabIndex = 3;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(0, 222);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.MinimumSize = new System.Drawing.Size(60, 50);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 74);
            this.button4.TabIndex = 4;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(75, 222);
            this.button5.Margin = new System.Windows.Forms.Padding(0);
            this.button5.MinimumSize = new System.Drawing.Size(60, 50);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 74);
            this.button5.TabIndex = 5;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(150, 222);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.MinimumSize = new System.Drawing.Size(60, 50);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 74);
            this.button6.TabIndex = 6;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(0, 148);
            this.button7.Margin = new System.Windows.Forms.Padding(0);
            this.button7.MinimumSize = new System.Drawing.Size(60, 50);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 74);
            this.button7.TabIndex = 7;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(75, 148);
            this.button8.Margin = new System.Windows.Forms.Padding(0);
            this.button8.MinimumSize = new System.Drawing.Size(60, 50);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 74);
            this.button8.TabIndex = 8;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(150, 148);
            this.button9.Margin = new System.Windows.Forms.Padding(0);
            this.button9.MinimumSize = new System.Drawing.Size(60, 50);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 74);
            this.button9.TabIndex = 9;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // button0
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.button0, 2);
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button0.Location = new System.Drawing.Point(0, 370);
            this.button0.Margin = new System.Windows.Forms.Padding(0);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(150, 77);
            this.button0.TabIndex = 0;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEqual.Location = new System.Drawing.Point(300, 296);
            this.buttonEqual.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEqual.MinimumSize = new System.Drawing.Size(60, 0);
            this.buttonEqual.Name = "buttonEqual";
            this.tableLayoutPanel1.SetRowSpan(this.buttonEqual, 2);
            this.buttonEqual.Size = new System.Drawing.Size(76, 151);
            this.buttonEqual.TabIndex = 17;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlus.Location = new System.Drawing.Point(225, 370);
            this.buttonPlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlus.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(75, 77);
            this.buttonPlus.TabIndex = 11;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinus.Location = new System.Drawing.Point(225, 296);
            this.buttonMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinus.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(75, 74);
            this.buttonMinus.TabIndex = 12;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonMultiplication
            // 
            this.buttonMultiplication.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMultiplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMultiplication.Location = new System.Drawing.Point(225, 222);
            this.buttonMultiplication.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMultiplication.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonMultiplication.Name = "buttonMultiplication";
            this.buttonMultiplication.Size = new System.Drawing.Size(75, 74);
            this.buttonMultiplication.TabIndex = 13;
            this.buttonMultiplication.Text = "*";
            this.buttonMultiplication.UseVisualStyleBackColor = true;
            this.buttonMultiplication.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonDivision
            // 
            this.buttonDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDivision.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDivision.Location = new System.Drawing.Point(225, 148);
            this.buttonDivision.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDivision.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonDivision.Name = "buttonDivision";
            this.buttonDivision.Size = new System.Drawing.Size(75, 74);
            this.buttonDivision.TabIndex = 14;
            this.buttonDivision.Text = "/";
            this.buttonDivision.UseVisualStyleBackColor = true;
            this.buttonDivision.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // buttonBackspace
            // 
            this.buttonBackspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBackspace.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBackspace.Location = new System.Drawing.Point(300, 74);
            this.buttonBackspace.Margin = new System.Windows.Forms.Padding(0);
            this.buttonBackspace.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonBackspace.Name = "buttonBackspace";
            this.buttonBackspace.Size = new System.Drawing.Size(76, 74);
            this.buttonBackspace.TabIndex = 18;
            this.buttonBackspace.Text = "<=";
            this.buttonBackspace.UseVisualStyleBackColor = true;
            this.buttonBackspace.Click += new System.EventHandler(this.OnBackspaceButtonClick);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.White;
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClear.Location = new System.Drawing.Point(225, 74);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClear.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 74);
            this.buttonClear.TabIndex = 19;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // buttonSqrt
            // 
            this.buttonSqrt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqrt.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSqrt.Location = new System.Drawing.Point(300, 148);
            this.buttonSqrt.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSqrt.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonSqrt.Name = "buttonSqrt";
            this.buttonSqrt.Size = new System.Drawing.Size(76, 74);
            this.buttonSqrt.TabIndex = 15;
            this.buttonSqrt.Text = "√x";
            this.buttonSqrt.UseVisualStyleBackColor = true;
            this.buttonSqrt.Click += new System.EventHandler(this.OnSqrtButtonClick);
            // 
            // buttonSqr
            // 
            this.buttonSqr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSqr.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSqr.Location = new System.Drawing.Point(300, 222);
            this.buttonSqr.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSqr.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonSqr.Name = "buttonSqr";
            this.buttonSqr.Size = new System.Drawing.Size(76, 74);
            this.buttonSqr.TabIndex = 16;
            this.buttonSqr.Text = "x²";
            this.buttonSqr.UseVisualStyleBackColor = true;
            this.buttonSqr.Click += new System.EventHandler(this.OnSqrButtonClick);
            // 
            // buttonDot
            // 
            this.buttonDot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDot.Location = new System.Drawing.Point(150, 370);
            this.buttonDot.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDot.MinimumSize = new System.Drawing.Size(60, 50);
            this.buttonDot.Name = "buttonDot";
            this.buttonDot.Size = new System.Drawing.Size(75, 77);
            this.buttonDot.TabIndex = 10;
            this.buttonDot.Text = ",";
            this.buttonDot.UseVisualStyleBackColor = true;
            this.buttonDot.Click += new System.EventHandler(this.OnDigitOperationAndDotButtonClick);
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(382, 453);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(360, 350);
            this.Name = "CalculatorForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Calculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonMultiplication;
        private System.Windows.Forms.Button buttonDivision;
        private System.Windows.Forms.Button buttonBackspace;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSqrt;
        private System.Windows.Forms.Button buttonSqr;
        private System.Windows.Forms.Button buttonDot;
    }
}