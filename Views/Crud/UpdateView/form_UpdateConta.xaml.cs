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
    /// Interaction logic for form_UpdateConta.xaml
    /// </summary>
    public partial class form_UpdateConta : Window
    {
        public form_UpdateConta()
        {
            
            InitializeComponent();

            clearForm();

            drop_SelectConta.ItemsSource = ContaDAO.Read();

            drop_SelectConta.DisplayMemberPath = "Nome";
            drop_SelectConta.SelectedValuePath = "Id";

        }

        public void clearForm()
        {

            input_ContaNome.Clear();

            input_ContaCPF.Clear();

            input_ContaNome.Focus();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(drop_SelectConta.Text))
            {

                int Id = (int)drop_SelectConta.SelectedValue;

                Conta c = ContaDAO.ReadById(Id);

                input_ContaNome.Text = c.Nome;

                input_ContaCPF.Text = c.Cpf;


            }
            else
            {

                MessageBox.Show("Erro : Campo vazio", "Atualizar conta", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void btn_AtualizarConta_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(drop_SelectConta.Text) && !string.IsNullOrEmpty(input_ContaCPF.Text) && !string.IsNullOrEmpty(input_ContaNome.Text))
            {

                int Id = (int)drop_SelectConta.SelectedValue;

                Conta c = ContaDAO.ReadById(Id);

                c.Nome = input_ContaNome.Text;

                c.Cpf = input_ContaCPF.Text;

                ContaDAO.Update(c);

                MessageBox.Show("Conta atualizada com sucesso!", "Atualizar conta", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                clearForm();


            }
            else
            {

                MessageBox.Show("Erro : Campo vazio", "Atualizar conta", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }
}
