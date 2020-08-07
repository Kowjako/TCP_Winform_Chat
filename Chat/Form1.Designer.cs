namespace Chat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.altoTextBox1 = new AltoControls.AltoTextBox();
            this.altoButton3 = new AltoControls.AltoButton();
            this.altoButton1 = new AltoControls.AltoButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.zeroitClassicRndButton1 = new Zeroit.Framework.Button.ZeroitClassicRndButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(540, 703);
            this.panel1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.altoTextBox1);
            this.panel4.Controls.Add(this.altoButton3);
            this.panel4.Controls.Add(this.altoButton1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 663);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(538, 38);
            this.panel4.TabIndex = 0;
            // 
            // altoTextBox1
            // 
            this.altoTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.altoTextBox1.Br = System.Drawing.Color.White;
            this.altoTextBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.altoTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.altoTextBox1.Location = new System.Drawing.Point(3, 5);
            this.altoTextBox1.Name = "altoTextBox1";
            this.altoTextBox1.Size = new System.Drawing.Size(426, 30);
            this.altoTextBox1.TabIndex = 0;
            this.altoTextBox1.Text = "Write message";
            this.altoTextBox1.Enter += new System.EventHandler(this.altoTextBox1_Enter);
            this.altoTextBox1.Leave += new System.EventHandler(this.altoTextBox1_Leave);
            // 
            // altoButton3
            // 
            this.altoButton3.Active1 = System.Drawing.Color.DarkGray;
            this.altoButton3.Active2 = System.Drawing.Color.Silver;
            this.altoButton3.BackColor = System.Drawing.Color.Transparent;
            this.altoButton3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton3.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.altoButton3.ForeColor = System.Drawing.Color.Black;
            this.altoButton3.Inactive1 = System.Drawing.Color.White;
            this.altoButton3.Inactive2 = System.Drawing.Color.White;
            this.altoButton3.Location = new System.Drawing.Point(483, 5);
            this.altoButton3.Name = "altoButton3";
            this.altoButton3.Radius = 10;
            this.altoButton3.Size = new System.Drawing.Size(46, 30);
            this.altoButton3.Stroke = false;
            this.altoButton3.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton3.TabIndex = 1;
            this.altoButton3.Text = "File";
            this.altoButton3.Transparency = false;
            this.altoButton3.Click += new System.EventHandler(this.altoButton3_Click);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.DarkGray;
            this.altoButton1.Active2 = System.Drawing.Color.Silver;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.altoButton1.ForeColor = System.Drawing.Color.Black;
            this.altoButton1.Inactive1 = System.Drawing.Color.White;
            this.altoButton1.Inactive2 = System.Drawing.Color.White;
            this.altoButton1.Location = new System.Drawing.Point(435, 5);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 10;
            this.altoButton1.Size = new System.Drawing.Size(42, 30);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Gray;
            this.altoButton1.TabIndex = 0;
            this.altoButton1.Text = "Send";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(538, 603);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.statusLbl);
            this.panel2.Controls.Add(this.nameLbl);
            this.panel2.Controls.Add(this.zeroitClassicRndButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(538, 59);
            this.panel2.TabIndex = 0;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.BackColor = System.Drawing.Color.Transparent;
            this.statusLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLbl.ForeColor = System.Drawing.Color.Turquoise;
            this.statusLbl.Location = new System.Drawing.Point(250, 33);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(41, 15);
            this.statusLbl.TabIndex = 0;
            this.statusLbl.Text = "online";
            // 
            // nameLbl
            // 
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nameLbl.Location = new System.Drawing.Point(136, 8);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(275, 23);
            this.nameLbl.TabIndex = 1;
            this.nameLbl.Text = "Wlodzimierz Kowjako";
            this.nameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zeroitClassicRndButton1
            // 
            this.zeroitClassicRndButton1.AllowClickAnimation = true;
            this.zeroitClassicRndButton1.AllowTransparency = true;
            this.zeroitClassicRndButton1.ButtonColor = System.Drawing.Color.DarkSlateGray;
            this.zeroitClassicRndButton1.ButtonPressOffset = 0;
            this.zeroitClassicRndButton1.CenterColor = System.Drawing.Color.White;
            this.zeroitClassicRndButton1.ClickMaxOffset = 10;
            this.zeroitClassicRndButton1.ClickOffset = 1;
            this.zeroitClassicRndButton1.ClickSpeed = 1;
            this.zeroitClassicRndButton1.EdgeWidth = 1;
            this.zeroitClassicRndButton1.LightAngle = 50F;
            this.zeroitClassicRndButton1.Location = new System.Drawing.Point(487, 8);
            this.zeroitClassicRndButton1.Name = "zeroitClassicRndButton1";
            this.zeroitClassicRndButton1.RecessDepth = 0;
            this.zeroitClassicRndButton1.Size = new System.Drawing.Size(42, 40);
            this.zeroitClassicRndButton1.TabIndex = 0;
            this.zeroitClassicRndButton1.Text = "X";
            this.zeroitClassicRndButton1.VsTextSpread = 0.75D;
            this.zeroitClassicRndButton1.Click += new System.EventHandler(this.zeroitClassicRndButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 703);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private AltoControls.AltoButton altoButton1;
        private AltoControls.AltoTextBox altoTextBox1;
        private Zeroit.Framework.Button.ZeroitClassicRndButton zeroitClassicRndButton1;
        private System.Windows.Forms.Label nameLbl;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label statusLbl;
        private System.Windows.Forms.Timer timer1;
        private AltoControls.AltoButton altoButton3;
    }
}

