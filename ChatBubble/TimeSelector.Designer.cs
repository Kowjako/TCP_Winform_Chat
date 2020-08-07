namespace ChatBubble
{
    partial class TimeSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelRoundCorner = new LabelRoundCorners();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lrc1
            // 
            this.LabelRoundCorner._BackColor = System.Drawing.Color.Pink;
            this.LabelRoundCorner.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LabelRoundCorner.AutoSize = true;
            this.LabelRoundCorner.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRoundCorner.Location = new System.Drawing.Point(276, 5);
            this.LabelRoundCorner.MaximumSize = new System.Drawing.Size(130, 0);
            this.LabelRoundCorner.MinimumSize = new System.Drawing.Size(110, 0);
            this.LabelRoundCorner.Name = "lrc1";
            this.LabelRoundCorner.Size = new System.Drawing.Size(110, 19);
            this.LabelRoundCorner.TabIndex = 0;
            this.LabelRoundCorner.Text = "28 December";
            this.LabelRoundCorner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(386, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(258, 2);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(-1, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 2);
            this.panel2.TabIndex = 2;
            // 
            // TimeSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LabelRoundCorner);
            this.Name = "TimeSelector";
            this.Size = new System.Drawing.Size(642, 28);
            this.Load += new System.EventHandler(this.TimeSelector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelRoundCorners LabelRoundCorner;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
