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
                MessageBox.Show("�����߻�");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = client.Get("������ ���/" + textBox2.Text);
            Upload upd = result.ResultAs<Upload>();
            Upload upd2 = new Upload()
            {
                name = textBox1.Text, id = textBox2.Text, pwd = textBox3.Text  
            };
            var send = client.Set("������ ���/" + textBox2.Text, upd2);

            MessageBox.Show("ȸ�� ���� �Ϸ�");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Upload upd2 = new Upload()
            {
                name = textBox1.Text,
                id = textBox2.Text,
                pwd = textBox3.Text
            };
            var send = client.Set("������ ���/" + textBox2.Text, upd2);

            MessageBox.Show("���� �Ϸ�");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("������ ������ �ּ���.");
            }
            else
            {
                var result = client.Get("������ ���/" + textBox2.Text);
                Upload upd = result.ResultAs<Upload>();
                if (upd == null)
                {
                    MessageBox.Show("�Է��� ������ ��ȸ ���� �����ϴ�.");
                }
                else
                {
                    textBox1.Text = upd.name;
                    textBox2.Text = upd.id;
                    textBox3.Text = upd.pwd;

                    MessageBox.Show("����Ÿ �޾ƿ�");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("������ ������ �ּ���.");
            }
            else
            {
                var result = client.Get("������ ���/" + textBox2.Text);
                Upload upd = result.ResultAs<Upload>();
                if (upd == null)
                {
                    MessageBox.Show("�Է��� ������ ��ȸ ���� �����ϴ�.");
                }
                else
                {
                    result = client.Delete("������ ���/" + textBox2.Text);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";

                    MessageBox.Show("���� ���� �Ϸ�");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string id = textBox4.Text;
            string pwd = textBox5.Text;

            var result = client.Get("������ ���/" + id);
            Upload upd = result.ResultAs<Upload>();

            if (id == null || upd == null || pwd == null || pwd != upd.pwd) 
            {
                MessageBox.Show("����");
            }
            else
            { 
                MessageBox.Show("����");
            }
        }
    }

}