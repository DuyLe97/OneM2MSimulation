using simulation02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation2
{
    public partial class CreateNode : Form
    {
        public static int numberIN = 1;
        public static int numberMN = 10;
        public static int numberAE = 0;
        private static CreateNode Instance;
        public CreateNode()
        {
            InitializeComponent();

            number_in.Text = numberIN.ToString();
            number_mn.Text = numberMN.ToString();
            number_ae.Text = numberAE.ToString();

            this.AcceptButton = this.button_ok;
            this.CancelButton = this.button_cancel;
        }

        public static CreateNode GetInstance()
        {
            if (Instance == null)
            {
                Instance = new CreateNode();
            }
            return Instance;
        }

        public static void CreateData()
        {
            for (int i = 0; i < numberIN; i++)
            {
                String dirPath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i;
                // Kiểm tra xem đường dẫn thư mục tồn tại không.
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
                CopyFolder(@"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse", @"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i);
            }
            for (int i = 0; i < numberMN; i++)
            {
                String dirPath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i;
                // Kiểm tra xem đường dẫn thư mục tồn tại không.
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
                CopyFolder(@"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse", @"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i);
            }
        }
        public void button_ok_Click(object sender, EventArgs e)
        {
            numberIN = int.Parse(number_in.Text);
            numberMN = int.Parse(number_mn.Text);
            numberAE = int.Parse(number_ae.Text);

            CreateData();

            this.Close();
            
            Simulation simu = Simulation.getInstance();
            simu.ShowDialog();
        }
        static public void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))

                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)
            {

                string name = Path.GetFileName(file);

                string dest = Path.Combine(destFolder, name);
                if (!File.Exists(dest))
                {
                    File.Copy(file, dest);
                }
            }

            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)
            {

                string name = Path.GetFileName(folder);

                string dest = Path.Combine(destFolder, name);

                CopyFolder(folder, dest);

            }

        }

    }
}
