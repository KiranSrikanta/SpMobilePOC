using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Security;

namespace McMobileSolution.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("44cea979-597b-444d-a79a-254c3ae22882")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            SPSite spsite = (SPSite)properties.Feature.Parent;
            SPWeb spweb = spsite.RootWeb;
            Uri masterPageUri = new Uri(spweb.Url + "/_catalogs/masterpage/MobileRedirect.master");
            spweb.MasterUrl = masterPageUri.AbsolutePath;
            spweb.CustomMasterUrl = masterPageUri.AbsolutePath;
            spweb.Update();
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            SPSite spsite = (SPSite)properties.Feature.Parent;
            SPWeb spweb = spsite.RootWeb;
            Uri masterPageUri = new Uri(spweb.Url + "/_catalogs/masterpage/v4.master");
            spweb.MasterUrl = masterPageUri.AbsolutePath;
            spweb.CustomMasterUrl = masterPageUri.AbsolutePath;
            spweb.Update();
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
