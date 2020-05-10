using simulation02;
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
    public partial class delete : Form
    {
        private static delete Instance;
        public delete()
        {
            InitializeComponent();
        }
        public static delete GetInstance()
        {
            if (Instance == null)
            {
                Instance = new delete();
            }
            return Instance;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Simulation simmu = Simulation.getInstance();
            Node node = Node.GetInstance();
            MessageBox.Show(node.Text);
            //simmu.deleteNode();
        }
    }
}
