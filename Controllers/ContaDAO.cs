using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using FinanWPF.Models;

namespace FinanWPF.Controllers
{
    public class ContaDAO
    {

        private static Context _context = new Context();
        //Starting context var
        //private static Context _context = new Context();

        //CREATE
        public static void Create(Conta c)
        {

            _context.Conta.Add(c);

            _context.SaveChanges();

            Console.WriteLine("Adicionado com sucesso ;) ");

        }

        //READ

        //All
        public static List<Conta> Read() => _context.Conta.ToList();
        //ById
        public static Conta ReadById(int id) => _context.Conta.Find(id);
        //ByName
        public static Conta ReadByName(string nome) => _context.Conta.FirstOrDefault(x => x.Nome == nome);
        //ByCpf
        public static Conta ReadByCpf(string cpf) => _context.Conta.FirstOrDefault(x => x.Cpf == cpf);

        //UPDATE
        public static void Update(Conta p)
        {

            _context.Conta.Update(p);
            _context.SaveChanges();

            Console.WriteLine("Atualizado com sucesso ;) ");

        }

        //DELETE
        public static void Delete(Conta c)
        {

            _context.Conta.Remove(c);
            _context.SaveChanges();

            Console.WriteLine("Excluido com sucesso ;) ");

        }

    }

}
