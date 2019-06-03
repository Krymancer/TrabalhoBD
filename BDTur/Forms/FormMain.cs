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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Classes.Connection con = new Classes.Connection(Program.databaseUser, Program.databasePassword);
            MySqlDataAdapter da = con.allAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewCidade.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Falha");
            }

            populateComboBox();
        }

        private void populateComboBox()
        {
            Classes.Connection con = new Classes.Connection(Program.databaseUser, Program.databasePassword);
            MySqlDataAdapter da = con.cidadesAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                comboBox1.ValueMember = "idCidade";
                comboBox1.DisplayMember = "nome";
                comboBox1.DataSource = dt;       
                foreach (DataRow dr in dt.Rows) {
                    //comboBox1.Items.Add(dr[1].ToString());                   
                }
                
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }
    }
}
