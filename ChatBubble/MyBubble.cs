﻿using System;
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
    public partial class MyBubble: UserControl
    {
        public MyBubble()
        { 
            InitializeComponent();
        }
        private int previousWidth;
        public string Body
        {
            get
            {
                return label1.Text;
            }
            set
            {
                previousWidth = label1.Width;
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
        Label time = new Label();
        public void AddTimeLabel()
        {
            time.Left = label1.Left + label1.Width - 35;
            time.Top = label1.Height + 5;
            time.Text = DateTime.Now.ToShortTimeString();
            time.Font = new Font("Segoe UI",9);
            time.ForeColor = Color.DarkRed;
            this.Controls.Add(time);
        }
        private void MyBubble_Load(object sender, EventArgs e)
        {
            label1.Left = this.Width - label1.Width - 5;
            AddTimeLabel();
        }
    }
}
