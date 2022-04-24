using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace WinFormsApp4
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

        private void button1_Click(object sender, EventArgs e) // Insert
        {

            // Textbox laukai
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string phoneNum = textBox3.Text;
            string address = textBox4.Text;

            // Jeigu koks nors laukas tuðèias

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

            // Jeigu laukai netuðti
            else
            {

                string connectionString =
                    "Data Source=localhost; Initial Catalog=CSHARP; Trusted_Connection=True; TrustServerCertificate=True";
                string sqlQuery = "INSERT INTO person (person_name, person_surname, phone_num, person_address) " +
                    "VALUES (@person_name, @person_surname, @phone_num, @person_address)";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                // Áraðo áraðymas á duomenø bazæ
                cmd.Parameters.AddWithValue("@person_name", name);
                cmd.Parameters.AddWithValue("@person_surname", surname);
                cmd.Parameters.AddWithValue("@phone_num", phoneNum);
                cmd.Parameters.AddWithValue("@person_address", address);

                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Data added into the database!");

            }
        }
        private void button2_Click(object sender, EventArgs e) // Delete
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string phoneNum = textBox3.Text;
            string address = textBox4.Text;

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
                string connectionString =
                    "Data Source=localhost; Initial Catalog=CSHARP; Trusted_Connection=True; TrustServerCertificate=True";
                string sqlQuery =
                    "DELETE FROM person " +
                    "WHERE person_name=@name AND person_surname=@surname AND phone_num=@phoneNum AND person_address=@address";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@phoneNum", phoneNum);
                cmd.Parameters.AddWithValue("@address", address);

                int rowsAffected = cmd.ExecuteNonQuery(); // ExecuteNonQuery atlikæs veiksmà iðveda, kiek eiluèiø buvo pakeitæs
                connection.Close();
            

                if (rowsAffected == 0)
                {
                    MessageBox.Show("There was no such data in the database, nothing was deleted.");
                }
                else
                {
                    MessageBox.Show("Data deleted from the database!");
                }
            }
            

        }

        private void button3_Click(object sender, EventArgs e) // Search
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string phoneNum = textBox3.Text;
            string address = textBox4.Text;

            string connectionString =
                "Data Source=localhost; Initial Catalog=CSHARP; Trusted_Connection=True; TrustServerCertificate=True";

            SqlConnection connection = new SqlConnection(connectionString);

            if (String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Name and Surname textbox is empty!");
            }
            if (!String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surname))
            {
                string sqlQuery =
                    "SELECT * FROM person WHERE person_name=@name";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                // Áraðo áraðymas á duomenø bazæ
                cmd.Parameters.AddWithValue("@name", name);

                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            if (String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(surname))
            {
                string sqlQuery =
                    "SELECT * FROM person WHERE person_surname=@surname";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                // Áraðo áraðymas á duomenø bazæ
                cmd.Parameters.AddWithValue("@surname", surname);

                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            if (!String.IsNullOrEmpty(surname) && !String.IsNullOrEmpty(name))
            {
                string sqlQuery =
                    "SELECT * FROM person" +
                    "WHERE person_name=@name AND person_surname=@surname";

                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                // Áraðo áraðymas á duomenø bazæ
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);

                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }
        private void button4_Click(object sender, EventArgs e) // Update
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string phoneNum = textBox3.Text;
            string address = textBox4.Text;

            if (String.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name textbox is empty!");
            }
            else if (String.IsNullOrEmpty(surname))
            {
                MessageBox.Show("Surname textbox is empty!");
            }
            else
            {
                string connectionString =
                    "Data Source=localhost; Initial Catalog=CSHARP; Trusted_Connection=True; TrustServerCertificate=True";
                string sqlQuery =
                    "UPDATE person SET phone_num=@phoneNum, person_address=@address WHERE person_name=@name AND person_surname=@surname";

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                // Áraðo áraðymas á duomenø bazæ
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@phoneNum", phoneNum);
                cmd.Parameters.AddWithValue("@address", address);

                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Data updated in the database!");
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}