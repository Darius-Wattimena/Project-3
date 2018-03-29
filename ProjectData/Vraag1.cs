using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            //TODO reset all the checkboxes and comboboxes

            checkBoxDrenthe.Checked = false;
            checkBoxFlevoland.Checked = false;
            checkBoxFriesland.Checked = false;
            checkBoxGelderland.Checked = false;
            checkBoxGroningen.Checked = false;
            checkBoxLimburg.Checked = false;
            checkBoxNoordBrabant.Checked = false;
            checkBoxNoordholland.Checked = false;
            checkBoxOverijssel.Checked = false;
            checkBoxUtrecht.Checked = false;
            checkBoxZeeland.Checked = false;
            checkBoxZuidholland.Checked = false;

            comboBoxJaartal.SelectedIndex = -1;
            comboBoxSoortDiefstal.SelectedIndex = -1;

            
        }

        private void buttonZoekFilter_Click(object sender, EventArgs e)
        {
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
            gemiddeldInkomenCriteria.RegioList = regios;
            gemiddeldInkomenCriteria.Periode = jaartal;

            var diefstallen = _diefstalDao.FindByNewCriteria(diefstalCriteria);
            diefstallen = DiefstalUtil.SumDiefstallenForeachRegio(diefstallen);

            var gemiddeldInkomens = _gemiddeldInkomenDao.FindByNewCriteria(gemiddeldInkomenCriteria);
            gemiddeldInkomens = GemiddeldInkomenUtil.ParInkomenForeachRegio(gemiddeldInkomens);

            LoadChart(diefstallen, gemiddeldInkomens);
        }

        private void LoadChart(List<Diefstal> diefstallen, List<GemiddeldInkomen> gemiddeldInkomens)
        {
            //Clear the chart
            WinForm.ClearChart(chart1);

            //Define the label position of the regio names
            var labelPosition = 0.5d;

            foreach (var diefstal in diefstallen)
            {
                if (diefstal.RegioCode == EnumUtil.GetEnumDescription(RegioCode.NietInTeDelen)) continue;

                if (!string.IsNullOrEmpty(diefstal.TotaalGeregistreerdeDiefstallen))
                {
                    //Add the diefstallen to the chart
                    chart1.Series[0].Points.Add(int.Parse(diefstal.TotaalGeregistreerdeDiefstallen));

                    //Get the regio name and place it on the chart
                    var regioName = RegioUtil.GetRegioName(diefstal.RegioCode);
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(labelPosition, labelPosition + 1d, regioName);
                    labelPosition++;
                }
            }

            foreach (var gemiddeldInkomen in gemiddeldInkomens)
            {
                if (gemiddeldInkomen.RegioCode == EnumUtil.GetEnumDescription(RegioCode.NietInTeDelen)) continue;

                var value = Convert.ToInt32(gemiddeldInkomen.GemiddeldPersoonlijkInkomen * 100);
                chart1.Series[1].Points.Add(value);
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
