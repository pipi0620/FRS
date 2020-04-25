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
    public partial class FRS : System.Web.UI.Page
    {
        private string accountName = "huifengstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "QSetwy+LxLwziFXywuZU+dOOJIp8oSc4ye8WrY6MiYlQ188A8k8qlesPHsIwaxw6/FXBvwpb2hmIrPwRIdhcvw==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     

        protected void Page_Load(object sender, EventArgs e)
        {
            //This is a method where you could add page initialization code.  Left blank because we don't have any now.
        }

        //THE FOLLOWING CODE IS EXECUTED WHEN THE POST BUTTON IS CLICKED
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
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);     //Account and key are already initialized
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient(); //Create an instance of a Cloud QueueClient object to access your queue in the storage
            try
            {



                // Retrieve a reference to a specific queue
                CloudQueue queue = queueClient.GetQueueReference("frsworkerqueue");

                // Create the queue if it doesn't already exist
                queue.CreateIfNotExists();

                //remove any existing messages (just in case)
                queue.Clear();

                // Create a message and add it to the queue.
                string cloudmessage = from.Text+"*"+to.Text+"*"+month.Text+"*"+infant.Text+"*"+child.Text+"*"+adult.Text+"*"+senior.Text;
                CloudQueueMessage message = new CloudQueueMessage(cloudmessage);
                queue.AddMessage(message);

                //Show in the console that some activity is going on in the Web Role
                Debug.WriteLine("Message '" + message + "'stored in Queue");
               
            }
            catch (Exception ee) {; }
            CloudQueue queue1 = queueClient.GetQueueReference("frswebqueue");
            try
            {
                // Create the queue if it doesn't already exist
                queue1.CreateIfNotExists();

                // retrieve the next message
                CloudQueueMessage readMessage = null;
                while(readMessage == null)
                 readMessage = queue1.GetMessage();
                // Display message (populate the textbox with the message you just retrieved.
                TxtMyName.Text = readMessage.AsString;

                //Delete the message just read to avoid reading it over and over again
                queue1.DeleteMessage(queue1.GetMessage());
            }
            catch (Exception ee) { Debug.WriteLine("Problem reading from queue"); }
        }
    }


}