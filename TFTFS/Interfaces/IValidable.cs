using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TFTFS.Interfaces
{
    public class IValidable
    {
        //Código retirado do stack overflow https://stackoverflow.com/a/4331964 e adaptado
        public bool Validate()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this, null, null), null, true);
        }
    }
}
