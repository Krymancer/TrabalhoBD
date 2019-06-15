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
            this.groupBoxCidade = new System.Windows.Forms.GroupBox();
            this.dataGridViewCidade = new System.Windows.Forms.DataGridView();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.labelCidade = new System.Windows.Forms.Label();
            this.textBoxCidade = new System.Windows.Forms.TextBox();
            this.groupBoxFiltro = new System.Windows.Forms.GroupBox();
            this.textBoxEstado = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxPopulacao = new System.Windows.Forms.TextBox();
            this.labelPopulacao = new System.Windows.Forms.Label();
            this.groupBoxCidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCidade)).BeginInit();
            this.groupBoxFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCidade
            // 
            this.groupBoxCidade.Controls.Add(this.groupBoxFiltro);
            this.groupBoxCidade.Controls.Add(this.dataGridViewCidade);
            this.groupBoxCidade.Location = new System.Drawing.Point(12, 12);
            this.groupBoxCidade.Name = "groupBoxCidade";
            this.groupBoxCidade.Size = new System.Drawing.Size(760, 335);
            this.groupBoxCidade.TabIndex = 30;
            this.groupBoxCidade.TabStop = false;
            this.groupBoxCidade.Text = "Cidades";
            // 
            // dataGridViewCidade
            // 
            this.dataGridViewCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCidade.Location = new System.Drawing.Point(12, 19);
            this.dataGridViewCidade.Name = "dataGridViewCidade";
            this.dataGridViewCidade.Size = new System.Drawing.Size(609, 309);
            this.dataGridViewCidade.TabIndex = 0;
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Location = new System.Drawing.Point(697, 353);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 31;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            // 
            // labelCidade
            // 
            this.labelCidade.AutoSize = true;
            this.labelCidade.Location = new System.Drawing.Point(10, 61);
            this.labelCidade.Name = "labelCidade";
            this.labelCidade.Size = new System.Drawing.Size(43, 13);
            this.labelCidade.TabIndex = 32;
            this.labelCidade.Text = "Cidade:";
            // 
            // textBoxCidade
            // 
            this.textBoxCidade.Location = new System.Drawing.Point(13, 77);
            this.textBoxCidade.Name = "textBoxCidade";
            this.textBoxCidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxCidade.TabIndex = 33;
            // 
            // groupBoxFiltro
            // 
            this.groupBoxFiltro.Controls.Add(this.textBoxPopulacao);
            this.groupBoxFiltro.Controls.Add(this.labelPopulacao);
            this.groupBoxFiltro.Controls.Add(this.textBoxId);
            this.groupBoxFiltro.Controls.Add(this.labelId);
            this.groupBoxFiltro.Controls.Add(this.textBoxEstado);
            this.groupBoxFiltro.Controls.Add(this.labelEstado);
            this.groupBoxFiltro.Controls.Add(this.textBoxCidade);
            this.groupBoxFiltro.Controls.Add(this.labelCidade);
            this.groupBoxFiltro.Location = new System.Drawing.Point(628, 19);
            this.groupBoxFiltro.Name = "groupBoxFiltro";
            this.groupBoxFiltro.Size = new System.Drawing.Size(125, 309);
            this.groupBoxFiltro.TabIndex = 1;
            this.groupBoxFiltro.TabStop = false;
            this.groupBoxFiltro.Text = "Filtro";
            // 
            // textBoxEstado
            // 
            this.textBoxEstado.Location = new System.Drawing.Point(13, 116);
            this.textBoxEstado.Name = "textBoxEstado";
            this.textBoxEstado.Size = new System.Drawing.Size(100, 20);
            this.textBoxEstado.TabIndex = 35;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Location = new System.Drawing.Point(10, 100);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 13);
            this.labelEstado.TabIndex = 34;
            this.labelEstado.Text = "Estado:";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(13, 38);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(100, 20);
            this.textBoxId.TabIndex = 37;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(10, 22);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(21, 13);
            this.labelId.TabIndex = 36;
            this.labelId.Text = "ID:";
            // 
            // textBoxPopulacao
            // 
            this.textBoxPopulacao.Location = new System.Drawing.Point(13, 155);
            this.textBoxPopulacao.Name = "textBoxPopulacao";
            this.textBoxPopulacao.Size = new System.Drawing.Size(100, 20);
            this.textBoxPopulacao.TabIndex = 39;
            // 
            // labelPopulacao
            // 
            this.labelPopulacao.AutoSize = true;
            this.labelPopulacao.Location = new System.Drawing.Point(10, 139);
            this.labelPopulacao.Name = "labelPopulacao";
            this.labelPopulacao.Size = new System.Drawing.Size(61, 13);
            this.labelPopulacao.TabIndex = 38;
            this.labelPopulacao.Text = "População:";
            // 
            // FormCidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 383);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.groupBoxCidade);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cidades";
            this.groupBoxCidade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCidade)).EndInit();
            this.groupBoxFiltro.ResumeLayout(false);
            this.groupBoxFiltro.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxPopulacao;
        private System.Windows.Forms.Label labelPopulacao;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelId;
    }
}