namespace BDTur.Forms
{
    partial class FormDetalhesHotel
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label11;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetalhesHotel));
            this.buttonCancelarCadastroHotel = new System.Windows.Forms.Button();
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
            this.comboBoxCategoriaHotel = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxContatoHotel = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxDados = new System.Windows.Forms.GroupBox();
            this.dataGridViewHotelQuarto = new System.Windows.Forms.DataGridView();
            this.textBoxIdHotel = new System.Windows.Forms.TextBox();
            this.textBoxNomeHotel = new System.Windows.Forms.TextBox();
            this.groupBoxEndereço = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAddQuartos = new System.Windows.Forms.Button();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            this.groupBoxDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHotelQuarto)).BeginInit();
            this.groupBoxEndereço.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(15, 181);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(43, 13);
            label10.TabIndex = 11;
            label10.Text = "Cidade:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(233, 131);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(29, 13);
            label9.TabIndex = 8;
            label9.Text = "Cep:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(127, 131);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(37, 13);
            label8.TabIndex = 7;
            label8.Text = "Bairro:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(15, 27);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(31, 13);
            label4.TabIndex = 3;
            label4.Text = "Tipo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(15, 78);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(64, 13);
            label5.TabIndex = 4;
            label5.Text = "Logradouro:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(15, 131);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(74, 13);
            label7.TabIndex = 6;
            label7.Text = "Complemento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(233, 78);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(47, 13);
            label6.TabIndex = 5;
            label6.Text = "Número:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(81, 13);
            label1.TabIndex = 0;
            label1.Text = "Nome do Hotel:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(220, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(55, 13);
            label2.TabIndex = 1;
            label2.Text = "Categoria:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(220, 68);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(47, 13);
            label3.TabIndex = 2;
            label3.Text = "Contato:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 27);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(21, 13);
            label11.TabIndex = 4;
            label11.Text = "ID:";
            // 
            // buttonCancelarCadastroHotel
            // 
            this.buttonCancelarCadastroHotel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarCadastroHotel.Location = new System.Drawing.Point(691, 298);
            this.buttonCancelarCadastroHotel.Name = "buttonCancelarCadastroHotel";
            this.buttonCancelarCadastroHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarCadastroHotel.TabIndex = 17;
            this.buttonCancelarCadastroHotel.Text = "Cancelar";
            this.buttonCancelarCadastroHotel.UseVisualStyleBackColor = true;
            this.buttonCancelarCadastroHotel.Click += new System.EventHandler(this.buttonCancelarCadastroHotel_Click);
            // 
            // comboBoxIdRestauranteHotel
            // 
            this.comboBoxIdRestauranteHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIdRestauranteHotel.Enabled = false;
            this.comboBoxIdRestauranteHotel.FormattingEnabled = true;
            this.comboBoxIdRestauranteHotel.Location = new System.Drawing.Point(173, 197);
            this.comboBoxIdRestauranteHotel.Name = "comboBoxIdRestauranteHotel";
            this.comboBoxIdRestauranteHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxIdRestauranteHotel.TabIndex = 13;
            // 
            // comboBoxEndCidadeHotel
            // 
            this.comboBoxEndCidadeHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndCidadeHotel.Enabled = false;
            this.comboBoxEndCidadeHotel.FormattingEnabled = true;
            this.comboBoxEndCidadeHotel.Location = new System.Drawing.Point(18, 197);
            this.comboBoxEndCidadeHotel.Name = "comboBoxEndCidadeHotel";
            this.comboBoxEndCidadeHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEndCidadeHotel.TabIndex = 11;
            // 
            // labelRestaurante
            // 
            this.labelRestaurante.AutoSize = true;
            this.labelRestaurante.Location = new System.Drawing.Point(170, 181);
            this.labelRestaurante.Name = "labelRestaurante";
            this.labelRestaurante.Size = new System.Drawing.Size(68, 13);
            this.labelRestaurante.TabIndex = 17;
            this.labelRestaurante.Text = "Restaurante:";
            // 
            // checkBoxContemRestaurante
            // 
            this.checkBoxContemRestaurante.AutoSize = true;
            this.checkBoxContemRestaurante.Enabled = false;
            this.checkBoxContemRestaurante.Location = new System.Drawing.Point(18, 232);
            this.checkBoxContemRestaurante.Name = "checkBoxContemRestaurante";
            this.checkBoxContemRestaurante.Size = new System.Drawing.Size(144, 17);
            this.checkBoxContemRestaurante.TabIndex = 12;
            this.checkBoxContemRestaurante.Text = "Contém um restaurante ?";
            this.checkBoxContemRestaurante.UseVisualStyleBackColor = true;
            this.checkBoxContemRestaurante.CheckedChanged += new System.EventHandler(this.checkBoxContemRestaurante_CheckedChanged);
            // 
            // maskedTextBoxEndCepHotel
            // 
            this.maskedTextBoxEndCepHotel.Enabled = false;
            this.maskedTextBoxEndCepHotel.Location = new System.Drawing.Point(236, 148);
            this.maskedTextBoxEndCepHotel.Mask = "00000-999";
            this.maskedTextBoxEndCepHotel.Name = "maskedTextBoxEndCepHotel";
            this.maskedTextBoxEndCepHotel.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxEndCepHotel.TabIndex = 10;
            // 
            // textBoxEndBairroHotel
            // 
            this.textBoxEndBairroHotel.Enabled = false;
            this.textBoxEndBairroHotel.Location = new System.Drawing.Point(130, 148);
            this.textBoxEndBairroHotel.Name = "textBoxEndBairroHotel";
            this.textBoxEndBairroHotel.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndBairroHotel.TabIndex = 9;
            // 
            // textBoxEndComplementoHotel
            // 
            this.textBoxEndComplementoHotel.Enabled = false;
            this.textBoxEndComplementoHotel.Location = new System.Drawing.Point(18, 148);
            this.textBoxEndComplementoHotel.Name = "textBoxEndComplementoHotel";
            this.textBoxEndComplementoHotel.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndComplementoHotel.TabIndex = 8;
            // 
            // textBoxEndNumeroHotel
            // 
            this.textBoxEndNumeroHotel.Enabled = false;
            this.textBoxEndNumeroHotel.Location = new System.Drawing.Point(236, 94);
            this.textBoxEndNumeroHotel.Name = "textBoxEndNumeroHotel";
            this.textBoxEndNumeroHotel.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndNumeroHotel.TabIndex = 7;
            this.textBoxEndNumeroHotel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEndNumeroHotel_KeyPress);
            // 
            // textBoxEndLogradouroHotel
            // 
            this.textBoxEndLogradouroHotel.Enabled = false;
            this.textBoxEndLogradouroHotel.Location = new System.Drawing.Point(18, 94);
            this.textBoxEndLogradouroHotel.Name = "textBoxEndLogradouroHotel";
            this.textBoxEndLogradouroHotel.Size = new System.Drawing.Size(212, 20);
            this.textBoxEndLogradouroHotel.TabIndex = 6;
            // 
            // comboBoxEndTipoHotel
            // 
            this.comboBoxEndTipoHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEndTipoHotel.Enabled = false;
            this.comboBoxEndTipoHotel.FormattingEnabled = true;
            this.comboBoxEndTipoHotel.Location = new System.Drawing.Point(18, 43);
            this.comboBoxEndTipoHotel.Name = "comboBoxEndTipoHotel";
            this.comboBoxEndTipoHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEndTipoHotel.TabIndex = 5;
            // 
            // buttonCadastrarHotel
            // 
            this.buttonCadastrarHotel.Location = new System.Drawing.Point(590, 298);
            this.buttonCadastrarHotel.Name = "buttonCadastrarHotel";
            this.buttonCadastrarHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarHotel.TabIndex = 16;
            this.buttonCadastrarHotel.Text = "Excluir";
            this.buttonCadastrarHotel.UseVisualStyleBackColor = true;
            this.buttonCadastrarHotel.Click += new System.EventHandler(this.buttonCadastrarHotel_Click);
            // 
            // comboBoxCategoriaHotel
            // 
            this.comboBoxCategoriaHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategoriaHotel.Enabled = false;
            this.comboBoxCategoriaHotel.FormattingEnabled = true;
            this.comboBoxCategoriaHotel.Items.AddRange(new object[] {
            "1 Estrela",
            "2 Estrelas",
            "3 Estrelas",
            "4 Estrelas",
            "5 Estrelas"});
            this.comboBoxCategoriaHotel.Location = new System.Drawing.Point(223, 42);
            this.comboBoxCategoriaHotel.Name = "comboBoxCategoriaHotel";
            this.comboBoxCategoriaHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCategoriaHotel.TabIndex = 1;
            // 
            // maskedTextBoxContatoHotel
            // 
            this.maskedTextBoxContatoHotel.Enabled = false;
            this.maskedTextBoxContatoHotel.Location = new System.Drawing.Point(223, 85);
            this.maskedTextBoxContatoHotel.Mask = "(99) 00000-0000";
            this.maskedTextBoxContatoHotel.Name = "maskedTextBoxContatoHotel";
            this.maskedTextBoxContatoHotel.Size = new System.Drawing.Size(121, 20);
            this.maskedTextBoxContatoHotel.TabIndex = 3;
            // 
            // groupBoxDados
            // 
            this.groupBoxDados.Controls.Add(this.dataGridViewHotelQuarto);
            this.groupBoxDados.Controls.Add(this.textBoxIdHotel);
            this.groupBoxDados.Controls.Add(label11);
            this.groupBoxDados.Controls.Add(this.comboBoxCategoriaHotel);
            this.groupBoxDados.Controls.Add(this.maskedTextBoxContatoHotel);
            this.groupBoxDados.Controls.Add(this.textBoxNomeHotel);
            this.groupBoxDados.Controls.Add(label1);
            this.groupBoxDados.Controls.Add(label2);
            this.groupBoxDados.Controls.Add(label3);
            this.groupBoxDados.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDados.Name = "groupBoxDados";
            this.groupBoxDados.Size = new System.Drawing.Size(387, 280);
            this.groupBoxDados.TabIndex = 14;
            this.groupBoxDados.TabStop = false;
            this.groupBoxDados.Text = "Dados";
            // 
            // dataGridViewHotelQuarto
            // 
            this.dataGridViewHotelQuarto.AllowUserToAddRows = false;
            this.dataGridViewHotelQuarto.AllowUserToDeleteRows = false;
            this.dataGridViewHotelQuarto.AllowUserToOrderColumns = true;
            this.dataGridViewHotelQuarto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHotelQuarto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHotelQuarto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewHotelQuarto.Location = new System.Drawing.Point(9, 122);
            this.dataGridViewHotelQuarto.Name = "dataGridViewHotelQuarto";
            this.dataGridViewHotelQuarto.Size = new System.Drawing.Size(372, 152);
            this.dataGridViewHotelQuarto.TabIndex = 4;
            // 
            // textBoxIdHotel
            // 
            this.textBoxIdHotel.Enabled = false;
            this.textBoxIdHotel.Location = new System.Drawing.Point(9, 44);
            this.textBoxIdHotel.Name = "textBoxIdHotel";
            this.textBoxIdHotel.Size = new System.Drawing.Size(179, 20);
            this.textBoxIdHotel.TabIndex = 0;
            // 
            // textBoxNomeHotel
            // 
            this.textBoxNomeHotel.Enabled = false;
            this.textBoxNomeHotel.Location = new System.Drawing.Point(9, 84);
            this.textBoxNomeHotel.Name = "textBoxNomeHotel";
            this.textBoxNomeHotel.Size = new System.Drawing.Size(179, 20);
            this.textBoxNomeHotel.TabIndex = 2;
            // 
            // groupBoxEndereço
            // 
            this.groupBoxEndereço.Controls.Add(this.comboBoxIdRestauranteHotel);
            this.groupBoxEndereço.Controls.Add(this.comboBoxEndCidadeHotel);
            this.groupBoxEndereço.Controls.Add(this.labelRestaurante);
            this.groupBoxEndereço.Controls.Add(label10);
            this.groupBoxEndereço.Controls.Add(this.checkBoxContemRestaurante);
            this.groupBoxEndereço.Controls.Add(this.maskedTextBoxEndCepHotel);
            this.groupBoxEndereço.Controls.Add(this.textBoxEndBairroHotel);
            this.groupBoxEndereço.Controls.Add(this.textBoxEndComplementoHotel);
            this.groupBoxEndereço.Controls.Add(this.textBoxEndNumeroHotel);
            this.groupBoxEndereço.Controls.Add(label9);
            this.groupBoxEndereço.Controls.Add(this.textBoxEndLogradouroHotel);
            this.groupBoxEndereço.Controls.Add(label8);
            this.groupBoxEndereço.Controls.Add(this.comboBoxEndTipoHotel);
            this.groupBoxEndereço.Controls.Add(label4);
            this.groupBoxEndereço.Controls.Add(label5);
            this.groupBoxEndereço.Controls.Add(label7);
            this.groupBoxEndereço.Controls.Add(label6);
            this.groupBoxEndereço.Location = new System.Drawing.Point(405, 12);
            this.groupBoxEndereço.Name = "groupBoxEndereço";
            this.groupBoxEndereço.Size = new System.Drawing.Size(360, 280);
            this.groupBoxEndereço.TabIndex = 15;
            this.groupBoxEndereço.TabStop = false;
            this.groupBoxEndereço.Text = "Endereço";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(490, 298);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Editar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonAddQuartos
            // 
            this.buttonAddQuartos.Location = new System.Drawing.Point(358, 298);
            this.buttonAddQuartos.Name = "buttonAddQuartos";
            this.buttonAddQuartos.Size = new System.Drawing.Size(106, 23);
            this.buttonAddQuartos.TabIndex = 14;
            this.buttonAddQuartos.Text = "Adicionar Quartos";
            this.buttonAddQuartos.UseVisualStyleBackColor = true;
            this.buttonAddQuartos.Click += new System.EventHandler(this.buttonAddQuartos_Click);
            // 
            // FormDetalhesHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelarCadastroHotel;
            this.ClientSize = new System.Drawing.Size(777, 328);
            this.Controls.Add(this.buttonAddQuartos);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCancelarCadastroHotel);
            this.Controls.Add(this.buttonCadastrarHotel);
            this.Controls.Add(this.groupBoxDados);
            this.Controls.Add(this.groupBoxEndereço);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDetalhesHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalhes Hotel";
            this.groupBoxDados.ResumeLayout(false);
            this.groupBoxDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHotelQuarto)).EndInit();
            this.groupBoxEndereço.ResumeLayout(false);
            this.groupBoxEndereço.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelarCadastroHotel;
        private System.Windows.Forms.ComboBox comboBoxIdRestauranteHotel;
        private System.Windows.Forms.ComboBox comboBoxEndCidadeHotel;
        private System.Windows.Forms.Label labelRestaurante;
        private System.Windows.Forms.CheckBox checkBoxContemRestaurante;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxEndCepHotel;
        private System.Windows.Forms.TextBox textBoxEndBairroHotel;
        private System.Windows.Forms.TextBox textBoxEndComplementoHotel;
        private System.Windows.Forms.TextBox textBoxEndNumeroHotel;
        private System.Windows.Forms.TextBox textBoxEndLogradouroHotel;
        private System.Windows.Forms.ComboBox comboBoxEndTipoHotel;
        private System.Windows.Forms.Button buttonCadastrarHotel;
        private System.Windows.Forms.ComboBox comboBoxCategoriaHotel;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxContatoHotel;
        private System.Windows.Forms.GroupBox groupBoxDados;
        private System.Windows.Forms.TextBox textBoxNomeHotel;
        private System.Windows.Forms.GroupBox groupBoxEndereço;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxIdHotel;
        private System.Windows.Forms.Button buttonAddQuartos;
        private System.Windows.Forms.DataGridView dataGridViewHotelQuarto;
    }
}