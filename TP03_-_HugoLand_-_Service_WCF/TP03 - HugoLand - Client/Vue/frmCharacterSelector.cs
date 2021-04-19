using HugoWorld_Client.HL_Services;
using System;
using System.Windows.Forms;

namespace HugoWorld.Vue {

    public partial class frmCharacterSelector : Form {
        public HeroDTO Hero { get; set; }
        public string ErrorMsg { get; set; }
        private HeroDTO _selectedHero = new HeroDTO();
        private CompteJoueurDTO _user;
        private readonly JoueurServiceClient joueurService;

        public frmCharacterSelector(CompteJoueurDTO j)
        {
            _user = j;
            InitializeComponent();
            herosDataGridView.DataSource = j.Heros;
            herosDataGridView.Refresh();
            joueurService = new JoueurServiceClient();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Remplir la liste selon le user
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add character
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (herosDataGridView.SelectedRows.Count > 0)
                {
                    //Start game with selected hero
                    Hero = herosDataGridView.SelectedRows[0].DataBoundItem as HeroDTO;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.ErrorMsg = "Please a choose a character!";
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                this.ErrorMsg = ex.Message;
                this.Close();
            }
        }
    }
}