
namespace HugoWorld_Client.Vue {
    partial class frmMenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label courrielLabel;
            System.Windows.Forms.Label nomLabel;
            System.Windows.Forms.Label nomJoueurLabel;
            System.Windows.Forms.Label prenomLabel;
            this.compteJoueurDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courrielTextBox = new System.Windows.Forms.TextBox();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.nomJoueurTextBox = new System.Windows.Forms.TextBox();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.btnHeroes = new System.Windows.Forms.Button();
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            courrielLabel = new System.Windows.Forms.Label();
            nomLabel = new System.Windows.Forms.Label();
            nomJoueurLabel = new System.Windows.Forms.Label();
            prenomLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.compteJoueurDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // courrielLabel
            // 
            courrielLabel.AutoSize = true;
            courrielLabel.Location = new System.Drawing.Point(17, 74);
            courrielLabel.Name = "courrielLabel";
            courrielLabel.Size = new System.Drawing.Size(35, 13);
            courrielLabel.TabIndex = 1;
            courrielLabel.Text = "Email:";
            // 
            // nomLabel
            // 
            nomLabel.AutoSize = true;
            nomLabel.Location = new System.Drawing.Point(17, 126);
            nomLabel.Name = "nomLabel";
            nomLabel.Size = new System.Drawing.Size(58, 13);
            nomLabel.TabIndex = 3;
            nomLabel.Text = "First name:";
            // 
            // nomJoueurLabel
            // 
            nomJoueurLabel.AutoSize = true;
            nomJoueurLabel.Location = new System.Drawing.Point(17, 100);
            nomJoueurLabel.Name = "nomJoueurLabel";
            nomJoueurLabel.Size = new System.Drawing.Size(68, 13);
            nomJoueurLabel.TabIndex = 5;
            nomJoueurLabel.Text = "Player name:";
            // 
            // prenomLabel
            // 
            prenomLabel.AutoSize = true;
            prenomLabel.Location = new System.Drawing.Point(17, 152);
            prenomLabel.Name = "prenomLabel";
            prenomLabel.Size = new System.Drawing.Size(59, 13);
            prenomLabel.TabIndex = 7;
            prenomLabel.Text = "Last name:";
            // 
            // compteJoueurDTOBindingSource
            // 
            this.compteJoueurDTOBindingSource.DataSource = typeof(HugoWorld_Client.HL_Services.CompteJoueurDTO);
            // 
            // courrielTextBox
            // 
            this.courrielTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compteJoueurDTOBindingSource, "Courriel", true));
            this.courrielTextBox.Location = new System.Drawing.Point(90, 71);
            this.courrielTextBox.Name = "courrielTextBox";
            this.courrielTextBox.ReadOnly = true;
            this.courrielTextBox.Size = new System.Drawing.Size(100, 20);
            this.courrielTextBox.TabIndex = 2;
            // 
            // nomTextBox
            // 
            this.nomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compteJoueurDTOBindingSource, "Nom", true));
            this.nomTextBox.Location = new System.Drawing.Point(90, 123);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.ReadOnly = true;
            this.nomTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomTextBox.TabIndex = 4;
            // 
            // nomJoueurTextBox
            // 
            this.nomJoueurTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compteJoueurDTOBindingSource, "NomJoueur", true));
            this.nomJoueurTextBox.Location = new System.Drawing.Point(90, 97);
            this.nomJoueurTextBox.Name = "nomJoueurTextBox";
            this.nomJoueurTextBox.ReadOnly = true;
            this.nomJoueurTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomJoueurTextBox.TabIndex = 6;
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.compteJoueurDTOBindingSource, "Prenom", true));
            this.prenomTextBox.Location = new System.Drawing.Point(90, 149);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.ReadOnly = true;
            this.prenomTextBox.Size = new System.Drawing.Size(100, 20);
            this.prenomTextBox.TabIndex = 8;
            // 
            // btnHeroes
            // 
            this.btnHeroes.Location = new System.Drawing.Point(215, 71);
            this.btnHeroes.Name = "btnHeroes";
            this.btnHeroes.Size = new System.Drawing.Size(75, 23);
            this.btnHeroes.TabIndex = 9;
            this.btnHeroes.Text = "Heroes";
            this.btnHeroes.UseVisualStyleBackColor = true;
            this.btnHeroes.Click += new System.EventHandler(this.btnHeroes_Click);
            // 
            // btnClasses
            // 
            this.btnClasses.Location = new System.Drawing.Point(215, 101);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(75, 23);
            this.btnClasses.TabIndex = 10;
            this.btnClasses.Text = "Classes";
            this.btnClasses.UseVisualStyleBackColor = true;
            this.btnClasses.Visible = false;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(20, 175);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(115, 175);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 12;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "MAIN MENU";
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(215, 149);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 48);
            this.btnPlay.TabIndex = 14;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 209);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClasses);
            this.Controls.Add(this.btnHeroes);
            this.Controls.Add(courrielLabel);
            this.Controls.Add(this.courrielTextBox);
            this.Controls.Add(nomLabel);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(nomJoueurLabel);
            this.Controls.Add(this.nomJoueurTextBox);
            this.Controls.Add(prenomLabel);
            this.Controls.Add(this.prenomTextBox);
            this.Name = "frmMenu";
            ((System.ComponentModel.ISupportInitialize)(this.compteJoueurDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource compteJoueurDTOBindingSource;
        private System.Windows.Forms.TextBox courrielTextBox;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.TextBox nomJoueurTextBox;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.Button btnHeroes;
        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPlay;
    }
}