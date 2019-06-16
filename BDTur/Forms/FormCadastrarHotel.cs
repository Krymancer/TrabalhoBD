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
    public partial class FormCadastrarHotel : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormCadastrarHotel()
        {
            InitializeComponent();
            populateComboBoxes();
        }

        private void FormCadastrarHotel_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoHotel.Items.Add("Rua");
            comboBoxEndTipoHotel.Items.Add("Avenida");
            comboBoxEndTipoHotel.Items.Add("Travessa");
            comboBoxEndTipoHotel.Items.Add("Praça");
            comboBoxEndTipoHotel.Items.Add("Estação");
            comboBoxEndTipoHotel.Items.Add("Alameda");
            comboBoxEndTipoHotel.Items.Add("Balneário");
            comboBoxEndTipoHotel.Items.Add("Beco");


            comboBoxCategoriaHotel.Items.Add("1 Estrela");
            comboBoxCategoriaHotel.Items.Add("2 Estrelas");
            comboBoxCategoriaHotel.Items.Add("3 Estrelas");
            comboBoxCategoriaHotel.Items.Add("4 Estrelas");
            comboBoxCategoriaHotel.Items.Add("5 Estrelas");

            labelRestaurante.Visible = false;
            comboBoxIdRestauranteHotel.Visible = false;
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
                comboBoxEndCidadeHotel.ValueMember = "idCidade";
                comboBoxEndCidadeHotel.DisplayMember = "nome";
                comboBoxEndCidadeHotel.DataSource = dt;

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

                while (reader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.ItemArray = new object[2] { reader.GetInt32(0), reader.GetString(1) };
                    dt.Rows.InsertAt(dr, 0);
                }


                //comboBoxCidade.Items.Add("Selecione...");
                comboBoxIdRestauranteHotel.ValueMember = "idRestaurante";
                comboBoxIdRestauranteHotel.DisplayMember = "nomeRestaurante";
                comboBoxIdRestauranteHotel.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void checkBoxContemRestaurante_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxContemRestaurante.Checked)
            {
                labelRestaurante.Visible = true;
                comboBoxIdRestauranteHotel.Visible = true;
            }
            else
            {
                labelRestaurante.Visible = false;
                comboBoxIdRestauranteHotel.Visible = false;
            }

        }

        private void buttonCadastrarHotel_Click(object sender, EventArgs e)
        {
            try
            {
                string hRid;
                if (checkBoxContemRestaurante.Checked)
                {
                    hRid = comboBoxIdRestauranteHotel.SelectedValue.ToString();
                }
                else
                {
                    hRid = "NULL";
                }

                string hNome = textBoxNomeHotel.Text;
                string hCategoria = comboBoxCategoriaHotel.SelectedItem.ToString();
                maskedTextBoxContatoHotel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string hContato = maskedTextBoxContatoHotel.Text;
                maskedTextBoxContatoHotel.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                string hEndTipo = comboBoxEndTipoHotel.SelectedItem.ToString();
                string hEndLog = textBoxEndLogradouroHotel.Text;
                string hEndNum = textBoxEndNumeroHotel.Text;
                string hEndComp;
                try
                {
                    hEndComp = textBoxEndComplementoHotel.Text;
                }
                catch (NullReferenceException)
                {
                    hEndComp = "NULL";
                }
                string hEndBairro = textBoxEndBairroHotel.Text;
                maskedTextBoxEndCepHotel.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string hEndCep = maskedTextBoxEndCepHotel.Text;
                maskedTextBoxEndCepHotel.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                int hCid = int.Parse(comboBoxEndCidadeHotel.SelectedValue.ToString());
                if (hCid == 0) throw new InvalidSelectValue("CidadeID must be different of 0");
                Classes.Hotel h = new Classes.Hotel(0,hCid,hRid,hNome,hCategoria,hContato,hEndTipo,hEndLog,hEndNum,hEndComp,hEndBairro,hEndBairro);
                if (adapter.adicionarHotel(h))
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
                //Erro ao resgatar valores dos componentes
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidSelectValue)
            {
                //Tratar se usuario não tenha selecionado uma cidade valida
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBoxEndNumeroHotel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonCancelarCadastroHotel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
