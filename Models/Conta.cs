using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanWPF.Models
{

    [Table("Conta")]
    public class Conta
    {

        public Conta()
        {

            CreationDate = DateTime.Now;

        }

        [Key]
        public int Id { get; set; }
        //public string ContaId { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Lancamento> Lancamentos { get; set; }

        public override string ToString() => $" Id:{ this.Id } | Nome:{ this.Nome } | CPF:{ this.Cpf } | Data de criação:{ this.CreationDate } " ;

    }

}
