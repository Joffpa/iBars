using System.Web;
using System.Web.Optimization;

namespace ExhibitGrid
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/exhibit").Include(
                        "~/Scripts/angular.min.js",
                        "~/Scripts/Grid/addRowService.js",
                        "~/Scripts/Grid/modelService.js",
                        "~/Scripts/Grid/calcService.js",
                        "~/Scripts/Grid/filters.js",
                        "~/Scripts/math.js",
                        "~/Scripts/hashtable.js",
                        "~/Scripts/jquery.numberformatter-1.2.4.jsmin.js",
                        "~/Scripts/kendo/2016.1.112/kendo.all.min.js",
                        "~/Scripts/Grid/dynamicCellGrid.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css/exhibit").Include(
                      "~/Content/kendo/2016.1.112/kendo.common.min.css",
                      "~/Content/kendo/2016.1.112/kendo.silver.min.css",
                      "~/Content/gridTable.min.css"
                      ));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js",
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

        }
    }
}
