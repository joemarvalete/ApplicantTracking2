using System.Web;
using System.Web.Optimization;

namespace ApplicantTracking
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/jquery.signalR-2.2.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                        "~/Scripts/fastclick.js",
                        "~/Scripts/nprogress.js",
                        "~/Scripts/bootstrap-progressbar.js",
                        "~/Scripts/pnotify.js",
                        "~/Scripts/pnotify.buttons.js",
                        "~/Scripts/pnotify.nonblock.js",
                        "~/Scripts/custom.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/nprogress.css",
                      "~/Content/bootstrap-progressbar-3.3.4.css",
                      "~/Content/pnotify.css",
                      "~/Content/pnotify.nonblock.css",
                      "~/Content/pnotify.buttons.css",
                      "~/Content/custom.css"));
        }
    }
}
