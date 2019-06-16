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
    public partial class FormCadastrarIgreja : Form
    {

        Classes.DAL adapter = new Classes.DAL();
        DataTable fundadores = new DataTable();        
        DataTable selecionados = new DataTable();        


        public FormCadastrarIgreja()
        {
            InitializeComponent();
            populateComboBoxes();
            addDataTablesColumns();
            getFundadoresList();
            populateListView();            
        }

        private void FormCadastrarIgreja_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoIgreja.Items.Add("Rua");
            comboBoxEndTipoIgreja.Items.Add("Avenida");
            comboBoxEndTipoIgreja.Items.Add("Travessa");
            comboBoxEndTipoIgreja.Items.Add("Praça");
            comboBoxEndTipoIgreja.Items.Add("Estação");
            comboBoxEndTipoIgreja.Items.Add("Alameda");
            comboBoxEndTipoIgreja.Items.Add("Balneário");
            comboBoxEndTipoIgreja.Items.Add("Beco");
        }

        private void populateComboBoxes() {
            populateCidadesComboBox();
        }

        private void addDataTablesColumns() {
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
                comboBoxEndCidadeIgreja.ValueMember = "idCidade";
                comboBoxEndCidadeIgreja.DisplayMember = "nome";
                comboBoxEndCidadeIgreja.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void populateListView() {            
            listBoxFundadoresDisponiveis.DataSource = fundadores;
            listBoxFundadoresSelecionados.DataSource = selecionados;
        }

        private void getFundadoresList() {
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

        private void buttonCadastrarIgreja_Click(object sender, EventArgs e)
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
                Classes.Igreja i = new Classes.Igreja(0,igrejaFund,igrejaEstilo,null,0,"Igreja",igrejaNome,contato,descricao,endTip,endLog,endNum,endComp,endBairro,endCep,cidade);
                if (!adapter.adicionarIgreja(i))
                { 
                    sucess = false;
                    //MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MySqlDataReader reader = adapter.lastInsertId();
                reader.Read();
                int igrejaId = reader.GetInt32(0);

                foreach (DataRow drow in selecionados.Rows)
                {
                    int idFundador = int.Parse(drow[0].ToString());
                    Classes.Fundador fu = new Classes.Fundador(idFundador,null,null,DateTime.Now, false,DateTime.Now, null,null);
                    Classes.Igreja ig = new Classes.Igreja(igrejaId, DateTime.Now,null,null,0,null,null,null,null,null,null,null,null,null,null,0);
                    if (!adapter.adicionarFundadapor(ig,fu))
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

        private void textBoxEndNumeroIgreja_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCancelarCadastroIgreja_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
