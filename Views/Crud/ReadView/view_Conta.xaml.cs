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

namespace FinanWPF.Views.Crud.ReadView
{
    /// <summary>
    /// Interaction logic for view_Conta.xaml
    /// </summary>
    public partial class view_Conta : Window
    {
        public view_Conta()
        {
            InitializeComponent();

            //Dropdown conta
            foreach (Conta c in ContaDAO.Read())
            {

                //drop_SelectCategoria.Items.Add(categoria.Id + " - " + categoria.Nome);
                drop_FindConta.Items.Add(c.Nome);

            }

            //Dropdown categoria
            foreach (Categoria c in CategoriaDAO.Read())
            {

                //drop_SelectCategoria.Items.Add(categoria.Id + " - " + categoria.Nome);
                drop_FindCategoria.Items.Add(c.Nome);

            }

        }



        private void btn_PesquisarConta_Click(object sender, RoutedEventArgs e)
        {
            
            

            string x = drop_FindConta.SelectedItem.ToString();           

            foreach(Conta y in ContaDAO.ReadByName(x))
            {

                //Todas as contas do drop
                //filter pela categoria

                if (checkBox_Categoria.IsChecked.Value || checkBox_first.IsChecked.Value) { 

                    if(checkBox_Categoria.IsChecked.Value && checkBox_first.IsChecked.Value)
                    {

                        dataGrid.ItemsSource = LancamentoDAO.ReadByAll(y.Nome, drop_FindCategoria.Text, Convert.ToDouble(form_PesquisarLancamentoValor1.Text), Convert.ToDouble(form_PesquisarLancamentoValor2.Text));

                    }
                    else
                    {

                        if (checkBox_Categoria.IsChecked.Value)
                        {

                            dataGrid.ItemsSource = LancamentoDAO.ReadByTwo(y.Nome, drop_FindCategoria.Text);

                        }

                        if (checkBox_first.IsChecked.Value)
                        {

                            dataGrid.ItemsSource = LancamentoDAO.ReadByValorInter(y.Nome,       Convert.ToDouble(form_PesquisarLancamentoValor1.Text), Convert.ToDouble(form_PesquisarLancamentoValor2.Text));

                        }

                    }

                }
                else
                {

                    dataGrid.ItemsSource = ContaDAO.ReadLancamentos(y.Id);

                }

                title_ContaNome.Content = y.Nome;

                title_Cpf.Content = y.Cpf;

                title_Criacao.Content = Convert.ToString(y.CreationDate);

            }

        }

        private void btn_Sair_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }

        private void btn_CadastrarConta_Click(object sender, RoutedEventArgs e)
        {

            form_CadastrarConta form = new form_CadastrarConta();
            form.ShowDialog();

        }

    }

}
