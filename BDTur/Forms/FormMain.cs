using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
        int[] CategoriaHotel = new int[] {1, 2, 3, 4, 5};
        int[] CategoriaRestaurante = new int[] { 1, 2, 3, 4, 5 };
        bool[] RestauranteHotel = new bool[] { true, true };
        bool[] RestauranteCasaDeShow = new bool[] { true, true };
        string[] MuseuData = new string[] { "", "", "" };
        //int AcessLevel;
        public FormMain(int acessLevel)
        {
            InitializeComponent();
            //AcessLevel = acessLevel;

            if (Program.AcessLevel == 2) {
                cadastrarToolStripMenuItem.Enabled = false;
            }
            if (Program.AcessLevel == 3)
            {
                cadastrarToolStripMenuItem.Enabled = false;
                toolStripGerenciar.Enabled = false;
                
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            populateComboBoxes();
            refreshDataGridViews();
        }

        private void populateComboBoxes()
        {
            populateCidadesComboBox();
            populatePeriodoComboBox();
            populateFechamentoCasadeShowComboBox();
        }

        #region Popular ComboBoxes
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
                comboBoxCidade.ValueMember = "idCidade";
                comboBoxCidade.DisplayMember = "nome";
                comboBoxCidade.DataSource = dt;       
                
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }
        private void populatePeriodoComboBox() {
            MySqlDataReader dr = adapter.periodoReader();
            List<int> ListaAnos = new List<int>();
            List<int> ListaSec = new List<int>();
            List<string> ListaSeculos = new List<string>();
            int[] dec = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
            string[] sym = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ListaAnos.Add(dr.GetDateTime(0).Year);                    
                }
            }

            ListaAnos = ListaAnos.Distinct().ToList();

            foreach (int year in ListaAnos)
            {
                int ano = year;
                if (ano % 100 != 0)
                {         
                    ano -= ano % 100;
                    while (ano >= 100) ano /= 10;
                    ano++;
                }
                else
                {
                   while (ano >= 100) ano /= 10;
                }

                ListaSec.Add(ano);

                int num = ano;
                int i = 0;
                string rom = "";
                while (num>0)
                {
                    while (num/dec[i]>0)
                    {
                        rom += sym[i];
                        num -= dec[i];
                    }
                    i++;
                }

                ListaSeculos.Add(rom);
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("secNum");
            dt.Columns.Add("secRom");

            DataRow drow;
            drow = dt.NewRow();
            drow.ItemArray = new object[2] { 0, "Selecione..." };
            dt.Rows.InsertAt(drow, 0);

            for(int i = 0; i < ListaSeculos.Count; i++)
            {
                DataRow dataRow;
                dataRow = dt.NewRow();
                dataRow.ItemArray = new object[2] { ListaSec[i] , ListaSeculos[i] };
                dt.Rows.InsertAt(dataRow, i+1);                
            }

            comboBoxPeriodoIgreja.ValueMember = "secNum";
            comboBoxPeriodoIgreja.DisplayMember = "secRom";
            comboBoxPeriodoIgreja.DataSource = dt;
        }
        private void populateFechamentoCasadeShowComboBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("dia");          
            string[] semana = new string[] {"Selecione...","domingo","segunda","terça","quarta","quinta","sexta","sábado" };


            for (int i = 0; i < semana.Length; i++)
            {
                DataRow drow;
                drow = dt.NewRow();
                drow.ItemArray = new object[1] { semana[i] };
                dt.Rows.InsertAt(drow, i);
            }          

            comboBoxDiaFechamentoCasadeShow.ValueMember = "dia";
            comboBoxDiaFechamentoCasadeShow.DisplayMember = "dia";
            comboBoxDiaFechamentoCasadeShow.DataSource = dt;
        }
        #endregion
        /// <summary>
        /// Popula os DataGridViews com os dados do BD.
        /// </summary>
        /// <param name="name"> Texto para filtragem dos resultados pelo Nome </param>
        private void populateDataGridViews(string name, string cidade,int[] categoriaHotel, int[] categoriaRestaurante,bool[] restauranteHotel, string especialidadeRestaurante, string nomeFundadorIgreja, string nacionalidadeFundadorIgreja, string estiloIgreja, int periodoIgreja, string nomeFundadorMuseu, string nacionalidadeFundadorMuseu, string[] museuFundacao, string horarioCasaDeShow, string fechamentoCasadeShow, bool[] restauranteCasadeShow,string fundadorAtuacao, string fundadorNaturalidade)
        {
            populateHotelDataGridView(name, cidade,categoriaHotel,restauranteHotel);
            populateRestauranteDataGridView(name,cidade,CategoriaRestaurante,especialidadeRestaurante);            
            populateIgrejaDataGridView(name,cidade,nomeFundadorIgreja,nacionalidadeFundadorIgreja,estiloIgreja,periodoIgreja);
            populateCasaDeShowDataGridView(name,cidade, horarioCasaDeShow, fechamentoCasadeShow, restauranteCasadeShow);
            populateMuseuDataGridView(name,cidade, nomeFundadorMuseu, nacionalidadeFundadorMuseu, museuFundacao);
            populateFundadorDataGridView(name,fundadorAtuacao,fundadorNaturalidade);
        }

        #region Popular DataGridViews
        private void populateHotelDataGridView(string name, string cidade, int[] categoria,bool[] restaurante)
        {
            MySqlDataAdapter da = adapter.hotelAdapter(name,cidade, categoria, restaurante);
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
                    Console.WriteLine($"Hotel Erro: \n{ex.Message}\n");
                }
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
        private void populateRestauranteDataGridView(string name, string cidade, int[] categoria, string especialidade)
        {
            
            MySqlDataAdapter da = adapter.restauranteAdapter(name,cidade,categoria,especialidade);
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
                    Console.WriteLine($"Restaurante Erro: \n{ex.Message}\n");
                }
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
        private void populateIgrejaDataGridView(string name, string cidade, string nomeFundador, string nacionalidadeFundador, string estilo, int periodo)
        {
            MySqlDataAdapter da = adapter.igrejaAdapater(name,cidade,nomeFundador,nacionalidadeFundador,estilo, periodo);
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
                    Console.WriteLine($"Igreja Erro: \n{ex.Message}\n");
                }

                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Get duplicate rows
                foreach (DataRow dRow in dt.Rows)
                {
                    if (UniqueRecords.Contains(dRow[0]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[0]);
                }

                // Remove duplicate rows
                foreach (DataRow dRow in DuplicateRecords)
                {
                    dt.Rows.Remove(dRow);                    
                }

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
        private void populateCasaDeShowDataGridView(string name, string cidade, string horario, string fechamento, bool[] restaurante)
        {
            MySqlDataAdapter da = adapter.casadeShowAdapater(name, cidade, horario, fechamento, restaurante);
            if (da != null)
            {
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Ocorreu um erro \n", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"CasaDeShow Erro: \n{ex.Message}\n");
                }
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[2].DataType = typeof(Int64);
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }
                dataGridViewCasadeShow.DataSource = dtCloned;

                dataGridViewCasadeShow.Columns[2].DefaultCellStyle.Format = "(##) # ####-####";
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
        private void populateMuseuDataGridView(string name, string cidade, string nomeFundador, string nacionalidadeFundador, string[] fundacao)
        {
            MySqlDataAdapter da = adapter.museuAdapater(name, cidade, nomeFundador, nacionalidadeFundador, fundacao);
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
                    Console.WriteLine($"Museu Erro: \n{ex.Message}\n");
                }
                DataTable dtCloned = dt.Clone();
                dtCloned.Columns[2].DataType = typeof(Int64);

                ArrayList UniqueRecords = new ArrayList();
                ArrayList DuplicateRecords = new ArrayList();

                // Get duplicate rows
                foreach (DataRow dRow in dt.Rows)
                {
                    if (UniqueRecords.Contains(dRow[0]))
                        DuplicateRecords.Add(dRow);
                    else
                        UniqueRecords.Add(dRow[0]);
                }

                // Remove duplicate rows
                foreach (DataRow dRow in DuplicateRecords)
                {
                    dt.Rows.Remove(dRow);
                }

                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewMuseu.DataSource = dtCloned;

                dataGridViewMuseu.Columns[2].DefaultCellStyle.Format = "(##) # ####-####";
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
        private void populateFundadorDataGridView(string name, string atuacao, string naturalidade)
        {
            MySqlDataAdapter da = adapter.fundadorAdapter(name,atuacao,naturalidade);
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
        #endregion

        /// <summary>
        /// Atualiza os DataGridViews com os dados do BD devido a novos parametros nas requsições.
        /// </summary>
        private void refreshDataGridViews()
        {
            string name = textBoxNome.Text;
            string cidade = comboBoxCidade.SelectedValue.ToString();
            string especialidadeRestaurante = textBoxEspecialidadeRestaurante.Text;
            string nomeFundadorIgreja = textBoxNomeFundadorIgreja.Text;
            string nacionalidadeFundadorIgreja = textBoxNacionalidadeFundadorIgreja.Text;
            string estiloIgreja = textBoxEstiloIgreja.Text;
            string nomeFundadorMuseu = textBoxNomeFundadorMuseu.Text;
            string nacionalidadeFundadorMuseu = textBoxNacionalidadeFundadorMuseu.Text;
            int periodoIgreja = 0;
            string horarioCasadeShow = textBoxHorarioFuncionamentoCasadeShow.Text;
            string diaFechamentoCasadeShow = "Selecione...";
            if(comboBoxDiaFechamentoCasadeShow.SelectedValue != null) diaFechamentoCasadeShow = comboBoxDiaFechamentoCasadeShow.SelectedValue.ToString();
            if (comboBoxPeriodoIgreja.SelectedValue != null) periodoIgreja = int.Parse(comboBoxPeriodoIgreja.SelectedValue.ToString());
            string atuacaoFundador = textBoxAtuacaoFundador.Text;
            string naturaliadeFundador = textBoxNaturalidadeFundador.Text;
            populateDataGridViews(name, cidade, CategoriaHotel, CategoriaRestaurante, RestauranteHotel, especialidadeRestaurante, nomeFundadorIgreja, nacionalidadeFundadorIgreja, estiloIgreja, periodoIgreja, nomeFundadorMuseu, nacionalidadeFundadorMuseu, MuseuData, horarioCasadeShow, diaFechamentoCasadeShow, RestauranteCasaDeShow,  atuacaoFundador, naturaliadeFundador);
        }

        #region UIEvents
        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void comboBoxCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        
        private void checkBox5StarHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5StarHotel.CheckState == CheckState.Checked)
            {
                CategoriaHotel[4] = 5;
            }
            if (checkBox5StarHotel.CheckState == CheckState.Unchecked)
            {
                CategoriaHotel[4] = 0;
            }

            refreshDataGridViews();
        }
        private void checkBox4StarHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4StarHotel.CheckState == CheckState.Checked)
            {
                CategoriaHotel[3] = 4;
            }
            if (checkBox4StarHotel.CheckState == CheckState.Unchecked)
            {
                CategoriaHotel[3] = 0;
            }

            refreshDataGridViews();
        }
        private void checkBox3StarHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3StarHotel.CheckState == CheckState.Checked)
            {
                CategoriaHotel[2] = 3;
            }
            if (checkBox3StarHotel.CheckState == CheckState.Unchecked)
            {
                CategoriaHotel[2] = 0;
            }

            refreshDataGridViews();
        }
        private void checkBox2StarHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2StarHotel.CheckState == CheckState.Checked)
            {
                CategoriaHotel[1] = 2;
            }

            if (checkBox2StarHotel.CheckState == CheckState.Unchecked)
            {
                CategoriaHotel[1] = 0;
            }

            refreshDataGridViews();
        }
        private void checkBox1StarHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1StarHotel.CheckState == CheckState.Checked)
            {
                CategoriaHotel[0] = 1;                                                
            }
            if (checkBox1StarHotel.CheckState == CheckState.Unchecked)
            {                           
                CategoriaHotel[0] = 0;
            }

            refreshDataGridViews();
        }
        private void checkBoxPossuiRestauranteHotel_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPossuiRestauranteHotel.CheckState == CheckState.Checked)
            {
                RestauranteHotel[0] = true;
            }

            if (checkBoxPossuiRestauranteHotel.CheckState == CheckState.Unchecked)
            {
                RestauranteHotel[0] = false;
            }

            refreshDataGridViews();

        }
        private void checkBoxNãoPossuiRestauranteHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNaoPossuiRestauranteHotel.CheckState == CheckState.Checked)
            {
                RestauranteHotel[1] = true;
            }

            if (checkBoxNaoPossuiRestauranteHotel.CheckState == CheckState.Unchecked)
            {
                RestauranteHotel[1] = false;
            }

            refreshDataGridViews();
        }
        private void textBoxEspecialidadeRestaurante_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxNomeFundadorIgreja_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        } 
        private void textBoxEstiloIgreja_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxNacionalidadeFundadorIgreja_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxDiaFundacaoMuseu_TextChanged(object sender, EventArgs e)
        {
            MuseuData[2] = textBoxDiaFundacaoMuseu.Text;
            refreshDataGridViews();
        }
        private void textBoxMesFundacaoMuseu_TextChanged(object sender, EventArgs e)
        {
            MuseuData[1] = textBoxMesFundacaoMuseu.Text;
            refreshDataGridViews();
        }
        private void textBoxAnoFundacaoMuseu_TextChanged(object sender, EventArgs e)
        {
            MuseuData[0] = textBoxAnoFundacaoMuseu.Text;
            refreshDataGridViews();
        }
        private void textBoxNomeFundadorMuseu_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxNacionalidadeFundadorMuseu_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void comboBoxPeriodoIgreja_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void comboBoxDiaFechamentoCasadeShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxHorarioFuncionamentoCasadeShow_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void checkBoxPossuiRestauranteCasadeShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPossuiRestauranteCasadeShow.CheckState == CheckState.Checked)
            {
                RestauranteCasaDeShow[0] = true;
            }

            if (checkBoxPossuiRestauranteCasadeShow.CheckState == CheckState.Unchecked)
            {
                RestauranteCasaDeShow[0] = false;
            }

            refreshDataGridViews();
        }
        private void checkBoxNaoPossuiRestauranteCasadeShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNaoPossuiRestauranteCasadeShow.CheckState == CheckState.Checked)
            {
                RestauranteCasaDeShow[1] = true;
            }

            if (checkBoxNaoPossuiRestauranteCasadeShow.CheckState == CheckState.Unchecked)
            {
                RestauranteCasaDeShow[1] = false;
            }

            refreshDataGridViews();
        }    
        private void textBoxAtuacaoFundador_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxNaturalidadeFundador_TextChanged(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( tabControl.SelectedIndex == tabControl.TabPages.Count - 1)
            {
                comboBoxCidade.Enabled = false;                
            }
            else
            {
                comboBoxCidade.Enabled = true;
            }
        }
        private void dataGridViewHotel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewHotel.RowCount)
            {
                int id = int.Parse(dataGridViewHotel.Rows[e.RowIndex].Cells[0].Value.ToString());                
                Forms.FormDetalhesHotel nextScreen = new Forms.FormDetalhesHotel(id);
                nextScreen.ShowDialog();
                refreshDataGridViews();
            }            
        }
        private void dataGridViewRestaurante_CellDoubleClick(object sender, DataGridViewCellEventArgs e)                  
        {            
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewRestaurante.RowCount)
            {                
                int id = int.Parse(dataGridViewRestaurante.Rows[e.RowIndex].Cells[0].Value.ToString());
                Forms.FormDetalhesRestaurante nextScreen = new Forms.FormDetalhesRestaurante(id);
                nextScreen.ShowDialog();
                refreshDataGridViews();
            }
        }
        private void dataGridViewIgreja_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewIgreja.RowCount)
            {
                int id = int.Parse(dataGridViewIgreja.Rows[e.RowIndex].Cells[0].Value.ToString());                
                Forms.FormDetalhesIgreja nextScreen = new Forms.FormDetalhesIgreja(id);
                nextScreen.ShowDialog();
                refreshDataGridViews();
            }
        }
        private void dataGridViewMuseu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewMuseu.RowCount)
            {
                int id = int.Parse(dataGridViewMuseu.Rows[e.RowIndex].Cells[0].Value.ToString());
                Forms.FormDetalhesMuseu nextScreen = new Forms.FormDetalhesMuseu(id);
                nextScreen.ShowDialog();
                refreshDataGridViews();
            }
        }
        private void dataGridViewCasadeShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewCasadeShow.RowCount)
            {
                int id = int.Parse(dataGridViewCasadeShow.Rows[e.RowIndex].Cells[0].Value.ToString());
                Forms.FormDetalhesCasadeShow nextScreen = new Forms.FormDetalhesCasadeShow(id);
                nextScreen.ShowDialog();
                refreshDataGridViews();
            }
        }
        private void dataGridViewFundadores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewFundadores.RowCount)
            {
                int id = int.Parse(dataGridViewFundadores.Rows[e.RowIndex].Cells[0].Value.ToString());
                Forms.FormDetalhesFundador nextScreen = new Forms.FormDetalhesFundador(id);
                nextScreen.ShowDialog();
                refreshDataGridViews();
            }
        }
        private void cidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarCidade nextScreen = new Forms.FormCadastrarCidade();            
            nextScreen.ShowDialog();
            populateComboBoxes();
            refreshDataGridViews();
        }
        private void hotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarHotel nextScreen = new Forms.FormCadastrarHotel();
            nextScreen.ShowDialog();
            refreshDataGridViews();
        }
        private void restauranteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarRestaurante nextScreen = new Forms.FormCadastrarRestaurante();
            nextScreen.ShowDialog();
            refreshDataGridViews();
        }
        private void igrejaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarIgreja nextScreen = new Forms.FormCadastrarIgreja();
            nextScreen.ShowDialog();
            refreshDataGridViews();
        }
        private void museuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarMuseu nextScreen = new Forms.FormCadastrarMuseu();
            nextScreen.ShowDialog();
            refreshDataGridViews();
        }
        private void casaDeShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarCasaDeShow nextScreen = new Forms.FormCadastrarCasaDeShow();
            nextScreen.ShowDialog();
            refreshDataGridViews();
        }
        private void fundadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarFundador nextScreen = new Forms.FormCadastrarFundador();
            nextScreen.ShowDialog();
            refreshDataGridViews();
        }
        private void usariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.FormCadastrarUsuario nextScreen = new Forms.FormCadastrarUsuario();
            nextScreen.ShowDialog();
        }
        private void textBoxAtuacaoFundador_TextChanged_1(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
        private void textBoxNaturalidadeFundador_TextChanged_1(object sender, EventArgs e)
        {
            refreshDataGridViews();
        }
       private void cidadesToolStripMenuItemCidade_Click(object sender, EventArgs e)
        {
            Forms.FormCidades nextScreen = new Forms.FormCidades();
            nextScreen.ShowDialog();
            populateComboBoxes();
            refreshDataGridViews();
        }
        private void usuáriosToolStripMenuItemUser_Click(object sender, EventArgs e)
        {
            Forms.FormUsuario nextScreen = new Forms.FormUsuario();
            nextScreen.ShowDialog();            
        }

        #endregion

 
    }
}
