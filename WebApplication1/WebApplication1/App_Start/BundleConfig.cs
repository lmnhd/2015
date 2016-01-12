using System.Web.Optimization;
using RicoGMB.Bundles;
using RicoGMB;

namespace RicoGMB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/vegas/vegas.min.js",
                        "~/Scripts/jquery.scrollTo-2.1.0/jquery.scrollTo.js",
                        "~/Scripts/soc.js-master/soc.min.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
               "~/Scripts/knockout-{version}.js",
               "~/Scripts/knockout.validation.js",
               
               "~/Scripts/dustjs-master/dist/dust-core-0.3.0.min.js",
               "~/Scripts/dustjs-master/dist/dust-full-0.3.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/YouTubePlayer.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/user.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/admin.viewmodel.js",
                "~/Scripts/app/Dust_tpl.js",
                "~/Scripts/app/_run.js"
                ,"~/Scripts/app/Global.js"
                
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
           "~/sass/Site.css"
          ));

            #region Foundation Bundles

            bundles.Add(Foundation.Scripts());
            #endregion
        }
    }
}
