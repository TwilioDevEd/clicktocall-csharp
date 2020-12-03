using System.Web;
using System.Web.Optimization;

namespace ClickToCall.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                      "~/Scripts/lib/dist/js/jquery.js",
                      "~/Scripts/lib/dist/js/bootstrap.js",
                      "~/Scripts/intl-phone/js/intlTelInput.js",
                      "~/Scripts/intl-phone/libphonenumber/build/utils.js",
                      "~/Scripts/app.js"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Scripts/lib/dist/css/bootstrap.css",
                      "~/Content/intl-phone/css/intlTelInput.css",
                      "~/Content/site.css"));
        }
    }
}
