using System;
using System.Collections.Generic;
using System.Text;

using FinanWPF.Models;
using System.Linq;

namespace FinanWPF.Controllers
{
    public static class ResumeController
    {
        
        //retorna o total de totos os lancamentos de um conta
        //returning 11189.98
        public static double TotalDeGasto(string nome)
        {

            double valorTotal = 0;

            foreach(Lancamento x in LancamentoDAO.ReadByContaName(nome))
            {

                valorTotal += x.Valor;

            }

            return valorTotal;

        }

        //Retorna o total de lançamento de uma conta de categoria
        public static double TotalPorCategoria(string categoria,string nome)
        {

            double valorTotal = 0;

            foreach (Lancamento l in LancamentoDAO.ReadByTwo(nome, categoria)){

                valorTotal += l.Valor;

            }

            return  valorTotal;

        }

        public static double Porcentagem(string categoria, string nome)
        {

            return Math.Round(100 * TotalPorCategoria(categoria, nome) / TotalDeGasto(nome), 2);

        }

    }
}
