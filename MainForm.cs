using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SSH
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            comboBox1.Text = comboBox1.Items[0].ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ipdbDataSet3.ip". При необходимости она может быть перемещена или удалена.
            this.ipTableAdapter1.Fill(this.ipdbDataSet3.ip);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ipdbDataSet2.ip". При необходимости она может быть перемещена или удалена.
          //  this.ipTableAdapter.Fill(this.ipdbDataSet2.ip);
            //    Properties.Settings.Default.
            dataGridView1.CellFormatting +=
            new System.Windows.Forms.DataGridViewCellFormattingEventHandler(
            this.dataGridView1_CellFormatting);

        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ipdbDataSet3.ip;
                ipTableAdapter1.Update(ipdbDataSet3);
            }
            catch (SqlException ex) { MessageBox.Show(ex.ToString()); }
        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dataGridView1.SelectedCells)
            {
                if (oneCell.Selected)
                    dataGridView1.Rows.RemoveAt(oneCell.RowIndex);
            }

            ipTableAdapter1.Update(ipdbDataSet3);
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            string filter;

            if (comboBox1.Text == "Имя")
            {

                filter = "Host";

            }
            else if (comboBox1.Text == "Группа")

            { filter = "Group_Name"; }
            else { filter = "IP"; }

            ipBindingSource1.Filter = String.Format("" + filter + " LIKE '%{0}%'", textBox1.Text);

        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            List<string> ip = new List<string>();
            List<string> list = new List<string>();
            List<string> pass = new List<string>();
            List<string> log = new List<string>();
            list.Add(richTextBox1.Text);

            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Нет команд для выполнения!");
            }
            else  {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if ((Convert.ToBoolean(row.Cells[0].Value)) == true)
                    {

                        ip.Add(Convert.ToString(row.Cells[4].Value));
                        log.Add(Convert.ToString(row.Cells[5].Value));
                        pass.Add(Convert.ToString(row.Cells[6].Value));

                    }

                }

                var path = "";

 
                ThreadHelper thr = new ThreadHelper();
                thr.ExecThread(ip, log, pass, list, path);
        


            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            ThreadHelper thr = new ThreadHelper();
            thr.StopThreads();

        }



        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form1 frm = new Form1();
            frm.Show();

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SshHelper v 0.1");
        }



        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex].Name=="Log_H" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
            if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Pass_H" && e.Value != null)
            {
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

    }
}