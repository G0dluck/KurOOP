using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Click
    {
        Label firstClicked;
        Label secondClicked;
        int error = 0;
        Label label;
        Timer timer1 = new Timer();
        TableLayoutPanel table;
        System.Diagnostics.Stopwatch stopWatch;
        int n;

        public Click(Label label)
        {
            timer1.Interval = 500;
            timer1.Tick += new EventHandler(timer1_Tick);
            this.label = label;
        }

        public void label_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;
            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == System.Drawing.Color.Black)
                    return;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = System.Drawing.Color.Black;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = System.Drawing.Color.Black;

                CheckForWin(table, stopWatch, n);

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
                error++;
                label.Text = error.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        public void CheckForWin(TableLayoutPanel table, System.Diagnostics.Stopwatch stopWatch, int n)
        {
            if (this.table == null)
            {
                this.table = table;
                this.stopWatch = stopWatch;
                this.n = n;
                return;
            }

            foreach (Control control in table.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
            }

            stopWatch.Stop();
            FormRes form = new FormRes();
            form.error = error;
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            form.time = String.Format("{0:00}:{1:00}.{2:00}",
                ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            form.n = n;
            form.ShowDialog();
        }
    }
}
