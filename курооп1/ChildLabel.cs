using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class ChildLabel: ParentLabel
    {
        protected Label firstClicked1 = null;
        public ChildLabel(TableLayoutPanel table, List<string> Num, List<string> icons, String str)
            : base(table, Num, icons)
        {
            label.Text = str;
        }
    }
}
