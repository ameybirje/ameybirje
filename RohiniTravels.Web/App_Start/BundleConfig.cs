using System.Web;
using System.Web.Optimization;

namespace RohiniTravels.Web
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
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/igcombocss").Include(
            "~/Content/infragistics.theme.css.css",
            "~/Content/infragistics.css.css",
            "~/Content/igcomboCustom.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/igcomboscript").Include(
                     "~/Scripts/infragistics.core.js.js",
                     "~/Scripts/infragistics.lob.js.js",
                     "~/Scripts/jquery-ui.js"));


        }
    }
}
