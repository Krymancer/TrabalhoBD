namespace BDTur.Forms
{
    partial class FormCadastrarRestaurante
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
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastrarRestaurante));
            this.buttonCancelarCadastroRestaurante = new System.Windows.Forms.Button();
            this.buttonCadastrarRestaurante = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxEndCidadeRestaurante = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxEndCepRestaurante = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEndBairroRestaurante = new System.Windows.Forms.TextBox();
            this.textBoxEndComplementoRestaurante = new System.Windows.Forms.TextBox();
            this.textBoxEndNumeroRestaurante = new System.Windows.Forms.TextBox();
            this.textBoxEndLogradouroRestaurante = new System.Windows.Forms.TextBox();
            this.comboBoxEndTipoRestaurante = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxPreco = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEspecialidadeRestaurante = new System.Windows.Forms.TextBox();
            this.comboBoxCategoriaRestaurante = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxContatoRestaurante = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNomeHotel = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 183);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(43, 13);
            label10.TabIndex = 11;
            label10.Text = "Cidade:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(224, 133);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(29, 13);
            label9.TabIndex = 8;
            label9.Text = "Cep:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(118, 133);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 13);
            label8.TabIndex = 7;
            label8.Text = "Bairro:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 29);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 13);
            label4.TabIndex = 3;
            label4.Text = "Tipo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 80);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 13);
            label5.TabIndex = 4;
            label5.Text = "Logradouro:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 133);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 13);
            label7.TabIndex = 6;
            label7.Text = "Complemento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(224, 80);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(47, 13);
            label6.TabIndex = 5;
            label6.Text = "Número:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(9, 132);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(66, 13);
            label12.TabIndex = 14;
            label12.Text = "Preço médio";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(136, 79);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(76, 13);
            label11.TabIndex = 12;
            label11.Text = "Especialidade:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(114, 13);
            label1.TabIndex = 0;
            label1.Text = "Nome do Restaurante:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 79);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 1;
            label2.Text = "Categoria:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(136, 132);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 2;
            label3.Text = "Contato:";
            // 
            // buttonCancelarCadastroRestaurante
            // 
            this.buttonCancelarCadastroRestaurante.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCadastroRestaurante.Location = new System.Drawing.Point(578, 342);
            this.buttonCancelarCadastroRestaurante.Name = "buttonCancelarCadastroRestaurante";
            this.buttonCancelarCadastroRestaurante.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCadastroRestaurante.TabIndex = 15;
            this.buttonCancelarCadastroRestaurante.Text = "Cancelar";
            this.buttonCancelarCadastroRestaurante.UseVisualStyleBackColor = true;
            this.buttonCancelarCadastroRestaurante.Click += new System.EventHandler(this.buttonCancelarCadastroRestaurante_Click);
            // 
            // buttonCadastrarRestaurante
            // 
            this.buttonCadastrarRestaurante.Location = new System.Drawing.Point(477, 342);
            this.buttonCadastrarRestaurante.Name = "buttonCadastrarRestaurante";
            this.buttonCadastrarRestaurante.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarRestaurante.TabIndex = 14;
            this.buttonCadastrarRestaurante.Text = "Cadastrar";
            this.buttonCadastrarRestaurante.UseVisualStyleBackColor = true;
            this.buttonCadastrarRestaurante.Click += new System.EventHandler(this.buttonCadastrarRestaurante_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxEndCidadeRestaurante);
            this.groupBox2.Controls.Add(label10);
            this.groupBox2.Controls.Add(this.maskedTextBoxEndCepRestaurante);
            this.groupBox2.Controls.Add(this.textBoxEndBairroRestaurante);
            this.groupBox2.Controls.Add(this.textBoxEndComplementoRestaurante);
            this.groupBox2.Controls.Add(this.textBoxEndNumeroRestaurante);
            this.groupBox2.Controls.Add(label9);
            this.groupBox2.Controls.Add(this.textBoxEndLogradouroRestaurante);
            this.groupBox2.Controls.Add(label8);
            this.groupBox2.Controls.Add(this.comboBoxEndTipoRestaurante);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(label7);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Location = new System.Drawing.Point(293, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 263);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço";
            // 
            // comboBoxEndCidadeRestaurante
            // 
            this.comboBoxEndCidadeRestaurante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndCidadeRestaurante.FormattingEnabled = true;
            this.comboBoxEndCidadeRestaurante.Location = new System.Drawing.Point(9, 199);
            this.comboBoxEndCidadeRestaurante.Name = "comboBoxEndCidadeRestaurante";
            this.comboBoxEndCidadeRestaurante.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEndCidadeRestaurante.TabIndex = 11;
            // 
            // maskedTextBoxEndCepRestaurante
            // 
            this.maskedTextBoxEndCepRestaurante.Location = new System.Drawing.Point(227, 150);
            this.maskedTextBoxEndCepRestaurante.Mask = "00000-999";
            this.maskedTextBoxEndCepRestaurante.Name = "maskedTextBoxEndCepRestaurante";
            this.maskedTextBoxEndCepRestaurante.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxEndCepRestaurante.TabIndex = 10;
            // 
            // textBoxEndBairroRestaurante
            // 
            this.textBoxEndBairroRestaurante.Location = new System.Drawing.Point(121, 150);
            this.textBoxEndBairroRestaurante.Name = "textBoxEndBairroRestaurante";
            this.textBoxEndBairroRestaurante.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndBairroRestaurante.TabIndex = 9;
            // 
            // textBoxEndComplementoRestaurante
            // 
            this.textBoxEndComplementoRestaurante.Location = new System.Drawing.Point(9, 150);
            this.textBoxEndComplementoRestaurante.Name = "textBoxEndComplementoRestaurante";
            this.textBoxEndComplementoRestaurante.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndComplementoRestaurante.TabIndex = 8;
            // 
            // textBoxEndNumeroRestaurante
            // 
            this.textBoxEndNumeroRestaurante.Location = new System.Drawing.Point(227, 96);
            this.textBoxEndNumeroRestaurante.Name = "textBoxEndNumeroRestaurante";
            this.textBoxEndNumeroRestaurante.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndNumeroRestaurante.TabIndex = 7;
            this.textBoxEndNumeroRestaurante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEndNumeroRestaurante_KeyPress);
            // 
            // textBoxEndLogradouroRestaurante
            // 
            this.textBoxEndLogradouroRestaurante.Location = new System.Drawing.Point(9, 96);
            this.textBoxEndLogradouroRestaurante.Name = "textBoxEndLogradouroRestaurante";
            this.textBoxEndLogradouroRestaurante.Size = new System.Drawing.Size(212, 20);
            this.textBoxEndLogradouroRestaurante.TabIndex = 6;
            // 
            // comboBoxEndTipoRestaurante
            // 
            this.comboBoxEndTipoRestaurante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndTipoRestaurante.FormattingEnabled = true;
            this.comboBoxEndTipoRestaurante.Location = new System.Drawing.Point(9, 45);
            this.comboBoxEndTipoRestaurante.Name = "comboBoxEndTipoRestaurante";
            this.comboBoxEndTipoRestaurante.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEndTipoRestaurante.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBoxPreco);
            this.groupBox1.Controls.Add(label12);
            this.groupBox1.Controls.Add(this.textBoxEspecialidadeRestaurante);
            this.groupBox1.Controls.Add(label11);
            this.groupBox1.Controls.Add(this.comboBoxCategoriaRestaurante);
            this.groupBox1.Controls.Add(this.maskedTextBoxContatoRestaurante);
            this.groupBox1.Controls.Add(this.textBoxNomeHotel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(17, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 263);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // maskedTextBoxPreco
            // 
            this.maskedTextBoxPreco.Location = new System.Drawing.Point(12, 149);
            this.maskedTextBoxPreco.Mask = "$000,00";
            this.maskedTextBoxPreco.Name = "maskedTextBoxPreco";
            this.maskedTextBoxPreco.PromptChar = '0';
            this.maskedTextBoxPreco.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.maskedTextBoxPreco.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxPreco.TabIndex = 3;
            this.maskedTextBoxPreco.ValidatingType = typeof(int);
            // 
            // textBoxEspecialidadeRestaurante
            // 
            this.textBoxEspecialidadeRestaurante.Location = new System.Drawing.Point(139, 94);
            this.textBoxEspecialidadeRestaurante.Name = "textBoxEspecialidadeRestaurante";
            this.textBoxEspecialidadeRestaurante.Size = new System.Drawing.Size(92, 20);
            this.textBoxEspecialidadeRestaurante.TabIndex = 2;
            // 
            // comboBoxCategoriaRestaurante
            // 
            this.comboBoxCategoriaRestaurante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoriaRestaurante.FormattingEnabled = true;
            this.comboBoxCategoriaRestaurante.Location = new System.Drawing.Point(9, 94);
            this.comboBoxCategoriaRestaurante.Name = "comboBoxCategoriaRestaurante";
            this.comboBoxCategoriaRestaurante.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategoriaRestaurante.TabIndex = 1;
            // 
            // maskedTextBoxContatoRestaurante
            // 
            this.maskedTextBoxContatoRestaurante.Location = new System.Drawing.Point(139, 149);
            this.maskedTextBoxContatoRestaurante.Mask = "(99) 00000-0000";
            this.maskedTextBoxContatoRestaurante.Name = "maskedTextBoxContatoRestaurante";
            this.maskedTextBoxContatoRestaurante.Size = new System.Drawing.Size(92, 20);
            this.maskedTextBoxContatoRestaurante.TabIndex = 4;
            // 
            // textBoxNomeHotel
            // 
            this.textBoxNomeHotel.Location = new System.Drawing.Point(9, 45);
            this.textBoxNomeHotel.Name = "textBoxNomeHotel";
            this.textBoxNomeHotel.Size = new System.Drawing.Size(223, 20);
            this.textBoxNomeHotel.TabIndex = 0;
            // 
            // FormCadastrarRestaurante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelarCadastroRestaurante;
            this.ClientSize = new System.Drawing.Size(669, 379);
            this.Controls.Add(this.buttonCancelarCadastroRestaurante);
            this.Controls.Add(this.buttonCadastrarRestaurante);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastrarRestaurante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Restaurante";
            this.Load += new System.EventHandler(this.FormCadastrarRestaurante_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelarCadastroRestaurante;
        private System.Windows.Forms.Button buttonCadastrarRestaurante;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxEndCidadeRestaurante;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxEndCepRestaurante;
        private System.Windows.Forms.TextBox textBoxEndBairroRestaurante;
        private System.Windows.Forms.TextBox textBoxEndComplementoRestaurante;
        private System.Windows.Forms.TextBox textBoxEndNumeroRestaurante;
        private System.Windows.Forms.TextBox textBoxEndLogradouroRestaurante;
        private System.Windows.Forms.ComboBox comboBoxEndTipoRestaurante;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxCategoriaRestaurante;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxContatoRestaurante;
        private System.Windows.Forms.TextBox textBoxNomeHotel;
        private System.Windows.Forms.TextBox textBoxEspecialidadeRestaurante;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPreco;
    }
}