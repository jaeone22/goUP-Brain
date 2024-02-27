using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace goUP_Brain
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        string df = @"C:\goUP\Brain\";

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

        private void settings_Load(object sender, EventArgs e)
        {
            //라운드 처리
            int ro1 = 50;
            int ro2 = 40;
            int ro3 = 30;

            ApplyRoundCorners(this, ro1);

            ApplyRoundCorners(thanks_panel, ro1);
            ApplyRoundCorners(thanks_add_bt, ro3);

            ApplyRoundCorners(editdata_menu_open_bt, ro2);
            ApplyRoundCorners(restore_menu_open_bt, ro2);
            ApplyRoundCorners(info_menu_open_bt, ro2);

            ApplyRoundCorners(openfolder_editdata_menu_panel, ro1);
            ApplyRoundCorners(opentrash_editdata_menu_panel, ro1);
            ApplyRoundCorners(restoretrash_editdata_menu_panel, ro1);
            ApplyRoundCorners(restore_editdata_menu_panel, ro1);

            ApplyRoundCorners(textbox_1_restore_menu_panel, ro3);
            ApplyRoundCorners(textbox_2_restore_menu_panel, ro3);
            ApplyRoundCorners(restore_bt_restore_menu_panel, ro1);

            //버전
            ver_info_menu_panel.Text = Properties.app.Default.version + "\r\n" + "goUP UI 4.1";

            // 웹 페이지의 URL
            string url = "https://thanks.goup.ggm.kr/thanks-list.goup";

            try
            {
                // WebClient를 사용하여 웹 페이지의 내용을 가져옴
                WebClient client = new WebClient();
                client.Encoding = Encoding.UTF8;
                string htmlCode = client.DownloadString(url);

                // 가져온 HTML 코드를 레이블에 표시
                thanks_richTextBox.Text = htmlCode;
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("오류 발생: " + ex.Message);
            }
        }

        private void close_bt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thanks_add_bt_Click(object sender, EventArgs e)
        {
            Process.Start("https://goup.ggm.kr/spt");
        }

        private void alldel_editdata_menu_panel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 계정을 삭제할까요?\r\n이 작업은 되돌릴수 없어요\r\n계정을 삭제하기 전 모든 자료를 복사해주세요", "goUP ID", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Process.Start("https://forms.gle/uhTS1dR1hv6GTQAg9");
                MessageBox.Show("이 폼을 작성 후 제출해주세요", "goUP ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void restore_bt_restore_menu_panel_Click(object sender, EventArgs e)
        {
            string memoContentResult = DecryptString(textbox_1_restore_menu_panel.Text, textbox_2_restore_menu_panel.Text);

            if (memoContentResult == "error")
            {
                //알림 뛰우기
                /*info_text = "⚠️ | 시냅스를 복호화할수 없어요";
                info_panel.BackColor = Color.Red;
                infobox(sender, e);*/

                MessageBox.Show("시냅스를 복구할수 없어요\r\n다른 비밀번호로 다시 시도해주세요", "goUP Brain 시냅스 복구 도구", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int count = 1;

                while (System.IO.File.Exists(df + "복구한 시냅스 " + count + ".goUP"))
                {
                    count++;
                }

                StreamWriter writer;
                writer = File.CreateText(df + "복구한 시냅스 " + count + ".goUP");
                writer.Close();

                File.WriteAllText(df + "복구한 시냅스 " + count + ".goUP", memoContentResult);

                MessageBox.Show("시냅스를 복구했어요\r\n복구한 시냅스를 시냅스 목록에 추가했어요", "goUP Brain 시냅스 복구 도구", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void editdata_menu_open_bt_Click(object sender, EventArgs e)
        {
            editdata_menu_panel.Visible = true;
            restore_menu_panel.Visible = false;
            info_menu_panel.Visible = false;

            editdata_menu_open_bt.BackColor = Color.DodgerBlue;
            editdata_menu_open_bt.ForeColor = Color.White;

            restore_menu_open_bt.BackColor = Color.FromArgb(240, 240, 240);
            restore_menu_open_bt.ForeColor = Color.Black;

            info_menu_open_bt.BackColor = Color.FromArgb(240, 240, 240);
            info_menu_open_bt.ForeColor = Color.Black;
        }

        private void restore_menu_open_bt_Click(object sender, EventArgs e)
        {
            editdata_menu_panel.Visible = false;
            restore_menu_panel.Visible = true;
            info_menu_panel.Visible = false;

            editdata_menu_open_bt.BackColor = Color.FromArgb(240, 240, 240);
            editdata_menu_open_bt.ForeColor = Color.Black;

            restore_menu_open_bt.BackColor = Color.DodgerBlue;
            restore_menu_open_bt.ForeColor = Color.White;

            info_menu_open_bt.BackColor = Color.FromArgb(240, 240, 240);
            info_menu_open_bt.ForeColor = Color.Black;
        }

        private void info_menu_open_bt_Click(object sender, EventArgs e)
        {
            editdata_menu_panel.Visible = false;
            restore_menu_panel.Visible = false;
            info_menu_panel.Visible = true;

            editdata_menu_open_bt.BackColor = Color.FromArgb(240, 240, 240);
            editdata_menu_open_bt.ForeColor = Color.Black;

            restore_menu_open_bt.BackColor = Color.FromArgb(240, 240, 240);
            restore_menu_open_bt.ForeColor = Color.Black;

            info_menu_open_bt.BackColor = Color.DodgerBlue;
            info_menu_open_bt.ForeColor = Color.White;
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

        private void openfolder_editdata_menu_panel_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\goUP\Brain");
        }

        private void opentrash_editdata_menu_panel_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\goUP\Brain\.Trash");
        }

        private void restoretrash_editdata_menu_panel_Click(object sender, EventArgs e)
        {
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
                        /*info_text = fileName + " 시냅스를 복원했어요";
                        info_panel.BackColor = Color.DodgerBlue;
                        infobox(sender, e);*/
                    }

                    //알림 뛰우기
                    /*info_text = "시냅스를 모두 복원했어요";
                    info_panel.BackColor = Color.DodgerBlue;
                    infobox(sender, e);*/
                }
                catch (Exception ex)
                {
                    //알림 뛰우기
                    /*info_text = "⚠️ | 시냅스를 복원할수 없어요";
                    info_panel.BackColor = Color.Red;
                    infobox(sender, e);*/

                    MessageBox.Show("goUP Brain 앱에 문제가 있어요\r\n디스코드 서버에 문의글을 남기면 신속하게 해결해 드릴게요\r\n밑의 내용을 캡쳐해서 문의해 주세요\r\n\r\n" + ex.Message,
                        "goUP Brain", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void restore_editdata_menu_panel_Click(object sender, EventArgs e)
        {
            restore_menu_open_bt_Click(sender, e);
        }
    }
}
