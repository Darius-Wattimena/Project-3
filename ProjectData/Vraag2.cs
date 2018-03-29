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
using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Database.Entities;
using System.Diagnostics;

namespace ProjectData
{
    public partial class Vraag2 : Form
    {
        private PreventieCriteria pcriteria = new PreventieCriteria();
        private DiefstalCriteria dcriteria = new DiefstalCriteria();
        private List<string> perioden = new List<string>();

        public Vraag2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag1>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag3>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Form2>();
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (yearone.Checked == true)
            {
                perioden.Add("2012JJ00");
            }
            else {
                perioden.Remove("2012JJ00");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkallyears.Checked == true)
            {
                yearone.Checked = true;
                yeartwo.Checked = true;
                yearthree.Checked = true;
                yearfour.Checked = true;
                yearfive.Checked = true;
                yearsix.Checked = true;
            }
            else
            {
                yearone.Checked = false;
                yeartwo.Checked = false;
                yearthree.Checked = false;
                yearfour.Checked = false;
                yearfive.Checked = false;
                yearsix.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (yeartwo.Checked == true)
            {
                perioden.Add("2013JJ00");
            }
            else
            {
                perioden.Remove("2013JJ00");
            }
        }

        private void updatechart_Click(object sender, EventArgs e)
        {
            if (yearone.Checked == false && yeartwo.Checked == false && yearthree.Checked == false && yearfour.Checked == false && yearfive.Checked == false && yearsix.Checked == false)
            {
                string message = "You didn't check any years. Please check at least one year.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);


            }
            else
            {
                this.preventie.Series["Series1"].Points.Clear();
                var pdao = new PreventieDao();
                pcriteria.Perioden = perioden;
                List<Preventie> lijstp = pdao.FindByCriteria(pcriteria);
                var ddao = new DiefstalDao();
                dcriteria.Perioden = perioden;
                dcriteria.Soortdiefstal = "00";
                dcriteria.Gebruikgeweld = "0";
                List<Diefstal> lijstd = ddao.FindByNewCriteria(dcriteria);
                List<Diefstal> slijstd = lijstd.OrderBy(o => o.TotaalGeregistreerdeDiefstallen).ToList();
                int x = 1;
                Debug.Write(slijstd.ElementAt(9).Perioden);

                Debug.Write(slijstd.ElementAt(9).RegioCode);
                Debug.Write(lijstp.ElementAt(9).Perioden);

                Debug.Write(lijstp.ElementAt(9).RegioCode);
                foreach (Diefstal element in slijstd)
                {
                    foreach (Preventie pelement in lijstp)
                    {
                        if (element.Perioden == pelement.Perioden && element.RegioCode.Trim() == pelement.RegioCode.Trim())
                        {
                            Debug.Write(x);
                            this.preventie.Series["Series1"].Points.AddXY(Convert.ToInt32(element.TotaalGeregistreerdeDiefstallen), pelement.LichtBijAfwezigheid);
                            x++;
                        }
                    }
                }
            }
        }

        private void yearthree_CheckedChanged(object sender, EventArgs e)
        {
            if (yearthree.Checked == true)
            {
                perioden.Add("2014JJ00");
            }
            else
            {
                perioden.Remove("2014JJ00");
            }
        }

        private void yearfour_CheckedChanged(object sender, EventArgs e)
        {
            if (yearfour.Checked == true)
            {
                perioden.Add("2015JJ00");
            }
            else
            {
                perioden.Remove("2015JJ00");
            }
        }

        private void yearfive_CheckedChanged(object sender, EventArgs e)
        {
            if (yearfive.Checked == true)
            {
                perioden.Add("2016JJ00");
            }
            else
            {
                perioden.Remove("2016JJ00");
            }
        }

        private void yearsix_CheckedChanged(object sender, EventArgs e)
        {
            if (yearsix.Checked == true)
            {
                perioden.Add("2017JJ00");
            }
            else
            {
                perioden.Remove("2017JJ00");
            }
        }
    }
}
