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
    /// Interaction logic for form_CadastrarConta.xaml
    /// </summary>
    public partial class form_CadastrarConta : Window
    {
        public form_CadastrarConta()
        {
            InitializeComponent();
        }

        public void clearForm()
        {

            input_ContaNome.Clear();

            input_ContaCPF.Clear();

            input_ContaNome.Focus();

        }

        private void btn_CadastrarConta_Click(object sender, RoutedEventArgs e)
        {

            Conta c = new Conta();

            //Console.WriteLine(" - - - Cadastrar Conta - - - ");

            //Console.Write("Escreva o nome da Conta:");
            c.Nome = input_ContaNome.Text;

            //Console.Write("Escreva o cpf da Conta:");
            c.Cpf = input_ContaCPF.Text;

            ContaDAO.Create(c);

            MessageBox.Show("Conta cadastrada com sucesso", "Cadastrar conta", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            clearForm();

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }
}
