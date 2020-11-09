using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ChatBubble
{
    public partial class SendVideo : UserControl
    {
        public SendVideo()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
        }
        TransparentLabel time = new TransparentLabel();
        public void AddTimeLabelSender()
        {
            time.BackColor = System.Drawing.Color.Transparent;
            panel1.BackColor = Color.White;
            label1.BackColor = Color.White;
            pictureBox1.BackColor = Color.White;
            time.Left = panel1.Width - 35;
            time.Top = panel1.Height + 5;
            time.Text = DateTime.Now.ToShortTimeString();
            time.Font = new Font("Segoe UI", 9);
            time.ForeColor = Color.DarkRed;
            this.Controls.Add(time);
        }
        public void AddTimeLabelGetter()
        {
            time.BackColor = System.Drawing.Color.Transparent;
            panel1.BackColor = Color.SkyBlue;
            label1.BackColor = Color.SkyBlue;
            pictureBox1.BackColor = Color.SkyBlue;
            time.Left = 5;
            time.Top = panel1.Height + 5;
            time.Text = DateTime.Now.ToShortTimeString();
            time.Font = new Font("Segoe UI", 9);
            time.ForeColor = Color.DarkRed;
            this.Controls.Add(time);
        }
        public void SetFile(string path)
        {
            filename = path;
        }
        private string filename;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(filename);
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
