using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class TPicBox
    {
       PictureBox[,] pictureBox;
       PictureBox P1;
       bool b;
       int y = 20;
       int n;
       int error;
       Label label1;
       Form F;
       int count=0;

       public TPicBox(Form F, int n, int x)
       {
           this.n = n;
           this.F = F;
           int St_x = x;
           label1 = new Label();
           pictureBox = new PictureBox[n, n];
           for (int i = 0; i < n; i++)
           {
               for (int j = 0; j < n; j++)
               {
                   //Create PictureBox
                   pictureBox[i, j] = new System.Windows.Forms.PictureBox();
                   pictureBox[i, j].Location = new System.Drawing.Point(x, y);
                   pictureBox[i, j].Size = new System.Drawing.Size(80, 80);
                   pictureBox[i, j].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                   pictureBox[i, j].Name = "pictureBox" + i.ToString();
                   pictureBox[i, j].Click += new EventHandler(onClick);
                   pictureBox[i, j].TabIndex = i;
                   pictureBox[i, j].TabStop = false;
                   pictureBox[i, j].BackColor = System.Drawing.Color.DarkGray;
                   pictureBox[i, j].Enabled = false;
                   F.Controls.Add(pictureBox[i, j]);
                   x += 90;
               }
               x = St_x;
               y += 90;
           }
           //Create Label
           Label label11 = new Label();
           label11.Location = new System.Drawing.Point(0, 100);
           label11.Size = new System.Drawing.Size(250, 30);
           label11.Font = new System.Drawing.Font("Comic Sans MS", 15.0f, FontStyle.Bold);
           label11.ForeColor = Color.Red;
           label11.Text = "Колличество ошибок:";
           F.Controls.Add(label11);
           label1.Location = new System.Drawing.Point(100, 130);
           label1.Size = new System.Drawing.Size(70, 40);
           label1.Font = new System.Drawing.Font("Comic Sans MS", 20.0f, FontStyle.Bold);
           label1.ForeColor = Color.Red;
           F.Controls.Add(label1);
           label1.Text = error.ToString();
       }

       public void VoteNum()
       {
           Random random = new Random();
           List<string> list;
           if (n==4)
                list = new List<string> 
                 {
                    "1","1","2","2","3","3","4","4",
                    "5","5","6","6","7","7","8","8"
                 };
           else
                list = new List<string> 
                 {
                    "1","1","2","2","3","3","4","4",
                    "5","5","6","6","7","7","8","8",
                    "9","9","10","10","11","11","12","12",
                    "13","13","14","14","15","15","16","16",
                    "17","17","18","18"
                 };

           foreach (PictureBox button in pictureBox)
           {
               int randomNum = random.Next(list.Count);
               button.Tag = list[randomNum];
               list.RemoveAt(randomNum);
           }    
       }

       private void onClick(object sender, EventArgs e) 
        {
            string currFile = Environment.CurrentDirectory.ToString() + "\\images\\" + ((PictureBox)sender).Tag.ToString() + ".png";
            ((PictureBox)sender).Load(currFile);
            //((PictureBox)sender).Image = Properties.Resources._1;

            if ((b == true) && (P1.Tag.ToString() != ((PictureBox)sender).Tag.ToString()))
            {
                error++;
                label1.Text = error.ToString();
                DateTime Tthen = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while (Tthen.AddSeconds(0.3) > DateTime.Now);
                //((PictureBox)sender).Enabled = true;
                P1.Enabled = true;
                ((PictureBox)sender).Image = null;
                P1.Image = null;
                b = false;
            }
            else
            {
                if ((b == true))
                {
                    ((PictureBox)sender).Enabled = false;
                    //P1.Enabled = false;
                    b = false;
                    P1 = null;
                    count++;
                    if (count == n * n / 2)
                    {
                        //stopWatch.Stop();
                        /*string message = "Закрыть?";
                        string caption = "Congratulation!";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            F.Close();
                        }
                        else
                        {
                            Application.Restart();
                            F.Show();
                        }*/
                        FormRes form1 = new FormRes();
                        form1.error = error;
                        //form1.time = stopWatch.Elapsed.Minutes + ":" + stopWatch.Elapsed.Seconds;
                        form1.ShowDialog();
                    }
                }
                else
                {
                    b = true;
                    ((PictureBox)sender).Enabled = false;
                    P1 = ((PictureBox)sender);
                }
            }
        }

       public void ShowPic()
       {
           for (int i = 0; i < n; i++)
               for (int j = 0; j < n; j++)
               {
                   string currFile = Environment.CurrentDirectory.ToString() + "\\images\\" + pictureBox[i, j].Tag.ToString() + ".png";
                   pictureBox[i, j].Load(currFile);

               }
       }

       public void HidePic()
       {
           for (int i = 0; i < n; i++)
               for (int j = 0; j < n; j++)
               {
                   pictureBox[i, j].Image = null;
                   pictureBox[i, j].Enabled = true;
               }
           //stopWatch.Start();
       }
    }
}
