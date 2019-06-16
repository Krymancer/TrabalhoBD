namespace BDTur.Forms
{
    partial class FormCadastrarQuartoHotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCadastrarQuartoHotel));
            this.buttonCancelarQuarto = new System.Windows.Forms.Button();
            this.buttonCadastrarQuarto = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxDiariaQuarto = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxTipoQuarto = new System.Windows.Forms.ComboBox();
            this.textBoxNumeroQuarto = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(124, 85);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(85, 13);
            label12.TabIndex = 16;
            label12.Text = "Diária do quarto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(118, 13);
            label1.TabIndex = 0;
            label1.Text = "Quantidade de quartos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 85);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 13);
            label3.TabIndex = 2;
            label3.Text = "Tipo de quarto:";
            // 
            // buttonCancelarQuarto
            // 
            this.buttonCancelarQuarto.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelarQuarto.Location = new System.Drawing.Point(185, 169);
            this.buttonCancelarQuarto.Name = "buttonCancelarQuarto";
            this.buttonCancelarQuarto.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelarQuarto.TabIndex = 4;
            this.buttonCancelarQuarto.Text = "Cancelar";
            this.buttonCancelarQuarto.UseVisualStyleBackColor = true;
            this.buttonCancelarQuarto.Click += new System.EventHandler(this.buttonCancelarQuarto_Click);
            // 
            // buttonCadastrarQuarto
            // 
            this.buttonCadastrarQuarto.Location = new System.Drawing.Point(104, 169);
            this.buttonCadastrarQuarto.Name = "buttonCadastrarQuarto";
            this.buttonCadastrarQuarto.Size = new System.Drawing.Size(75, 23);
            this.buttonCadastrarQuarto.TabIndex = 3;
            this.buttonCadastrarQuarto.Text = "Cadastrar";
            this.buttonCadastrarQuarto.UseVisualStyleBackColor = true;
            this.buttonCadastrarQuarto.Click += new System.EventHandler(this.buttonCadastrarQuarto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBoxDiariaQuarto);
            this.groupBox1.Controls.Add(this.comboBoxTipoQuarto);
            this.groupBox1.Controls.Add(label12);
            this.groupBox1.Controls.Add(this.textBoxNumeroQuarto);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 151);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados";
            // 
            // maskedTextBoxDiariaQuarto
            // 
            this.maskedTextBoxDiariaQuarto.Location = new System.Drawing.Point(127, 102);
            this.maskedTextBoxDiariaQuarto.Mask = "$#####.##";
            this.maskedTextBoxDiariaQuarto.Name = "maskedTextBoxDiariaQuarto";
            this.maskedTextBoxDiariaQuarto.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxDiariaQuarto.TabIndex = 2;
            this.maskedTextBoxDiariaQuarto.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // comboBoxTipoQuarto
            // 
            this.comboBoxTipoQuarto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoQuarto.FormattingEnabled = true;
            this.comboBoxTipoQuarto.Location = new System.Drawing.Point(9, 101);
            this.comboBoxTipoQuarto.Name = "comboBoxTipoQuarto";
            this.comboBoxTipoQuarto.Size = new System.Drawing.Size(98, 21);
            this.comboBoxTipoQuarto.TabIndex = 1;
            // 
            // textBoxNumeroQuarto
            // 
            this.textBoxNumeroQuarto.Location = new System.Drawing.Point(9, 45);
            this.textBoxNumeroQuarto.Name = "textBoxNumeroQuarto";
            this.textBoxNumeroQuarto.Size = new System.Drawing.Size(117, 20);
            this.textBoxNumeroQuarto.TabIndex = 0;
            this.textBoxNumeroQuarto.Text = " ";
            this.textBoxNumeroQuarto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroQuarto_KeyPress);
            // 
            // FormCadastrarQuartoHotel
            // 
            this.AcceptButton = this.buttonCadastrarQuarto;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelarQuarto;
            this.ClientSize = new System.Drawing.Size(267, 197);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCancelarQuarto);
            this.Controls.Add(this.buttonCadastrarQuarto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCadastrarQuartoHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Quarto";
            this.Load += new System.EventHandler(this.FormCadastrarQuartoHotel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancelarQuarto;
        private System.Windows.Forms.Button buttonCadastrarQuarto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNumeroQuarto;
        private System.Windows.Forms.ComboBox comboBoxTipoQuarto;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDiariaQuarto;
    }
}