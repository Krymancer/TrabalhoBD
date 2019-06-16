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
    public partial class FormDetalhesCidade : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        bool editar = false;

        public FormDetalhesCidade(int id)
        {
            InitializeComponent();
            getDetails(id);

            if (Program.AcessLevel != 1)
            {
                buttonEditarCidade.Enabled = false;
                buttonExcluirCidade.Enabled = false;
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.cidadesReader(id);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxIdCidade.Text = reader.GetInt32(0).ToString();
                    textBoxNomeCidade.Text = reader.GetString(1);
                    textBoxEstadoCidade.Text = reader.GetString(2);
                    textBoxPopulacaoCidade.Text = reader.GetString(3);
                }
            }
        }

        private void buttonEditarCidade_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                groupBox1.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                textBoxIdCidade.Enabled = false;
                buttonEditarCidade.Text = "Salvar";
                editar = !editar;
            }
            else
            {
                try
                {
                    string cidadenome = textBoxNomeCidade.Text;
                    string cidadeestado = textBoxEstadoCidade.Text;
                    string populacao = textBoxPopulacaoCidade.Text;                    

                    int id = int.Parse(textBoxIdCidade.Text);
                    Classes.Cidade c = new Classes.Cidade(id, cidadenome, cidadeestado, populacao);
                    if (adapter.atualizarCidade(c))
                    {
                        MessageBox.Show("Atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        editar = !editar;
                        groupBox1.Controls.Cast<Control>().ToList()
                        .ForEach(x => { if (x.GetType() != typeof(Label)) x.Enabled = false; });
                        buttonEditarCidade.Text = "Editar";
                    }
                    else
                    {
                        MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (NullReferenceException)
                {
                    //Erro ao resgatar valores dos componentes
                    MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidSelectValue)
                {
                    //Tratar se usuario não tenha selecionado uma cidade valida
                    MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonExcluirCidade_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxIdCidade.Text);
            adapter.removerCidade(id);
            this.Close();
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
