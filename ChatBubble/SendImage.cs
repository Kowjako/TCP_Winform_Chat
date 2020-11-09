using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace ChatBubble
{
    public partial class SendImage : UserControl
    {
        public SendImage()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
        }
        public string OpenFileDialog()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Photos | *.jpg; *.jpeg; *.png *.bmp";
            fd.Title = "Choose a file";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream file = (FileStream)fd.OpenFile();
                if (file != null)
                    return file.Name;
            }
            return null;
        }
        public void SetImage(string path)
        {
            pictureBox1.Image = Image.FromFile(path);
        }
        public Color PhotoColor
        {
            get
            {
                return panel1.BackColor;
            }
            set
            {
                panel1.BackColor = value;
            }
        }
        public string SetImage()
        {
            string path = OpenFileDialog();
            if (path != null) 
            pictureBox1.Image = Image.FromFile(path);
            return path;
        }
        TransparentLabel time = new TransparentLabel();
        public void AddTimeLabelSender()
        {
            time.BackColor = System.Drawing.Color.Transparent;
            panel1.BackColor = Color.White;
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
            time.Left = 5;
            time.Top = panel1.Height + 5;
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
