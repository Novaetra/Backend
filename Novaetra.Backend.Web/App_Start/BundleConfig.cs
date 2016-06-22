using System.Web.Optimization;

namespace Novaetra.Backend.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            var cssRewrite = new CssRewriteUrlTransform();

            //VENDOR RESOURCES

            //~/Bundles/App/vendor/css
            var venderStyles = new StyleBundle("~/Bundles/App/vendor/css")
                .Include("~/Content/themes/base/all.css", cssRewrite)
                .Include("~/Content/bootstrap-cosmo.min.css", cssRewrite)
                .Include("~/Content/toastr.min.css")
                .Include("~/Scripts/sweetalert/sweet-alert.css")
                .Include("~/Content/flags/famfamfam-flags.css", cssRewrite)
                .Include("~/Content/font-awesome.min.css", cssRewrite);
            bundles.Add(venderStyles);

            //~/Bundles/App/vendor/js
            var venderScripts = new ScriptBundle("~/Bundles/App/vendor/js")
                .Include(
                    "~/Abp/Framework/scripts/utils/ie10fix.js",
                    "~/Scripts/json2.min.js",

                    "~/Scripts/modernizr-2.8.3.js",

                    "~/Scripts/jquery-2.1.4.min.js",
                    "~/Scripts/jquery-ui-1.11.4.min.js",

                    "~/Scripts/bootstrap.min.js",

                    "~/Scripts/moment-with-locales.min.js",
                    "~/Scripts/jquery.blockUI.js",
                    "~/Scripts/toastr.min.js",
                    "~/Scripts/sweetalert/sweet-alert.min.js",
                    "~/Scripts/others/spinjs/spin.js",
                    "~/Scripts/others/spinjs/jquery.spin.js",

                    "~/Scripts/angular.min.js",
                    "~/Scripts/angular-animate.min.js",
                    "~/Scripts/angular-sanitize.min.js",
                    "~/Scripts/angular-ui-router.min.js",
                    "~/Scripts/angular-ui/ui-bootstrap.min.js",
                    "~/Scripts/angular-ui/ui-bootstrap-tpls.min.js",
                    "~/Scripts/angular-ui/ui-utils.min.js",
                    "~/Scripts/angular-messages.min.js",

                    "~/Abp/Framework/scripts/abp.js",
                    "~/Abp/Framework/scripts/libs/abp.jquery.js",
                    "~/Abp/Framework/scripts/libs/abp.toastr.js",
                    "~/Abp/Framework/scripts/libs/abp.blockUI.js",
                    "~/Abp/Framework/scripts/libs/abp.spin.js",
                    "~/Abp/Framework/scripts/libs/abp.sweet-alert.js",
                    "~/Abp/Framework/scripts/libs/angularjs/abp.ng.js"
                );
            bundles.Add(venderScripts);

            //APPLICATION RESOURCES

            //~/Bundles/App/Main/css
            var appStyles = new StyleBundle("~/Bundles/App/Main/css")
                .IncludeDirectory("~/App/Main", "*.css", true);
            bundles.Add(appStyles);

            //~/Bundles/App/Main/js
            var appScripts = new ScriptBundle("~/Bundles/App/Main/js")
                .IncludeDirectory("~/App/Main", "*.js", true);
            bundles.Add(appScripts);

            bundles.Add(new PartialsBundle("~/Bundles/App/partials.js", "app")
                .IncludeDirectory("~/App/Main/partials", "*.html", true));

#if DEBUG
            foreach (var registeredBundle in bundles.GetRegisteredBundles())
            {
                if (registeredBundle is ScriptBundle)
                    registeredBundle.Transforms.Add(new RemoveMinifyTransform());
            }
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}