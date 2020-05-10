using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation2
{
    class doDataSQLite
    {
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
            createConection();
            SQLiteCommand command = new SQLiteCommand(sql, connectData);
            command.ExecuteNonQuery();
            closeConnection();
        }
        public DataSet loadData()
        {
            DataSet ds = new DataSet();
            createConection();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select id, nodeName as [Node Name], mess as [Message], time as [Time] from tbl_nodeMonitor", connectData);

            da.Fill(ds);
            //dataGidMonitor.DataSource = ds.Tables[0];
            closeConnection();
            return ds;
        }
        public void getData()
        {
            String filePath = "C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/mn-cse/x86_64/reqOUT.txt";
            File.ReadAllText(filePath);
            for (int i = 0; i < Simulation.ListNodeMN.Count; i++)
            {
                String nodename = "mn-cse-" + Simulation.ListNodeMN[i].index;
                Console.WriteLine(Simulation.ListNodeMN[i].index + "111111111111111");
                String mess = File.ReadAllText(filePath); ;
                String time = "";

                string strInsert = string.Format("INSERT INTO tbl_nodeMonitor(nodename, mess, time) VALUES('{0}','{1}','{2}')", nodename, mess, time);
                createConection();
                SQLiteCommand cmd = new SQLiteCommand(strInsert, connectData);
                cmd.ExecuteNonQuery();
            }
            closeConnection();
            // load data
            //loadData();
        }
    }
}
