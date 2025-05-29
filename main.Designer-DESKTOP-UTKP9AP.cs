namespace preprojetopap
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.smartWorkoutDataSet = new preprojetopap.SmartWorkoutDataSet();
            this.treinosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.treinosTableAdapter = new preprojetopap.SmartWorkoutDataSetTableAdapters.TreinosTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUtilizadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoTreinoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duracaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartWorkoutDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treinosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(18)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 37);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(18)))), ((int)(((byte)(80)))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SmartWorkout";
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(761, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 37);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Location = new System.Drawing.Point(401, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 29);
            this.label3.TabIndex = 3;
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.idUtilizadorDataGridViewTextBoxColumn,
            this.idTipoTreinoDataGridViewTextBoxColumn,
            this.dataDataGridViewTextBoxColumn,
            this.duracaoDataGridViewTextBoxColumn,
            this.notasDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.treinosBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(59, 232);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(642, 197);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // smartWorkoutDataSet
            // 
            this.smartWorkoutDataSet.DataSetName = "SmartWorkoutDataSet";
            this.smartWorkoutDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // treinosBindingSource
            // 
            this.treinosBindingSource.DataMember = "Treinos";
            this.treinosBindingSource.DataSource = this.smartWorkoutDataSet;
            // 
            // treinosTableAdapter
            // 
            this.treinosTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idUtilizadorDataGridViewTextBoxColumn
            // 
            this.idUtilizadorDataGridViewTextBoxColumn.DataPropertyName = "IdUtilizador";
            this.idUtilizadorDataGridViewTextBoxColumn.HeaderText = "IdUtilizador";
            this.idUtilizadorDataGridViewTextBoxColumn.Name = "idUtilizadorDataGridViewTextBoxColumn";
            // 
            // idTipoTreinoDataGridViewTextBoxColumn
            // 
            this.idTipoTreinoDataGridViewTextBoxColumn.DataPropertyName = "IdTipoTreino";
            this.idTipoTreinoDataGridViewTextBoxColumn.HeaderText = "IdTipoTreino";
            this.idTipoTreinoDataGridViewTextBoxColumn.Name = "idTipoTreinoDataGridViewTextBoxColumn";
            // 
            // dataDataGridViewTextBoxColumn
            // 
            this.dataDataGridViewTextBoxColumn.DataPropertyName = "Data";
            this.dataDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataDataGridViewTextBoxColumn.Name = "dataDataGridViewTextBoxColumn";
            // 
            // duracaoDataGridViewTextBoxColumn
            // 
            this.duracaoDataGridViewTextBoxColumn.DataPropertyName = "Duracao";
            this.duracaoDataGridViewTextBoxColumn.HeaderText = "Duracao";
            this.duracaoDataGridViewTextBoxColumn.Name = "duracaoDataGridViewTextBoxColumn";
            // 
            // notasDataGridViewTextBoxColumn
            // 
            this.notasDataGridViewTextBoxColumn.DataPropertyName = "Notas";
            this.notasDataGridViewTextBoxColumn.HeaderText = "Notas";
            this.notasDataGridViewTextBoxColumn.Name = "notasDataGridViewTextBoxColumn";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main";
            this.Text = "main";
            this.Load += new System.EventHandler(this.main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smartWorkoutDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treinosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private SmartWorkoutDataSet smartWorkoutDataSet;
        private System.Windows.Forms.BindingSource treinosBindingSource;
        private SmartWorkoutDataSetTableAdapters.TreinosTableAdapter treinosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUtilizadorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoTreinoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn duracaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notasDataGridViewTextBoxColumn;
    }
}