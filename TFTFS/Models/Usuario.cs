using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFTFS.Models
{
    public class Usuario
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; } = 0;

        public Usuario() { }

        public Usuario(string nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
