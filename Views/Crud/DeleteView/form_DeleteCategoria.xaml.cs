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

namespace FinanWPF.Views.Crud.DeleteView
{
    /// <summary>
    /// Interaction logic for form_DeleteCategoria.xaml
    /// </summary>
    public partial class form_DeleteCategoria : Window
    {
        public form_DeleteCategoria()
        {

            InitializeComponent();

            drop_SelectCategoria.ItemsSource = CategoriaDAO.Read();

            drop_SelectCategoria.DisplayMemberPath = "Nome";
            drop_SelectCategoria.SelectedValuePath = "Id";



        }

        private void btn_deletar_Click(object sender, RoutedEventArgs e)
        {

            if(MessageBox.Show("Tem certeza em excluir essa categoria? Ao exluir uma categoria todos os seus lançamentos são excluidos tambem.", "Excluir categoria", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                int Id = (int)drop_SelectCategoria.SelectedValue;

                Categoria c = CategoriaDAO.ReadById(Id);

                CategoriaDAO.Delete(c);

                MessageBox.Show("Categoria excluida com sucesso!", "Excluir categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

    }
}
