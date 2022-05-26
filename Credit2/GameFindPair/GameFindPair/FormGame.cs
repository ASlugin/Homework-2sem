namespace GameFindPair;

/// <summary>
/// Class for form of game
/// </summary>
public partial class FormGame : Form
{
    private int size;
    private Button[,] arrayOfButtons;

    public FormGame(int size)
    {
        if (size % 2 != 0 || size <= 0)
        {
            throw new ArgumentException("Invalid size!");
        }

        this.size = size;
        this.amountOfEnabledButtons = size * size;
        InitializeComponent();

        tableLayout.ColumnCount = size;
        tableLayout.RowCount = size;
        for (int i = 0; i < size; i++)
        {
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, (float)(100 / size)));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, (float)(100 / size)));
        }

        arrayOfButtons = new Button[size, size];
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
            {
                var button = new Button();
                button.Dock = DockStyle.Fill;
                button.Margin = new System.Windows.Forms.Padding(0);
                button.MouseClick += new MouseEventHandler(ClickOnMouse!);
                tableLayout.Controls.Add(button);

                arrayOfButtons[i, j] = button;
            }
        }

        Random random = new();
        for (int i = 0; i < size * size / 2; ++i)
        {
            for (int j = 0; j < 2; ++j)
            {
                int x = random.Next(0, size);
                int y = random.Next(0, size);
                while (arrayOfButtons[x, y].Tag != null)
                {
                    x = random.Next(0, size);
                    y = random.Next(0, size);
                }
                arrayOfButtons[x, y].Tag = i;
            }
        }
    }

    private Button? firstButton;
    private Button? secondButton;
    private int selectedButtons = 0;
    private int amountOfEnabledButtons;

    private void ClickOnMouse(object sender, MouseEventArgs e)
    {
        if (selectedButtons == 0)
        {
            if (firstButton != null && secondButton != null && !firstButton.Tag.Equals(secondButton.Tag))
            {
                firstButton.Text = string.Empty;
                secondButton.Text = string.Empty;
            }
            firstButton = sender as Button;
            firstButton!.Text = firstButton.Tag.ToString();
            selectedButtons = 1;
        }
        else if (selectedButtons == 1)
        {
            secondButton = sender as Button;
            secondButton!.Text = secondButton.Tag.ToString();
            selectedButtons = 0;

            if (firstButton!.Tag.Equals(secondButton.Tag) && firstButton != secondButton)
            {
                firstButton!.Enabled = false;
                secondButton!.Enabled = false;
                amountOfEnabledButtons -= 2;
            }
        }

        if (amountOfEnabledButtons <= 0)
        {
            MessageBox.Show("You won!");
        }
    }
}