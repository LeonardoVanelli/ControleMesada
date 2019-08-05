using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Html_Helpers
{
    public static class Index
    {
        public static IHtmlString Deletar(this HtmlHelper helper, int id)
        {
            IList<string> linhas = new List<string>();
            linhas.Add("<a id=\""+id+"\" onclick=\"abrirModalDeletar(this)\" href=\"#\" data-toggle=\"tooltip\" title=\"Deletar\">");
            linhas.Add("     <span style=\"margin-right:0px;\" class=\"red\">");
            linhas.Add("          <i class=\"fa fa-minus font-white\" aria-hidden=\"true\"></i>");
            linhas.Add("     </span>");
            linhas.Add("</a>");

            var textos = "";
            foreach (var linha in linhas)
            {
                textos += linha + Environment.NewLine;
            }
            return new MvcHtmlString(textos);       
        }

        public static IHtmlString Deletar(this HtmlHelper helper, int id, string nomeItem)
        {
            IList<string> linhas = new List<string>();
            linhas.Add("<a id=\""+id+"\" onclick=\"abrirModalDeletar(this, '"+nomeItem+"' )\" href=\"#\" data-toggle=\"tooltip\" title=\"Deletar\">");
            linhas.Add("     <span style=\"margin-right:0px;\" class=\"red\">");
            linhas.Add("          <i class=\"fa fa-minus font-white\" aria-hidden=\"true\"></i>");
            linhas.Add("     </span>");
            linhas.Add("</a>");

            var textos = "";
            foreach (var linha in linhas)
            {
                textos += linha + Environment.NewLine;
            }
            return new MvcHtmlString(textos);
        }

        public static IHtmlString Editar(this HtmlHelper helper, int id, string url)
        {
            var texto =
                "<a href=\""+url+"\" data-toggle=\"tooltip\" title=\"Editar\">" +
                "    <span style=\"margin-right:0px;\" class=\"blue\">" +
                "        <i class=\"fa fa-pencil\" aria-hidden=\"true\"></i>" +
                "    </span>" +
                "</a>";

            return new MvcHtmlString(texto);
        }

    }
}