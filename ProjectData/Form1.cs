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
using ProjectData.Util;

namespace ProjectData
{
    public partial class Form1 : Form
    {
        private static readonly int SUCCESS = 0;
        private static readonly int MYSQL_ERROR = 101;

        private readonly RegioDao _regioDao = new RegioDao();
        private readonly DiefstalDao _diefstalDao = new DiefstalDao();
        private readonly PreventieDao _preventieDao = new PreventieDao();
        private readonly GemiddeldInkomenDao _inkomenDao = new GemiddeldInkomenDao();
        private readonly VeiligheidDao _veiligheidDao = new VeiligheidDao();

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
                WinForm.Execute(() =>
                {
                    SetSubLabelText("Loading finished, now redirecting to MainMenu");
                    UpdateProgressBar(100);
                    OpenMainMenu();
                });
            }
            else if (result == MYSQL_ERROR)
            {
                WinForm.Execute(() =>
                {
                    SetSubLabelColor(Color.Red);
                    SetSubLabelText("MySQL Error please check your database server and/or your config file!");
                    UpdateProgressBarColor(2);
                });
            }

            if (bw.CancellationPending)
            {
                WinForm.Execute(() => FlipRetryAndQuitButton());
                e.Cancel = true;
            }
            
        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            WinForm.Execute(() =>
            {
                UpdateProgressBar(0);
                UpdateProgressBarColor(1);
                SetSubLabelText("Retrying");
                backgroundWorker1.RunWorkerAsync();
                FlipRetryAndQuitButton();
            });
        }
        
        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int BackgroundOperation(BackgroundWorker bw)
        {
            var result = -1;
            var exit = false;

            while (!bw.CancellationPending)
            {
                try
                {
                    WinForm.Execute(() =>
                    {
                        SetSubLabelText("Testing connection");
                        UpdateProgressBar(5);
                    });
                    DatabaseUtil.TestConnection();
                    
                    WinForm.Execute(() => 
                    {
                        SetSubLabelText("Check the current data");
                        UpdateProgressBar(20);
                    });

                    if (_regioDao.CountAll() == 0)
                    {
                        ConverterUtil.ConvertRegio();
                    }

                    WinForm.Execute(() =>
                    {
                        SetSubLabelText("Loading diefstallen");
                        UpdateProgressBar(26);
                    });

                    if (_diefstalDao.CountAll() == 0)
                    {
                        ConverterUtil.ConvertDiefstal();
                    }

                    WinForm.Execute(() =>
                    {
                        SetSubLabelText("Loading preventiedata");
                        UpdateProgressBar(42);
                    });

                    if (_preventieDao.CountAll() == 0)
                    {
                        ConverterUtil.ConvertPreventie();
                    }

                    WinForm.Execute(() =>
                    {
                        SetSubLabelText("Loading gemiddeld inkomen");
                        UpdateProgressBar(58);
                    });

                    if (_inkomenDao.CountAll() == 0)
                    {
                        ConverterUtil.ConvertGemiddeldInkomen();
                    }

                    WinForm.Execute(() =>
                    {
                        SetSubLabelText("Loading Veiligheid data");
                        UpdateProgressBar(72);
                    });

                    if (_veiligheidDao.CountAll() == 0)
                    {
                        ConverterUtil.ConvertVeiligheid();
                    }

                }
                catch (MySqlException ex)
                {
                    result = MYSQL_ERROR;
                    Log.Error(ex.Message);
                    bw.CancelAsync();
                    break;
                }

                WinForm.Execute(() =>
                {
                    SetSubLabelText("Almost done");
                    UpdateProgressBar(90);
                });

                result = SUCCESS;
                break;
            }

            return result;
        }

        private void OpenMainMenu()
        {
            WinForm.OpenForm<Form2>();
        }

        private void FlipRetryAndQuitButton()
        {
            retryButton.Enabled = !retryButton.Enabled;
            retryButton.Visible = !retryButton.Visible;

            quitButton.Enabled = !quitButton.Enabled;
            quitButton.Visible = !quitButton.Visible;
        }

        private void UpdateProgressBarColor(int color)
        {
            SendMessage(progressBar.Handle, 1040, (IntPtr)color, IntPtr.Zero);
        }

        private void UpdateProgressBar(int progress)
        {
            progressBar.Value = progress;
        }

        private void SetSubLabelText(string text)
        {
            subLabel.Text = text;
        }

        private void SetSubLabelColor(Color color)
        {
            subLabel.ForeColor = color;
        }
    }
}
