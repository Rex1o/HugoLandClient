namespace HugoWorld.Vue
{
    partial class frmCharacterSelector
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
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lstCharacters = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListTitle.Location = new System.Drawing.Point(12, 9);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(191, 32);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Character List";
            // 
            // lstCharacters
            // 
            this.lstCharacters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCharacters.FormattingEnabled = true;
            this.lstCharacters.ItemHeight = 22;
            this.lstCharacters.Location = new System.Drawing.Point(18, 68);
            this.lstCharacters.Name = "lstCharacters";
            this.lstCharacters.Size = new System.Drawing.Size(559, 312);
            this.lstCharacters.TabIndex = 1;
            this.lstCharacters.SelectedIndexChanged += new System.EventHandler(this.lstCharacters_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdd.BackgroundImage = global::HugoWorld_Client.Properties.Resources.GreenPlusBtn;
            this.btnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Location = new System.Drawing.Point(583, 68);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 52);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(645, 406);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(143, 32);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Select";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmCharacterSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstCharacters);
            this.Controls.Add(this.lblListTitle);
            this.Name = "frmCharacterSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCharacterSelector";
            this.TransparencyKey = System.Drawing.Color.White;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.ListBox lstCharacters;
        public System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOk;
    }
}