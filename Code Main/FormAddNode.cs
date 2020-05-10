using simulation02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation2
{
    public partial class FormAddNode : Form
    {
        public static int numberIN = 0;
        public static int numberMN = 0;
        public static int numberAE = 0;

        public int R = 100;//range of MN
        public static String[] MN_PORT = new String[Simulation.ListNodeMN.Count];
        public static String[] MN_NAME = new String[Simulation.ListNodeMN.Count];
        public static String[] MN_ID = new String[Simulation.ListNodeMN.Count];
        public static String[] MN_IP = new String[Simulation.ListNodeMN.Count];

        public String filePath = "";
        public FormAddNode()
        {

            InitializeComponent();
            if (number_in.Text != "" && number_in.Text != "" && number_in.Text != "")
            {
                numberIN = Convert.ToInt32(number_in.Text);
                numberMN = Convert.ToInt32(number_mn.Text);
                numberAE = Convert.ToInt32(number_ae.Text);
            }
        }
        private static FormAddNode Instance;
        public static FormAddNode GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FormAddNode();
            }
            return Instance;
        }
        public static void CreateData()
        {
            for (int i = Simulation.ListNodeIN.Count; i < numberIN + Simulation.ListNodeIN.Count; i++)
            {
                String dirPath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i;
                // Kiểm tra xem đường dẫn thư mục tồn tại không.
                if (Directory.Exists(dirPath))
                {
                    Directory.Delete(dirPath, true);
                }
                CopyFolder(@"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse", @"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i);
            }
            for (int i = Simulation.ListNodeMN.Count; i < numberMN + Simulation.ListNodeMN.Count; i++)
            {
                String dirPath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i;
                // Kiểm tra xem đường dẫn thư mục tồn tại không.
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
                CopyFolder(@"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse", @"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i);
            }
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

        private void number_in_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_ok_Click_1(object sender, EventArgs e)
        {
            k++;
            numberIN = int.Parse(number_in.Text);
            numberMN = int.Parse(number_mn.Text);
            numberAE = int.Parse(number_ae.Text);
            CreateData();
            
            conectNode();
            String FilePath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/run-new-all-" + k + ".bat";
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = FilePath; // vd: "D:"
            prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            prc.Start();
            this.Close();
        }
        int k = 0;

        CreateNode creNode = CreateNode.GetInstance();
        InfoNode infoNode = InfoNode.GetInstance();
        String remoteCsePort_string = "org.eclipse.om2m.remoteCsePort_string=";
        String cseBaseAddress_string = "org.eclipse.om2m.cseBaseAddress_string=";
        String cseBaseName = "org.eclipse.om2m.cseBaseName=";
        String cseBaseId = "org.eclipse.om2m.cseBaseId=";
        String remoteCseId_string = "org.eclipse.om2m.remoteCseId_string=";
        String remoteCseName_string = "org.eclipse.om2m.remoteCseName_string=";
        String cseMNPort = "org.eclipse.equinox.http.jetty.http.port=";
        public void conectNode()    // Thêm đường dẫn các file .bat vào file all-bat để khởi động all in, mn
        {
            Console.WriteLine(numberMN + Simulation.ListNodeIN.Count + "-111");
            for (int i = Simulation.ListNodeIN.Count; i < numberIN + Simulation.ListNodeIN.Count; i++)
            {
                Console.WriteLine("-----------" + numberIN + Simulation.ListNodeIN.Count + "------");
                filePath = filePath + "\n start /D \"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i + "/x86_64/\" start.bat \n ";


                StreamReader readerIN = new StreamReader("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i + "/x86_64/configuration/config.ini");           
                String contentIN = readerIN.ReadToEnd();
                //Console.WriteLine(contentIN);
                readerIN.Close();
                StreamWriter writerIN = new StreamWriter("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i + "/x86_64/configuration/config.ini");

                contentIN = Regex.Replace(contentIN, cseBaseName, cseBaseName + Simulation.ListNodeIN[i].Node_Name);
                contentIN = Regex.Replace(contentIN, cseBaseId, cseBaseId + Simulation.ListNodeIN[i].Node_Id);
                writerIN.Write(contentIN);
                writerIN.Close();
            }
            for (int i = Simulation.ListNodeMN.Count; i < numberMN + Simulation.ListNodeMN.Count; i++)
            {
                filePath = filePath + "\n start /D \"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/\" start.bat \n ";

                StreamReader reader = new StreamReader("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/configuration/config.ini");
                String content = reader.ReadToEnd();
                //Console.WriteLine(content);
                reader.Close();
                StreamWriter writer = new StreamWriter("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/configuration/config.ini");
                //content = Regex.Replace(content, cseMNPort, cseMNPort + Simulation.ListNodeMN[i].Node_Port);
                content = Regex.Replace(content, cseMNPort, cseMNPort + "8585");
                writer.Write(content);
                writer.Close();
            }
            //-----------------------------------
            //for (int i = 0; i < Simulation.ListNodeMN.Count; i++)
            //{
            //    for (int j = 0; j < Simulation.ListNodeIN.Count; j++)
            //    {
            //        int weight = Convert.ToInt32(Math.Pow(Simulation.ListNodeMN[i].Center.X - Simulation.ListNodeMN[j].Center.X, 2) + Math.Pow(Simulation.ListNodeMN[i].Center.Y - Simulation.ListNodeMN[j].Center.Y, 2));
            //        Console.WriteLine(weight + " location" + R);
            //        if (weight < R * R)
            //        {
            //            //MN_PORT[i] = MN_PORT[i] + " " + Simulation.ListNodeIN[j].Node_Port;
            //            //MN_NAME[i] = MN_NAME[i] + " " + Simulation.ListNodeIN[j].Node_Name;
            //            //MN_ID[i] = MN_ID[i] + " " + Simulation.ListNodeIN[j].Node_Id;
            //            //MN_IP[i] = MN_IP[i] + " " + Simulation.ListNodeIN[j].Node_Ip;                     
            //            Console.WriteLine(i + "chi so");
            //        }
            //    }
            //    Console.WriteLine(MN_PORT[i] + "Chỉ số mnport out");
            //}
            //for (int i = 0; i < Simulation.ListNodeMN.Count - 1; i++)
            //{
            //    for (int j = Simulation.ListNodeMN.Count - 1; j > 0; j--)
            //    {
            //        if (i < j)
            //        {
            //            int weight = Convert.ToInt32(Math.Pow(Simulation.ListNodeMN[i].Center.X - Simulation.ListNodeMN[j].Center.X, 2) + Math.Pow(Simulation.ListNodeMN[i].Center.Y - Simulation.ListNodeMN[j].Center.Y, 2));
            //            Console.WriteLine(weight + " location" + R);
            //            if (weight < R * R)
            //            {
            //                //Console.WriteLine(Node.InRange(this) + " = ");
            //                //MN_PORT[j] = MN_PORT[j] + " " + Simulation.ListNodeMN[i].Node_Port;
            //                //MN_NAME[j] = MN_NAME[j] + " " + Simulation.ListNodeMN[i].Node_Name;
            //                //MN_ID[j] = MN_ID[j] + " " + Simulation.ListNodeMN[i].Node_Id;
            //                //MN_IP[j] = MN_IP[j] + " " + Simulation.ListNodeMN[i].Node_Ip;
            //                //filePath = filePath + "\n start /D \"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/\" start.bat \n ";
            //                Console.WriteLine(i + "chi so");
            //            }
            //        }
            //    }
            //}
            //-----------------------------------
            //config cho từng MN
            //for(int i = 0; i < Simulation.ListNodeMN.Count; i++)
            //{
            //    doConfig doCofig = new doConfig();
            //    doCofig.doCofig(Simulation.ListNodeMN[i]);
            //}
            //Tạo file run-new-all.bat chứa tất cả các file bat khác
            String filePathRunAll = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/run-all.bat";    
            String fileNewPathRunAll = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/run-new-all-" + k + ".bat";
            using (var file = new StreamReader(filePathRunAll))
            using (var writer = new StreamWriter(fileNewPathRunAll))
            {
                Console.WriteLine("Code có vào k");
                String line;
                while ((line = file.ReadLine()) != null)
                {
                    if (!line.Contains(")"))
                        writer.WriteLine(line);
                    else
                    {
                        Console.WriteLine(line);
                        writer.WriteLine(filePath + ")");
                    }
                }
                writer.Close();
                file.Close();
            }
        }
    }
}
