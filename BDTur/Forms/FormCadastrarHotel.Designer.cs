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
            this.labelNomeHotel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNomeHotel
            // 
            this.labelNomeHotel.AutoSize = true;
            this.labelNomeHotel.Location = new System.Drawing.Point(56, 81);
            this.labelNomeHotel.Name = "labelNomeHotel";
            this.labelNomeHotel.Size = new System.Drawing.Size(35, 13);
            this.labelNomeHotel.TabIndex = 0;
            this.labelNomeHotel.Text = "Nome";
            // 
            // FormCadastrarHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelNomeHotel);
            this.Name = "FormCadastrarHotel";
            this.Text = "FormCadastrarHotel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNomeHotel;
    }
}