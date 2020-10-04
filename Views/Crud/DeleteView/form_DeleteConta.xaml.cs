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
    /// Interaction logic for form_DeleteConta.xaml
    /// </summary>
    public partial class form_DeleteConta : Window
    {
        public form_DeleteConta()
        {
            InitializeComponent();

            drop_SelectConta.ItemsSource = ContaDAO.Read();

            drop_SelectConta.DisplayMemberPath = "Nome";
            drop_SelectConta.SelectedValuePath = "Id";
        }

        private void btn_deletar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Tem certeza em excluir essa conta? Ao exluir uma conta todos os seus lançamentos são excluidos tambem.", "Excluir conta", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                int Id = (int)drop_SelectConta.SelectedValue;

                Conta c = ContaDAO.ReadById(Id);

                ContaDAO.Delete(c);

                MessageBox.Show("Conta excluida com sucesso!", "Excluir categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }
}
