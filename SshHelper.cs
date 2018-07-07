using System;
using System.Collections.Generic;
using Renci.SshNet;


namespace SSH
{
    class SshHelper
    {
        internal LogHelper LogHelper
        {
            get => default(LogHelper);
            set
            {
            }
        }

        public void ExSSH(string ip, string log, string pass, List<String> list)
        {

                using (var conninfo = new PasswordConnectionInfo(ip, log, pass))
                {
                    Renci.SshNet.SshClient client = new Renci.SshNet.SshClient(conninfo);
                try
                {
                    client.Connect();
                }
                catch (Exception ex)
                {
                    LogHelper logs = new LogHelper();
                    logs.LogList(ip + " "+ex.Message,ip);

                    System.Threading.Thread.CurrentThread.Abort();
                }
                    Renci.SshNet.ShellStream stream = client.CreateShellStream("ssh", 180, 324, 1800, 3600, 8000);
                    foreach (string command in list)
                    { 
                        
                        stream.Write(command + "\n");
                        System.Threading.Thread.Sleep(1000);
                        string temp_string = stream.Read();  
                    LogHelper logs = new LogHelper();
                    logs.LogList(temp_string,ip);
                    }
                    client.Disconnect();

            }
        }
    }

}