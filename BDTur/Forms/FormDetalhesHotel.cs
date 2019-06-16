using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BDTur.Forms
{
    public partial class FormDetalhesHotel : Form
    {

        Classes.DAL adapter = new Classes.DAL();     

        public FormDetalhesHotel(int id)
        {
            InitializeComponent();

            comboBoxCategoriaHotel.Items.Add("1 Estrela");
            comboBoxCategoriaHotel.Items.Add("2 Estrelas");
            comboBoxCategoriaHotel.Items.Add("3 Estrelas");
            comboBoxCategoriaHotel.Items.Add("4 Estrelas");
            comboBoxCategoriaHotel.Items.Add("5 Estrelas");

            comboBoxEndTipoHotel.Items.Add("Rua");
            comboBoxEndTipoHotel.Items.Add("Avenida");
            comboBoxEndTipoHotel.Items.Add("Travessa");
            comboBoxEndTipoHotel.Items.Add("Praça");
            comboBoxEndTipoHotel.Items.Add("Estação");
            comboBoxEndTipoHotel.Items.Add("Alameda");
            comboBoxEndTipoHotel.Items.Add("Balneário");
            comboBoxEndTipoHotel.Items.Add("Beco");
            comboBoxEndTipoHotel.Items.Add("Viela");

            populateComboBoxes();
            populateHotelQuartoDataGridView(id);
            getDetails(id);           
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
                comboBoxEndCidadeHotel.ValueMember = "idCidade";
                comboBoxEndCidadeHotel.DisplayMember = "nome";
                comboBoxEndCidadeHotel.DataSource = dt;

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
                dr.ItemArray = new object[2] { 0 , "Selecione..." };
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
                comboBoxIdRestauranteHotel.ValueMember = "idRestaurante";
                comboBoxIdRestauranteHotel.DisplayMember = "nomeRestaurante";
                comboBoxIdRestauranteHotel.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.hotelDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdHotel.Text = reader.GetString(0);                                        
                    try
                    {
                        comboBoxIdRestauranteHotel.SelectedItem = comboBoxIdRestauranteHotel.Items[reader.GetInt32(1)];                        
                        checkBoxContemRestaurante.Checked = true;
                    }
                    catch(System.Data.SqlTypes.SqlNullValueException e){
                       checkBoxContemRestaurante.Checked = false;
                    }
                    textBoxNomeHotel.Text = reader.GetString(2);
                    comboBoxCategoriaHotel.SelectedItem = comboBoxCategoriaHotel.Items[int.Parse(reader.GetString(3)[0]+"")-1];
                    maskedTextBoxContatoHotel.Text = reader.GetString(4);
                    int index = comboBoxEndTipoHotel.Items.IndexOf(reader.GetString(5));                    
                    comboBoxEndTipoHotel.SelectedItem = comboBoxEndTipoHotel.Items[index];
                    textBoxEndLogradouroHotel.Text = reader.GetString(6);
                    textBoxEndNumeroHotel.Text = reader.GetString(7);                    
                    try
                    {
                        textBoxEndComplementoHotel.Text = reader.GetString(8);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoHotel.Text = "";
                    }
                    textBoxEndBairroHotel.Text = reader.GetString(9);
                    maskedTextBoxEndCepHotel.Text = reader.GetString(10);                                                            
                    comboBoxEndCidadeHotel.SelectedValue = reader.GetInt32(11);

                }
            }
        }

        private void populateHotelQuartoDataGridView(int id) {
            MySqlDataAdapter da = adapter.hotelQuartoAdapter(id);
            if (da != null)
            {
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ocorreu um erro \n", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Fundador Erro: \n{ex.Message}\n");
                }
                dataGridViewHotelQuarto.DataSource = dt;

                dataGridViewHotelQuarto.Columns[0].HeaderText = "Quantidade";
                dataGridViewHotelQuarto.Columns[1].HeaderText = "Tipo";
                dataGridViewHotelQuarto.Columns[2].HeaderText = "Diaria";

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
                comboBoxIdRestauranteHotel.Visible = true;
            }
            else
            {
                labelRestaurante.Visible = false;
                comboBoxIdRestauranteHotel.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEndNumeroHotel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonAddQuartos_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxIdHotel.Text);
            FormCadastrarQuartoHotel nextScreen = new FormCadastrarQuartoHotel(id);
            nextScreen.ShowDialog();
            populateHotelQuartoDataGridView(id);
        }

        private void buttonCadastrarHotel_Click(object sender, EventArgs e)
        {
            if (adapter.removerHotel(int.Parse(textBoxIdHotel.Text)))
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
