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

namespace FinanWPF.Views
{
    /// <summary>
    /// Interaction logic for form_main.xaml
    /// </summary>
    public partial class form_main : Window
    {
        public form_main()
        {
            InitializeComponent();
        }





        //Evento de click do item _file no menu
        //Close Event
        private void ManuSair_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (MessageBox.Show("Are you sure?", "Exiting", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {

                e.Cancel = true;

            }

        }



        //CATEGORIAS

        //Cadastrar Categoria
        private void MenuCadastrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Cadastrar Categoria", "Cadastrar Categoria", MessageBoxButton.OK, MessageBoxImage.Information);

            form_CadastrarCategoria form = new form_CadastrarCategoria();
            form.ShowDialog();

        }
        //Listar categorias
        private void MenuMostrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Listar Categoria", "Listar Categorias", MessageBoxButton.OK, MessageBoxImage.Information);

            dataGrid.ItemsSource = CategoriaDAO.Read();

        }
        //Editar/Excluir categoria
        private void MenuEditCategoria_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Editar/Excluir Categoria", "Editar/Excluir Categoria", MessageBoxButton.OK, MessageBoxImage.Warning);

        }



        //CONTAS

        //Cadastrar Conta
        private void MenuCadastrarConta_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Cadastrar Conta", "Cadastrar Conta", MessageBoxButton.OK, MessageBoxImage.Information);

            form_CadastrarConta form = new form_CadastrarConta();
            form.ShowDialog();

        }
        //Listar Contas
        private void MenuMostrarConta_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Listar contas", "Listar contas", MessageBoxButton.OK, MessageBoxImage.Information);

            dataGrid.ItemsSource = ContaDAO.Read();

        }
        //Editar/excluir Contas
        private void MenuEditConta_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Editar/Excluir contas", "Editar/Excluir contas", MessageBoxButton.OK, MessageBoxImage.Warning);

        }



        //LANCAMENTOS

        //Cadastrar lançamento
        private void MenuCadastrarLancamentos_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Cadastrar Lancamento", "Cadastrar Lancamento", MessageBoxButton.OK, MessageBoxImage.Information);

            form_CadastrarLancamento form = new form_CadastrarLancamento();
            form.ShowDialog();

        }
        //Listar lançamento
        private void MenuMostrarLancamentos_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("Listar Lancamentos", "Listar Lancamentos", MessageBoxButton.OK, MessageBoxImage.Information);

            dataGrid.ItemsSource = LancamentoDAO.Read();

        }
        //Editar/excluir lançamento
        private void MenuEditLancamentos_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Editar/Excluir Lancamentos", "Editar/Exluir Lancamentos", MessageBoxButton.OK, MessageBoxImage.Warning);

        }


        //FUNCIONALIDADE DE RESUMO
        private void MenuCriarResumo_Click(object sender, RoutedEventArgs e)
        {

           

        }

        //Pesquisar categoria
        private void btn_PesquisarCategoria_Click(object sender, RoutedEventArgs e)
        {

            dataGrid.ItemsSource = CategoriaDAO.ReadByName(form_PesquisarCategoria.Text);

        }

        //Pesquisar conta
        private void btn_PesquisarConta_Click(object sender, RoutedEventArgs e)
        {
            //Pesquisa pelo nome
            dataGrid.ItemsSource = ContaDAO.ReadByName(form_PesquisarConta.Text);
            
            //Pesquisa pelo cpf
            //dataGrid.ItemsSource = ContaDAO.ReadByCpf(form_PesquisarConta.Text);

        }

        //Pesquisar lançamento
        private void btn_PesquisarLancamento_Click(object sender, RoutedEventArgs e)
        {

            dataGrid.ItemsSource = LancamentoDAO.ReadByCategoryName(form_PesquisarLancamento.Text);

            //Pesquisar pelo nome da conta
            dataGrid.ItemsSource = LancamentoDAO.ReadByContaName(form_PesquisarLancamento.Text);

            //Pesquisar pelo cpf da conta
            //dataGrid.ItemsSource = LancamentoDAO.ReadByContaCPF(form_PesquisarLancamento.Text);

        }
        //Pesquisa lançamento pelo valor
        private void btn_PesquisarLancamentoValor_Click(object sender, RoutedEventArgs e)
        {

            dataGrid.ItemsSource = LancamentoDAO.ReadByValorInter(Convert.ToDouble(form_PesquisarLancamentoValor1.Text), Convert.ToDouble(form_PesquisarLancamentoValor2.Text));

        }

    }
}
