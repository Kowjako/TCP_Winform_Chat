using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ChatBubble
{
    public partial class SendImage : UserControl
    {
        public SendImage()
        {
            InitializeComponent();
        }
        public string OpenFileDialog()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose a file";
            fd.ShowDialog();
            FileStream file = (FileStream)fd.OpenFile();
            return file.Name;
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
            pictureBox1.Image = Image.FromFile(path);
            return path;
        }
        Label time = new Label();
        public void AddTimeLabelSender()
        {
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
            panel1.BackColor = Color.SkyBlue;
            time.Left = 5;
            time.Top = panel1.Height + 5;
            time.Text = DateTime.Now.ToShortTimeString();
            time.Font = new Font("Segoe UI", 9);
            time.ForeColor = Color.DarkRed;
            this.Controls.Add(time);
        }
    }
}
