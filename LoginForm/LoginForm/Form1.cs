using System.Data.SqlClient;
using System.Data;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=LoginApp;Integrated Security=True");   


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;

            username = textBox1.Text;
            password = textBox2.Text;

            try
            {
                String queriee = "Select * From User_info where username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(queriee, conn);

                DataTable dTable = new DataTable();
                //import file neeeded
                adapter.Fill(dTable);

                if(dTable.Rows.Count > 0)
                {
                    username = textBox1.Text;
                    password = textBox2.Text;

                    //next loading form
                    MenuForm form2 = new MenuForm();   
                    form2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid details", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();

                    textBox1.Focus();
                }

            }
            catch
            {
                MessageBox.Show("error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(Res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }
    }
}