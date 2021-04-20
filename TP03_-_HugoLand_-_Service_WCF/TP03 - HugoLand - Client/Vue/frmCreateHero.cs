using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using HugoWorld_Client.HL_Services;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoWorld_Client.Vue
{
    public partial class frmCreateHero : Form
    {
        private ClasseServiceClient classeService = new ClasseServiceClient();
        private MondeServiceClient mondeService = new MondeServiceClient();

        public frmCreateHero()
        {
            InitializeComponent();
        }

        private void btnCreateHero_Click(object sender, EventArgs e)
        {

        }

        private void frmCreateHero_Load(object sender, EventArgs e)
        {
            cmbWorld.DataSource = mondeService.GetMondeDTOs().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
            string itemstr = cmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

            cmbClasse.DataSource = classeService.GetClassDTOFromMap(id).ToList().Select(x => x.Id + " : " + x.NomClasse).ToArray();
        }

        private void cmbWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemstr = cmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

            cmbClasse.DataSource = classeService.GetClassDTOFromMap(id).ToList().Select(x => x.Id + " : " + x.NomClasse).ToArray();
        }
    }
}