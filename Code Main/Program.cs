using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simulation2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void tess()
        {
            Action myaction = () =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(Simulation.getInstance());
            };
            Task task = new Task(myaction);
            task.Start();   // tạo và chạy thread
            Thread.Sleep(2000);
        }
        public async static void tess2()
        {
            Action myaction = () =>
            {
                Thread pro = new Thread(Proxy.Start);
                pro.Start();
                Thread.Sleep(2000);
            };
            Task task = new Task(myaction);
            task.Start();   // tạo và chạy thread
            await task;
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Simulation.getInstance());
        }
    }
}

