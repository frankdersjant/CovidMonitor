using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppCovid19Monitor
{
    public partial class FrmMain : Form
    {

        public FrmMain()
        {
            InitializeComponent();
        }

        private void confirmedCasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfirmed frmConfirmed = new FrmConfirmed();
            frmConfirmed.Show();
        }

        private void recoveredToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRecoverd frmRecoverd = new FrmRecoverd();
            frmRecoverd.Show();
        }
    }
}
