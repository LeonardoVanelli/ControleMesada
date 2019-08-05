using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.ViewModels.ValidationAttribute
{
    public class ForeignKeyViewAttribute : Attribute 
    {
        public string Tabela { get; set; }
        public string NomeCampo { get; set; }

        public ForeignKeyViewAttribute(string tatela, string campo)
        {

        }
    }
}