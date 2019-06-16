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
    public partial class FormDetalhesCasadeShow : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormDetalhesCasadeShow(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxEndTipoCasaDeShow.Items.Add("Rua");
            comboBoxEndTipoCasaDeShow.Items.Add("Avenida");
            comboBoxEndTipoCasaDeShow.Items.Add("Travessa");
            comboBoxEndTipoCasaDeShow.Items.Add("Praça");
            comboBoxEndTipoCasaDeShow.Items.Add("Estação");
            comboBoxEndTipoCasaDeShow.Items.Add("Alameda");
            comboBoxEndTipoCasaDeShow.Items.Add("Balneário");
            comboBoxEndTipoCasaDeShow.Items.Add("Beco");
            comboBoxEndTipoCasaDeShow.Items.Add("Viela");

            getDetails(id);
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.casadeshowDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdCasadeShow.Text = reader.GetString(14);
                    textBoxNomeCasaDeShow.Text = reader.GetString(2);
                    maskedTextBoxContatoCasaDeShow.Text = reader.GetString(3);
                    textBoxDescricaoCasaDeShow.Text = reader.GetString(4);
                    textBoxEndLogradouroCasaDeShow.Text = reader.GetString(5);
                    int index = comboBoxEndTipoCasaDeShow.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoCasaDeShow.SelectedItem = comboBoxEndTipoCasaDeShow.Items[index];
                    textBoxEndNumeroCasaDeShow.Text = reader.GetString(7);
                    try
                    {
                        textBoxEndComplementoCasaDeShow.Text = reader.GetString(8);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoCasaDeShow.Text = "";
                    }
                    textBoxEndBairroCasaDeShow.Text = reader.GetString(9);
                    maskedTextBoxEndCepCasaDeShow.Text = reader.GetString(10);
                    comboBoxEndCidadeCasaDeShow.SelectedValue = reader.GetInt32(11);
                    try
                    {
                        comboBoxIdRestauranteCasaDeShow.SelectedItem = comboBoxIdRestauranteCasaDeShow.Items[reader.GetInt32(18)];
                        checkBoxContemRestaurante.Checked = true;
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        checkBoxContemRestaurante.Checked = false;
                    }
                    textBoxDiaFechamentoCasaDeShow.Text = reader.GetString(12);
                    textBoxHoraInicioCasaDeShow.Text = reader.GetString(13);

                }
            }
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

                DataRow dr;
                dr = dt.NewRow();
                dr.ItemArray = new object[2] { 0, "Selecione..." };
                dt.Rows.InsertAt(dr, 0);

                int i = 1;
                while (reader.Read())
                {
                    dr = dt.NewRow();
                    dr.ItemArray = new object[2] { reader.GetInt32(0), reader.GetString(1) };
                    dt.Rows.InsertAt(dr, i);
                    i++;
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



        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEndNumeroCasaDeShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxHoraInicioCasaDeShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != ':'))
            {
                e.Handled = true;
            }
        }

        private void buttonCadastrarHotel_Click(object sender, EventArgs e)
        {            
            if (adapter.removerCasadeShow(int.Parse(textBoxIdCasadeShow.Text)))
            {
                MessageBox.Show("Removido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
