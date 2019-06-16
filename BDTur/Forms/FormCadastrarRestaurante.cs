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
    public partial class FormCadastrarRestaurante : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormCadastrarRestaurante()
        {
            InitializeComponent();
        }

        private void FormCadastrarRestaurante_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoRestaurante.Items.Add("Rua");
            comboBoxEndTipoRestaurante.Items.Add("Avenida");
            comboBoxEndTipoRestaurante.Items.Add("Travessa");
            comboBoxEndTipoRestaurante.Items.Add("Praça");
            comboBoxEndTipoRestaurante.Items.Add("Estação");
            comboBoxEndTipoRestaurante.Items.Add("Alameda");
            comboBoxEndTipoRestaurante.Items.Add("Balneário");
            comboBoxEndTipoRestaurante.Items.Add("Beco");

            comboBoxCategoriaRestaurante.Items.Add("Simples");
            comboBoxCategoriaRestaurante.Items.Add("Rápido e Casual");
            comboBoxCategoriaRestaurante.Items.Add("Estilo Familiar");
            comboBoxCategoriaRestaurante.Items.Add("Luxo");
            comboBoxCategoriaRestaurante.Items.Add("Café ou Bistrô");
            comboBoxCategoriaRestaurante.Items.Add("Jantar fino");
            comboBoxCategoriaRestaurante.Items.Add("Fast food");
            comboBoxCategoriaRestaurante.Items.Add("Food Truck");
            comboBoxCategoriaRestaurante.Items.Add("Buffet");

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
                comboBoxEndCidadeRestaurante.ValueMember = "idCidade";
                comboBoxEndCidadeRestaurante.DisplayMember = "nome";
                comboBoxEndCidadeRestaurante.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void buttonCadastrarRestaurante_Click(object sender, EventArgs e)
        {
            Classes.Restaurante r;
            try
            {
                string restNome = textBoxNomeHotel.Text;
                string restCategoria = comboBoxCategoriaRestaurante.SelectedItem.ToString();
                string restEspecialidade = textBoxEspecialidadeRestaurante.Text;
                maskedTextBoxContatoRestaurante.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string restContato = maskedTextBoxContatoRestaurante.Text;
                maskedTextBoxContatoRestaurante.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                maskedTextBoxPreco.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                float restPreco = float.Parse(maskedTextBoxPreco.Text.ToString()) / 100;
                maskedTextBoxPreco.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                string restEndTipo = comboBoxEndTipoRestaurante.SelectedItem.ToString();
                string restEndLog = textBoxEndLogradouroRestaurante.Text;
                string restEndNum = textBoxEndNumeroRestaurante.Text;
                string restComp;
                try
                {
                    restComp = textBoxEndComplementoRestaurante.Text;
                }
                catch (NullReferenceException)
                {
                    restComp = "";
                }
                string restEndBairro = textBoxEndBairroRestaurante.Text;
                maskedTextBoxEndCepRestaurante.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                string restEndCep = maskedTextBoxEndCepRestaurante.Text;
                maskedTextBoxEndCepRestaurante.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                int restCid = int.Parse(comboBoxEndCidadeRestaurante.SelectedValue.ToString());
                if (restCid == 0) throw new InvalidSelectValue("CidadeID must be different of 0");
                
                r = new Classes.Restaurante(0, restNome, restCategoria, restEspecialidade, restPreco, restContato, restEndTipo, restEndLog, restEndNum, restComp, restEndBairro, restEndCep, restCid);
                if (adapter.adicionarRestaurante(r))
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
        private void textBoxEndNumeroRestaurante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonCancelarCadastroRestaurante_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    //Implementação de uma Exeção customizada 
    public class InvalidSelectValue : Exception
    {
        public InvalidSelectValue() : base() { }
        public InvalidSelectValue(string message) : base(message) { }
        public InvalidSelectValue(string message, System.Exception inner) : base(message, inner) { }
    }
}
