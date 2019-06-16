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
    public partial class FormCadastrarMuseu : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        DataTable fundadores = new DataTable();
        DataTable selecionados = new DataTable();

        public FormCadastrarMuseu()
        {
            InitializeComponent();
            populateComboBoxes();
            addDataTablesColumns();
            getFundadoresList();
            populateListView();
        }

        private void FormCadastrarMuseu_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoMuseu.Items.Add("Rua");
            comboBoxEndTipoMuseu.Items.Add("Avenida");
            comboBoxEndTipoMuseu.Items.Add("Travessa");
            comboBoxEndTipoMuseu.Items.Add("Praça");
            comboBoxEndTipoMuseu.Items.Add("Estação");
            comboBoxEndTipoMuseu.Items.Add("Alameda");
            comboBoxEndTipoMuseu.Items.Add("Balneário");
            comboBoxEndTipoMuseu.Items.Add("Beco");
        }

        private void populateComboBoxes()
        {
            populateCidadesComboBox();
        }

        private void addDataTablesColumns()
        {
            fundadores.Columns.Add("idFundador");
            fundadores.Columns.Add("nomeFundador");
            selecionados.Columns.Add("idFundador");
            selecionados.Columns.Add("nomeFundador");
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

        private void populateListView()
        {
            listBoxFundadoresDisponiveis.DataSource = fundadores;
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
                }
            }
        }

        private void buttonAddFundador_Click(object sender, EventArgs e)
        {
            string a = listBoxFundadoresDisponiveis.GetItemText(listBoxFundadoresDisponiveis.SelectedItem);

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

        private void buttonRemoveFundador_Click(object sender, EventArgs e)
        {
            string a = listBoxFundadoresSelecionados.GetItemText(listBoxFundadoresSelecionados.SelectedItem);

            foreach (DataRow dr in selecionados.Rows)
            {
                if (dr["nomeFundador"].Equals(a))
                {
                    fundadores.ImportRow(dr);
                    selecionados.Rows.Remove(dr);
                    break;
                }
            }
        }

        private void buttonCadastrarMuseu_Click(object sender, EventArgs e)
        {
            bool sucess = true;
            try
            {
                string museuNome = textBoxNomeMuseu.Text;
                maskedTextBoxValorEntradaMuseu.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                float museuPreco = float.Parse(maskedTextBoxValorEntradaMuseu.Text)/100;
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
                Classes.Museu m = new Classes.Museu(0, museuFund, museuPreco,museuNumSalas, null, 0, "Museu", museuNome, contato, descricao, endTip, endLog, endNum, endComp, endBairro, endCep, cidade);
                if (!adapter.adicionarMuseu(m))
                {
                    sucess = false;
                    //MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MySqlDataReader reader = adapter.lastInsertId();
                reader.Read();
                int museuId = reader.GetInt32(0);

                foreach (DataRow drow in selecionados.Rows)
                {
                    int idFundador = int.Parse(drow[0].ToString());
                    Classes.Fundador fu = new Classes.Fundador(idFundador, null, null, DateTime.Now,false, DateTime.Now, null, null);
                    Classes.Museu mu = new Classes.Museu(museuId, DateTime.Now, 0,null, null, 0, null, null, null, null, null, null, null, null, null, null, 0);
                    if (!adapter.adicionarFundadopor(mu, fu))
                    {
                        sucess = false;
                        //MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (sucess)
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
        }

        private void textBoxEndNumeroMuseu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonCancelarCadastroMuseu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
