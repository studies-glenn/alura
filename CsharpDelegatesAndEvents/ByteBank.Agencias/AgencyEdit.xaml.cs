using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using ByteBank.Agencias.DAL.Models;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for AgencyEdit.xaml
    /// </summary>
    public partial class AgencyEdit : Window
    {
        private readonly Agencia _agency;
        public AgencyEdit(Agencia agency)
        {
            InitializeComponent();
            InitializeControls();
            _agency = agency ?? throw new ArgumentNullException(nameof(agency));
            FillTextBox();
        }

        private void InitializeControls()
        {
            //!Anonymous method
            /*
             *! In the course whe example is this:
             ** RoutedEventHandler dialogResultTrue = delegate(object o, RoutedEventArgs e)
             ** {
             **      DialogResult = true;
             ** }
             */
            RoutedEventHandler saveHandler = (sender, e) =>
            {
                DialogResult = true;
            };
            RoutedEventHandler cancelHandler = (sender, e) =>
            {
                DialogResult = false;
            };

            var saveEventHandler = saveHandler + CloseWindow;
            var cancelEventHandler = cancelHandler + CloseWindow;

            btnSave.Click += saveEventHandler;
            btnCancel.Click += cancelEventHandler;

            txtName.Validate += BuildDelegateForTextFields;
            txtDescription.Validate += BuildDelegateForTextFields;
            txtAddress.Validate += BuildDelegateForTextFields;
            txtPhone.Validate += BuildDelegateForTextFields;
            txtNumber.Validate += BuildDelegateForTextFields;
            txtNumber.Validate += ValidateOnlyDigits;
        }

        private void FillTextBox()
        {
            txtNumber.Text = _agency.Numero.Trim();
            txtName.Text = _agency.Nome.Trim();
            txtPhone.Text = _agency.Telefone.Trim();
            txtAddress.Text = _agency.Endereco.Trim();
            txtDescription.Text = _agency.Descricao.Trim();
        }

        private void BuildDelegateForTextFields(object sender, ValidateEventArgs e)
            => e.isValid = !string.IsNullOrEmpty(e.Text);

        private void ValidateOnlyDigits(object sender, ValidateEventArgs e)
            => e.isValid = e.Text.All(char.IsDigit);

        private void CloseWindow(object sender, RoutedEventArgs e) => Close();
    }
}
