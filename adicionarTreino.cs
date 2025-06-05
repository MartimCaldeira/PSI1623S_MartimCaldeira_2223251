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
    public partial class adicionarTreino : Form
    {
        public adicionarTreino()
        {
            InitializeComponent();

            guna2DateTimePicker1.MaxDate = DateTime.Today;
            

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

        

        private void button1_Click(object sender, EventArgs e)
        {
            var Home = new main();

            Home.Show();

            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void adicionarTreino_Load(object sender, EventArgs e)
        {
            
            this.tipoTreinoTableAdapter.Fill(this.smartWorkoutDataSet4.TipoTreino);

        }

        

        private void Confirmar_Click(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=SmartWorkout;Trusted_Connection=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                string query = "Insert into treinos (IdUtilizador,IdTipoTreino,Data,Duracao,Notas) VALUES (@idUtilizador,@idTreino,@data,@duracao,@notas)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idUtilizador", SessaoUtilizador.Id);
                    cmd.Parameters.AddWithValue("@idTreino", comboBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@data", guna2DateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@duracao", int.Parse(guna2TextBox3.Text));
                    cmd.Parameters.AddWithValue("@notas", guna2TextBox2.Text);
                    int linhasAfetadas = cmd.ExecuteNonQuery();

                    if (linhasAfetadas > 0)
                        MessageBox.Show("Treino registado com sucesso!");
                    else
                        MessageBox.Show("Erro ao registar treino.");




                }
            }
            guna2TextBox3.Text = "";
            guna2TextBox2.Text = "";
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var removertreino = new Removertreino();

            removertreino.Show();

            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var editarTreino = new EditarTreino();  

            editarTreino.Show();    

            this.Close();
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

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
