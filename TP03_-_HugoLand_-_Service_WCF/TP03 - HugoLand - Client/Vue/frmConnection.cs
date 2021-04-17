//using HugoWorld.Services;
using System;
using System.Windows.Forms;
using TP01_Library.Controllers;

namespace HugoWorld {

    public partial class frmConnection : Form {
        //private readonly JoueurServiceClient joueurService;

        /// <summary>
        /// Description : Initialise le formulaire de connexion
        /// </summary>
        public frmConnection()
        {
            //joueurService = new JoueurServiceClient();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmConnection_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Description : Tente d'authentifier l'utilisateur
        /// Date : 2021-03-08
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connection_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string password = txt_password.Text;

            CompteJoueurController controller = new CompteJoueurController();
            string reponse = controller.ValiderConnexion(password, username);
            //string reponse = joueurService.Connection(password, username);

            if (reponse == "INVALIDE")
            {
                MessageBox.Show("USERNAME IS INVALID", "Connection error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (reponse == "SUCCESS")
            {
                //Outil.SetActiveUser(joueurService.GetAccountByName(username));
                Outil.SetActiveUser(controller.TrouverJoueur(username));
                //if (joueurService.GetAccountByName(username).TypeUtilisateur == 2)
                if (controller.TrouverJoueur(username).TypeUtilisateur == 2)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("YOU DO NOT HAVE PERMISSIONS TO LOG IN", "Connection error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (reponse == "INCORRECT")
            {
                MessageBox.Show("PASSWORD IS INVALID", "Connection error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}