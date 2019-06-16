using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDTur.Forms
{
    public partial class FormUserLogin : Form
    {
        public FormUserLogin()
        {
            InitializeComponent();
        }

        /*
         * TODO:
         * Verify wich kind o user it is
         */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Classes.Usuario user = new Classes.Usuario(0, textBoxUser.Text, textBoxPassword.Text, 0);
                if (user.Autenticate())
                {
                    Forms.FormMain nextScreen = new Forms.FormMain(user.AcessLevel);
                    this.Visible = false;
                    nextScreen.ShowDialog();
                    this.Close();
                }
                else
                {
                    //Usuario não foi atenticado
                    throw new InvalidLoginException("invalid combination of user and password");
                }
            }
            catch (MySqlException ex)
            {
                //Tratamento de Exeções do MySQL
                MessageBox.Show("Ocorreu um erro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
            }
            catch (InvalidLoginException) {
                //Callback caso usuario não tenha sido atenticado
                MessageBox.Show("Usuário ou Senha invalidos\n Tente Novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }


    //Implementação de uma Exceção customizada C#
    public class InvalidLoginException : Exception {
        public InvalidLoginException() : base() { }
        public InvalidLoginException(string message) : base(message) { }
        public InvalidLoginException(string message, System.Exception inner) : base(message, inner) { }
    }
}


