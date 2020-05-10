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
    public partial class CreateMoteType : Form
    {
        public CreateMoteType()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNode creNode = CreateNode.GetInstance();
            creNode.ShowDialog();
        }
    }
}
