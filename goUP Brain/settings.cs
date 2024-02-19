using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goUP_Brain
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
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

        private void settings_Load(object sender, EventArgs e)
        {
            //라운드 처리
            int ro1 = 50;
            int ro2 = 30;
            ApplyRoundCorners(this, ro1);
            ApplyRoundCorners(thanks_panel, ro1);
            ApplyRoundCorners(thanks_add_bt, ro2);


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
    }
}
