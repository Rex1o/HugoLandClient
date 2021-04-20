using HugoWorld.BLL;
using HugoWorld_Client.HL_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HugoWorld_Client.Vue {
    public partial class frmCreateHero : Form {
        private readonly ClasseServiceClient classeService;
        private readonly MondeServiceClient mondeService;
        private readonly HeroServiceClient heroService;
        private int _BaseStrength,_BaseDexterity, _BaseVitality, _BaseIntegrity;
        private int _TotalStrength, _TotalDexterity, _TotalVitality, _TotalIntegrity;

        private Random _rnd = new Random();
        private List<ClasseDTO> _WorldClass = new List<ClasseDTO>();
        private ClasseDTO _SelectedClass;
        public HeroDTO createdHero { get; set; }
        
        public frmCreateHero()
        {
            InitializeComponent();
            classeService = new ClasseServiceClient();
            mondeService = new MondeServiceClient();
            heroService = new HeroServiceClient();

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

                MessageBox.Show("Hero successfully added!", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.None,
    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while adding the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}