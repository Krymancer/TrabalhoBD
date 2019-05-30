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
         * TODO: Validade User 
         * Verify wich kind o user it is
         */
        private void btnLogin_Click(object sender, EventArgs e)
        {

            //if user is valid then go to the main form
            Forms.FormMain nextScreen = new Forms.FormMain();
            this.Visible = false;
            nextScreen.ShowDialog();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
