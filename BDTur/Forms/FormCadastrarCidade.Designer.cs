namespace BDTur.Forms
{
    partial class FormCadastrarCidade
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
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastrarCidade));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxEstadoCidade = new System.Windows.Forms.TextBox();
            this.textBoxPopulacaoCidade = new System.Windows.Forms.TextBox();
            this.textBoxNomeCidade = new System.Windows.Forms.TextBox();
            this.buttonCadastrarCidade = new System.Windows.Forms.Button();
            this.buttonCancelarCidade = new System.Windows.Forms.Button();
            label12 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(107, 79);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(61, 13);
            label12.TabIndex = 16;
            label12.Text = "População:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(86, 13);
            label1.TabIndex = 0;
            label1.Text = "Nome da Cidade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 13);
            label3.TabIndex = 2;
            label3.Text = "Estado:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxEstadoCidade);
            this.groupBox1.Controls.Add(this.textBoxPopulacaoCidade);
            this.groupBox1.Controls.Add(label12);
            this.groupBox1.Controls.Add(this.textBoxNomeCidade);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 142);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // textBoxEstadoCidade
            // 
            this.textBoxEstadoCidade.Location = new System.Drawing.Point(9, 96);
            this.textBoxEstadoCidade.Name = "textBoxEstadoCidade";
            this.textBoxEstadoCidade.Size = new System.Drawing.Size(83, 20);
            this.textBoxEstadoCidade.TabIndex = 1;
            // 
            // textBoxPopulacaoCidade
            // 
            this.textBoxPopulacaoCidade.Location = new System.Drawing.Point(110, 96);
            this.textBoxPopulacaoCidade.Name = "textBoxPopulacaoCidade";
            this.textBoxPopulacaoCidade.Size = new System.Drawing.Size(122, 20);
            this.textBoxPopulacaoCidade.TabIndex = 2;
            this.textBoxPopulacaoCidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPopulacaoCidade_KeyPress);
            // 
            // textBoxNomeCidade
            // 
            this.textBoxNomeCidade.Location = new System.Drawing.Point(9, 45);
            this.textBoxNomeCidade.Name = "textBoxNomeCidade";
            this.textBoxNomeCidade.Size = new System.Drawing.Size(133, 20);
            this.textBoxNomeCidade.TabIndex = 0;
            // 
            // buttonCadastrarCidade
            // 
            this.buttonCadastrarCidade.Location = new System.Drawing.Point(117, 157);
            this.buttonCadastrarCidade.Name = "buttonCadastrarCidade";
            this.buttonCadastrarCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarCidade.TabIndex = 3;
            this.buttonCadastrarCidade.Text = "Cadastrar";
            this.buttonCadastrarCidade.UseVisualStyleBackColor = true;
            this.buttonCadastrarCidade.Click += new System.EventHandler(this.buttonCadastrarCidade_Click);
            // 
            // buttonCancelarCidade
            // 
            this.buttonCancelarCidade.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCidade.Location = new System.Drawing.Point(198, 157);
            this.buttonCancelarCidade.Name = "buttonCancelarCidade";
            this.buttonCancelarCidade.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCidade.TabIndex = 4;
            this.buttonCancelarCidade.Text = "Cancelar";
            this.buttonCancelarCidade.UseVisualStyleBackColor = true;
            this.buttonCancelarCidade.Click += new System.EventHandler(this.buttonCancelarCidade_Click);
            // 
            // FormCadastrarCidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelarCidade;
            this.ClientSize = new System.Drawing.Size(283, 189);
            this.Controls.Add(this.buttonCancelarCidade);
            this.Controls.Add(this.buttonCadastrarCidade);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastrarCidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cidade";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPopulacaoCidade;
        private System.Windows.Forms.TextBox textBoxNomeCidade;
        private System.Windows.Forms.TextBox textBoxEstadoCidade;
        private System.Windows.Forms.Button buttonCadastrarCidade;
        private System.Windows.Forms.Button buttonCancelarCidade;
    }
}