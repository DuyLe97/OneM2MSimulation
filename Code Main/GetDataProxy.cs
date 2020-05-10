using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simulation2
{
    public class GetDataProxy
    {
        public static SQLiteConnection CreateConnection()
      {
 
         SQLiteConnection sqlite_conn;
         //Create a new database connection:
         //sqlite_conn = new SQLiteConnection(@"URI=file:C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/MyDatabase.sqlite");
         sqlite_conn = new SQLiteConnection("Data Source=C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/MyDatabase.sqlite;Version=3;New=True;Compress=True;Synchronous=Off;");
         // Open the connection:
         try
         {
            sqlite_conn.Open();
         }
         catch (Exception ex)
         {
 
         }
         return sqlite_conn;
      }

        public static SQLiteConnection CloseConnection()
        {

            SQLiteConnection sqlite_conn;
            //Create a new database connection:
            //sqlite_conn = new SQLiteConnection(@"URI=file:C:/Users/LHD/Documents/IN-MN-Standard/IN-MN-Standard/MyDatabase.sqlite");
            sqlite_conn = new SQLiteConnection("Data Source=C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/DataProxy/MyDatabase.sqlite;Version=3;New=True;Compress=True;Synchronous=Off;");
            // Close the connection:
            try
            {
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
      public static void CreateTable(SQLiteConnection conn)
      {
        
         SQLiteCommand sqlite_cmd;
         string Createsql = "CREATE TABLE SampleTable(Col1 TEXT, Col2 INT)";
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = Createsql;
         sqlite_cmd.ExecuteNonQuery();

      }

      public static void DeleteTable(SQLiteConnection conn)
      {
          Console.WriteLine("code vao day");
          SQLiteCommand sqlite_cmd;
          string Createsql = "DROP Table SampleTable;";         
          sqlite_cmd = conn.CreateCommand();
          sqlite_cmd.CommandText = Createsql;
          sqlite_cmd.ExecuteNonQuery();


      }
 
      public static void InsertData(SQLiteConnection conn, String list_connect_in, int i)
      {
         SQLiteCommand sqlite_cmd;
         //sqlite_cmd = conn.CreateCommand();
         //sqlite_cmd.CommandText = "INSERT INTO SampleTable (Col1, Col2) VALUES (" + list_connect_in + "," + Convert.ToString(i) + ");";
         //sqlite_cmd.ExecuteNonQuery();
      }
 
      public static void ReadData(SQLiteConnection conn, int i)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         //sqlite_cmd.CommandText = "SELECT * FROM SampleTable;Version=3;New=True;Compress=True;";
         sqlite_cmd.CommandText = "SELECT col1 FROM SampleTable WHERE col2 = " + Convert.ToString(i);
         sqlite_datareader = sqlite_cmd.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            string myreader = sqlite_datareader.GetString(0);
            Console.WriteLine(myreader + "=");
         }
         conn.Close();
      }
    }
}
