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
        }
        public string FileName
        {
            get
            {
                return label2.Text;
            }
            set
            {
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
        private void PictureBox1_get(object sender, EventArgs e)
        {
            Process.Start(filename);
        }
        public static FileStream fs { private get; set; }
        public string OpenFileDialog()
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Choose a file";
            fd.ShowDialog();
            fs = (FileStream)fd.OpenFile();          
            return fs.Name;
        }
        public string SetFile()
        {
            string path = OpenFileDialog();
            return path;
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
    }
}
