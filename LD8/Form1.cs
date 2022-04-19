using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            var key = "PeShVmYq3t6w9z$C&F)H@McQfTjWnZr4";

            if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password box is empty!");
            }
            else
            {
                byte[] IV = new byte[16];
                AesManaged aes = new AesManaged();

                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = IV;

                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

                byte[] InputBytes = Encoding.UTF8.GetBytes(password);
                cryptoStream.Write(InputBytes, 0, InputBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] Encrypted = memoryStream.ToArray();


                var encrypted = Convert.ToBase64String(Encrypted);

                textBox2.Text = encrypted;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var originalPw = textBox1.Text;
            var encrypted = textBox2.Text;
            var key = "PeShVmYq3t6w9z$C&F)H@McQfTjWnZr4";

            if (String.IsNullOrEmpty(encrypted))
            {
                MessageBox.Show("Encrypted password box is empty!");
            }
            else if (String.IsNullOrEmpty(originalPw))
            {
                MessageBox.Show("Password box is empty");
            }
            else
            {
                byte[] IV = new byte[16];
                byte[] buffer = Convert.FromBase64String(encrypted);

                AesManaged aes = new AesManaged();

                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                MemoryStream memoryStream = new MemoryStream(buffer);
                CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader((Stream)cryptoStream);
                var decrypted = streamReader.ReadToEnd();
                textBox3.Text = decrypted;
            }

        }
    }
}