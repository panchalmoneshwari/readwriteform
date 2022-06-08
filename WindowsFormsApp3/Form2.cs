﻿using System;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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

        private void Write_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\SnQBatch1\Test1.txt", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                int id = Convert.ToInt32(textid.Text);
                string name = textname.Text;
                string location = textlocation.Text;
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

        private void Read_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"D:\SnQBatch1\Test1.txt", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int id = br.ReadInt32();
                string name = br.ReadString();
                string loc = br.ReadString();
                textid.Text = id.ToString();
                textname.Text = name;
                textlocation.Text = loc;
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
