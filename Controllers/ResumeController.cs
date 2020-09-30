using System;
using System.Collections.Generic;
using System.Text;

using FinanWPF.Models;
using System.Linq;

namespace FinanWPF.Controllers
{
    public static class ResumeController
    {
        
        public static double TotalDeGasto(int Id)
        {

            double valorTotal = 0;

            foreach(Lancamento x in LancamentoDAO.ReadByContaId(Id))
            {

                valorTotal += x.Valor;

            }

            return Math.Round(valorTotal,2);

        }

        //Retorna o total de lançamento de uma conta de categoria
        
        public static double TotalPorCategoria(int ContaId , int CategoriaId)
        {

            double valorTotal = 0;

            foreach (Lancamento l in LancamentoDAO.ReadByTwo(ContaId, CategoriaId)){

                valorTotal += l.Valor;

            }

            return  Math.Round(valorTotal,2);

        }

        public static double Porcentagem(int ContaId, int CategoriaId)
        {

            return Math.Round(100 * TotalPorCategoria(ContaId, CategoriaId) / TotalDeGasto(ContaId), 2);

        }
        
    }
}
