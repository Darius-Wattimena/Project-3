using ProjectData.Util;
using System;
using System.Windows.Forms;

namespace ProjectData
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag1>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag2>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag3>();
        }
    }
}
