using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Trackbar
    {
        public System.Windows.Forms.TrackBar trackBar1;
        System.Windows.Forms.TextBox textBox1;

        public Trackbar(Panel panel)
        {
             textBox1 = new System.Windows.Forms.TextBox();
             trackBar1 = new System.Windows.Forms.TrackBar();

             // TextBox for TrackBar.Value update.
             textBox1.Location = new System.Drawing.Point(240, panel.Height - 37);
             textBox1.Size = new System.Drawing.Size(48, 20);

             // Set up the TrackBar.
             trackBar1.Location = new System.Drawing.Point(8, panel.Height - 45);
             trackBar1.Size = new System.Drawing.Size(224, 45);
             trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);

             trackBar1.Maximum = 10;
             trackBar1.Minimum = 1;
             trackBar1.Value = 5;
             textBox1.Text = "" + trackBar1.Value + " сек.";
             trackBar1.TickFrequency = 1;
             trackBar1.LargeChange = 2;
             trackBar1.SmallChange = 5;
            panel.Controls.Add(trackBar1);
            panel.Controls.Add(textBox1);
        }

        private void trackBar1_Scroll(object sender, System.EventArgs e)
        {
            // Display the trackbar value in the text box.
            textBox1.Text = "" + trackBar1.Value + " сек.";
        }
    }
}
