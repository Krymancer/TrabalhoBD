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
    public partial class FormMain : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            populateComboBox();
            populateDataGridViews("",null);
        }

        
        private void populateComboBox()
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


                comboBoxCidade.Items.Add("Selecione...");
                comboBoxCidade.ValueMember = "idCidade";
                comboBoxCidade.DisplayMember = "nome";
                comboBoxCidade.DataSource = dt;       
                
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        /// <summary>
        /// Popula os DataGridViews com os dados do BD.
        /// </summary>
        private void populateDataGridViews(string where, string cidade)
        {
            populateHotelDataGridView(where, cidade);
            populateRestauranteDataGridView(where);
            populatePontoTuristicoDataGridView(where);
            populateIgrejaDataGridView(where);
            populateCasaDeShowDataGridView(where);
            populateMuseuDataGridView(where);
            populateFundadorDataGridView(where);
        }
        /* Metodos para popular e alterar o cabeçario dos DataGridViews individualmente */
        private void populateHotelDataGridView(string where, string cidade)
        {
            MySqlDataAdapter da = adapter.hotelAdapter(where,cidade);
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[3].DataType = typeof(Int64);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dataGridViewHotel.DataSource = dtCloned;

                dataGridViewHotel.Columns[3].DefaultCellStyle.Format = "(##) # ####-####";

                dataGridViewHotel.Columns[0].HeaderText = "ID";
                dataGridViewHotel.Columns[1].HeaderText = "Nome";
                dataGridViewHotel.Columns[2].HeaderText = "Categoria";
                dataGridViewHotel.Columns[3].HeaderText = "Contato";
                dataGridViewHotel.Columns[4].HeaderText = "Tipo Endereço";
                dataGridViewHotel.Columns[5].HeaderText = "Logadouro";
                dataGridViewHotel.Columns[6].HeaderText = "Numero";
                dataGridViewHotel.Columns[7].HeaderText = "Complemento";
                dataGridViewHotel.Columns[8].HeaderText = "Bairro";
            }
            else
            {
                MessageBox.Show("Falha");
            }          
        }
        private void populateRestauranteDataGridView(string where)
        {
            
            MySqlDataAdapter da = adapter.restauranteAdapter(where);
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[5].DataType = typeof(Int64);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewRestaurante.DataSource = dtCloned;

                dataGridViewRestaurante.Columns[5].DefaultCellStyle.Format = "(##) # ####-####";

                dataGridViewRestaurante.Columns[0].HeaderText = "ID";
                dataGridViewRestaurante.Columns[1].HeaderText = "Nome";
                dataGridViewRestaurante.Columns[2].HeaderText = "Categoria";
                dataGridViewRestaurante.Columns[3].HeaderText = "Especialidade";
                dataGridViewRestaurante.Columns[4].HeaderText = "Preço Médio";
                dataGridViewRestaurante.Columns[4].DefaultCellStyle.Format = "R$ ###.##";
                dataGridViewRestaurante.Columns[5].HeaderText = "Contato";
                dataGridViewRestaurante.Columns[6].HeaderText = "Tipo Endereço";
                dataGridViewRestaurante.Columns[7].HeaderText = "Logadouro";
                dataGridViewRestaurante.Columns[8].HeaderText = "Numero";
                dataGridViewRestaurante.Columns[9].HeaderText = "Complemento";
                dataGridViewRestaurante.Columns[10].HeaderText = "Bairro";
            }
            else
            {
                MessageBox.Show("Falha");
            }

           
        }
        private void populatePontoTuristicoDataGridView(string where)
        {
            MySqlDataAdapter da = adapter.pontoTuristicoAdapter(where);
            if (da != null)
            {            
                DataTable dt = new DataTable();                
                da.Fill(dt);                             
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[4].DataType = typeof(Int64);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewPontosTuristico.DataSource = dtCloned;

                dataGridViewPontosTuristico.Columns[4].DefaultCellStyle.Format = "(##) # ####-####";

                dataGridViewPontosTuristico.Columns[0].HeaderText = "ID";
                dataGridViewPontosTuristico.Columns[1].HeaderText = "Tipo";
                dataGridViewPontosTuristico.Columns[2].HeaderText = "Nome";
                dataGridViewPontosTuristico.Columns[3].HeaderText = "Descrição";
                dataGridViewPontosTuristico.Columns[4].HeaderText = "Contato";
                dataGridViewPontosTuristico.Columns[5].HeaderText = "Tipo Endereço";
                dataGridViewPontosTuristico.Columns[6].HeaderText = "Logadouro";
                dataGridViewPontosTuristico.Columns[7].HeaderText = "Numero";
                dataGridViewPontosTuristico.Columns[8].HeaderText = "Complemento";
                dataGridViewPontosTuristico.Columns[9].HeaderText = "Bairro";
            }
            else
            {
                MessageBox.Show("Falha");
            }             
        }
        private void populateIgrejaDataGridView(string where)
        {
            MySqlDataAdapter da = adapter.igrejaAdapater(where);
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[3].DataType = typeof(Int64);                
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewIgreja.DataSource = dtCloned;

                dataGridViewIgreja.Columns[3].DefaultCellStyle.Format = "(##) # ####-####";
                dataGridViewIgreja.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridViewIgreja.Columns[0].HeaderText = "ID";
                dataGridViewIgreja.Columns[1].HeaderText = "Nome";
                dataGridViewIgreja.Columns[2].HeaderText = "Descrição";
                dataGridViewIgreja.Columns[3].HeaderText = "Contato";
                dataGridViewIgreja.Columns[4].HeaderText = "Data de Fundação";
                dataGridViewIgreja.Columns[5].HeaderText = "Estilo";
                dataGridViewIgreja.Columns[6].HeaderText = "Tipo Endereço";
                dataGridViewIgreja.Columns[7].HeaderText = "Logadouro";
                dataGridViewIgreja.Columns[8].HeaderText = "Numero";
                dataGridViewIgreja.Columns[9].HeaderText = "Complemento";
                dataGridViewIgreja.Columns[10].HeaderText = "Bairro";
            }
            else
            {
                MessageBox.Show("Falha");
            }           

        }
        private void populateCasaDeShowDataGridView(string where)
        {
            MySqlDataAdapter da = adapter.casadeShowAdapater(where);
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[2].DataType = typeof(Int64);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dataGridViewCasadeShow.DataSource = dtCloned;

                dataGridViewCasadeShow.Columns[3].DefaultCellStyle.Format = "(##) # ####-####";
                dataGridViewCasadeShow.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                
                dataGridViewCasadeShow.Columns[0].HeaderText = "ID";
                dataGridViewCasadeShow.Columns[1].HeaderText = "Nome";                
                dataGridViewCasadeShow.Columns[2].HeaderText = "Contato";
                dataGridViewCasadeShow.Columns[3].HeaderText = "Descrição";
                dataGridViewCasadeShow.Columns[4].HeaderText = "Data de Fundação";
                dataGridViewCasadeShow.Columns[5].HeaderText = "Estilo";
                dataGridViewCasadeShow.Columns[6].HeaderText = "Tipo Endereço";
                dataGridViewCasadeShow.Columns[7].HeaderText = "Logadouro";
                dataGridViewCasadeShow.Columns[8].HeaderText = "Numero";
                dataGridViewCasadeShow.Columns[9].HeaderText = "Complemento";
                dataGridViewCasadeShow.Columns[10].HeaderText = "Bairro";
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }
        private void populateMuseuDataGridView(string where)
        {
            MySqlDataAdapter da = adapter.museuAdapater(where);
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[2].DataType = typeof(Int64);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewMuseu.DataSource = dtCloned;

                dataGridViewMuseu.Columns[3].DefaultCellStyle.Format = "(##) # ####-####";
                dataGridViewMuseu.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewMuseu.Columns[5].DefaultCellStyle.Format = "R$ ##,##";
                
                dataGridViewMuseu.Columns[0].HeaderText = "ID";
                dataGridViewMuseu.Columns[1].HeaderText = "Nome";                
                dataGridViewMuseu.Columns[2].HeaderText = "Contato";
                dataGridViewMuseu.Columns[3].HeaderText = "Descrição";
                dataGridViewMuseu.Columns[4].HeaderText = "N° de Salas";
                dataGridViewMuseu.Columns[5].HeaderText = "Entrada";
                dataGridViewMuseu.Columns[6].HeaderText = "Tipo Endereço";
                dataGridViewMuseu.Columns[7].HeaderText = "Logadouro";
                dataGridViewMuseu.Columns[8].HeaderText = "Numero";
                dataGridViewMuseu.Columns[9].HeaderText = "Complemento";
                dataGridViewMuseu.Columns[10].HeaderText = "Bairro";
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }
        private void populateFundadorDataGridView(string where)
        {
            MySqlDataAdapter da = adapter.fundadorAdapter(where);
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewFundadores.DataSource = dt;

                dataGridViewFundadores.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridViewFundadores.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";                

                dataGridViewFundadores.Columns[0].HeaderText = "ID";
                dataGridViewFundadores.Columns[1].HeaderText = "Nome";
                dataGridViewFundadores.Columns[2].HeaderText = "Atuação";
                dataGridViewFundadores.Columns[3].HeaderText = "Nascimento";
                dataGridViewFundadores.Columns[4].HeaderText = "Morte";
                dataGridViewFundadores.Columns[5].HeaderText = "Nacionalidade";
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }
        /* ---------------------------------------------------------------------------- */        
        private void dataGridViewPontosTuristico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            string where = textBoxNome.Text;
            string cidade = comboBoxCidade.SelectedValue.ToString();
            
            populateDataGridViews(where,cidade);
        }
    }
}
