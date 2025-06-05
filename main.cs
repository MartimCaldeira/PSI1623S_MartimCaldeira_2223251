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
using System.Windows.Forms.DataVisualization.Charting;


namespace preprojetopap
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            CarregarObjetivos();

            label3.Text = "Bem-vindo(a), " + SessaoUtilizador.Nome + "!";
            dataGridView1.AutoGenerateColumns = true;
             this.Load += main_Load;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewObjetivos.RowHeadersVisible = false;
            dataGridViewObjetivos.EnableHeadersVisualStyles = false;
            dataGridViewObjetivos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dataGridViewObjetivos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewObjetivos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridViewObjetivos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewObjetivos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dataGridViewObjetivos.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridViewObjetivos.RowHeadersVisible = false;

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
        private void main_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet13.Objetivos'. Você pode movê-la ou removê-la conforme necessário.
            this.objetivosTableAdapter1.Fill(this.smartWorkoutDataSet13.Objetivos);
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet10.Objetivos'. Você pode movê-la ou removê-la conforme necessário.
            
            this.tipoTreinoTableAdapter.Fill(this.tipoDeTreinosTreinos.TipoTreino);
            this.vTreinosComNomeTipoTableAdapter.Fill(this.smartWorkoutDataSet1.vTreinosComNomeTipo);

            CarregarTreinos();
            CarregarGraficoSemana(); // <- aqui fica o gráfico também
        }


        private void CarregarGraficoSemana()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"
            SELECT 
                DATEPART(WEEKDAY, Data) AS DiaNum,
                SUM(Duracao) AS TotalMinutos
            FROM Treinos
            WHERE IdUtilizador = @id
            GROUP BY DATEPART(WEEKDAY, Data);";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", SessaoUtilizador.Id);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Nomes dos dias da semana
                    Dictionary<int, string> diasSemana = new Dictionary<int, string>
            {
                {1, "Domingo"},
                {2, "Segunda"},
                {3, "Terça"},
                {4, "Quarta"},
                {5, "Quinta"},
                {6, "Sexta"},
                {7, "Sábado"}
            };

                    // Inicializar todos os dias com 0
                    Dictionary<int, int> duracaoPorDia = diasSemana.ToDictionary(d => d.Key, d => 0);

                    foreach (DataRow row in dt.Rows)
                    {
                        int dia = Convert.ToInt32(row["DiaNum"]);
                        int minutos = Convert.ToInt32(row["TotalMinutos"]);
                        if (duracaoPorDia.ContainsKey(dia))
                            duracaoPorDia[dia] = minutos;
                    }

                    // Prepara o gráfico
                    chart1.Series.Clear();
                    chart1.ChartAreas[0].AxisX.Title = "Dia da Semana";
                    chart1.ChartAreas[0].AxisY.Title = "Minutos de Treino";

                    Series serie = new Series("Treino")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.DeepSkyBlue
                    };

                    foreach (var dia in duracaoPorDia.OrderBy(d => d.Key))
                    {
                        serie.Points.AddXY(diasSemana[dia.Key], dia.Value);
                    }

                    chart1.Series.Add(serie);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CarregarTreinos()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = @"
            SELECT T.Data, TT.Nome AS TipoTreino, T.Duracao, T.Notas
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

                   
                    if (dataGridView1.Columns.Contains("Id"))
                    {
                        dataGridView1.Columns["Id"].Visible = false;
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Perfil = new perfil();

            Perfil.Show();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var editarTreino = new EditarTreino();

            editarTreino.Show();

            this.Close();
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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        bool sidebarExpand = true;
        private void sidebarTrasition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand) {
                sidebar.Width -= 4;
                if (sidebar.Width <= 41) { 
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

       

        private void treinosBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void smartWorkoutDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnHam_Click_1(object sender, EventArgs e)
        {
            sidebarTrasition.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var objetivos = new Objetivos();

            objetivos.Show();

            this.Close();
        }
    }
}
