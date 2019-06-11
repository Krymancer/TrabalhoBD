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
    public partial class FormDetalhesIgreja : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        DataTable fundadores = new DataTable();
        DataTable selecionados = new DataTable();


        public FormDetalhesIgreja(int id)
        {
            InitializeComponent();
            populateComboBoxes();

            comboBoxEndTipoIgreja.Items.Add("Rua");
            comboBoxEndTipoIgreja.Items.Add("Avenida");
            comboBoxEndTipoIgreja.Items.Add("Travessa");
            comboBoxEndTipoIgreja.Items.Add("Praça");
            comboBoxEndTipoIgreja.Items.Add("Estação");
            comboBoxEndTipoIgreja.Items.Add("Alameda");
            comboBoxEndTipoIgreja.Items.Add("Balneário");
            comboBoxEndTipoIgreja.Items.Add("Beco");
            comboBoxEndTipoIgreja.Items.Add("Viela");

            addDataTablesColumns();
            getFundadoresList();
            getIgrejaFundadores(id);
            populateListView();

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
                comboBoxEndCidadeIgreja.ValueMember = "idCidade";
                comboBoxEndCidadeIgreja.DisplayMember = "nome";
                comboBoxEndCidadeIgreja.DataSource = dt;

            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void getDetails(int id)
        {
            MySqlDataReader reader = adapter.igrejaDetailsReader(id);
            if (reader != null)
            {
                while (reader.Read())
                {
                    textBoxIdIgreja.Text = reader.GetString(14);
                    textBoxNomeIgreja.Text = reader.GetString(2);
                    maskedTextBoxContatoIgreja.Text = reader.GetString(3);
                    textBoxDescricaoIgreja.Text = reader.GetString(4);
                    textBoxEndLogradouroIgreja.Text = reader.GetString(5);
                    int index = comboBoxEndTipoIgreja.Items.IndexOf(reader.GetString(6));
                    comboBoxEndTipoIgreja.SelectedItem = comboBoxEndTipoIgreja.Items[index];
                    textBoxEndNumeroIgreja.Text = reader.GetString(7);
                    try
                    {
                        textBoxEndComplementoIgreja.Text = reader.GetString(8);                        
                    }
                    catch (System.Data.SqlTypes.SqlNullValueException e)
                    {
                        textBoxEndComplementoIgreja.Text = "";                        
                    }
                    textBoxEndBairroIgreja.Text = reader.GetString(9);
                    maskedTextBoxEndCepIgreja.Text = reader.GetString(10);
                    comboBoxEndCidadeIgreja.SelectedValue = reader.GetInt32(11);
                    monthCalendarFundacaoIgreja.SetDate(reader.GetDateTime(15));
                    textBoxEstiloIgreja.Text = reader.GetString(16);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void addDataTablesColumns()
        {
            fundadores.Columns.Add("idFundador");
            fundadores.Columns.Add("nomeFundador");
            selecionados.Columns.Add("idFundador");
            selecionados.Columns.Add("nomeFundador");
        }

        private void populateListView()
        {
            listBoxFundadoresDisponiveis.DataSource = fundadores;
            listBoxFundadoresSelecionados.DataSource = selecionados;
        }

        private void getFundadoresList()
        {
              MySqlDataReader dr = adapter.fundadoresReader();

            if (dr.HasRows)
            {
                int i = 0;
                while (dr.Read())
                {
                    DataRow dataRow;
                    dataRow = fundadores.NewRow();
                    dataRow.ItemArray = new object[2] { dr.GetInt32(0), dr.GetString(1) };  
                    fundadores.Rows.InsertAt(dataRow, i);
                    i++;
                }
            }          
            
        }

        private void getIgrejaFundadores(int id)
        {
            MySqlDataReader reader = adapter.igrejafundadoresReader(id);

            if (reader.HasRows)
            {
                int i = 0;
                while (reader.Read())
                {
                    string a = reader.GetString(1);

                    foreach (DataRow dr in fundadores.Rows)
                    {
                        if (dr["nomeFundador"].Equals(a))
                        {
                            selecionados.ImportRow(dr);
                            fundadores.Rows.Remove(dr);
                            break;
                        }
                    }
                }
            }
        }

        private void buttonAddFundador_Click(object sender, EventArgs e)
        {
            string a = listBoxFundadoresDisponiveis.GetItemText(listBoxFundadoresDisponiveis.SelectedItem);

            foreach (DataRow dr in fundadores.Rows)
            {
                if (dr["nomeFundador"].Equals(a))
                {
                    selecionados.ImportRow(dr);
                    fundadores.Rows.Remove(dr);
                    break;
                }
            }
        }

        private void buttonRemoveFundador_Click(object sender, EventArgs e)
        {
            string a = listBoxFundadoresSelecionados.GetItemText(listBoxFundadoresSelecionados.SelectedItem);

            foreach (DataRow dr in selecionados.Rows)
            {
                if (dr["nomeFundador"].Equals(a))
                {
                    fundadores.ImportRow(dr);
                    selecionados.Rows.Remove(dr);
                    break;
                }
            }
        }
    }
}
