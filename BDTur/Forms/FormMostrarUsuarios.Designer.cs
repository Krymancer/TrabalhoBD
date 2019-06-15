namespace BDTur.Forms
{
    partial class FormMostrarUsuarios
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
            this.dataGridViewUsuario = new System.Windows.Forms.DataGridView();
            this.groupBoxClassificaoHotel = new System.Windows.Forms.GroupBox();
            this.checkBox5StarHotel = new System.Windows.Forms.CheckBox();
            this.checkBox4StarHotel = new System.Windows.Forms.CheckBox();
            this.checkBox3StarHotel = new System.Windows.Forms.CheckBox();
            this.groupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).BeginInit();
            this.groupBoxClassificaoHotel.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsuario
            // 
            this.dataGridViewUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuario.Location = new System.Drawing.Point(12, 19);
            this.dataGridViewUsuario.Name = "dataGridViewUsuario";
            this.dataGridViewUsuario.Size = new System.Drawing.Size(609, 309);
            this.dataGridViewUsuario.TabIndex = 0;
            // 
            // groupBoxClassificaoHotel
            // 
            this.groupBoxClassificaoHotel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClassificaoHotel.Controls.Add(this.checkBox3StarHotel);
            this.groupBoxClassificaoHotel.Controls.Add(this.checkBox5StarHotel);
            this.groupBoxClassificaoHotel.Controls.Add(this.checkBox4StarHotel);
            this.groupBoxClassificaoHotel.Location = new System.Drawing.Point(638, 19);
            this.groupBoxClassificaoHotel.Name = "groupBoxClassificaoHotel";
            this.groupBoxClassificaoHotel.Size = new System.Drawing.Size(120, 88);
            this.groupBoxClassificaoHotel.TabIndex = 28;
            this.groupBoxClassificaoHotel.TabStop = false;
            this.groupBoxClassificaoHotel.Text = "Nível de acesso";
            // 
            // checkBox5StarHotel
            // 
            this.checkBox5StarHotel.AutoSize = true;
            this.checkBox5StarHotel.Checked = true;
            this.checkBox5StarHotel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5StarHotel.Location = new System.Drawing.Point(10, 19);
            this.checkBox5StarHotel.Name = "checkBox5StarHotel";
            this.checkBox5StarHotel.Size = new System.Drawing.Size(87, 17);
            this.checkBox5StarHotel.TabIndex = 0;
            this.checkBox5StarHotel.Text = "Admnistrador";
            this.checkBox5StarHotel.UseVisualStyleBackColor = true;
            // 
            // checkBox4StarHotel
            // 
            this.checkBox4StarHotel.AutoSize = true;
            this.checkBox4StarHotel.Checked = true;
            this.checkBox4StarHotel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4StarHotel.Location = new System.Drawing.Point(10, 42);
            this.checkBox4StarHotel.Name = "checkBox4StarHotel";
            this.checkBox4StarHotel.Size = new System.Drawing.Size(64, 17);
            this.checkBox4StarHotel.TabIndex = 1;
            this.checkBox4StarHotel.Text = "Gerente";
            this.checkBox4StarHotel.UseVisualStyleBackColor = true;
            // 
            // checkBox3StarHotel
            // 
            this.checkBox3StarHotel.AutoSize = true;
            this.checkBox3StarHotel.Checked = true;
            this.checkBox3StarHotel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3StarHotel.Location = new System.Drawing.Point(10, 65);
            this.checkBox3StarHotel.Name = "checkBox3StarHotel";
            this.checkBox3StarHotel.Size = new System.Drawing.Size(62, 17);
            this.checkBox3StarHotel.TabIndex = 2;
            this.checkBox3StarHotel.Text = "Usuário";
            this.checkBox3StarHotel.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBoxClassificaoHotel);
            this.groupBox.Controls.Add(this.dataGridViewUsuario);
            this.groupBox.Location = new System.Drawing.Point(-6, 7);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(763, 349);
            this.groupBox.TabIndex = 29;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Usuários";
            // 
            // FormMostrarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 410);
            this.Controls.Add(this.groupBox);
            this.Name = "FormMostrarUsuarios";
            this.Text = "FormMostrarUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).EndInit();
            this.groupBoxClassificaoHotel.ResumeLayout(false);
            this.groupBoxClassificaoHotel.PerformLayout();
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsuario;
        private System.Windows.Forms.GroupBox groupBoxClassificaoHotel;
        private System.Windows.Forms.CheckBox checkBox5StarHotel;
        private System.Windows.Forms.CheckBox checkBox4StarHotel;
        private System.Windows.Forms.CheckBox checkBox3StarHotel;
        private System.Windows.Forms.GroupBox groupBox;
    }
}