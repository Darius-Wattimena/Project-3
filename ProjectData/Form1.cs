using System.Windows.Forms;
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

            var regioCriteria = new RegioCriteria {Code = "TEST01"};
            var regios2 = regioDao.FindByCriteria(regioCriteria);
        }
    }
}
