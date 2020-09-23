using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanWPF.Models
{

    [Table("Categoria")]
    public class Categoria
    {

        public Categoria()
        {

            CreationDate = DateTime.Now;
           
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Lancamento> Lancamento { get; set; }

        public override String ToString() => $" Id:{ this.Id } | Nome:{ this.Nome } | Data de criação:{ this.CreationDate }";

    }
}

