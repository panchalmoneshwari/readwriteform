using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textId_TextChanged(object sender, EventArgs e)
        {
            TextBox mytextBox = new TextBox();
            mytextBox.Name = "textId";
            this.Controls.Add(mytextBox);
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            TextBox mytextBox1 = new TextBox();
            mytextBox1.Name = "textName";
            this.Controls.Add(mytextBox1);
        }

        private void textLocation_TextChanged(object sender, EventArgs e)
        {
            TextBox mytextBox2 = new TextBox();
            mytextBox2.Name = "textName";
            this.Controls.Add(mytextBox2);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"D:\SnQBatch1";
            DirectoryInfo di = new DirectoryInfo(path);

            if (di.Exists)
            {
                MessageBox.Show("Folder is already exists");
            }
            else
            {
                di.Create();
                MessageBox.Show("Folder is created");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string path = @"D:\SnQBatch1\Test1.txt";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                MessageBox.Show("File already exists");
            }
            else
            {
                fi.Create();
                MessageBox.Show("File created");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\SnQBatch1\Test1.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                int id = Convert.ToInt32(textId.Text);
                string name = textName.Text;
                string location = textLocation.Text;
                bw.Write(id);
                bw.Write(name);
                bw.Write(location);
                bw.Close();
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\SnQBatch1\Test1.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int id = br.ReadInt32();
                string name = br.ReadString();
                string loc = br.ReadString();
                textId.Text = id.ToString();
                textName.Text = name;
                textLocation.Text = loc;
                br.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
    }
}
