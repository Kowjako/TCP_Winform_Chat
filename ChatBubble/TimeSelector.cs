using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBubble
{
    public partial class TimeSelector : UserControl
    {
        public TimeSelector()
        {
            InitializeComponent();
        }
        public string Body
        {
            get
            {
                return LabelRoundCorner.Text;
            }
            set
            {
                LabelRoundCorner.Text = value;
            }
        }

        private void TimeSelector_Load(object sender, EventArgs e)
        {

        }
    }
}
