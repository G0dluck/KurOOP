using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class StartMenu
    {
        private Panel panel;
        public int n;
        Button bt4, bt6;
        bool exitF = false;
        public Trackbar trackbar;
        Form form;
        public StartMenu(Form form)
        {
            this.form = form;
            panel = new Panel();
            panel.Location = new System.Drawing.Point(form.ClientSize.Width / 2 - form.ClientSize.Width / 4, form.ClientSize.Height / 2 - form.ClientSize.Height / 4);
            panel.Size = new System.Drawing.Size(form.ClientSize.Width/2, form.ClientSize.Height/2);
            panel.BackColor = Color.MediumSeaGreen;
            //panel.BackgroundImage = Image.FromFile(Environment.CurrentDirectory.ToString() + "\\images\\ramka.png");
            //panel.BackgroundImageLayout = ImageLayout.Stretch;
            form.Controls.Add(panel);
            

            bt4 = new Button();
            bt4.Location = new System.Drawing.Point(panel.Width/2-40, panel.Height/2 - 15);
            bt4.Size = new System.Drawing.Size(80, 20);
            bt4.Name = "4x4";
            bt4.Text = "Поле 4x4";
            bt4.BackColor = Color.Transparent;
            bt4.Click += new EventHandler(Bt_Click);
            panel.Controls.Add(bt4);

            bt6 = new Button();
            bt6.Location = new System.Drawing.Point(panel.Width / 2-40, panel.Height / 2 + 15);
            bt6.Size = new System.Drawing.Size(80, 20);
            bt6.BackColor = Color.Transparent;
            bt6.Name = "6x6";
            bt6.Text = "Поле 6x6";
            bt6.Click += new EventHandler(Bt_Click);
            panel.Controls.Add(bt6);
  
            trackbar = new Trackbar(panel);
            
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name.ToString() == "4x4")
                n = 4;
            else
            {
                n = 6;
            }
            HidePanel();
            form.Controls.RemoveAt(0);
        }

        public void HidePanel()
        {
            bt4.Enabled = false;
            bt6.Enabled = false;
            Timer timer1 = new Timer();
            timer1.Interval = 1;
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Start();
            timer1.Enabled = true;
            while (exitF == false)
            {
                Application.DoEvents();
            }
            panel.Hide();
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panel.Width != 0)
                panel.Width-=8;
            else
                exitF = true;
        }
    }
}
