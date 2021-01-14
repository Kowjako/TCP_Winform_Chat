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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRecord = new System.Windows.Forms.PictureBox();
            this.altoButton1 = new AltoControls.AltoButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.altoButton3 = new System.Windows.Forms.PictureBox();
            this.altoTextBox1 = new AltoControls.AltoTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusLbl = new System.Windows.Forms.Label();
            this.nameLbl = new System.Windows.Forms.Label();
            this.zeroitClassicRndButton1 = new Zeroit.Framework.Button.ZeroitClassicRndButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.roundedImage1 = new Chat.RoundedImage();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.altoButton3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedImage1)).BeginInit();
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
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnRecord);
            this.panel4.Controls.Add(this.altoButton1);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.altoButton3);
            this.panel4.Controls.Add(this.altoTextBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.panel4.Location = new System.Drawing.Point(0, 663);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(538, 38);
            this.panel4.TabIndex = 0;
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.Transparent;
            this.btnRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.Location = new System.Drawing.Point(329, 3);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(34, 31);
            this.btnRecord.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRecord.TabIndex = 5;
            this.btnRecord.TabStop = false;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.DarkGray;
            this.altoButton1.Active2 = System.Drawing.Color.Silver;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Bold);
            this.altoButton1.ForeColor = System.Drawing.Color.Black;
            this.altoButton1.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.altoButton1.Inactive2 = System.Drawing.SystemColors.ButtonFace;
            this.altoButton1.Location = new System.Drawing.Point(489, 4);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 10;
            this.altoButton1.Size = new System.Drawing.Size(46, 30);
            this.altoButton1.Stroke = false;
            this.altoButton1.StrokeColor = System.Drawing.Color.Transparent;
            this.altoButton1.TabIndex = 0;
            this.altoButton1.Text = "Send";
            this.altoButton1.Transparency = false;
            this.altoButton1.Click += new System.EventHandler(this.altoButton1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(449, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(409, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // altoButton3
            // 
            this.altoButton3.BackColor = System.Drawing.Color.Transparent;
            this.altoButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.altoButton3.Image = ((System.Drawing.Image)(resources.GetObject("altoButton3.Image")));
            this.altoButton3.Location = new System.Drawing.Point(369, 3);
            this.altoButton3.Name = "altoButton3";
            this.altoButton3.Size = new System.Drawing.Size(34, 31);
            this.altoButton3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.altoButton3.TabIndex = 2;
            this.altoButton3.TabStop = false;
            this.altoButton3.Click += new System.EventHandler(this.altoButton3_Click_1);
            // 
            // altoTextBox1
            // 
            this.altoTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.altoTextBox1.Br = System.Drawing.Color.White;
            this.altoTextBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.altoTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.altoTextBox1.Location = new System.Drawing.Point(1, 1);
            this.altoTextBox1.Name = "altoTextBox1";
            this.altoTextBox1.Size = new System.Drawing.Size(325, 34);
            this.altoTextBox1.TabIndex = 0;
            this.altoTextBox1.TabStop = false;
            this.altoTextBox1.TextChanged += new System.EventHandler(this.altoTextBox1_TextChanged);
            this.altoTextBox1.Enter += new System.EventHandler(this.altoTextBox1_Enter);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(538, 604);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.roundedImage1);
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
            this.statusLbl.Location = new System.Drawing.Point(70, 31);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(41, 15);
            this.statusLbl.TabIndex = 0;
            this.statusLbl.Text = "online";
            // 
            // nameLbl
            // 
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nameLbl.Location = new System.Drawing.Point(68, 8);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(228, 23);
            this.nameLbl.TabIndex = 1;
            this.nameLbl.Text = "Wlodzimierz Kowjako";
            this.nameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // zeroitClassicRndButton1
            // 
            this.zeroitClassicRndButton1.AllowClickAnimation = true;
            this.zeroitClassicRndButton1.AllowTransparency = true;
            this.zeroitClassicRndButton1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.zeroitClassicRndButton1.ButtonColor = System.Drawing.Color.WhiteSmoke;
            this.zeroitClassicRndButton1.ButtonPressOffset = 0;
            this.zeroitClassicRndButton1.CenterColor = System.Drawing.Color.White;
            this.zeroitClassicRndButton1.ClickMaxOffset = 10;
            this.zeroitClassicRndButton1.ClickOffset = 1;
            this.zeroitClassicRndButton1.ClickSpeed = 1;
            this.zeroitClassicRndButton1.EdgeWidth = 1;
            this.zeroitClassicRndButton1.LightAngle = 50F;
            this.zeroitClassicRndButton1.Location = new System.Drawing.Point(504, 16);
            this.zeroitClassicRndButton1.Name = "zeroitClassicRndButton1";
            this.zeroitClassicRndButton1.RecessDepth = 0;
            this.zeroitClassicRndButton1.Size = new System.Drawing.Size(23, 23);
            this.zeroitClassicRndButton1.TabIndex = 0;
            this.zeroitClassicRndButton1.Text = "X";
            this.zeroitClassicRndButton1.UseVisualStyleBackColor = false;
            this.zeroitClassicRndButton1.VsTextSpread = 0.75D;
            this.zeroitClassicRndButton1.Click += new System.EventHandler(this.zeroitClassicRndButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // roundedImage1
            // 
            this.roundedImage1.BackColor = System.Drawing.Color.DarkGray;
            this.roundedImage1.Image = ((System.Drawing.Image)(resources.GetObject("roundedImage1.Image")));
            this.roundedImage1.Location = new System.Drawing.Point(11, 3);
            this.roundedImage1.Name = "roundedImage1";
            this.roundedImage1.Size = new System.Drawing.Size(51, 50);
            this.roundedImage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.roundedImage1.TabIndex = 2;
            this.roundedImage1.TabStop = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.btnRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.altoButton3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roundedImage1)).EndInit();
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
        private System.Windows.Forms.PictureBox altoButton3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnRecord;
        private RoundedImage roundedImage1;
    }
}

