namespace BDTur.Forms
{
    partial class FormDetalhesCidade
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
            System.Windows.Forms.Label labelIdCidade;
            System.Windows.Forms.Label labelPopulacaoCidade;
            System.Windows.Forms.Label labelNomeCidade;
            System.Windows.Forms.Label labelEstadoCidade;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalhesCidade));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxIdCidade = new System.Windows.Forms.TextBox();
            this.textBoxEstadoCidade = new System.Windows.Forms.TextBox();
            this.textBoxPopulacaoCidade = new System.Windows.Forms.TextBox();
            this.textBoxNomeCidade = new System.Windows.Forms.TextBox();
            this.buttonEditarCidade = new System.Windows.Forms.Button();
            this.buttonExcluirCidade = new System.Windows.Forms.Button();
            this.buttonCancelarCidade = new System.Windows.Forms.Button();
            labelIdCidade = new System.Windows.Forms.Label();
            labelPopulacaoCidade = new System.Windows.Forms.Label();
            labelNomeCidade = new System.Windows.Forms.Label();
            labelEstadoCidade = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelIdCidade
            // 
            labelIdCidade.AutoSize = true;
            labelIdCidade.Location = new System.Drawing.Point(9, 16);
            labelIdCidade.Name = "labelIdCidade";
            labelIdCidade.Size = new System.Drawing.Size(21, 13);
            labelIdCidade.TabIndex = 21;
            labelIdCidade.Text = "ID:";
            // 
            // labelPopulacaoCidade
            // 
            labelPopulacaoCidade.AutoSize = true;
            labelPopulacaoCidade.Location = new System.Drawing.Point(115, 55);
            labelPopulacaoCidade.Name = "labelPopulacaoCidade";
            labelPopulacaoCidade.Size = new System.Drawing.Size(61, 13);
            labelPopulacaoCidade.TabIndex = 19;
            labelPopulacaoCidade.Text = "População:";
            // 
            // labelNomeCidade
            // 
            labelNomeCidade.AutoSize = true;
            labelNomeCidade.Location = new System.Drawing.Point(112, 16);
            labelNomeCidade.Name = "labelNomeCidade";
            labelNomeCidade.Size = new System.Drawing.Size(89, 13);
            labelNomeCidade.TabIndex = 0;
            labelNomeCidade.Text = "Nome da Cidade:";
            // 
            // labelEstadoCidade
            // 
            labelEstadoCidade.AutoSize = true;
            labelEstadoCidade.Location = new System.Drawing.Point(9, 55);
            labelEstadoCidade.Name = "labelEstadoCidade";
            labelEstadoCidade.Size = new System.Drawing.Size(43, 13);
            labelEstadoCidade.TabIndex = 2;
            labelEstadoCidade.Text = "Estado:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxIdCidade);
            this.groupBox1.Controls.Add(labelIdCidade);
            this.groupBox1.Controls.Add(this.textBoxEstadoCidade);
            this.groupBox1.Controls.Add(this.textBoxPopulacaoCidade);
            this.groupBox1.Controls.Add(labelPopulacaoCidade);
            this.groupBox1.Controls.Add(this.textBoxNomeCidade);
            this.groupBox1.Controls.Add(labelNomeCidade);
            this.groupBox1.Controls.Add(labelEstadoCidade);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 110);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // textBoxIdCidade
            // 
            this.textBoxIdCidade.Enabled = false;
            this.textBoxIdCidade.Location = new System.Drawing.Point(9, 32);
            this.textBoxIdCidade.Name = "textBoxIdCidade";
            this.textBoxIdCidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxIdCidade.TabIndex = 0;
            // 
            // textBoxEstadoCidade
            // 
            this.textBoxEstadoCidade.Enabled = false;
            this.textBoxEstadoCidade.Location = new System.Drawing.Point(9, 71);
            this.textBoxEstadoCidade.Name = "textBoxEstadoCidade";
            this.textBoxEstadoCidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxEstadoCidade.TabIndex = 2;
            // 
            // textBoxPopulacaoCidade
            // 
            this.textBoxPopulacaoCidade.Enabled = false;
            this.textBoxPopulacaoCidade.Location = new System.Drawing.Point(115, 72);
            this.textBoxPopulacaoCidade.Name = "textBoxPopulacaoCidade";
            this.textBoxPopulacaoCidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxPopulacaoCidade.TabIndex = 3;
            this.textBoxPopulacaoCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPopulacaoCidade_KeyPress);
            // 
            // textBoxNomeCidade
            // 
            this.textBoxNomeCidade.Enabled = false;
            this.textBoxNomeCidade.Location = new System.Drawing.Point(115, 32);
            this.textBoxNomeCidade.Name = "textBoxNomeCidade";
            this.textBoxNomeCidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxNomeCidade.TabIndex = 1;
            // 
            // buttonEditarCidade
            // 
            this.buttonEditarCidade.Location = new System.Drawing.Point(13, 128);
            this.buttonEditarCidade.Name = "buttonEditarCidade";
            this.buttonEditarCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonEditarCidade.TabIndex = 4;
            this.buttonEditarCidade.Text = "Editar";
            this.buttonEditarCidade.UseVisualStyleBackColor = true;
            this.buttonEditarCidade.Click += new System.EventHandler(this.buttonEditarCidade_Click);
            // 
            // buttonExcluirCidade
            // 
            this.buttonExcluirCidade.Location = new System.Drawing.Point(106, 128);
            this.buttonExcluirCidade.Name = "buttonExcluirCidade";
            this.buttonExcluirCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonExcluirCidade.TabIndex = 5;
            this.buttonExcluirCidade.Text = "Excluir";
            this.buttonExcluirCidade.UseVisualStyleBackColor = true;
            this.buttonExcluirCidade.Click += new System.EventHandler(this.buttonExcluirCidade_Click);
            // 
            // buttonCancelarCidade
            // 
            this.buttonCancelarCidade.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCidade.Location = new System.Drawing.Point(198, 128);
            this.buttonCancelarCidade.Name = "buttonCancelarCidade";
            this.buttonCancelarCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCidade.TabIndex = 6;
            this.buttonCancelarCidade.Text = "Cancelar";
            this.buttonCancelarCidade.UseVisualStyleBackColor = true;
            this.buttonCancelarCidade.Click += new System.EventHandler(this.buttonCancelarCidade_Click);
            // 
            // FormDetalhesCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 169);
            this.Controls.Add(this.buttonEditarCidade);
            this.Controls.Add(this.buttonExcluirCidade);
            this.Controls.Add(this.buttonCancelarCidade);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDetalhesCidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes Cidade";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxIdCidade;
        private System.Windows.Forms.TextBox textBoxEstadoCidade;
        private System.Windows.Forms.TextBox textBoxPopulacaoCidade;
        private System.Windows.Forms.TextBox textBoxNomeCidade;
        private System.Windows.Forms.Button buttonEditarCidade;
        private System.Windows.Forms.Button buttonExcluirCidade;
        private System.Windows.Forms.Button buttonCancelarCidade;
    }
}