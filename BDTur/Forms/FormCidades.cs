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
    public partial class FormCidades : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormCidades()
        {
            InitializeComponent();
            populateDataGridView("","");
        }

        private void populateDataGridView(string nome, string estado)
        {
            MySqlDataAdapter da = adapter.cidadeAdapterParam(estado,nome);
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
                    Console.WriteLine($"Cidade Erro: \n{ex.Message}\n");
                }
                DataTable dtCloned = dt.Clone();                
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewCidade.DataSource = dtCloned;

                dataGridViewCidade.Columns[0].HeaderText = "ID";
                dataGridViewCidade.Columns[1].HeaderText = "Nome";
                dataGridViewCidade.Columns[2].HeaderText = "Estado";
                dataGridViewCidade.Columns[3].HeaderText = "População";
            }
            else
            {
                MessageBox.Show("Falha");
            }

        }

        private void dataGridViewCidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewCidade.RowCount)
            {
                int id = int.Parse(dataGridViewCidade.Rows[e.RowIndex].Cells[0].Value.ToString());
                Forms.FormDetalhesCidade nextScreen = new Forms.FormDetalhesCidade(id);
                nextScreen.ShowDialog();
                populateDataGridView("", "");
            }
        }

        private void textBoxCidade_TextChanged(object sender, EventArgs e)
        {
            string nome = textBoxCidade.Text;
            string estado = textBoxEstado.Text;
            populateDataGridView(nome, estado);
        } 

        private void textBoxEstado_TextChanged(object sender, EventArgs e)
        {
            string nome = textBoxCidade.Text;
            string estado = textBoxEstado.Text;
            populateDataGridView(nome, estado);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
