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
using System.Timers;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;

namespace simulation2
{
    public partial class Simulation : Form
    {
        public static List<Node> list_node_In;
        public List<Node> list_node_to_IN;
        Counter _counter = new Counter();

        private static Simulation instance;
        public static Simulation getInstance()
        {
            if (instance == null)
            {
                instance = new Simulation();
            }
            //Proxy.Start();
            //Thread pro = new Thread(HttpServer.Server1.Start);
            //pro.Start();
            return instance;
        }
        private Simulation()
        {
            InitializeComponent();
            int seconds = 0;

            _counter.OnCount = (step) =>
            {
                panel_simu.Invalidate();
            };

            panel_simu.Paint += (s, e) =>
            {
                var pen = new Pen(Color.LightGray, 1);
                Node.Tranversal((node) =>
                {
                    var pt = node.Center;
                    var r = node.Range;
                    var d = r << 1;
                    e.Graphics.DrawEllipse(pen, pt.X - r, pt.Y - r, d, d);
                });

                Node.Tranversal((node) =>
                {
                    var o = node.Center;
                    var connList = node.GetNodeInRange();
                    //foreach (var n in connList)
                    //    e.Graphics.DrawLine(pen, o, n.Center);
                    pen = new Pen(Color.Gray, 1);
                    pen.DashStyle = DashStyle.Dash;
                    foreach (var n in connList)
                    {
                        e.Graphics.DrawLine(pen, o, n.Center);
                    }
                                      
                });

            };

            _counter.OnSecond = () =>
            {
                if (++seconds == 10)
                {
                    seconds = 0;
                    getData();
                    //loadData();
                    test_connect_IN();
                }
            };
            _counter.Start();

            FormClosing += (s, e) =>
            {
                _counter.Dispose();
            };
        }

        public int t = -2;
        bool flag = false;
        int id = 1;
        public int test_connect_IN()
        {

            InfoNode infoNode = InfoNode.GetInstance();
            List<String> list = new List<string>();
            String listToIN = "";
            String listIN = "Port";
            String listINMax = "Port";
            String listDistance = "Distance";
            for (int i = 0; i < ListNodeIN.Count; i++)
            {
                for (int j = 0; j < ListNodeMN.Count; j++)
                {
                    if (ListNodeIN[i].InRange(ListNodeMN[j]))
                    {
                        //list_node_to_IN.Add(ListNodeMN[j]);
                        Console.WriteLine("Node connect to IN is: " + ListNodeMN[j].Text + "  " + ListNodeMN[j].index + " " + Simulation.ListNodeMN[ListNodeMN[j].index].Node_Port);
                        list.Add(Simulation.ListNodeMN[ListNodeMN[j].index].Node_Port);
                        listToIN = listToIN + Simulation.ListNodeMN[ListNodeMN[j].index].Node_Port;
                        listIN = listIN + "-" + Simulation.ListNodeMN[ListNodeMN[j].index].Node_Port;
                        listDistance = listDistance + "-" + ListNodeIN[i].InDistance(ListNodeMN[j]);

                    }
                    if (ListNodeIN[i].InDistance(ListNodeMN[j]))
                    {
                        listINMax = listINMax + "-" + Simulation.ListNodeMN[ListNodeMN[j].index].Node_Port;
                    }
                }
            }
            String a = listToIN;
            Console.WriteLine(listToIN + " aaa " + id + listDistance);
            SQLiteConnection sqlite_conn;
            sqlite_conn = GetDataProxy.CreateConnection();
            GetDataProxy.InsertData(sqlite_conn, a, id);
            GetDataProxy.ReadData(sqlite_conn, id);
            sqlite_conn.Dispose();
            //String sourceFile = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/MyDatabase.sqlite";
            //String destFile = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/MyDatabase2.sqlite";

            String filePathMin = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/dataMin.txt";
            String filePathMax = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/dataMax.txt";
            File.WriteAllText(filePathMin, listIN);
            File.WriteAllText(filePathMax, listINMax);

            //System.IO.File.Copy(sourceFile, destFile, true);

            list_node_In = new List<Node>();

            id++;
            t = list.Count();
            //Console.WriteLine("Simulator---" + list[0]);
            flag = true;
            return t;
        }

