﻿using System;
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
            SetStyle(ControlStyles.Opaque, true);
        }
        TransparentLabel time = new TransparentLabel();
        public void AddTimeLabelSender()
        {
            time.BackColor = System.Drawing.Color.Transparent;
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
            time.BackColor = System.Drawing.Color.Transparent;
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
        DateTime dt;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            macTrackBar1.Value = 0;
            Timer t = new Timer();
            dt = DateTime.Now;
            using (System.Media.SoundPlayer player = new System.Media.SoundPlayer { SoundLocation = filename })
            {
                macTrackBar1.Minimum = 0;
                macTrackBar1.Maximum = Int32.Parse(label2.Text.Substring(label2.Text.LastIndexOf(':') + 1)) * 1000;
                t.Interval = 150; //ms
                t.Tick += T_Tick;
                t.Start();
                player.Play();
            }
        }
        private void T_Tick(object sender, EventArgs e)
        {
            if (macTrackBar1.Value >= macTrackBar1.Maximum) ((Timer)sender).Stop();
            else
                macTrackBar1.Value = Convert.ToInt32(DateTime.Now.Subtract(dt).TotalMilliseconds);
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
