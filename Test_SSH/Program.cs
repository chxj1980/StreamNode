﻿using System;
using Renci.SshNet;

namespace Test_SSH
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            using (var sshClient = new SshClient("192.168.2.43", 22, "root", "cdtnb..."))

            {
                sshClient.Connect();
                /*using (var cmd = sshClient.CreateCommand("/root/Server/MediaServer"))
                {*/
                try
                {
                    var stream = sshClient.CreateShellStream("input", 0, 0, 0, 0, 1000000);
                    stream.WriteLine("/root/Server/MediaServer");
                    while (stream.CanRead)
                    {
                        var output = stream.ReadLine(new TimeSpan(0, 0, 0, 5, 0));
                        Console.WriteLine(output);
                    }

                    /*ShellStream ss= new ShellStream();
                     var res=cmd.Execute();
                    Console.Write(res);*/
                    Console.WriteLine("end");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //}
            }
        }
    }
}