        public int get_connect_IN()
        {
            if (flag)
            {
                flag = false;
                return t;
            }
            return -1;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CreateNode.CreateData();
            createNode();
            //Đưa dữ liệu thiết lập trong infoNode vào node
            InfoNode infoNode = InfoNode.GetInstance();
            for (int i = 0; i < ListNodeIN.Count; i++)
            { infoNode.SetData(ListNodeIN[i]); }
            for (int i = 0; i < ListNodeMN.Count; i++)
            { infoNode.SetData(ListNodeMN[i]); }
            if (txtColumn.Text == "")
            {
                txtColumn.ForeColor = Color.Gray;
            }


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
            for (int i = 0; i < CreateNode.numberIN; i++)
            {
                var node = Node.CreateNode("IN");
                Console.WriteLine(node.Text_Name + node.Index + "----" + " Index");
                panel_simu.Controls.Add(node);
                ListNodeIN.Add(node);

            }
            for (int i = 0; i < CreateNode.numberMN; i++)
            {
                var node = Node.CreateNode("MN");
                panel_simu.Controls.Add(node);
                ListNodeMN.Add(node);
            }

            Console.WriteLine(CreateNode.numberIN + "-------------");
            for (int i = 0; i < CreateNode.numberAE; i++)
            {
                var node = Node.CreateNode("AE");
                panel_simu.Controls.Add(node);
                ListNodeAE.Add(node);
            }
        }
        public void deleteNode()
        {
            for (int i = 0; i < CreateNode.numberIN; i++)
            {
                var node = Node.deleteNode("IN");
                Console.WriteLine(node.Text_Name + node.Index + "----" + " Index");
                panel_simu.Controls.Remove(node);
                ListNodeIN.Remove(node);

            }
            for (int i = 0; i < CreateNode.numberMN; i++)
            {
                var node = Node.deleteNode("MN");
                panel_simu.Controls.Remove(node);
                ListNodeMN.Remove(node);
            }

            Console.WriteLine(CreateNode.numberIN + "-------------");
            for (int i = 0; i < CreateNode.numberAE; i++)
            {
                var node = Node.deleteNode("AE");
                panel_simu.Controls.Remove(node);
                ListNodeAE.Remove(node);
            }
        }
        public void AddNode()
        {
            for (int i = CreateNode.numberIN; i < FormAddNode.numberIN + CreateNode.numberIN; i++)
            {
                var node = Node.CreateNode("IN");
                Console.WriteLine(node.Text_Name + "--+--" + node.Index + " Index");
                panel_simu.Controls.Add(node);
                ListNodeIN.Add(node);
                InfoNode infoNode = InfoNode.GetInstance();
                infoNode.SetData(node);

            }
            for (int i = CreateNode.numberMN; i < FormAddNode.numberMN + CreateNode.numberMN; i++)
            {
                InfoNode infoNode = InfoNode.GetInstance();
                var node = Node.CreateNode("MN");
                panel_simu.Controls.Add(node);
                ListNodeMN.Add(node);
                infoNode.SetData(node);
            }

            Console.WriteLine(CreateNode.numberIN + "-------------");
            for (int i = CreateNode.numberAE; i < FormAddNode.numberAE + CreateNode.numberAE; i++)
            {
                var node = Node.CreateNode("AE");
                panel_simu.Controls.Add(node);
                ListNodeAE.Add(node);
                InfoNode infoNode = InfoNode.GetInstance();
                infoNode.SetData(node);
            }
        }
        //public void deleteNode()
        //{
        //    panel_simu.Controls.Remove(node);
        //}
        private void panel_mess_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_simu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button_run_Click(object sender, EventArgs e)
        {
            RemoveAll();
            ////Đưa dữ liệu thiết lập trong infoNode vào node
            //InfoNode infoNode = InfoNode.GetInstance();
            //for(int i = 0; i < ListNodeIN.Count; i++)
            //{infoNode.SetData(ListNodeIN[i]);}
            //for(int i = 0; i < ListNodeMN.Count; i++)
            //{infoNode.SetData(ListNodeMN[i]);}
            String fileDirectoryPath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/IN-MN-Standard";
            if (Directory.Exists(fileDirectoryPath)) Directory.CreateDirectory(fileDirectoryPath);
            //Kết nối và RUN các node
            NodeConect conect = new NodeConect();
            conect.conectNode();

            doConfig doCofig = new doConfig();
            doCofig.doCofig();

            String FilePath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/run-new-all.bat";
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = FilePath; // vd: "D:"
            prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            prc.Start();

            Thread.Sleep(3000);
            //connectData.Open();
            createTable();
            getData();

            SQLiteConnection sqlite_conn;
            sqlite_conn = GetDataProxy.CreateConnection();
            GetDataProxy.DeleteTable(sqlite_conn);
            GetDataProxy.CreateTable(sqlite_conn);
            sqlite_conn.Close();
            //GetDataProxy.CloseConnection();
            
        }

