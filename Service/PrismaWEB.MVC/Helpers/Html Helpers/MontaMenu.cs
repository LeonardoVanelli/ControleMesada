using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoModeloDDD.MVC.Controllers;

namespace ProjetoModeloDDD.MVC.Html_Helpers
{
    public static class MontaMenu
    {
        private static IList<string> Linhas = new List<string>();

        private static void AdicionaLinha(string linha)
        {
            Linhas.Add(linha);
        }

        private static string MontaTexto()
        {
            var texto = "";
            foreach (var linha in Linhas)
            {
                texto += linha + Environment.NewLine;
            }
            Linhas.Clear();
            return texto;
        }

        public static IHtmlString Botao(this HtmlHelper Html, string caminho, string nome)
        {
            

            AdicionaLinha($"<li class=\"nav-item\" data-toggle=\"tooltip\" data-placement=\"right\" title=\"" + caminho + "\">");
            AdicionaLinha("  <a class=\"nav-link\" href=\"" + caminho + "\">");
            AdicionaLinha("      <i class=\"fa fa-fw fa-dashboard\"></i>");
            AdicionaLinha("      <span class=\"nav-link-text\">" + nome + "</span>");
            AdicionaLinha("  </a>");
            AdicionaLinha("</li>");

            return new MvcHtmlString(MontaTexto());
        }

        public static string DropDown(string nome)
        {
            AdicionaLinha("< li class=\"nav-item\" data-toggle=\"tooltip\" data-placement=\"right\" title=\"Components\">");
            AdicionaLinha("        <a class=\"nav-link nav-link-collapse collapsed\" data-toggle=\"collapse\" href=\"#collapseComponents\" daAta-parent=\"#exampleAccordion\">");
            AdicionaLinha("            <i class=\"fa fa-fw fa-wrench\"></i>");
            AdicionaLinha("            <span class=\"nav-link-text\">"+nome+"</span>");
            AdicionaLinha("        </a>");
            AdicionaLinha("         <ul class=\"sidenav-second-level collapse\" id=\"collapseComponents\">");
            //AdicionaLinha("            <li>");
            //AdicionaLinha("                < a href=\"~/Content/Layout/navbar.html\"> Navbar </a>");
            //AdicionaLinha("            </li>");
            //AdicionaLinha("            <li>");
            //AdicionaLinha("                <a href=\"~/Content/Layout/cards.html\">Cards</a>");
            //AdicionaLinha("            </li>");
            AdicionaLinha("        </ul>");
            AdicionaLinha("    </li>");

            return MontaTexto();
        }

        public static string DropDropDown(string nome)
        {
            AdicionaLinha("<a class=\"nav-link-collapse collapsed\" data-toggle=\"collapse\" href=\"#collapseMulti2\">Third Level</a>");
            AdicionaLinha("<ul class=\"sidenav-third-level collapse\" id=\"collapseMulti2\">");
            AdicionaLinha("");
            AdicionaLinha("</ul>");

            return MontaTexto();
        }

        public static string BotaoDropDown(string caminho, string nome)
        {
            AdicionaLinha("            <li>");
            AdicionaLinha("                <a href=\""+caminho+"\">"+nome+"</a>");
            AdicionaLinha("            </li>");

            return MontaTexto();
        }
    }
}