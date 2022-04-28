using System.ComponentModel;

namespace Calculator
{
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

        private enum Operation
        {
            Addition, Subtraction, Multiplication, Division
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

        public void Validation()
        {
            if (TextForTextBox.Length == 0)
            {
                state = State.Begin;
                dotIsAllowed = true;
                positionOfOperation = 0;
                return;
            }
            char lastSymbol = TextForTextBox[TextForTextBox.Length - 1];
            char prevLastSymbol = TextForTextBox.Length < 2 ? '\0' : TextForTextBox[TextForTextBox.Length - 2];
            string textForTextBoxWithoutLastSymbol = TextForTextBox.Substring(0, TextForTextBox.Length - 1);

            if (lastSymbol == '=')
            {
                if (state == State.FirstNumber)
                {
                    TextForTextBox = textForTextBoxWithoutLastSymbol;
                    return;
                }
                else if (state == State.Operation)
                {
                    TextForTextBox = textForTextBoxWithoutLastSymbol.Substring(0, textForTextBoxWithoutLastSymbol.Length - 1);
                    state = State.FirstNumber;
                    dotIsAllowed = false;
                    return;
                }
                else if (state == State.SecondNumber)
                {
                    if (prevLastSymbol == ',')
                    {
                        TextForTextBox = textForTextBoxWithoutLastSymbol;
                        return;
                    }
                    if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) || (operation == '/' && secondNumber == 0))
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    TextForTextBox = Calculate().ToString();
                    state = State.FirstNumber;
                    dotIsAllowed = false;
                    return;
                }
                TextForTextBox = textForTextBoxWithoutLastSymbol;
                return;
            }


            if (state == State.Begin)
            {
                if (lastSymbol == '-' || lastSymbol == '+' || Char.IsDigit(lastSymbol))
                {
                    state = State.FirstNumber;
                    return;
                }
            }
            else if (state == State.FirstNumber)
            {
                if (prevLastSymbol == ',' && !Char.IsDigit(lastSymbol))
                {
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;
                }
                else if (Char.IsDigit(lastSymbol))
                {
                    return;
                }
                else if (lastSymbol == ',')
                {
                    if (dotIsAllowed)
                    {
                        dotIsAllowed = false;
                        return;
                    }
                }
                else if (IsOperation(lastSymbol))
                {
                    if (!double.TryParse(TextForTextBox.Substring(0, TextForTextBox.Length - 1), out firstNumber))
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    operation = lastSymbol;
                    positionOfOperation = TextForTextBox.Length - 1;
                    state = State.Operation;
                    return;
                }
                else if (lastSymbol == '²')
                {
                    if (!double.TryParse(TextForTextBox.Substring(0, TextForTextBox.Length - 1), out firstNumber))
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    firstNumber *= firstNumber;
                    TextForTextBox = firstNumber.ToString();
                    dotIsAllowed = false;
                    return;
                }
                else if (lastSymbol == '√')
                {
                    if (!double.TryParse(TextForTextBox.Substring(0, TextForTextBox.Length - 1), out firstNumber) || firstNumber < 0)
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    firstNumber = Math.Sqrt(firstNumber);
                    TextForTextBox = firstNumber.ToString();
                    dotIsAllowed = false;
                    return;
                }
            }
            else if (state == State.Operation)
            {
                if (Char.IsDigit(lastSymbol))
                {
                    state = State.SecondNumber;
                    dotIsAllowed = true;
                    return;
                }
            }
            else if (state == State.SecondNumber)
            {
                if (prevLastSymbol == ',' && !Char.IsDigit(lastSymbol))
                {
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;
                }
                else if (Char.IsDigit(lastSymbol))
                {
                    return;
                }
                else if (lastSymbol == ',')
                {
                    if (dotIsAllowed)
                    {
                        dotIsAllowed = false;
                        return;
                    }
                }
                else if (IsOperation(lastSymbol))
                {
                    if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) || (operation == '/' && secondNumber == 0))
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    var result = Calculate();
                    TextForTextBox = result.ToString() + lastSymbol;
                    firstNumber = result;
                    operation = lastSymbol;
                    positionOfOperation = TextForTextBox.Length - 1;
                    state = State.Operation;
                    dotIsAllowed = true;
                    return;
                }
                else if (lastSymbol == '²')
                {
                    if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber))
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    var result = Math.Pow(Calculate(), 2);
                    TextForTextBox = result.ToString();
                    state = State.FirstNumber;
                    dotIsAllowed = false;
                    return;
                }
                else if (lastSymbol == '√')
                {
                    double result;
                    if (!double.TryParse(textForTextBoxWithoutLastSymbol.Substring(positionOfOperation + 1), out secondNumber) || (result = Calculate()) < 0)
                    {
                        TextForTextBox = "";
                        state = State.Begin;
                        dotIsAllowed = true;
                        return;
                    }
                    result = Math.Sqrt(result);
                    TextForTextBox = result.ToString();
                    state = State.FirstNumber;
                    dotIsAllowed = false;
                    return;
                }
            }
            TextForTextBox = textForTextBoxWithoutLastSymbol;
        }

        public void validationForBackspace()
        {
            string text = TextForTextBox;
            TextForTextBox = "";
            state = State.Begin;
            dotIsAllowed = true;
            positionOfOperation = 0;
            foreach (var symbol in text)
            {
                TextForTextBox += symbol;
                Validation();
            }
        }

    }
}