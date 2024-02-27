using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace goUP_Brain
{
    public partial class goupid : Form
    {
        bool if_auto_login = false;

        public goupid(string data)
        {
            if (data == "auto_login")
            {
                if_auto_login = true;
            }

            InitializeComponent();
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void round(object sender, EventArgs e)
        {
            //라운드 처리
            int ro1 = 50;
            int ro2 = 30;
            ApplyRoundCorners(this, ro1);

            ApplyRoundCorners(id_panel, ro2);
            ApplyRoundCorners(pw_panel, ro2);
            ApplyRoundCorners(login_bt, ro1);
            ApplyRoundCorners(tos_bt, ro2);

            ApplyRoundCorners(oldpw_panel, ro2);
            ApplyRoundCorners(newpw_panel, ro2);
            ApplyRoundCorners(changepw_bt, ro1);
            ApplyRoundCorners(logout_bt, ro1);
            ApplyRoundCorners(delid_bt, ro1);
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

        private async void autologin(object sender, EventArgs e)
        {
            id_textBox.Text = Properties.Settings.Default.id;
            pw_textBox.Text = Properties.Settings.Default.pw;

            id_textBox.ReadOnly = true;
            pw_textBox.ReadOnly = true;

            login_label.Text = "서버에 연결중이에요";

            // 사용자 입력 정보
            string username = id_textBox.Text;
            string rawPassword = pw_textBox.Text;

            // SHA-256 해시 함수를 사용하여 비밀번호 해싱
            string hashedPassword = ComputeSha256Hash(rawPassword);

            // HTTP 클라이언트 생성
            using (HttpClient client = new HttpClient())
            {
                // 전송할 데이터 생성
                var data = new
                {
                    username = username,
                    password = hashedPassword
                };

                // 데이터를 JSON 형식으로 변환
                string jsonData = JsonConvert.SerializeObject(data);

                // 서버 주소
                string serverUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/login";

                try
                {
                    // HTTP POST 요청
                    var response = await client.PostAsync(serverUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    // 서버 응답 확인
                    if (response.IsSuccessStatusCode)
                    {
                        login_label.Text = "goUP ID 로그인";
                        string result = await response.Content.ReadAsStringAsync();

                        if (result == "login")
                        {
                            //MessageBox.Show("계정에 자동 로그인했어요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            this.Close();
                        }
                        else if (result == "error_pw")
                        {
                            MessageBox.Show("계정에 자동 로그인을 할수 없어요\r\n계정의 비밀번호가 틀려요\r\n보안을 위해 로그아웃되었어요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            Properties.Settings.Default.Reset();
                            this.Close();
                        }
                        else if (result == "error_no-id")
                        {
                            MessageBox.Show("자동 로그인할수 없어요\r\n계정이 존재하지 않아요\r\n로그아웃할게요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            Properties.Settings.Default.Reset();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("서버에서 알수 없는 데이터를 받았어요\r\n앱이 최신버전인지 goUP AppStore에서 확인해주세요\r\n최신버전이라면 디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    else
                    {
                        login_label.Text = "문제가 발생했어요";
                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + response.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
                catch (Exception ex)
                {
                    login_label.Text = "문제가 발생했어요";
                    MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }

            login_label.Text = "goUP ID 로그인";

            id_textBox.ReadOnly = false;
            pw_textBox.ReadOnly = false;
        }

        private async void login_bt_Click(object sender, EventArgs e)
        {
            id_textBox.ReadOnly = true;
            pw_textBox.ReadOnly = true;

            if (id_textBox.Text != "" && pw_textBox.Text != "")
            {
                if (checkBox_1.Checked == true && checkBox_2.Checked == true && checkBox_3.Checked == true)
                {
                    if (id_textBox.Text.Contains("@"))
                    {
                        login_label.Text = "서버에 연결중이에요";

                        // 사용자 입력 정보
                        string username = id_textBox.Text;
                        string rawPassword = pw_textBox.Text;

                        // SHA-256 해시 함수를 사용하여 비밀번호 해싱
                        string hashedPassword = ComputeSha256Hash(rawPassword);

                        // HTTP 클라이언트 생성
                        using (HttpClient client = new HttpClient())
                        {
                            // 전송할 데이터 생성
                            var data = new
                            {
                                username = username,
                                password = hashedPassword
                            };

                            // 데이터를 JSON 형식으로 변환
                            string jsonData = JsonConvert.SerializeObject(data);

                            // 서버 주소
                            string serverUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/login";

                            try
                            {
                                // HTTP POST 요청
                                var response = await client.PostAsync(serverUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                                // 서버 응답 확인
                                if (response.IsSuccessStatusCode)
                                {
                                    login_label.Text = "goUP ID 로그인";
                                    string result = await response.Content.ReadAsStringAsync();

                                    if (result == "login")
                                    {
                                        MessageBox.Show("계정에 로그인했어요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                        /*Random rand = new Random();
                                        int random_number = rand.Next(1000);

                                        // 암호화 키 (16, 24, 또는 32 바이트)
                                        byte[] key = Encoding.UTF8.GetBytes(random_number.ToString());

                                        // 사용자 정보를 암호화하여 저장
                                        string encryptedData = EncryptData(pw_textBox.Text, key);
                                        Properties.Settings.Default.pw = encryptedData;*/
                                        /*Properties.Settings.Default.key = random_number;*/

                                        Properties.Settings.Default.id = id_textBox.Text;
                                        Properties.Settings.Default.pw = pw_textBox.Text;
                                        Properties.Settings.Default.autologin = true;
                                        Properties.Settings.Default.Save();

                                        goupid_Shown(sender, e);
                                    }
                                    else if (result == "error_pw")
                                    {
                                        MessageBox.Show("계정의 비밀번호가 틀려요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                    }
                                    else if (result == "error_no-id")
                                    {
                                        if (MessageBox.Show("계정이 존재하지 않아요\r\n계정을 만들까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                        {
                                            login_label.Text = "서버에 연결중이에요";

                                            // HTTP 클라이언트 생성
                                            using (client)
                                            {
                                                // 전송할 데이터 생성
                                                data = new
                                                {
                                                    username = username,
                                                    password = hashedPassword
                                                };

                                                // 데이터를 JSON 형식으로 변환
                                                jsonData = JsonConvert.SerializeObject(data);

                                                // 서버 주소
                                                serverUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/new";

                                                try
                                                {
                                                    // HTTP POST 요청
                                                    response = await client.PostAsync(serverUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                                                    // 서버 응답 확인
                                                    if (response.IsSuccessStatusCode)
                                                    {
                                                        login_label.Text = "goUP ID 로그인";
                                                        result = await response.Content.ReadAsStringAsync();

                                                        if (result == "new")
                                                        {
                                                            MessageBox.Show("계정을 만들었어요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                                            login_bt_Click(sender, e);
                                                        }
                                                        else if (result == "error_yes-id")
                                                        {
                                                            MessageBox.Show("이미 계정이 존재해요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("서버에서 알수 없는 데이터를 받았어요\r\n앱이 최신버전인지 goUP AppStore에서 확인해주세요\r\n최신버전이라면 디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        login_label.Text = "문제가 발생했어요";
                                                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + response.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    login_label.Text = "문제가 발생했어요";
                                                    MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                                }
                                            }

                                            login_label.Text = "goUP ID 로그인";
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("서버에서 알수 없는 데이터를 받았어요\r\n앱이 최신버전인지 goUP AppStore에서 확인해주세요\r\n최신버전이라면 디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                    }
                                }
                                else
                                {
                                    login_label.Text = "문제가 발생했어요";
                                    MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + response.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                }
                            }
                            catch (Exception ex)
                            {
                                login_label.Text = "문제가 발생했어요";
                                MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }

                        login_label.Text = "goUP ID 로그인";
                    }
                    else
                    {
                        MessageBox.Show("이메일을 입력해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("필수 항목의 동의가 필요해요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("이메일과 비밀번호를 입력해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }

            id_textBox.ReadOnly = false;
            pw_textBox.ReadOnly = false;
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

        private void goupid_Load(object sender, EventArgs e)
        {
            round(sender, e);
        }

        private async void goupid_Shown(object sender, EventArgs e)
        {
            load_panel.Visible = true;
            idinfo_panel.Visible = false;
            login_panel.Visible = false;

            // 테스트할 서버의 URL 설정
            string serverUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/test";
            string thisip = "error";

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisip = ip.ToString();
                }
            }

            // HTTP 클라이언트 생성
            using (HttpClient client = new HttpClient())
            {
                // 전송할 데이터 생성
                var data = new
                {
                    ip = thisip
                };

                // 데이터를 JSON 형식으로 변환
                string jsonData = JsonConvert.SerializeObject(data);

                try
                {
                    // HTTP POST 요청
                    var response = await client.PostAsync(serverUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    // 서버 응답 확인
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        if (result == "true")
                        {
                            if (if_auto_login == true)
                            {
                                autologin(sender, e);
                            }
                            else if (Properties.Settings.Default.autologin == false)
                            {
                                load_panel.Visible = false;
                                idinfo_panel.Visible = false;
                                login_panel.Visible = true;
                            }
                            else if (Properties.Settings.Default.autologin == true)
                            {
                                load_panel.Visible = false;
                                idinfo_panel.Visible = true;
                                login_panel.Visible = false;

                                idinfo_label.Text = Properties.Settings.Default.id;
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("서버에서 정상적이지 않은 데이터를 받았어요\r\n보안을 위해 중지하는것을 추천해요\r\n게속할까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                load_panel.Visible = false;
                                login_panel.Visible = true;

                                if (if_auto_login == true)
                                {
                                    autologin(sender, e);
                                }
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        login_label.Text = "문제가 발생했어요";
                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + response.StatusCode, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    login_label.Text = "문제가 발생했어요";
                    MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message, "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
        }

        private void logout_bt_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            MessageBox.Show("게정에서 로그아웃했어요\r\ngoUP ID를 계속 사용하려면 다시 로그인해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            this.Close();
        }

        private async void changepw_bt_Click(object sender, EventArgs e)
        {
            if (oldpw_textBox.Text != "" && newpw_textBox.Text != "")
            {
                idinfo_label.Text = "서버에 연결중이에요";

                // 사용자 입력 정보
                string username = Properties.Settings.Default.id;
                string rawPassword = oldpw_textBox.Text;
                string newrawPassword = newpw_textBox.Text;

                // SHA-256 해시 함수를 사용하여 비밀번호 해싱
                string hashedPassword = ComputeSha256Hash(rawPassword);
                string newhashedPassword = ComputeSha256Hash(newrawPassword);

                // HTTP 클라이언트 생성
                using (HttpClient client = new HttpClient())
                {
                    // 전송할 데이터 생성
                    var data = new
                    {
                        username = username,
                        oldPassword = hashedPassword,
                        newPassword = newhashedPassword
                    };

                    // 데이터를 JSON 형식으로 변환
                    string jsonData = JsonConvert.SerializeObject(data);

                    // 서버 주소
                    string serverUrl = "https://port-0-goup-id-nodejs-57lz2alpnvh5jc.sel4.cloudtype.app/change-pw";

                    try
                    {
                        // HTTP POST 요청
                        var response = await client.PostAsync(serverUrl, new StringContent(jsonData, Encoding.UTF8, "application/json"));

                        // 서버 응답 확인
                        if (response.IsSuccessStatusCode)
                        {
                            idinfo_label.Text = Properties.Settings.Default.id;
                            string result = await response.Content.ReadAsStringAsync();

                            if (result == "change-pw")
                            {
                                Properties.Settings.Default.Reset();

                                MessageBox.Show("비밀번호를 변경했어요\r\n다시 로그인해주세요", "goUP ID",
                                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                                this.Close();
                            }
                            else if (result == "error_oldpw")
                            {
                                MessageBox.Show("계정의 기존 비밀번호가 틀려요\r\n비밀번호를 변경하려면 기존 비밀번호가 있어야 해요", "goUP ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                            else if (result == "error")
                            {
                                Properties.Settings.Default.Reset();

                                MessageBox.Show("계정이 존재하지 않아요\r\n로그아웃할게요\r\n데이터 위변조 방지를 위해 다시 로그인해야해요", "goUP ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("서버에서 알수 없는 데이터를 받았어요\r\n앱이 최신버전인지 goUP AppStore에서 확인해주세요\r\n최신버전이라면 디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요", "goUP ID",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else
                        {
                            idinfo_label.Text = "문제가 발생했어요";

                            MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + response.StatusCode, "goUP ID",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                    catch (Exception ex)
                    {
                        idinfo_label.Text = "문제가 발생했어요";

                        MessageBox.Show("서버에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message, "goUP ID", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }

                idinfo_label.Text = Properties.Settings.Default.id;
            }
            else
            {
                MessageBox.Show("기존 비밀번호와 새로운 비밀번호를 입력해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void delid_bt_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 계정을 삭제할까요?\r\n이 작업은 되돌릴수 없어요\r\n계정을 삭제하기 전 모든 자료를 복사해주세요", "goUP ID", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Process.Start("https://forms.gle/uhTS1dR1hv6GTQAg9");
                MessageBox.Show("이 폼을 작성 후 제출해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void checkBox_1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_1.Checked == true)
            {
                checkBox_1.ForeColor = Color.Black;

                if (MessageBox.Show("goUP ID 이용약관을 열까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Process.Start("https://goup.ggm.kr/tos");
                }
            }
            else
            {
                checkBox_1.ForeColor = Color.Red;
            }
        }

        private void checkBox_2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_2.Checked == true)
            {
                checkBox_2.ForeColor = Color.Black;

                if (MessageBox.Show("goUP ID 개인정보 수집 및 이용 동의서를 열까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Process.Start("https://plip.kr/pcc/216a3b33-836d-4bd3-9990-bad4bb1e091f/consent/2.html");
                }
            }
            else
            {
                checkBox_2.ForeColor = Color.Red;
            }
        }

        private void checkBox_3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_3.Checked == true)
            {
                checkBox_3.ForeColor = Color.Black;

                if (MessageBox.Show("goUP ID 마케팅 및 광고성 정보 수신 동의서를 열까요?", "goUP ID", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Process.Start("https://plip.kr/pcc/216a3b33-836d-4bd3-9990-bad4bb1e091f/consent/1.html");
                }
            }
            else
            {
                checkBox_3.ForeColor = Color.Red;
            }
        }

        Point mCurrentPosition = new Point(0, 0);

        private void title1_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mCurrentPosition = new Point(-e.X, -e.Y);
        }

        private void title1_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                this.Location.X + (mCurrentPosition.X + e.X),
                this.Location.Y + (mCurrentPosition.Y + e.Y));
            }
        }

        private void id_textBox_TextChanged(object sender, EventArgs e)
        {
            /*if (id_textBox.Text.Contains("@duck.com"))
            {
                id_label.Text = "✔️ | 안전해요";
            }
            else if (id_textBox.Text.Contains("@protonmail.com"))
            {
                id_label.Text = "✔️ | 안전해요";
            }
            else if (id_textBox.Text.Contains("@proton.me"))
            {
                id_label.Text = "✔️ | 안전해요";
            }
            else if (id_textBox.Text.Contains("@icloud.com"))
            {
                id_label.Text = "✔️ | 안전해요";
            }
            else if (id_textBox.Text.Contains("@naver.com"))
            {
                id_label.Text = "⚠️ | 데이터를 암호화하지 않아요";
            }
            else if (id_textBox.Text.Contains("@gmail.com"))
            {
                id_label.Text = "⚠️ | 개인정보 추적 사례가 있어요";
            }
            else
            {
                id_label.Text = "❔| 이메일 호스트를 알수 없어요";
            }*/
        }

        private void tos_bt_Click(object sender, EventArgs e)
        {
            Process.Start("https://plip.kr/pcc/216a3b33-836d-4bd3-9990-bad4bb1e091f/privacy-policy");
        }
    }
}