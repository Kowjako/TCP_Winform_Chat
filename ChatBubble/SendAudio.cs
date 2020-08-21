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
    public partial class SendAudio : UserControl
    {
        public SendAudio()
        {
            InitializeComponent();
        }
        Label time = new Label();
        public void AddTimeLabelSender()
        {
            panel1.BackColor = Color.White;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
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
            panel1.BackColor = Color.SkyBlue;
            label1.BackColor = Color.SkyBlue;
            label2.BackColor = Color.SkyBlue;
            pictureBox1.BackColor = Color.SkyBlue;
            time.Left = 5;
            time.Top = panel1.Height + 5;
            time.Text = DateTime.Now.ToShortTimeString();
            time.Font = new Font("Segoe UI", 9);
            time.ForeColor = Color.DarkRed;
            this.Controls.Add(time);
        }
        public string AudioTime
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
        public void SetFile(string path)
        {
            filename = path;
        }
        private string filename;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(filename);
        }
    }
}
