using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
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
using System.Windows.Forms.DataVisualization.Charting;
using ProjectData.Database.Entities;

namespace ProjectData
{
    public partial class Vraag1 : Form
    {
        private readonly DiefstalDao _diefstalDao = new DiefstalDao();
        private readonly GemiddeldInkomenDao _gemiddeldInkomenDao = new GemiddeldInkomenDao();

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
            //Clear the chart
            WinForm.ClearChart(chart1);

            //Get the soort diefstal from the combobox and get the enum value
            var soortDiefstal = GetDiefstalSoort(comboBoxSoortDiefstal.GetItemText(comboBoxSoortDiefstal.SelectedItem));
            var soortDiefstalNumber = EnumUtil.GetIndex(soortDiefstal);

            //Add a "0" to the string when there is only one digit
            var soortDiefstalValue = soortDiefstalNumber.ToString().Length == 1
                ? "0" + soortDiefstalNumber
                : soortDiefstalNumber.ToString();

            //Get the jaartal from the combobox
            var jaartal = JaartalUtil.GetJaartalCode(comboBoxJaartal.GetItemText(comboBoxJaartal.SelectedItem));
            var regios = CheckCheckboxes();

            //Setup diefstal criteria
            var diefstalCriteria = new DiefstalCriteria();
            diefstalCriteria.NoEmptyValues = true;
            diefstalCriteria.RegioList = regios;
            diefstalCriteria.Soortdiefstal = soortDiefstalValue;
            diefstalCriteria.Periode = jaartal;

            //Setup gemiddeld inkomen criteria
            var gemiddeldInkomenCriteria = new GemiddeldInkomenCriteria();

            var diefstallen = _diefstalDao.FindByNewCriteria(diefstalCriteria);
            var gemiddeldInkomens = _gemiddeldInkomenDao.FindByNewCriteria(gemiddeldInkomenCriteria);

            double i = 0.5;

            diefstallen = DiefstalUtil.SumDiefstallenForeachRegio(diefstallen);
            foreach (var diefstal in diefstallen)
            {
                if (!string.IsNullOrEmpty(diefstal.TotaalGeregistreerdeDiefstallen))
                {
                    chart1.Series[0].Points.Add(int.Parse(diefstal.TotaalGeregistreerdeDiefstallen));
                    var regioName = RegioUtil.GetRegioName(diefstal.RegioCode);
                    chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(i, i + 1d, regioName);
                    i++;
                }
                else
                {
                    chart1.Series[0].Points.Add(0);
                }
            }

            gemiddeldInkomens = GemiddeldInkomenUtil.SumDiefstallenForeachRegio(gemiddeldInkomens);

            foreach (var gemiddeldInkomen in gemiddeldInkomens)
            {
                chart1.Series[1].Points.Add((int) Math.Truncate(gemiddeldInkomen.GemiddeldBesteedbaarInkomen));
            }
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

        private static DiefstalSoort GetDiefstalSoort(string soortDiefstal)
        {
            var soorten = EnumUtil.GetValues<DiefstalSoort>();
            foreach (var soort in soorten)
            {
                var description = EnumUtil.GetEnumDescription(soort);
                if (description.Equals(soortDiefstal))
                {
                    return soort;
                }
            }

            return DiefstalSoort.AlleDiefstallen;
        }
    }
}
