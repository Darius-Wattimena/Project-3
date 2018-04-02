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
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProjectData
{
    public partial class Vraag3 : Form
    {
        private readonly DiefstalDao _diefstalDao = new DiefstalDao();
        private readonly VeiligheidDao _veiligheidDao = new VeiligheidDao();

        public Vraag3()
        {
            InitializeComponent();
        }

        private void buttonQuestion1_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag1>();
        }

        private void buttonQuestion2_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Vraag2>();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            WinForm.OpenForm<Form2>();
        }

        private void buttonResetFilter_Click(object sender, EventArgs e)
        {
            ResetCheckBoxes();
            ResetComboBoxes();
            buttonZoekFilter_Click(sender, e);
        }

        private void buttonResetProvincies_Click(object sender, EventArgs e)
        {
            ResetCheckBoxes();
            buttonZoekFilter_Click(sender, e);
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

            //Get diefstallen using the criteria
            var diefstallen = _diefstalDao.FindByNewCriteria(diefstalCriteria);
            diefstallen = DiefstalUtil.SumDiefstallenForeachRegio(diefstallen);

            //Get the picked veiligheid from the combobox
            var pickedVeiligheid = comboBoxSoortVeiligheid.GetItemText(comboBoxSoortVeiligheid.SelectedItem);

            var veiligheidCriteria = new VeiligheidCriteria();
            veiligheidCriteria.RegioList = regios;
            veiligheidCriteria.Periode = jaartal;

            var veiligheids = _veiligheidDao.FindByNewCriteria(veiligheidCriteria);

            LoadChart(diefstallen, veiligheids, pickedVeiligheid);
        }

        private void LoadChart(List<Diefstal> diefstallen, List<Veiligheid> veiligheids, string pickedVeiligheid)
        {
            //Clear form
            WinForm.ClearChart(chart1);

            //Set label position for regio names
            var labelPosition = 0.5d;

            //Get veiligheid soort by pickedone from combobox
            var veiligheidSoort = VeiligheidUtil.PickVeiligheidType(pickedVeiligheid);

            //Iterate over diefstallen list
            for (int i = 0; i < diefstallen.Count; i++)
            {
                var diefstal = diefstallen[i];
                var veiligheid = veiligheids[i];

                //Check if TotaalGeregistreerdeDiefstallen is not empty and regio is not equal to NietInTeDelen
                if (!string.IsNullOrEmpty(diefstal.TotaalGeregistreerdeDiefstallen) && !diefstal.RegioCode.Contains(EnumUtil.GetEnumDescription(RegioCode.NietInTeDelen)))
                {
                    //Get int value from the TotaalGeregistreerdeDiefstallen
                    var totaalDiefstallen = int.Parse(diefstal.TotaalGeregistreerdeDiefstallen);

                    //Add TotaalGeregistreerdeDiefstallen to first chart series
                    chart1.Series[0].Points.Add(totaalDiefstallen);

                    //Get the regio name from the code saved in diefstal and add the name using a customlabel
                    var regioName = RegioUtil.GetRegioName(diefstal.RegioCode);
                    chart1.ChartAreas[0].AxisX.CustomLabels.Add(labelPosition, labelPosition + 1d, regioName);
                    labelPosition++;

                    //Get the field from veiligheid with the given enum value
                    var item = VeiligheidUtil.GetVeiligheidValueByType(veiligheid, veiligheidSoort);
                    var itemValue = VeiligheidUtil.GetVeiligheidValueFromString(item);

                    //Recalculate the percentage so the value is visable in the chart
                    //var calculatedItemValue = (totaalDiefstallen / 100) * itemValue;

                    //Add the recalculated percentage to the 2nd series
                    chart1.Series[1].Points.Add(itemValue);
                }
            }
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

        private void Vraag3Loaded(object sender, EventArgs e)
        {
            comboBoxSoortVeiligheid.SelectedIndex = 0;
            chart1.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisY2.LabelStyle.Format = "{0.00} %";
            chart1.Series[1].YAxisType = AxisType.Secondary;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY2.MajorGrid.LineWidth = 0;
        }

        private void ResetCheckBoxes()
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
            checkBoxUtrecht.Checked = false;
            checkBoxZeeland.Checked = false;
            checkBoxZuidholland.Checked = false;
        }

        private void ResetComboBoxes()
        {
            comboBoxSoortDiefstal.SelectedIndex = -1;
            comboBoxSoortVeiligheid.SelectedIndex = 0;
            comboBoxJaartal.SelectedIndex = -1;
        }
    }
}
