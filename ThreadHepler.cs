using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSH
{
    public class ThreadHelper
    {
        public bool stop = false;

        internal SshHelper SshHelper
        {
            get => default(SshHelper);
            set
            {
            }
        }

        public void ExecThread(List<String> ip, List<string> log, List<string> pass, List<String> list, string path)
        {
            int i = 0;

            foreach (string ipadd in ip)
            {
                string logs = log[i];
                string passs = pass[i];
                if (stop == true) {
                    stop = false;
                                break;
                            }


                try
                {
                    var t = new Task(() =>
                                {

                                    SshHelper ssh = new SshHelper();//(logs, passs, list, ipadd, path);
                                    ssh.ExSSH(ipadd, logs, passs, list);
                                });





                    t.Start();
                }
                catch (Exception ex)
                {
                    LogHelper threrr = new LogHelper();
                    threrr.LogList(ipadd + " " + ex.Message, ipadd);
                }
                i++;
                }
                }

        public void StopThreads() {

            stop = true;
        }

            }

        } 



            

