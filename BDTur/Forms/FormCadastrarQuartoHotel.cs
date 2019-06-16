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
    public partial class FormCadastrarQuartoHotel : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        int hotelid;

        public FormCadastrarQuartoHotel(int id)
        {
            hotelid = id;
            InitializeComponent();

            comboBoxTipoQuarto.Items.Add("luxo");
            comboBoxTipoQuarto.Items.Add("superluxo");
            comboBoxTipoQuarto.Items.Add("master");
            comboBoxTipoQuarto.Items.Add("standard");            
        }

        private void FormCadastrarQuartoHotel_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNumeroQuarto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCadastrarQuarto_Click(object sender, EventArgs e)
        {
            try
            { 
                int numquarto = int.Parse(textBoxNumeroQuarto.Text);
                string tipo = comboBoxTipoQuarto.SelectedItem.ToString();
                float diaria = float.Parse(maskedTextBoxDiariaQuarto.Text) / 100;
                Classes.HotelQuarto hq = new Classes.HotelQuarto(numquarto,hotelid,tipo,diaria);

                if (adapter.adicionarHotelQuarto(hq))
                {
                    MessageBox.Show("Adicionado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Falha", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (NullReferenceException)
            {
                //Erro ao resgatar valores dos componentes
                MessageBox.Show("Verifique se os campos estão preenchidos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancelarQuarto_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
