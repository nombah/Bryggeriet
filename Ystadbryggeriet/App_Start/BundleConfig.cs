using System.Web;
using System.Web.Optimization;

namespace Ystadbryggeriet
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
                      "~/Scripts/jquery-1.10.1.min.js",
                      "~/Scripts/scripts.js",
                      "~/Scripts/googleMaps.js",
                      "~/Scripts/jquery.flexslider-min.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/toucheffects.js",
                      "~/Scripts/jquery.countTo.js",
                      "~/Scripts/waypoints.min.js",
                      "~/Scripts/preloader.js",
                      "~/Scripts/jquery.bxslider.min.js",
                      "~/Scripts/jquery.colio.min.js",
                      "~/Scripts/jquery.scrollTo-1.4.3.1-min.js",
                      "~/Scripts/jquery.localScroll.min.js",
                      "~/Scripts/jquery.cycle.all.min.js",
                      "~/Scripts/jquery.easing.1.3.js",
                      "~/Scripts/jquery.maximage.min.js",
                      "~/Scripts/jquery.contactForm.js",
                       "~/Scripts/moment.min.js",
                      "~/Scripts/fullcalendar.js",
                      "~/Scripts/fullcalendar.min.js",
                      "~/Scripts/gcal.js",
                      "~/Scripts/lang-all.js",
                      "~/ckeditor/skins/ckeditor.js"));

            bundles.Add(new StyleBundle("~/Styles/css").Include(
                      "~/Content/css/bootstrap.css",            
                      "~/Content/css/bootstrap-theme.css",
                      "~/Content/css/felxslider.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/jquery.bxslider.css",
                      "~/Content/css/colio.css",
                      "~/Content/css/jquery.maximage.css",
                      "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/boostrap.theme.css",
                      "~/Content/fullcalendar.css",
                      "~/Content/fullcalendar.min.css",
                      "~/Content/site.css"
                      ));
        }
    }
}
