using DiscordRPC;
using DiscordRPC.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

            //디스코드
            discord_start();

            //버전
            beta_info_label.Text = "⚠️ Beta | goUP Brain " + Properties.app.Default.version;

            //베타
            if (Properties.app.Default.is_beta == true)
            {
                beta_info_panel.Visible = true;
            }

            //디렉토리 생성
            DirectoryInfo di = Directory.CreateDirectory(@"C:\goUP");
            di = Directory.CreateDirectory(@"C:\goUP\Brain");
            di = Directory.CreateDirectory(@"C:\goUP\Brain\.Trash");
            di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;

            //새로고침
            reload(sender, e);

            // 시냅스 선택
            if (listBox.Items.Count != 0)
            {
                listBox.SelectedIndex = 0;
            }
        }

        public DiscordRpcClient client;

        private void discord_start()
        {
            client = new DiscordRpcClient("1227451314838175814");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                //MessageBox.Show("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                //MessageBox.Show("Received Update! {0}", e.Presence.ToString());
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "시냅스 편집중",
                //State = "시냅스 편집중",

                Buttons = new DiscordRPC.Button[]
                {
                    new DiscordRPC.Button() { Label = "goUP Brain 다운로드", Url = "https://goup.ggm.kr/download" },
                    new DiscordRPC.Button() { Label = "더 알아보기", Url = "https://goup.ggm.kr/apps/goup-brain" }
                },

                Assets = new Assets()
                {
                    LargeImageKey = "goup_brain",
                    LargeImageText = "goUP Brain"
                }
            });
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

            ApplyRoundCorners(del_cloudedit_bt, ro2);
            ApplyRoundCorners(new_cloudedit_bt, ro2);

            ApplyRoundCorners(fastmemo_bt, 40);
            ApplyRoundCorners(cloudedit_save_bt, 40);
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

            /*try
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
            catch { }*/
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
                info_panel.BackColor = Color.OrangeRed;
                infobox(sender, e);
            }
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(df + listBox.SelectedItem + ".goUP"))
            {
                textBox.Text = File.ReadAllText(df + listBox.SelectedItem + ".goUP");
                title_textBox.Text = listBox.SelectedItem.ToString();
                //syname_label.Text = listBox.SelectedItem.ToString();
            }

            if (goupid_title1_panel.Visible == false)
            {
                //이모티콘닫기
                em_panel_isopen = false;

                em_panel.Visible = false;

                em_bt.BackColor = Color.FromArgb(250, 250, 250);
                em_bt.ForeColor = Color.Black;

                em_bt.Visible = false;

                //마크다운 변환
                if_readmode = true;

                textBox.Visible = false;
                webBrowser.Visible = true;

                mode_bt.Text = "수정 모드로 전환하기";

                // Markdown 변환
                string markdownText = Markdig.Markdown.ToHtml(textBox.Text);

                // 변환된 텍스트를 WebBrowser 컨트롤에 표시
                markdownText = markdownText.Replace("\n", "<br>");

                markdownText = Regex.Replace(markdownText, @"\{::emoticon-(\d+)::\}", m =>
                {
                    int number = int.Parse(m.Groups[1].Value);
                    string imagePath = $"C:\\goUP\\BrainApp\\em_{number}.png";
                    return $"<img src=\"{imagePath}\" alt=\"emoticon-{number}\" />";
                });

                webBrowser.DocumentText = markdownText;

                if (devmode == true)
                {
                    webBrowser.DocumentText = textBox.Text;
                }

                ChangeWebBrowserStyle(webBrowser);
            }
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                if (goupid_title1_panel.Visible == false && cloudedit_title_panel.Visible == false)
                {
                    fastmemo_bt.Visible = true;
                }
            }
            else if (cloudedit_title_panel.Visible == true)
            {
                if (cloudedit_memoContentResult == textBox.Text)
                {
                    // 같을때
                    syname_label.Text = "Cloud 편집 - 저장되었어요";
                    syname_label.ForeColor = Color.DodgerBlue;

                    cloudedit_save_bt.Visible = false;
                }
                else
                {
                    // 다를때
                    syname_label.Text = "Cloud 편집 - 저장되지 않았어요";
                    syname_label.ForeColor = Color.Orange;

                    cloudedit_save_bt.Visible = true;
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

        private async void nameedit_bt_Click(object sender, EventArgs e)
        {
            if (cloudedit_title_panel.Visible == false)
            {
                if (listBox.SelectedItem == null || title_textBox.Text.Contains(".goUP") || title_textBox.Text.Contains(".goup"))
                {
                    //알림 뛰우기
                    info_text = "제목을 바꿀수 없어요";
                    info_panel.BackColor = Color.OrangeRed;
                    infobox(sender, e);
                }
                else
                {
                    try
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
                    catch
                    {
                        //알림 뛰우기
                        info_text = "제목을 바꿀수 없어요";
                        info_panel.BackColor = Color.OrangeRed;
                        infobox(sender, e);
                    }
                }
            }
            else
            {
                // 계정 정보
                email = Properties.Settings.Default.id;
                password = Properties.Settings.Default.pw;

                // 사용자 입력 정보
                string selectedMemoName = cloudedit_listBox.SelectedItem?.ToString();
                string newMemoName = title_textBox.Text; // 새 메모 이름 입력란

                if (selectedMemoName != null && newMemoName != null)
                {
                    // 비밀번호를 해시로 암호화
                    string hashedPassword = ComputeSha256Hash(password);

                    // HTTP 클라이언트 생성
                    using (HttpClient client = new HttpClient())
                    {
                        // 전송할 데이터 생성
                        var renameMemoData = new
                        {
                            username = email,
                            password = hashedPassword, // 암호화된 비밀번호 전송
                            oldMemoName = selectedMemoName,
                            newMemoName = newMemoName // 새 메모 이름
                        };

                        // 데이터를 JSON 형식으로 변환
                        string renameMemoJsonData = JsonConvert.SerializeObject(renameMemoData);

                        // 서버 주소
                        string renameMemoServerUrl = "https://goup-id-auth.goup.ggm.kr/brain/new-title";

                        try
                        {
                            // HTTP POST 요청
                            var renameMemoResponse = await client.PostAsync(renameMemoServerUrl, new StringContent(renameMemoJsonData, Encoding.UTF8, "application/json"));

                            // 서버 응답 확인
                            if (renameMemoResponse.IsSuccessStatusCode)
                            {
                                string renameMemoResult = await renameMemoResponse.Content.ReadAsStringAsync();
                                //MessageBox.Show(renameMemoResult, "메모 이름 변경 결과");


                                if (renameMemoResult == "brain-true")
                                {
                                    //알림 뛰우기
                                    info_text = "Cloud 시냅스의 제목을 바꿨어요";
                                    info_panel.BackColor = Color.DodgerBlue;
                                    infobox(sender, e);
                                }
                                else if (renameMemoResult == "brain-false-not_select_memo")
                                {
                                    //알림 뛰우기
                                    info_text = "⚠️ | 앱에 문제가 있어요";
                                    info_panel.BackColor = Color.OrangeRed;
                                    infobox(sender, e);

                                    MessageBox.Show("앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + renameMemoResult, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                }
                                else if (renameMemoResult == "brain-false-password_error")
                                {
                                    //알림 뛰우기
                                    info_text = "⚠️ | 앱 또는 서버에 문제가 있어요";
                                    info_panel.BackColor = Color.OrangeRed;
                                    infobox(sender, e);

                                    MessageBox.Show("앱 또는 서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + renameMemoResult, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                }
                                else
                                {
                                    //알림 뛰우기
                                    info_text = "⚠️ | 알수 없는 문제가 있어요";
                                    info_panel.BackColor = Color.OrangeRed;
                                    infobox(sender, e);

                                    MessageBox.Show("알수 없는 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + renameMemoResult, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                }

                                // 메모 목록 갱신
                                open_cloudedit_bt_Click(sender, e);
                            }
                            else
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 서버에 문제가 있어요";
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + renameMemoResponse.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                else
                {
                    //알림 뛰우기
                    info_text = "⚠️ | 시냅스 제목을 입력해주세요";
                    info_panel.BackColor = Color.OrangeRed;
                    infobox(sender, e);
                }
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
                em_bt.Visible = true;

                if_readmode = false;

                textBox.Visible = true;
                webBrowser.Visible = false;

                mode_bt.Text = "마크다운 모드로 전환하기";
            }
            else
            {
                //이모티콘닫기
                em_panel_isopen = false;

                em_panel.Visible = false;

                em_bt.BackColor = Color.FromArgb(250, 250, 250);
                em_bt.ForeColor = Color.Black;

                em_bt.Visible = false;


                //시작
                if_readmode = true;

                textBox.Visible = false;
                webBrowser.Visible = true;

                mode_bt.Text = "수정 모드로 전환하기";

                // Markdown 변환
                string markdownText = Markdig.Markdown.ToHtml(textBox.Text);

                // 변환된 텍스트를 WebBrowser 컨트롤에 표시
                markdownText = markdownText.Replace("\n", "<br>");

                markdownText = Regex.Replace(markdownText, @"\{::emoticon-(\d+)::\}", m =>
                {
                    int number = int.Parse(m.Groups[1].Value);
                    string imagePath = $"C:\\goUP\\BrainApp\\em_{number}.png";
                    return $"<img src=\"{imagePath}\" alt=\"emoticon-{number}\" />";
                });

                webBrowser.DocumentText = markdownText;

                if (devmode == true)
                {
                    webBrowser.DocumentText = textBox.Text;
                }

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
            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

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
                                string onebone = await getMemoContentResponse.Content.ReadAsStringAsync();
                                string memoContentResult = await getMemoContentResponse.Content.ReadAsStringAsync();
                                memoContentResult = DecryptString(memoContentResult, password);

                                if (memoContentResult == "error")
                                {
                                    title_textBox.Text = "암호화된 시냅스";
                                    textBox.Text = onebone;

                                    //알림 뛰우기
                                    info_text = "⚠️ | 시냅스를 복호화할수 없어요";
                                    info_panel.BackColor = Color.OrangeRed;
                                    infobox(sender, e);

                                    MessageBox.Show("시냅스를 복구할수 없어요\r\n대신 암호화된 내용을 로드했어요\r\n설정 ❯ 시냅스 복구에서 시냅스를 복구해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemoContentResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
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
                    info_panel.BackColor = Color.OrangeRed;
                    infobox(sender, e);

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "\"error/goup/brain/web/not-seleted-memo/0001\"",
                        "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);*/
                }
            }
        }

        private async void goupid_res_bt_Click(object sender, EventArgs e)
        {
            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

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
                            string onebone = await getMemoContentResponse.Content.ReadAsStringAsync();
                            string memoContentResult = await getMemoContentResponse.Content.ReadAsStringAsync();
                            memoContentResult = DecryptString(memoContentResult, password);

                            if (memoContentResult == "error")
                            {
                                int count = 1;

                                while (System.IO.File.Exists(df + "암호화된 시냅스 " + count + ".goUP"))
                                {
                                    count++;
                                }

                                StreamWriter writer;
                                writer = File.CreateText(df + "암호화된 시냅스 " + count + ".goUP");
                                writer.Close();

                                File.WriteAllText(df + "암호화된 시냅스 " + count + ".goUP", onebone);

                                //새로고침
                                reload(sender, e);

                                //알림 뛰우기
                                info_text = "⚠️ | 시냅스를 복호화할수 없어요";
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("시냅스를 복구할수 없어요\r\n대신 암호화된 내용을 저장했어요\r\n설정 ❯ 시냅스 복구에서 시냅스를 복구해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
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
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemoContentResponse.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.OrangeRed;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                //알림 뛰우기
                info_text = "⚠️ | goUP Brain 앱에 문제가 있어요";
                info_panel.BackColor = Color.OrangeRed;
                infobox(sender, e);

                MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "error/goup/brain/web/not-seleted-memo/0001", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private async void goupid_newbackup_bt_Click(object sender, EventArgs e)
        {
            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

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
                    info_text = "⚠️ | 시냅스를 암호화할수 없어요. 백업하지 못했어요";
                    info_panel.BackColor = Color.OrangeRed;
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
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + addMemoResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
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
            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

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
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + deleteMemoResponse.StatusCode,
                                "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.OrangeRed;
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
                info_panel.BackColor = Color.OrangeRed;
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
                etc_bt.BackColor = Color.FromArgb(250, 250, 250);
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
                    info_panel.BackColor = Color.OrangeRed;
                    infobox(sender, e);

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                        "goUP Brain", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void open_settings_bt_Click(object sender, EventArgs e)
        {
            //etc_bt_Click(sender, e);

            //this.Hide();

            settings f = new settings();
            f.ShowDialog();

            reload(sender, e);

            //this.Show();
        }

        private async void open_cloudedit_bt_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autologin == true)
            {
                // 패널 보이기 변경
                cloudedit_title_panel.Visible = true;
                title1_panel.Visible = false;
                goupid_title1_panel.Visible = false;

                // 버튼 백컬러 변경
                open_cloudedit_bt.BackColor = Color.DodgerBlue;
                golocal_bt.BackColor = Color.WhiteSmoke;
                //openfolder_bt.BackColor = Color.WhiteSmoke;

                // 버튼 폰트 컬러 변경
                open_cloudedit_bt.ForeColor = Color.White;
                golocal_bt.ForeColor = Color.Black;
                //openfolder_bt.ForeColor = Color.Black;

                // 텍스트박스 설정
                textBox.Visible = false;
                webBrowser.Visible = true;
                textBox.ReadOnly = false;

                // 버튼 보이기 설정
                goupid_res_bt.Visible = false;
                cloudedit_save_bt.Visible = false;

                syname_label.ForeColor = Color.Black;
                syname_label.Text = "Cloud 편집 - 열린 시냅스가 없어요";

                fastmemo_bt.Visible = false;

                // 모드 선택기 설정
                if_readmode = true;
                mode_bt.Text = "수정 모드로 전환";
                mode_bt.Enabled = true;

                // 리스트박스 클리어
                cloudedit_listBox.DataSource = null;
                cloudedit_listBox.Items.Clear();

                // 계정 정보
                email = Properties.Settings.Default.id;
                password = Properties.Settings.Default.pw;

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
                    string getMemosServerUrl = "https://goup-id-auth.goup.ggm.kr/brain/get-title";

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
                            cloudedit_listBox.DataSource = memos;
                        }
                        else
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemosResponse.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.OrangeRed;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                //알림 뛰우기
                info_text = "⚠️ | goUP ID에 로그인해야 사용할수 있어요";
                info_panel.BackColor = Color.OrangeRed;
                infobox(sender, e);
            }
        }

        private void golocal_bt_Click(object sender, EventArgs e)
        {
            // 패널 보이기 변경
            cloudedit_title_panel.Visible = false;
            title1_panel.Visible = true;
            goupid_title1_panel.Visible = false;

            // 버튼 백컬러 변경
            open_cloudedit_bt.BackColor = Color.WhiteSmoke;
            golocal_bt.BackColor = Color.DodgerBlue;
            //openfolder_bt.BackColor = Color.WhiteSmoke;

            // 버튼 폰트 컬러 변경
            open_cloudedit_bt.ForeColor = Color.Black;
            golocal_bt.ForeColor = Color.White;
            //openfolder_bt.ForeColor = Color.Black;

            // 텍스트박스 설정
            textBox.Visible = false;
            webBrowser.Visible = true;
            textBox.ReadOnly = false;

            // 버튼 보이기 설정
            goupid_res_bt.Visible = false;
            cloudedit_save_bt.Visible = false;

            syname_label.ForeColor = Color.Black;
            syname_label.Text = "로컬에서 편집중이에요";

            // 모드 선택기 설정
            if_readmode = true;
            mode_bt.Text = "수정 모드로 전환";
            mode_bt.Enabled = true;

            // 리로드
            reload(sender, e);

            // 시냅스 선택
            if (listBox.Items.Count != 0)
            {
                listBox.SelectedIndex = 0;
            }
        }

        private async void openfolder_bt_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.autologin == true)
            {
                // 패널 보이기 변경
                cloudedit_title_panel.Visible = false;
                title1_panel.Visible = false;
                goupid_title1_panel.Visible = true;

                // 버튼 백컬러 변경
                open_cloudedit_bt.BackColor = Color.WhiteSmoke;
                golocal_bt.BackColor = Color.WhiteSmoke;
                //openfolder_bt.BackColor = Color.DodgerBlue;

                // 버튼 폰트 컬러 변경
                open_cloudedit_bt.ForeColor = Color.Black;
                golocal_bt.ForeColor = Color.Black;
                //openfolder_bt.ForeColor = Color.White;

                // 텍스트박스 설정
                textBox.Visible = true;
                webBrowser.Visible = false;
                textBox.ReadOnly = true;

                // 버튼 보이기 설정
                goupid_res_bt.Visible = true;
                cloudedit_save_bt.Visible = false;

                // 모드 선택기 설정
                if_readmode = false;
                mode_bt.Text = "goUP Cloud에 백업된 시냅스 보는중";
                mode_bt.Enabled = false;

                // 리스트박스 클리어
                goupid_listBox.DataSource = null;
                goupid_listBox.Items.Clear();

                // 계정 정보
                email = Properties.Settings.Default.id;
                password = Properties.Settings.Default.pw;

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
                    string getMemosServerUrl = "https://goup-id-auth.goup.ggm.kr/brain/get-title";

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
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemosResponse.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.OrangeRed;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            else
            {
                //알림 뛰우기
                info_text = "⚠️ | goUP ID에 로그인해야 사용할수 있어요";
                info_panel.BackColor = Color.OrangeRed;
                infobox(sender, e);
            }
        }

        string cloudedit_memoContentResult = null;

        private async void cloudedit_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //이모티콘닫기
            em_panel_isopen = false;

            em_panel.Visible = false;

            em_bt.BackColor = Color.FromArgb(250, 250, 250);
            em_bt.ForeColor = Color.Black;

            em_bt.Visible = false;

            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

            if (cloudedit_listBox.Items.Count != 0)
            {
                // 사용자 입력 정보
                string selectedMemoName = cloudedit_listBox.SelectedItem?.ToString();

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
                                string onebone = await getMemoContentResponse.Content.ReadAsStringAsync();
                                string memoContentResult = await getMemoContentResponse.Content.ReadAsStringAsync();
                                memoContentResult = DecryptString(memoContentResult, password);

                                if (memoContentResult == "error")
                                {
                                    title_textBox.Text = "암호화된 시냅스";
                                    textBox.Text = onebone;

                                    //알림 뛰우기
                                    info_text = "⚠️ | 시냅스를 복호화할수 없어요";
                                    info_panel.BackColor = Color.OrangeRed;
                                    infobox(sender, e);

                                    MessageBox.Show("시냅스를 복구할수 없어요\r\n대신 암호화된 내용을 로드했어요\r\n설정 ❯ 시냅스 복구에서 시냅스를 복구해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                }
                                else
                                {
                                    title_textBox.Text = selectedMemoName;
                                    textBox.Text = memoContentResult;

                                    cloudedit_memoContentResult = textBox.Text;

                                    richTextBox_TextChanged(sender, e);

                                    //MessageBox.Show(cloudedit_memoContentResult + "\r\n" + textBox.Text, "test");
                                }
                            }
                            else
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 서버에 문제가 있어요";
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + getMemoContentResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
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
                    info_panel.BackColor = Color.OrangeRed;
                    infobox(sender, e);

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "\"error/goup/brain/web/not-seleted-memo/0001\"",
                        "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);*/
                }
            }

            if_readmode = true;

            textBox.Visible = false;
            webBrowser.Visible = true;

            mode_bt.Text = "수정 모드로 전환하기";

            //마크다운 변환
            if_readmode = true;

            textBox.Visible = false;
            webBrowser.Visible = true;

            mode_bt.Text = "수정 모드로 전환하기";

            // Markdown 변환
            string markdownText = Markdig.Markdown.ToHtml(textBox.Text);

            // 변환된 텍스트를 WebBrowser 컨트롤에 표시
            markdownText = markdownText.Replace("\n", "<br>");

            markdownText = Regex.Replace(markdownText, @"\{::emoticon-(\d+)::\}", m =>
            {
                int number = int.Parse(m.Groups[1].Value);
                string imagePath = $"C:\\goUP\\BrainApp\\em_{number}.png";
                return $"<img src=\"{imagePath}\" alt=\"emoticon-{number}\" />";
            });

            webBrowser.DocumentText = markdownText;

            if (devmode == true)
            {
                webBrowser.DocumentText = textBox.Text;
            }

            ChangeWebBrowserStyle(webBrowser);
        }

        private async void new_cloudedit_bt_Click(object sender, EventArgs e)
        {
            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

            if (listBox.SelectedItem != null)
            {
                int count = 1;
                //open_cloudedit_bt_Click(sender, e);

                while (cloudedit_listBox.Items.Contains("새로운 시냅스 " + count))
                {
                    count++;
                }

                string memoName = "새로운 시냅스 " + count;
                string memoContent = "";

                // 비밀번호 암호화
                string hashedPassword = ComputeSha256Hash(password);
                // 시냅스 암호화
                memoContent = EncryptString(memoContent, password);

                if (memoContent == "error")
                {
                    //알림 뛰우기
                    info_text = "⚠️ | 시냅스를 암호화할수 없어요. 시냅스를 만들지 못했어요";
                    info_panel.BackColor = Color.OrangeRed;
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
                        string addMemoServerUrl = "https://goup-id-auth.goup.ggm.kr/brain/add-memo";

                        try
                        {
                            // HTTP POST 요청
                            var addMemoResponse = await client.PostAsync(addMemoServerUrl, new StringContent(addMemoJsonData, Encoding.UTF8, "application/json"));

                            // 서버 응답 확인
                            if (addMemoResponse.IsSuccessStatusCode)
                            {
                                string addMemoResult = await addMemoResponse.Content.ReadAsStringAsync();

                                open_cloudedit_bt_Click(sender, e);

                                //알림 뛰우기
                                info_text = "goUP Cloud에 시냅스를 만들었어요";
                                info_panel.BackColor = Color.DodgerBlue;
                                infobox(sender, e);
                            }
                            else
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 서버에 문제가 있어요";
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + addMemoResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                                "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
        }

        private async void del_cloudedit_bt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cloud 편집에서 삭제한 시냅스는 복구할수 없어요\r\n휴지통 없이 서버에서 즉시 삭제되며 복원할수 없어요\r\n정말로 삭제할까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                //if (MessageBox.Show("삭제하기 전 로컬 폴더에 시냅스를 복사할까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                }

                email = Properties.Settings.Default.id;
                password = Properties.Settings.Default.pw;

                // 사용자 입력 정보
                string selectedMemoName = cloudedit_listBox.SelectedItem?.ToString();

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
                        string deleteMemoServerUrl = "https://goup-id-auth.goup.ggm.kr/brain/del-memo";

                        try
                        {
                            // HTTP POST 요청
                            var deleteMemoResponse = await client.PostAsync(deleteMemoServerUrl, new StringContent(deleteMemoJsonData, Encoding.UTF8, "application/json"));

                            // 서버 응답 확인
                            if (deleteMemoResponse.IsSuccessStatusCode)
                            {
                                string deleteMemoResult = await deleteMemoResponse.Content.ReadAsStringAsync();

                                //알림 뛰우기
                                info_text = "goUP Cloud에 저장된 시냅스를 삭제했어요";
                                info_panel.BackColor = Color.DodgerBlue;
                                infobox(sender, e);

                                // 메모 목록 갱신
                                open_cloudedit_bt_Click(sender, e);
                            }
                            else
                            {
                                //알림 뛰우기
                                info_text = "⚠️ | 서버에 문제가 있어요";
                                info_panel.BackColor = Color.OrangeRed;
                                infobox(sender, e);

                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + deleteMemoResponse.StatusCode,
                                    "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
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
                    info_panel.BackColor = Color.OrangeRed;
                    infobox(sender, e);

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + "error/goup/brain/web/not-seleted-memo/0001",
                        "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private async void cloudedit_save_bt_Click(object sender, EventArgs e)
        {
            email = Properties.Settings.Default.id;
            password = Properties.Settings.Default.pw;

            string memoName = cloudedit_listBox.SelectedItem.ToString();
            string memoContent = textBox.Text;
            cloudedit_memoContentResult = textBox.Text;

            // 비밀번호 암호화
            string hashedPassword = ComputeSha256Hash(password);
            // 시냅스 암호화
            memoContent = EncryptString(memoContent, password);

            if (memoContent == "error")
            {
                //알림 뛰우기
                info_text = "⚠️ | 시냅스를 암호화할수 없어요. 시냅스를 만들지 못했어요";
                info_panel.BackColor = Color.OrangeRed;
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
                    string addMemoServerUrl = "https://goup-id-auth.goup.ggm.kr/brain/add-memo";

                    try
                    {
                        // HTTP POST 요청
                        var addMemoResponse = await client.PostAsync(addMemoServerUrl, new StringContent(addMemoJsonData, Encoding.UTF8, "application/json"));

                        // 서버 응답 확인
                        if (addMemoResponse.IsSuccessStatusCode)
                        {
                            string addMemoResult = await addMemoResponse.Content.ReadAsStringAsync();

                            richTextBox_TextChanged(sender, e);

                            //알림 뛰우기
                            info_text = "goUP Cloud에 시냅스를 저장했어요";
                            info_panel.BackColor = Color.DodgerBlue;
                            infobox(sender, e);
                        }
                        else
                        {
                            //알림 뛰우기
                            info_text = "⚠️ | 서버에 문제가 있어요";
                            info_panel.BackColor = Color.OrangeRed;
                            infobox(sender, e);

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + addMemoResponse.StatusCode,
                                "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        //알림 뛰우기
                        info_text = "⚠️ | 서버에 문제가 있어요";
                        info_panel.BackColor = Color.OrangeRed;
                        infobox(sender, e);

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                            "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void syname_label_Click(object sender, EventArgs e)
        {
            /*if (syname_label.Text == "goUP Cloud - 저장되지 않음")
            {
                //알림 뛰우기
                info_text = "⚠️ | 시냅스가 저장되지 않았어요";
                info_panel.BackColor = Color.Orange;
                infobox(sender, e);
            }
            else if(syname_label.Text == "goUP Cloud - 저장됨")
            {
                //알림 뛰우기
                info_text = "시냅스가 Cloud에 저장되었어요";
                info_panel.BackColor = Color.DodgerBlue;
                infobox(sender, e);
            }*/
        }

        bool em_panel_isopen = false;

        private void em_bt_Click(object sender, EventArgs e)
        {
            if (em_panel_isopen != true)
            {
                // 이모티콘 파일 불러오기
                em_listBox.Items.Clear();

                string savePath = @"C:\goUP\BrainApp\em.goup";

                if (File.Exists(savePath))
                {
                    using (StreamReader sr = new StreamReader(savePath))
                    {
                        // 파일의 끝까지 한 줄씩 읽어오면서 리스트박스에 추가합니다.
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            em_listBox.Items.Add(line);
                        }
                    }
                }

                //이모티콘 존재 여부 확인
                if (em_listBox.Items.Count == 0)
                {
                    //알림 뛰우기
                    info_text = "설치된 이모티콘이 없어요. 이모티콘 업데이트를 눌러주세요";
                    info_panel.BackColor = Color.Orange;
                    infobox(sender, e);
                }

                //열기
                em_panel_isopen = true;

                em_panel.Visible = true;

                em_bt.BackColor = Color.DodgerBlue;
                em_bt.ForeColor = Color.White;

                em_listBox.SelectedIndex = 0;
            }
            else
            {
                //닫기
                em_panel_isopen = false;

                em_panel.Visible = false;

                em_bt.BackColor = Color.FromArgb(250, 250, 250);
                em_bt.ForeColor = Color.Black;
            }
        }

        bool devmode = false;

        private void devmode_bt_Click(object sender, EventArgs e)
        {
            if (devmode == true)
            {
                devmode = false;
                devmode_bt.Text = "⚙️ 개발자 모드";
                devmode_bt.BackColor = Color.WhiteSmoke;
                devmode_bt.ForeColor = Color.Black;
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
            else
            {
                devmode = true;
                devmode_bt.Text = "⚙️ 개발자 모드 [켜짐]";
                devmode_bt.BackColor = Color.DodgerBlue;
                devmode_bt.ForeColor = Color.White;
                textBox.BackColor = Color.Black;
                textBox.ForeColor = Color.White;

                MessageBox.Show("개발자 모드가 켜졌어요\r\n개발자 모드의 기능을 사용하려면 아래처럼 하면 돼요\r\n1. 코드를 시냅스에 적어주세요\r\n2. [마크다운 모드로 전환하기]를 클릭해주세요\r\n3. 마크다운 모드 대신 웹페이지가 열려요\r\n\r\n⚠️ 주의\r\n라이브 미리보기는 Internet Explorer 모드에서 실행돼요\r\n실제 유저가 보는 환경과 다르게 표시될수 있어요\r\n또한 단일 HTML, CSS 코드만 지원해요\r\nJS, NextJS같은 스크립트 실행이 불가능해요");
            }
        }

        private void emupdate_bt_Click(object sender, EventArgs e)
        {
            em_listBox.Items.Clear();

            string url = "https://files.goup.ggm.kr/em/em.goup"; // 다운로드할 파일의 URL을 입력하세요
            string savePath = @"C:\goUP\BrainApp\em.goup"; // 파일을 저장할 경로와 파일명을 입력하세요

            WebClient client = new WebClient();

            try
            {
                client.DownloadFile(url, savePath);

                // StreamReader를 사용하여 파일을 엽니다.
                using (StreamReader sr = new StreamReader(savePath))
                {
                    int index_em = 1;

                    // 파일의 끝까지 한 줄씩 읽어오면서 리스트박스에 추가합니다.
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        em_listBox.Items.Add(line);
                        client.DownloadFile("https://files.goup.ggm.kr/em/em_" + index_em + ".png", @"C:\goUP\BrainApp\em_" + index_em + ".png");
                        index_em++;
                    }
                }

                //알림 뛰우기
                info_text = "이모티콘을 업데이트했어요";
                info_panel.BackColor = Color.DodgerBlue;
                infobox(sender, e);
            }
            catch (Exception ex)
            {
                //알림 뛰우기
                info_text = "문제가 발생했어요";
                info_panel.BackColor = Color.OrangeRed;
                infobox(sender, e);

                MessageBox.Show("이모티콘 업데이트중 문제가 발생했어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message, "goUP Brain", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void eminput_bt_Click(object sender, EventArgs e)
        {
            if (em_listBox.SelectedIndex != -1)
            {
                // 현재 텍스트박스의 커서 위치를 가져옵니다.
                int cursorPosition = textBox.SelectionStart;

                // 특정 텍스트를 가져옵니다.
                string textToInsert = "{::emoticon-" + (em_listBox.SelectedIndex + 1).ToString() + "::}";

                // 현재 텍스트박스의 텍스트를 가져옵니다.
                string currentText = textBox.Text;

                // 커서 위치에 특정 텍스트를 삽입합니다.
                string newText = currentText.Substring(0, cursorPosition) + textToInsert + currentText.Substring(cursorPosition);

                // 텍스트박스에 새로운 텍스트를 설정합니다.
                textBox.Text = newText;

                // 커서 위치를 설정합니다. (삽입된 텍스트 끝으로 이동)
                textBox.SelectionStart = cursorPosition + textToInsert.Length;

                // 이모티콘 창 닫기
                em_bt_Click(sender, e);

                // 포커스를 텍스트박스로 이동합니다.
                textBox.Focus();
            }
        }

        private void em_listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            em_pictureBox.ImageLocation = $"C:\\goUP\\BrainApp\\em_{(em_listBox.SelectedIndex + 1)}.png";
        }

        private void main_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Dispose();
        }
    }
}