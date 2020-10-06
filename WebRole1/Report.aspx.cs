using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole1
{
    public partial class Report : System.Web.UI.Page
    {
        private string connection = "mongodb://bunnychen:nuAeTYeuH43uvX8EQIoxrAzG0GJJ9FgrJ0wLZ9I7P6GfJjyKumejbqsFqiAC6ZtFy8TeRR8j70A0ZycMHAWzow==@bunnychen.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@bunnychen@";
        protected void Page_Load(object sender, EventArgs e)
        {
            MongoClient dbClient = new MongoClient(connection);
            var database = dbClient.GetDatabase("PaymentService");
            var data1 = database.GetCollection<BsonDocument>("cardlist");
            var data2 = database.GetCollection<BsonDocument>("Transaction");

            var list = data1.Find(new BsonDocument()).FirstOrDefault();
            var transaction = data2.Find(new BsonDocument()).FirstOrDefault();

            CardList.Text = list.ToString();
            Transactions.Text = transaction.ToString();
           

        }
    }
}