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
    class doConfig:InfoNode
    {
        public void doCofig()
        {
            CreateNode creNode = CreateNode.GetInstance();
            InfoNode infoNode = InfoNode.GetInstance();
            String remoteCsePort_string = "org.eclipse.om2m.remoteCsePort_string=";
            String cseBaseAddress_string = "org.eclipse.om2m.cseBaseAddress_string=";
            String cseBaseName = "org.eclipse.om2m.cseBaseName=";
            String cseBaseId ="org.eclipse.om2m.cseBaseId=";
            String remoteCseId_string = "org.eclipse.om2m.remoteCseId_string=";
            String remoteCseName_string = "org.eclipse.om2m.remoteCseName_string=";
            String cseMNPort = "org.eclipse.equinox.http.jetty.http.port=";

            //Config IN
            for (int i = 0; i < Simulation.ListNodeIN.Count; i++)
            {
                StreamReader readerIN = new StreamReader("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i + "/x86_64/configuration/config.ini");
                String contentIN = readerIN.ReadToEnd();
                //Console.WriteLine(contentIN);
                readerIN.Close();
                StreamWriter writerIN = new StreamWriter("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/in-cse-" + i + "/x86_64/configuration/config.ini");

                contentIN = Regex.Replace(contentIN, cseBaseName, cseBaseName + Simulation.ListNodeIN[i].Node_Name);
                contentIN = Regex.Replace(contentIN, cseBaseId, cseBaseId + Simulation.ListNodeIN[i].Node_Id);
                writerIN.Write(contentIN);
                writerIN.Close();
                //Console.WriteLine(contentIN);
            }
            //Chỉnh config MN
            for (int i = 0; i < Simulation.ListNodeMN.Count; i++)
            {
                StreamReader reader = new StreamReader("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/configuration/config.ini");
                String content = reader.ReadToEnd();
                //Console.WriteLine(content);
                reader.Close();
                StreamWriter writer = new StreamWriter("C:/Users/eduyduy/Documents/SIMULATOR/IN-MN-Standard/mn-cse-" + i + "/x86_64/configuration/config.ini");

            //    content = Regex.Replace(content, remoteCsePort_string, remoteCsePort_string + " " + NodeConect.MN_PORT[i]);
            //    content = Regex.Replace(content, cseBaseAddress_string, cseBaseAddress_string + " " + NodeConect.MN_IP[i]);
             //   content = Regex.Replace(content, cseBaseName, cseBaseName + Simulation.ListNodeMN[i].Node_Name);
            //    content = Regex.Replace(content, cseBaseId, cseBaseId + " " + Simulation.ListNodeMN[i].Node_Id);
            //    content = Regex.Replace(content, remoteCseId_string, remoteCseId_string + " " + NodeConect.MN_ID[i]);
            //    content = Regex.Replace(content, remoteCseName_string, remoteCseName_string + " " + NodeConect.MN_NAME[i]);
                content = Regex.Replace(content, cseMNPort, cseMNPort + Simulation.ListNodeMN[i].Node_Port);
                writer.Write(content);
                writer.Close();
            //  Console.WriteLine(content);
            }             
            }
        }
    }
        
    
