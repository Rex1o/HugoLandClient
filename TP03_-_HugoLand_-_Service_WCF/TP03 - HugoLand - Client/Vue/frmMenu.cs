using HugoWorld.BLL;
using HugoWorld.Vue;
using HugoWorld_Client.HL_Services;
using System;
using System.Windows.Forms;

namespace HugoWorld_Client.Vue {
    public partial class frmMenu : Form {
        private readonly JoueurServiceClient joueurService;

        private bool _editMode;
        private CompteJoueurDTO connectedPlayer;
        private HeroDTO _currentHero;
        public HeroDTO currentHero
        {
            get => _currentHero;
            set
            {
                _currentHero = value;
                btnPlay.Enabled = true;
            }
        }

        public frmMenu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            joueurService = new JoueurServiceClient();
            _editMode = false;
            connectedPlayer = Outils.GetActiveUser();
            FillMenu();
            courrielTextBox.ReadOnly = false;
            nomJoueurTextBox.ReadOnly = false;
            nomTextBox.ReadOnly = false;
            prenomTextBox.ReadOnly = false;

            if (connectedPlayer.TypeUtilisateur > 0)
                btnClasses.Visible = true;
        }

        private void btnHeroes_Click(object sender, EventArgs e)
        {
            //Show Character Selector/Creator Here
            frmCharacterSelector chSelect = new frmCharacterSelector(Outils.GetActiveUser());
            this.Enabled = false;
            chSelect.ShowDialog();

            if (chSelect.DialogResult == DialogResult.OK)
                currentHero = chSelect.Hero;

            this.Enabled = true;
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            frmClassList frmClassList = new frmClassList();
            this.Enabled = false;
            frmClassList.ShowDialog();

            this.Enabled = true;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            return;
        }

        private void FillMenu()
        {
            courrielTextBox.Text = connectedPlayer.Courriel;
            nomJoueurTextBox.Text = connectedPlayer.NomJoueur;
            nomTextBox.Text = connectedPlayer.Nom;
            prenomTextBox.Text = connectedPlayer.Prenom;

            Refresh();
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to quit? Unsaved progress will be lost.",
                      "Closing the world save", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }
            }
        }
    }
}
