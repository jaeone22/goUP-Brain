using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace goUP_Brain
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        //
        Point mCurrentPosition = new Point(0, 0);
        string df = @"C:\goUP\Brain\";
        string info_text = "안녕하세요!";

        string email = Properties.Settings.Default.id;
        string password = Properties.Settings.Default.pw;
        //

        private void main_Load(object sender, EventArgs e)
        {
            //라운드 처리
            round(sender, e);

            //디렉토리 생성
            DirectoryInfo di = Directory.CreateDirectory(@"C:\goUP");
            di = Directory.CreateDirectory(@"C:\goUP\Brain");
            di = Directory.CreateDirectory(@"C:\goUP\Brain\.Trash");
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            //새로고침
            reload(sender, e);
        }

        private void round(object sender, EventArgs e)
        {
            //라운드 처리
            int ro1 = 50;
            int ro2 = 30;
            ApplyRoundCorners(this, ro1);
            ApplyRoundCorners(add_bt, ro2);
            ApplyRoundCorners(del_bt, ro2);
            ApplyRoundCorners(goupid_del_memo, ro2);
            ApplyRoundCorners(goupid_newbackup_bt, ro2);
            ApplyRoundCorners(fastmemo_bt, 40);
            ApplyRoundCorners(nameedit_bt, 40);
            ApplyRoundCorners(info_panel, ro1);
            ApplyRoundCorners(infoclose_bt, ro2);
        }

        private void ApplyRoundCorners(Control control, int cornerRadius)
        {
            // 둥근 모서리를 가진 Region 생성
            GraphicsPath path = new GraphicsPath();

            // 왼쪽 상단
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            // 오른쪽 상단
            path.AddArc(control.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            // 오른쪽 하단
            path.AddArc(control.Width - cornerRadius, control.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            // 왼쪽 하단
            path.AddArc(0, control.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);

            // 둥근 모서리 적용
            control.Region = new Region(path);
        }

        private void reload(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            var di = new DirectoryInfo(df);
            var files = di.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                listBox.Items.Add(file.Name.Replace(".goUP", ""));
            }

            try
            {
                using (StreamReader reader = new StreamReader(@"C:\goUP\theme.goup"))
                {
                    // 파일 내용을 변수에 읽어오기
                    string theme = reader.ReadLine();

                    // 파일 내용에 따라 테마 설정
                    if (theme == "goup-ui")
                    {
                        title1_panel.BackColor = Color.WhiteSmoke;
                        title2_panel.BackColor = Color.FromArgb(250, 250, 250);

                        del_bt.BackColor = Color.White;
                        add_bt.BackColor = Color.White;

                        listBox.BackColor = Color.FromArgb(240, 240, 240);

                        text_panel.BackColor = Color.White;
                        textBox.BackColor = Color.White;
                        title_textBox.BackColor = Color.White;
                    }
                    else if (theme == "win-xp")
                    {
                        title1_panel.BackColor = Color.Blue;
                        title2_panel.BackColor = Color.RoyalBlue;

                        del_bt.BackColor = Color.RoyalBlue;
                        add_bt.BackColor = Color.RoyalBlue;

                        listBox.BackColor = Color.CornflowerBlue;

                        text_panel.BackColor = Color.Ivory;
                        textBox.BackColor = Color.Ivory;
                        title_textBox.BackColor = Color.Ivory;
                    }
                    else if (theme == "x-mas")
                    {
                        title1_panel.BackColor = Color.Red;
                        title2_panel.BackColor = Color.Green;

                        del_bt.BackColor = Color.Red;
                        add_bt.BackColor = Color.Red;

                        listBox.BackColor = Color.DarkRed;

                        text_panel.BackColor = Color.Green;
                        textBox.BackColor = Color.Green;
                        title_textBox.BackColor = Color.Green;
                    }
                }
            }
            catch { }
        }

        private void infobox(object sender, EventArgs e)
        {
            info_label.Text = info_text;
            info_panel.Size = new Size(info_label.Size.Width + 60, 50);
            round(sender, e);
            info_panel.Location = new Point(10, 600);
            info_open_timer.Enabled = true;
        }

        private void add_bt_Click(object sender, EventArgs e)
        {
            int count = 1;

            while (System.IO.File.Exists(df + "새로운 시냅스 " + count + ".goUP"))
            {
                count++;
            }

            StreamWriter writer;
            writer = File.CreateText(df + "새로운 시냅스 " + count + ".goUP");
            writer.Close();

            //새로고침
            reload(sender, e);

            listBox.SelectedItem = "새로운 시냅스 " + count;
        }

        private void del_bt_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 1;

                while (System.IO.File.Exists(df + @".Trash\" + listBox.SelectedItem + " (" + count + ")" + ".goUP"))
                {
                    count++;
                }

                File.Move(df + listBox.SelectedItem + ".goUP", df + @".Trash\" + listBox.SelectedItem + " (" + count + ")" + ".goUP");

                //새로고침
                reload(sender, e);

                //알림 뛰우기
                info_text = "시냅스를 휴지통으로 보냈어요";
                info_panel.BackColor = Color.DodgerBlue;
                infobox(sender, e);
            }
            catch
            {
                //알림 뛰우기
                info_text = "시냅스를 휴지통으로 이동할수 없어요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(df + listBox.SelectedItem + ".goUP"))
            {
                textBox.Text = File.ReadAllText(df + listBox.SelectedItem + ".goUP");
                title_textBox.Text = listBox.SelectedItem.ToString();
                syname_label.Text = listBox.SelectedItem.ToString();
            }
            else
            {
                //reload(sender, e);

                /*//알림 뛰우기
                info_text = "열린 시냅스가 존재하지 않아요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);*/
            }

            if (goupid_title1_panel.Visible == false)
            {
                if_readmode = true;

                textBox.Visible = false;
                webBrowser.Visible = true;

                mode_bt.Text = "수정 모드로 전환하기";

                //마크다운 변환
                StringBuilder result = new StringBuilder();
                bool isInMarkdown = false;
                List<string> ignoreList = new List<string> { "#", "-", "" }; // 무시할 항목들

                foreach (char c in textBox.Text)
                {
                    if (ignoreList.Any(ignore => textBox.Text.StartsWith(ignore)))
                    {
                        isInMarkdown = true;
                        result.Append(c);
                    }
                    else if (c == '\n' && isInMarkdown)
                    {
                        // 무시
                    }
                    else
                    {
                        isInMarkdown = false;
                        result.Append(c);
                    }
                }

                // Markdown 변환
                string markdownText = Markdig.Markdown.ToHtml(textBox.Text);

                // 변환된 텍스트를 WebBrowser 컨트롤에 표시
                webBrowser.DocumentText = markdownText.Replace("\n", "<br>");

                //MessageBox.Show(result.ToString());

                ChangeWebBrowserStyle(webBrowser);
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                if (goupid_title1_panel.Visible == false)
                {
                    fastmemo_bt.Visible = true;
                }
            }
            else
            {
                fastmemo_bt.Visible = false;
                File.WriteAllText(df + listBox.SelectedItem + ".goUP", textBox.Text);
            }
        }
        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox.Text == "여기에서 시냅스를 빠르게 만들수 있어요")
            {
                textBox.Text = "";
            }
        }

        private void fastmemo_bt_Click(object sender, EventArgs e)
        {
            fastmemo_bt.Visible = false;

            int count = 1;

            while (System.IO.File.Exists(df + "새로운 시냅스 " + count + ".goUP"))
            {
                count++;
            }

            StreamWriter writer;
            writer = File.CreateText(df + "새로운 시냅스 " + count + ".goUP");
            writer.Close();

            File.WriteAllText(df + "새로운 시냅스 " + count + ".goUP", textBox.Text);

            //새로고침
            reload(sender, e);

            listBox.SelectedItem = "새로운 시냅스 " + count;
        }

        private void title_textBox_Enter(object sender, EventArgs e)
        {
            nameedit_bt.Visible = true;
        }

        private void title_textBox_Leave(object sender, EventArgs e)
        {
            nameedit_bt.Visible = false;
        }

        private void nameedit_bt_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null || title_textBox.Text.Contains(".goUP"))
            {
                //알림 뛰우기
                info_text = "제목을 바꿀수 없어요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);
            }
            else
            {
                File.Move(df + listBox.SelectedItem + ".goUP", df + title_textBox.Text + ".goUP");

                //새로고침
                reload(sender, e);
                listBox.SelectedItem = title_textBox.Text;

                //알림 뛰우기
                info_text = "제목을 바꿨어요";
                info_panel.BackColor = Color.DodgerBlue;
                infobox(sender, e);
            }
        }

        private void title_textBox_TextChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                if (goupid_title1_panel.Visible == false)
                {
                    title_textBox.Text = "열린 시냅스가 없어요";
                }
            }
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void opentrash_bt_Click(object sender, EventArgs e)
        {
            Process.Start(df + ".Trash");
        }

        private void title1_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mCurrentPosition = new Point(-e.X, -e.Y);
        }

        bool minimode = false;

        private void title1_panel_MouseMove(object sender, MouseEventArgs e)
        {
            /*if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                this.Location.X + (mCurrentPosition.X + e.X),
                this.Location.Y + (mCurrentPosition.Y + e.Y));
            }*/

            int screen = Screen.PrimaryScreen.Bounds.Height;
            int taskbarHeight = Screen.PrimaryScreen.Bounds.Height - Screen.PrimaryScreen.WorkingArea.Height;

            if (e.Button == MouseButtons.Left)
            {
                if (this.Location.Y + (mCurrentPosition.Y + e.Y) <= screen - taskbarHeight - 80)
                {
                    if (minimode == true)
                    {
                        minimode = false;

                        this.Size = new Size(800, 600);
                        minimode_panel.Visible = false;
                        round(sender, e);
                    }

                    this.Location = new Point(this.Location.X + (mCurrentPosition.X + e.X), this.Location.Y + (mCurrentPosition.Y + e.Y));
                }
                else
                {
                    Point two = new Point(Cursor.Position.X - 125, screen - taskbarHeight - 40);
                    this.Location = new Point((Size)two);

                    if (minimode != true)
                    {
                        minimode = true;

                        golocal_bt_Click(sender, e);
                        this.Size = new Size(250, 80);
                        minimode_panel.Visible = true;
                        round(sender, e);
                    }
                }
            }
        }

        private void info_open_timer_Tick(object sender, EventArgs e)
        {
            if (info_panel.Location.Y == 510)
            {
                info_panel.Location = new Point(10, 510);
                info_open_timer.Enabled = false;
            }
            else
            {
                info_panel.Location = new Point(10, info_panel.Location.Y - 5);
            }
        }

        private void infoclose_bt_Click(object sender, EventArgs e)
        {
            info_panel.Location = new Point(10, 600);
        }

        private void goupid_bt_Click(object sender, EventArgs e)
        {
            this.Hide();
            goupid f = new goupid("");
            f.ShowDialog();
            this.Show();
        }

        private void main_Shown(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autologin == true)
            {
                this.Hide();
                goupid f = new goupid("auto_login");
                f.ShowDialog();
                this.Show();

                //goupid_bt.Text = Properties.Settings.Default.id;
            }
        }

        bool if_readmode = true;

        private void mode_bt_Click(object sender, EventArgs e)
        {
            if (if_readmode == true)
            {
                if_readmode = false;

                textBox.Visible = true;
                webBrowser.Visible = false;

                mode_bt.Text = "마크다운 모드로 전환하기";
            }
            else
            {
                if_readmode = true;

                textBox.Visible = false;
                webBrowser.Visible = true;

                mode_bt.Text = "수정 모드로 전환하기";

                // Markdown 변환
                string markdownText = Markdig.Markdown.ToHtml(textBox.Text);

                // 변환된 텍스트를 WebBrowser 컨트롤에 표시
                webBrowser.DocumentText = markdownText.Replace("\n", "<br>");

                ChangeWebBrowserStyle(webBrowser);
            }
        }

        private void ChangeWebBrowserStyle(WebBrowser webBrowser)
        {
            // WebBrowser 컨트롤의 스타일 변경
            if (webBrowser.Document != null && webBrowser.Document.Body != null)
            {
                // 폰트 변경 예제
                webBrowser.Document.Body.Style = "font-family: '맑은 고딕'; font-size: 12pt;";
            }
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ChangeWebBrowserStyle(webBrowser);
        }

        private async void openfolder_bt_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autologin == true)
            {
                //
                openfolder_bt.Visible = false;

                title1_panel.Visible = false;
                goupid_title1_panel.Visible = true;

                goupid_backup_close.Enabled = false;
                goupid_backup_open.Enabled = true;

                //
                if_readmode = false;

                textBox.Visible = true;
                webBrowser.Visible = false;

                textBox.ReadOnly = true;

                mode_bt.Text = "goUP ID Cloud에 백업된 데이터 보는중";
                mode_bt.Enabled = false;

                listBox.SelectedItem = null;

                goupid_listBox.DataSource = null;
                goupid_listBox.Items.Clear();

                //
                // 비밀번호를 해시로 암호화
                string hashedPassword = ComputeSha256Hash(password);

                // HTTP 클라이언트 생성
                using (HttpClient client = new HttpClient())
                {
                    // 전송할 데이터 생성
                    var getMemosData = new
                    {
                        username = email,
                        password = hashedPassword // 암호화된 비밀번호 전송
                    };

                    // 데이터를 JSON 형식으로 변환
                    string getMemosJsonData = JsonConvert.SerializeObject(getMemosData);

                    // 서버 주소
                    string getMemosServerUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/brain/get-title";

                    try
                    {
                        // HTTP POST 요청
                        var getMemosResponse = await client.PostAsync(getMemosServerUrl, new StringContent(getMemosJsonData, Encoding.UTF8, "application/json"));

                        // 서버 응답 확인
                        if (getMemosResponse.IsSuccessStatusCode)
                        {
                            string memosResult = await getMemosResponse.Content.ReadAsStringAsync();
                            // memosResult는 JSON 형식의 데이터일 것이므로 파싱 후 목록 표시
                            var memos = JsonConvert.DeserializeObject<List<string>>(memosResult);
                            goupid_listBox.DataSource = memos;
                        }
                        else
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.Red;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemosResponse.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.Red;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                //알림 뛰우기
                info_text = "⚠️ | goUP ID에 로그인해야 사용할수 있어요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (System.Security.Cryptography.SHA256 sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void goupid_backup_open_Tick(object sender, EventArgs e)
        {
            if (goupid_title1_panel.Size.Height + 30 > 250)
            {
                goupid_backup_open.Enabled = false;
                //this.Size = new Size(250, 600);
                goupid_title1_panel.Size = new Size(250, 600);
                //round(sender, e);
            }
            else
            {
                //this.Size = new Size(this.Size.Width - 30, 600);
                goupid_title1_panel.Size = new Size(250, goupid_title1_panel.Size.Height + 30);
            }
        }

        private void golocal_bt_Click(object sender, EventArgs e)
        {
            //ApplyRoundCornersAll(this, 50);

            openfolder_bt.Visible = true;

            goupid_backup_close.Enabled = true;
            goupid_backup_open.Enabled = false;

            //
            if_readmode = true;

            textBox.Visible = false;
            webBrowser.Visible = true;

            textBox.ReadOnly = false;

            mode_bt.Text = "수정 모드로 전환";
            mode_bt.Enabled = true;

            reload(sender, e);
        }

        private void goupid_backup_close_Tick(object sender, EventArgs e)
        {
            if (goupid_title1_panel.Size.Height - 30 < 40)
            {
                goupid_backup_close.Enabled = false;
                //this.Size = new Size(800, 600);
                goupid_title1_panel.Size = new Size(250, 40);
                title1_panel.Visible = true;
                goupid_title1_panel.Visible = false;
                //round(sender, e);
            }
            else
            {
                //this.Size = ne Size(this.Size.Width + 30, 600);
                goupid_title1_panel.Size = new Size(250, goupid_title1_panel.Size.Height - 30);
            }
        }

        private async void goupid_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (goupid_listBox.Items.Count != 0)
            {
                // 사용자 입력 정보
                string selectedMemoName = goupid_listBox.SelectedItem?.ToString();

                if (selectedMemoName != null)
                {
                    // 비밀번호를 해시로 암호화
                    string hashedPassword = ComputeSha256Hash(password);

                    // HTTP 클라이언트 생성
                    using (HttpClient client = new HttpClient())
                    {
                        // 전송할 데이터 생성
                        var getMemoContentData = new
                        {
                            username = email,
                            password = hashedPassword, // 암호화된 비밀번호 전송
                            memoName = selectedMemoName
                        };

                        // 데이터를 JSON 형식으로 변환
                        string getMemoContentJsonData = JsonConvert.SerializeObject(getMemoContentData);

                        // 서버 주소
                        string getMemoContentServerUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/brain/get-memo";

                        try
                        {
                            // HTTP POST 요청
                            var getMemoContentResponse = await client.PostAsync(getMemoContentServerUrl, new StringContent(getMemoContentJsonData, Encoding.UTF8, "application/json"));

                            // 서버 응답 확인
                            if (getMemoContentResponse.IsSuccessStatusCode)
                            {
                                string memoContentResult = await getMemoContentResponse.Content.ReadAsStringAsync();
                                memoContentResult = DecryptString(memoContentResult, password);

                                if (memoContentResult == "error")
                                {
                                    //알림 뛰우기
                                    info_text = "⚠️ | 시냅스를 복호화할수 없어요";
                                    info_panel.BackColor = Color.Red;
                                    infobox(sender, e);
                                }
                                else
                                {
                                    title_textBox.Text = selectedMemoName;
                                    textBox.Text = memoContentResult;
                                }
                            }
                            else
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 서버에 문제가 있어요";
                                info_panel.BackColor = Color.Red;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemoContentResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.Red;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                                "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                else
                {
                    //알림 뛰우기
                    /*info_text = "⚠️ | goUP Brain 앱에 문제가 있어요";
                    info_panel.BackColor = Color.Red;
                    infobox(sender, e);

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "\"error/goup/brain/web/not-seleted-memo/0001\"",
                        "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);*/
                }
            }
        }

        private async void goupid_res_bt_Click(object sender, EventArgs e)
        {
            string selectedMemoName = goupid_listBox.SelectedItem?.ToString();

            if (selectedMemoName != null)
            {
                // 비밀번호를 해시로 암호화
                string hashedPassword = ComputeSha256Hash(password);

                // HTTP 클라이언트 생성
                using (HttpClient client = new HttpClient())
                {
                    // 전송할 데이터 생성
                    var getMemoContentData = new
                    {
                        username = email,
                        password = hashedPassword, // 암호화된 비밀번호 전송
                        memoName = selectedMemoName
                    };

                    // 데이터를 JSON 형식으로 변환
                    string getMemoContentJsonData = JsonConvert.SerializeObject(getMemoContentData);

                    // 서버 주소
                    string getMemoContentServerUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/brain/get-memo";

                    try
                    {
                        // HTTP POST 요청
                        var getMemoContentResponse = await client.PostAsync(getMemoContentServerUrl, new StringContent(getMemoContentJsonData, Encoding.UTF8, "application/json"));

                        // 서버 응답 확인
                        if (getMemoContentResponse.IsSuccessStatusCode)
                        {
                            string memoContentResult = await getMemoContentResponse.Content.ReadAsStringAsync();
                            memoContentResult = DecryptString(memoContentResult, password);

                            if (memoContentResult == "error")
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 시냅스를 복호화할수 없어요";
                                info_panel.BackColor = Color.Red;
                                infobox(sender, e);
                            }
                            else
                            {
                                File.WriteAllText(df + selectedMemoName + ".goUP", memoContentResult);

                                //알림 뛰우기
                                info_text = "goUP ID Cloud에서 시냅스를 가져왔어요";
                                info_panel.BackColor = Color.DodgerBlue;
                                infobox(sender, e);
                            }
                        }
                        else
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.Red;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemoContentResponse.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.Red;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                //알림 뛰우기
                info_text = "⚠️ | goUP Brain 앱에 문제가 있어요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);

                MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "error/goup/brain/web/not-seleted-memo/0001", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private async void goupid_newbackup_bt_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string memoName = listBox.SelectedItem.ToString();
                string memoContent = File.ReadAllText(df + listBox.SelectedItem + ".goUP");

                // 비밀번호 암호화
                string hashedPassword = ComputeSha256Hash(password);
                // 시냅스 암호화
                memoContent = EncryptString(memoContent, password);

                if (memoContent == "error")
                {
                    //알림 뛰우기
                    info_text = "⚠️ | 시냅스를 암호화할수 없어요";
                    info_panel.BackColor = Color.Red;
                    infobox(sender, e);
                }
                else
                {
                    // HTTP 클라이언트 생성
                    using (HttpClient client = new HttpClient())
                    {
                        // 전송할 데이터 생성
                        var addMemoData = new
                        {
                            username = email,
                            password = hashedPassword, // 암호화된 비밀번호 전송
                            memoName = memoName,
                            memoContent = memoContent
                        };

                        // 데이터를 JSON 형식으로 변환
                        string addMemoJsonData = JsonConvert.SerializeObject(addMemoData);

                        // 서버 주소
                        string addMemoServerUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/brain/add-memo";

                        try
                        {
                            // HTTP POST 요청
                            var addMemoResponse = await client.PostAsync(addMemoServerUrl, new StringContent(addMemoJsonData, Encoding.UTF8, "application/json"));

                            // 서버 응답 확인
                            if (addMemoResponse.IsSuccessStatusCode)
                            {
                                string addMemoResult = await addMemoResponse.Content.ReadAsStringAsync();

                                //알림 뛰우기
                                info_text = "goUP ID Cloud에 시냅스를 백업했어요";
                                info_panel.BackColor = Color.DodgerBlue;
                                infobox(sender, e);
                            }
                            else
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 서버에 문제가 있어요";
                                info_panel.BackColor = Color.Red;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + addMemoResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.Red;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                                "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
        }

        private async void goupid_del_memo_Click(object sender, EventArgs e)
        {
            // 사용자 입력 정보
            string selectedMemoName = goupid_listBox.SelectedItem?.ToString();

            if (selectedMemoName != null)
            {
                // 비밀번호를 해시로 암호화
                string hashedPassword = ComputeSha256Hash(password);

                // HTTP 클라이언트 생성
                using (HttpClient client = new HttpClient())
                {
                    // 전송할 데이터 생성
                    var deleteMemoData = new
                    {
                        username = email,
                        password = hashedPassword, // 암호화된 비밀번호 전송
                        memoName = selectedMemoName
                    };

                    // 데이터를 JSON 형식으로 변환
                    string deleteMemoJsonData = JsonConvert.SerializeObject(deleteMemoData);

                    // 서버 주소
                    string deleteMemoServerUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/brain/del-memo";

                    try
                    {
                        // HTTP POST 요청
                        var deleteMemoResponse = await client.PostAsync(deleteMemoServerUrl, new StringContent(deleteMemoJsonData, Encoding.UTF8, "application/json"));

                        // 서버 응답 확인
                        if (deleteMemoResponse.IsSuccessStatusCode)
                        {
                            string deleteMemoResult = await deleteMemoResponse.Content.ReadAsStringAsync();

                            //알림 뛰우기
                            info_text = "goUP ID Cloud에 저장된 시냅스를 삭제했어요";
                            info_panel.BackColor = Color.DodgerBlue;
                            infobox(sender, e);

                            // 메모 목록 갱신
                            openfolder_bt_Click(sender, e);
                        }
                        else
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.Red;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + deleteMemoResponse.StatusCode,
                                "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.Red;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                            "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                //알림 뛰우기
                info_text = "⚠️ | goUP Brain 앱에 문제가 있어요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);

                MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "error/goup/brain/web/not-seleted-memo/0001",
                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private static string EncryptString(string InputText, string Password)
        {
            string EncryptedData = "";
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();
                byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(PlainText, 0, PlainText.Length);
                cryptoStream.FlushFinalBlock();
                byte[] CipherBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                EncryptedData = Convert.ToBase64String(CipherBytes);
            }
            catch
            {
                return "error";
            }
            return EncryptedData;
        }

        private static string DecryptString(string InputText, string Password)
        {
            string DecryptedData = "";   // 리턴값
            try
            {
                RijndaelManaged RijndaelCipher = new RijndaelManaged();

                byte[] EncryptedData = Convert.FromBase64String(InputText);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

                // Decryptor 객체를 만든다.
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

                MemoryStream memoryStream = new MemoryStream(EncryptedData);

                // 데이터 읽기(복호화이므로) 용도로 cryptoStream객체를 선언, 초기화
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

                // 복호화된 데이터를 담을 바이트 배열을 선언한다.
                // 길이는 알 수 없지만, 일단 복호화되기 전의 데이터의 길이보다는
                // 길지 않을 것이기 때문에 그 길이로 선언한다.
                byte[] PlainText = new byte[EncryptedData.Length];

                // 복호화 시작
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);

                memoryStream.Close();
                cryptoStream.Close();

                // 복호화된 데이터를 문자열로 바꾼다.
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                return "error";
            }
            // 최종 결과 리턴
            return DecryptedData;
        }

        private void beta_info_github_label_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Error-ForestofMaking/goUP-Brain");
        }

        private void beta_info_close_label_Click(object sender, EventArgs e)
        {
            beta_info_panel.Visible = false;
        }

        private void show_beta_info_label_Click(object sender, EventArgs e)
        {
            beta_info_panel.Visible = true;
        }

        bool etc_menu_isopen = false;

        private void etc_bt_Click(object sender, EventArgs e)
        {
            if (etc_menu_isopen != true)
            {
                //열기
                etc_menu_isopen = true;

                etc_panel.Visible = true;

                etc_bt.Text = "▼";
                etc_bt.BackColor = Color.DodgerBlue;
                etc_bt.ForeColor = Color.White;
            }
            else
            {
                //닫기
                etc_menu_isopen = false;

                etc_panel.Visible = false;

                etc_bt.Text = "▲";
                etc_bt.BackColor = Color.WhiteSmoke;
                etc_bt.ForeColor = Color.Black;
            }
        }

        private void open_folder_bt_Click(object sender, EventArgs e)
        {
            etc_bt_Click(sender, e);

            Process.Start(@"C:\goUP\Brain");
        }

        private void open_trash_bt_Click(object sender, EventArgs e)
        {
            etc_bt_Click(sender, e);

            Process.Start(@"C:\goUP\Brain\.Trash");
        }

        private void restore_trash_bt_Click(object sender, EventArgs e)
        {
            etc_bt_Click(sender, e);

            if (MessageBox.Show("휴지통에 있는 모든 시냅스를 복원할까요?", "goUP Brain", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    // 폴더 A의 모든 파일 가져오기
                    string[] files = Directory.GetFiles(@"C:\goUP\Brain\.Trash");

                    // 각 파일을 폴더 B로 이동하고 파일 이름에 "복원:" 추가
                    foreach (string file in files)
                    {
                        // 파일 이름에서 파일명 추출
                        string fileName = Path.GetFileName(file);

                        // 파일을 폴더 B로 이동하고 이름에 "복원:" 추가
                        string newFilePath = Path.Combine(@"C:\goUP\Brain", "!! " + fileName);
                        File.Move(file, newFilePath);

                        //알림 뛰우기
                        info_text = fileName + " 시냅스를 복원했어요";
                        info_panel.BackColor = Color.DodgerBlue;
                        infobox(sender, e);
                    }

                    reload(sender, e);

                    //알림 뛰우기
                    info_text = "시냅스를 모두 복원했어요";
                    info_panel.BackColor = Color.DodgerBlue;
                    infobox(sender, e);
                }
                catch (Exception ex)
                {
                    //알림 뛰우기
                    info_text = "⚠️ | 시냅스를 복원할수 없어요";
                    info_panel.BackColor = Color.Red;
                    infobox(sender, e);

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                        "goUP Brain", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }
    }
}
