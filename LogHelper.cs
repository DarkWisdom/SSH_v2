using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SSH
{
    class LogHelper
    {

        public void LogList(string stream,string ip)
        {

            (Application.OpenForms[0] as MainForm).richTextBox2.Invoke((MethodInvoker)(delegate () { (Application.OpenForms[0] as MainForm).richTextBox2.AppendText(stream+"\n"); }));

            string path = Properties.Settings.Default.text + "\\";
           
            File.WriteAllText(path+" "+ip+" "+ System.DateTime.Now.ToString("dd.MM.yyyy")+ ".txt", stream, Encoding.UTF8);
        }

    }
}
