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
    public partial class FormDetalhesMuseu : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        DataTable fundadores = new DataTable();
        DataTable selecionados = new DataTable();
        bool editar = false;
        public FormDetalhesMuseu(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxEndTipoMuseu.Items.Add("Rua");
            comboBoxEndTipoMuseu.Items.Add("Avenida");
            comboBoxEndTipoMuseu.Items.Add("Travessa");
            comboBoxEndTipoMuseu.Items.Add("Praça");
            comboBoxEndTipoMuseu.Items.Add("Estação");
            comboBoxEndTipoMuseu.Items.Add("Alameda");
            comboBoxEndTipoMuseu.Items.Add("Balneário");
            comboBoxEndTipoMuseu.Items.Add("Beco");
            comboBoxEndTipoMuseu.Items.Add("Viela");

            addDataTablesColumns();
            getFundadoresList();
            getMuseuFundadores(id);
            populateListView();

            getDetails(id);

            if (Program.AcessLevel != 1)
            {
                buttonEditar.Enabled = false;
                buttonExcluir.Enabled = false;
            }
        }

        private void populateComboBoxes()
        {
            populateCidadesComboBox();
        }

        private void populateCidadesComboBox()
        {

            MySqlDataAdapter da = adapter.cidadeAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                DataRow dr;
                dr = dt.NewRow();
                dr.ItemArray = new object[2] { 0, "Selecione..." };
                dt.Rows.InsertAt(dr, 0);


                //comboBoxCidade.Items.Add("Selecione...");
                comboBoxEndCidadeMuseu.ValueMember = "idCidade";
                comboBoxEndCidadeMuseu.DisplayMember = "nome";
                comboBoxEndCidadeMuseu.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.museuDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdMuseu.Text = reader.GetString(14);
                    textBoxNomeMuseu.Text = reader.GetString(2);
                    maskedTextBoxContatoMuseu.Text = reader.GetString(3);
                    textBoxDescricaoMuseu.Text = reader.GetString(4);
                    textBoxEndLogradouroMuseu.Text = reader.GetString(5);
                    int index = comboBoxEndTipoMuseu.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoMuseu.SelectedItem = comboBoxEndTipoMuseu.Items[index];
                    textBoxEndNumeroMuseu.Text = reader.GetString(7);
                    try
                    {
                        textBoxEndComplementoMuseu.Text = reader.GetString(8);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoMuseu.Text = "";
                    }
                    textBoxEndBairroMuseu.Text = reader.GetString(9);
                    maskedTextBoxEndCepMuseu.Text = reader.GetString(10);
                    comboBoxEndCidadeMuseu.SelectedValue = reader.GetInt32(11);
                    monthCalendarFundacaoMuseu.SetDate(reader.GetDateTime(15));
                    maskedTextBoxValorEntradaMuseu.Text = reader.GetString(16);
                    textBoxNumeroDeSalasMuseu.Text = reader.GetString(17);

                }
            }
        }        

        private void addDataTablesColumns()
        {
            fundadores.Columns.Add("idFundador");
            fundadores.Columns.Add("nomeFundador");
            selecionados.Columns.Add("idFundador");
            selecionados.Columns.Add("nomeFundador");
        }

        private void populateListView()
        {
            //listBoxFundadoresDisponiveis.DataSource = fundadores;
            listBoxFundadoresSelecionados.DataSource = selecionados;
        }

        private void getFundadoresList()
        {
            MySqlDataReader dr = adapter.fundadoresReader();

            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    DataRow dataRow;
                    dataRow = fundadores.NewRow();
                    dataRow.ItemArray = new object[2] { dr.GetInt32(0), dr.GetString(1) };
                    fundadores.Rows.InsertAt(dataRow, i);
                    i++;
                }
            }

        }

        private void getMuseuFundadores(int id)
        {
            MySqlDataReader reader = adapter.museufundadoresReader(id);

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    string a = reader.GetString(1);

                    foreach (DataRow dr in fundadores.Rows)
                    {
                        if (dr["nomeFundador"].Equals(a))
                        {
                            selecionados.ImportRow(dr);
                            fundadores.Rows.Remove(dr);
                            break;
                        }
                    }
                }
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                groupBoxDados.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                groupBoxDados.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                textBoxIdMuseu.Enabled = false;
                
                buttonEditar.Text = "Salvar";
                editar = !editar;
            }
            else
            {
                bool sucess = true;
                try
                {
                    string museuNome = textBoxNomeMuseu.Text;
                    maskedTextBoxValorEntradaMuseu.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    float museuPreco = float.Parse(maskedTextBoxValorEntradaMuseu.Text) / 100;
                    maskedTextBoxValorEntradaMuseu.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    string museuNumSalas = textBoxNumeroDeSalasMuseu.Text;
                    DateTime museuFund = monthCalendarFundacaoMuseu.SelectionStart;
                    maskedTextBoxContatoMuseu.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string contato = maskedTextBoxContatoMuseu.Text;
                    maskedTextBoxContatoMuseu.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    string descricao = textBoxDescricaoMuseu.Text;

                    string endTip = comboBoxEndTipoMuseu.SelectedItem.ToString();
                    string endLog = textBoxEndLogradouroMuseu.Text;
                    string endNum = textBoxEndNumeroMuseu.Text;
                    string endComp;
                    try
                    {
                        endComp = textBoxEndComplementoMuseu.Text;
                    }
                    catch (NullReferenceException)
                    {
                        endComp = "";
                    }
                    string endBairro = textBoxEndBairroMuseu.Text;
                    maskedTextBoxEndCepMuseu.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string endCep = maskedTextBoxEndCepMuseu.Text;
                    maskedTextBoxEndCepMuseu.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    int cidade = int.Parse(comboBoxEndCidadeMuseu.SelectedValue.ToString());
                    if (cidade == 0) throw new InvalidSelectValue("CidadeID must be different of 0");
                    int id = int.Parse(textBoxIdMuseu.Text);
                    Classes.Museu m = new Classes.Museu(id, museuFund, museuPreco, museuNumSalas, null, 0, "Museu", museuNome, contato, descricao, endTip, endLog, endNum, endComp, endBairro, endCep, cidade);
                    if (!adapter.atualizarMuseu(m))
                    {
                        sucess = false;
                        //MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (sucess)
                    {
                        MessageBox.Show("Atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
                catch (FormatException)
                {
                    MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBoxEndNumeroMuseu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (adapter.removerMuseu(int.Parse(textBoxIdMuseu.Text)))
            {
                MessageBox.Show("Removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelarCadastroMuseu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