        SQLiteConnection connectData = new SQLiteConnection("Data Source = C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/MyDatabase.sqlite");
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
            DropTable();
            string sql = "CREATE TABLE IF NOT EXISTS tbl_nodeMonitor ([ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,Times nvarchar(10), Source nvarchar(10), Action varchar(100), Type varchar(30), Destination varchar(10), Status varchar(10), Contents varchar(10))";
            String path = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/IN-MN-Standard/MyDatabase.sqlite";
            if (!File.Exists(path))
                SQLiteConnection.CreateFile("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/IN-MN-Standard/MyDatabase.sqlite");
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, connectData);
            command.ExecuteNonQuery();
            closeConnection();
        }

        public void DropTable()
        {
            createConection();
            String sql = "DROP TABLE tbl_nodeMonitor";
            SQLiteCommand command = new SQLiteCommand(sql, connectData);
            closeConnection();
        }
        public void RemoveAll()
        {
            String sourceFileData = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/MyDatabase.sqlite";
            if (File.Exists(sourceFileData))
            {
                File.WriteAllText(sourceFileData, "");
            }
            String ProxyData = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/data.txt";
            if (File.Exists(ProxyData))
            {
                File.WriteAllText(ProxyData, "");
            }
            String FileDataOUT = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/reqOUT.txt";
            if (File.Exists(FileDataOUT))
            {
                File.WriteAllText(FileDataOUT, "");
            }
            String FileDataIN = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/reqIN.txt";
            if (File.Exists(FileDataIN))
            {
                File.WriteAllText(FileDataIN, "");
            }
        }
        BindingSource bs = new BindingSource();
        public DataSet loadData()
        {
            createConection();
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM tbl_nodeMonitor ORDER BY Times ASC", connectData);
            da.Fill(ds);
            dataGidMonitor.DataSource = ds.Tables[0];
            dataGidMonitor.Refresh();
            dataGidMonitor.Columns[0].Width = 20;
            dataGidMonitor.Columns[1].Width = 70;
            dataGidMonitor.Columns[2].Width = 50;
            dataGidMonitor.Columns[3].Width = 65;
            dataGidMonitor.Columns[4].Width = 70;
            dataGidMonitor.Columns[5].Width = 65;
            dataGidMonitor.Columns[6].Width = 65;
            foreach(DataGridViewRow row in dataGidMonitor.Rows)
            {
                if (row.Cells[6].Value.ToString() == "Active")
                    row.DefaultCellStyle.BackColor = Color.Green;
                if (row.Cells[6].Value.ToString() == "Deactivate")
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
            }    
            //dataGidMonitor.Rows[0].DefaultCellStyle.ForceColor = Color.Beige;
            closeConnection();
            return ds;
        }
        public void getData()
        {
            DropTable();
            createTable();
            String filePath = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/reqOUT.txt";
            String filePathIN = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/reqIN.txt";
            String filePathData = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/dataMin.txt";
            String filePathDataMin = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/dataMax.txt";
            File.ReadAllText(filePath);
            String t = File.ReadAllText(filePathData);
            File.ReadAllText(filePath);
            String dmin = File.ReadAllText(filePathDataMin);
            for (int i = 0; i < Simulation.ListNodeMN.Count; i++)
            {
                String times = DateTime.Now.ToString("hh:mm:ss tt");
                //if (t.Contains(Simulation.ListNodeMN[i].Node_Port))
                //{
                String source = "MN-" + Simulation.ListNodeMN[i].index;
                Console.WriteLine(Simulation.ListNodeMN[i].index + "111111111111111");
                String mess = File.ReadAllText(filePath);
                String action = "";
                String type = "";
                String destination = "IN-1";
                String status = "";
                String content = mess;

                //--------------------
                String source2 = "IN-";
                Console.WriteLine(Simulation.ListNodeMN[i].index + "111111111111111");
                String mess2 = File.ReadAllText(filePathIN);
                String action2 = "";
                String type2 = "";
                String destination2 = "MN-" + Simulation.ListNodeMN[i].index;
                String status2 = "Active";
                String content2 = mess;
                if (t.Contains(Simulation.ListNodeMN[i].Node_Port))
                {

                    status = "Active";
                    action = "Request";
                    type = "Remote CSE";

                    source2 = "IN-1";
                    Console.WriteLine(Simulation.ListNodeMN[i].index + "111111111111111");
                    mess2 = File.ReadAllText(filePathIN);
                    action2 = "Response";
                    type2 = "Remote CSE";
                    destination2 = "MN-" + Simulation.ListNodeMN[i].index;
                    status2 = "Active";
                    content2 = mess2;

                    createConection();
                    string strInsert = string.Format("INSERT INTO tbl_nodeMonitor(Times, Source, Action, Type, Destination, Status, Contents) VALUES('{0}','{1}','{2}', '{3}', '{4}','{5}','{6}')", times, source, action, type, destination, status, content);
                    SQLiteCommand cmd = new SQLiteCommand(strInsert, connectData);
                    cmd.ExecuteNonQuery();
                    closeConnection();

                    createConection();
                    string strInsertt = string.Format("INSERT INTO tbl_nodeMonitor(Times, Source, Action, Type, Destination, Status, Contents) VALUES('{0}','{1}','{2}', '{3}', '{4}','{5}','{6}')", times, source2, action2, type2, destination2, status2, content2);
                    SQLiteCommand cmdd = new SQLiteCommand(strInsertt, connectData);
                    cmdd.ExecuteNonQuery();
                    closeConnection();
                }
                else
                {
                    status = "Deactivate";
                    content = "";
                    source2 = "IN-1";
                    Console.WriteLine(Simulation.ListNodeMN[i].index + "111111111111111");
                    mess2 = File.ReadAllText(filePathIN);
                    action2 = "";
                    type2 = "";
                    destination2 = "MN-" + Simulation.ListNodeMN[i].index;
                    status2 = "Deactivate";
                    content2 = "";

                    createConection();
                    string strInsert = string.Format("INSERT INTO tbl_nodeMonitor(Times, Source, Action, Type, Destination, Status, Contents) VALUES('{0}','{1}','{2}', '{3}', '{4}','{5}','{6}')", times, source, action, type, destination, status, content);
                    SQLiteCommand cmd = new SQLiteCommand(strInsert, connectData);
                    cmd.ExecuteNonQuery();
                    closeConnection();
                }
                //---------------------------------
            }
            loadData();
        }

        private void addMotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddNode add_node = FormAddNode.GetInstance();
            add_node.ShowDialog();
            AddNode();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateSimu cre = new CreateSimu();
            cre.ShowDialog();
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readToItemSettingFile();
            Thread t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Filter = "JSON Files (*.rtf)|*.rtf";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string fileName;
                    fileName = dlg.FileName;
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void savaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ListNodeIN.Count; i++)
            { writeToItemSettingFile(ListNodeIN[i]); }
            for (int i = 0; i < ListNodeMN.Count; i++)
            { writeToItemSettingFile(ListNodeMN[i]); }
            string selectedPath = "";

            Thread t = new Thread((ThreadStart)(() =>
            {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();

                saveFileDialog1.Filter = "JSON Files (*.csv)|*.csv";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    selectedPath = saveFileDialog1.FileName;
                }
            }));

            // Run your code from a thread that joins the STA Thread
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static void ParserJSon(Node node)
        {
            String path = "C:/Users/eduyduy/Documents/SIMULATOR/test2.json";
            //Node node = new Node();
            //node.Name = "IN";
            //node.Node_Range = 150;
            JsonSerializerSettings jss = new JsonSerializerSettings();
            jss.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            string json = JsonConvert.SerializeObject(node);
            File.WriteAllText(path, json.ToString());
        }
        public static List<String> lines = new List<String>();
        public static void writeToItemSettingFile(Node node)
        {
            String path = "C:/Users/eduyduy/Documents/SIMULATOR/test2.csv"; //Khai báo đường dẫn chứa file
                                                                            //Khai báo đối tượng kiểu string
            lines.Add(node.Text + "," + node.index + "," + node.Node_Name + "," + node.Node_Id + "," + node.Node_Ip + "," + node.Node_Port + "," + node.Node_Range);
            //lines.Add(node.Text + "," + node.index + "," + node.Node_Id);
            //lines.Add(node.Text + "," + node.index + "," + node.Node_Ip);
            //lines.Add(node.Text + "," + node.index + "," + node.Node_Port);
            //lines.Add(node.Text + "," + node.index + "," + node.Node_Range);
            //File.WriteAllText(path, ""); //Xóa trắng tất cả dữ liệu ở file cũ.
            //File.WriteAllText(path, string.Empty); //dùng cách này cũng được
            //Sử dụng đối tượng StreamWriter để ghi file
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (string line in lines)
                    writer.WriteLine(line);
            }

        }
        public static void readToItemSettingFile()
        {
            using (var reader = new StreamReader("C:/Users/eduyduy/Documents/SIMULATOR/test2.csv"))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    listA.Add(values[0]);
                    listB.Add(values[1]);
                }
                Console.WriteLine(listA[2] + listA.Count);
            }

        }

        int i = 0;
        private void button_pause_Click(object sender, EventArgs e)
        {
            i++;
            if (i % 2 == 1)
            {
                _counter.Stop();
            }
            if (i % 2 == 0)
            {
                int seconds = 0;
                _counter.OnSecond = () =>
                {
                    if (++seconds == 10)
                    {
                        seconds = 0;
                        getData();
                        loadData();
                        test_connect_IN();
                    }
                };
                _counter.Start();
            }

        }
        public void getCPUCounter()
        {

            PerformanceCounter cpuCounter = new PerformanceCounter();
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            Console.WriteLine(cpuCounter.NextValue());
            float fcpu = cpuCounter.NextValue();
            Console.WriteLine(fcpu + "%");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            closeConnection();
            dataGidMonitor.DataSource = null;
            DropTable();
            createTable();
            ////Simulation.ListNodeIN.Clear();
            ////Simulation.ListNodeMN.Clear();
            ////Simulation.ListNodeAE.Clear();
            //deleteNode();
            //panel_simu.Controls.Clear();
            //panel_simu.Paint += (s, t) =>
            //{
            //    var pen = new Pen(Color.Gray, 1);
            //    Node.Tranversal((node) =>
            //    {
            //    });
            //};


            //panel_simu.Refresh();
            ////but_Click(panel_simu);
            ////panel_simu.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
            //createNode();
            ////Đưa dữ liệu thiết lập trong infoNode vào node

            //InfoNode infoNode = InfoNode.GetInstance();
            //for (int i = 0; i < ListNodeIN.Count; i++)
            //{
            //    infoNode.SetData(ListNodeIN[i]);
            //}
            //for (int i = 0; i < ListNodeMN.Count; i++)
            //{
            //    infoNode.SetData(ListNodeMN[i]);
            //}

        }

        private void button_step_Click(object sender, EventArgs e)
        {
            
        }
        public DataSet loadDataSelect()
        {
            createConection();
            DataSet ds = new DataSet();
            SQLiteDataAdapter da;
            if (txtColumn.Text != "")
            {
                da = new SQLiteDataAdapter(" SELECT * FROM tbl_nodeMonitor WHERE " + txtColumn.Text  + " = " + "'" + txtFind.Text + "'" + ";", connectData);
            }
            //SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM tbl_nodeMonitor ORDER BY Times ASC", connectData);
            else
            {
                da = new SQLiteDataAdapter(" SELECT * FROM tbl_nodeMonitor WHERE Source = " + "'" + txtFind.Text + "'"
                    + " OR Action = " + "'" + txtFind.Text + "'"
                    + " OR Type = " + "'" + txtFind.Text + "'"
                    + " OR Destination = " + "'" + txtFind.Text + "'"
                    + " OR Status = " + "'" + txtFind.Text + "'"
                    + " OR Contents = " + "'" + txtFind.Text + "'"
                    + " OR Times = " + "'" + txtFind.Text + "'"
                    + ";", connectData);
            }
            da.Fill(ds);
            dataGidMonitor.DataSource = ds.Tables[0];
            dataGidMonitor.Refresh();
            dataGidMonitor.Columns[0].Width = 20;
            dataGidMonitor.Columns[1].Width = 120;
            dataGidMonitor.Columns[2].Width = 50;
            dataGidMonitor.Columns[3].Width = 70;
            dataGidMonitor.Columns[4].Width = 70;
            dataGidMonitor.Columns[5].Width = 62;
            dataGidMonitor.Columns[6].Width = 72;
            foreach (DataGridViewRow row in dataGidMonitor.Rows)
            {
                if (row.Cells[6].Value.ToString() == "Active")
                    row.DefaultCellStyle.BackColor = Color.Green;
                if (row.Cells[6].Value.ToString() == "Deactivate")
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
            }
            //dataGidMonitor.Rows[0].DefaultCellStyle.ForceColor = Color.Beige;
            closeConnection();
            return ds;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            loadDataSelect();
            _counter.Stop();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _counter.Start();
            getData();
        }
    }
}


