using simulation02;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace simulation2
{
    class NodeConect:Node
    {
        public int R = 100;//range of MN
        public static String[] MN_PORT = new String[Simulation.ListNodeMN.Count];
        public static String[] MN_NAME = new String[Simulation.ListNodeMN.Count];
        public static String[] MN_ID = new String[Simulation.ListNodeMN.Count];
        public static String[] MN_IP = new String[Simulation.ListNodeMN.Count];

        public String filePath = "";
        public void conectNode()    // Thêm đường dẫn các file .bat vào file all-bat để khởi động all in, mn
        {          
            Console.WriteLine(Simulation.ListNodeMN.Count + Simulation.ListNodeIN.Count + "-111");
            for (int i = 0; i < Simulation.ListNodeIN.Count; i++)
            {
                filePath = filePath + "\n start /D \"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i + "/x86_64/\" start.bat \n ";
            }
            for (int i = 0; i < Simulation.ListNodeMN.Count; i++)
            {
                filePath = filePath + "\n start /D \"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/\" start.bat \n ";
            }
            for(int i = 0; i < Simulation.ListNodeMN.Count; i++)
            {
                for (int j = 0; j < Simulation.ListNodeIN.Count; j++)
                {
                    int weight = Convert.ToInt32(Math.Pow(Simulation.ListNodeMN[i].Center.X - Simulation.ListNodeMN[j].Center.X, 2) + Math.Pow(Simulation.ListNodeMN[i].Center.Y - Simulation.ListNodeMN[j].Center.Y, 2));
                        Console.WriteLine(weight + " location" + R);
                        if (weight < R*R)
                        {
                        //MN_PORT[i] = MN_PORT[i] + " " + Simulation.ListNodeIN[j].Node_Port;
                        //MN_NAME[i] = MN_NAME[i] + " " + Simulation.ListNodeIN[j].Node_Name;
                        //MN_ID[i] = MN_ID[i] + " " + Simulation.ListNodeIN[j].Node_Id;
                        //MN_IP[i] = MN_IP[i] + " " + Simulation.ListNodeIN[j].Node_Ip;                     
                        Console.WriteLine(i + "chi so");                       
                        }
                }
                Console.WriteLine(MN_PORT[i] + "Chỉ số mnport out");
            }   
            for (int i = 0; i < Simulation.ListNodeMN.Count - 1; i++)
            {
                for (int j = Simulation.ListNodeMN.Count - 1; j > 0; j--)
                {
                    if (i < j)
                    {
                        int weight = Convert.ToInt32(Math.Pow(Simulation.ListNodeMN[i].Center.X - Simulation.ListNodeMN[j].Center.X, 2) + Math.Pow(Simulation.ListNodeMN[i].Center.Y - Simulation.ListNodeMN[j].Center.Y, 2));
                        Console.WriteLine(weight + " location" + R);
                        if (weight < R*R)
                        {
                            Console.WriteLine(InRange(this) + " = ");
                            //MN_PORT[j] = MN_PORT[j] + " " + Simulation.ListNodeMN[i].Node_Port;
                            //MN_NAME[j] = MN_NAME[j] + " " + Simulation.ListNodeMN[i].Node_Name;
                            //MN_ID[j] = MN_ID[j] + " " + Simulation.ListNodeMN[i].Node_Id;
                            //MN_IP[j] = MN_IP[j] + " " + Simulation.ListNodeMN[i].Node_Ip;
                            //filePath = filePath + "\n start /D \"C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/\" start.bat \n ";
                            Console.WriteLine(i + "chi so"); 
                        }
                    }
                }
            }
            //config cho từng MN
            //for(int i = 0; i < Simulation.ListNodeMN.Count; i++)
            //{
            //    doConfig doCofig = new doConfig();
            //    doCofig.doCofig(Simulation.ListNodeMN[i]);
            //}
            //Tạo file run-new-all.bat chứa tất cả các file bat khác
            String filePathRunAll = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/run-all.bat";
            String fileNewPathRunAll = "C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/run-new-all.bat";           
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
