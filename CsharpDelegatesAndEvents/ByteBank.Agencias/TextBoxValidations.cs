using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate bool ValidateEventHandler(string txt);

    public class TextBoxValidations : TextBox
    {
        public event ValidateEventHandler Validate;

        public TextBoxValidations()
        {
            TextChanged += ValidateTextBox_TextChanged;
        }

        private void ValidateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validate != null)
            {
                var isValid = Validate(Text);
                Background = isValid
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
