using System.Web;
using System.Web.Optimization;

namespace HardstyleFestivals
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //hier alle libraries die voor elke pagina beschikbaar zijn
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js"));

            ////jqueryval zorgt voor client side validation van forms.
            ////helaas werkt het niet, vanwege globalization problemen. Hij laat geen comma toe (en de server laat geen punt toe)
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      ));


            //Voeg hier de css files toe die in elke pgina gebruikt moeten worden. 
            //in de header van _layout.cshtml wordt dit gezet: @Styles.Render("~/Content/css") 
            //Daarmee worden alle onderstaande css files gelinkt in de header van _layout.cshtml
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/Site.css"));
        }
    }
}
