namespace BDTur.Forms
{
    partial class FormDetalhesFundador
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
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label3;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNacionalidadeFundador = new System.Windows.Forms.TextBox();
            this.maskedTextBoxDataMorteFundador = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDataNascimentoFundador = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAtividadeProfissionalFundador = new System.Windows.Forms.TextBox();
            this.textBoxNomeFundador = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listBoxPontosTuristicosFundados = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCancelarCadastroHotel = new System.Windows.Forms.Button();
            this.buttonCadastrarHotel = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(120, 79);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(78, 13);
            label11.TabIndex = 12;
            label11.Text = "Nacionalidade:";
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
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados Pessoais";
            // 
            // textBoxNacionalidadeFundador
            // 
            this.textBoxNacionalidadeFundador.Enabled = false;
            this.textBoxNacionalidadeFundador.Location = new System.Drawing.Point(123, 95);
            this.textBoxNacionalidadeFundador.Name = "textBoxNacionalidadeFundador";
            this.textBoxNacionalidadeFundador.Size = new System.Drawing.Size(100, 20);
            this.textBoxNacionalidadeFundador.TabIndex = 2;
            // 
            // maskedTextBoxDataMorteFundador
            // 
            this.maskedTextBoxDataMorteFundador.Enabled = false;
            this.maskedTextBoxDataMorteFundador.Location = new System.Drawing.Point(123, 150);
            this.maskedTextBoxDataMorteFundador.Mask = "00/00/0000";
            this.maskedTextBoxDataMorteFundador.Name = "maskedTextBoxDataMorteFundador";
            this.maskedTextBoxDataMorteFundador.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDataMorteFundador.TabIndex = 4;
            this.maskedTextBoxDataMorteFundador.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBoxDataNascimentoFundador
            // 
            this.maskedTextBoxDataNascimentoFundador.Enabled = false;
            this.maskedTextBoxDataNascimentoFundador.Location = new System.Drawing.Point(12, 150);
            this.maskedTextBoxDataNascimentoFundador.Mask = "00/00/0000";
            this.maskedTextBoxDataNascimentoFundador.Name = "maskedTextBoxDataNascimentoFundador";
            this.maskedTextBoxDataNascimentoFundador.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDataNascimentoFundador.TabIndex = 3;
            this.maskedTextBoxDataNascimentoFundador.ValidatingType = typeof(System.DateTime);
            // 
            // textBoxAtividadeProfissionalFundador
            // 
            this.textBoxAtividadeProfissionalFundador.Enabled = false;
            this.textBoxAtividadeProfissionalFundador.Location = new System.Drawing.Point(12, 96);
            this.textBoxAtividadeProfissionalFundador.Name = "textBoxAtividadeProfissionalFundador";
            this.textBoxAtividadeProfissionalFundador.Size = new System.Drawing.Size(100, 20);
            this.textBoxAtividadeProfissionalFundador.TabIndex = 1;
            // 
            // textBoxNomeFundador
            // 
            this.textBoxNomeFundador.Enabled = false;
            this.textBoxNomeFundador.Location = new System.Drawing.Point(9, 45);
            this.textBoxNomeFundador.Name = "textBoxNomeFundador";
            this.textBoxNomeFundador.Size = new System.Drawing.Size(223, 20);
            this.textBoxNomeFundador.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listBoxPontosTuristicosFundados);
            this.groupBox3.Location = new System.Drawing.Point(279, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 181);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pontos Turisticos Fundados";
            // 
            // listBoxPontosTuristicosFundados
            // 
            this.listBoxPontosTuristicosFundados.DisplayMember = "nomePontoTuristico";
            this.listBoxPontosTuristicosFundados.Enabled = false;
            this.listBoxPontosTuristicosFundados.FormattingEnabled = true;
            this.listBoxPontosTuristicosFundados.Location = new System.Drawing.Point(6, 22);
            this.listBoxPontosTuristicosFundados.Name = "listBoxPontosTuristicosFundados";
            this.listBoxPontosTuristicosFundados.Size = new System.Drawing.Size(169, 147);
            this.listBoxPontosTuristicosFundados.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 216);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancelarCadastroHotel
            // 
            this.buttonCancelarCadastroHotel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCadastroHotel.Location = new System.Drawing.Point(379, 216);
            this.buttonCancelarCadastroHotel.Name = "buttonCancelarCadastroHotel";
            this.buttonCancelarCadastroHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCadastroHotel.TabIndex = 34;
            this.buttonCancelarCadastroHotel.Text = "Cancelar";
            this.buttonCancelarCadastroHotel.UseVisualStyleBackColor = true;
            // 
            // buttonCadastrarHotel
            // 
            this.buttonCadastrarHotel.Location = new System.Drawing.Point(278, 216);
            this.buttonCadastrarHotel.Name = "buttonCadastrarHotel";
            this.buttonCadastrarHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarHotel.TabIndex = 33;
            this.buttonCadastrarHotel.Text = "Excluir";
            this.buttonCadastrarHotel.UseVisualStyleBackColor = true;
            // 
            // FormDetalhesFundador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCancelarCadastroHotel);
            this.Controls.Add(this.buttonCadastrarHotel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDetalhesFundador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes Fundador";
            this.Load += new System.EventHandler(this.FormDetalhesFundador_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNacionalidadeFundador;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataMorteFundador;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataNascimentoFundador;
        private System.Windows.Forms.TextBox textBoxAtividadeProfissionalFundador;
        private System.Windows.Forms.TextBox textBoxNomeFundador;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listBoxPontosTuristicosFundados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCancelarCadastroHotel;
        private System.Windows.Forms.Button buttonCadastrarHotel;
    }
}