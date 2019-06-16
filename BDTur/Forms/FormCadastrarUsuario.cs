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
    public partial class FormCadastrarUsuario : Form
    {

        Classes.DAL adapter = new Classes.DAL();
        public FormCadastrarUsuario()
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

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string username = textBoxUsername.Text;
                string password = textBoxPasswd.Text;
                int acessLevel = ((comboBoxAcessLevel.SelectedItem) as ComboboxItem).GetItemValue();
                Classes.Usuario u = new Classes.Usuario(0,username,password,acessLevel);
                if (adapter.adicionarUsuario(u))
                {
                    MessageBox.Show("Adicionado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public int GetItemValue()
        {
            return Value;
        }
    }
}
