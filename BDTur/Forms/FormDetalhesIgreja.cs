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
    public partial class FormDetalhesIgreja : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        DataTable fundadores = new DataTable();
        DataTable selecionados = new DataTable();
        bool editar = false;

        public FormDetalhesIgreja(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxEndTipoIgreja.Items.Add("Rua");
            comboBoxEndTipoIgreja.Items.Add("Avenida");
            comboBoxEndTipoIgreja.Items.Add("Travessa");
            comboBoxEndTipoIgreja.Items.Add("Praça");
            comboBoxEndTipoIgreja.Items.Add("Estação");
            comboBoxEndTipoIgreja.Items.Add("Alameda");
            comboBoxEndTipoIgreja.Items.Add("Balneário");
            comboBoxEndTipoIgreja.Items.Add("Beco");
            comboBoxEndTipoIgreja.Items.Add("Viela");

            addDataTablesColumns();
            getFundadoresList();
            getIgrejaFundadores(id);
            populateListView();

            getDetails(id);

            if (Program.AcessLevel != 1)
            {
                button1.Enabled = false;
                buttonCadastrarIgreja.Enabled = false;
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
                comboBoxEndCidadeIgreja.ValueMember = "idCidade";
                comboBoxEndCidadeIgreja.DisplayMember = "nome";
                comboBoxEndCidadeIgreja.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.igrejaDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdIgreja.Text = reader.GetString(14);
                    textBoxNomeIgreja.Text = reader.GetString(2);
                    maskedTextBoxContatoIgreja.Text = reader.GetString(3);
                    textBoxDescricaoIgreja.Text = reader.GetString(4);
                    textBoxEndLogradouroIgreja.Text = reader.GetString(5);
                    int index = comboBoxEndTipoIgreja.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoIgreja.SelectedItem = comboBoxEndTipoIgreja.Items[index];
                    textBoxEndNumeroIgreja.Text = reader.GetString(7);
                    try
                    {
                        textBoxEndComplementoIgreja.Text = reader.GetString(8);                        
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoIgreja.Text = "";                        
                    }
                    textBoxEndBairroIgreja.Text = reader.GetString(9);
                    maskedTextBoxEndCepIgreja.Text = reader.GetString(10);
                    comboBoxEndCidadeIgreja.SelectedValue = reader.GetInt32(11);
                    monthCalendarFundacaoIgreja.SetDate(reader.GetDateTime(15));
                    textBoxEstiloIgreja.Text = reader.GetString(16);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                groupBox1.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                groupBox2.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                textBoxIdIgreja.Enabled = false;
                
                button1.Text = "Salvar";
                editar = !editar;
            }
            else
            {
                bool sucess = true;
                try
                {
                    string igrejaNome = textBoxNomeIgreja.Text;
                    string igrejaEstilo = textBoxEstiloIgreja.Text;
                    DateTime igrejaFund = monthCalendarFundacaoIgreja.SelectionStart;
                    maskedTextBoxContatoIgreja.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string contato = maskedTextBoxContatoIgreja.Text;
                    maskedTextBoxContatoIgreja.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    string descricao = textBoxDescricaoIgreja.Text;

                    string endTip = comboBoxEndTipoIgreja.SelectedItem.ToString();
                    string endLog = textBoxEndLogradouroIgreja.Text;
                    string endNum = textBoxEndNumeroIgreja.Text;
                    string endComp;
                    try
                    {
                        endComp = textBoxEndComplementoIgreja.Text;
                    }
                    catch (NullReferenceException)
                    {
                        endComp = "";
                    }
                    string endBairro = textBoxEndBairroIgreja.Text;
                    maskedTextBoxEndCepIgreja.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string endCep = maskedTextBoxEndCepIgreja.Text;
                    maskedTextBoxEndCepIgreja.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    int cidade = int.Parse(comboBoxEndCidadeIgreja.SelectedValue.ToString());
                    if (cidade == 0) throw new InvalidSelectValue("CidadeID must be different of 0");
                    int id = int.Parse(textBoxIdIgreja.Text);
                    Classes.Igreja i = new Classes.Igreja(id, igrejaFund, igrejaEstilo, null, 0, "Igreja", igrejaNome, contato, descricao, endTip, endLog, endNum, endComp, endBairro, endCep, cidade);
                    if (!adapter.atualizarIgreja(i))
                    {
                        sucess = false;
                        //MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    MySqlDataReader reader = adapter.lastInsertId();
                    reader.Read();
                    int igrejaId = int.Parse(textBoxIdIgreja.Text);

                    foreach (DataRow drow in selecionados.Rows)
                    {
                        int idFundador = int.Parse(drow[0].ToString());
                        Classes.Fundador fu = new Classes.Fundador(idFundador, null, null, DateTime.Now, false, DateTime.Now, null, null);
                        Classes.Igreja ig = new Classes.Igreja(igrejaId, DateTime.Now, null, null, 0, null, null, null, null, null, null, null, null, null, null, 0);
                        //if (!adapter.atualizarFundadapor(ig, fu))
                        //{
                            //sucess = false;
                            //MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
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

        private void getIgrejaFundadores(int id)
        {
            MySqlDataReader reader = adapter.igrejafundadoresReader(id);

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



        private void textBoxEndNumeroIgreja_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonCadastrarIgreja_Click(object sender, EventArgs e)
        {
            if (adapter.removerIgreja(int.Parse(textBoxIdIgreja.Text)))
            {
                MessageBox.Show("Removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelarCadastroIgreja_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
