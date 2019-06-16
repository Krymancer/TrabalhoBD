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
    public partial class FormDetalhesCasadeShow : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        bool editar = false;

        public FormDetalhesCasadeShow(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxEndTipoCasaDeShow.Items.Add("Rua");
            comboBoxEndTipoCasaDeShow.Items.Add("Avenida");
            comboBoxEndTipoCasaDeShow.Items.Add("Travessa");
            comboBoxEndTipoCasaDeShow.Items.Add("Praça");
            comboBoxEndTipoCasaDeShow.Items.Add("Estação");
            comboBoxEndTipoCasaDeShow.Items.Add("Alameda");
            comboBoxEndTipoCasaDeShow.Items.Add("Balneário");
            comboBoxEndTipoCasaDeShow.Items.Add("Beco");
            comboBoxEndTipoCasaDeShow.Items.Add("Viela");

            comboBoxDiaFechamento.Items.Add("domingo");
            comboBoxDiaFechamento.Items.Add("segunda");
            comboBoxDiaFechamento.Items.Add("terça");
            comboBoxDiaFechamento.Items.Add("quarta");
            comboBoxDiaFechamento.Items.Add("quinta");
            comboBoxDiaFechamento.Items.Add("sexta");
            comboBoxDiaFechamento.Items.Add("sabado");

            getDetails(id);

            if (Program.AcessLevel != 1) {
                buttonEditar.Enabled = false;
                buttonCadastrarHotel.Enabled = false;
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.casadeshowDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdCasadeShow.Text = reader.GetString(14);
                    textBoxNomeCasaDeShow.Text = reader.GetString(2);
                    maskedTextBoxContatoCasaDeShow.Text = reader.GetString(3);
                    textBoxDescricaoCasaDeShow.Text = reader.GetString(4);
                    textBoxEndLogradouroCasaDeShow.Text = reader.GetString(5);
                    int index = comboBoxEndTipoCasaDeShow.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoCasaDeShow.SelectedItem = comboBoxEndTipoCasaDeShow.Items[index];
                    textBoxEndNumeroCasaDeShow.Text = reader.GetString(7);
                    try
                    {
                        textBoxEndComplementoCasaDeShow.Text = reader.GetString(8);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        textBoxEndComplementoCasaDeShow.Text = "";
                    }
                    textBoxEndBairroCasaDeShow.Text = reader.GetString(9);
                    maskedTextBoxEndCepCasaDeShow.Text = reader.GetString(10);
                    comboBoxEndCidadeCasaDeShow.SelectedValue = reader.GetInt32(11);
                    try
                    {
                        comboBoxIdRestauranteCasaDeShow.SelectedItem = comboBoxIdRestauranteCasaDeShow.Items[reader.GetInt32(18)];
                        checkBoxContemRestaurante.Checked = true;
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException)
                    {
                        checkBoxContemRestaurante.Checked = false;
                    }
                    int indexDia = comboBoxDiaFechamento.Items.IndexOf(reader.GetString(15));
                    Console.WriteLine(indexDia + " " + reader.GetString(15));
                    comboBoxDiaFechamento.SelectedItem = comboBoxDiaFechamento.Items[indexDia];
                    //textBoxDiaFechamentoCasaDeShow.Text = reader.GetString(12);
                    textBoxHoraInicioCasaDeShow.Text = reader.GetString(16);

                }
            }
        }

        private void populateComboBoxes()
        {            
            populateCidadesComboBox();
            populateRestauranteComboBox();
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
                comboBoxEndCidadeCasaDeShow.ValueMember = "idCidade";
                comboBoxEndCidadeCasaDeShow.DisplayMember = "nome";
                comboBoxEndCidadeCasaDeShow.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void populateRestauranteComboBox()
        {

            MySqlDataReader reader = adapter.restaunrateReader();
            if (reader != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("idRestaurante");
                dt.Columns.Add("nomeRestaurante");

                DataRow dr;
                dr = dt.NewRow();
                dr.ItemArray = new object[2] { 0, "Selecione..." };
                dt.Rows.InsertAt(dr, 0);

                int i = 1;
                while (reader.Read())
                {
                    dr = dt.NewRow();
                    dr.ItemArray = new object[2] { reader.GetInt32(0), reader.GetString(1) };
                    dt.Rows.InsertAt(dr, i);
                    i++;
                }


                //comboBoxCidade.Items.Add("Selecione...");
                comboBoxIdRestauranteCasaDeShow.ValueMember = "idRestaurante";
                comboBoxIdRestauranteCasaDeShow.DisplayMember = "nomeRestaurante";
                comboBoxIdRestauranteCasaDeShow.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                groupBoxDados.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                groupBoxEndereco.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });
                textBoxIdCasadeShow.Enabled = false;
                buttonEditar.Text = "Salvar";
                editar = !editar;
            }
            else
            {
                try
                {
                    string csNome = textBoxNomeCasaDeShow.Text;
                    maskedTextBoxContatoCasaDeShow.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string csContato = maskedTextBoxContatoCasaDeShow.Text;
                    maskedTextBoxContatoCasaDeShow.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    string csDesc = textBoxDescricaoCasaDeShow.Text;
                    string csEndLog = textBoxEndLogradouroCasaDeShow.Text;
                    string csEndTip = comboBoxEndTipoCasaDeShow.SelectedItem.ToString();
                    string csEndNum = textBoxEndNumeroCasaDeShow.Text;
                    string csEndComp;
                    try
                    {
                        csEndComp = textBoxEndComplementoCasaDeShow.Text;
                    }
                    catch (NullReferenceException)
                    {
                        csEndComp = "NULL";
                    }
                    string csEndBairro = textBoxEndBairroCasaDeShow.Text;
                    maskedTextBoxEndCepCasaDeShow.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string csEndCep = maskedTextBoxEndCepCasaDeShow.Text;
                    maskedTextBoxEndCepCasaDeShow.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    int csCid = int.Parse(comboBoxEndCidadeCasaDeShow.SelectedValue.ToString());
                    string csRid;

                    if (checkBoxContemRestaurante.Checked)
                    {
                        csRid = comboBoxIdRestauranteCasaDeShow.SelectedValue.ToString();
                    }
                    else
                    {
                        csRid = "NULL";
                    }

                    string csDiaFechamento = comboBoxDiaFechamento.SelectedItem.ToString();
                    string cshorarioInicio = textBoxHoraInicioCasaDeShow.Text;
                    if (csCid == 0) throw new InvalidSelectValue("CidadeID must be different of 0");

                    int id = int.Parse(textBoxIdCasadeShow.Text);
                    Classes.CasaDeShow c = new Classes.CasaDeShow(id, csDiaFechamento, cshorarioInicio, 0, csRid, 0, "Casa de Show", csNome, csContato, csDesc, csEndTip, csEndLog, csEndNum, csEndComp, csEndBairro, csContato, csCid);
                    if (adapter.atualizarCasadeShow(c))
                    {
                        MessageBox.Show("Atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        editar = !editar;
                        groupBoxDados.Controls.Cast<Control>().ToList()
                        .ForEach(x => { if (x.GetType() != typeof(Label)) x.Enabled = false; });
                        groupBoxEndereco.Controls.Cast<Control>().ToList()
                        .ForEach(x => { if (x.GetType() != typeof(Label)) x.Enabled = false; });
                        buttonEditar.Text = "Editar";
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

        private void textBoxEndNumeroCasaDeShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxHoraInicioCasaDeShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void buttonCadastrarHotel_Click(object sender, EventArgs e)
        {            
            if (adapter.removerCasadeShow(int.Parse(textBoxIdCasadeShow.Text)))
            {
                MessageBox.Show("Removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelarCadastroCasaDeShow_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
