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

namespace preprojetopap
{
    public partial class teste_login : Form
    {
        public teste_login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var CriarNovaConta = new CriarNovaContaNova();

            CriarNovaConta.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = TextBox1.Text;
            string password = TextBox2.Text;
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }
            else
            {
                int userId = Loginn(nome, password);
                if (userId != -1)
                {
                    SessaoUtilizador.Nome = nome;
                    SessaoUtilizador.Id = userId;

                    MessageBox.Show("Login com sucesso!");
                    var Main = new main();

                    Main.Show();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Nome ou palavra-passe incorretos.");
                }
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
