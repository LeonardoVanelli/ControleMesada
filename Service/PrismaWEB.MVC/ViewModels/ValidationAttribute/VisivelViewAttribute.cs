using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Attribute
{
    class VisivelViewAttribute : ValidationAttribute
    {
        public string Campos { get; set; }

        public override bool IsValid(object value)
        {
            return true;
        }
    }    
}
