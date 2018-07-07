using System;
using System.Windows.Forms;

namespace SSH
{
    public partial class Form1 : Form
    {
        string folderpath = Properties.Settings.Default.text;

        public Form1()
        {
            InitializeComponent();

           textBox1.Text = Properties.Settings.Default.text;

            if (textBox1.Text == "")
            {

                textBox1.Text = Environment.CurrentDirectory;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.text = textBox1.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void Form1_Close(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
