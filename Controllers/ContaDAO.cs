using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using FinanWPF.Models;

namespace FinanWPF.Controllers
{
    public class ContaDAO
    {

        //private static Context _context = new Context();
        private static Context _context = SingleContext.GetInstance();

        //CREATE
        public static void Create(Conta c)
        {

            _context.Conta.Add(c);

            _context.SaveChanges();

        }

        //READ

        //All
        public static List<Conta> Read() => _context.Conta.ToList();

        //ById => Retorna objeto
        public static Conta ReadById(int id) => _context.Conta.Find(id);

        //ByName
        public static List<Conta> ReadByName(string nome) => _context.Conta.Where(x => x.Nome == nome).ToList();

        //ByCpf => Retorna uma lista com 1 objeto,   funcao nao utilizada
        public static List<Conta> ReadByCpf(string cpf) => _context.Conta.Where(x => x.Cpf == cpf).ToList();

        //Read lançamentos de uma conta
        public static List<Lancamento> ReadLancamentos(int id) => _context.Conta.Find(id).Lancamentos.ToList();

        //UPDATE
        public static void Update(Conta p)
        {

            _context.Conta.Update(p);
            _context.SaveChanges();

        }

        //DELETE
        public static void Delete(Conta c)
        {

            _context.Conta.Remove(c);
            _context.SaveChanges();

        }

    }

}
