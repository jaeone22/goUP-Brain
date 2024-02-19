namespace goUP_Brain
{
    partial class settings
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
            this.title_panel = new System.Windows.Forms.Panel();
            this.goupid_res_bt = new System.Windows.Forms.Button();
            this.goupid_listBox = new System.Windows.Forms.ListBox();
            this.golocal_bt = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.thanks_richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.close_bt = new System.Windows.Forms.Button();
            this.title_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_panel
            // 
            this.title_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.title_panel.Controls.Add(this.close_bt);
            this.title_panel.Controls.Add(this.goupid_res_bt);
            this.title_panel.Controls.Add(this.goupid_listBox);
            this.title_panel.Controls.Add(this.golocal_bt);
            this.title_panel.Controls.Add(this.title_label);
            this.title_panel.Location = new System.Drawing.Point(0, 0);
            this.title_panel.Name = "title_panel";
            this.title_panel.Size = new System.Drawing.Size(800, 40);
            this.title_panel.TabIndex = 3;
            this.title_panel.Visible = false;
            // 
            // goupid_res_bt
            // 
            this.goupid_res_bt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.goupid_res_bt.FlatAppearance.BorderSize = 0;
            this.goupid_res_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goupid_res_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goupid_res_bt.Location = new System.Drawing.Point(0, 570);
            this.goupid_res_bt.Name = "goupid_res_bt";
            this.goupid_res_bt.Size = new System.Drawing.Size(250, 30);
            this.goupid_res_bt.TabIndex = 6;
            this.goupid_res_bt.Text = "선택한 시냅스 복원 ❯❯";
            this.goupid_res_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.goupid_res_bt.UseVisualStyleBackColor = false;
            // 
            // goupid_listBox
            // 
            this.goupid_listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.goupid_listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.goupid_listBox.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.goupid_listBox.ForeColor = System.Drawing.Color.Black;
            this.goupid_listBox.FormattingEnabled = true;
            this.goupid_listBox.ItemHeight = 21;
            this.goupid_listBox.Location = new System.Drawing.Point(0, 70);
            this.goupid_listBox.Name = "goupid_listBox";
            this.goupid_listBox.Size = new System.Drawing.Size(250, 525);
            this.goupid_listBox.Sorted = true;
            this.goupid_listBox.TabIndex = 5;
            // 
            // golocal_bt
            // 
            this.golocal_bt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.golocal_bt.FlatAppearance.BorderSize = 0;
            this.golocal_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.golocal_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.golocal_bt.Location = new System.Drawing.Point(0, 40);
            this.golocal_bt.Name = "golocal_bt";
            this.golocal_bt.Size = new System.Drawing.Size(250, 30);
            this.golocal_bt.TabIndex = 4;
            this.golocal_bt.Text = "◀️ 뒤로가기";
            this.golocal_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.golocal_bt.UseVisualStyleBackColor = false;
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Location = new System.Drawing.Point(10, 10);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(144, 21);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "goUP Brain ❯ 설정";
            // 
            // thanks_richTextBox
            // 
            this.thanks_richTextBox.BackColor = System.Drawing.Color.White;
            this.thanks_richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.thanks_richTextBox.ForeColor = System.Drawing.Color.Black;
            this.thanks_richTextBox.Location = new System.Drawing.Point(281, 319);
            this.thanks_richTextBox.Name = "thanks_richTextBox";
            this.thanks_richTextBox.Size = new System.Drawing.Size(390, 149);
            this.thanks_richTextBox.TabIndex = 4;
            this.thanks_richTextBox.Text = "Thanks 목록을 가져오는중이에요...\nhttps://thanks.goup.ggm.kr/thanks-list.goup";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 560);
            this.panel1.TabIndex = 5;
            // 
            // close_bt
            // 
            this.close_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close_bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.close_bt.FlatAppearance.BorderSize = 0;
            this.close_bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.close_bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.close_bt.Location = new System.Drawing.Point(760, 0);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(40, 40);
            this.close_bt.TabIndex = 6;
            this.close_bt.UseVisualStyleBackColor = false;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.thanks_richTextBox);
            this.Controls.Add(this.title_panel);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "goUP Brain 설정";
            this.Load += new System.EventHandler(this.settings_Load);
            this.title_panel.ResumeLayout(false);
            this.title_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel title_panel;
        private System.Windows.Forms.Button goupid_res_bt;
        private System.Windows.Forms.ListBox goupid_listBox;
        private System.Windows.Forms.Button golocal_bt;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.RichTextBox thanks_richTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button close_bt;
    }
}