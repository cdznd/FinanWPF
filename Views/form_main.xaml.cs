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
using FinanWPF.Views.Crud.ReadView;

namespace FinanWPF.Views
{
    /// <summary>
    /// Interaction logic for form_main.xaml
    /// </summary>
    public partial class form_main : Window
    {

        //Constructor
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

      
            form_CadastrarCategoria form = new form_CadastrarCategoria();
            form.ShowDialog();

        }
        //Listar categorias
        private void MenuMostrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            view_Categoria view_Categoria = new view_Categoria();
            view_Categoria.ShowDialog();

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

            form_CadastrarConta form = new form_CadastrarConta();
            form.ShowDialog();

        }
        //Listar Contas
        private void MenuMostrarConta_Click(object sender, RoutedEventArgs e)
        {

            view_Conta y = new view_Conta();

            y.ShowDialog();
                
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


            form_CadastrarLancamento form = new form_CadastrarLancamento();
            form.ShowDialog();

        }
        //Listar lançamento
        private void MenuMostrarLancamentos_Click(object sender, RoutedEventArgs e)
        {

            view_Conta y = new view_Conta();
            y.ShowDialog();

        }
        //Editar/excluir lançamento
        private void MenuEditLancamentos_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Editar/Excluir Lancamentos", "Editar/Exluir Lancamentos", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void MenuCriarResumo_Click(object sender, RoutedEventArgs e)
        {

            Resume x = new Resume();

            x.ShowDialog();

        }
    }
}
