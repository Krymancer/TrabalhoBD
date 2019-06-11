﻿using MySql.Data.MySqlClient;
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
    public partial class FormDetalhesRestaurante : Form
    {

        Classes.DAL adapter = new Classes.DAL();

        public FormDetalhesRestaurante(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxCategoriaRestaurante.Items.Add("1 Estrela");
            comboBoxCategoriaRestaurante.Items.Add("2 Estrelas");
            comboBoxCategoriaRestaurante.Items.Add("3 Estrelas");
            comboBoxCategoriaRestaurante.Items.Add("4 Estrelas");
            comboBoxCategoriaRestaurante.Items.Add("5 Estrelas");

            comboBoxEndTipoRestaurante.Items.Add("Rua");
            comboBoxEndTipoRestaurante.Items.Add("Avenida");
            comboBoxEndTipoRestaurante.Items.Add("Travessa");
            comboBoxEndTipoRestaurante.Items.Add("Praça");
            comboBoxEndTipoRestaurante.Items.Add("Estação");
            comboBoxEndTipoRestaurante.Items.Add("Alameda");
            comboBoxEndTipoRestaurante.Items.Add("Balneário");
            comboBoxEndTipoRestaurante.Items.Add("Beco");
            comboBoxEndTipoRestaurante.Items.Add("Viela");


            getDetails(id);
        }

        private void populateComboBoxes()
        {
            populateCidadesComboBox();            
        }

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
                comboBoxEndCidadeRestaurante.ValueMember = "idCidade";
                comboBoxEndCidadeRestaurante.DisplayMember = "nome";
                comboBoxEndCidadeRestaurante.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.restauranteDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdRestaurante.Text = reader.GetString(0);
                    textBoxNomeRestaurante.Text = reader.GetString(1);
                    comboBoxCategoriaRestaurante.SelectedItem = comboBoxCategoriaRestaurante.Items[reader.GetInt32(2) - 1];
                    textBoxEspecialidadeRestaurante.Text = reader.GetString(3);
                    maskedTextBoxContatoRestaurante.Text = reader.GetString(4);
                    maskedTextBoxContatoRestaurante.Text = reader.GetString(5);
                    int index = comboBoxEndTipoRestaurante.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoRestaurante.SelectedItem = comboBoxEndTipoRestaurante.Items[index];
                    textBoxEndLogradouroRestaurante.Text = reader.GetString(7);
                    textBoxEndNumeroRestaurante.Text = reader.GetString(8);
                    try
                    {
                        textBoxEndComplementoRestaurante.Text = reader.GetString(9);
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoRestaurante.Text = "";
                    }

                    textBoxEndBairroRestaurante.Text = reader.GetString(10);
                    maskedTextBoxEndCepRestaurante.Text = reader.GetString(11);
                    comboBoxEndCidadeRestaurante.SelectedValue = reader.GetInt32(12);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
