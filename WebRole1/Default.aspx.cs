using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure;
using System.Diagnostics;

namespace WebRole1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string accountName = "huifengstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "QSetwy+LxLwziFXywuZU+dOOJIp8oSc4ye8WrY6MiYlQ188A8k8qlesPHsIwaxw6/FXBvwpb2hmIrPwRIdhcvw==";
        protected void BtnPost_Click(object sender, EventArgs e)
        {
            /*      USE THIS CODE INSTEAD OF YOU WANT TO USE YOUR LOCAL STORAGE EMULATOR.  YOU GET CONNECTION STRING AND SETTINGS FROM THE web.config FILE
                        // Retrieve storage account from connection string
                        //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                        //    CloudConfigurationManager.GetSetting("Setting1"));

                        //CloudStorageAccount storageAccount = CloudStorageAccount.FromConfigurationSetting("StorageConnectionString");
                        //.Parse(                CloudConfigurationManager.GetSetting("StorageConnectionString"));
                        // Create the queue client
            */

            //Note: the key above is not a real key.  Do not try it!
             if(service1.Items[0].Selected&&service1.Items[1].Selected)
             {
                 Response.Redirect("HRS1.aspx");
             }
            if (service1.Items[0].Selected && !service1.Items[1].Selected)
                Response.Redirect("HRS2.aspx");
            if (!service1.Items[0].Selected && service1.Items[1].Selected)
                Response.Redirect("CRS.aspx");
            if (!service1.Items[0].Selected && !service1.Items[1].Selected)
             {
                 Response.Redirect("FRS.aspx");
             }
             
        }
        
    }
}