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
            var saveEventHandler = (RoutedEventHandler)SaveClick + CloseWindow;
            var cancelEventHandler = (RoutedEventHandler)CancelClick + CloseWindow;

            btnSave.Click += new RoutedEventHandler(saveEventHandler);
            btnCancel.Click += new RoutedEventHandler(cancelEventHandler);
        }

        private void FillTextBox()
        {
            txtNumber.Text = _agency.Numero;
            txtName.Text = _agency.Nome;
            txtPhone.Text = _agency.Telefone;
            txtAddress.Text = _agency.Endereco;
            txtDescription.Text = _agency.Descricao;
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CloseWindow(object sender, RoutedEventArgs e) => Close();
    }
}
