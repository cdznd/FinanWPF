using System;
using System.Collections.Generic;
using System.Globalization;
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
using FinanWPF.Views.Crud.DeleteView;
using FinanWPF.Views.Crud.UpdateView;

namespace FinanWPF.Views.Crud.ReadView
{

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

            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");
            drop_FindMes.ItemsSource = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat.MonthNames.Take(12).ToList();

            //drop_FindMes.DisplayMemberPath = "Nome";
            drop_FindMes.SelectedValuePath = "Id";

        }

        private void btn_PesquisarConta_Click(object sender, RoutedEventArgs e)
        {

            List<dynamic> list_Lanc = new List<dynamic>();

            if (drop_FindConta.SelectedItem != null)
            {

                int Id = (int)drop_FindConta.SelectedValue;

                Conta c = ContaDAO.ReadById(Id);

                //Verifica algum dos checkbox esta marcado.
                if (checkBox_Categoria.IsChecked.Value || checkBox_first.IsChecked.Value || checkBox_Mes.IsChecked.Value || checkBox_Dia.IsChecked.Value)
                {

                    //Verifica se os dois estão marcados juntos(categoria e valor)
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
                        
                        //Pesquisar pelo intervalo de valor
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

                        //Pesquisar pela categoria
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

                                label3.Content = "Total gasto na categoria " + CategoriaDAO.ReadById(CategoriaId).Nome + ": R$" + ResumeController.TotalPorCategoria(c.Id, CategoriaId) + " , " + ResumeController.Porcentagem(c.Id,CategoriaId) + "% do Total gasto.";

                            }
                            else
                            {

                                MessageBox.Show("Erro - Filtro invalido - Categoria ", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                            }

                        }

                        //Verifica se o campo de dia e mes estao marcados
                        if (checkBox_Mes.IsChecked.Value && checkBox_Dia.IsChecked.Value)
                        {

                            if (!string.IsNullOrEmpty(drop_FindMes.Text) || !string.IsNullOrEmpty(form_day1.Text) || !string.IsNullOrEmpty(form_day2.Text))
                            {

                                foreach (Lancamento l in LancamentoDAO.ReadByDate(c.Id, drop_FindMes.SelectedIndex + 1, Convert.ToInt32(form_day1.Text), Convert.ToInt32(form_day2.Text)))
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

                                label4.Content = "Total gasto durante o mes de " + drop_FindMes.SelectedItem + " entre os dias " + form_day1.Text + " e " + form_day2.Text + ": R$" + ResumeController.TotalNoMes(c.Id, drop_FindMes.SelectedIndex + 1);

                            }
                            else
                            {

                                MessageBox.Show("Erro - Filtro invalido - Campo vazio ", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Error);

                            }

                        }
                        else
                        {
                            //Pesquisa pelo mes
                            if (checkBox_Mes.IsChecked.Value)
                            {

                                if (!string.IsNullOrEmpty(drop_FindMes.Text))
                                {

                                    //title_ContaNome.Content = drop_FindMes.SelectedValuePath;
                                    foreach (Lancamento l in LancamentoDAO.ReadByMonth(c.Id, drop_FindMes.SelectedIndex + 1))
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

                                    label4.Content = "Total gasto durante o mes de " + drop_FindMes.SelectedItem + " : R$" + ResumeController.TotalNoMes(c.Id, drop_FindMes.SelectedIndex + 1);

                                }
                                else
                                {

                                    MessageBox.Show("Erro - Filtro invalido - Mes ", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Error);

                                }

                            }

                        }

                    }

                }
                else
                {

                    //Pesquisa apenas pelo nome
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

                title_ContaNome.Content = c.Nome;

                title_Cpf.Content = c.Cpf;

                title_Criacao.Content = Convert.ToString(c.CreationDate);

                ContaDataNasc.Content = c.dataNasc;

                label2.Content = "Total gasto na conta de " + c.Nome + ": " + ResumeController.TotalDeGasto(c.Id) + "R$.";

            }
            else
            {

                MessageBox.Show("Erro - Campo vazio", "Contas e lancamentos", MessageBoxButton.OK, MessageBoxImage.Exclamation);

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

        //CHECKBOXXX
        private void checkBox_Mes_Checked(object sender, RoutedEventArgs e)
        {
            
            checkBox_Dia.IsEnabled = true;
            label_dia2.Opacity = 100;
            label_dia1.Opacity = 100;

        }

        private void checkBox_Mes_Unchecked(object sender, RoutedEventArgs e)
        {

            checkBox_Dia.IsEnabled = false;
            label_dia2.Opacity = 50;
            label_dia1.Opacity = 50;

        }

        private void btn_ExcluirConta_Click(object sender, RoutedEventArgs e)
        {

            form_DeleteConta form = new form_DeleteConta();
            form.ShowDialog();

        }

        private void btn_EditarConta_Click(object sender, RoutedEventArgs e)
        {

            form_UpdateConta form = new form_UpdateConta();
            form.ShowDialog();

        }
    }

}
