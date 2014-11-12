using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;
using Microsoft.SharePoint.Administration;
using System.Collections.Generic;
using System.Linq;

namespace RemoveDefaultMobileRedirect.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("e14f2f88-77eb-497b-94c9-33e2d2047b82")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite spsite = (SPSite)properties.Feature.Parent;
            SPWebApplication webApp = spsite.WebApplication;

            SPWebConfigModification configMod = new SPWebConfigModification
            {
                Name = "browserCaps",
                Owner = "RemoveDefaultMobileRedirect",
                Path = "configuration/system.web",
                Sequence = 0,
                Type = 0,
                Value = "<browserCaps><result type=\"System.Web.Mobile.MobileCapabilities, System.Web.Mobile, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a\" /><filter>isMobileDevice=false</filter></browserCaps>"
            };

            webApp.WebConfigModifications.Add(configMod);
            webApp.Update();
            webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite spsite = (SPSite)properties.Feature.Parent;
            SPWebApplication webApp = spsite.WebApplication;

            List<SPWebConfigModification> mods = webApp.WebConfigModifications.Where(m => m.Owner == "RemoveDefaultMobileRedirect").ToList();

            foreach (SPWebConfigModification mod in mods)
            {
                webApp.WebConfigModifications.Remove(mod);
            }
            webApp.Update();
            webApp.Farm.Services.GetValue<SPWebService>().ApplyWebConfigModifications();
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
