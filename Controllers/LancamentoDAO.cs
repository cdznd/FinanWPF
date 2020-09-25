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

        //By Id
        public static Lancamento ReadById(int id) => _context.Lancamento.Include(Lancamento => Lancamento.Categoria).Include(Lancamento => Lancamento.Conta).FirstOrDefault(x => x.Id == id);
        //By Category name
        public static List<Lancamento> ReadByCategoryName(string nome) => _context.Lancamento.Where(x => x.Categoria.Nome == nome).ToList();
        //By Conta name
        public static List<Lancamento> ReadByContaName(string nome) => _context.Lancamento.Where(x => x.Conta.Nome == nome).ToList();
        //By Conta cpf
        public static List<Lancamento> ReadByContaCPF(string cpf) => _context.Lancamento.Where(x => x.Conta.Cpf == cpf).ToList();
        //By intervalo de valor
        public static List<Lancamento> ReadByValorInter(double value1, double value2) => _context.Lancamento.Where(x => x.Valor > value1 && x.Valor < value2).ToList();

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
