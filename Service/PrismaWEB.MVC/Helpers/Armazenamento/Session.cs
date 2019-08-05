using System.Web;

namespace ProjetoModeloDDD.MVC.Helpers.Armazenamento
{
    public static class ArmazemSession
    {
        public static object Buscar(string nome)
        {
            return HttpContext.Current.Session[nome];
        }
    }
}