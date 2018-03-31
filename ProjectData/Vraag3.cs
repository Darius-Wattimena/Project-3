using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectData.Converter;
using ProjectData.Database;
using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Database.Entities;
using ProjectData.Util;

namespace ProjectData
{
    public partial class Vraag3 : Form
    {
        public Vraag3()
        {
            InitializeComponent();
        }

        private void buttonQuestion2_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag2>();
        }

        private void buttonQuestion3_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag3>();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Form2>();
        }

        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
          //  resetCheckBoxes();
           // resetComboBoxes();
            buttonZoekFilter_Click(sender, e);
        }

        private void buttonResetProvincies_Click(object sender, EventArgs e)
        {
           // resetCheckBoxes();
            buttonZoekFilter_Click(sender, e);
        }

        private void buttonZoekFilter_Click(object sender, EventArgs e)
        {
        }
    }
}
