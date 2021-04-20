
namespace HugoWorld_Client.Vue
{
    partial class frmCreateHero
    {
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
            this.lblHeroCreator = new System.Windows.Forms.Label();
            this.lblStrength = new System.Windows.Forms.Label();
            this.txtStr = new System.Windows.Forms.TextBox();
            this.txtDex = new System.Windows.Forms.TextBox();
            this.lblDexterity = new System.Windows.Forms.Label();
            this.txtVit = new System.Windows.Forms.TextBox();
            this.lblVitality = new System.Windows.Forms.Label();
            this.txtInt = new System.Windows.Forms.TextBox();
            this.lblIntegrity = new System.Windows.Forms.Label();
            this.cmbWorld = new System.Windows.Forms.ComboBox();
            this.cmbClasse = new System.Windows.Forms.ComboBox();
            this.lblWorld = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.btnCreateHero = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeroCreator
            // 
            this.lblHeroCreator.AutoSize = true;
            this.lblHeroCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.lblHeroCreator.Location = new System.Drawing.Point(21, 35);
            this.lblHeroCreator.Name = "lblHeroCreator";
            this.lblHeroCreator.Size = new System.Drawing.Size(177, 32);
            this.lblHeroCreator.TabIndex = 0;
            this.lblHeroCreator.Text = "Hero Creator";
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(25, 123);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(66, 17);
            this.lblStrength.TabIndex = 1;
            this.lblStrength.Text = "Strength:";
            // 
            // txtStr
            // 
            this.txtStr.Enabled = false;
            this.txtStr.Location = new System.Drawing.Point(24, 145);
            this.txtStr.Name = "txtStr";
            this.txtStr.Size = new System.Drawing.Size(174, 22);
            this.txtStr.TabIndex = 2;
            // 
            // txtDex
            // 
            this.txtDex.Enabled = false;
            this.txtDex.Location = new System.Drawing.Point(24, 195);
            this.txtDex.Name = "txtDex";
            this.txtDex.Size = new System.Drawing.Size(174, 22);
            this.txtDex.TabIndex = 4;
            // 
            // lblDexterity
            // 
            this.lblDexterity.AutoSize = true;
            this.lblDexterity.Location = new System.Drawing.Point(25, 173);
            this.lblDexterity.Name = "lblDexterity";
            this.lblDexterity.Size = new System.Drawing.Size(67, 17);
            this.lblDexterity.TabIndex = 3;
            this.lblDexterity.Text = "Dexterity:";
            // 
            // txtVit
            // 
            this.txtVit.Enabled = false;
            this.txtVit.Location = new System.Drawing.Point(24, 250);
            this.txtVit.Name = "txtVit";
            this.txtVit.Size = new System.Drawing.Size(174, 22);
            this.txtVit.TabIndex = 6;
            // 
            // lblVitality
            // 
            this.lblVitality.AutoSize = true;
            this.lblVitality.Location = new System.Drawing.Point(25, 228);
            this.lblVitality.Name = "lblVitality";
            this.lblVitality.Size = new System.Drawing.Size(53, 17);
            this.lblVitality.TabIndex = 5;
            this.lblVitality.Text = "Vitality:";
            // 
            // txtInt
            // 
            this.txtInt.Enabled = false;
            this.txtInt.Location = new System.Drawing.Point(24, 307);
            this.txtInt.Name = "txtInt";
            this.txtInt.Size = new System.Drawing.Size(174, 22);
            this.txtInt.TabIndex = 8;
            // 
            // lblIntegrity
            // 
            this.lblIntegrity.AutoSize = true;
            this.lblIntegrity.Location = new System.Drawing.Point(25, 285);
            this.lblIntegrity.Name = "lblIntegrity";
            this.lblIntegrity.Size = new System.Drawing.Size(62, 17);
            this.lblIntegrity.TabIndex = 7;
            this.lblIntegrity.Text = "Integrity:";
            // 
            // cmbWorld
            // 
            this.cmbWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorld.FormattingEnabled = true;
            this.cmbWorld.Location = new System.Drawing.Point(24, 359);
            this.cmbWorld.Name = "cmbWorld";
            this.cmbWorld.Size = new System.Drawing.Size(176, 24);
            this.cmbWorld.TabIndex = 9;
            this.cmbWorld.SelectedIndexChanged += new System.EventHandler(this.cmbWorld_SelectedIndexChanged);
            // 
            // cmbClasse
            // 
            this.cmbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasse.FormattingEnabled = true;
            this.cmbClasse.Location = new System.Drawing.Point(22, 409);
            this.cmbClasse.Name = "cmbClasse";
            this.cmbClasse.Size = new System.Drawing.Size(176, 24);
            this.cmbClasse.TabIndex = 10;
            this.cmbClasse.SelectedIndexChanged += new System.EventHandler(this.cmbClasse_SelectedIndexChanged);
            // 
            // lblWorld
            // 
            this.lblWorld.AutoSize = true;
            this.lblWorld.Location = new System.Drawing.Point(21, 339);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(49, 17);
            this.lblWorld.TabIndex = 11;
            this.lblWorld.Text = "World:";
            // 
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Location = new System.Drawing.Point(19, 391);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(54, 17);
            this.lblClasse.TabIndex = 13;
            this.lblClasse.Text = "Classe:";
            // 
            // btnCreateHero
            // 
            this.btnCreateHero.Location = new System.Drawing.Point(21, 444);
            this.btnCreateHero.Name = "btnCreateHero";
            this.btnCreateHero.Size = new System.Drawing.Size(176, 43);
            this.btnCreateHero.TabIndex = 14;
            this.btnCreateHero.Text = "Create Hero";
            this.btnCreateHero.UseVisualStyleBackColor = true;
            this.btnCreateHero.Click += new System.EventHandler(this.btnCreateHero_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(24, 98);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(174, 22);
            this.txtName.TabIndex = 16;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 76);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name:";
            // 
            // frmCreateHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 502);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCreateHero);
            this.Controls.Add(this.lblClasse);
            this.Controls.Add(this.lblWorld);
            this.Controls.Add(this.cmbClasse);
            this.Controls.Add(this.cmbWorld);
            this.Controls.Add(this.txtInt);
            this.Controls.Add(this.lblIntegrity);
            this.Controls.Add(this.txtVit);
            this.Controls.Add(this.lblVitality);
            this.Controls.Add(this.txtDex);
            this.Controls.Add(this.lblDexterity);
            this.Controls.Add(this.txtStr);
            this.Controls.Add(this.lblStrength);
            this.Controls.Add(this.lblHeroCreator);
            this.Name = "frmCreateHero";
            this.Text = "CreateHero";
            this.Load += new System.EventHandler(this.frmCreateHero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeroCreator;
        private System.Windows.Forms.Label lblStrength;
        private System.Windows.Forms.TextBox txtStr;
        private System.Windows.Forms.TextBox txtDex;
        private System.Windows.Forms.Label lblDexterity;
        private System.Windows.Forms.TextBox txtVit;
        private System.Windows.Forms.Label lblVitality;
        private System.Windows.Forms.TextBox txtInt;
        private System.Windows.Forms.Label lblIntegrity;
        private System.Windows.Forms.ComboBox cmbWorld;
        private System.Windows.Forms.ComboBox cmbClasse;
        private System.Windows.Forms.Label lblWorld;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.Button btnCreateHero;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
    }
}