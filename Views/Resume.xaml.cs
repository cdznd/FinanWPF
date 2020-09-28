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
    /// Interaction logic for Resume.xaml
    /// </summary>
    public partial class Resume : Window
    {
        public Resume()
        {
            InitializeComponent();

            List<double> results = new List<double>();


            foreach (Lancamento y in LancamentoDAO.ReadByContaName("Fabricio Gabriel")){

                results.Add(ResumeController.Porcentagem(y.Categoria.Nome, "Fabricio Gabriel")); 

            }

            listBox.ItemsSource = results;

        }

        
    }
}
