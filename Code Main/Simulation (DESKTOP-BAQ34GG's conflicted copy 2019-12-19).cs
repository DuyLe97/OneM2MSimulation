using simulation02;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

using System.Data.OleDb;
using System.IO;
namespace simulation2
{
    public partial class Simulation : Form
    {
        public Simulation()
        {
            InitializeComponent();
            createNode();
        }

        private void createNewMoteTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateMoteType creMoteType = new CreateMoteType();
            creMoteType.ShowDialog();
        }
        public int indx;
        public static List<Node> ListNodeIN = new List<Node>();
        public static List<Node> ListNodeMN = new List<Node>();
        public static List<Node> ListNodeAE = new List<Node>();
        public void createNode()
        {
                CreateNode creNode = CreateNode.GetInstance();
                for (int i = 0; i < creNode.numberIN; i++)
                {
                    var node = Node.CreateNode("IN");
                    Console.WriteLine(node.Text_Name + node.Index + "----" + " Index");
                    panel_simu.Controls.Add(node);
                    ListNodeIN.Add(node);
                }
                for (int i = 0; i < creNode.numberMN; i++)
                {
                    var node = Node.CreateNode("MN");
                    panel_simu.Controls.Add(node);
                    ListNodeMN.Add(node);       
                }
              
                Console.WriteLine(creNode.numberIN + "-------------");
                for (int i = 0; i < creNode.numberAE; i++)
                {
                    var node = Node.CreateNode("AE");
                    panel_simu.Controls.Add(node);
                    ListNodeAE.Add(node);
                }
        
        }

        private void panel_mess_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_simu_Paint(object sender, PaintEventArgs e)
        {
               
        }
        public void ImportDataGrid()
        {
            string file = "Exam2.xlsx";
            string name = "Sheet";
            //string constr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source=" + file + "; Extented Properties =\"Excel 8.0; HDR=Yes;\";";
            //OleDbConnection con = new OleDbConnection(constr);
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';");
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataSet data = new DataSet();
            sda.Fill(data);
            dataGidMonitor.DataSource = data.Tables;
        }
        private void button_run_Click(object sender, EventArgs e)
        {
            String FilePathIN = "C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/in-cse/win32/win32/x86_64/start.bat";
            //File.Open(FilePathIN, FileMode.Open);
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = FilePathIN; // vd: "D:"
            prc.Start();
            
            for(int i = 0; i < ListNodeMN.Count; i++)
            {
                String dirPath = "C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/mn-cse-" + ListNodeMN[i].index;
                if(Directory.Exists(dirPath))
                {
                String FilePathMN = "C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/mn-cse-" + ListNodeMN[i].index + "/x86_64/start.bat";
                //System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = FilePathMN; // vd: "D:"
                prc.Start();
                //prc.CloseMainWindow();
                Console.WriteLine("đã Start");
                //prc.Close();              
                }
            }
            connectData.Open();
            //createTable();
            getData();
        }
        SQLiteConnection connectData = new SQLiteConnection("Data Source = C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/MyDatabase.sqlite");
        public void createConection()
        {
            connectData.Open();
        }

        public void closeConnection()
        {
            connectData.Close();
        }
        public void createTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS tbl_nodeMonitor ([id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, nodeName nvarchar(10), mess varchar(15), time varchar(30))";
            SQLiteConnection.CreateFile("C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/MyDatabase.sqlite");
            //createConection();
            SQLiteCommand command = new SQLiteCommand(sql, connectData);
            command.ExecuteNonQuery();
            //closeConnection();
        }
        public DataSet loadData()
        {
            DataSet ds = new DataSet();
            //createConection();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, nodeName as [Node Name], mess as [Message], time as [Time] from tbl_nodeMonitor", connectData);

            da.Fill(ds);
            dataGidMonitor.DataSource = ds.Tables[0];
            closeConnection();
            return ds;
        }
        public void getData()
        {
            //createTable();
            String filePath = "C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/mn-cse/x86_64/reqOUT.txt";
            File.ReadAllText(filePath);
            for (int i = 0; i < Simulation.ListNodeMN.Count; i++)
            {
                String nodename = "mn-cse-" + Simulation.ListNodeMN[i].index;
                Console.WriteLine(Simulation.ListNodeMN[i].index + "111111111111111");
                String mess = File.ReadAllText(filePath); ;
                String time = "";

                string strInsert = string.Format("INSERT INTO tbl_nodeMonitor(nodename, mess, time) VALUES('{0}','{1}','{2}')", nodename, mess, time);
                //createConection();
                SQLiteCommand cmd = new SQLiteCommand(strInsert, connectData);
                cmd.ExecuteNonQuery();
            }
            //closeConnection();
            // load data
            loadData();
        }
    }
}
