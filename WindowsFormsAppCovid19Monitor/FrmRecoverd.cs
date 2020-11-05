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

            //Collection Covid Deaths: CovidDeaths
            //Collection CovidR Recoverd: CovidRecovered
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
