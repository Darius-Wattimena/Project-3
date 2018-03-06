using System.Windows.Forms;
using ProjectData.Converter;
using ProjectData.Database.Criterias;
using ProjectData.Database.Daos;
using ProjectData.Database.Entities;

namespace ProjectData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var regioDao = new RegioDao();
            var regios = regioDao.FindAll();

            if (regios.Count == 0)
            {
                Regio regio = new Regio
                {
                    Code = "TEST01",
                    Name = "Test Regio 1"
                };

                regioDao.Save(regio);
            }

            //Hallo

            var regioCriteria = new RegioCriteria {Code = "TEST01"};
            var regios2 = regioDao.FindByCriteria(regioCriteria);

            RegioConverter.Convert();
        }
    }
}
