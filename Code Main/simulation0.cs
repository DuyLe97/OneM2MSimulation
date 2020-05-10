using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation2
{
    public partial class simulation0 : Form
    {
        public simulation0()
        {
            InitializeComponent();
        }

        private void panel_simu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void createNewMoteTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMoteType creMoteType = new CreateMoteType();
            creMoteType.ShowDialog();
            this.Close();
        }
    }
}
