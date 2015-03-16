using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ParentLabel
    {
        Random rd = new Random();
        public String str;
        protected Label label;

        public ParentLabel(TableLayoutPanel table, List<string> Num, List<string> icons)
        {
            int Loc;

            label = new Label();
            label.Dock = System.Windows.Forms.DockStyle.Fill;
            label.Font = new System.Drawing.Font("Webdings", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            label.Location = new System.Drawing.Point(404, 383);
            label.Size = new System.Drawing.Size(125, 127);
            if (this is ChildLabel)
            {
                Loc = rd.Next(Num.Count);
            }
            else
            {
                int numran = rd.Next(icons.Count);
                str = icons[numran].ToString();
                icons.RemoveAt(numran);
                Loc = rd.Next(Num.Count);
            }
            label.Name = "label" + Loc;
            label.Text = str;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //label.Click += new System.EventHandler(this.label1_Click);
            int col = Convert.ToInt32(Num[Loc][0].ToString());
            int row = Convert.ToInt32(Num[Loc][1].ToString());
            table.Controls.Add(label, col, row);
            Num.RemoveAt(Loc);
        }
    }
}
