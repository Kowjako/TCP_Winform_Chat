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
using System.IO;

namespace ChatBubble
{
    public partial class SendFile : UserControl
    {
        public SendFile()
        {
            InitializeComponent();
            SetStyle(ControlStyles.Opaque, true);
        }
        public string FileName
        {
            get
            {
                return label2.Text;
            }
            set
            {
                if (value.Contains("pdf")) pb1.Image = Properties.Resources.pdf;
                if (value.Contains("doc") || value.Contains("docx")) pb1.Image = Properties.Resources.word;
                if (value.Contains("xls") || value.Contains("xlsx")) pb1.Image = Properties.Resources.xlsx;
                if (value.Contains("mp4")) pb1.Image = Properties.Resources.mp4;
                if (value.Contains("mp3")) pb1.Image = Properties.Resources.mp3;
                if (value.Contains("ppt") || value.Contains("pptx")) pb1.Image = Properties.Resources.ppt;
                label2.Text = value;
            }
        }
        public string FileSize
        {
            get
            {
                return label3.Text;
            }
            set
            {
                label3.Text = Ext.ToPrettySize(Convert.ToInt64(value));
            }
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
        private void PictureBox1_get(object sender, EventArgs e)
        {
            Process.Start(filename);
        }
        public static FileStream fs { private get; set; }
        public string OpenFileDialog()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Files | *.pdf; *.xlsx; *.doc; *.docx; *.ppt; *.mp3; *.mp4;";
            fd.Title = "Choose a file";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream file = (FileStream)fd.OpenFile();
                if (file != null)
                    return file.Name;
            }
            return null;
        }
        public string SetFile()
        {
            string path = OpenFileDialog();
            if (path != null) return path;
            return null;
        }
        public void ResetStream()
        {
            fs.Close();
            fs = null;
        }
        string filename = "";
        public void SetFile(string path)
        {
            filename = path;
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
