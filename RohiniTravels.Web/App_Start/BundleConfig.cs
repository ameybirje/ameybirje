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

            bundles.Add(new StyleBundle("~/Content/RohiniTravelsCss").Include(
                     "~/Content/open-iconic-bootstrap.min.css",
                     "~/Content/animate.css",
                     "~/Content/owl.carousel.min.css",
                     "~/Content/owl.theme.default.min.css",
                     "~/Content/magnific-popup.css",
                     "~/Content/aos.css",
                     "~/Content/ionicons.min.css",
                     "~/Content/flaticon.css",
                     "~/Content/icomoon.min.css",
                     "~/Content/style.min.css",
                     "~/Content/fixed.css"));

            bundles.Add(new StyleBundle("~/bundles/igcombocss").Include(
            "~/Content/infragistics.theme.css.css",
            "~/Content/infragistics.css.css",
            "~/Content/igcomboCustom.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/igcomboscript").Include(
                     "~/Scripts/infragistics.core.js.js",
                     "~/Scripts/infragistics.lob.js.js",
                     "~/Scripts/jquery-ui.js"));


            bundles.Add(new ScriptBundle("~/bundles/RohiniTravelsJs").Include(
                   "~/Scripts/jquery.min.js",
                   "~/Scripts/jquery-migrate-3.0.1.min.js",
                   "~/Scripts/popper.min.js",
                   "~/Scripts/bootstrap.min.js",
                   "~/Scripts/jquery.easing.1.3.js",
                   "~/Scripts/jquery.waypoints.min.js",
                   "~/Scripts/jquery.stellar.min.js",
                   "~/Scripts/owl.carousel.min.js",
                   "~/Scripts/jquery.magnific-popup.min.js",
                   "~/Scripts/aos.js",
                   "~/Scripts/jquery.animateNumber.min.js",
                   "~/Scripts/scrollax.min.js",
                   "~/Scripts/google-map.js",
                   "~/Scripts/main.js"));

        }
    }
}
