namespace WinFormsApp1
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kintamieji
            long startNum = Int64.Parse(textBox1.Text);
            long differencial = Int64.Parse(textBox2.Text);
            long finalNum = Int64.Parse(textBox3.Text);
            int times = 0;

            for(long i = startNum; startNum < finalNum; i+=differencial) // Ciklas aritmetinei progresijai
            {
                startNum += i;
                times++;
            }

            MessageBox.Show("Cycle went for " + times + " times and the final result was: " + startNum); // Message box rezultatø iðvedimas
        }
    }
}