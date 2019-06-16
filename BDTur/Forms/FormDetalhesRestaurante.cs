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
    public partial class FormDetalhesRestaurante : Form
    {

        Classes.DAL adapter = new Classes.DAL();
        bool editar = false;

        public FormDetalhesRestaurante(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxCategoriaRestaurante.Items.Add("Simples");
            comboBoxCategoriaRestaurante.Items.Add("Rápido e Casual");
            comboBoxCategoriaRestaurante.Items.Add("Estilo Familiar");
            comboBoxCategoriaRestaurante.Items.Add("Luxo");
            comboBoxCategoriaRestaurante.Items.Add("Café ou Bistrô");
            comboBoxCategoriaRestaurante.Items.Add("Jantar fino");
            comboBoxCategoriaRestaurante.Items.Add("Fast food");
            comboBoxCategoriaRestaurante.Items.Add("Food Truck");
            comboBoxCategoriaRestaurante.Items.Add("Buffet");

            comboBoxEndTipoRestaurante.Items.Add("Rua");
            comboBoxEndTipoRestaurante.Items.Add("Avenida");
            comboBoxEndTipoRestaurante.Items.Add("Travessa");
            comboBoxEndTipoRestaurante.Items.Add("Praça");
            comboBoxEndTipoRestaurante.Items.Add("Estação");
            comboBoxEndTipoRestaurante.Items.Add("Alameda");
            comboBoxEndTipoRestaurante.Items.Add("Balneário");
            comboBoxEndTipoRestaurante.Items.Add("Beco");
            comboBoxEndTipoRestaurante.Items.Add("Viela");


            getDetails(id);

            if (Program.AcessLevel != 1)
            {
                buttonEditar.Enabled = false;
                buttonCadastrarHotel.Enabled = false;
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
                comboBoxEndCidadeRestaurante.ValueMember = "idCidade";
                comboBoxEndCidadeRestaurante.DisplayMember = "nome";
                comboBoxEndCidadeRestaurante.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.restauranteDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdRestaurante.Text = reader.GetString(0);
                    textBoxNomeRestaurante.Text = reader.GetString(1);
                    comboBoxCategoriaRestaurante.SelectedItem = comboBoxCategoriaRestaurante.Items[comboBoxCategoriaRestaurante.Items.IndexOf(reader.GetString(2))];
                    textBoxEspecialidadeRestaurante.Text = reader.GetString(3);
                    string preco = reader.GetFloat(4).ToString().PadLeft(5);
                    maskedTextBoxPrecoMedioRestaurante.Text = preco;
                    maskedTextBoxContatoRestaurante.Text = reader.GetString(5); 
                    int index = comboBoxEndTipoRestaurante.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoRestaurante.SelectedItem = comboBoxEndTipoRestaurante.Items[index];
                    textBoxEndLogradouroRestaurante.Text = reader.GetString(7);
                    textBoxEndNumeroRestaurante.Text = reader.GetString(8);
                    try
                    {
                        textBoxEndComplementoRestaurante.Text = reader.GetString(9);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoRestaurante.Text = "";
                    }

                    textBoxEndBairroRestaurante.Text = reader.GetString(10);
                    maskedTextBoxEndCepRestaurante.Text = reader.GetString(11);
                    comboBoxEndCidadeRestaurante.SelectedValue = reader.GetInt32(12);
                }
            }
        }

        private void textBoxEndNumeroRestaurante_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCadastrarHotel_Click(object sender, EventArgs e)
        {
            if (adapter.removerRestaurante(int.Parse(textBoxIdRestaurante.Text)))
            {
                MessageBox.Show("Removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                groupBoxDados.Controls.Cast<Control>().ToList()
                .ForEach(x => {  x.Enabled = true;  });
                groupBoxEndereço.Controls.Cast<Control>().ToList()
                .ForEach(x => {  x.Enabled = true; });
                textBoxIdRestaurante.Enabled = false;
                buttonEditar.Text = "Salvar";
                editar = !editar; 
            }
            else
            {
                Classes.Restaurante r;

                try
                {
                    int restID = int.Parse(textBoxIdRestaurante.Text);
                    string restNome = textBoxNomeRestaurante.Text;
                    string restCategoria = comboBoxCategoriaRestaurante.SelectedItem.ToString();
                    string restEspecialidade = textBoxEspecialidadeRestaurante.Text;
                    maskedTextBoxContatoRestaurante.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    string restContato = maskedTextBoxContatoRestaurante.Text;
                    maskedTextBoxContatoRestaurante.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                    maskedTextBoxPrecoMedioRestaurante.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals; // tira a formatação
                    float restPreco = 0;
                    try
                    {
                        restPreco = float.Parse(maskedTextBoxPrecoMedioRestaurante.Text.ToString()) / 100;
                    }
                    catch (FormatException)
                    {                        
                        //MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new NullReferenceException("PREÇO");
                    }
                    maskedTextBoxPrecoMedioRestaurante.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
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

                    r = new Classes.Restaurante(restID, restNome, restCategoria, restEspecialidade, restPreco, restContato, restEndTipo, restEndLog, restEndNum, restComp, restEndBairro, restEndCep, restCid);
                    if (adapter.atualizarRestaurante(r))
                    {
                        MessageBox.Show("Atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        editar = !editar;
                        groupBoxDados.Controls.Cast<Control>().ToList()
                        .ForEach(x => { if (x.GetType() != typeof(Label)) x.Enabled = false; });
                        groupBoxEndereço.Controls.Cast<Control>().ToList()
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

        private void buttonCancelarCadastroRestaurante_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
