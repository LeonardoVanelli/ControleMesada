using ProjetoModeloDDD.MVC.ViewModels.Sistema;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoModeloDDD.MVC.Html_Helpers
{
    public static class UsuarioLogado
    {
        public static IHtmlString NomeUsuario(this HtmlHelper helper, SCadastroUsuarioLogadoViewModel cadastro)
        {
            if (cadastro.Pessoa.Apelido == "")
                return new MvcHtmlString(cadastro.Pessoa.Nome);
            return new MvcHtmlString(cadastro.Pessoa.Apelido);
        }

        public static IHtmlString SiglaUsuario(this HtmlHelper helper, SCadastroUsuarioLogadoViewModel cadastro)
        {
            var nomes = cadastro.Pessoa.Nome.Split(' ');
            var sigla = nomes.First()[0].ToString() + nomes.Last()[0].ToString();

            return new MvcHtmlString(sigla);
        }

        public static IHtmlString PapeisUsuarioLogado(this HtmlHelper helper, SCadastroUsuarioLogadoViewModel cadastro)
        {
            var texto = "";
            foreach (var papel in cadastro.Papeis)
            {
                if (texto != "")
                    texto += Environment.NewLine;
                texto += $"            <a class=\"nav-link dropdown-item\" style=\"color: black\">" +
                         "                 <i class=\"fa fa-fw fas fa-asterisk\"></i>" + papel.Nome +
                         "            </a>";
                
            }

            return new MvcHtmlString(texto);
        }
    }
}