using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFTFS.Models
{
    public class Metodos : Usuario
    {
        List<Usuario> us = new List<Usuario>();
        public decimal ValorInserido { get; set; } = 0;
        public Metodos() { }

        public Metodos(decimal valorInserido)
        {
            ValorInserido = valorInserido;
        }

        public bool Deposito(decimal valor, string nome) {
            var NomeUsuario = us.Where(x => x.Nome.Equals(nome));
            if (NomeUsuario.Count() == 1) {
                foreach (var item in NomeUsuario)
                {
                    item.Valor += valor;
                }
                return true;
            }
          return false;
        }
        public bool Saque(decimal valor, string nome)
        {
            var NomeUsuario = us.Where(x => x.Nome.Equals(nome));
            if (NomeUsuario.Count() == 1) { 
                foreach (var item in NomeUsuario)
                {
                    item.Valor -= valor;
                }
            }
            return false;
        }
    }
}
