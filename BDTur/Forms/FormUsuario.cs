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
    public partial class FormUsuario : Form
    {
        Classes.DAL adapter = new Classes.DAL();
        int[] NivelAcessoUsuario = new int[] { 1, 2, 3 };

        public FormUsuario()
        {
            InitializeComponent();
            populateUsuarioDataGridView();
        }

        private void populateUsuarioDataGridView()
        {   
            MySqlDataAdapter da = adapter.usuarioAdapter();
            if (da != null)
            {
                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ocorreu um erro \n", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine($"Usuario Erro: \n{ex.Message}\n");
                }
                DataTable dtCloned = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    dtCloned.ImportRow(row);
                }

                dataGridViewUsuario.DataSource = dtCloned;            
                dataGridViewUsuario.Columns[0].HeaderText = "ID";
                dataGridViewUsuario.Columns[1].HeaderText = "Login";
                dataGridViewUsuario.Columns[2].HeaderText = "Senha";
                dataGridViewUsuario.Columns[3].HeaderText = "Nível de acesso";
                
            }
            else
            {
                MessageBox.Show("Falha");
            }
        }

        private void checkBoxNivelAdm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsuario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < dataGridViewUsuario.RowCount)
            {
                int id = int.Parse(dataGridViewUsuario.Rows[e.RowIndex].Cells[0].Value.ToString());
                Forms.FormDetalhesUsuario nextScreen = new Forms.FormDetalhesUsuario(id);
                nextScreen.ShowDialog();
                populateUsuarioDataGridView();
            }
        }
    }
}
