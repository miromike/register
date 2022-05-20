using FireSharp.Config;
using FireSharp.Interfaces;

namespace register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FirebaseConfig fbc = new FirebaseConfig()
        {
            AuthSecret = "XNKREdDh3zVpRKANbkHFxl6F8qSRF9Eup8cESali",
            BasePath = "https://register-a194e-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(fbc);
            }
            catch
            {
                MessageBox.Show("문제발생");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = client.Get("가입자 명단/" + textBox2.Text);
            Upload upd = result.ResultAs<Upload>();
            Upload upd2 = new Upload()
            {
                name = textBox1.Text, id = textBox2.Text, pwd = textBox3.Text  
            };
            var send = client.Set("가입자 명단/" + textBox2.Text, upd2);

            MessageBox.Show("회원 가입 완료");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Upload upd2 = new Upload()
            {
                name = textBox1.Text,
                id = textBox2.Text,
                pwd = textBox3.Text
            };
            var send = client.Set("가입자 명단/" + textBox2.Text, upd2);

            MessageBox.Show("수정 완료");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("정보를 기입해 주세요.");
            }
            else
            {
                var result = client.Get("가입자 명단/" + textBox2.Text);
                Upload upd = result.ResultAs<Upload>();
                if (upd == null)
                {
                    MessageBox.Show("입력한 정보로 조회 값이 없습니다.");
                }
                else
                {
                    textBox1.Text = upd.name;
                    textBox2.Text = upd.id;
                    textBox3.Text = upd.pwd;

                    MessageBox.Show("데이타 받아옴");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("정보를 기입해 주세요.");
            }
            else
            {
                var result = client.Get("가입자 명단/" + textBox2.Text);
                Upload upd = result.ResultAs<Upload>();
                if (upd == null)
                {
                    MessageBox.Show("입력한 정보로 조회 값이 없습니다.");
                }
                else
                {
                    result = client.Delete("가입자 명단/" + textBox2.Text);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    MessageBox.Show("정보 삭제 완료");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string pwd = textBox5.Text;

            var result = client.Get("가입자 명단/" + id);
            Upload upd = result.ResultAs<Upload>();

            if (id == null || upd == null || pwd == null || pwd != upd.pwd) 
            {
                MessageBox.Show("실패");
            }
            else
            { 
                MessageBox.Show("성공");
            }
        }
    }

}