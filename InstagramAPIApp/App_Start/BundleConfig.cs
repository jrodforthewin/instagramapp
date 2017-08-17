using System.Web;
using System.Web.Optimization;

namespace InstagramAPIApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/Scripts/jqueryOwl").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/owl.carousel.js",
                        "~/Scripts/materialize/materialize.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/angularjs").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-animate.js",
                      "~/Scripts/angular-aria.js",
                      "~/Scripts/angular-messages.js",
                      "~/Scripts/angular-material.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/acqcontroller").Include(
                     "~/Framework/modules/main.js",
                     "~/Framework/configurations/acquisition.config.js",
                     //"~/Framework/services/main.js",
                     //"~/Framework/directives/main.directives.js",
                     "~/Framework/controllers/acq.controller.js"
                     ));

            bundles.Add(new ScriptBundle("~/bundles/maincontroller").Include(
                     "~/Framework/modules/main.js",
                     "~/Framework/configurations/main.config.js",
                     "~/Framework/services/main.js",
                     "~/Framework/directives/main.directives.js",
                     "~/Framework/controllers/main.controller.js"
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/angular-material/angular-material.css"
                      //,
                      //"~/Content/site.css"
                      ));
            bundles.Add(new StyleBundle("~/Content/cssOwl").Include(
                     "~/Content/angular-material/angular-material.css",
                     "~/Content/owl.carousel.css",
                     "~/Content/materialize/css/materialize.css",
                     "~/Content/site.css"
                     ));
        }
    }
}
