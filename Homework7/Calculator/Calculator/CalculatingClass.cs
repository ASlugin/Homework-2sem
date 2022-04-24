using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatingClass : INotifyPropertyChanged
    {
        public CalculatingClass()
        {
            state = States.Begin;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string erorrString = "error";
        private enum States
        {
            Begin,
            SignBeforeFirstNumber,
            DigitFirstNumber,
            DotFirstNUmber,
            DigitAfterDotFirstNumber,
            Operation,
            DigitSecondNumber,
            DotSecondNUmber,
            DigitAfterDotSecondNumber,
        }
        private States state;
        private int positionOperation;

        public void ValidationForSqr()
        {
            if (state == States.DigitFirstNumber || state == States.DigitSecondNumber
                || state == States.DigitAfterDotFirstNumber || state == States.DigitAfterDotSecondNumber)
            {
                if (state == States.DigitAfterDotSecondNumber || state == States.DigitSecondNumber)
                {
                    Calculate();
                }
                if (Double.TryParse(TextForTextBox, out double number))
                {
                    TextForTextBox += '²';
                    Calculate();
                    
                }
                state = States.DigitAfterDotFirstNumber;
            }
        }
        public void ValidationForSqrt()
        {
            if (state == States.DigitFirstNumber || state == States.DigitSecondNumber
                || state == States.DigitAfterDotFirstNumber || state == States.DigitAfterDotSecondNumber)
            {
                if (state == States.DigitAfterDotSecondNumber || state == States.DigitSecondNumber)
                {
                    Calculate();
                }
                if (Double.TryParse(TextForTextBox, out double number) && number >= 0)
                {
                    TextForTextBox = '√' + TextForTextBox;
                    Calculate();

                }
                state = States.DigitAfterDotFirstNumber;
            }
        }

        public void ValidationForBackspace()
        {
            string stringForCheck = TextForTextBox;
            TextForTextBox = "";
            state = States.Begin;
            positionOperation = 0;
            foreach (char symbol in stringForCheck)
            {
                TextForTextBox += symbol;
                Validation();
            }
        }

        public void Validation()
        {
            if (TextForTextBox.Length == 0)
            {
                state = States.Begin;
                positionOperation = 0;
                return;
            }

            char lastSymbol = TextForTextBox[TextForTextBox.Length - 1];
            string textWothoutLastSymbol = TextForTextBox.Substring(0, TextForTextBox.Length - 1);

            if (String.Compare(textWothoutLastSymbol, erorrString) == 0 || String.Compare(TextForTextBox, erorrString) == 0)
            {
                TextForTextBox = "";
                state = States.Begin;
                positionOperation = 0;
                return;
            }
            
            switch (state)
            {
                case States.Begin:
                    if (Char.IsDigit(lastSymbol))
                    {
                        state = States.DigitFirstNumber;
                        return;
                    }
                    else if (lastSymbol == '-' || lastSymbol == '+')
                    {
                        state = States.SignBeforeFirstNumber;
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.SignBeforeFirstNumber:
                    if (Char.IsDigit(lastSymbol))
                    {
                        state = States.DigitFirstNumber;
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.DigitFirstNumber:
                    if (lastSymbol == ',')
                    {
                        state = States.DotFirstNUmber;
                        return;
                    }
                    else if (IsOperation(lastSymbol))
                    {
                        state = States.Operation;
                        positionOperation = TextForTextBox.Length - 1;
                        return;
                    }
                    else if (Char.IsDigit(lastSymbol))
                    {
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.DotFirstNUmber:
                    if (Char.IsDigit(lastSymbol))
                    {
                        state = States.DigitAfterDotFirstNumber;
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.DigitAfterDotFirstNumber:
                    if (IsOperation(lastSymbol))
                    {
                        state = States.Operation;
                        positionOperation = TextForTextBox.Length - 1;
                        return;
                    }
                    else if (Char.IsDigit(lastSymbol))
                    {
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return ;
                case States.Operation:
                    if (Char.IsDigit(lastSymbol))
                    {
                        state = States.DigitSecondNumber;
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.DigitSecondNumber:
                    if (lastSymbol == ',')
                    {
                        state = States.DotSecondNUmber;
                        return;
                    }
                    else if (IsOperation(lastSymbol))
                    {
                        Calculate();
                        state = States.Operation;
                        positionOperation = TextForTextBox.Length - 1;
                        return;
                    }
                    else if (lastSymbol == '=')
                    {
                        Calculate();
                        state = States.DigitAfterDotFirstNumber;
                        positionOperation = 0;
                        return;
                    }
                    else if (Char.IsDigit(lastSymbol))
                    {
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.DotSecondNUmber:
                    if (Char.IsDigit(lastSymbol))
                    {
                        state = States.DigitAfterDotSecondNumber;
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                case States.DigitAfterDotSecondNumber:
                    if (IsOperation(lastSymbol))
                    {
                        Calculate();
                        state = States.Operation;
                        positionOperation = TextForTextBox.Length - 1;
                        return;
                    }
                    else if (lastSymbol == '=')
                    {
                        Calculate();
                        state = States.DigitAfterDotFirstNumber;
                        positionOperation = 0;
                        return;
                    }
                    else if (Char.IsDigit(lastSymbol))
                    {
                        return;
                    }
                    TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
                    return;

                default:
                    return;
            }

        }

        private bool IsOperation (char symbol)
            => symbol == '-' || symbol == '+' || symbol == '*' || symbol == '/';

        private void Calculate()
        {
            if (TextForTextBox[TextForTextBox.Length - 1] == '²')
            {
                var resultSqr = Math.Pow(Double.Parse(TextForTextBox.Substring(0, TextForTextBox.Length - 1)), 2);
                TextForTextBox = resultSqr.ToString();
                return;
            }
            if (TextForTextBox[0] == '√')
            {
                var resultSqrt = Math.Sqrt(Double.Parse(TextForTextBox.Substring(1)));
                TextForTextBox = resultSqrt.ToString();
                return;
            }

            if (positionOperation == 0)
            {
                return;
            }

            char nextOperation = '\0';
            if (IsOperation(TextForTextBox[TextForTextBox.Length - 1]) || TextForTextBox[TextForTextBox.Length - 1] == '=')
            {
                nextOperation = TextForTextBox[TextForTextBox.Length - 1];
                TextForTextBox = TextForTextBox.Substring(0, TextForTextBox.Length - 1);
            }

            var firstNumber = Double.Parse(TextForTextBox.Substring(0, positionOperation));
            var secondNumber = Double.Parse(TextForTextBox.Substring(positionOperation + 1));
            char operation = TextForTextBox[positionOperation];

            double result = 0;
            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber == 0)
                    {
                        TextForTextBox = erorrString;
                        return;
                    }
                    result = firstNumber / secondNumber;
                    break;
            }
            if (nextOperation == '=')
            {
                TextForTextBox = result.ToString();
            }
            else
            {
                TextForTextBox = result.ToString() + nextOperation;
            }
        }
    }
}
