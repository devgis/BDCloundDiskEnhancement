using System;
using System.Collections.Generic;
using System.Threading;

namespace BDCloundDiskEnhancement
{
    class Program
    {
        static List<string> processNames = new List<string> { "baidunetdisk", "baidunetdiskhost" };
        static string startExePath = @"C:\Users\Administrator\AppData\Roaming\baidu\BaiduNetdisk\BaiduNetdisk.exe";
        const int StartInterval = 5000; //结束到启动间隔毫秒
        const int RestartInterval = 600000; //间隔毫秒
        static void Main(string[] args)
        {
            Console.WriteLine("Started!");
            int i = 1;
            while (true)
            {
                try {
                    //kill old
                    foreach (var p in processNames)
                    {
                        KillProcess(p);
                    }

                    Thread.Sleep(StartInterval);
                    //start new
                    System.Diagnostics.Process.Start(startExePath);
                    Console.WriteLine($"RestartedStarted{i}");

                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error:"+ex.Message);
                }
                Thread.Sleep(RestartInterval);
            }
        }

        static void KillProcess(string processName)
        {
            System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName(processName);
            foreach (System.Diagnostics.Process p in process)
            {
                p.Kill();
            }
        }
    }
}
