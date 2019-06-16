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
    public partial class FormDetalhesUsuario : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormDetalhesUsuario(int id)
        {
            InitializeComponent();

            ComboboxItem admin = new ComboboxItem();
            admin.Text = "Administrador";
            admin.Value = 1;
            ComboboxItem gerente = new ComboboxItem();
            gerente.Text = "Gerente";
            gerente.Value = 2;
            ComboboxItem user = new ComboboxItem();
            user.Text = "Usuario Comum";
            user.Value = 3;

            comboBoxAcessLevel.Items.Add(admin);
            comboBoxAcessLevel.Items.Add(gerente);
            comboBoxAcessLevel.Items.Add(user);

            comboBoxAcessLevel.DisplayMember = "Text";


            getDetails(id);
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.usuarioReader(id);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxID.Text = reader.GetInt32(0).ToString();
                    textBoxUsername.Text = reader.GetString(1);
                    textBoxPasswd.Text = reader.GetString(2);
                    comboBoxAcessLevel.SelectedItem = comboBoxAcessLevel.Items[int.Parse(reader.GetString(3))-1];
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxID.Text);
            adapter.removerUsuario(id);
            this.Close();
            
        }
    }
}
