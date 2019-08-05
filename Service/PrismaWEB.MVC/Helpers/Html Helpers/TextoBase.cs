using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoModeloDDD.MVC.Html_Helpers
{
    public class TextoBase
    {
        public List<string> Linhas { get; set; }

        public TextoBase()
        {
            Linhas = new List<string>();
        }

        public void AdicionaLinha(string linha)
        {            
            Linhas.Add(linha);
        }

        public string MontaTexto()
        {
            var texto = string.Empty;
            foreach (var linha in Linhas)
            {
                texto += linha + Environment.NewLine;
            }
            Linhas.Clear();
            return texto;
        }
    }
}