using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsAppCovid19Monitor
{

    public partial class FrmRecoverd : Form
    {
        const string URI = "mongodb://frank:frank123@cluster0-shard-00-00.ivqy7.mongodb.net:27017,cluster0-shard-00-01.ivqy7.mongodb.net:27017,cluster0-shard-00-02.ivqy7.mongodb.net:27017/<dbname>?ssl=true&replicaSet=atlas-ch1jyk-shard-0&authSource=admin&retryWrites=true&w=majority";

        public FrmRecoverd()
        {
            InitializeComponent();
        }

        private void FilllChartRecoverd()
        {
            IMongoClient MongoClient = new MongoClient(URI);

            IMongoDatabase MongoDataBase = MongoClient.GetDatabase("Covid");

            var deathsCollection = MongoDataBase.GetCollection<BsonDocument>("CovidDeaths");
            var deathsList = deathsCollection.Find(f => true).ToEnumerable();

            var recoveredCollection = MongoDataBase.GetCollection<BsonDocument>("CovidRecovered");
            var recoveredList = recoveredCollection.Find(f => true).ToEnumerable();

            chartDandR.Series["Deaths"].Color = Color.Black;
            chartDandR.Series["Recovered"].Color = Color.Red;
            chartDandR.ChartAreas[0].AxisY.IsLogarithmic = true;

            foreach (BsonDocument bdocdeaths in deathsList)
            {
                foreach (BsonElement element in bdocdeaths)
                {
                    if (element.Name.Contains("/") && element.Name != "Province/State" && element.Name != "Country/Region" && double.Parse(element.Value.ToString()) > 0)
                    {
                        chartDandR.Series["Deaths"].Points.AddXY(element.Name.ToString(), double.Parse(element.Value.ToString()));
                    }
                }
            }

            foreach (BsonDocument b in recoveredList)
            {
                foreach (BsonElement element in b)
                {
                    if (element.Name.Contains("/") && element.Name != "Province/State" && element.Name != "Country/Region" && double.Parse(element.Value.ToString()) > 0)
                    {
                        chartDandR.Series["Recovered"].Points.AddXY(element.Name.ToString(), double.Parse(element.Value.ToString()));
                    }
                }
            }

            chartDandR.ChartAreas[0].AxisY.IsLogarithmic = true;
            chartDandR.Titles.Add("Covid-19 Deaths and Recovered between Jan to Oct 2020");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRecoverd_Load(object sender, EventArgs e)
        {
            FilllChartRecoverd();
        }
    }
}
