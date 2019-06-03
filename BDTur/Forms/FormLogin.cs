using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BDTur.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Program.databaseUser = textBoxUser.Text;
            Program.databasePassword = textBoxPassword.Text;
            
            Classes.Connection connection = new Classes.Connection(Program.databaseUser, Program.databasePassword);
            MySqlConnection c = connection.getConnection();
            try
            {
                c.Open();
                Forms.FormUserLogin nextScreen = new Forms.FormUserLogin();
                this.Visible = false;
                nextScreen.ShowDialog();
                this.Close();
            }
            catch (MySqlException ex)
            {

                if(ex.Code == 0x0)
                MessageBox.Show("Ocorreu um erro \n Usuário ou Senha incoretos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                MessageBox.Show("Ocorreu um erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Console.WriteLine(ex); // Provavélmente o Usuario e/ou a senha estão incorretos
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
