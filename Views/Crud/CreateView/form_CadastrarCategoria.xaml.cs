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

using FinanWPF.Models;
using FinanWPF.Controllers;

namespace FinanWPF.Views
{
    /// <summary>
    /// Interaction logic for form_CadastrarCategoria.xaml
    /// </summary>
    public partial class form_CadastrarCategoria : Window
    {
        public form_CadastrarCategoria()
        {
            InitializeComponent();
        }

        private void btn_CadastrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            Categoria c = new Categoria();

            c.Nome = input_CategoriaNome.Text;

            CategoriaDAO.Create(c);

            MessageBox.Show("Categoria cadastrada com sucesso", "Cadastrar Categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);

        }
    }
}
