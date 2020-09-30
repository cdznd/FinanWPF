using System;
using System.Collections.Generic;
using System.Linq;
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
using FinanWPF.Utils;

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

            drop_FindConta.ItemsSource = ContaDAO.Read();

            drop_FindConta.DisplayMemberPath = "Nome";
            drop_FindConta.SelectedValuePath = "Id";

            drop_FindCategoria.ItemsSource = CategoriaDAO.Read();

            drop_FindCategoria.DisplayMemberPath = "Nome";
            drop_FindCategoria.SelectedValuePath = "Id";

        }



        private void btn_PesquisarConta_Click(object sender, RoutedEventArgs e)
        {

            List<dynamic> list_Lanc = new List<dynamic>();

            if (drop_FindConta.SelectedItem != null)
            {

                int Id = (int)drop_FindConta.SelectedValue;

                Conta c = ContaDAO.ReadById(Id);

                //Verifica se um dos checkbox esta marcado
                if (checkBox_Categoria.IsChecked.Value || checkBox_first.IsChecked.Value)
                {

                    //Verifica se os dois estão marcados juntos
                    if (checkBox_Categoria.IsChecked.Value && checkBox_first.IsChecked.Value)
                    {

                        int CategoriaId = (int)drop_FindCategoria.SelectedValue;

                        if (!string.IsNullOrEmpty(drop_FindCategoria.Text) && !string.IsNullOrEmpty(form_PesquisarLancamentoValor1.Text) && !string.IsNullOrEmpty(form_PesquisarLancamentoValor2.Text))
                        {

                            foreach(Lancamento l in LancamentoDAO.ReadByAll(c.Id, CategoriaId , Convert.ToDouble(form_PesquisarLancamentoValor1.Text), Convert.ToDouble(form_PesquisarLancamentoValor2.Text))){


                                dynamic Lancamentos = new
                                {

                                    Nome = l.Conta.Nome,
                                    Categoria = l.Categoria.Nome,
                                    Valor = l.Valor,
                                    Data = l.CreationDate

                                };

                                list_Lanc.Add(Lancamentos);

                            }

                            dataGrid.ItemsSource = list_Lanc;

                            dataGrid.Items.Refresh();

                        }
                        else
                        {

                            MessageBox.Show("Erro - Filtro invalido", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                        }

                    }
                    else
                    {

                        if (checkBox_first.IsChecked.Value)
                        {

                            if (!string.IsNullOrEmpty(form_PesquisarLancamentoValor1.Text) && !string.IsNullOrEmpty(form_PesquisarLancamentoValor2.Text))
                            {

                                //MessageBox.Show("Erro - Filtro invalido - Intervalo de valores", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                foreach(Lancamento l in LancamentoDAO.ReadByValorInter(c.Id, Convert.ToDouble(form_PesquisarLancamentoValor1.Text), Convert.ToDouble(form_PesquisarLancamentoValor2.Text))){

                                    dynamic Lancamentos = new
                                    {

                                        Nome = l.Conta.Nome,
                                        Categoria = l.Categoria.Nome,
                                        Valor = l.Valor,
                                        Data = l.CreationDate

                                    };

                                    list_Lanc.Add(Lancamentos);

                                }

                                dataGrid.ItemsSource = list_Lanc;

                                dataGrid.Items.Refresh();

                            }
                            else
                            {

                                MessageBox.Show("Erro - Filtro invalido - Intervalo de valores", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }

                        }

                        if (checkBox_Categoria.IsChecked.Value)
                        {
                            int CategoriaId = (int)drop_FindCategoria.SelectedValue;

                            if (!string.IsNullOrEmpty(drop_FindCategoria.Text))
                            {

                                foreach(Lancamento l in LancamentoDAO.ReadByTwo(c.Id, CategoriaId))
                                {

                                    dynamic Lancamentos = new
                                    {

                                        Nome = l.Conta.Nome,
                                        Categoria = l.Categoria.Nome,
                                        Valor = l.Valor,
                                        Data = l.CreationDate

                                    };

                                    list_Lanc.Add(Lancamentos);

                                }

                                dataGrid.ItemsSource = list_Lanc;

                                dataGrid.Items.Refresh();

                                label3.Content = "Total gasto na categoria " + CategoriaDAO.ReadById(CategoriaId).Nome + ": " + ResumeController.TotalPorCategoria(c.Id, CategoriaId) + "R$, " + ResumeController.Porcentagem(c.Id,CategoriaId) + "% do Total gasto.";



                            }
                            else
                            {

                                MessageBox.Show("Erro - Filtro invalido - Categoria ", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }

                        }

                        if (checkBox_Mes.IsChecked.Value)
                        {

                            //MessageBox.Show("" + (drop_FindMes.SelectedValuePath) ,"" ,MessageBoxButton.OK , MessageBoxImage.Exclamation);

                            title_ContaNome.Content = drop_FindMes.SelectedValuePath;
                        }

                    }

                }
                else
                {

                    //dataGrid.ItemsSource = ContaDAO.ReadLancamentos(c.Id);
                    foreach(Lancamento l in LancamentoDAO.ReadByContaId(c.Id))
                    {

                        dynamic Lancamentos = new
                        {

                            Nome = l.Conta.Nome,
                            Categoria = l.Categoria.Nome,
                            Valor = l.Valor,
                            Data = l.CreationDate

                        };

                        list_Lanc.Add(Lancamentos);

                    }

                    dataGrid.ItemsSource = list_Lanc;

                    dataGrid.Items.Refresh();

                }

                //title_ContaNome.Content = c.Nome;

                title_Cpf.Content = c.Cpf;

                title_Criacao.Content = Convert.ToString(c.CreationDate);

                label2.Content = "Total gasto na conta de " + c.Nome + ": " + ResumeController.TotalDeGasto(c.Id) + "R$.";
            }
            else
            {

                MessageBox.Show("Erro - Campo invalido", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);

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
