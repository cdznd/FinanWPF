using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using FinanWPF.Controllers;
using FinanWPF.Models;

namespace FinanWPF.Views
{
    /// <summary>
    /// Interaction logic for form_CadastrarLancamento.xaml
    /// </summary>
    public partial class form_CadastrarLancamento : Window
    {
        public form_CadastrarLancamento()
        {
            InitializeComponent();

            foreach (Categoria categoria in CategoriaDAO.Read())
            {

                //drop_SelectCategoria.Items.Add(categoria.Id + " - " + categoria.Nome);
                drop_SelectCategoria.Items.Add(categoria.Id + " - " + categoria.Nome + ".");

            }

            foreach (Conta conta in ContaDAO.Read())
            {

                //drop_SelectConta.Items.Add(conta.Id + " - " + conta.Nome);
                drop_SelectConta.Items.Add(conta.Id + " - " + conta.Nome + ".");

            }

        }

        private void btn_CadastrarLancamento_Click(object sender, RoutedEventArgs e)
        {
            //Gambiarra Só é possivel escolher conta e categoria com id de 2 digitos, ou seja no maximo 99 contas / categorias.
            Lancamento c = new Lancamento();

            string x = drop_SelectCategoria.SelectedItem.ToString();
            x = x.Substring(0, 2);

            string y = drop_SelectConta.SelectedItem.ToString();
            y = y.Substring(0,2);

            MessageBox.Show("Categoria = " + x + " Conta = " + y + ".", "Listar Categorias", MessageBoxButton.OK, MessageBoxImage.Information);
            c.ContaId = Convert.ToInt32(y);
            c.CategoriaId = Convert.ToInt32(x);

            c.Valor = Convert.ToDouble(input_LancamentoValue.Text);

            LancamentoDAO.Create(c);

        }
    }
}
