using OfficeOpenXml;
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
    public partial class InfoNode : Form
    {
        //giữ nguyên đối tượng khi được gọi lại
        public static InfoNode Instance;
        public static InfoNode GetInstance()
        {
            if (Instance == null)
            {
                Instance = new InfoNode();
            }
            return Instance;
        }

        public InfoNode()
        {
            InitializeComponent();
        }
        public static string nameNd ;
        public static int idx;
        public static string node_name;
        public static string node_port;
        public static string node_id;
        public static string node_ip;
        public static int node_range;
        public void SetData(Node node)
        {
            string name = null;
            string id = null;
            CreateNode creNode = CreateNode.GetInstance();
            if(node.content1 == "IN")
            {
                name = "in-name-";
                id = "in-cse-";
            }
            if(node.content1 == "MN")
            {
                name = "mn-name-";
                id = "mn-cse-";
            }
            if (node.content1 == "AE")
            {
                name = "ae-name-";
                id = "ae-cse-";
            }
            //node trong textox
            node_Name.Text = name + node.Index;
            node_ID.Text = id  + node.Index;
            node_IP.Text = "127.0.0.1"; // "192.168.0." + node.Index;
            //node_Port.Text = "8"+ node.Index + "8" + node.Index;
            node_Port.Text = "8080";
            node_Range.Text = "100";

            nameNd = node.content1;

            node_port = node_Port.Text;
            node_name = node_Name.Text;
            node_id = node_ID.Text;
            node_ip = node_IP.Text;
            node_range = Convert.ToInt32(node_Range.Text);
            //Node.Node_Range = node_range;
            if (node.content1 == "IN")
            {
                Simulation.ListNodeIN[node.Index].Node_Port = node_port;
                Simulation.ListNodeIN[node.Index].Node_Name = node_name;
                Simulation.ListNodeIN[node.Index].Node_Id = node_id;
                Simulation.ListNodeIN[node.Index].Node_Ip = node_ip;
                Simulation.ListNodeIN[node.Index].Node_Range = node_range;
                Console.WriteLine(Simulation.ListNodeIN[node.Index].Node_Port + " chi so IN ben Info");
            }
            
            if (node.content1 == "MN")
            {
                node_port = "828" + node.Index;
                if(node.Index == 0)
                {
                    //node_port = "8282";
                    //node_ip = "168.0.0.10";
                }
                //node_ip = "127.0.0.1";
                Simulation.ListNodeMN[node.Index].Node_Port = node_port;
                Simulation.ListNodeMN[node.Index].Node_Name = node_name;
                Simulation.ListNodeMN[node.Index].Node_Id = node_id;
                Simulation.ListNodeMN[node.Index].Node_Ip = node_ip;
                Simulation.ListNodeMN[node.Index].Node_Range = node_range;
                Console.WriteLine(Simulation.ListNodeMN[node.Index].Node_Port + " chi so MN ben Info");
            }
        }
        public void SetAgainData(Node node)
        {
            string name = null;
            string id = null;
            CreateNode creNode = CreateNode.GetInstance();
            if (node.content1 == "IN")
            {
                name = "in-name-";
                id = "in-cse-";
            }
            if (node.content1 == "MN")
            {
                name = "mn-name-";
                id = "mn-cse-";
            }
            if (node.content1 == "AE")
            {
                name = "ae-name-";
                id = "ae-cse-";
            }
            //node trong textox
            node_Name.Text = name + node.Index;
            node_ID.Text = id + node.Index;
            node_IP.Text = "127.0.0.1"; // "192.168.0." + node.Index;
            //node_Port.Text = "8"+ node.Index + "8" + node.Index;
            node_Port.Text = "8080";
            //node_Range.Text = "200";

            nameNd = node.content1;

            node_port = node_Port.Text;
            node_name = node_Name.Text;
            node_id = node_ID.Text;
            node_ip = node_IP.Text;
            if (node_Range.Text != "")
                node_range = Convert.ToInt32(node_Range.Text);
            //Node.Node_Range = node_range;
            if (node.content1 == "IN")
            {
                Simulation.ListNodeIN[node.Index].Node_Port = node_port;
                Simulation.ListNodeIN[node.Index].Node_Name = node_name;
                Simulation.ListNodeIN[node.Index].Node_Id = node_id;
                Simulation.ListNodeIN[node.Index].Node_Ip = node_ip;
                Simulation.ListNodeIN[node.Index].Node_Range = node_range;
                Console.WriteLine(Simulation.ListNodeIN[node.Index].Node_Port + " chi so IN ben Info");
            }

            if (node.content1 == "MN")
            {
                node_port = "828" + node.Index;
                if (node.Index == 0)
                {
                    //node_port = "8282";
                    //node_ip = "168.0.0.10";
                }
                //node_ip = "127.0.0.1";
                Simulation.ListNodeMN[node.Index].Node_Port = node_port;
                Simulation.ListNodeMN[node.Index].Node_Name = node_name;
                Simulation.ListNodeMN[node.Index].Node_Id = node_id;
                Simulation.ListNodeMN[node.Index].Node_Ip = node_ip;
                Simulation.ListNodeMN[node.Index].Node_Range = node_range;
                Console.WriteLine(Simulation.ListNodeMN[node.Index].Node_Port + " chi so MN ben Info");
            }
        }
        //public void ImportExcel()
        //{

        //    var package = new ExcelPackage(new FileInfo("LocRange.xlsx"));
        //    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
        //    for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
        //    {
        //        int j = 1;
        //        string name = workSheet.Cells[i, j++].Value.ToString();                
        //    }
            
        //}
        //public void ExportExcel(Node node)
        //{

        //    var package = new ExcelPackage(new FileInfo("Exam2.xlsx"));
        //    ExcelWorksheet ws = package.Workbook.Worksheets[1];

        //    int rowIndex = 1;
        //    switch (nameNd)
        //    {
        //        case "IN":
        //            {
        //                rowIndex = 2;
        //                break;
        //            }
        //        case "MN":
        //            {
        //                rowIndex = idx + 3;
        //                break;
        //            }
        //        case "AE":
        //            {
        //                rowIndex = idx + 7;
        //                break;
        //            }
        //        default:
        //            break;
        //    }
        //    Console.WriteLine(idx + "--------------");
        //    ws.Cells[rowIndex, 1].Value = node_Name.Text;
        //    ws.Cells[rowIndex, 5].Value = node_ID.Text;
        //    ws.Cells[rowIndex, 6].Value = node_Name.Text;
        //    ws.Cells[rowIndex, 7].Value = node_IP.Text;
        //    ws.Cells[rowIndex, 8].Value = node_Port.Text;
        //    //Lưu file lại
        //    package.Save();
        //    MessageBox.Show("Xuất excel thành công!");

        //}

        private void button_Cancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public int i;
        public void btn_OK_Click_1(object sender, EventArgs e)
        {
            Node node = Node.GetInstance();
            i = 1;
            Console.WriteLine(node.Index + " chi so index");
            this.Visible = false;
        }
        private void button_Cancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
