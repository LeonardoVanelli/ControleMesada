using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.Atributos
{
    public static class T4Helpers
    {
        public static bool IsRequired(string viewDataTypeName, string propertyName)
        {
            bool IsRequired = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (RequiredAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(RequiredAttribute));
                return richText != null;
            }

            return IsRequired;
        }
    }
}