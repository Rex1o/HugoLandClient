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
using HugoWorld.BLL;

namespace HugoWorld_Client.Vue
{
    public partial class frmCreateHero : Form
    {
        private ClasseServiceClient classeService = new ClasseServiceClient();
        private MondeServiceClient mondeService = new MondeServiceClient();
        private HeroServiceClient heroService = new HeroServiceClient();
        int _BaseStrength;
        int _BaseDexterity;
        int _BaseVitality;
        int _BaseIntegrity;

        int _TotalStrength;
        int _TotalDexterity;
        int _TotalVitality;
        int _TotalIntegrity;
        Random _rnd = new Random();
        List<ClasseDTO> _WorldClass = new List<ClasseDTO>();
        ClasseDTO _SelectedClass;

        public frmCreateHero()
        {
            InitializeComponent();
            cmbWorld.DataSource = mondeService.GetWorldsForSelection().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
            string itemstr = cmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

            _WorldClass = classeService.GetClassDTOFromMap(id).ToList();
            cmbClasse.DataSource = _WorldClass.Select(x => x.Id + " : " + x.NomClasse).ToArray();

            _BaseStrength = _rnd.Next(0, 21);
            _BaseDexterity = _rnd.Next(0, 21);
            _BaseVitality = _rnd.Next(0, 21);
            _BaseIntegrity = _rnd.Next(0, 21);
            UpdateUI();
        }

        private void btnCreateHero_Click(object sender, EventArgs e)
        {
            CompteJoueurDTO activeAccount = Outils.GetActiveUser();

            HeroDTO newHero = new HeroDTO()
            {
                CompteJoueurId = activeAccount.Id,
                x = 8,
                y = 8,
                StatDex = _TotalDexterity,
                StatInt = _TotalIntegrity,
                StatStr = _TotalStrength,
                StatVitalite = _TotalVitality,
                ClasseId = _SelectedClass.Id,
                Experience = 0,
                Niveau = 1,
                NomHero = txtName.Text
            };

            try
            {
                heroService.AddHeroToDataBase(newHero);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while adding the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

        }

        private void frmCreateHero_Load(object sender, EventArgs e)
        {

        }

        private void cmbWorld_SelectedIndexChanged(object sender, EventArgs e)
        {
            string itemstr = cmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

            cmbClasse.DataSource = classeService.GetClassDTOFromMap(id).ToList().Select(x => x.Id + " : " + x.NomClasse).ToArray();
            UpdateUI();
        }

        private void cmbClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {

            if (string.IsNullOrEmpty(cmbClasse.Text))
            {
                btnCreateHero.Enabled = false;
            }
            else
            {


                string itemstr = cmbClasse.SelectedItem.ToString();
                int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));
                _SelectedClass = _WorldClass.FirstOrDefault(x => x.Id == id);
                if (!(_SelectedClass == null))
                {
                    _TotalStrength = _BaseStrength + _SelectedClass.StatBaseStr;
                    _TotalDexterity = _BaseDexterity + _SelectedClass.StatBaseDex;
                    _TotalVitality = _BaseVitality + _SelectedClass.StatBaseVitalite;
                    _TotalIntegrity = _BaseIntegrity + _SelectedClass.StatBaseInt;

                    txtStr.Text = _TotalStrength.ToString();
                    txtDex.Text = _TotalDexterity.ToString();
                    txtVit.Text = _TotalVitality.ToString();
                    txtInt.Text = _TotalIntegrity.ToString();
                    if (string.IsNullOrEmpty(txtName.Text))
                    {
                        btnCreateHero.Enabled = false;
                    }
                    else
                    {
                        btnCreateHero.Enabled = true;
                    }
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }
}