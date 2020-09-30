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
        //By Category Id
        public static List<Lancamento> ReadByCategoryId(int Id) => _context.Lancamento.Where(x => x.CategoriaId == Id).ToList();


        //By Conta Id
        public static List<Lancamento> ReadByContaId(int Id) => _context.Lancamento.Where(x => x.ContaId == Id).ToList();
        //By Conta name
        public static List<Lancamento> ReadByContaName(string nome) => _context.Lancamento.Where(x => x.Conta.Nome == nome).ToList();
        //By Conta cpf
        public static List<Lancamento> ReadByContaCPF(string cpf) => _context.Lancamento.Where(x => x.Conta.Cpf == cpf).ToList();

        public static List<Lancamento> ReadByMonth(int date) => _context.Lancamento.Where(x => x.CreationDate.Month == date).ToList();

        public static List<Lancamento> ReadByDayIntervalo(int day1, int day2) => _context.Lancamento.Where(x => x.CreationDate.Day > day1 && x.CreationDate.Day < day2).ToList();
        
        //var ByMonthGrouped = new TestEntities().Objects.GroupBy(O => new { O.date.Year, O.date.Month }).ToList();

        //By intervalo de valor
        //public static List<Lancamento> ReadByValorInter(double value1, double value2) => _context.Lancamento.Where(x => x.Valor > value1 && x.Valor < value2).ToList();
        public static List<Lancamento> ReadByValorInter(int ContaId, double value1, double value2) => _context.Lancamento.Where(x => x.Valor > value1 && x.Valor < value2 && x.Conta.Id == ContaId).ToList();
        //By categoria and nome
        public static List<Lancamento> ReadByTwo(int ContaId, int CategoriaId ) => _context.Lancamento.Where(x => x.Conta.Id == ContaId && x.Categoria.Id == CategoriaId).ToList();
        //by categoria, conta e valor
        //public static List<Lancamento> ReadByAll(string nome, string categoria, double value1, double value2 ) => _context.Lancamento.Where(x => x.Conta.Nome == nome && x.Categoria.Nome == categoria && x.Valor > value1 && x.Valor < value2).ToList();

        public static List<Lancamento> ReadByAll(int ContaId, int CategoriaId, double value1, double value2) => _context.Lancamento.Where(x => x.Conta.Id == ContaId && x.Categoria.Id == CategoriaId && x.Valor > value1 && x.Valor < value2).ToList();

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
