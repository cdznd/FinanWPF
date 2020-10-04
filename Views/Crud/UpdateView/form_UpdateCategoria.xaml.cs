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

namespace FinanWPF.Views.Crud.UpdateView
{
    /// <summary>
    /// Interaction logic for form_UpdateCategoria.xaml
    /// </summary>
    public partial class form_UpdateCategoria : Window
    {
        public form_UpdateCategoria()
        {
            InitializeComponent();

            clearForm();

            drop_SelectCategoria.ItemsSource = CategoriaDAO.Read();

            drop_SelectCategoria.DisplayMemberPath = "Nome";
            drop_SelectCategoria.SelectedValuePath = "Id";

        }

        public void clearForm()
        {

            input_CategoriaNome.Clear();

            input_CategoriaNome.Focus();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(drop_SelectCategoria.Text))
            {

                int Id = (int)drop_SelectCategoria.SelectedValue;

                Categoria c = CategoriaDAO.ReadById(Id);

                input_CategoriaNome.Text = c.Nome;

            }
            else
            {

                MessageBox.Show("Erro : Campo vazio", "Atualizar conta", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btn_AtualizarCategoria_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(drop_SelectCategoria.Text) && !string.IsNullOrEmpty(input_CategoriaNome.Text))
            {

                int Id = (int)drop_SelectCategoria.SelectedValue;

                Categoria c = CategoriaDAO.ReadById(Id);

                c.Nome = input_CategoriaNome.Text;

                CategoriaDAO.Update(c);

                MessageBox.Show("Categoria atualizada com sucesso!", "Atualizar categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                clearForm();


            }
            else
            {

                MessageBox.Show("Erro : Campo vazio", "Atualizar categoria", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

     }
}
