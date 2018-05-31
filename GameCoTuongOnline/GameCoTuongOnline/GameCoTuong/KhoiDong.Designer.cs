namespace GameCoTuong
{
    partial class KhoiDong
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
            this.btnGo = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.radioConnectPvp = new System.Windows.Forms.RadioButton();
            this.radioNewGamePvp = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioContinueGame = new System.Windows.Forms.RadioButton();
            this.radioNewOfflineGame = new System.Windows.Forms.RadioButton();
            this.btnPvpMode = new System.Windows.Forms.Button();
            this.btnOfflineMode = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(348, 249);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(86, 27);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "Bắt đầu";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbPlayerName);
            this.panel2.Controls.Add(this.radioConnectPvp);
            this.panel2.Controls.Add(this.radioNewGamePvp);
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(122, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 122);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tên người chơi:";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(111, 17);
            this.tbPlayerName.MaxLength = 12;
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(142, 23);
            this.tbPlayerName.TabIndex = 2;
            // 
            // radioConnectPvp
            // 
            this.radioConnectPvp.AutoSize = true;
            this.radioConnectPvp.Location = new System.Drawing.Point(29, 80);
            this.radioConnectPvp.Name = "radioConnectPvp";
            this.radioConnectPvp.Size = new System.Drawing.Size(275, 19);
            this.radioConnectPvp.TabIndex = 1;
            this.radioConnectPvp.Text = "Kết nối vào một ván cờ tạo bởi người chơi khác";
            this.radioConnectPvp.UseVisualStyleBackColor = true;
            // 
            // radioNewGamePvp
            // 
            this.radioNewGamePvp.AutoSize = true;
            this.radioNewGamePvp.Checked = true;
            this.radioNewGamePvp.Location = new System.Drawing.Point(29, 50);
            this.radioNewGamePvp.Name = "radioNewGamePvp";
            this.radioNewGamePvp.Size = new System.Drawing.Size(91, 19);
            this.radioNewGamePvp.TabIndex = 0;
            this.radioNewGamePvp.TabStop = true;
            this.radioNewGamePvp.Text = "Tạo ván mới";
            this.radioNewGamePvp.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.radioContinueGame);
            this.panel1.Controls.Add(this.radioNewOfflineGame);
            this.panel1.Location = new System.Drawing.Point(122, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 84);
            this.panel1.TabIndex = 7;
            // 
            // radioContinueGame
            // 
            this.radioContinueGame.AutoSize = true;
            this.radioContinueGame.Location = new System.Drawing.Point(29, 48);
            this.radioContinueGame.Name = "radioContinueGame";
            this.radioContinueGame.Size = new System.Drawing.Size(146, 19);
            this.radioContinueGame.TabIndex = 1;
            this.radioContinueGame.Text = "Tiếp tục ván đang chơi";
            this.radioContinueGame.UseVisualStyleBackColor = true;
            // 
            // radioNewOfflineGame
            // 
            this.radioNewOfflineGame.AutoSize = true;
            this.radioNewOfflineGame.Checked = true;
            this.radioNewOfflineGame.Location = new System.Drawing.Point(29, 18);
            this.radioNewOfflineGame.Name = "radioNewOfflineGame";
            this.radioNewOfflineGame.Size = new System.Drawing.Size(91, 19);
            this.radioNewOfflineGame.TabIndex = 0;
            this.radioNewOfflineGame.TabStop = true;
            this.radioNewOfflineGame.Text = "Tạo ván mới";
            this.radioNewOfflineGame.UseVisualStyleBackColor = true;
            // 
            // btnPvpMode
            // 
            this.btnPvpMode.Location = new System.Drawing.Point(12, 112);
            this.btnPvpMode.Name = "btnPvpMode";
            this.btnPvpMode.Size = new System.Drawing.Size(104, 31);
            this.btnPvpMode.TabIndex = 6;
            this.btnPvpMode.Text = "2 máy";
            this.btnPvpMode.UseVisualStyleBackColor = true;
            this.btnPvpMode.Click += new System.EventHandler(this.btnPvpMode_Click);
            // 
            // btnOfflineMode
            // 
            this.btnOfflineMode.Enabled = false;
            this.btnOfflineMode.Location = new System.Drawing.Point(12, 13);
            this.btnOfflineMode.Name = "btnOfflineMode";
            this.btnOfflineMode.Size = new System.Drawing.Size(104, 31);
            this.btnOfflineMode.TabIndex = 5;
            this.btnOfflineMode.Text = "1 máy";
            this.btnOfflineMode.UseVisualStyleBackColor = true;
            this.btnOfflineMode.Click += new System.EventHandler(this.btnOfflineMode_Click);
            // 
            // KhoiDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 288);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPvpMode);
            this.Controls.Add(this.btnOfflineMode);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "KhoiDong";
            this.Text = "Khởi động";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.RadioButton radioConnectPvp;
        private System.Windows.Forms.RadioButton radioNewGamePvp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioContinueGame;
        private System.Windows.Forms.RadioButton radioNewOfflineGame;
        private System.Windows.Forms.Button btnPvpMode;
        private System.Windows.Forms.Button btnOfflineMode;
    }
}