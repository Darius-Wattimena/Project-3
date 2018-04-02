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
        private List<string> perioden = new List<string>();
        private List<string> regios = new List<string>();

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

        private void updatechart_Click(object sender, EventArgs e)
        {
            this.preventie.Series["Series1"].Points.Clear();
            var selected = aantalsoort(combobox.GetItemText(combobox.SelectedItem));
            if (CheckYears().Count() == 0)
            {
                string message = "You didn't check any years. Please check at least one year.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);


            }
            else if (CheckCheckboxes().Count == 0)
            {
                string message = "You didn't check any provinces. Please check at least one province.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
            }
            else if (selected == 0)
            {
                string message = "You didn't pick a type. Please pick a type.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                PreventieCriteria pcritiria = new PreventieCriteria();
                DiefstalCriteria dcriteria = new DiefstalCriteria();
                regios = CheckCheckboxes();
                perioden = CheckYears();
                var pdao = new PreventieDao();
                pcritiria.Perioden = perioden;
                pcritiria.Regios = regios;
                List<Preventie> lijstp = pdao.FindByNewCriteria(pcritiria);
                var ddao = new DiefstalDao();
                dcriteria.Perioden = perioden;
                dcriteria.RegioList = regios;
                dcriteria.Soortdiefstal = "00";
                dcriteria.Gebruikgeweld = "0";
                List<Diefstal> lijstd = ddao.FindByNewCriteria(dcriteria);
                List<Diefstal> slijst = new List<Diefstal>();

                if (selected == 1) {
                    slijst = lijstd.OrderBy(o => o.TotaalGeregistreerdeDiefstallen).ToList();
                    foreach (Diefstal element in slijst)
                    {
                        foreach (Preventie pelement in lijstp)
                        {
                            if (element.Perioden == pelement.Perioden && element.RegioCode.Trim() == pelement.RegioCode.Trim())
                            {
                                this.preventie.Series["Relatie preventie en diefstal"].Points.AddXY(Convert.ToInt32(element.TotaalGeregistreerdeDiefstallen), pelement.LichtBijAfwezigheid);
                            }
                        }
                    }
                    this.preventie.ChartAreas[0].AxisX.Title = "Aantal diefstallen";
                    this.preventie.ChartAreas[0].AxisY.Title = "Percentage van preventiefgedrag";
                } else if (selected == 2) {
                    slijst = lijstd.OrderBy(o => o.GeregistreerdeDiefstallenPer1000Inw).ToList();
                    foreach (Diefstal element in slijst)
                    {
                        foreach (Preventie pelement in lijstp)
                        {
                            if (element.Perioden == pelement.Perioden && element.RegioCode.Trim() == pelement.RegioCode.Trim())
                            {
                                this.preventie.Series["Relatie preventie en diefstal"].Points.AddXY(Convert.ToInt32(element.GeregistreerdeDiefstallenPer1000Inw), pelement.LichtBijAfwezigheid);
                            }
                        }
                    }
                    this.preventie.ChartAreas[0].AxisX.Title = "Aantal diefstallen per 1000 inwoners";
                    this.preventie.ChartAreas[0].AxisY.Title = "Percentage van preventiefgedrag";
                } 
                
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

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CheckAllProvinces.Checked == true)
            {
                checkBoxDrenthe.Checked = true;
                checkBoxFlevoland.Checked = true;
                checkBoxFriesland.Checked = true;
                checkBoxGelderland.Checked = true;
                checkBoxGroningen.Checked = true;
                checkBoxLimburg.Checked = true;
                checkBoxNoordBrabant.Checked = true;
                checkBoxNoordholland.Checked = true;
                checkBoxOverijssel.Checked = true;
                checkBoxZeeland.Checked = true;
                checkBoxZuidholland.Checked = true;
                checkBoxUtrecht.Checked = true;
            }
            else
            {
                checkBoxDrenthe.Checked = false;
                checkBoxFlevoland.Checked = false;
                checkBoxFriesland.Checked = false;
                checkBoxGelderland.Checked = false;
                checkBoxGroningen.Checked = false;
                checkBoxLimburg.Checked = false;
                checkBoxNoordBrabant.Checked = false;
                checkBoxNoordholland.Checked = false;
                checkBoxOverijssel.Checked = false;
                checkBoxZeeland.Checked = false;
                checkBoxZuidholland.Checked = false;
                checkBoxUtrecht.Checked = false;
            }
        }

        private List<string> CheckYears()
        {
            var perioden = new List<string>();
            if (yearone.Checked == true)
            {
                perioden.Add("2012JJ00");
            }
            if (yeartwo.Checked == true)
            {
                perioden.Add("2013JJ00");
            }
            if (yearthree.Checked == true)
            {
                perioden.Add("2014JJ00");
            }
            if (yearfour.Checked == true)
            {
                perioden.Add("2015JJ00");
            }
            if (yearfive.Checked == true)
            {
                perioden.Add("2016JJ00");
            }
            if (yearsix.Checked == true)
            {
                perioden.Add("2017JJ00");
            }
            return perioden;
            
        }
        private List<string> CheckCheckboxes()
        {
            var regios = new List<string>();

            if (checkBoxGroningen.Checked)
            {
                regios.Add(Regio.Groningen);
            }

            if (checkBoxFriesland.Checked)
            {
                regios.Add(Regio.Friesland);
            }

            if (checkBoxDrenthe.Checked)
            {
                regios.Add(Regio.Drenthe);
            }

            if (checkBoxOverijssel.Checked)
            {
                regios.Add(Regio.Overijssel);
            }

            if (checkBoxFlevoland.Checked)
            {
                regios.Add(Regio.Flevoland);
            }

            if (checkBoxGelderland.Checked)
            {
                regios.Add(Regio.Gelderland);
            }

            if (checkBoxUtrecht.Checked)
            {
                regios.Add(Regio.Utrecht);
            }

            if (checkBoxNoordholland.Checked)
            {
                regios.Add(Regio.NoordHolland);
            }

            if (checkBoxZuidholland.Checked)
            {
                regios.Add(Regio.ZuidHolland);
            }

            if (checkBoxZeeland.Checked)
            {
                regios.Add(Regio.Zeeland);
            }

            if (checkBoxNoordBrabant.Checked)
            {
                regios.Add(Regio.NoordBrabant);
            }

            if (checkBoxLimburg.Checked)
            {
                regios.Add(Regio.Limburg);
            }

            return regios;
        }

        private int aantalsoort(string soort)
        {
            int getal = 0;
            if (soort.Contains("Totaal")) {
                getal = 1;
            } else if (soort.Contains("inwoners")) {
                getal = 2;
            }
            return getal;
        }
    }
    
}
