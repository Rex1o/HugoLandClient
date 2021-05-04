using HugoWorld.BLL;
using HugoWorld_Client.HL_Services;
using HugoWorld_Client.Vue;
using System;
using System.Windows.Forms;

namespace HugoWorld.Vue {

    public partial class frmCharacterSelector : Form {
        public HeroDTO Hero { get; set; }
        public string ErrorMsg { get; set; }
        private CompteJoueurDTO connectedPlayer;
        private readonly JoueurServiceClient joueurService;
        private readonly HeroServiceClient heroService;

        public frmCharacterSelector(CompteJoueurDTO j) {
            connectedPlayer = j;
            InitializeComponent();

            //Remplir la liste selon le user
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            herosDataGridView.DataSource = connectedPlayer.Heros;
            herosDataGridView.Refresh();
            joueurService = new JoueurServiceClient();
            heroService = new HeroServiceClient();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmCreateHero frmCreateHero = new frmCreateHero();
            this.Enabled = false;
            frmCreateHero.ShowDialog();

            if (frmCreateHero.DialogResult == DialogResult.OK)
                Hero = frmCreateHero.createdHero;

            this.Enabled = true;
            RefreshData();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            try {
                if (herosDataGridView.SelectedRows.Count > 0) {
                    //Start game with selected hero
                    Hero = herosDataGridView.SelectedRows[0].DataBoundItem as HeroDTO;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else {
                    this.DialogResult = DialogResult.Cancel;
                    this.ErrorMsg = "Please a choose a character!";
                    this.Close();
                }
            } catch (Exception ex) {
                this.DialogResult = DialogResult.Abort;
                this.ErrorMsg = ex.Message;
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DialogResult confirmation = Outils.ShowInfoMessage("Please confirm", "Confirmation", MessageBoxButtons.YesNo);
            if (confirmation == DialogResult.Yes) {
                try {
                    if (herosDataGridView.SelectedRows.Count > 0) {
                        //Start game with selected hero
                        if (heroService.DeleteHeroById(((HeroDTO)herosDataGridView.SelectedRows[0].DataBoundItem).Id)) {
                            this.DialogResult = DialogResult.OK;
                            Hero = null;
                        } else {
                            this.DialogResult = DialogResult.Abort;
                            this.ErrorMsg = "There's been an error while deleting your hero!";
                            this.Close();
                        }
                    } else {
                        this.DialogResult = DialogResult.Cancel;
                        this.ErrorMsg = "Please a choose a character!";
                    }
                    RefreshData();
                } catch (Exception ex) {
                    this.DialogResult = DialogResult.Abort;
                    this.ErrorMsg = ex.Message;
                    this.Close();
                }
            }
        }

        private void RefreshData() {
            Outils.SetActiveUser(joueurService.GetAccountByName(connectedPlayer.NomJoueur));
            connectedPlayer = Outils.GetActiveUser();
            herosDataGridView.DataSource = connectedPlayer.Heros;
            herosDataGridView.Refresh();
        }
    }
}