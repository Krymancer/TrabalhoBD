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
    public partial class FormCadastrarIgreja : Form
    {
        public FormCadastrarIgreja()
        {
            InitializeComponent();
        }

        private void FormCadastrarIgreja_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoIgreja.Items.Add("Rua");
            comboBoxEndTipoIgreja.Items.Add("Avenida");
            comboBoxEndTipoIgreja.Items.Add("Travessa");
            comboBoxEndTipoIgreja.Items.Add("Praça");
            comboBoxEndTipoIgreja.Items.Add("Estação");
            comboBoxEndTipoIgreja.Items.Add("Alameda");
            comboBoxEndTipoIgreja.Items.Add("Balneário");
            comboBoxEndTipoIgreja.Items.Add("Beco");
        }
    }
}
