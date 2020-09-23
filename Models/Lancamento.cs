using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanWPF.Models
{
    [Table("Lancamento")]
    public class Lancamento
    {

        public Lancamento()
        {

            CreationDate = DateTime.Now;

        }

        [Key]
        public int Id { get; set; }
        //public string LancamentoId { get; set; }
        
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("Conta")]
        public int ContaId { get; set; }
        public virtual Conta Conta { get; set; }

        public double Valor { get; set; }

        public DateTime CreationDate { get; set; }

        public override String ToString() => $" Id:{ this.Id } | Titular da conta:{ Conta.Nome } | Categoria:{ Categoria.Nome } | Valor:{ this.Valor } | Data de criação:{ this.CreationDate } " ;

    }

}
