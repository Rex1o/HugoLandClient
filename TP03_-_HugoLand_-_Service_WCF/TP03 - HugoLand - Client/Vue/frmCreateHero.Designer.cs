
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblDexterity = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblVitality = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblIntegrity = new System.Windows.Forms.Label();
            this.cmbWorld = new System.Windows.Forms.ComboBox();
            this.cmbClasse = new System.Windows.Forms.ComboBox();
            this.lblWorld = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.btnCreateHero = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(24, 145);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 22);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(24, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 22);
            this.textBox2.TabIndex = 4;
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
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(24, 250);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(174, 22);
            this.textBox3.TabIndex = 6;
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
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(24, 307);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(174, 22);
            this.textBox4.TabIndex = 8;
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
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(24, 98);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(174, 22);
            this.textBox5.TabIndex = 16;
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
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnCreateHero);
            this.Controls.Add(this.lblClasse);
            this.Controls.Add(this.lblWorld);
            this.Controls.Add(this.cmbClasse);
            this.Controls.Add(this.cmbWorld);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.lblIntegrity);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.lblVitality);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblDexterity);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblDexterity;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblVitality;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblIntegrity;
        private System.Windows.Forms.ComboBox cmbWorld;
        private System.Windows.Forms.ComboBox cmbClasse;
        private System.Windows.Forms.Label lblWorld;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.Button btnCreateHero;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label lblName;
    }
}