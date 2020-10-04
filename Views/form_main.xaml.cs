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
using FinanWPF.Views.Crud.UpdateView;
using FinanWPF.Views.Crud.DeleteView;


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

            if (MessageBox.Show("Sair?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
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
        //Editar categoria
        private void MenuEditCategoria_Click(object sender, RoutedEventArgs e)
        {

            form_UpdateCategoria form = new form_UpdateCategoria();
            form.ShowDialog();

        }
        //Deletar categoria
        private void MenuDeleteCategoria_Click(object sender, RoutedEventArgs e)
        {

            form_DeleteCategoria form = new form_DeleteCategoria();

            form.ShowDialog();

        }



        //CONTAS

        //Cadastrar Conta
        private void MenuCadastrarConta_Click(object sender, RoutedEventArgs e)
        {

            form_CadastrarConta form = new form_CadastrarConta();
            form.ShowDialog();

        }

        //Editar Contas
        private void MenuEditConta_Click(object sender, RoutedEventArgs e)
        {

            form_UpdateConta form = new form_UpdateConta();
            form.ShowDialog();

        }
        //Deletar Contas
        private void MenuDeleteConta_Click(object sender, RoutedEventArgs e)
        {

            form_DeleteConta form = new form_DeleteConta();

            form.ShowDialog();

        }



        //LANCAMENTOS

        //Cadastrar lançamento
        private void MenuCadastrarLancamentos_Click(object sender, RoutedEventArgs e)
        {


            form_CadastrarLancamento form = new form_CadastrarLancamento();
            form.ShowDialog();

        }

        //CRIAR RESUMO
        private void MenuCriarResumo_Click(object sender, RoutedEventArgs e)
        {

            view_Conta y = new view_Conta();
            y.ShowDialog();

        }

        
    }

}
