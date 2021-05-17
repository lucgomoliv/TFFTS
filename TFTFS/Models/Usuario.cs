using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFTFS.Models
{
    public class Usuario
    {
        public int Conta { get; set; } = 0;
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [Range(0, 999.9)]
        public decimal Valor { get; set; } = 0;

        public Usuario() { }

        public Usuario(int conta, string nome, decimal valor)
        {
            if (nome.Length > 100)
                throw new ArgumentOutOfRangeException();
            Conta = conta;
            Nome = nome;
            Valor = valor;
        }
    }
}
