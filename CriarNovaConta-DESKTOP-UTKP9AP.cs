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
    public partial class CriarNovaConta : Form
    {
        public CriarNovaConta()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var Login = new Login();

           Login.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string password = textBox2.Text;

            if (UtilizadorExiste(nome))
            {
                MessageBox.Show("O utilizador já existe. Por favor escolhe outro nome.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CriarConta(nome, password);
                MessageBox.Show("Conta criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool UtilizadorExiste(string nome)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Utilizadores WHERE Nome = @nome";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void CriarConta(string nome, string password)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO Utilizadores (Nome, PalavraPasse) VALUES (@nome, @password)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        

    }
}
