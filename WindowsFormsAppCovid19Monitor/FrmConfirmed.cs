using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppCovid19Monitor
{
    public partial class FrmConfirmed : Form
    {

        const string URI = "mongodb://frank:frank123@cluster0-shard-00-00.ivqy7.mongodb.net:27017,cluster0-shard-00-01.ivqy7.mongodb.net:27017,cluster0-shard-00-02.ivqy7.mongodb.net:27017/<dbname>?ssl=true&replicaSet=atlas-ch1jyk-shard-0&authSource=admin&retryWrites=true&w=majority";

        public FrmConfirmed()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmConfirmed_Load(object sender, EventArgs e)
        {
            FillConfirmedChart();
        }

        private void FillConfirmedChart()
        {
            IMongoClient MongoClient = new MongoClient(URI);

            IMongoDatabase MongoDataBase = MongoClient.GetDatabase("Covid");

            var collCovid19Confirmed = MongoDataBase.GetCollection<BsonDocument>("Covid19");
            var listCovidConfirmed = collCovid19Confirmed.Find(f => true).ToEnumerable();

            foreach (BsonDocument bdoc in listCovidConfirmed)
            {
                foreach (BsonElement element in bdoc)
                {
                    if (element.Name.Contains("/") && element.Name != "Province/State" && element.Name != "Country/Region")
                    {
                        chartConfirmed.Series["Confirmed"].Points.AddXY(element.Name, element.Value.ToString());
                    }
                }
            }
            chartConfirmed.Titles.Add("Confirmed global covid-19 cases between Jan and Oct of 2020");
        }
    }
}
