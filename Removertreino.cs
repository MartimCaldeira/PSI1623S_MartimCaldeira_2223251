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
    public partial class Removertreino : Form
    {
        public Removertreino()
        {
            InitializeComponent();
            CarregarTreinos();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.RowHeadersVisible = false;

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "DELETE FROM treinos WHERE IdUtilizador = @idUtilizador AND Id = @idTreino ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUtilizador", SessaoUtilizador.Id);
                    cmd.Parameters.AddWithValue("@idTreino", guna2TextBox3.Text);
                    
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        MessageBox.Show("Treino Eleminado com sucesso!");
                    else
                        MessageBox.Show("Erro ao registar treino.");




                }
            }
            CarregarTreinos();
            Confirmar.Text = "";
        }

        private void Removertreino_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet5.vTreinosComNomeTipo'. Você pode movê-la ou removê-la conforme necessário.
            this.vTreinosComNomeTipoTableAdapter.Fill(this.smartWorkoutDataSet5.vTreinosComNomeTipo);

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CarregarTreinos()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"
            SELECT T.Id AS Id, T.Data, TT.Nome AS TipoDeTreino, T.Duracao, T.Notas
            FROM Treinos T
            INNER JOIN TipoTreino TT ON T.IdTipoTreino = TT.Id
            WHERE T.IdUtilizador = @idUtilizador
            ORDER BY T.Data DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUtilizador", SessaoUtilizador.Id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            var editarTreino = new EditarTreino();

            editarTreino.Show();

            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Perfil = new perfil();

            Perfil.Show();

            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var objetivos = new Objetivos();

            objetivos.Show();

            this.Close();
        }
    }
}
