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
    public partial class FormMain : Form
    {
        int n;
        StartMenu start;
        SplitContainer splitContainer1;
        List<string> Num;
        List<string> icons;
        public FormMain()
        {
            InitializeComponent();

            start = new StartMenu(this);

            splitContainer1 = new SplitContainer();
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new System.Drawing.Size(987, 429);
            splitContainer1.SplitterDistance = 329;
            splitContainer1.SplitterWidth = 2;
            splitContainer1.TabIndex = 0;
            this.Controls.Add(splitContainer1);
            splitContainer1.Panel1.BackColor = Color.GreenYellow;
            splitContainer1.Panel2.BackColor = Color.Green;
            
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //start.AddClick(Bt_Click);
            StopWatch watch = new StopWatch(splitContainer1.Panel1);

        }

        private void Bt_Click(object sender, EventArgs e)
        {
           /* if (((Button)sender).Name.ToString() == "4x4")
                n = 4;
            else
            {
                n = 6;
                this.Height += 150;
            }
            pictureBox1 = new TPicBox(this, n, this.ClientSize.Width / 2 - (n / 2) * 80 - 8 * (n / 2));
            start.HidePanel();
            pictureBox1.VoteNum();
            pictureBox1.ShowPic();
            Timer timer1 = new Timer();
            timer1.Interval = start.trackbar.trackBar1.Value * 1000;
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Start();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            //pictureBox1.HidePic();
        }

        private void FormMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            n = start.n;
            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            table.RowCount = n;
            table.ColumnCount = n;
            for (int i = 0; i < n; i++)
            {
                table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
                table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            }
            //table.BackColor = Color.LightSeaGreen;
            splitContainer1.SplitterDistance = 329;
            splitContainer1.Panel2.Hide();
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            splitContainer1.Panel2.Controls.Add(table);

            Num = new List<string>();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Num.Add(i.ToString() + j.ToString());
            if (n==4)
                icons = new List<string>()
                {
            "!", "N", ",", "k", "b", "v", "w", "z"
                };
            else
                icons = new List<string>()
                {
            "!", "N", ",", "k", "b", "v", "w", "z", "y",
            "?", "D", ".", "T", "q", "a", "o", "s", "r"
                };

            Click click = new Click();

            for (int i = 0; i < (n*n)/2; i++)
            {
                ParentLabel parent = new ParentLabel(table, Num, icons);
                ChildLabel child = new ChildLabel(table, Num, icons, parent.str);
                parent.AddClick(click.label_Click);
                child.AddClick(click.label_Click);
            }

            splitContainer1.Panel2.Show();
            
        }
    }
}
