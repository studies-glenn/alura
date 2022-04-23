using ByteBank.Agencias.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
	// public class ListBox : System.Windows.Controls.ListBox
	// {
	//     private readonly MainWindow _main;
	//     public ListBox(MainWindow mainWndow)
	//     {
	//         _main = mainWndow ?? throw new ArgumentNullException(nameof(mainWndow));
	//     }

	//     protected override void OnSelectionChanged(SelectionChangedEventArgs e)
	//     {
	//         base.OnSelectionChanged(e);

	//         var selectedAgency = (Agencia)SelectedItem;

	//         _main.txtNumber.Text = selectedAgency.Numero;
	//         _main.txtName.Text = selectedAgency.Nome;
	//         _main.txtPhone.Text = selectedAgency.Telefone;
	//         _main.txtAddress.Text = selectedAgency.Endereco;
	//         _main.txtDescription.Text = selectedAgency.Descricao;
	//     }
	// }
}
