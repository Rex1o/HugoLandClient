﻿using HugoWorld.BLL;
using HugoWorld_Client.HL_Services;
using System;
using System.Windows.Forms;

namespace HugoWorld {

    public partial class frmConnection : Form {
        //Service a utiliser
        private readonly JoueurServiceClient joueurService;
        private string reponse = "NewAttempt";

        /// <summary>
        /// Description : Initialise le formulaire de connexion
        /// </summary>
        public frmConnection()
        {
            joueurService = new JoueurServiceClient();
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

            this.Cursor = Cursors.WaitCursor;
            try
            {
                reponse = joueurService.Connection(username, password);
                if (reponse == "INVALIDE")
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("USERNAME IS INVALID", "Connection error",
        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                else if (reponse == "SUCCESS")
                {
                    try
                    {
                        Outils.SetActiveUser(joueurService.GetAccountByName(username));
                        this.Close();
                    }
                    catch
                    {
                        this.Cursor = Cursors.Default;
                        MessageBox.Show("Services Are Not Accessible ", "Connection error",
        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else if (reponse == "INCORRECT")
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("PASSWORD IS INVALID", "Connection error",
        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("PLEASE RECONNECT " + ex.Message, "Connection error",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void frmConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (reponse != "SUCCESS")
            {
                this.DialogResult = DialogResult.No;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}