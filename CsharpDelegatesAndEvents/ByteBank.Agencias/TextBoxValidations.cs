using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate void ValidateEventHandler(object sender, ValidateEventArgs e);

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
        
        protected virtual void OnValidate()
        {
            if (_validate != null)
            {
                var _validateInvocationList = _validate.GetInvocationList();
                var validateEventArgs = new ValidateEventArgs(Text);

                var isValid = true;
                foreach (ValidateEventHandler invocation in _validateInvocationList)
                {
                    invocation(this, validateEventArgs);
                    if (!validateEventArgs.isValid)
                    {
                        isValid = false;
                        break;
                    }
                }

                                
                Background = isValid
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidate();
        }
    }
}
