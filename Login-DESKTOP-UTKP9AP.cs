using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using preprojetopap;


namespace preprojetopap
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var CriarNovaConta = new CriarNovaConta();

            CriarNovaConta.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string password = textBox2.Text;

            int userId = Loginn(nome, password);
            if (userId != -1)
            {
                // Guarda os dados do utilizador autenticado
                SessaoUtilizador.Id = userId;
                SessaoUtilizador.Nome = nome;

                MessageBox.Show("Login com sucesso!");

                // Abre o menu principal
                main menu = new main();
                menu.Show();
                this.Hide(); // Ou this.Close() se não quiseres voltar
            }
            else
            {
                MessageBox.Show("Nome ou palavra-passe incorretos.");
            }
        }

        private int Loginn(string nome, string password)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT Id FROM Utilizadores WHERE Nome = @nome AND PalavraPasse = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@password", password);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result); // Devolve o ID
                    }
                    else
                    {
                        return -1; // Falhou login
                    }
                }
            }
        }
        

    }
}
