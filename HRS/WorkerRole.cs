using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;

namespace HRS
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        private string accountName = "lichstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "sg8SddKgyVvJI55jv2PiP61w54QZSs1NcihujjRfQK+SCPu4xt80wyH41ovnk6D/D8A/35p89HdBgDfQaxuGWw==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     

        private CloudQueue inqueue, outqueue;
        private CloudQueueMessage inMessage, outMessage;

        //the following method is called at the start of the worker role to get instances of incoming and outgoing queues 
        private void initQueue()
        {
            // Retrieve storage account from connection string
            //  CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //      CloudConfigurationManager.GetSetting("Setting2"));

            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

            // Create the queue client
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            inqueue = queueClient.GetQueueReference("hrsworkerqueue");

            // Create the queue if it doesn't already exist
            inqueue.CreateIfNotExists();

            // Retrieve a reference to a queue
            outqueue = queueClient.GetQueueReference("hrswebqueue");

            // Create the queue if it doesn't already exist
            outqueue.CreateIfNotExists();
        }

        public override void Run()
        {
            Trace.TraceInformation("HRS is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            catch (Exception e) {; }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("HRS has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("HRS is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("HRS has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            initQueue();        //call the queue initialization method
            while (!cancellationToken.IsCancellationRequested)
            {
                // Async dequeue (read) the message
                inMessage = await inqueue.GetMessageAsync();    //not an optimal way to retrieve a message from a queue, but works
                //Console.WriteLine("Retrieved message with content '{0}'", inMessage.AsString);  //Show the received message in the development console
                if (inMessage != null)
                {
                    //convert the message to string, parse it, perform your business logic here, etc.
                    string s = inMessage.AsString;
                    string[] str = s.Split('*');
                    int numtraveller = int.Parse(str[0]);
                    int numnights = int.Parse(str[1]);
                    int numsenior = int.Parse(str[2]);
                    int price = 0;
                    if (str[4] == "Single")
                    {
                        price = ((numtraveller - numsenior) * 600 + numsenior * 300) * numnights;
                    }
                    else
                    {
                        price = ((numtraveller - numsenior) * 450 + numsenior * 225) * numnights;
                    }

                    string bigs = price.ToString();      //This is the message (response) the worker sends to the web role
                    Trace.TraceInformation("***** Worker Received " + bigs);

                    // Async delete the message
                    await inqueue.DeleteMessageAsync(inMessage);

                    // Create a message and add it to the queue.
                    outMessage = new CloudQueueMessage(bigs);
                    outqueue.AddMessage(outMessage);
                }
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}