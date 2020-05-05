namespace WindowsFormsApp1
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
            this.btnEn = new System.Windows.Forms.Button();
            this.btnDis = new System.Windows.Forms.Button();
            this.lblJoy = new System.Windows.Forms.Label();
            this.lblEn = new System.Windows.Forms.Label();
            this.btnShut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lblSteer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEn
            // 
            this.btnEn.Location = new System.Drawing.Point(12, 12);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(63, 23);
            this.btnEn.TabIndex = 0;
            this.btnEn.Text = "Enable";
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // btnDis
            // 
            this.btnDis.Location = new System.Drawing.Point(81, 12);
            this.btnDis.Name = "btnDis";
            this.btnDis.Size = new System.Drawing.Size(63, 23);
            this.btnDis.TabIndex = 1;
            this.btnDis.Text = "Disable";
            this.btnDis.UseVisualStyleBackColor = true;
            this.btnDis.Click += new System.EventHandler(this.btnDis_Click);
            // 
            // lblJoy
            // 
            this.lblJoy.AutoSize = true;
            this.lblJoy.Location = new System.Drawing.Point(92, 75);
            this.lblJoy.Name = "lblJoy";
            this.lblJoy.Size = new System.Drawing.Size(0, 13);
            this.lblJoy.TabIndex = 2;
            this.lblJoy.Click += new System.EventHandler(this.lblJoy_Click);
            // 
            // lblEn
            // 
            this.lblEn.AutoSize = true;
            this.lblEn.Location = new System.Drawing.Point(92, 52);
            this.lblEn.Name = "lblEn";
            this.lblEn.Size = new System.Drawing.Size(48, 13);
            this.lblEn.TabIndex = 3;
            this.lblEn.Text = "Disabled";
            // 
            // btnShut
            // 
            this.btnShut.Location = new System.Drawing.Point(150, 12);
            this.btnShut.Name = "btnShut";
            this.btnShut.Size = new System.Drawing.Size(81, 23);
            this.btnShut.TabIndex = 4;
            this.btnShut.Text = "Shut Down";
            this.btnShut.UseVisualStyleBackColor = true;
            this.btnShut.Click += new System.EventHandler(this.btnShut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sending Bytes: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log: ";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(249, 33);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(300, 172);
            this.rtbLog.TabIndex = 9;
            this.rtbLog.Text = "";
            // 
            // lblSteer
            // 
            this.lblSteer.AutoSize = true;
            this.lblSteer.Location = new System.Drawing.Point(93, 92);
            this.lblSteer.Name = "lblSteer";
            this.lblSteer.Size = new System.Drawing.Size(0, 13);
            this.lblSteer.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 217);
            this.Controls.Add(this.lblSteer);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnShut);
            this.Controls.Add(this.lblEn);
            this.Controls.Add(this.lblJoy);
            this.Controls.Add(this.btnDis);
            this.Controls.Add(this.btnEn);
            this.Name = "Form1";
            this.Text = "Driver Station";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEn;
        private System.Windows.Forms.Button btnDis;
        private System.Windows.Forms.Label lblJoy;
        private System.Windows.Forms.Label lblEn;
        private System.Windows.Forms.Button btnShut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lblSteer;
    }
}