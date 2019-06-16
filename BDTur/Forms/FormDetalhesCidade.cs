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
    public partial class FormDetalhesCidade : Form
    {
        Classes.DAL adapter = new Classes.DAL();

        public FormDetalhesCidade(int id)
        {
            InitializeComponent();
            getDetails(id);
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.cidadesReader(id);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxIdCidade.Text = reader.GetInt32(0).ToString();
                    textBoxNomeCidade.Text = reader.GetString(1);
                    textBoxEstadoCidade.Text = reader.GetString(2);
                    textBoxPopulacaoCidade.Text = reader.GetString(3);
                }
            }
        }

        private void buttonEditarCidade_Click(object sender, EventArgs e)
        {

        }

        private void buttonExcluirCidade_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBoxIdCidade.Text);
            adapter.removerCidade(id);
            this.Close();
        }

        private void textBoxPopulacaoCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
