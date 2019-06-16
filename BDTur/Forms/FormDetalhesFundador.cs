using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDTur.Forms
{
    public partial class FormDetalhesFundador : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        DataTable pontoturisticos = new DataTable();        
        private int id;
        bool editar = false;

        public FormDetalhesFundador(int id)
        {
            InitializeComponent();
            pontoturisticos.Columns.Add("nomePontoTuristico");
            getPontosTuristicosList();
            this.id = id;

            if (Program.AcessLevel != 1)
            {
                button1.Enabled = false;
                buttonCadastrarHotel.Enabled = false;
            }
        }

        private void FormDetalhesFundador_Load(object sender, EventArgs e)
        {
            getPontosTuristicosList();
            getDetails(id);
        }

        private void getPontosTuristicosList()
        {
            MySqlDataReader readerIgreja = adapter.fundadorIgrejaReader(id);
            MySqlDataReader readerMuseu = adapter.fundadorMuseuReader(id);
            int i = 0;

            if (readerIgreja.HasRows)
            {                
                while (readerIgreja.Read())
                {
                    DataRow dataRow;
                    dataRow = pontoturisticos.NewRow();
                    dataRow.ItemArray = new object[1] { readerIgreja.GetString(0) };
                    pontoturisticos.Rows.InsertAt(dataRow, i);
                    i++;
                }
            }

            if (readerMuseu.HasRows)
            {                
                while (readerMuseu.Read())
                {
                    DataRow dataRow;
                    dataRow = pontoturisticos.NewRow();
                    dataRow.ItemArray = new object[1] { readerMuseu.GetString(0) };
                    pontoturisticos.Rows.InsertAt(dataRow, i);
                    i++;
                }
            }

        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.fundadorDetailsReader(id);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxNomeFundador.Text = reader.GetString(0);
                    textBoxAtividadeProfissionalFundador.Text = reader.GetString(1);
                    textBoxNacionalidadeFundador.Text = reader.GetString(2);
                    maskedTextBoxDataNascimentoFundador.Text = reader.GetString(3);

                    try
                    {
                        maskedTextBoxDataMorteFundador.Text = reader.GetString(4);
                    }
                    catch (SqlNullValueException e)
                    {

                        maskedTextBoxDataMorteFundador.Text = "";
                    }

                }

                listBoxPontosTuristicosFundados.DataSource = pontoturisticos;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                groupBox1.Controls.Cast<Control>().ToList()
                .ForEach(x => { x.Enabled = true; });                
                button1.Text = "Salvar";
                editar = !editar;
            }
            else
            {
                try
                {
                    string fundNome = textBoxNomeFundador.Text;
                    string fundPorf = textBoxAtividadeProfissionalFundador.Text;
                    string fundNacio = textBoxNacionalidadeFundador.Text;
                    string fundNasc = (maskedTextBoxDataNascimentoFundador.Text);
                    string fundMort = (maskedTextBoxDataMorteFundador.Text);
                    DateTime fundNascDate = DateTime.ParseExact(fundNasc, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                    DateTime fundMortDate;
                    bool hasDead = false;
                    try
                    {
                        fundMortDate = DateTime.ParseExact(fundMort, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("pt-BR"));
                        hasDead = true;
                    }
                    catch (FormatException)
                    {
                        fundMortDate = DateTime.Now;
                        hasDead = false;

                    }
                        Classes.Fundador f = new Classes.Fundador(id, fundNome, fundPorf, fundNascDate,hasDead, fundMortDate, fundNacio, null);
                    if (adapter.atualizarFundador(f))
                    {
                        MessageBox.Show("Atualizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                        editar = !editar;
                        groupBox1.Controls.Cast<Control>().ToList()
                        .ForEach(x => { if (x.GetType() != typeof(Label)) x.Enabled = false; });
                        button1.Text = "Editar";
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

        private void buttonCadastrarHotel_Click(object sender, EventArgs e)
        {
            if (adapter.removerFundador(id))
            {
                MessageBox.Show("Removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelarCadastroHotel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
