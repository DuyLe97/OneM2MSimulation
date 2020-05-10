using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;

namespace simulation2
{
    class Proxy
    {
        public static List<String> List_des = new List<String>();
        public static string url = "";
        public static string address_MN = "";
        public static async Task<HttpResponseMessage> Fowarding(HttpListenerContext om2mMessage)
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Test: received RECV: ", om2mMessage.Request.AcceptTypes);
                MappingReq(om2mMessage.Request);
                //Console.WriteLine("TEST URL MN " + om2mMessage.Request.Url);
                //address_MN = Convert.ToString(om2mMessage.Request.Url);
                /*
                 * TODO: Hàm chuẩn bị bản tin và gửi nó đi.
                  */
                //httpClient.DefaultRequestHeaders.Add(); // thêm các header
                //httpClient.PostAsync(); // Có thể là Get, post,...
                // cách khác, dùng sendAsynnc. 
                HttpMethod method = new HttpMethod("GET");
                //lấy những node kết nối vs IN, so sánh port của mn gửi ts vs mn đang connect trên simulator để forword bản tin
                //String uri = "";
                String url = "http://127.0.0.1:8080/~/in-cse"; // URI of IN, ex: http://127.0.0.1:8080/~/in-cse 
                List<String> list_mn = new List<String>();
                //for (int i = 0; i < Simulation.getInstance().list_node_to_IN.Count; i++)
                //{
                //    list_mn.Add(Simulation.getInstance().list_node_to_IN[i].Node_Port);
                //    Console.WriteLine("port cua simulator" + Simulation.getInstance().list_node_to_IN[i].Node_Port);
                //}
                //int pos = list_mn.IndexOf(address_MN);
                //Console.WriteLine("port cua proxy " + address_MN);
                //if (pos > -1)
                //    url = "";

                HttpRequestMessage request = new HttpRequestMessage(method, url);
                //request.Method = "GET";
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("X-M2M-Origin", "admin:admin");
                Console.WriteLine("@@@@@@@@@@@ " + List_des.Count + " @@@@@@@@@@@");
                httpClient.DefaultRequestHeaders.Add("Accept", "application/xml");
                httpClient.DefaultRequestHeaders.Add("X-M2M-Origin", "admin:admin");
                //request.Headers.Add
                //request.Content.ReadAsStringAsync()
                //httpClient.SendAsync(request);

                HttpResponseMessage response = await httpClient.GetAsync(url);
                Console.WriteLine("Sending to IN is done respond code:" + response.StatusCode);

                return response;

                /*
                 Lấy được response rồi thì truyền nó sang cho response của http server
                 */
            }
        }

        public static void MappingReq(HttpListenerRequest request)
        {
            //GET all header BUT pnly something need - todo read a om2m format ty=16 message

            int loop1, loop2;
            NameValueCollection coll;
            // Load Header collection into NameValueCollection object.
            coll = request.Headers;
            //---------------------------
            //Xử lý body bản tin request tới
            System.IO.Stream body = request.InputStream;
            System.Text.Encoding encoding = request.ContentEncoding;
            System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
            string string_body = reader.ReadToEnd();
            //Console.WriteLine(cd);
            //String cd = Convert.ToString(bodyText);
            //--------------------------
            // Put the names of all keys into a string array.
            String[] key = coll.AllKeys;
            for (loop1 = 0; loop1 < key.Length; loop1++)
            {
                // Get all values under this key.
                String[] value = coll.GetValues(key[loop1]);
                for (loop2 = 0; loop2 < value.Length; loop2++)
                {
                    //Bản tin nhận từ Postman
                    Console.WriteLine(key[loop1] + ":" + value[loop2]);
                    //if (key[loop1] == "RURL") List_des.Add(value[loop2]);
                    if (key[loop1] == "RURL") url = value[loop2];
                    if (key[loop1] == "PORT") address_MN = value[loop2];
                }
            }
            Console.WriteLine("--------" + List_des[0]);
            reader.Close();
        }

        private static async Task<String> Server()
        {
            Console.WriteLine("Run into Server()");

            var listener = new HttpListener();
            //listener.Prefixes.Add("http://*:8081/");
            listener.Prefixes.Add("http://127.0.0.1:8081/");
            listener.Start();

            Console.WriteLine("Listening...");
            int Max_Connection = 10;
            for (int i = 0; i < Max_Connection; i++)
            {
                while (true)
                {
                    //HttpListenerContext ctx = await listener.GetContextAsync();
                    var ctx = listener.GetContext();
                    HttpResponseMessage response = await Fowarding(ctx);
                    //Response nhận từ IN trả về
                    String test = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("-------------" + test + "-------------");
                    byte[] b = Encoding.UTF8.GetBytes(test);
                    ctx.Response.ContentLength64 = b.Length;
                    ctx.Response.OutputStream.Write(b, 0, b.Length);
                    ctx.Response.OutputStream.Close();
                    ctx.Response.Close();
                }
            }
            return "Done";
            //listener.Close();
        }
        public static void Start()
        {
            Console.WriteLine("Start Proxy");
            //string uri = "http://127.0.0.1:8080/"; // proxy PORT  eg:http://*:xxxx/
            Server();

            //Console.ReadKey();
        }
    }
}
