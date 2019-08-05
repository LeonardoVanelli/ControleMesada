using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Html_Helpers
{
    public static class Menu
    {        
        public static IHtmlString Menu_Lateral(this HtmlHelper helper)
        {
            var caminho = "/configuracoes";
            var nome = "Config";

            List<string> file = new List<string>();

            file.Add($"<li class=\"nav-item\" data-toggle=\"tooltip\" data-placement=\"right\" title=\""+ caminho + "\">");
            file.Add("  <a class=\"nav-link\" href=\"/" + caminho + "\">");
            file.Add("      <i class=\"fa fa-fw fa-dashboard\"></i>");
            file.Add("      <span class=\"nav-link-text\">"+nome+"</span>");
            file.Add("  </a>");
            file.Add("</li>");

            var fileEnd = string.Empty;
            foreach (var linha in file)
            {
                fileEnd += linha + System.Environment.NewLine;
            }

            return new MvcHtmlString(fileEnd);
        }

        public static void botoesTeste()
        {

        }
    }
}