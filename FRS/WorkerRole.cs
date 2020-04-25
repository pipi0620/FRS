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

namespace FRS
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private static double EARTH_RADIUS = 6378.137;
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        private string accountName = "huifengstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "QSetwy+LxLwziFXywuZU+dOOJIp8oSc4ye8WrY6MiYlQ188A8k8qlesPHsIwaxw6/FXBvwpb2hmIrPwRIdhcvw==";     // zPie75n + Wcbwr19brs3LNC05ldiv4sDAPLB6ib4 / eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw ==";     // zPie75n+Wcbwr19bferrs3LNCdiv4sDAPsdLB6ib4/eVLsYBc20iSULTvRfVlmI2MXBC2SOf1MCaDHv2cihuu4fw";   // Write your Azure storage account key here "YOUR_ACCOUNT_KEY";     
        private StorageCredentials creds;
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;
        private CloudQueue inqueue,que1,que2, outqueue;
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

            que1 = queueClient.GetQueueReference("hrswebqueque");
            que1.CreateIfNotExists();
            que2 = queueClient.GetQueueReference("crswebqueque");
            que2.CreateIfNotExists();
            // Retrieve a reference to a queue
            inqueue = queueClient.GetQueueReference("frsworkerqueue");

            // Create the queue if it doesn't already exist
            inqueue.CreateIfNotExists();

            // Retrieve a reference to a queue
            outqueue = queueClient.GetQueueReference("frswebqueue");

            // Create the queue if it doesn't already exist
            outqueue.CreateIfNotExists();
        }
        public static double getDistance(double long1, double lat1, double long2, double lat2)
        {
            double a, b, d, sa2, sb2;
            lat1 = rad(lat1);
            lat2 = rad(lat2);
            a = lat1 - lat2;
            b = rad(long1 - long2);

            sa2 = Math.Sin(a / 2.0);
            sb2 = Math.Sin(b / 2.0);
            d = 2 * EARTH_RADIUS
                    * Math.Asin(Math.Sqrt(sa2 * sa2 + Math.Cos(lat1)
                    * Math.Cos(lat2) * sb2 * sb2));
            return d;
        }
        public override void Run()
        {
            Trace.TraceInformation("WorkerRole1 is running");

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

            Trace.TraceInformation("WorkerRole1 has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRole1 is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("WorkerRole1 has stopped");
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
                    Airport airport = Airport.getInstance();
                    for (int i = 0; i < 5; i++)
                    {
                        if (str[0] == airport.code[i])
                        {
                            id1 = i;
                        }
                        if (str[1] == airport.code[i])
                        {
                            id2 = i;
                        }
                    }
                    double dis = getDistance(airport.y[id1], airport.x[id1], airport.y[id2], airport.x[id2]);
                    double pri1 = airport.rate[id1] * dis * Double.Parse(str[3]) * (1.0 - 0.9);
                    double pri2 = airport.rate[id1] * dis * Double.Parse(str[4]) * (1.0 - 0.33);
                    double pri3 = airport.rate[id1] * dis * Double.Parse(str[5]);
                    double pri4 = airport.rate[id1] * dis * Double.Parse(str[6]) * (1.0 - 0.25);
                    int sum = Convert.ToInt32(pri1 + pri2 + pri3 + pri4);
                    if (str[2] == "1" || str[2] == "12")
                        sum *= 15;
                    else sum *= 10;
                    int allsum = 0;
                    String s1 = que1.GetMessage().AsString;
                    String s2 = que2.GetMessage().AsString;
                    int sum1 = 0;
                    int sum2 = 0;
                    if (s1 != null)
                        sum1 += int.Parse(s1);
                    if (s2 != null)
                        sum2 += int.Parse(s2);
                    allsum = sum + sum1 + sum2;
                    string bigs = allsum.ToString();      //This is the message (response) the worker sends to the web role
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
    public class Airport
    {
        private static Airport instance = new Airport();
        public string[] code = { "STO", "CPH", "CDG", "LHR", "FRA" };
        public double[] x = { 59.6519, 55.6181, 49.0097, 31.5497, 50.1167 };
        public double[] y = { 17.9186, 12.6561, 2.5478, 74.3436, 8.6833 };
        public double[] rate = { 0.234, 0.2554, 0.2255, 0.2300, 0.2400 };
        private Airport() { }
        public static Airport getInstance()
        {
            if (instance == null)
                instance = new Airport();
            return instance;
        }
    }
}

