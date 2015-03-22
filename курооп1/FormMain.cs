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
        TableLayoutPanel table;
        List<string> Num;
        List<string> icons;
        Label label1;
        StopWatch watch;
        public FormMain()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

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

        private void FormMain_Shown(object sender, EventArgs e)
        {
            watch = new StopWatch(splitContainer1.Panel1);

            Label label = new Label();
            label.Location = new System.Drawing.Point(0, 100);
            label.Size = new System.Drawing.Size(250, 30);
            label.Font = new System.Drawing.Font("Comic Sans MS", 15.0f, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.Red;
            label.Text = "Колличество ошибок:";
            splitContainer1.Panel1.Controls.Add(label);
            label1 = new Label();
            label1.Location = new System.Drawing.Point(100, 130);
            label1.Size = new System.Drawing.Size(70, 40);
            label1.Font = new System.Drawing.Font("Comic Sans MS", 20.0f, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Red;
            splitContainer1.Panel1.Controls.Add(label1);
            label1.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();


            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;

                iconLabel.ForeColor = iconLabel.BackColor;
                iconLabel.Enabled = true;
            }
            watch.stopWatch.Start();
        }

        private void FormMain_ControlRemoved(object sender, ControlEventArgs e)
        {
            n = start.n;
            table = new TableLayoutPanel();
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
            "!", "N", ",", "k", "b", "v", "w", "z", "d",
            "?", "~", "@", "%", "-", "Y", "L", "h", "r"
                };

            Click click = new Click(label1);
            click.CheckForWin(table, watch.stopWatch, n);

            for (int i = 0; i < (n*n)/2; i++)
            {
                ParentLabel parent = new ParentLabel(table, Num, icons);
                ChildLabel child = new ChildLabel(table, Num, icons, parent.str);
                parent.AddClick(click.label_Click);
                child.AddClick(click.label_Click);
            }

            splitContainer1.Panel2.Show();
            Num = null;
            icons = null;

            Timer timer1 = new Timer();
            timer1.Interval = start.trackbar.trackBar1.Value * 1000;
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Start();
            
        }
    }
}
