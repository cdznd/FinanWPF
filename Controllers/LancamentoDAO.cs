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

        //private static Context _context = new Context();
        private static Context _context = SingleContext.GetInstance();

        //CREATE
        public static void Create(Lancamento c)
        {

            _context.Lancamento.Add(c);

            _context.SaveChanges();

        }

        //READ

        //All
        public static List<Lancamento> Read() => _context.Lancamento.Include(Lancamento => Lancamento.Categoria).Include(Lancamento => Lancamento.Conta).ToList();

        //By Id
        public static Lancamento ReadById(int id) => _context.Lancamento.Include(Lancamento => Lancamento.Categoria).Include(Lancamento => Lancamento.Conta).FirstOrDefault(x => x.Id == id);
        
        //By Category name => Retorna uma lista de lancamentos que pertencem a mesma categoria.
        public static List<Lancamento> ReadByCategoryName(string nome) => _context.Lancamento.Where(x => x.Categoria.Nome == nome).ToList();

        //By Category Id =>  Retorna uma lista de lancamentos que pertencem a mesma categoria.
        public static List<Lancamento> ReadByCategoryId(int Id) => _context.Lancamento.Where(x => x.CategoriaId == Id).ToList();


        //By Conta Id
        public static List<Lancamento> ReadByContaId(int Id) => _context.Lancamento.Where(x => x.ContaId == Id).ToList();
        //By Conta name
        public static List<Lancamento> ReadByContaName(string nome) => _context.Lancamento.Where(x => x.Conta.Nome == nome).ToList();
        //By Conta cpf
        public static List<Lancamento> ReadByContaCPF(string cpf) => _context.Lancamento.Where(x => x.Conta.Cpf == cpf).ToList();

        //Fixed
        //Retorna os lançamentos de um determinado mes
        public static List<Lancamento> ReadByMonth(int Id, int date) => _context.Lancamento.Where(x => x.ContaId == Id && x.CreationDate.Month == date).ToList();
        //Retorna lancamentos de um itervalo de dias
        public static List<Lancamento> ReadByDayIntervalo(int Id,int day1, int day2) => _context.Lancamento.Where(x => x.ContaId== Id && x.CreationDate.Day > day1 && x.CreationDate.Day < day2).ToList();
        //Retorna lancamentos de um mes e intervalo de dias.
        public static List<Lancamento> ReadByDate(int Id,int month, int day1, int day2) => _context.Lancamento.Where(x => x.ContaId == Id && x.CreationDate.Month == month && x.CreationDate.Day > day1 && x.CreationDate.Day < day2).ToList();

        //XXXXXXXXXXXXXXXXXXXXX
        //FILTROS

        //By intervalo de valor
        public static List<Lancamento> ReadByValorInter(int ContaId, double value1, double value2) => _context.Lancamento.Where(x => x.Valor > value1 && x.Valor < value2 && x.Conta.Id == ContaId).ToList();

        //By categoria and nome
        public static List<Lancamento> ReadByTwo(int ContaId, int CategoriaId ) => _context.Lancamento.Where(x => x.Conta.Id == ContaId && x.Categoria.Id == CategoriaId).ToList();

        //By categoria, nome, e intervalo de valor
        public static List<Lancamento> ReadByAll(int ContaId, int CategoriaId, double value1, double value2) => _context.Lancamento.Where(x => x.Conta.Id == ContaId && x.Categoria.Id == CategoriaId && x.Valor > value1 && x.Valor < value2).ToList();

        //UPDATE
        public static void Update(Lancamento p)
        {

            _context.Lancamento.Update(p);
            _context.SaveChanges();

        }

        //DELETE
        public static void Delete(Lancamento c)
        {

            _context.Lancamento.Remove(c);
            _context.SaveChanges();

        }

    }
}
