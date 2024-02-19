using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void settings_Load(object sender, EventArgs e)
        {
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
    }
}
