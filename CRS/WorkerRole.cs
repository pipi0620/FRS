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

namespace CRS
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private string accountName = "huifengstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "QSetwy+LxLwziFXywuZU+dOOJIp8oSc4ye8WrY6MiYlQ188A8k8qlesPHsIwaxw6/FXBvwpb2hmIrPwRIdhcvw==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        private StorageCredentials creds;
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;
        private CloudQueue inqueue, outqueue;
        private CloudQueueMessage inMessage, outMessage;

        //the following method is called at the start of the worker role to get instances of incoming and outgoing queues 
        private void initQueue()
        {
            // Retrieve storage account from connection string
            //  CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            //      CloudConfigurationManager.GetSetting("Setting2"));

            creds = new StorageCredentials(accountName, accountKey);
            storageAccount = new CloudStorageAccount(creds, useHttps: true);

            // Create the queue client
            queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a queue
            inqueue = queueClient.GetQueueReference("crsworkerqueue");

            // Create the queue if it doesn't already exist
            inqueue.CreateIfNotExists();

            // Retrieve a reference to a queue
            outqueue = queueClient.GetQueueReference("crswebqueue");

            // Create the queue if it doesn't already exist
            outqueue.CreateIfNotExists();
        }
      
        public override void Run()
        {
            Trace.TraceInformation("CRS is running");

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

            Trace.TraceInformation("CRS has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("CRS is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("CRS has stopped");
        }
        public int id1 = 0, id2 = 0;
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            initQueue();        //call the queue initialization method
            while (!cancellationToken.IsCancellationRequested)
            {
                // Async dequeue (read) the message
                inMessage = await inqueue.GetMessageAsync();    //not an optimal way to retrieve a message from a queue, but works
                if (inMessage != null)
                {
                    Console.WriteLine("Retrieved message with content '{0}'", inMessage.AsString);  //Show the received message in the development console

                    //convert the message to string, parse it, perform your business logic here, etc.
                    string s = inMessage.AsString;
                    string[] str = s.Split('*');
                    int num = int.Parse(str[0]);
                    int year = int.Parse(str[1]);
                    int age = int.Parse(str[2]);

                    int a = 0;
                    int b = 0;
                    if (num <= 5)
                        a = 600 * (year - 2010);
                    else
                        a = 900 * (year - 2010);
                    if (age < 45)
                        b = (50 - age) * 200;
                    else
                        b = (age - 40) * 225;
                    int sum = a + b;
                    if (str[3] == "D")
                        sum = Convert.ToInt32(Convert.ToDouble(sum) * 1.2);

                    string bigs = sum.ToString();      //This is the message (response) the worker sends to the web role
                    Trace.TraceInformation("***** Worker Received " + sum.ToString());
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


