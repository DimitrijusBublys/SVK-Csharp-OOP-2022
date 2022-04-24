using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string name = textBox2.Text;
            string surname = textBox3.Text;
            string phoneNum = textBox4.Text;
            string address = textBox5.Text;

            // Jeigu visi laukai uþpildyti, áraðas pateikiamas duomenø bazei
            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name textbox is empty!");
            }
            else if (String.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Surname textbox is empty!");
            }
            else if (String.IsNullOrEmpty(phoneNum))
            {
                MessageBox.Show("Phone number textbox is empty!");
            }
            else if (String.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address textbox is empty!");
            }
            else
            {
                // Áraðo pateikimas á duomenø bazæ
                string connectionString =
                    @"Data Source=localhost; Initial Catalog=CSHARP; Trusted_Connection=True; TrustServerCertificate=True";
                string sqlQuery = "INSERT INTO person (person_name, person_surname, phone_num, person_address) " +
                    "VALUES (" + "'" + name + "'" + ","
                    + "'" + surname + "'" + ","
                    + "'" + phoneNum + "'" + ","
                    + "'" + address + "'"; ")";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }




        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}