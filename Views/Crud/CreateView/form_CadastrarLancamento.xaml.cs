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

            clearForm();
            //Prenche os dropdown

            drop_SelectCategoria.ItemsSource = CategoriaDAO.Read();

            drop_SelectCategoria.DisplayMemberPath = "Nome";
            drop_SelectCategoria.SelectedValuePath = "Id";

            drop_SelectConta.ItemsSource = ContaDAO.Read();

            drop_SelectConta.DisplayMemberPath = "Nome";
            drop_SelectConta.SelectedValuePath = "Id";

        }

        public void clearForm()
        {

            input_LancamentoValue.Clear();

        }

        private void btn_CadastrarLancamento_Click(object sender, RoutedEventArgs e)
        {

            if (drop_SelectCategoria.SelectedItem == null || drop_SelectConta.SelectedItem == null || input_LancamentoValue.Text == "")
            {

                MessageBox.Show("Erro : Campo vazio", "Cadastrar lançamento - Erro ", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                int CategoriaId = (int)drop_SelectCategoria.SelectedValue;

                int ContaId = (int)drop_SelectConta.SelectedValue;

                double valor = Convert.ToDouble(input_LancamentoValue.Text);

                Lancamento c = new Lancamento();

                c.ContaId = ContaId;

                c.CategoriaId = CategoriaId;

                c.Valor = valor;

                LancamentoDAO.Create(c);

                MessageBox.Show("Lançamento no valor de " + c.Valor + " na Categoria " + LancamentoDAO.ReadById(c.Id).Categoria.Nome + " para a Conta " + LancamentoDAO.ReadById(c.Id).Conta.Nome + " Cadastrado com sucesso!!", "Listar Categorias", MessageBoxButton.OK, MessageBoxImage.Information);

                clearForm();

            }

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

    }
}
