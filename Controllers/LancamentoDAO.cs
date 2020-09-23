using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using FinanWPF.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

namespace FinanWPF.Controllers
{
    class LancamentoDAO
    {

        private static Context _context = new Context();

        //CREATE
        public static void Create(Lancamento c)
        {

            _context.Lancamento.Add(c);

            _context.SaveChanges();

            Console.WriteLine("Adicionado com sucesso ;) ");

        }

        //READ




        //All
        public static List<Lancamento> Read() => _context.Lancamento.Include(Lancamento => Lancamento.Categoria).Include(Lancamento => Lancamento.Conta).ToList();


        public static Lancamento ReadById(int id) => _context.Lancamento.Find(id);
        //ByName
        //public static Lancamento ReadByName(string nome) => _context.Lancamento.FirstOrDefault(x => x.Nome == nome);
        //ByCpf
        //public static Lancamento ReadByCpf(string cpf) => _context.Lancamento.FirstOrDefault(x => x.Cpf == cpf);

        //UPDATE
        public static void Update(Lancamento p)
        {

            _context.Lancamento.Update(p);
            _context.SaveChanges();

            Console.WriteLine("Atualizado com sucesso ;) ");

        }

        //DELETE
        public static void Delete(Lancamento c)
        {

            _context.Lancamento.Remove(c);
            _context.SaveChanges();

            Console.WriteLine("Excluido com sucesso ;) ");

        }

    }
}
