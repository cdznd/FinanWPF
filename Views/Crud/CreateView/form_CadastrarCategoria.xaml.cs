﻿using System;
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

    public partial class form_CadastrarCategoria : Window
    {
        public form_CadastrarCategoria()
        {

            InitializeComponent();

            clearForm();

        }

        public void clearForm()
        {

            input_CategoriaNome.Clear();

            input_CategoriaNome.Focus();

        }

        //CREATE
        private void btn_CadastrarCategoria_Click(object sender, RoutedEventArgs e)
        {

            if (!(input_CategoriaNome.Text == ""))
            {

                if (!(Utils.Utility.verificarCategoriaExistente(input_CategoriaNome.Text)))
                {

                    Categoria c = new Categoria();

                    c.Nome = input_CategoriaNome.Text;

                    CategoriaDAO.Create(c);

                    MessageBox.Show("Categoria cadastrada com sucesso", "Cadastrar Categoria", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    clearForm();

                }
                else
                {

                    MessageBox.Show("Erro : Falha ao cadastrar, Categoria ja existe. ", "Cadastrar Categoria", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
            else
            {

                MessageBox.Show("Erro : Falha ao cadastrar, campo vazio ", "Cadastrar Categoria", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btn_voltar_Click(object sender, RoutedEventArgs e)
        {

            Close();

        }
    }
}
