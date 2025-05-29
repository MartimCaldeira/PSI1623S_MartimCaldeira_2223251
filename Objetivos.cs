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
    public partial class Objetivos : Form
    {
        public Objetivos()
        {
            InitializeComponent();
            CarregarObjetivos();
            guna2DateTimePicker1.MinDate = DateTime.Today;
        }
        private void CarregarObjetivos()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";

            string query = @"
    SELECT 
        O.Id,
        O.IdUtilizador,
        O.Notas,
        O.DuracaoMeta,
        O.TipoTreinoDesejado,
        O.DataLimite,
        ISNULL(TT.Nome, 'Todos os tipos') AS TipoTreino,
        ISNULL(SUM(T.Duracao), 0) AS TotalFeito
    FROM Objetivos O
    LEFT JOIN TipoTreino TT ON O.TipoTreinoDesejado = TT.Id
    LEFT JOIN Treinos T ON 
        T.IdUtilizador = O.IdUtilizador
        AND (O.TipoTreinoDesejado IS NULL OR T.IdTipoTreino = O.TipoTreinoDesejado)
        AND T.Data <= O.DataLimite
    WHERE O.IdUtilizador = @id
    GROUP BY 
        O.Id, 
        O.IdUtilizador, 
        O.Notas, 
        O.DuracaoMeta, 
        O.TipoTreinoDesejado, 
        O.DataLimite, 
        TT.Nome
";


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", SessaoUtilizador.Id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridViewObjetivos.DataSource = dt;
                    dataGridViewObjetivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

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

        private void btnHam_Click(object sender, EventArgs e)
        {
            sidebarTrasition.Start();
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

        private void button5_Click(object sender, EventArgs e)
        {
            var Perfil = new perfil();

            Perfil.Show();

            this.Close();
        }

        private void Objetivos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet12.Objetivos'. Você pode movê-la ou removê-la conforme necessário.
            this.objetivosTableAdapter2.Fill(this.smartWorkoutDataSet12.Objetivos);
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet11.Objetivos'. Você pode movê-la ou removê-la conforme necessário.
            this.objetivosTableAdapter1.Fill(this.smartWorkoutDataSet11.Objetivos);
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet9.TipoTreino'. Você pode movê-la ou removê-la conforme necessário.
            this.tipoTreinoTableAdapter.Fill(this.smartWorkoutDataSet9.TipoTreino);
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet8.Objetivos'. Você pode movê-la ou removê-la conforme necessário.
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";

        private void Confirmar_Click(object sender, EventArgs e)
        {
            string descricao = guna2TextBox2.Text;
            int duracao = (int)guna2NumericUpDown1.Value;
            DateTime dataLimite = guna2DateTimePicker1.Value;
            object tipoTreino = comboBox1.SelectedValue ?? DBNull.Value;

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(@"
        INSERT INTO Objetivos 
            (IdUtilizador, Notas, DuracaoMeta, TipoTreinoDesejado, DataLimite)
        VALUES 
            (@idUtilizador, @descricao, @duracao, @tipoTreino, @dataLimite)", conn))
            {
                cmd.Parameters.AddWithValue("@idUtilizador", SessaoUtilizador.Id);
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@duracao", duracao);
                cmd.Parameters.AddWithValue("@tipoTreino", tipoTreino);
                cmd.Parameters.AddWithValue("@dataLimite", dataLimite);

                conn.Open();
                int linhasInseridas = cmd.ExecuteNonQuery();

                if (linhasInseridas > 0)
                    MessageBox.Show("Objetivo adicionado com sucesso!");
                else
                    MessageBox.Show("Erro ao adicionar objetivo.");
            }

            CarregarObjetivos();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(guna2TextBox1.Text, out int idObjetivo))
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            string descricao = guna2TextBox2.Text;
            int duracao = (int)guna2NumericUpDown1.Value;
            DateTime dataLimite = guna2DateTimePicker1.Value;
            object tipoTreino = comboBox1.SelectedValue ?? DBNull.Value;

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(@"
        UPDATE Objetivos
        SET 
            Notas = @descricao,
            DuracaoMeta = @duracao,
            TipoTreinoDesejado = @tipoTreino,
            DataLimite = @dataLimite
        WHERE 
            Id = @id AND IdUtilizador = @idUtilizador", conn))
            {
                cmd.Parameters.AddWithValue("@descricao", descricao);
                cmd.Parameters.AddWithValue("@duracao", duracao);
                cmd.Parameters.AddWithValue("@tipoTreino", tipoTreino);
                cmd.Parameters.AddWithValue("@dataLimite", dataLimite);
                cmd.Parameters.AddWithValue("@id", idObjetivo);
                cmd.Parameters.AddWithValue("@idUtilizador", SessaoUtilizador.Id);

                conn.Open();
                int linhasAfetadas = cmd.ExecuteNonQuery();

                if (linhasAfetadas > 0)
                    MessageBox.Show("Objetivo editado com sucesso!");
                else
                    MessageBox.Show("Erro: Nenhum objetivo foi alterado. Verifica o ID ou os dados.");
            }

            CarregarObjetivos();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(guna2TextBox1.Text, out int idObjetivo))
            {
                MessageBox.Show("ID inválido.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(@"
        DELETE FROM Objetivos 
        WHERE Id = @id AND IdUtilizador = @idUtilizador", conn))
            {
                cmd.Parameters.AddWithValue("@id", idObjetivo);
                cmd.Parameters.AddWithValue("@idUtilizador", SessaoUtilizador.Id);

                conn.Open();
                int linhasApagadas = cmd.ExecuteNonQuery();

                if (linhasApagadas > 0)
                    MessageBox.Show("Objetivo removido com sucesso!");
                else
                    MessageBox.Show("Erro: Nenhum objetivo foi removido. Verifica o ID.");
            }

            CarregarObjetivos();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

