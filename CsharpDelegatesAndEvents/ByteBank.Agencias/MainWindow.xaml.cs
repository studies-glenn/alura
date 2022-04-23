using ByteBank.Agencias.DAL.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
	{
		private readonly ByteBankContext _dbContext = new ByteBankContext();
		private readonly ListBox _lstAgencies;

		public MainWindow()
		{
			InitializeComponent();
			_lstAgencies = new ListBox();
			InitializeControllers();
			UpdateAgenciesList();
		}

		private void InitializeControllers()
		{
			_lstAgencies.Width = 290;
			_lstAgencies.Height = 320;
			Canvas.SetTop(_lstAgencies, 15);
			Canvas.SetLeft(_lstAgencies, 15);
			container.Children.Add(_lstAgencies);

			//? private delegate void SelectionChangedEventHandler
			//? delegate :: methods manipulation
			_lstAgencies.SelectionChanged += new SelectionChangedEventHandler(lstAgencies_SelectionChanged);

			
		}

		private void UpdateAgenciesList()
		{
			var agencies = _dbContext.Agencias.ToList();
			_lstAgencies.Items.Clear();
			foreach (var item in agencies)
			{
				_lstAgencies.Items.Add(item);
			}
		}

		private void lstAgencies_SelectionChanged(object sender, RoutedEventArgs e)
		{
			var selectedAgency = (Agencia)_lstAgencies.SelectedItem;

			txtNumber.Text = selectedAgency.Numero;
			txtName.Text = selectedAgency.Nome;
			txtPhone.Text = selectedAgency.Telefone;
			txtAddress.Text = selectedAgency.Endereco;
			txtDescription.Text = selectedAgency.Descricao;
		}

		private void Delete(object sender, RoutedEventArgs e)
		{
			var confirmDeletion = MessageBox.Show("Confirma exclusão do item?", "Confirmação", MessageBoxButton.YesNo);
			if (confirmDeletion == MessageBoxResult.Yes)
			{
				_dbContext.Agencias.Remove((Agencia)_lstAgencies.SelectedItem);
				UpdateAgenciesList();
			}
		}


		private void Edit(object sender, RoutedEventArgs e)
        {
            var editWindow = new AgencyEdit((Agencia)_lstAgencies.SelectedItem);
			var result = editWindow.ShowDialog().Value;
            if (result == true)
            {

            }
            else
            {
                
            }
        }
	}
}
