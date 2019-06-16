using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDTur.Forms
{
    public partial class FormCadastrarFundador : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormCadastrarFundador()
        {
            InitializeComponent();
        }

        private void buttonCadastrarFundador_Click(object sender, EventArgs e)
        {
            try
            {
                string fundNome = textBoxNomeFundador.Text;
                string fundPorf = textBoxAtividadeProfissionalFundador.Text;
                string fundNacio = textBoxNacionalidadeFundador.Text; 
                string fundNasc = (maskedTextBoxDataNascimentoFundador.Text);
                string fundMort = (maskedTextBoxDataMorteFundador.Text);
                DateTime fundNascDate = DateTime.ParseExact(fundNasc, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                DateTime fundMortDate;
                bool hasDead = false;
                try
                {
                    fundMortDate = DateTime.ParseExact(fundMort, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                    hasDead = true;
                }
                catch (FormatException)
                {
                    fundMortDate = DateTime.Now;
                    hasDead = false;

                }
                Classes.Fundador f = new Classes.Fundador(0,fundNome,fundPorf,fundNascDate,hasDead,fundMortDate,fundNacio,null);
                if (adapter.adicionarFundador(f))
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
            catch (FormatException)
            {
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelarCadastroFundador_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
