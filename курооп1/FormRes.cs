using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormRes : Form
    {
        string currFile = Environment.CurrentDirectory.ToString() + "\\result4.txt";
        public int error;
        public string time;
        public FormRes()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(currFile))
                listBox1.Items.Add("Файл не найден!");
            else
            {
                using (System.IO.StreamReader sr = System.IO.File.OpenText(currFile))
                {
                    string s = "";
                    listBox1.Items.Add("Имя" + "        " + "Ошибки" + "        " + "Время");
                    while ((s = sr.ReadLine()) != null)
                    {
                        listBox1.Items.Add(s);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(currFile))
            {
                sw.WriteLine(textBox1.Text + "        " + error + "        " + time);
            }
            this.Close();
        }
    }
}
