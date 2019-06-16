namespace BDTur.Forms
{
    partial class FormCadastrarHotel
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastrarHotel));
            this.textBoxNomeHotel = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCategoriaHotel = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxContatoHotel = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxIdRestauranteHotel = new System.Windows.Forms.ComboBox();
            this.comboBoxEndCidadeHotel = new System.Windows.Forms.ComboBox();
            this.labelRestaurante = new System.Windows.Forms.Label();
            this.checkBoxContemRestaurante = new System.Windows.Forms.CheckBox();
            this.maskedTextBoxEndCepHotel = new System.Windows.Forms.MaskedTextBox();
            this.textBoxEndBairroHotel = new System.Windows.Forms.TextBox();
            this.textBoxEndComplementoHotel = new System.Windows.Forms.TextBox();
            this.textBoxEndNumeroHotel = new System.Windows.Forms.TextBox();
            this.textBoxEndLogradouroHotel = new System.Windows.Forms.TextBox();
            this.comboBoxEndTipoHotel = new System.Windows.Forms.ComboBox();
            this.buttonCadastrarHotel = new System.Windows.Forms.Button();
            this.buttonCancelarCadastroHotel = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 45);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 0;
            label1.Text = "Nome do Hotel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 95);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 1;
            label2.Text = "Categoria:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(134, 94);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 2;
            label3.Text = "Contato:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 44);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 13);
            label4.TabIndex = 3;
            label4.Text = "Tipo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(12, 95);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 13);
            label5.TabIndex = 4;
            label5.Text = "Logradouro:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(230, 95);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(47, 13);
            label6.TabIndex = 5;
            label6.Text = "Número:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 148);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 13);
            label7.TabIndex = 6;
            label7.Text = "Complemento:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(124, 148);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 13);
            label8.TabIndex = 7;
            label8.Text = "Bairro:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(230, 148);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(29, 13);
            label9.TabIndex = 8;
            label9.Text = "Cep:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 198);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(43, 13);
            label10.TabIndex = 11;
            label10.Text = "Cidade:";
            // 
            // textBoxNomeHotel
            // 
            this.textBoxNomeHotel.Location = new System.Drawing.Point(6, 61);
            this.textBoxNomeHotel.Name = "textBoxNomeHotel";
            this.textBoxNomeHotel.Size = new System.Drawing.Size(223, 20);
            this.textBoxNomeHotel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCategoriaHotel);
            this.groupBox1.Controls.Add(this.maskedTextBoxContatoHotel);
            this.groupBox1.Controls.Add(this.textBoxNomeHotel);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(27, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 280);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // comboBoxCategoriaHotel
            // 
            this.comboBoxCategoriaHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoriaHotel.FormattingEnabled = true;
            this.comboBoxCategoriaHotel.Location = new System.Drawing.Point(6, 110);
            this.comboBoxCategoriaHotel.Name = "comboBoxCategoriaHotel";
            this.comboBoxCategoriaHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategoriaHotel.TabIndex = 1;
            // 
            // maskedTextBoxContatoHotel
            // 
            this.maskedTextBoxContatoHotel.Location = new System.Drawing.Point(137, 111);
            this.maskedTextBoxContatoHotel.Mask = "(99) 00000-0000";
            this.maskedTextBoxContatoHotel.Name = "maskedTextBoxContatoHotel";
            this.maskedTextBoxContatoHotel.Size = new System.Drawing.Size(92, 20);
            this.maskedTextBoxContatoHotel.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxIdRestauranteHotel);
            this.groupBox2.Controls.Add(this.comboBoxEndCidadeHotel);
            this.groupBox2.Controls.Add(this.labelRestaurante);
            this.groupBox2.Controls.Add(label10);
            this.groupBox2.Controls.Add(this.checkBoxContemRestaurante);
            this.groupBox2.Controls.Add(this.maskedTextBoxEndCepHotel);
            this.groupBox2.Controls.Add(this.textBoxEndBairroHotel);
            this.groupBox2.Controls.Add(this.textBoxEndComplementoHotel);
            this.groupBox2.Controls.Add(this.textBoxEndNumeroHotel);
            this.groupBox2.Controls.Add(label9);
            this.groupBox2.Controls.Add(this.textBoxEndLogradouroHotel);
            this.groupBox2.Controls.Add(label8);
            this.groupBox2.Controls.Add(this.comboBoxEndTipoHotel);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(label7);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Location = new System.Drawing.Point(303, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 280);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço";
            // 
            // comboBoxIdRestauranteHotel
            // 
            this.comboBoxIdRestauranteHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdRestauranteHotel.FormattingEnabled = true;
            this.comboBoxIdRestauranteHotel.Location = new System.Drawing.Point(170, 214);
            this.comboBoxIdRestauranteHotel.Name = "comboBoxIdRestauranteHotel";
            this.comboBoxIdRestauranteHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIdRestauranteHotel.TabIndex = 11;
            // 
            // comboBoxEndCidadeHotel
            // 
            this.comboBoxEndCidadeHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndCidadeHotel.FormattingEnabled = true;
            this.comboBoxEndCidadeHotel.Location = new System.Drawing.Point(15, 214);
            this.comboBoxEndCidadeHotel.Name = "comboBoxEndCidadeHotel";
            this.comboBoxEndCidadeHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEndCidadeHotel.TabIndex = 9;
            // 
            // labelRestaurante
            // 
            this.labelRestaurante.AutoSize = true;
            this.labelRestaurante.Location = new System.Drawing.Point(167, 198);
            this.labelRestaurante.Name = "labelRestaurante";
            this.labelRestaurante.Size = new System.Drawing.Size(68, 13);
            this.labelRestaurante.TabIndex = 17;
            this.labelRestaurante.Text = "Restaurante:";
            // 
            // checkBoxContemRestaurante
            // 
            this.checkBoxContemRestaurante.AutoSize = true;
            this.checkBoxContemRestaurante.Location = new System.Drawing.Point(15, 249);
            this.checkBoxContemRestaurante.Name = "checkBoxContemRestaurante";
            this.checkBoxContemRestaurante.Size = new System.Drawing.Size(144, 17);
            this.checkBoxContemRestaurante.TabIndex = 10;
            this.checkBoxContemRestaurante.Text = "Contém um restaurante ?";
            this.checkBoxContemRestaurante.UseVisualStyleBackColor = true;
            this.checkBoxContemRestaurante.CheckedChanged += new System.EventHandler(this.checkBoxContemRestaurante_CheckedChanged);
            // 
            // maskedTextBoxEndCepHotel
            // 
            this.maskedTextBoxEndCepHotel.Location = new System.Drawing.Point(233, 165);
            this.maskedTextBoxEndCepHotel.Mask = "00000-999";
            this.maskedTextBoxEndCepHotel.Name = "maskedTextBoxEndCepHotel";
            this.maskedTextBoxEndCepHotel.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxEndCepHotel.TabIndex = 8;
            // 
            // textBoxEndBairroHotel
            // 
            this.textBoxEndBairroHotel.Location = new System.Drawing.Point(127, 165);
            this.textBoxEndBairroHotel.Name = "textBoxEndBairroHotel";
            this.textBoxEndBairroHotel.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndBairroHotel.TabIndex = 7;
            // 
            // textBoxEndComplementoHotel
            // 
            this.textBoxEndComplementoHotel.Location = new System.Drawing.Point(15, 165);
            this.textBoxEndComplementoHotel.Name = "textBoxEndComplementoHotel";
            this.textBoxEndComplementoHotel.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndComplementoHotel.TabIndex = 6;
            // 
            // textBoxEndNumeroHotel
            // 
            this.textBoxEndNumeroHotel.Location = new System.Drawing.Point(233, 111);
            this.textBoxEndNumeroHotel.Name = "textBoxEndNumeroHotel";
            this.textBoxEndNumeroHotel.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndNumeroHotel.TabIndex = 5;
            this.textBoxEndNumeroHotel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEndNumeroHotel_KeyPress);
            // 
            // textBoxEndLogradouroHotel
            // 
            this.textBoxEndLogradouroHotel.Location = new System.Drawing.Point(15, 111);
            this.textBoxEndLogradouroHotel.Name = "textBoxEndLogradouroHotel";
            this.textBoxEndLogradouroHotel.Size = new System.Drawing.Size(212, 20);
            this.textBoxEndLogradouroHotel.TabIndex = 4;
            // 
            // comboBoxEndTipoHotel
            // 
            this.comboBoxEndTipoHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndTipoHotel.FormattingEnabled = true;
            this.comboBoxEndTipoHotel.Location = new System.Drawing.Point(15, 60);
            this.comboBoxEndTipoHotel.Name = "comboBoxEndTipoHotel";
            this.comboBoxEndTipoHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEndTipoHotel.TabIndex = 3;
            // 
            // buttonCadastrarHotel
            // 
            this.buttonCadastrarHotel.Location = new System.Drawing.Point(487, 313);
            this.buttonCadastrarHotel.Name = "buttonCadastrarHotel";
            this.buttonCadastrarHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarHotel.TabIndex = 12;
            this.buttonCadastrarHotel.Text = "Cadastrar";
            this.buttonCadastrarHotel.UseVisualStyleBackColor = true;
            this.buttonCadastrarHotel.Click += new System.EventHandler(this.buttonCadastrarHotel_Click);
            // 
            // buttonCancelarCadastroHotel
            // 
            this.buttonCancelarCadastroHotel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCadastroHotel.Location = new System.Drawing.Point(588, 313);
            this.buttonCancelarCadastroHotel.Name = "buttonCancelarCadastroHotel";
            this.buttonCancelarCadastroHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCadastroHotel.TabIndex = 13;
            this.buttonCancelarCadastroHotel.Text = "Cancelar";
            this.buttonCancelarCadastroHotel.UseVisualStyleBackColor = true;
            this.buttonCancelarCadastroHotel.Click += new System.EventHandler(this.buttonCancelarCadastroHotel_Click);
            // 
            // FormCadastrarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelarCadastroHotel;
            this.ClientSize = new System.Drawing.Size(692, 360);
            this.Controls.Add(this.buttonCancelarCadastroHotel);
            this.Controls.Add(this.buttonCadastrarHotel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastrarHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Hotel";
            this.Load += new System.EventHandler(this.FormCadastrarHotel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNomeHotel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxContatoHotel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxEndTipoHotel;
        private System.Windows.Forms.TextBox textBoxEndLogradouroHotel;
        private System.Windows.Forms.TextBox textBoxEndNumeroHotel;
        private System.Windows.Forms.TextBox textBoxEndComplementoHotel;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxEndCepHotel;
        private System.Windows.Forms.TextBox textBoxEndBairroHotel;
        private System.Windows.Forms.ComboBox comboBoxEndCidadeHotel;
        private System.Windows.Forms.ComboBox comboBoxCategoriaHotel;
        private System.Windows.Forms.Button buttonCadastrarHotel;
        private System.Windows.Forms.Button buttonCancelarCadastroHotel;
        private System.Windows.Forms.ComboBox comboBoxIdRestauranteHotel;
        private System.Windows.Forms.Label labelRestaurante;
        private System.Windows.Forms.CheckBox checkBoxContemRestaurante;
    }
}