using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TFTFS.Interfaces;

namespace TFTFS.Models
{
    public class Saque : IValidable
    {
        [Required]
        public int Conta { get; set; }
        [Required]
        [Range(0.01, 9999)]
        public decimal Valor { get; set; }
        
        public Saque() { }
    }
}
