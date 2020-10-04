using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using FinanWPF.Models;

namespace FinanWPF.Controllers
{
    public class CategoriaDAO
    {

        private static Context _context = SingleContext.GetInstance();

        //CREATE
        public static void Create(Categoria c)
        {

            _context.Categoria.Add(c);  

            _context.SaveChanges();

        }

        //READ

        //All
        public static List<Categoria> Read() => _context.Categoria.ToList();

        //ById => Retorna um objeto.
        public static Categoria ReadById(int id) => _context.Categoria.Find(id);

        //ByName
        public static List<Categoria> ReadByName(string nome) => _context.Categoria.Where(x => x.Nome == nome).ToList();

        //Retorna todos lançamentos de uma categoria
        public static List<Lancamento> ReadLancamentos(int id) => _context.Categoria.Find(id).Lancamento.ToList();
        
        //UPDATE
        public static void Update(Categoria p)
        {

            _context.Categoria.Update(p);
            _context.SaveChanges();

        }

        //DELETE
        public static void Delete(Categoria p)
        {

            _context.Categoria.Remove(p);
            _context.SaveChanges();

        }

    }

}
