namespace BDTur.Forms
{
    partial class FormCidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCidades));
            this.groupBoxCidade = new System.Windows.Forms.GroupBox();
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.textBoxCidade = new System.Windows.Forms.TextBox();
            this.labelCidade = new System.Windows.Forms.Label();
            this.dataGridViewCidade = new System.Windows.Forms.DataGridView();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.groupBoxCidade.SuspendLayout();
            this.groupBoxFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCidade)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCidade
            // 
            this.groupBoxCidade.Controls.Add(this.groupBoxFiltro);
            this.groupBoxCidade.Controls.Add(this.dataGridViewCidade);
            this.groupBoxCidade.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCidade.Name = "groupBoxCidade";
            this.groupBoxCidade.Size = new System.Drawing.Size(586, 335);
            this.groupBoxCidade.TabIndex = 30;
            this.groupBoxCidade.TabStop = false;
            this.groupBoxCidade.Text = "Cidades";
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.Controls.Add(this.textBoxEstado);
            this.groupBoxFiltro.Controls.Add(this.labelEstado);
            this.groupBoxFiltro.Controls.Add(this.textBoxCidade);
            this.groupBoxFiltro.Controls.Add(this.labelCidade);
            this.groupBoxFiltro.Location = new System.Drawing.Point(455, 19);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(125, 105);
            this.groupBoxFiltro.TabIndex = 1;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Filtro";
            // 
            // textBoxEstado
            // 
            this.textBoxEstado.Location = new System.Drawing.Point(9, 71);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.Size = new System.Drawing.Size(100, 20);
            this.textBoxEstado.TabIndex = 1;
            this.textBoxEstado.TextChanged += new System.EventHandler(this.textBoxEstado_TextChanged);
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(6, 55);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 34;
            this.labelEstado.Text = "Estado:";
            // 
            // textBoxCidade
            // 
            this.textBoxCidade.Location = new System.Drawing.Point(9, 32);
            this.textBoxCidade.Name = "textBoxCidade";
            this.textBoxCidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxCidade.TabIndex = 0;
            this.textBoxCidade.TextChanged += new System.EventHandler(this.textBoxCidade_TextChanged);
            // 
            // labelCidade
            // 
            this.labelCidade.AutoSize = true;
            this.labelCidade.Location = new System.Drawing.Point(6, 16);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(43, 13);
            this.labelCidade.TabIndex = 32;
            this.labelCidade.Text = "Cidade:";
            // 
            // dataGridViewCidade
            // 
            this.dataGridViewCidade.AllowUserToAddRows = false;
            this.dataGridViewCidade.AllowUserToDeleteRows = false;
            this.dataGridViewCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCidade.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewCidade.Location = new System.Drawing.Point(12, 19);
            this.dataGridViewCidade.Name = "dataGridViewCidade";
            this.dataGridViewCidade.Size = new System.Drawing.Size(437, 309);
            this.dataGridViewCidade.TabIndex = 0;
            this.dataGridViewCidade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCidade_CellDoubleClick);
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonVoltar.Location = new System.Drawing.Point(523, 353);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 2;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // FormCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonVoltar;
            this.ClientSize = new System.Drawing.Size(604, 383);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.groupBoxCidade);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cidades";
            this.groupBoxCidade.ResumeLayout(false);
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCidade;
        private System.Windows.Forms.DataGridView dataGridViewCidade;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Label labelCidade;
        private System.Windows.Forms.TextBox textBoxCidade;
        private System.Windows.Forms.GroupBox groupBoxFiltro;
        private System.Windows.Forms.TextBox textBoxEstado;
        private System.Windows.Forms.Label labelEstado;
    }
}