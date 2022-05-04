using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate bool ValidateEventHandler(string txt);

    public class TextBoxValidations : TextBox
    {
        private ValidateEventHandler _validate;
        public event ValidateEventHandler Validate
        {
            add
            {
                _validate += value;
                OnValidate();
            }
            remove
            {
                _validate -= value;
            }
        }

        public TextBoxValidations()
        {
            TextChanged += ValidateTextBox_TextChanged;
        }

        private void OnValidate()
        {
            if (_validate != null)
            {
                List<Delegate> _validateInvocationList = new List<Delegate>(_validate.GetInvocationList());
                
                var isValid = _validateInvocationList
                                .Select(item => (ValidateEventHandler)item)
                                .Any(validacao => validacao(Text));
                                
                Background = isValid
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }

        private void ValidateTextBox_TextChanged(object sender, TextChangedEventArgs e) => OnValidate();

    }
}
