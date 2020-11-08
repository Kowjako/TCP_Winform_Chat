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
    public partial class GetBubble : UserControl
    {
        public GetBubble()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
        }
        public string Body
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        public Color MsgColor
        {
            get
            {
                return label1.BackColor;
            }
            set
            {
                label1.BackColor = value;
            }
        }
        private Font font = UserControl.DefaultFont;
        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                label1.Font = value;
            }
        }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                label1.BackColor = value;
            }
        }
        TransparentLabel time = new TransparentLabel();
        public void AddTimeLabel()
        {
            time.BackColor = System.Drawing.Color.Transparent;
            time.Left = label1.Left;
            time.Top = label1.Height + 5;
            time.Text = DateTime.Now.ToShortTimeString();
            time.Font = new Font("Segoe UI", 9);
            time.ForeColor = Color.DarkRed;
            this.Controls.Add(time);
        }
        private const int WS_EX_TRANSPARENT = 0x20;

        private int opacity = 0;
        [DefaultValue(50)]
        public int Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("value must be between 0 and 100");
                this.opacity = value;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 255 / 100, this.BackColor)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            base.OnPaint(e);
        }
    }
}
