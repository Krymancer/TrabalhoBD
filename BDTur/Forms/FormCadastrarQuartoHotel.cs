﻿using System;
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
        public FormCadastrarQuartoHotel()
        {
            InitializeComponent();
        }

        private void FormCadastrarQuartoHotel_Load(object sender, EventArgs e)
        {

        }

        private void textBoxNumeroQuarto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
