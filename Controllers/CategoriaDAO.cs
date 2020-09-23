using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using FinanWPF.Models;

namespace FinanWPF.Controllers
{
    public class CategoriaDAO
    {

        private static Context _context = new Context();

        //CREATE
        public static void Create(Categoria c)
        {

            _context.Categoria.Add(c);  

            _context.SaveChanges();

            Console.WriteLine("Adicionado com sucesso ;) ");

        }

        //READ

        //Return Categoria table and convert to List
        public static List<Categoria> Read() => _context.Categoria.ToList();

        //Return Categoria by ID
        public static Categoria ReadById(int id) => _context.Categoria.Find(id);

        //Expressão lambda
        //Percorre toda a tabela de Categoria e compara o nome com o parametro fornecido.
        public static Categoria ReadByName(string nome) => _context.Categoria.FirstOrDefault(x => x.Nome == nome);

        //UPDATE
        public static void Update(Categoria p)
        {

            _context.Categoria.Update(p);
            _context.SaveChanges();

            Console.WriteLine("Atualizado com sucesso ;) ");

        }

        //DELETE
        public static void Delete(Categoria p)
        {

            _context.Categoria.Remove(p);
            _context.SaveChanges();

            Console.WriteLine("Excluido com sucesso ;) ");

        }

    }

}
