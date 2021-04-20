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

        public frmCharacterSelector(CompteJoueurDTO j)
        {
            connectedPlayer = j;
            InitializeComponent();

            //Remplir la liste selon le user
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;

            herosDataGridView.DataSource = j.Heros;
            herosDataGridView.Refresh();
            joueurService = new JoueurServiceClient();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCreateHero frmCreateHero = new frmCreateHero();
            this.Enabled = false;
            frmCreateHero.ShowDialog();

            if (frmCreateHero.DialogResult == DialogResult.OK)
                Hero = frmCreateHero.createdHero;

            this.Enabled = true;
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