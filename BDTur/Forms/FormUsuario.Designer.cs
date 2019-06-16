namespace BDTur.Forms
{
    partial class FormUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsuario));
            this.dataGridViewUsuario = new System.Windows.Forms.DataGridView();
            this.groupBoxNivelDeAcessoUsuario = new System.Windows.Forms.GroupBox();
            this.checkBoxNivelUsuario = new System.Windows.Forms.CheckBox();
            this.checkBoxNivelAdm = new System.Windows.Forms.CheckBox();
            this.checkBoxNivelGerente = new System.Windows.Forms.CheckBox();
            this.groupBoxUsuarios = new System.Windows.Forms.GroupBox();
            this.buttonVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).BeginInit();
            this.groupBoxNivelDeAcessoUsuario.SuspendLayout();
            this.groupBoxUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsuario
            // 
            this.dataGridViewUsuario.AllowUserToAddRows = false;
            this.dataGridViewUsuario.AllowUserToDeleteRows = false;
            this.dataGridViewUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewUsuario.Location = new System.Drawing.Point(12, 19);
            this.dataGridViewUsuario.Name = "dataGridViewUsuario";
            this.dataGridViewUsuario.Size = new System.Drawing.Size(437, 309);
            this.dataGridViewUsuario.TabIndex = 0;
            this.dataGridViewUsuario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuario_CellDoubleClick);
            // 
            // groupBoxNivelDeAcessoUsuario
            // 
            this.groupBoxNivelDeAcessoUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxNivelDeAcessoUsuario.Controls.Add(this.checkBoxNivelUsuario);
            this.groupBoxNivelDeAcessoUsuario.Controls.Add(this.checkBoxNivelAdm);
            this.groupBoxNivelDeAcessoUsuario.Controls.Add(this.checkBoxNivelGerente);
            this.groupBoxNivelDeAcessoUsuario.Location = new System.Drawing.Point(455, 19);
            this.groupBoxNivelDeAcessoUsuario.Name = "groupBoxNivelDeAcessoUsuario";
            this.groupBoxNivelDeAcessoUsuario.Size = new System.Drawing.Size(120, 88);
            this.groupBoxNivelDeAcessoUsuario.TabIndex = 28;
            this.groupBoxNivelDeAcessoUsuario.TabStop = false;
            this.groupBoxNivelDeAcessoUsuario.Text = "Nível de acesso";
            // 
            // checkBoxNivelUsuario
            // 
            this.checkBoxNivelUsuario.AutoSize = true;
            this.checkBoxNivelUsuario.Checked = true;
            this.checkBoxNivelUsuario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNivelUsuario.Location = new System.Drawing.Point(10, 65);
            this.checkBoxNivelUsuario.Name = "checkBoxNivelUsuario";
            this.checkBoxNivelUsuario.Size = new System.Drawing.Size(62, 17);
            this.checkBoxNivelUsuario.TabIndex = 2;
            this.checkBoxNivelUsuario.Text = "Usuário";
            this.checkBoxNivelUsuario.UseVisualStyleBackColor = true;
            this.checkBoxNivelUsuario.CheckedChanged += new System.EventHandler(this.checkBoxNivelUsuario_CheckedChanged);
            // 
            // checkBoxNivelAdm
            // 
            this.checkBoxNivelAdm.AutoSize = true;
            this.checkBoxNivelAdm.Checked = true;
            this.checkBoxNivelAdm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNivelAdm.Location = new System.Drawing.Point(10, 19);
            this.checkBoxNivelAdm.Name = "checkBoxNivelAdm";
            this.checkBoxNivelAdm.Size = new System.Drawing.Size(87, 17);
            this.checkBoxNivelAdm.TabIndex = 0;
            this.checkBoxNivelAdm.Text = "Admnistrador";
            this.checkBoxNivelAdm.UseVisualStyleBackColor = true;
            this.checkBoxNivelAdm.CheckedChanged += new System.EventHandler(this.checkBoxNivelAdm_CheckedChanged);
            // 
            // checkBoxNivelGerente
            // 
            this.checkBoxNivelGerente.AutoSize = true;
            this.checkBoxNivelGerente.Checked = true;
            this.checkBoxNivelGerente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNivelGerente.Location = new System.Drawing.Point(10, 42);
            this.checkBoxNivelGerente.Name = "checkBoxNivelGerente";
            this.checkBoxNivelGerente.Size = new System.Drawing.Size(64, 17);
            this.checkBoxNivelGerente.TabIndex = 1;
            this.checkBoxNivelGerente.Text = "Gerente";
            this.checkBoxNivelGerente.UseVisualStyleBackColor = true;
            this.checkBoxNivelGerente.CheckedChanged += new System.EventHandler(this.checkBoxNivelGerente_CheckedChanged);
            // 
            // groupBoxUsuarios
            // 
            this.groupBoxUsuarios.Controls.Add(this.groupBoxNivelDeAcessoUsuario);
            this.groupBoxUsuarios.Controls.Add(this.dataGridViewUsuario);
            this.groupBoxUsuarios.Location = new System.Drawing.Point(-6, 7);
            this.groupBoxUsuarios.Name = "groupBoxUsuarios";
            this.groupBoxUsuarios.Size = new System.Drawing.Size(581, 349);
            this.groupBoxUsuarios.TabIndex = 29;
            this.groupBoxUsuarios.TabStop = false;
            this.groupBoxUsuarios.Text = "Usuários";
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonVoltar.Location = new System.Drawing.Point(500, 362);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(75, 23);
            this.buttonVoltar.TabIndex = 30;
            this.buttonVoltar.Text = "Voltar";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.buttonVoltar_Click);
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonVoltar;
            this.ClientSize = new System.Drawing.Size(581, 387);
            this.Controls.Add(this.buttonVoltar);
            this.Controls.Add(this.groupBoxUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuários";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).EndInit();
            this.groupBoxNivelDeAcessoUsuario.ResumeLayout(false);
            this.groupBoxNivelDeAcessoUsuario.PerformLayout();
            this.groupBoxUsuarios.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsuario;
        private System.Windows.Forms.GroupBox groupBoxNivelDeAcessoUsuario;
        private System.Windows.Forms.CheckBox checkBoxNivelAdm;
        private System.Windows.Forms.CheckBox checkBoxNivelGerente;
        private System.Windows.Forms.CheckBox checkBoxNivelUsuario;
        private System.Windows.Forms.GroupBox groupBoxUsuarios;
        private System.Windows.Forms.Button buttonVoltar;
    }
}