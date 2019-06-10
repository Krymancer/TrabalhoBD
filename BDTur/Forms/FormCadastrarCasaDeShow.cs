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
    }
}
