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
    public partial class FormCadastrarCidade : Form
    {
        Classes.DAL adapter = new Classes.DAL();


        public FormCadastrarCidade()
        {
            InitializeComponent();
        }

        private void buttonCadastrarCidade_Click(object sender, EventArgs e)
        {
            try
            {
                string cidadenome = textBoxNomeCidade.Text;
                string cidadeestado = textBoxEstadoCidade.Text;
                string populacao = textBoxPopulacaoCidade.Text;
                Classes.Cidade c = new Classes.Cidade(0, cidadenome, cidadeestado, populacao);
                if (adapter.adicionarCidade(c))
                {
                    MessageBox.Show("Adicionado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPopulacaoCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonCancelarCidade_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
