using HugoWorld_Client.HL_Services;
using System;
using System.Windows.Forms;

namespace HugoWorld.Vue {

    public partial class frmCharacterSelector : Form {
        public HeroDTO Hero { get; set; }
        public string ErrorMsg { get; set; }
        private HeroDTO _selectedHero;
        private CompteJoueurDTO _user;

        public frmCharacterSelector(CompteJoueurDTO j)
        {
            _user = j;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Remplir la liste selon le user

            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnOk.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add character
        }

        private void lstCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int HeroID = int.Parse(lstCharacters.SelectedItem.ToString().Substring(4, lstCharacters.SelectedItem.ToString().IndexOf(' ')));
                //_selectedHero = GetHeroById();
                btnOk.Enabled = true;
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                this.ErrorMsg = ex.Message;
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Start game with selected hero
            Hero = _selectedHero;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}