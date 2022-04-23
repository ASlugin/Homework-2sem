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

        private enum States
        {
            begin,
            digit,
            dot,
            digitAfterDot,
            operation,
            fail
        }

        private States state = States.begin;
        

        public void Calculate()
        {

            
            
        }

    }
}
