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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace preprojetopap
{
    public partial class perfil : Form
    {
        public perfil()
        {
            InitializeComponent();
            label5.Text = SessaoUtilizador.Nome;
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT PalavraPasse FROM Utilizadores WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", SessaoUtilizador.Id);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        label6.Text = resultado.ToString();
                    }
                    else
                    {
                        label6.Text = "Palavra-Passe não encontrada";
                    }
                }
            }
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTrasition.Start();
        }
        bool sidebarExpand = true;
        private void sidebarTrasition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 4;
                if (sidebar.Width <= 41)
                {
                    sidebarExpand = false;
                    sidebarTrasition.Stop();
                }
            }
            else
            {
                sidebar.Width += 4;
                if (sidebar.Width >= 164)
                {
                    sidebarExpand = true;
                    sidebarTrasition.Stop();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Home = new main();

            Home.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adicionarTreino = new adicionarTreino();

            adicionarTreino.Show();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var removertreino = new Removertreino();

            removertreino.Show();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var editarTreino = new EditarTreino();

            editarTreino.Show();

            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var editarperfil = new EditarPerfil();

            editarperfil.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            label5.Text = SessaoUtilizador.Nome;
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT PalavraPasse FROM Utilizadores WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", SessaoUtilizador.Id);

                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        label6.Text = resultado.ToString();
                    }
                    else
                    {
                        label6.Text = "Palavra-Passe não encontrada";
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var objetivos = new Objetivos();

            objetivos.Show();

            this.Close();
        }
    }
}
