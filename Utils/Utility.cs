using System;
using System.Collections.Generic;
using System.Text;

using FinanWPF.Models;
using FinanWPF.Controllers;

namespace FinanWPF.Utils
{
    public static class Utility
    {
        public static bool verificaCpfExistente(string cpf)
        {

            foreach (Conta y in ContaDAO.Read())
            {

                if (cpf == y.Cpf)
                {

                    return true;

                }

            }

            return false;

        }

        public static List<String> Months()
        {

            List<String> Meses = new List<String>();

            Meses.Add("Janeiro");
            
            Meses.Add("Janeiro");

            Meses.Add("Fevereiro");

            Meses.Add("Março");

            Meses.Add("Abril");

            Meses.Add("Maio");

            Meses.Add("Junho");

            Meses.Add("Julho");

            Meses.Add("Agosto");

            Meses.Add("Setembro");

            Meses.Add("Outubro");

            Meses.Add("Novembro");

            Meses.Add("Dezembro");

            return Meses;

        }

    }
}
