using Guna.UI2.WinForms;
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
    public partial class EditarPerfil : Form
    {
        public EditarPerfil()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string Nome = guna2TextBox2.Text;
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"UPDATE Utilizadores
                         SET Nome = @Nome,
                             PalavraPasse = @palavrapass
                         WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@id", SessaoUtilizador.Id);
                    cmd.Parameters.AddWithValue("@palavrapass", guna2TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Nome", Nome);
                    
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                    {
                        SessaoUtilizador.Nome = Nome;
                      MessageBox.Show("Informações alteradas com sucesso!");
                        this.Close();
                    }
                    else
                    {
                      MessageBox.Show("Erro ao alterar treino.");
                    }

                }

            }
            


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
