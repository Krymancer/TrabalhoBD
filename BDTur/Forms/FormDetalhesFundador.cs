﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDTur.Forms
{
    public partial class FormDetalhesFundador : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        DataTable pontoturisticos = new DataTable();        
        private int id;

        public FormDetalhesFundador(int id)
        {
            InitializeComponent();
            pontoturisticos.Columns.Add("nomePontoTuristico");
            getPontosTuristicosList();
            this.id = id;

        }

        private void FormDetalhesFundador_Load(object sender, EventArgs e)
        {
            getPontosTuristicosList();
            getDetails(id);
        }

        private void getPontosTuristicosList()
        {
            MySqlDataReader readerIgreja = adapter.fundadorIgrejaReader(id);
            MySqlDataReader readerMuseu = adapter.fundadorMuseuReader(id);
            int i = 0;

            if (readerIgreja.HasRows)
            {                
                while (readerIgreja.Read())
                {
                    DataRow dataRow;
                    dataRow = pontoturisticos.NewRow();
                    dataRow.ItemArray = new object[1] { readerIgreja.GetString(0) };
                    pontoturisticos.Rows.InsertAt(dataRow, i);
                    i++;
                }
            }

            if (readerMuseu.HasRows)
            {                
                while (readerMuseu.Read())
                {
                    DataRow dataRow;
                    dataRow = pontoturisticos.NewRow();
                    dataRow.ItemArray = new object[1] { readerMuseu.GetString(0) };
                    pontoturisticos.Rows.InsertAt(dataRow, i);
                    i++;
                }
            }

        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.fundadorDetailsReader(id);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    textBoxNomeFundador.Text = reader.GetString(0);
                    textBoxAtividadeProfissionalFundador.Text = reader.GetString(1);
                    textBoxNacionalidadeFundador.Text = reader.GetString(2);
                    maskedTextBoxDataNascimentoFundador.Text = reader.GetString(3);

                    try
                    {
                        maskedTextBoxDataMorteFundador.Text = reader.GetString(4);
                    }
                    catch (SqlNullValueException e)
                    {

                        maskedTextBoxDataMorteFundador.Text = "";
                    }

                }

                listBoxPontosTuristicosFundados.DataSource = pontoturisticos;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}