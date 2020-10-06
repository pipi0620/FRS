using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole1
{
    public partial class PS : System.Web.UI.Page
    {
        private string accountName = "lichstorage";      // YOUR AZURE STORAGE ACCOUNT_NAME";             
        private string accountKey = "sg8SddKgyVvJI55jv2PiP61w54QZSs1NcihujjRfQK+SCPu4xt80wyH41ovnk6D/D8A/35p89HdBgDfQaxuGWw==";
        private string connection = "mongodb://bunnychen:nuAeTYeuH43uvX8EQIoxrAzG0GJJ9FgrJ0wLZ9I7P6GfJjyKumejbqsFqiAC6ZtFy8TeRR8j70A0ZycMHAWzow==@bunnychen.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@bunnychen@";

        private StorageCredentials creds;
        private CloudStorageAccount storageAccount;
        private CloudQueueClient queueClient;
        private CloudQueue queue1, queue2;
        private SqlConnection conn;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection("Data Source=LAPTOP-LIHGC18C;Initial Catalog=lichdatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected void BtnPost_Click(object sender, EventArgs e)
        {
            creds = new StorageCredentials(accountName, accountKey);
            storageAccount = new CloudStorageAccount(creds, useHttps: true);

            queueClient = storageAccount.CreateCloudQueueClient();

            queue1 = queueClient.GetQueueReference("frswebqueue");
            queue2 = queueClient.GetQueueReference("hrswebqueue");

            queue1.CreateIfNotExists();
            queue2.CreateIfNotExists();

            CloudQueueMessage readmes1 = queue1.GetMessage();
            CloudQueueMessage readmes2 = queue2.GetMessage();

            double final1 = 0, final2 = 0, final;

            if (readmes1 != null)
            {
                final1 = double.Parse(readmes1.AsString);
            }
            if (readmes2 != null)
            {
                final2 = double.Parse(readmes2.AsString);
            }

            queue1.Clear();
            queue2.Clear();

            final = final1 + final2;
            TxtPrice.Text = final.ToString();


        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
            string holdername = TxtName.Text;
            string card = TxtCardNumber.Text;
            string pass = passport.Text;
            int balance = 10000;
            ////mongo client setup
            MongoClient dbClient = new MongoClient(connection);
            var database = dbClient.GetDatabase("PaymentService");
            var cl = database.GetCollection<BsonDocument>("cardlist");
            var tr = database.GetCollection<BsonDocument>("Transaction");

            var doc1 = new BsonDocument
            {
                {"name", holdername },
                {"passport", pass },
                {"balance", balance },

            };
            cl.InsertOneAsync(doc1);

            var doc2 = new BsonDocument
            {
                {"name", holdername },
                {"cardnumber", card },

            };
            tr.InsertOneAsync(doc2);

            //insert into dbo.flight
            conn.Open();
            cmd = new SqlCommand(@"INSERT INTO dbo.Flights (Passenger_name, Passport_number, Flight_number, Air_fare, Departure_date)
                                    VALUES (@passenger, @passport, @flight, @price , @date)", conn);
            cmd.Parameters.Add(new SqlParameter("passenger", TxtName.Text));
            cmd.Parameters.Add(new SqlParameter("passport", passport.Text));
           
            cmd.Parameters.Add(new SqlParameter("flight", "SAS11"));
            cmd.Parameters.Add(new SqlParameter("price", TxtPrice.Text));
            cmd.Parameters.Add(new SqlParameter("date", "2020-7-26"));
            cmd.ExecuteNonQuery();
            conn.Close();


            Response.Redirect("Report.aspx");
        }
    }
}