using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjectData.Converter;
using ProjectData.Database;
using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Database.Entities;

namespace ProjectData
{
    public partial class Form1 : Form
    {
        private static readonly int SUCCESS = 0;
        private static readonly int MYSQL_ERROR = 101;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        public Form1()
        {
            InitializeComponent();
        }

        private void OnShown(object sender, System.EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void OnBackgroundLoad(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            int result = BackgroundOperation(bw);

            if (result == SUCCESS)
            {
                SetSubLabelText("Loading finished, now redirecting to MainMenu");
                UpdateProgressBar(100);
                OpenMainMenu();
            }
            else if (result == MYSQL_ERROR)
            {
                SetSubLabelColor(Color.Red);
                SetSubLabelText("MySQL Error please check your database server!");
                UpdateProgressBarColor(2);
            }

            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
            
        }

        private int BackgroundOperation(BackgroundWorker bw)
        {
            int result = -1;
            bool exit = false;

            while (!bw.CancellationPending)
            {
                try
                {
                    SetSubLabelText("Testing connection");
                    UpdateProgressBar(5);
                    DatabaseUtil.GetInstance().TestConnection();
                    Thread.Sleep(200);

                    SetSubLabelText("Check the current data");
                    //TODO check current data in database and insert new records if needed.
                    UpdateProgressBar(20);
                    RegioDao regioDao = new RegioDao();
                    regioDao.FindAll();

                    UpdateProgressBar(30);
                    Thread.Sleep(1000);

                    SetSubLabelText("Still checking the data");
                    UpdateProgressBar(50);
                    Thread.Sleep(1000);

                    UpdateProgressBar(52);
                    Thread.Sleep(1000);
                }
                catch (MySqlException)
                {
                    result = MYSQL_ERROR;
                    exit = true;
                    break;
                }

                SetSubLabelText("Getting closer");
                UpdateProgressBar(55);
                Thread.Sleep(1000);

                UpdateProgressBar(75);
                Thread.Sleep(1000);

                SetSubLabelText("Almost done");
                UpdateProgressBar(90);
                Thread.Sleep(1000);

                result = SUCCESS;
                exit = true;

                if (exit)
                {
                    break;
                }
            }

            return result;
        }

        private void OpenMainMenu()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    //Execute on main thread
                    OpenMainMenu();
                });
                return;
            }

            Form2 frm = new Form2();
            frm.Location = this.Location;
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
            this.Hide();
        }

        private void UpdateProgressBarColor(int color)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    //Execute on main thread
                    UpdateProgressBarColor(color);
                });
                return;
            }

            SendMessage(progressBar.Handle, 1040, (IntPtr)color, IntPtr.Zero);
        }

        private void UpdateProgressBar(int progress)
        {
            //Check if we are not on the main thread
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    //Execute on main thread
                    UpdateProgressBar(progress);
                });
                return;
            }

            progressBar.Value = progress;
        }

        private void SetSubLabelText(string text)
        {
            //Check if we are not on the main thread
            if (InvokeRequired)
            {
                Invoke((MethodInvoker) delegate() 
                {
                    //Execute on main thread
                    SetSubLabelText(text);
                });
                return;
            }

            subLabel.Text = text;
        }

        private void SetSubLabelColor(Color color)
        {
            //Check if we are not on the main thread
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    //Execute on main thread
                    SetSubLabelColor(color);
                });
                return;
            }

            subLabel.ForeColor = color;
        }
    }
}
