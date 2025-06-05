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
    public partial class EditarTreino : Form
    {
        public EditarTreino()
        {
            InitializeComponent();
            CarregarTreinos();
            guna2DateTimePicker1.MaxDate = DateTime.Today;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.RowHeadersVisible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var removertreino = new Removertreino();

            removertreino.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var adicionarTreino = new adicionarTreino();

            adicionarTreino.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Home = new main();

            Home.Show();

            this.Hide();
        }

        private void EditarTreino_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet7.TipoTreino'. Você pode movê-la ou removê-la conforme necessário.
            this.tipoTreinoTableAdapter.Fill(this.smartWorkoutDataSet7.TipoTreino);
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet6.vTreinosComNomeTipo'. Você pode movê-la ou removê-la conforme necessário.
            this.vTreinosComNomeTipoTableAdapter.Fill(this.smartWorkoutDataSet6.vTreinosComNomeTipo);

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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Confirmar_Click(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"UPDATE Treinos
                         SET IdTipoTreino = @idTipoTreino,
                             Data = @data,
                             Duracao = @duracao,
                             Notas = @notas
                         WHERE Id = @idTreino";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                   
                    cmd.Parameters.AddWithValue("@idTreino", guna2TextBox3.Text);
                    cmd.Parameters.AddWithValue("@data", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@duracao", int.Parse(guna2TextBox1.Text));
                    cmd.Parameters.AddWithValue("@notas", guna2TextBox2.Text);
                    cmd.Parameters.AddWithValue("@idTipoTreino", comboBox1.SelectedValue);
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        MessageBox.Show("Treino alterado com sucesso!");
                    else
                        MessageBox.Show("Erro ao registar treino.");




                }
            }
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox1.Text = "";
            CarregarTreinos();
        }
        bool sidebarExpand = false;
        

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnHam_Click_1(object sender, EventArgs e)
        {
            sidebarTrasition.Start();
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
