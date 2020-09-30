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

            List<dynamic> Categorias1 = new List<dynamic>();

            foreach (Categoria cc in CategoriaDAO.Read())
            {

                dynamic CategoriaC = new
                {

                    Nome = cc.Nome,
                    Data = cc.CreationDate

                };

                Categorias1.Add(CategoriaC);
            }

            dataGrid_Categoria.ItemsSource = Categorias1;

            dataGrid_Categoria.Items.Refresh();

            //Dropdown
            drop_FindCategoria.ItemsSource = CategoriaDAO.Read();

            drop_FindCategoria.DisplayMemberPath = "Nome";
            drop_FindCategoria.SelectedValuePath = "Id";

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void btn_MostrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            if (drop_FindCategoria.SelectedItem != null)
            {

                List<dynamic> Categorias = new List<dynamic>();

                int id = (int)drop_FindCategoria.SelectedValue;

                Categoria c = CategoriaDAO.ReadById(id);

                Categoria.Content = c.Nome;

                Lancamentos.Content = Convert.ToString(c.Lancamento.Count);

                DataCriacao.Content = Convert.ToString(c.CreationDate);

                foreach (Lancamento l in c.Lancamento)
                {

                    dataGrid_Categoria2.ItemsSource = "";

                    dynamic CategoriaD = new
                    {

                        Nome = c.Nome,
                        Conta = l.Conta.Nome,
                        Valor = l.Valor,
                        Data = l.CreationDate

                    };

                    Categorias.Add(CategoriaD);

                }

                dataGrid_Categoria2.ItemsSource = Categorias;

                dataGrid_Categoria2.Items.Refresh();

            }
            else
            {

                MessageBox.Show("Erro : Escolha uma categoria", "Categorias", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }


    }

}

