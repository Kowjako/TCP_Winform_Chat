using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBubble
{
    public class TransparentLabel : System.Windows.Forms.Label
    {
        public TransparentLabel()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.TextChanged += TransparentLabel_TextChanged;
        }

        void TransparentLabel_TextChanged(object sender, System.EventArgs e)
        {
            this.ForceRefresh();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;  
                return parms;
            }
        }
        public void ForceRefresh()
        {
            this.UpdateStyles();
        }
    }
}
