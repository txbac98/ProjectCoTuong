﻿namespace GameCoTuong
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
            this.background = new System.Windows.Forms.PictureBox();
            this.ptbBanCo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLAN = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.txbIP = new System.Windows.Forms.TextBox();
            this.lblPheDuocDanh = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSoLuotDi = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Enabled = false;
            this.background.Image = global::GameCoTuong.Properties.Resources.tranh_thuy_mac;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(944, 729);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.background.TabIndex = 3;
            this.background.TabStop = false;
            // 
            // ptbBanCo
            // 
            this.ptbBanCo.BackColor = System.Drawing.Color.Transparent;
            this.ptbBanCo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ptbBanCo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbBanCo.Image = global::GameCoTuong.Properties.Resources.BanCoTuong;
            this.ptbBanCo.InitialImage = null;
            this.ptbBanCo.Location = new System.Drawing.Point(34, 32);
            this.ptbBanCo.Name = "ptbBanCo";
            this.ptbBanCo.Size = new System.Drawing.Size(607, 662);
            this.ptbBanCo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbBanCo.TabIndex = 0;
            this.ptbBanCo.TabStop = false;
            this.ptbBanCo.Click += new System.EventHandler(this.ptbBanCo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnLAN);
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.txbIP);
            this.panel1.Controls.Add(this.lblPheDuocDanh);
            this.panel1.Controls.Add(this.btnNewGame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSoLuotDi);
            this.panel1.Location = new System.Drawing.Point(649, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 161);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP máy bạn:";
            // 
            // btnLAN
            // 
            this.btnLAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLAN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLAN.Location = new System.Drawing.Point(173, 128);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(85, 27);
            this.btnLAN.TabIndex = 6;
            this.btnLAN.Text = "Kết nối";
            this.btnLAN.UseVisualStyleBackColor = true;
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUndo.Enabled = false;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUndo.Location = new System.Drawing.Point(7, 61);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(80, 27);
            this.btnUndo.TabIndex = 0;
            this.btnUndo.Text = "Xin đi lại";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // txbIP
            // 
            this.txbIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txbIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txbIP.Location = new System.Drawing.Point(78, 99);
            this.txbIP.Name = "txbIP";
            this.txbIP.Size = new System.Drawing.Size(179, 23);
            this.txbIP.TabIndex = 5;
            // 
            // lblPheDuocDanh
            // 
            this.lblPheDuocDanh.AutoSize = true;
            this.lblPheDuocDanh.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPheDuocDanh.ForeColor = System.Drawing.Color.Black;
            this.lblPheDuocDanh.Location = new System.Drawing.Point(6, 6);
            this.lblPheDuocDanh.Name = "lblPheDuocDanh";
            this.lblPheDuocDanh.Size = new System.Drawing.Size(161, 25);
            this.lblPheDuocDanh.TabIndex = 0;
            this.lblPheDuocDanh.Text = "Phe nào được đi?";
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewGame.Enabled = false;
            this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNewGame.Location = new System.Drawing.Point(91, 61);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(80, 27);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "Cầu hòa";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(8, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lượt đã đi:";
            // 
            // lblSoLuotDi
            // 
            this.lblSoLuotDi.AutoSize = true;
            this.lblSoLuotDi.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSoLuotDi.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSoLuotDi.Location = new System.Drawing.Point(81, 28);
            this.lblSoLuotDi.Name = "lblSoLuotDi";
            this.lblSoLuotDi.Size = new System.Drawing.Size(31, 30);
            this.lblSoLuotDi.TabIndex = 2;
            this.lblSoLuotDi.Text = "??";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(175, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "Xin hàng";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(942, 726);
            this.Controls.Add(this.ptbBanCo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.background);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Co Tuong (Online)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBanCo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox ptbBanCo;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPheDuocDanh;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSoLuotDi;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.TextBox txbIP;
        private System.Windows.Forms.Button btnLAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

