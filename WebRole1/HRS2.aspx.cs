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
    public partial class HRS2 : System.Web.UI.Page
    {
        private string accountName = "lichstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "sg8SddKgyVvJI55jv2PiP61w54QZSs1NcihujjRfQK+SCPu4xt80wyH41ovnk6D/D8A/35p89HdBgDfQaxuGWw==";

        protected void BtnContinue_Click(object sender, EventArgs e)
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
            try
            {

                StorageCredentials creds = new StorageCredentials(accountName, accountKey);     //Account and key are already initialized
                CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

                CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient(); //Create an instance of a Cloud QueueClient object to access your queue in the storage

                // Retrieve a reference to a specific queue
                CloudQueue queue = queueClient.GetQueueReference("hrsworkerqueue");

                // Create the queue if it doesn't already exist
                queue.CreateIfNotExists();

                //remove any existing messages (just in case)
                queue.Clear();

                string cloudmessage = TxtNumTraveller.Text + "*" + TxtNumNight.Text + "*" + TxtNumSenior.Text + "*" + TxtGuestName.Text + "*";
                if (RadioButtonList1.Items[0].Selected)
                {
                    cloudmessage += "Single";
                }
                else
                {
                    cloudmessage += "Double";
                }
                // Create a message and add it to the queue.
                CloudQueueMessage message = new CloudQueueMessage(cloudmessage);
                queue.AddMessage(message);

                //Show in the console that some activity is going on in the Web Role
                Debug.WriteLine("Message '" + message + "'stored in Queue");
            }
            catch (Exception ee) {; }

            Response.Redirect("FRS.aspx");

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

    }
}