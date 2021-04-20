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
        int _BaseStrength;
        int _BaseDexterity;
        int _BaseVitality;
        int _BaseIntegrity;

        int _TotalStrength;
        int _TotalDexterity;
        int _TotalVitality;
        int _TotalIntegrity;
        Random  _rnd = new Random();
        ClasseDTO[] _WorldClass;

        public frmCreateHero()
        {
            InitializeComponent();
        }

        private void btnCreateHero_Click(object sender, EventArgs e)
        {

        }

        private void frmCreateHero_Load(object sender, EventArgs e)
        {
            cmbWorld.DataSource = mondeService.ListWorlds().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
            string itemstr = cmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

            _WorldClass = classeService.GetClassDTOFromMap(id).ToArray();
            cmbClasse.DataSource = _WorldClass.Select(x => x.Id + " : " + x.NomClasse).ToArray();

            _BaseStrength = _rnd.Next(0, 21);
            _BaseDexterity = _rnd.Next(0, 21);
            _BaseVitality = _rnd.Next(0, 21);
            _BaseIntegrity = _rnd.Next(0, 21);
            UpdateStats();
        }

        private void cmbWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemstr = cmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

            cmbClasse.DataSource = classeService.GetClassDTOFromMap(id).ToList().Select(x => x.Id + " : " + x.NomClasse).ToArray();
            UpdateStats();
        }

        private void cmbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStats();
        }

        private void UpdateStats()
        {
            
            //_TotalStrength = 
        }
    }
}