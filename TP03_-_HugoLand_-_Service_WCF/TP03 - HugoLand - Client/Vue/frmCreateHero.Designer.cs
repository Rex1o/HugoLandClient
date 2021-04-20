
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeroCreator
            // 
            this.lblHeroCreator.AutoSize = true;
            this.lblHeroCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.lblHeroCreator.Location = new System.Drawing.Point(16, 28);
            this.lblHeroCreator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeroCreator.Name = "lblHeroCreator";
            this.lblHeroCreator.Size = new System.Drawing.Size(137, 26);
            this.lblHeroCreator.TabIndex = 0;
            this.lblHeroCreator.Text = "Hero Creator";
            // 
            // lblStrength
            // 
            this.lblStrength.AutoSize = true;
            this.lblStrength.Location = new System.Drawing.Point(19, 100);
            this.lblStrength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStrength.Name = "lblStrength";
            this.lblStrength.Size = new System.Drawing.Size(50, 13);
            this.lblStrength.TabIndex = 1;
            this.lblStrength.Text = "Strength:";
            // 
            // txtStr
            // 
            this.txtStr.Enabled = false;
            this.txtStr.Location = new System.Drawing.Point(18, 118);
            this.txtStr.Margin = new System.Windows.Forms.Padding(2);
            this.txtStr.Name = "txtStr";
            this.txtStr.Size = new System.Drawing.Size(132, 20);
            this.txtStr.TabIndex = 2;
            // 
            // txtDex
            // 
            this.txtDex.Enabled = false;
            this.txtDex.Location = new System.Drawing.Point(18, 158);
            this.txtDex.Margin = new System.Windows.Forms.Padding(2);
            this.txtDex.Name = "txtDex";
            this.txtDex.Size = new System.Drawing.Size(132, 20);
            this.txtDex.TabIndex = 4;
            // 
            // lblDexterity
            // 
            this.lblDexterity.AutoSize = true;
            this.lblDexterity.Location = new System.Drawing.Point(19, 141);
            this.lblDexterity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDexterity.Name = "lblDexterity";
            this.lblDexterity.Size = new System.Drawing.Size(51, 13);
            this.lblDexterity.TabIndex = 3;
            this.lblDexterity.Text = "Dexterity:";
            // 
            // txtVit
            // 
            this.txtVit.Enabled = false;
            this.txtVit.Location = new System.Drawing.Point(18, 203);
            this.txtVit.Margin = new System.Windows.Forms.Padding(2);
            this.txtVit.Name = "txtVit";
            this.txtVit.Size = new System.Drawing.Size(132, 20);
            this.txtVit.TabIndex = 6;
            // 
            // lblVitality
            // 
            this.lblVitality.AutoSize = true;
            this.lblVitality.Location = new System.Drawing.Point(19, 185);
            this.lblVitality.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVitality.Name = "lblVitality";
            this.lblVitality.Size = new System.Drawing.Size(40, 13);
            this.lblVitality.TabIndex = 5;
            this.lblVitality.Text = "Vitality:";
            // 
            // txtInt
            // 
            this.txtInt.Enabled = false;
            this.txtInt.Location = new System.Drawing.Point(18, 249);
            this.txtInt.Margin = new System.Windows.Forms.Padding(2);
            this.txtInt.Name = "txtInt";
            this.txtInt.Size = new System.Drawing.Size(132, 20);
            this.txtInt.TabIndex = 8;
            // 
            // lblIntegrity
            // 
            this.lblIntegrity.AutoSize = true;
            this.lblIntegrity.Location = new System.Drawing.Point(19, 232);
            this.lblIntegrity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIntegrity.Name = "lblIntegrity";
            this.lblIntegrity.Size = new System.Drawing.Size(47, 13);
            this.lblIntegrity.TabIndex = 7;
            this.lblIntegrity.Text = "Integrity:";
            // 
            // cmbWorld
            // 
            this.cmbWorld.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorld.FormattingEnabled = true;
            this.cmbWorld.Location = new System.Drawing.Point(18, 292);
            this.cmbWorld.Margin = new System.Windows.Forms.Padding(2);
            this.cmbWorld.Name = "cmbWorld";
            this.cmbWorld.Size = new System.Drawing.Size(133, 21);
            this.cmbWorld.TabIndex = 9;
            this.cmbWorld.SelectedIndexChanged += new System.EventHandler(this.cmbWorld_SelectedIndexChanged);
            // 
            // cmbClasse
            // 
            this.cmbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClasse.FormattingEnabled = true;
            this.cmbClasse.Location = new System.Drawing.Point(16, 332);
            this.cmbClasse.Margin = new System.Windows.Forms.Padding(2);
            this.cmbClasse.Name = "cmbClasse";
            this.cmbClasse.Size = new System.Drawing.Size(133, 21);
            this.cmbClasse.TabIndex = 10;
            this.cmbClasse.SelectedIndexChanged += new System.EventHandler(this.cmbClasse_SelectedIndexChanged);
            // 
            // lblWorld
            // 
            this.lblWorld.AutoSize = true;
            this.lblWorld.Location = new System.Drawing.Point(16, 275);
            this.lblWorld.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorld.Name = "lblWorld";
            this.lblWorld.Size = new System.Drawing.Size(38, 13);
            this.lblWorld.TabIndex = 11;
            this.lblWorld.Text = "World:";
            // 
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Location = new System.Drawing.Point(14, 318);
            this.lblClasse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(41, 13);
            this.lblClasse.TabIndex = 13;
            this.lblClasse.Text = "Classe:";
            // 
            // btnCreateHero
            // 
            this.btnCreateHero.Location = new System.Drawing.Point(16, 361);
            this.btnCreateHero.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateHero.Name = "btnCreateHero";
            this.btnCreateHero.Size = new System.Drawing.Size(65, 35);
            this.btnCreateHero.TabIndex = 14;
            this.btnCreateHero.Text = "Create";
            this.btnCreateHero.UseVisualStyleBackColor = true;
            this.btnCreateHero.Click += new System.EventHandler(this.btnCreateHero_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(18, 80);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(132, 20);
            this.txtName.TabIndex = 16;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(19, 62);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(88, 361);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 35);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCreateHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(161, 408);
            this.Controls.Add(this.btnCancel);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCreateHero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button btnCancel;
    }
}