using ProjectData.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectData
{
    public partial class Vraag1 : Form
    {
        public Vraag1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag2>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag3>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Form2>();
        }

        private void Vraag1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Jaar2010 = checkBox2010.Checked;
            var Jaar2011 = checkBox2011.Checked;
            var Jaar2012 = checkBox2012.Checked;
            var Jaar2013 = checkBox2013.Checked;
            var Jaar2014 = checkBox2014.Checked;

            var SoortDiefstal = comboBoxSoortDiefstal.GetItemText(comboBoxSoortDiefstal.SelectedItem);

        }
    }
}
