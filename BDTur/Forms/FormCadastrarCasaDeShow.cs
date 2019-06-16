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
    public partial class FormCadastrarCasaDeShow : Form
    {
        Classes.DAL adapter = new Classes.DAL();


        public FormCadastrarCasaDeShow()
        {
            InitializeComponent();
            populateComboBoxes();
        }

        private void FormCadastrarCasaDeShow_Load(object sender, EventArgs e)
        {
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
            

            labelRestaurante.Visible = false;
            comboBoxIdRestauranteCasaDeShow.Visible = false;
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

                while(reader.Read())
                {
                    DataRow dr;
                    dr = dt.NewRow();
                    dr.ItemArray = new object[2] { reader.GetInt32(0), reader.GetString(1) };
                    dt.Rows.InsertAt(dr, 0);
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

        private void checkBoxContemRestaurante_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxContemRestaurante.Checked)
            {
                labelRestaurante.Visible = true;
                comboBoxIdRestauranteCasaDeShow.Visible = true;
            }
            else
            {
                labelRestaurante.Visible = false;
                comboBoxIdRestauranteCasaDeShow.Visible = false;
            }
        }

        private void buttonCadastrarCasaDeShow_Click(object sender, EventArgs e)
        {

            try{ 
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

                string csDiaFechamento = comboBoxDiaFechamento.SelectedItem.ToString(); ;
                string cshorarioInicio = textBoxHoraInicioCasaDeShow.Text;
                if (csCid == 0) throw new InvalidSelectValue("CidadeID must be different of 0");

                Classes.CasaDeShow c = new Classes.CasaDeShow(0, csDiaFechamento, cshorarioInicio, 0, csRid, 0, "Casa de Show", csNome, csContato, csDesc, csEndTip, csEndLog, csEndNum, csEndComp, csEndBairro, csContato, csCid);
                if (adapter.adicionarCasadeShow(c))
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
            catch (InvalidSelectValue) {
                //Tratar se usuario não tenha selecionado uma cidade valida
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxEndNumeroCasaDeShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCancelarCadastroCasaDeShow_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
