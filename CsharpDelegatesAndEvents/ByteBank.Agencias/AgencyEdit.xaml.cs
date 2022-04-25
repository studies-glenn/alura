using System;
using System.Windows;
using System.Windows.Documents;
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
        }

        private void FillTextBox()
        {
            txtNumber.Text = _agency.Numero;
            txtName.Text = _agency.Nome;
            txtPhone.Text = _agency.Telefone;
            txtAddress.Text = _agency.Endereco;
            txtDescription.Text = _agency.Descricao;
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => Close();
    }
}
