using System.ComponentModel;

namespace Calculator;

/// <summary>
/// Class for calculate expression from calculator
/// </summary>
public class CalculatingClass : INotifyPropertyChanged
{
    public CalculatingClass()
    {
        textForTextBox = "";
    }

    private string textForTextBox;
    public string TextForTextBox
    {
        get { return textForTextBox; }
        set
        {
            if (value == TextForTextBox)
                return;
            textForTextBox = value;
            OnPropertyChanged("TextForTextBox");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    private double firstNumber = 0;
    private double secondNumber = 0;
    private char operation;

    private enum State
    {
        Begin,
        FirstNumber,
        Operation,
        SecondNumber
    }
    private State state;
    private bool dotIsAllowed = true;
    private int positionOfOperation = 0;
    
    private bool IsOperation(char symbol)
        => symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/';

    private double Calculate()
    {
        switch (operation)
        {
            case '+': return firstNumber + secondNumber;
            case '-': return firstNumber - secondNumber;
            case '*': return firstNumber * secondNumber;
            case '/': return firstNumber / secondNumber;
            default: return 0;
        }
    }

    /// <summary>
    /// Checks whether last symbol is allowed. If it's false, deletes last symbol
    /// </summary>
    /// <returns>False, if error has occured and need to display messageBox with error, else returns true</returns>
    public bool Validation()
    {
        if (TextForTextBox.Length == 0)
        {
            state = State.Begin;
            dotIsAllowed = true;
            positionOfOperation = 0;
            return true;
        }
        char lastSymbol = TextForTextBox[TextForTextBox.Length - 1];
        char prevLastSymbol = TextForTextBox.Length < 2 ? '\0' : TextForTextBox[TextForTextBox.Length - 2];
        string textForTextBoxWithoutLastSymbol = TextForTextBox.Substring(0, TextForTextBox.Length - 1);

        if (lastSymbol == '=')
        {
            if (state == State.FirstNumber)
            {
                TextForTextBox = textForTextBoxWithoutLastSymbol;
                return true;
            }
            else if (state == State.Operation)
            {
                TextForTextBox = textForTextBoxWithoutLastSymbol.Substring(0, textForTextBoxWithoutLastSymbol.Length - 1);
                state = State.FirstNumber;
                dotIsAllowed = false;
                return true;
            }
            else if (state == State.SecondNumber)
            {
                if (prevLastSymbol == ',')
                {
                    TextForTextBox = textForTextBoxWithoutLastSymbol;
                    return true;
                }
                if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) || (operation == '/' && secondNumber == 0))
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                TextForTextBox = Calculate().ToString();
                state = State.FirstNumber;
                dotIsAllowed = false;
                return true;
            }
            TextForTextBox = textForTextBoxWithoutLastSymbol;
            return true;
        }

        if (state == State.Begin)
        {
            if (lastSymbol == '-' || lastSymbol == '+' || Char.IsDigit(lastSymbol))
            {
                state = State.FirstNumber;
                return true;
            }
        }
        else if (state == State.FirstNumber)
        {
            if (prevLastSymbol == ',' && !Char.IsDigit(lastSymbol))
            {
                TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                return true;
            }
            else if (Char.IsDigit(lastSymbol))
            {
                return true;
            }
            else if (lastSymbol == ',')
            {
                if (dotIsAllowed)
                {
                    dotIsAllowed = false;
                    return true;
                }
            }
            else if (IsOperation(lastSymbol))
            {
                if (!double.TryParse(TextForTextBox.Substring(0, TextForTextBox.Length - 1), out firstNumber))
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                operation = lastSymbol;
                positionOfOperation = TextForTextBox.Length - 1;
                state = State.Operation;
                return true;
            }
            else if (lastSymbol == '²')
            {
                if (!double.TryParse(TextForTextBox.Substring(0, TextForTextBox.Length - 1), out firstNumber))
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                firstNumber *= firstNumber;
                TextForTextBox = firstNumber.ToString();
                dotIsAllowed = false;
                return true;
            }
            else if (lastSymbol == '√')
            {
                if (!double.TryParse(TextForTextBox.Substring(0, TextForTextBox.Length - 1), out firstNumber) || firstNumber < 0)
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                firstNumber = Math.Sqrt(firstNumber);
                TextForTextBox = firstNumber.ToString();
                dotIsAllowed = false;
                return true;
            }
        }
        else if (state == State.Operation)
        {
            if (Char.IsDigit(lastSymbol))
            {
                state = State.SecondNumber;
                dotIsAllowed = true;
                return true;
            }
        }
        else if (state == State.SecondNumber)
        {
            if (prevLastSymbol == ',' && !Char.IsDigit(lastSymbol))
            {
                TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                return true;
            }
            else if (Char.IsDigit(lastSymbol))
            {
                return true;
            }
            else if (lastSymbol == ',')
            {
                if (dotIsAllowed)
                {
                    dotIsAllowed = false;
                    return true;
                }
            }
            else if (IsOperation(lastSymbol))
            {
                if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) || (operation == '/' && secondNumber == 0))
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                var result = Calculate();
                TextForTextBox = result.ToString() + lastSymbol;
                firstNumber = result;
                operation = lastSymbol;
                positionOfOperation = TextForTextBox.Length - 1;
                state = State.Operation;
                dotIsAllowed = true;
                return true;
            }
            else if (lastSymbol == '²')
            {
                if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) || operation == '/' && secondNumber == 0)
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                var result = Math.Pow(Calculate(), 2);
                TextForTextBox = result.ToString();
                state = State.FirstNumber;
                dotIsAllowed = false;
                return true;
            }
            else if (lastSymbol == '√')
            {
                double result;
                if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) 
                    || (result = Calculate()) < 0 || operation == '/' && secondNumber == 0)
                {
                    TextForTextBox = "";
                    state = State.Begin;
                    dotIsAllowed = true;
                    return false;
                }
                result = Math.Sqrt(result);
                TextForTextBox = result.ToString();
                state = State.FirstNumber;
                dotIsAllowed = false;
                return true;
            }
        }
        TextForTextBox = textForTextBoxWithoutLastSymbol;
        return true;
    }

    /// <summary>
    /// Checks expression without last symbol
    /// </summary>
    /// <returns>False, if error has occured and need to display messageBox with error, else returns true</returns>
    public bool validationForBackspace()
    {
        string text = TextForTextBox;
        TextForTextBox = "";
        state = State.Begin;
        dotIsAllowed = true;
        positionOfOperation = 0;
        foreach (var symbol in text)
        {
            TextForTextBox += symbol;
            if (!Validation())
            {
                TextForTextBox = "";
                state = State.Begin;
                dotIsAllowed = true;
                positionOfOperation = 0;
                return false;
            }
        }
        return true;
    }

}
