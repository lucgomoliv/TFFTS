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
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(this, null, null);
            Validator.TryValidateObject(this, ctx, validationResults, true);
            return validationResults.Count() == 0;
        }
    }
}
