namespace BDTur.Forms
{
    partial class FormCadastrarFundador
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
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastrarFundador));
            this.buttonCancelarCadastroFundador = new System.Windows.Forms.Button();
            this.buttonCadastrarFundador = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNacionalidadeFundador = new System.Windows.Forms.TextBox();
            this.maskedTextBoxDataMorteFundador = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDataNascimentoFundador = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAtividadeProfissionalFundador = new System.Windows.Forms.TextBox();
            this.textBoxNomeFundador = new System.Windows.Forms.TextBox();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(9, 133);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(105, 13);
            label13.TabIndex = 19;
            label13.Text = "Data de nascimento:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(120, 133);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(105, 13);
            label12.TabIndex = 16;
            label12.Text = "Data de falecimento:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(101, 13);
            label1.TabIndex = 0;
            label1.Text = "Nome do Fundador:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9, 79);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(109, 13);
            label3.TabIndex = 2;
            label3.Text = "Atividade profissional:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(120, 79);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(78, 13);
            label11.TabIndex = 12;
            label11.Text = "Nacionalidade:";
            // 
            // buttonCancelarCadastroFundador
            // 
            this.buttonCancelarCadastroFundador.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCadastroFundador.Location = new System.Drawing.Point(198, 207);
            this.buttonCancelarCadastroFundador.Name = "buttonCancelarCadastroFundador";
            this.buttonCancelarCadastroFundador.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCadastroFundador.TabIndex = 6;
            this.buttonCancelarCadastroFundador.Text = "Cancelar";
            this.buttonCancelarCadastroFundador.UseVisualStyleBackColor = true;
            this.buttonCancelarCadastroFundador.Click += new System.EventHandler(this.buttonCancelarCadastroFundador_Click);
            // 
            // buttonCadastrarFundador
            // 
            this.buttonCadastrarFundador.Location = new System.Drawing.Point(105, 207);
            this.buttonCadastrarFundador.Name = "buttonCadastrarFundador";
            this.buttonCadastrarFundador.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarFundador.TabIndex = 5;
            this.buttonCadastrarFundador.Text = "Cadastrar";
            this.buttonCadastrarFundador.UseVisualStyleBackColor = true;
            this.buttonCadastrarFundador.Click += new System.EventHandler(this.buttonCadastrarFundador_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNacionalidadeFundador);
            this.groupBox1.Controls.Add(this.maskedTextBoxDataMorteFundador);
            this.groupBox1.Controls.Add(this.maskedTextBoxDataNascimentoFundador);
            this.groupBox1.Controls.Add(this.textBoxAtividadeProfissionalFundador);
            this.groupBox1.Controls.Add(label13);
            this.groupBox1.Controls.Add(label12);
            this.groupBox1.Controls.Add(label11);
            this.groupBox1.Controls.Add(this.textBoxNomeFundador);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 189);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Pessoais";
            // 
            // textBoxNacionalidadeFundador
            // 
            this.textBoxNacionalidadeFundador.Location = new System.Drawing.Point(123, 95);
            this.textBoxNacionalidadeFundador.Name = "textBoxNacionalidadeFundador";
            this.textBoxNacionalidadeFundador.Size = new System.Drawing.Size(100, 20);
            this.textBoxNacionalidadeFundador.TabIndex = 2;
            // 
            // maskedTextBoxDataMorteFundador
            // 
            this.maskedTextBoxDataMorteFundador.Location = new System.Drawing.Point(123, 150);
            this.maskedTextBoxDataMorteFundador.Mask = "00/00/0000";
            this.maskedTextBoxDataMorteFundador.Name = "maskedTextBoxDataMorteFundador";
            this.maskedTextBoxDataMorteFundador.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDataMorteFundador.TabIndex = 4;
            this.maskedTextBoxDataMorteFundador.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBoxDataNascimentoFundador
            // 
            this.maskedTextBoxDataNascimentoFundador.Location = new System.Drawing.Point(12, 150);
            this.maskedTextBoxDataNascimentoFundador.Mask = "00/00/0000";
            this.maskedTextBoxDataNascimentoFundador.Name = "maskedTextBoxDataNascimentoFundador";
            this.maskedTextBoxDataNascimentoFundador.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDataNascimentoFundador.TabIndex = 3;
            this.maskedTextBoxDataNascimentoFundador.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxAtividadeProfissionalFundador
            // 
            this.textBoxAtividadeProfissionalFundador.Location = new System.Drawing.Point(12, 96);
            this.textBoxAtividadeProfissionalFundador.Name = "textBoxAtividadeProfissionalFundador";
            this.textBoxAtividadeProfissionalFundador.Size = new System.Drawing.Size(100, 20);
            this.textBoxAtividadeProfissionalFundador.TabIndex = 1;
            // 
            // textBoxNomeFundador
            // 
            this.textBoxNomeFundador.Location = new System.Drawing.Point(9, 45);
            this.textBoxNomeFundador.Name = "textBoxNomeFundador";
            this.textBoxNomeFundador.Size = new System.Drawing.Size(223, 20);
            this.textBoxNomeFundador.TabIndex = 0;
            // 
            // FormCadastrarFundador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelarCadastroFundador;
            this.ClientSize = new System.Drawing.Size(283, 238);
            this.Controls.Add(this.buttonCancelarCadastroFundador);
            this.Controls.Add(this.buttonCadastrarFundador);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastrarFundador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fundador";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelarCadastroFundador;
        private System.Windows.Forms.Button buttonCadastrarFundador;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNomeFundador;
        private System.Windows.Forms.TextBox textBoxAtividadeProfissionalFundador;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataMorteFundador;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataNascimentoFundador;
        private System.Windows.Forms.TextBox textBoxNacionalidadeFundador;
    }
}