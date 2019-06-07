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
    public partial class FormCadastrarRestaurante : Form
    {
        public FormCadastrarRestaurante()
        {
            InitializeComponent();
        }

        private void FormCadastrarRestaurante_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoRestaurante.Items.Add("Rua");
            comboBoxEndTipoRestaurante.Items.Add("Avenida");
            comboBoxEndTipoRestaurante.Items.Add("Travessa");
            comboBoxEndTipoRestaurante.Items.Add("Praça");
            comboBoxEndTipoRestaurante.Items.Add("Estação");
            comboBoxEndTipoRestaurante.Items.Add("Alameda");
            comboBoxEndTipoRestaurante.Items.Add("Balneário");
            comboBoxEndTipoRestaurante.Items.Add("Beco");

            comboBoxCategoriaRestaurante.Items.Add("Simples");
            comboBoxCategoriaRestaurante.Items.Add("Rápido e Casual");
            comboBoxCategoriaRestaurante.Items.Add("Estilo Familiar");
            comboBoxCategoriaRestaurante.Items.Add("Luxo");
            comboBoxCategoriaRestaurante.Items.Add("Café ou Bistrô");
            comboBoxCategoriaRestaurante.Items.Add("Jantar fino");
            comboBoxCategoriaRestaurante.Items.Add("Fast food");
            comboBoxCategoriaRestaurante.Items.Add("Food Truck");
            comboBoxCategoriaRestaurante.Items.Add("Buffet");

            labelHotel.Visible = false;
            comboBoxIdHotelRestaurante.Visible = false;
        }

        private void checkBoxPertenceAHotel_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPertenceAHotel.Checked)
            {
                labelHotel.Visible = true;
                comboBoxIdHotelRestaurante.Visible = true;
            }
            else
            {
                labelHotel.Visible = false;
                comboBoxIdHotelRestaurante.Visible = false;
            }
        }
    }
}
