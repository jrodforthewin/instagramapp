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

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/angularjs").Include(
                      "~/bower_components/angular/angular.js"
                      ));
            bundles.Add(new ScriptBundle("~/Scripts/angularFramework").Include(
                        "~/Scripts/Framework/modules.js",
                        //"~/Scripts/Framework/configuration.js",
                        "~/Scripts/Framework/directives.js",
                        "~/Scripts/Framework/services.js",
                        "~/Scripts/Framework/maincontroller.js"
                      ));

            bundles.Add(new ScriptBundle("~/Scripts/angularMaterialjs").Include(
                "~/bower_components/angular-animate/angular-animate.js",
                "~/bower_components/angular-aria/angular-aria.js",
                "~/bower_components/angular-messages/angular-messages.js", 
                "~/bower_components/angular-material/angular-material.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bower_components/angular-material/angular-material.css"
                      //,
                      //"~/Content/site.css"
                      ));
        }
    }
}
