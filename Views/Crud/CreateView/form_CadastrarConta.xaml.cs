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
using FinanWPF.Utils;

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

            if(!(input_ContaNome.Text == "" || input_ContaCPF.Text == ""))
            {

                Conta c = new Conta();

                c.Nome = input_ContaNome.Text;

                string cpf = input_ContaCPF.Text;

                if (Utility.verificaCpfExistente(cpf))
                {

                    MessageBox.Show("Erro : CPF Ja existe", "Cadastrar conta", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {

                    c.Cpf = input_ContaCPF.Text;

                    ContaDAO.Create(c);

                    MessageBox.Show("Conta cadastrada com sucesso", "Cadastrar conta", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    clearForm();
                }               


            }
            else
            {

                MessageBox.Show("Erro : Campo vazio", "Cadastrar conta", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }
}
