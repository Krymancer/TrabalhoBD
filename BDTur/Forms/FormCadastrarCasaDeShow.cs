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
        public FormCadastrarCasaDeShow()
        {
            InitializeComponent();
        }

        private void FormCadastrarCasaDeShow_Load(object sender, EventArgs e)
        {
            labelRestaurante.Visible = false;
            comboBoxIdRestauranteCasaDeShow.Visible = false;
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
