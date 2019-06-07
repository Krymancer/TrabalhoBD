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
    public partial class FormCadastrarHotel : Form
    {
        public FormCadastrarHotel()
        {
            InitializeComponent();
        }

        private void FormCadastrarHotel_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoHotel.Items.Add("Rua");
            comboBoxEndTipoHotel.Items.Add("Avenida");
            comboBoxEndTipoHotel.Items.Add("Travessa");
            comboBoxEndTipoHotel.Items.Add("Praça");
            comboBoxEndTipoHotel.Items.Add("Estação");
            comboBoxEndTipoHotel.Items.Add("Alameda");
            comboBoxEndTipoHotel.Items.Add("Balneário");
            comboBoxEndTipoHotel.Items.Add("Beco");


            comboBoxCategoriaHotel.Items.Add("1 Estrela");
            comboBoxCategoriaHotel.Items.Add("2 Estrelas");
            comboBoxCategoriaHotel.Items.Add("3 Estrelas");
            comboBoxCategoriaHotel.Items.Add("4 Estrelas");
            comboBoxCategoriaHotel.Items.Add("5 Estrelas");
        }
        }
}
