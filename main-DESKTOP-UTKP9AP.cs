using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using preprojetopap;


namespace preprojetopap
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            label3.Text = "Bem-vindo, " + SessaoUtilizador.Nome + "!";
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }

        private void main_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'smartWorkoutDataSet.Treinos'. Você pode movê-la ou removê-la conforme necessário.
            this.treinosTableAdapter.Fill(this.smartWorkoutDataSet.Treinos);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
