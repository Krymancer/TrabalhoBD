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
            populateDataGridViews();
        }

        private void populateDataGridViews()
        {
            populateHotelDataGridView();
            populateRestauranteDataGridView();
            populatePontoTuristicoDataGridView();
            populateIgrejaDataGridView();
            populateCasaDeShowDataGridView();
            populateMuseuDataGridView();
            populateFundadorDataGridView();
        }

        private void populateComboBox()
        {
            Classes.Connection con = new Classes.Connection(Program.databaseUser, Program.databasePassword);
            MySqlDataAdapter da = con.cidadesAdapter();
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

        private void populateHotelDataGridView()
        {
            
            MySqlDataAdapter da = adapter.hotelAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewHotel.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Falha");
            }

            dataGridViewHotel.Columns[0].HeaderText = "ID";
            dataGridViewHotel.Columns[1].HeaderText = "Nome";
            dataGridViewHotel.Columns[2].HeaderText = "Categoria";
            dataGridViewHotel.Columns[3].HeaderText = "Tipo Endereço";
            dataGridViewHotel.Columns[4].HeaderText = "Logadouro";
            dataGridViewHotel.Columns[5].HeaderText = "Numero";
            dataGridViewHotel.Columns[6].HeaderText = "Complemento";
            dataGridViewHotel.Columns[7].HeaderText = "Bairro";
        }
        private void populateRestauranteDataGridView()
        {
            
            MySqlDataAdapter da = adapter.restauranteAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewRestaurante.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Falha");
            }

            dataGridViewRestaurante.Columns[0].HeaderText = "ID";
            dataGridViewRestaurante.Columns[1].HeaderText = "Nome";
            dataGridViewRestaurante.Columns[2].HeaderText = "Categoria";
            dataGridViewRestaurante.Columns[3].HeaderText = "Especialidade";
            dataGridViewRestaurante.Columns[4].HeaderText = "Preço Médio";
            dataGridViewRestaurante.Columns[4].DefaultCellStyle.Format = "R$ ###.##";
            dataGridViewRestaurante.Columns[5].HeaderText = "Tipo Endereço";
            dataGridViewRestaurante.Columns[6].HeaderText = "Logadouro";
            dataGridViewRestaurante.Columns[7].HeaderText = "Numero";
            dataGridViewRestaurante.Columns[8].HeaderText = "Complemento";
            dataGridViewRestaurante.Columns[9].HeaderText = "Bairro";
        }
        private void populatePontoTuristicoDataGridView()
        {
            MySqlDataAdapter da = adapter.pontoTuristicoAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();                
                da.Fill(dt);
                
                dataGridViewPontosTuristico.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Falha");
            }

            dataGridViewPontosTuristico.Columns[4].DefaultCellStyle.Format = "(##) # ####-####";

            dataGridViewPontosTuristico.Columns[0].HeaderText = "ID";            
            dataGridViewPontosTuristico.Columns[1].HeaderText = "Tipo";
            dataGridViewPontosTuristico.Columns[2].HeaderText = "Nome";
            dataGridViewPontosTuristico.Columns[3].HeaderText = "Descrição";
            dataGridViewPontosTuristico.Columns[4].HeaderText = "Telefone";
            dataGridViewPontosTuristico.Columns[5].HeaderText = "Tipo Endereço";
            dataGridViewPontosTuristico.Columns[6].HeaderText = "Logadouro";
            dataGridViewPontosTuristico.Columns[7].HeaderText = "Numero";
            dataGridViewPontosTuristico.Columns[8].HeaderText = "Complemento";
            dataGridViewPontosTuristico.Columns[9].HeaderText = "Bairro";            

        }
        private void populateIgrejaDataGridView()
        {

        }
        private void populateCasaDeShowDataGridView()
        {

        }
        private void populateMuseuDataGridView()
        {

        }
        private void populateFundadorDataGridView()
        {

        }

        private void dataGridViewPontosTuristico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
