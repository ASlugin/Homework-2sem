namespace Game;

using System;

/// <summary>
/// Class for control of button
/// </summary>
class Controller
{
    /// <summary>
    /// Array of buttons
    /// </summary>
    public Button[,] buttonArray;

    /// <summary>
    /// Array of values of button
    /// </summary>
    public int[,] valueOfButtonArray;

    private int amountOfButtom;

    /// <summary>
    /// Size of a button
    /// </summary>
    public int sizeOfButton { get; } = 50;

    public Controller(int amountOfButtom)
    {
        this.amountOfButtom = amountOfButtom;
        buttonArray = new Button[amountOfButtom, amountOfButtom];
        valueOfButtonArray = new int[amountOfButtom, amountOfButtom];
        for (int i = 0; i < amountOfButtom; ++i)
        {
            for (int j = 0; j < amountOfButtom; ++j)
            {
                valueOfButtonArray[i, j] = -1;
            }
        }
        Initialize();
    }

    private void Initialize()
    {
        Random random = new();

        for (int i = 0; i < amountOfButtom * amountOfButtom / 2; ++i)
        {
            for (int k = 0; k < 2; ++k)
            {
                int x = random.Next(0, amountOfButtom);
                int y = random.Next(0, amountOfButtom);
                while (valueOfButtonArray[x, y] != -1)
                {
                    x = random.Next(0, amountOfButtom);
                    y = random.Next(0, amountOfButtom);
                }
                valueOfButtonArray[x, y] = i;
            }
        }

        for (int i = 0; i < amountOfButtom; ++i)
        {
            for (int j = 0; j < amountOfButtom; ++j)
            {
                buttonArray[i, j] = new Button();
                buttonArray[i, j].Location = new Point(i * sizeOfButton, j * sizeOfButton);
                buttonArray[i, j].Size = new Size(sizeOfButton, sizeOfButton);
            }
        }
    }

    private Button? firstButton;
    private Button? secondButton;
    private int firstValue = -1;
    private int secondValue = -1;
    private int selectedButtons = 0;

    public void Click(int i, int j)
    {
        if (selectedButtons == 0)
        {
            if (firstButton != null && secondButton != null && firstValue != secondValue)
            {
                firstButton.Text = string.Empty;
                secondButton.Text = string.Empty;
            }

            firstButton = buttonArray[i, j];
            firstValue = valueOfButtonArray[i, j];
            firstButton.Text = valueOfButtonArray[i, j].ToString();
            selectedButtons = 1;
        }
        else if (selectedButtons == 1)
        {
            secondButton = buttonArray[i, j];
            secondValue = valueOfButtonArray[i, j];
            secondButton.Text = valueOfButtonArray[i, j].ToString();
            selectedButtons = 0;
            
            if (firstValue == secondValue && firstButton != secondButton)
            {
                firstButton!.Enabled = false;
                secondButton!.Enabled = false;
            }
        }
    }

    /// <summary>
    /// Checks whether player wins
    /// </summary>
    /// <returns>returns true if all button already enable, else false</returns>
    public bool CheckWhetherPlayerWins()
    {
        foreach (var button in buttonArray)
        {
            if (button.Enabled)
            {
                return false;
            }
        }
        return true;
    }


}
