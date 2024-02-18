namespace goUP_Brain
{
    partial class main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.title1_panel = new System.Windows.Forms.Panel();
            this.del_bt = new System.Windows.Forms.Button();
            this.add_bt = new System.Windows.Forms.Button();
            this.goupid_newbackup_bt = new System.Windows.Forms.Button();
            this.title_label = new System.Windows.Forms.Label();
            this.list_panel = new System.Windows.Forms.Panel();
            this.openfolder_bt = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.text_panel = new System.Windows.Forms.Panel();
            this.etc_bt = new System.Windows.Forms.Button();
            this.fastmemo_bt = new System.Windows.Forms.Button();
            this.mode_bt = new System.Windows.Forms.Button();
            this.nameedit_bt = new System.Windows.Forms.Button();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.syname_label = new System.Windows.Forms.Label();
            this.title2_panel = new System.Windows.Forms.Panel();
            this.show_beta_info_label = new System.Windows.Forms.Label();
            this.goupid_bt = new System.Windows.Forms.Button();
            this.close_bt = new System.Windows.Forms.Button();
            this.info_panel = new System.Windows.Forms.Panel();
            this.infoclose_bt = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
            this.info_open_timer = new System.Windows.Forms.Timer(this.components);
            this.goupid_backup_open = new System.Windows.Forms.Timer(this.components);
            this.golocal_bt = new System.Windows.Forms.Button();
            this.goupid_backup_close = new System.Windows.Forms.Timer(this.components);
            this.goupid_listBox = new System.Windows.Forms.ListBox();
            this.goupid_title1_panel = new System.Windows.Forms.Panel();
            this.goupid_del_memo = new System.Windows.Forms.Button();
            this.goupid_res_bt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.minimode_panel = new System.Windows.Forms.Panel();
            this.minimode_close_bt = new System.Windows.Forms.Button();
            this.minimode_label = new System.Windows.Forms.Label();
            this.beta_info_panel = new System.Windows.Forms.Panel();
            this.beta_info_github_label = new System.Windows.Forms.Label();
            this.beta_info_close_label = new System.Windows.Forms.Label();
            this.beta_info_label = new System.Windows.Forms.Label();
            this.etc_panel = new System.Windows.Forms.Panel();
            this.restore_trash_bt = new System.Windows.Forms.Button();
            this.open_trash_bt = new System.Windows.Forms.Button();
            this.open_folder_bt = new System.Windows.Forms.Button();
            this.title1_panel.SuspendLayout();
            this.list_panel.SuspendLayout();
            this.text_panel.SuspendLayout();
            this.title2_panel.SuspendLayout();
            this.info_panel.SuspendLayout();
            this.goupid_title1_panel.SuspendLayout();
            this.minimode_panel.SuspendLayout();
            this.beta_info_panel.SuspendLayout();
            this.etc_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title1_panel
            // 
            this.title1_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.title1_panel.Controls.Add(this.del_bt);
            this.title1_panel.Controls.Add(this.add_bt);
            this.title1_panel.Controls.Add(this.goupid_newbackup_bt);
            this.title1_panel.Controls.Add(this.title_label);
            this.title1_panel.Location = new System.Drawing.Point(0, 0);
            this.title1_panel.Name = "title1_panel";
            this.title1_panel.Size = new System.Drawing.Size(250, 40);
            this.title1_panel.TabIndex = 0;
            this.title1_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.title1_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // del_bt
            // 
            this.del_bt.BackColor = System.Drawing.Color.White;
            this.del_bt.FlatAppearance.BorderSize = 0;
            this.del_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.del_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.del_bt.Location = new System.Drawing.Point(180, 5);
            this.del_bt.Name = "del_bt";
            this.del_bt.Size = new System.Drawing.Size(30, 30);
            this.del_bt.TabIndex = 1;
            this.del_bt.Text = "x";
            this.del_bt.UseVisualStyleBackColor = false;
            this.del_bt.Click += new System.EventHandler(this.del_bt_Click);
            // 
            // add_bt
            // 
            this.add_bt.BackColor = System.Drawing.Color.White;
            this.add_bt.FlatAppearance.BorderSize = 0;
            this.add_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.add_bt.Location = new System.Drawing.Point(215, 5);
            this.add_bt.Name = "add_bt";
            this.add_bt.Size = new System.Drawing.Size(30, 30);
            this.add_bt.TabIndex = 0;
            this.add_bt.Text = "+";
            this.add_bt.UseVisualStyleBackColor = false;
            this.add_bt.Click += new System.EventHandler(this.add_bt_Click);
            // 
            // goupid_newbackup_bt
            // 
            this.goupid_newbackup_bt.BackColor = System.Drawing.Color.White;
            this.goupid_newbackup_bt.FlatAppearance.BorderSize = 0;
            this.goupid_newbackup_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goupid_newbackup_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goupid_newbackup_bt.Location = new System.Drawing.Point(145, 5);
            this.goupid_newbackup_bt.Name = "goupid_newbackup_bt";
            this.goupid_newbackup_bt.Size = new System.Drawing.Size(30, 30);
            this.goupid_newbackup_bt.TabIndex = 0;
            this.goupid_newbackup_bt.Text = "✭";
            this.goupid_newbackup_bt.UseVisualStyleBackColor = false;
            this.goupid_newbackup_bt.Click += new System.EventHandler(this.goupid_newbackup_bt_Click);
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Location = new System.Drawing.Point(10, 10);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(92, 21);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "goUP Brain";
            this.title_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.title_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // list_panel
            // 
            this.list_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.list_panel.Controls.Add(this.openfolder_bt);
            this.list_panel.Controls.Add(this.listBox);
            this.list_panel.Location = new System.Drawing.Point(0, 40);
            this.list_panel.Name = "list_panel";
            this.list_panel.Size = new System.Drawing.Size(250, 560);
            this.list_panel.TabIndex = 2;
            // 
            // openfolder_bt
            // 
            this.openfolder_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openfolder_bt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.openfolder_bt.FlatAppearance.BorderSize = 0;
            this.openfolder_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openfolder_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.openfolder_bt.Location = new System.Drawing.Point(0, 530);
            this.openfolder_bt.Name = "openfolder_bt";
            this.openfolder_bt.Size = new System.Drawing.Size(250, 30);
            this.openfolder_bt.TabIndex = 3;
            this.openfolder_bt.Text = "goUP ID 백업";
            this.openfolder_bt.UseVisualStyleBackColor = false;
            this.openfolder_bt.Click += new System.EventHandler(this.openfolder_bt_Click);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.listBox.ForeColor = System.Drawing.Color.Black;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 21;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(250, 525);
            this.listBox.Sorted = true;
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // text_panel
            // 
            this.text_panel.BackColor = System.Drawing.Color.White;
            this.text_panel.Controls.Add(this.etc_bt);
            this.text_panel.Controls.Add(this.fastmemo_bt);
            this.text_panel.Controls.Add(this.mode_bt);
            this.text_panel.Controls.Add(this.nameedit_bt);
            this.text_panel.Controls.Add(this.title_textBox);
            this.text_panel.Controls.Add(this.textBox);
            this.text_panel.Controls.Add(this.webBrowser);
            this.text_panel.Location = new System.Drawing.Point(250, 40);
            this.text_panel.Name = "text_panel";
            this.text_panel.Size = new System.Drawing.Size(550, 560);
            this.text_panel.TabIndex = 3;
            // 
            // etc_bt
            // 
            this.etc_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.etc_bt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.etc_bt.FlatAppearance.BorderSize = 0;
            this.etc_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.etc_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.etc_bt.Location = new System.Drawing.Point(520, 530);
            this.etc_bt.Name = "etc_bt";
            this.etc_bt.Size = new System.Drawing.Size(30, 30);
            this.etc_bt.TabIndex = 10;
            this.etc_bt.Text = "▲";
            this.etc_bt.UseVisualStyleBackColor = false;
            this.etc_bt.Click += new System.EventHandler(this.etc_bt_Click);
            // 
            // fastmemo_bt
            // 
            this.fastmemo_bt.FlatAppearance.BorderSize = 0;
            this.fastmemo_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fastmemo_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.fastmemo_bt.Location = new System.Drawing.Point(410, 10);
            this.fastmemo_bt.Name = "fastmemo_bt";
            this.fastmemo_bt.Size = new System.Drawing.Size(130, 40);
            this.fastmemo_bt.TabIndex = 9;
            this.fastmemo_bt.Text = "시냅스 만들기";
            this.fastmemo_bt.UseVisualStyleBackColor = false;
            this.fastmemo_bt.Visible = false;
            this.fastmemo_bt.Click += new System.EventHandler(this.fastmemo_bt_Click);
            // 
            // mode_bt
            // 
            this.mode_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mode_bt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mode_bt.FlatAppearance.BorderSize = 0;
            this.mode_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mode_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mode_bt.Location = new System.Drawing.Point(0, 530);
            this.mode_bt.Name = "mode_bt";
            this.mode_bt.Size = new System.Drawing.Size(520, 30);
            this.mode_bt.TabIndex = 4;
            this.mode_bt.Text = "마크다운 모드로 전환하기";
            this.mode_bt.UseVisualStyleBackColor = false;
            this.mode_bt.Click += new System.EventHandler(this.mode_bt_Click);
            // 
            // nameedit_bt
            // 
            this.nameedit_bt.FlatAppearance.BorderSize = 0;
            this.nameedit_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameedit_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameedit_bt.Location = new System.Drawing.Point(450, 10);
            this.nameedit_bt.Name = "nameedit_bt";
            this.nameedit_bt.Size = new System.Drawing.Size(90, 39);
            this.nameedit_bt.TabIndex = 1;
            this.nameedit_bt.Text = "저장";
            this.nameedit_bt.UseVisualStyleBackColor = false;
            this.nameedit_bt.Visible = false;
            this.nameedit_bt.Click += new System.EventHandler(this.nameedit_bt_Click);
            // 
            // title_textBox
            // 
            this.title_textBox.BackColor = System.Drawing.Color.White;
            this.title_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.title_textBox.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.title_textBox.ForeColor = System.Drawing.Color.Black;
            this.title_textBox.Location = new System.Drawing.Point(10, 10);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(430, 39);
            this.title_textBox.TabIndex = 1;
            this.title_textBox.Text = "열린 시냅스가 없어요";
            this.title_textBox.TextChanged += new System.EventHandler(this.title_textBox_TextChanged);
            this.title_textBox.Enter += new System.EventHandler(this.title_textBox_Enter);
            this.title_textBox.Leave += new System.EventHandler(this.title_textBox_Leave);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("맑은 고딕", 12F);
            this.textBox.ForeColor = System.Drawing.Color.Black;
            this.textBox.Location = new System.Drawing.Point(10, 60);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(530, 460);
            this.textBox.TabIndex = 7;
            this.textBox.Text = "여기에 메모를 입력해서 시냅스를 빠르게 만들수 있어요";
            this.textBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(10, 60);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(530, 460);
            this.webBrowser.TabIndex = 8;
            this.webBrowser.Visible = false;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // syname_label
            // 
            this.syname_label.AutoSize = true;
            this.syname_label.Location = new System.Drawing.Point(10, 10);
            this.syname_label.Name = "syname_label";
            this.syname_label.Size = new System.Drawing.Size(166, 21);
            this.syname_label.TabIndex = 1;
            this.syname_label.Text = "열린 시냅스가 없어요";
            this.syname_label.Visible = false;
            this.syname_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.syname_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // title2_panel
            // 
            this.title2_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.title2_panel.Controls.Add(this.show_beta_info_label);
            this.title2_panel.Controls.Add(this.goupid_bt);
            this.title2_panel.Controls.Add(this.close_bt);
            this.title2_panel.Controls.Add(this.syname_label);
            this.title2_panel.Location = new System.Drawing.Point(250, 0);
            this.title2_panel.Name = "title2_panel";
            this.title2_panel.Size = new System.Drawing.Size(550, 40);
            this.title2_panel.TabIndex = 2;
            this.title2_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.title2_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // show_beta_info_label
            // 
            this.show_beta_info_label.AutoSize = true;
            this.show_beta_info_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.show_beta_info_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.show_beta_info_label.ForeColor = System.Drawing.Color.Orange;
            this.show_beta_info_label.Location = new System.Drawing.Point(10, 10);
            this.show_beta_info_label.Name = "show_beta_info_label";
            this.show_beta_info_label.Size = new System.Drawing.Size(80, 21);
            this.show_beta_info_label.TabIndex = 8;
            this.show_beta_info_label.Text = "⚠️ | Beta";
            this.show_beta_info_label.Visible = false;
            this.show_beta_info_label.Click += new System.EventHandler(this.show_beta_info_label_Click);
            // 
            // goupid_bt
            // 
            this.goupid_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goupid_bt.FlatAppearance.BorderSize = 0;
            this.goupid_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goupid_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goupid_bt.Location = new System.Drawing.Point(410, 0);
            this.goupid_bt.Name = "goupid_bt";
            this.goupid_bt.Size = new System.Drawing.Size(100, 40);
            this.goupid_bt.TabIndex = 3;
            this.goupid_bt.Text = "goUP ID";
            this.goupid_bt.UseVisualStyleBackColor = false;
            this.goupid_bt.Click += new System.EventHandler(this.goupid_bt_Click);
            this.goupid_bt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.goupid_bt.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
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
            this.close_bt.Location = new System.Drawing.Point(510, 0);
            this.close_bt.Name = "close_bt";
            this.close_bt.Size = new System.Drawing.Size(40, 40);
            this.close_bt.TabIndex = 2;
            this.close_bt.UseVisualStyleBackColor = false;
            this.close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // info_panel
            // 
            this.info_panel.BackColor = System.Drawing.Color.DodgerBlue;
            this.info_panel.Controls.Add(this.infoclose_bt);
            this.info_panel.Controls.Add(this.info_label);
            this.info_panel.ForeColor = System.Drawing.Color.White;
            this.info_panel.Location = new System.Drawing.Point(10, 600);
            this.info_panel.Name = "info_panel";
            this.info_panel.Size = new System.Drawing.Size(780, 50);
            this.info_panel.TabIndex = 4;
            // 
            // infoclose_bt
            // 
            this.infoclose_bt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.infoclose_bt.FlatAppearance.BorderSize = 0;
            this.infoclose_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoclose_bt.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.infoclose_bt.Location = new System.Drawing.Point(740, 10);
            this.infoclose_bt.Name = "infoclose_bt";
            this.infoclose_bt.Size = new System.Drawing.Size(30, 30);
            this.infoclose_bt.TabIndex = 2;
            this.infoclose_bt.Text = "x";
            this.infoclose_bt.UseVisualStyleBackColor = false;
            this.infoclose_bt.Click += new System.EventHandler(this.infoclose_bt_Click);
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.Location = new System.Drawing.Point(15, 15);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(95, 21);
            this.info_label.TabIndex = 0;
            this.info_label.Text = "안녕하세요!";
            // 
            // info_open_timer
            // 
            this.info_open_timer.Interval = 10;
            this.info_open_timer.Tick += new System.EventHandler(this.info_open_timer_Tick);
            // 
            // goupid_backup_open
            // 
            this.goupid_backup_open.Interval = 10;
            this.goupid_backup_open.Tick += new System.EventHandler(this.goupid_backup_open_Tick);
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
            this.golocal_bt.Click += new System.EventHandler(this.golocal_bt_Click);
            // 
            // goupid_backup_close
            // 
            this.goupid_backup_close.Interval = 10;
            this.goupid_backup_close.Tick += new System.EventHandler(this.goupid_backup_close_Tick);
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
            this.goupid_listBox.SelectedIndexChanged += new System.EventHandler(this.goupid_listBox_SelectedIndexChanged);
            // 
            // goupid_title1_panel
            // 
            this.goupid_title1_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.goupid_title1_panel.Controls.Add(this.goupid_del_memo);
            this.goupid_title1_panel.Controls.Add(this.goupid_res_bt);
            this.goupid_title1_panel.Controls.Add(this.goupid_listBox);
            this.goupid_title1_panel.Controls.Add(this.golocal_bt);
            this.goupid_title1_panel.Controls.Add(this.label1);
            this.goupid_title1_panel.Location = new System.Drawing.Point(0, 0);
            this.goupid_title1_panel.Name = "goupid_title1_panel";
            this.goupid_title1_panel.Size = new System.Drawing.Size(250, 40);
            this.goupid_title1_panel.TabIndex = 2;
            this.goupid_title1_panel.Visible = false;
            this.goupid_title1_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.goupid_title1_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // goupid_del_memo
            // 
            this.goupid_del_memo.BackColor = System.Drawing.Color.White;
            this.goupid_del_memo.FlatAppearance.BorderSize = 0;
            this.goupid_del_memo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goupid_del_memo.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.goupid_del_memo.Location = new System.Drawing.Point(215, 5);
            this.goupid_del_memo.Name = "goupid_del_memo";
            this.goupid_del_memo.Size = new System.Drawing.Size(30, 30);
            this.goupid_del_memo.TabIndex = 2;
            this.goupid_del_memo.Text = "x";
            this.goupid_del_memo.UseVisualStyleBackColor = false;
            this.goupid_del_memo.Click += new System.EventHandler(this.goupid_del_memo_Click);
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
            this.goupid_res_bt.Click += new System.EventHandler(this.goupid_res_bt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "goUP ID Cloud";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // minimode_panel
            // 
            this.minimode_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.minimode_panel.Controls.Add(this.minimode_close_bt);
            this.minimode_panel.Controls.Add(this.minimode_label);
            this.minimode_panel.Location = new System.Drawing.Point(0, 0);
            this.minimode_panel.Name = "minimode_panel";
            this.minimode_panel.Size = new System.Drawing.Size(250, 40);
            this.minimode_panel.TabIndex = 5;
            this.minimode_panel.Visible = false;
            this.minimode_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.minimode_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // minimode_close_bt
            // 
            this.minimode_close_bt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimode_close_bt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.minimode_close_bt.FlatAppearance.BorderSize = 0;
            this.minimode_close_bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minimode_close_bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.minimode_close_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimode_close_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.minimode_close_bt.Location = new System.Drawing.Point(210, 0);
            this.minimode_close_bt.Name = "minimode_close_bt";
            this.minimode_close_bt.Size = new System.Drawing.Size(40, 40);
            this.minimode_close_bt.TabIndex = 4;
            this.minimode_close_bt.UseVisualStyleBackColor = false;
            this.minimode_close_bt.Click += new System.EventHandler(this.close_bt_Click);
            // 
            // minimode_label
            // 
            this.minimode_label.AutoSize = true;
            this.minimode_label.Location = new System.Drawing.Point(10, 10);
            this.minimode_label.Name = "minimode_label";
            this.minimode_label.Size = new System.Drawing.Size(92, 21);
            this.minimode_label.TabIndex = 0;
            this.minimode_label.Text = "goUP Brain";
            this.minimode_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseDown);
            this.minimode_label.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title1_panel_MouseMove);
            // 
            // beta_info_panel
            // 
            this.beta_info_panel.BackColor = System.Drawing.Color.Orange;
            this.beta_info_panel.Controls.Add(this.beta_info_github_label);
            this.beta_info_panel.Controls.Add(this.beta_info_close_label);
            this.beta_info_panel.Controls.Add(this.beta_info_label);
            this.beta_info_panel.ForeColor = System.Drawing.Color.White;
            this.beta_info_panel.Location = new System.Drawing.Point(0, 0);
            this.beta_info_panel.Name = "beta_info_panel";
            this.beta_info_panel.Size = new System.Drawing.Size(800, 40);
            this.beta_info_panel.TabIndex = 10;
            this.beta_info_panel.Visible = false;
            // 
            // beta_info_github_label
            // 
            this.beta_info_github_label.AutoSize = true;
            this.beta_info_github_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.beta_info_github_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.beta_info_github_label.Location = new System.Drawing.Point(595, 10);
            this.beta_info_github_label.Name = "beta_info_github_label";
            this.beta_info_github_label.Size = new System.Drawing.Size(145, 21);
            this.beta_info_github_label.TabIndex = 7;
            this.beta_info_github_label.Text = "Github 리포지토리";
            this.beta_info_github_label.Click += new System.EventHandler(this.beta_info_github_label_Click);
            // 
            // beta_info_close_label
            // 
            this.beta_info_close_label.AutoSize = true;
            this.beta_info_close_label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.beta_info_close_label.Font = new System.Drawing.Font("맑은 고딕", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.beta_info_close_label.Location = new System.Drawing.Point(745, 10);
            this.beta_info_close_label.Name = "beta_info_close_label";
            this.beta_info_close_label.Size = new System.Drawing.Size(42, 21);
            this.beta_info_close_label.TabIndex = 6;
            this.beta_info_close_label.Text = "닫기";
            this.beta_info_close_label.Click += new System.EventHandler(this.beta_info_close_label_Click);
            // 
            // beta_info_label
            // 
            this.beta_info_label.AutoSize = true;
            this.beta_info_label.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.beta_info_label.Location = new System.Drawing.Point(10, 10);
            this.beta_info_label.Name = "beta_info_label";
            this.beta_info_label.Size = new System.Drawing.Size(382, 21);
            this.beta_info_label.TabIndex = 4;
            this.beta_info_label.Text = "⚠️ | 이 앱은 goUP Brain 2.0의 Beta 3 버전이에요";
            // 
            // etc_panel
            // 
            this.etc_panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.etc_panel.Controls.Add(this.restore_trash_bt);
            this.etc_panel.Controls.Add(this.open_trash_bt);
            this.etc_panel.Controls.Add(this.open_folder_bt);
            this.etc_panel.Location = new System.Drawing.Point(650, 480);
            this.etc_panel.Name = "etc_panel";
            this.etc_panel.Size = new System.Drawing.Size(150, 90);
            this.etc_panel.TabIndex = 11;
            this.etc_panel.Visible = false;
            // 
            // restore_trash_bt
            // 
            this.restore_trash_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.restore_trash_bt.FlatAppearance.BorderSize = 0;
            this.restore_trash_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restore_trash_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.restore_trash_bt.Location = new System.Drawing.Point(0, 60);
            this.restore_trash_bt.Name = "restore_trash_bt";
            this.restore_trash_bt.Size = new System.Drawing.Size(150, 30);
            this.restore_trash_bt.TabIndex = 6;
            this.restore_trash_bt.Text = "🗑️ 시냅스 복원";
            this.restore_trash_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restore_trash_bt.UseVisualStyleBackColor = false;
            this.restore_trash_bt.Click += new System.EventHandler(this.restore_trash_bt_Click);
            // 
            // open_trash_bt
            // 
            this.open_trash_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.open_trash_bt.FlatAppearance.BorderSize = 0;
            this.open_trash_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_trash_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.open_trash_bt.Location = new System.Drawing.Point(0, 30);
            this.open_trash_bt.Name = "open_trash_bt";
            this.open_trash_bt.Size = new System.Drawing.Size(150, 30);
            this.open_trash_bt.TabIndex = 5;
            this.open_trash_bt.Text = "🗑️ 휴지통 열기";
            this.open_trash_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open_trash_bt.UseVisualStyleBackColor = false;
            this.open_trash_bt.Click += new System.EventHandler(this.open_trash_bt_Click);
            // 
            // open_folder_bt
            // 
            this.open_folder_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.open_folder_bt.FlatAppearance.BorderSize = 0;
            this.open_folder_bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_folder_bt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.open_folder_bt.Location = new System.Drawing.Point(0, 0);
            this.open_folder_bt.Name = "open_folder_bt";
            this.open_folder_bt.Size = new System.Drawing.Size(150, 30);
            this.open_folder_bt.TabIndex = 4;
            this.open_folder_bt.Text = "📂 폴더 열기";
            this.open_folder_bt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.open_folder_bt.UseVisualStyleBackColor = false;
            this.open_folder_bt.Click += new System.EventHandler(this.open_folder_bt_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.etc_panel);
            this.Controls.Add(this.info_panel);
            this.Controls.Add(this.text_panel);
            this.Controls.Add(this.goupid_title1_panel);
            this.Controls.Add(this.title1_panel);
            this.Controls.Add(this.minimode_panel);
            this.Controls.Add(this.title2_panel);
            this.Controls.Add(this.beta_info_panel);
            this.Controls.Add(this.list_panel);
            this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "goUP Brain";
            this.Load += new System.EventHandler(this.main_Load);
            this.Shown += new System.EventHandler(this.main_Shown);
            this.title1_panel.ResumeLayout(false);
            this.title1_panel.PerformLayout();
            this.list_panel.ResumeLayout(false);
            this.text_panel.ResumeLayout(false);
            this.text_panel.PerformLayout();
            this.title2_panel.ResumeLayout(false);
            this.title2_panel.PerformLayout();
            this.info_panel.ResumeLayout(false);
            this.info_panel.PerformLayout();
            this.goupid_title1_panel.ResumeLayout(false);
            this.goupid_title1_panel.PerformLayout();
            this.minimode_panel.ResumeLayout(false);
            this.minimode_panel.PerformLayout();
            this.beta_info_panel.ResumeLayout(false);
            this.beta_info_panel.PerformLayout();
            this.etc_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel title1_panel;
        private System.Windows.Forms.Panel list_panel;
        private System.Windows.Forms.Panel text_panel;
        private System.Windows.Forms.Label syname_label;
        private System.Windows.Forms.Panel title2_panel;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Button add_bt;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.Button nameedit_bt;
        private System.Windows.Forms.Button del_bt;
        private System.Windows.Forms.Button close_bt;
        private System.Windows.Forms.Button openfolder_bt;
        private System.Windows.Forms.Panel info_panel;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.Timer info_open_timer;
        private System.Windows.Forms.Button infoclose_bt;
        private System.Windows.Forms.Button goupid_bt;
        private System.Windows.Forms.Button mode_bt;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Timer goupid_backup_open;
        private System.Windows.Forms.Button golocal_bt;
        private System.Windows.Forms.Timer goupid_backup_close;
        private System.Windows.Forms.Panel goupid_title1_panel;
        private System.Windows.Forms.Button goupid_newbackup_bt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox goupid_listBox;
        private System.Windows.Forms.Button fastmemo_bt;
        private System.Windows.Forms.Button goupid_res_bt;
        private System.Windows.Forms.Button goupid_del_memo;
        private System.Windows.Forms.Panel minimode_panel;
        private System.Windows.Forms.Label minimode_label;
        private System.Windows.Forms.Button minimode_close_bt;
        private System.Windows.Forms.Panel beta_info_panel;
        private System.Windows.Forms.Label beta_info_label;
        private System.Windows.Forms.Label beta_info_close_label;
        private System.Windows.Forms.Label beta_info_github_label;
        private System.Windows.Forms.Label show_beta_info_label;
        private System.Windows.Forms.Button etc_bt;
        private System.Windows.Forms.Panel etc_panel;
        private System.Windows.Forms.Button restore_trash_bt;
        private System.Windows.Forms.Button open_trash_bt;
        private System.Windows.Forms.Button open_folder_bt;
    }
}

