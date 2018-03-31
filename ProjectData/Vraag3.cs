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

            var diefstallen = _diefstalDao.FindByNewCriteria(diefstalCriteria);
            diefstallen = DiefstalUtil.SumDiefstallenForeachRegio(diefstallen);

            LoadChart(diefstallen);

        }

        private void LoadChart(List<Diefstal> diefstallen)
        {
            WinForm.ClearChart(chart1);
            var labelPosition = 0.5d;

            foreach (var diefstal in diefstallen)
            {
                if (!string.IsNullOrEmpty(diefstal.TotaalGeregistreerdeDiefstallen) && !diefstal.RegioCode.Contains(EnumUtil.GetEnumDescription(RegioCode.NietInTeDelen)))
                {
                    chart1.Series[0].Points.Add(int.Parse(diefstal.TotaalGeregistreerdeDiefstallen));
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
    }
}
