using System.Data.SqlClient;
using Management.Classes;
using Management.DB;
namespace Management
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

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Mail = Emailinp.Text.ToString();
            string Password = Passwordinp.Text.ToString();
            try
            {
                if (!DbConfig.OpenConn())
                {
                    throw new Exception("Connection Failed");
                }
                if (Verification.StrIsNull(Mail))
                {
                    throw new Exception("Input field Cannot be null");
                }
                DbConfig.GetData("Users", "*", $"Use_Mail='{Mail}' And Use_Password='{Password}'");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            



        }
    }
}