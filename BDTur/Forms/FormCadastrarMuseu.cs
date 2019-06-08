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
    public partial class FormCadastrarMuseu : Form
    {
        public FormCadastrarMuseu()
        {
            InitializeComponent();
        }

        private void FormCadastrarMuseu_Load(object sender, EventArgs e)
        {
            comboBoxEndTipoMuseu.Items.Add("Rua");
            comboBoxEndTipoMuseu.Items.Add("Avenida");
            comboBoxEndTipoMuseu.Items.Add("Travessa");
            comboBoxEndTipoMuseu.Items.Add("Praça");
            comboBoxEndTipoMuseu.Items.Add("Estação");
            comboBoxEndTipoMuseu.Items.Add("Alameda");
            comboBoxEndTipoMuseu.Items.Add("Balneário");
            comboBoxEndTipoMuseu.Items.Add("Beco");
        }
    }
}
