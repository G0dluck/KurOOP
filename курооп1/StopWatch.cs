using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class StopWatch
    {
       public Stopwatch stopWatch;
       System.Windows.Forms.Label labelTime;
       private System.Windows.Forms.Timer timerMain;

       public StopWatch(Panel Form)
        {
            stopWatch = new Stopwatch();
            timerMain = new System.Windows.Forms.Timer();
            timerMain.Enabled = true;
            timerMain.Interval = 50;
            timerMain.Tick += new System.EventHandler(this.timerMain_Tick); 
            labelTime = new System.Windows.Forms.Label();
            labelTime.Font = new System.Drawing.Font("Comic Sans MS", 18.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            labelTime.ForeColor = System.Drawing.Color.Green;
            labelTime.Location = new System.Drawing.Point(0, 56);
            labelTime.Name = "labelTime";
            labelTime.Size = new System.Drawing.Size(208, 32);
            labelTime.TabIndex = 1;
            labelTime.Text = "00:00.00";
            Form.Controls.Add(labelTime);
        }

        private void timerMain_Tick(System.Object sender, 
                                    System.EventArgs e)
        {
            // When the timer is running, update the displayed timer 
            // value for each tick event.

            if (stopWatch.IsRunning)
            {
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                labelTime.Text = String.Format("{0:00}:{1:00}.{2:00}", 
                    ts.Minutes, ts.Seconds, 
                    ts.Milliseconds/10);
            }
            }

    }

}
