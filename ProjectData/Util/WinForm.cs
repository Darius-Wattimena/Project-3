using System;
using System.Windows.Forms;

namespace ProjectData.Util
{
    public class WinForm
    {
        public static Form current;

        /// <summary>
        /// Opens a new Form on the location of the current one and closes the old one.
        /// </summary>
        /// <typeparam name="T">Instance of Form</typeparam>
        /// <param name="currentForm">The current form that is open</param>
        /// <returns>The new open form</returns>
        public static T OpenForm<T>() where T : Form, new()
        {
            T result = new T
            {
                Location = current.Location,
                StartPosition = FormStartPosition.Manual
            };

            result.Show();
            current.Hide();

            current = result;

            return result;
        }

        /// <summary>
        /// Execute methods on the main thread.
        /// </summary>
        /// <param name="methods">Methods that need to be executed on the main thread</param>
        public static void Execute(params Action[] methods)
        {
            // Check if we are not on the main thread
            if (current.InvokeRequired)
            {
                current.Invoke((MethodInvoker)delegate ()
                {
                    //Execute on main thread
                    foreach(Action method in methods)
                    {
                        method();
                    }
                });
            }
            else
            {
                foreach (Action method in methods)
                {
                    method();
                }
            }
        }

        public static void ClearChart(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            foreach (var serie in chart.Series)
            {
                serie.Points.Clear();
            }

            foreach (var chartArea in chart.ChartAreas)
            {
                foreach (var axes in chartArea.Axes)
                {
                    axes.CustomLabels.Clear();
                }
            }
        }

        public static void ClearChartFull(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.Series.Clear();
        }
    }
}
