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

namespace FinanWPF.Views.Crud.ReadView
{
    /// <summary>
    /// Interaction logic for view_Categoria.xaml
    /// </summary>
    public partial class view_Categoria : Window
    {
        public view_Categoria()
        {
            InitializeComponent();
               

            dataGrid_Categoria.ItemsSource = CategoriaDAO.Read();

            //Dropdown categoria
            foreach (Categoria c in CategoriaDAO.Read())
            {

                //drop_SelectCategoria.Items.Add(categoria.Id + " - " + categoria.Nome);
                drop_FindCategoria.Items.Add(c.Nome);

            }

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void btn_MostrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            string x = drop_FindCategoria.SelectedItem.ToString();

            foreach (Categoria y in CategoriaDAO.ReadByName(x))
            {

                //dataGrid_Categoria.ItemsSource = CategoriaDAO.ReadByName(y.Nome);

                dataGrid_Categoria.ItemsSource = CategoriaDAO.Read();

                dataGrid_Categoria2.ItemsSource = y.Lancamento;

                Categoria.Content = y.Nome;

                Lancamentos.Content = Convert.ToString(y.Lancamento.Count);                               

                DataCriacao.Content = Convert.ToString(y.CreationDate);

            }


        }
    }
}
