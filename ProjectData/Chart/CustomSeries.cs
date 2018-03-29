using System.Windows.Forms.DataVisualization.Charting;
using ProjectData.Database.Entities;

namespace ProjectData.Chart
{
    public class CustomSeries : Series
    {
        public CustomSeries(string regio)
        {
            ChartArea = "ChartArea1";
            EmptyPointStyle.LabelForeColor = System.Drawing.Color.White;
            LabelBackColor = System.Drawing.Color.White;
            LabelForeColor = System.Drawing.Color.White;
            Legend = "Legend1";
            Name = "Diefstal " + regio;
            SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
        }

    }
}
