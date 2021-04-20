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

            if (connectedPlayer.TypeUtilisateur > 0)
                btnClasses.Visible = true;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            SwitchMode(!_editMode);
        }

        private void btnConfirm_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(courrielTextBox.Text))
                    connectedPlayer.Courriel = courrielTextBox.Text;
                else
                {
                    ErreurEmptyValueMsgBox();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(nomJoueurTextBox.Text))
                    connectedPlayer.NomJoueur = nomJoueurTextBox.Text;
                else
                {
                    ErreurEmptyValueMsgBox();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(nomTextBox.Text))
                    connectedPlayer.Nom = nomTextBox.Text;
                else
                {
                    ErreurEmptyValueMsgBox();
                    return;
                }

                if (!string.IsNullOrWhiteSpace(prenomTextBox.Text))
                    connectedPlayer.Prenom = prenomTextBox.Text;
                else
                {
                    ErreurEmptyValueMsgBox();
                    return;
                }

                joueurService.EditAccount(connectedPlayer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while modifying the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnHeroes_Click(object sender, EventArgs e)
        {
            //Show Character Selector/Creator Here
            frmCharacterSelector chSelect = new frmCharacterSelector(Outils.GetActiveUser());
            this.Enabled = false;
            chSelect.ShowDialog();

            //if there is an error with the selection
            while (chSelect.DialogResult == DialogResult.Abort)
            {
                DialogResult r = MessageBox.Show(chSelect.ErrorMsg, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (r == DialogResult.Retry)
                    chSelect.ShowDialog();
                else
                    this.Close();
            }

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

        private void ErreurEmptyValueMsgBox()
        {
            MessageBox.Show("Please enter something, it can't be empty!", "WARNING!", MessageBoxButtons.OK);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FillMenu()
        {
            courrielTextBox.Text = connectedPlayer.Courriel;
            nomJoueurTextBox.Text = connectedPlayer.NomJoueur;
            nomTextBox.Text = connectedPlayer.Nom;
            prenomTextBox.Text = connectedPlayer.Prenom;

            Refresh();
        }

        private void SwitchMode(bool mode)
        {
            // if true, edit mode
            if (mode)
            {
                courrielTextBox.ReadOnly = false;
                nomJoueurTextBox.ReadOnly = false;
                nomTextBox.ReadOnly = false;
                prenomTextBox.ReadOnly = false;

                btnConfirm.Visible = true;
                _editMode = false;
                Refresh();
            }
            else // else false, readonly
            {
                courrielTextBox.ReadOnly = true;
                nomJoueurTextBox.ReadOnly = true;
                nomTextBox.ReadOnly = true;
                prenomTextBox.ReadOnly = true;

                btnConfirm.Visible = false;
                _editMode = true;
                Refresh();
            }
        }

    }
}
