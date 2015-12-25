using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using TP.WebBase.EncryptDecrypt;

namespace TP.WebBase.Mvc
{
    /// <summary>
    /// Site Authorize Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class SiteAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Check if user is authorized on a given permissionKey
        /// </summary>
        private bool IsAuthorized()
        {
            // check license
            DateTime LastTimeStamp;
            DateTime.TryParse(StringCipher.Decrypt(ConfigurationManager.AppSettings["LTS"], "4006"), out LastTimeStamp);


            var licenseKeyEncrypted = ConfigurationManager.AppSettings["LK"];

            LicenseKey = StringCipher.Decrypt(licenseKeyEncrypted, "4006");
            var splitLicenseKey = LicenseKey.Split('|');
            Domain = splitLicenseKey[0];
            MacAddress = splitLicenseKey[1];
            Modules = splitLicenseKey[2].Split(';');
            StartDate = DateTime.ParseExact(splitLicenseKey[3], "dd/MM/yyyy", new CultureInfo("en"));
            ExpiryDate = DateTime.ParseExact(splitLicenseKey[4], "dd/MM/yyyy", new CultureInfo("en"));
            
            //check MAC Address
            var isMACMatched = MatchMACAddress();
            if ((isMACMatched && ExpiryDate >= DateTime.Now && DateTime.Now >= LastTimeStamp) || !IsModule)
            {
                LogLastTimeStamp();
                return true;
            }

            ////check Domain
            //var dir = AppDomain.CurrentDomain.BaseDirectory;
            //if (dir != Domain)
            //{
            //    return false;
            //}

            //object userPermissionSet = HttpContext.Current.Session["UserPermissionSet"];
            //if (userPermissionSet != null)
            //{
            //    string[] userPermissionsSet = (string[]) userPermissionSet;
            //    return (userPermissionsSet.Contains(PermissionKey));
            //}
            return false;
        }
        private static void LogLastTimeStamp()
        {
            //Helps to open the Root level web.config file.
            var webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
            //Modifying the AppKey
            webConfigApp.AppSettings.Settings["LTS"].Value = StringCipher.Encrypt(DateTime.Now.ToString("G"), "4006");
            //Save the Modified settings of AppSettings.
            webConfigApp.Save();
        }
        /// <summary>
        /// Perform the authorization
        /// </summary>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            
            return IsAuthorized();
        }
        /// <summary>
        /// Redirects request to unauthroized request page
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new { area = "", controller = "UnauthorizedRequest", action = "Index" }));
            }
        }
        public string PermissionKey { get; set; }
        public string[] PermissionKeys { get; set; }
        public bool IsModule { get; set; }
        public string LicenseKey { get; set; }
        public string Domain { get; set; }
        public string MacAddress { get; set; }
        public string[] Modules { get; set; }
        public string NoOfUsers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        #region Get MAC Address
        public bool MatchMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            //return nics.Any(adapter =>(adapter.GetPhysicalAddress().ToString() == MacAddress));
            return nics.Any(adapter => adapter.NetworkInterfaceType.ToString() == "Ethernet" && (adapter.GetPhysicalAddress().ToString() == MacAddress));
        }
        #endregion
    }
}