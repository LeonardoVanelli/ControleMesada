using System.Web.Optimization;

namespace ProjetoModeloDDD.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js",
                        "~/Content/bootstrap/js/bootstrap.bundle.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/fontawesome-free-5.4.1-web").Include(
                        "~/Content/fontawesome-free-5.4.1-web/css/all.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/charts").Include(
                        "~/Content/chart.js/Chart.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Content/datatables/jquery.dataTables.js",
                        "~/Content/datatables/dataTables.bootstrap4.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                        "~/Content/bootstrap/css/bootstrap.min.css",
                        "~/Content/datatables/dataTables.bootstrap4.css",
                        "~/Content/css/sb-admin.css",
                        "~/Content/Semantic Ui/semantic.min.css",
                        "~/Content/Site.css"
               ));

            bundles.Add(new StyleBundle("~/bundles/js").Include(
                        "~/Content/Js/InicializacaoTabela.js",
                        "~/Content/jquery-easing/jquery.easing.min.js",
                        "~/Content/js/sb-admin/sb-admin.min.js",
                        "~/Content/Semantic Ui/semantic.min.js",
                        "~/Content/Js/Deletar.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                        //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
                        "~/Scripts/Inputmask/inputmask.js",
                        "~/Scripts/Inputmask/jquery.inputmask.js",
                        "~/Scripts/Inputmask/inputmask.extensions.js",
                        "~/Scripts/Inputmask/inputmask.date.extensions.js",
                        //and other extensions you want to include
                        "~/Scripts/Inputmask/inputmask.numeric.extensions.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}