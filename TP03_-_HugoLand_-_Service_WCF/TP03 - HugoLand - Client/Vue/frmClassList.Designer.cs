
namespace HugoWorld_Client.Vue {
    partial class frmClassList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClassList));
            this.editDescriptionLabel = new System.Windows.Forms.Label();
            this.editIdLabel = new System.Windows.Forms.Label();
            this.editNomClasseLabel = new System.Windows.Forms.Label();
            this.editStatBaseDexLabel = new System.Windows.Forms.Label();
            this.editStatBaseIntLabel = new System.Windows.Forms.Label();
            this.editStatBaseStrLabel = new System.Windows.Forms.Label();
            this.editStatBaseVitaliteLabel = new System.Windows.Forms.Label();
            this.classeDTOGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MondeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classeDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.newDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.newIdLabel = new System.Windows.Forms.Label();
            this.newNomClasseTextBox = new System.Windows.Forms.TextBox();
            this.newStatBaseDexTextBox = new System.Windows.Forms.TextBox();
            this.newStatBaseIntTextBox = new System.Windows.Forms.TextBox();
            this.newStatBaseStrTextBox = new System.Windows.Forms.TextBox();
            this.newStatBaseVitaliteTextBox = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEditClass = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.mondeDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mondeDTOComboBox = new System.Windows.Forms.ComboBox();
            this.editMondeLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.classeDTOGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classeDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mondeDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // editDescriptionLabel
            // 
            resources.ApplyResources(this.editDescriptionLabel, "editDescriptionLabel");
            this.editDescriptionLabel.Name = "editDescriptionLabel";
            // 
            // editIdLabel
            // 
            resources.ApplyResources(this.editIdLabel, "editIdLabel");
            this.editIdLabel.Name = "editIdLabel";
            // 
            // editNomClasseLabel
            // 
            resources.ApplyResources(this.editNomClasseLabel, "editNomClasseLabel");
            this.editNomClasseLabel.Name = "editNomClasseLabel";
            // 
            // editStatBaseDexLabel
            // 
            resources.ApplyResources(this.editStatBaseDexLabel, "editStatBaseDexLabel");
            this.editStatBaseDexLabel.Name = "editStatBaseDexLabel";
            // 
            // editStatBaseIntLabel
            // 
            resources.ApplyResources(this.editStatBaseIntLabel, "editStatBaseIntLabel");
            this.editStatBaseIntLabel.Name = "editStatBaseIntLabel";
            // 
            // editStatBaseStrLabel
            // 
            resources.ApplyResources(this.editStatBaseStrLabel, "editStatBaseStrLabel");
            this.editStatBaseStrLabel.Name = "editStatBaseStrLabel";
            // 
            // editStatBaseVitaliteLabel
            // 
            resources.ApplyResources(this.editStatBaseVitaliteLabel, "editStatBaseVitaliteLabel");
            this.editStatBaseVitaliteLabel.Name = "editStatBaseVitaliteLabel";
            // 
            // classeDTOGridView
            // 
            this.classeDTOGridView.AutoGenerateColumns = false;
            this.classeDTOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.classeDTOGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.MondeId});
            this.classeDTOGridView.DataSource = this.classeDTOBindingSource;
            resources.ApplyResources(this.classeDTOGridView, "classeDTOGridView");
            this.classeDTOGridView.Name = "classeDTOGridView";
            this.classeDTOGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn2.FillWeight = 15F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NomClasse";
            this.dataGridViewTextBoxColumn4.FillWeight = 15F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StatBaseDex";
            this.dataGridViewTextBoxColumn5.FillWeight = 15F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "StatBaseInt";
            this.dataGridViewTextBoxColumn6.FillWeight = 15F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn6, "dataGridViewTextBoxColumn6");
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StatBaseStr";
            this.dataGridViewTextBoxColumn7.FillWeight = 15F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn7, "dataGridViewTextBoxColumn7");
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "StatBaseVitalite";
            this.dataGridViewTextBoxColumn8.FillWeight = 15F;
            resources.ApplyResources(this.dataGridViewTextBoxColumn8, "dataGridViewTextBoxColumn8");
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MondeId
            // 
            this.MondeId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MondeId.DataPropertyName = "MondeId";
            resources.ApplyResources(this.MondeId, "MondeId");
            this.MondeId.Name = "MondeId";
            this.MondeId.ReadOnly = true;
            this.MondeId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // classeDTOBindingSource
            // 
            this.classeDTOBindingSource.DataSource = typeof(HugoWorld_Client.HL_Services.ClasseDTO);
            // 
            // newDescriptionTextBox
            // 
            this.newDescriptionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "Description", true));
            resources.ApplyResources(this.newDescriptionTextBox, "newDescriptionTextBox");
            this.newDescriptionTextBox.Name = "newDescriptionTextBox";
            // 
            // newIdLabel
            // 
            this.newIdLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "Id", true));
            resources.ApplyResources(this.newIdLabel, "newIdLabel");
            this.newIdLabel.Name = "newIdLabel";
            // 
            // newNomClasseTextBox
            // 
            this.newNomClasseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "NomClasse", true));
            resources.ApplyResources(this.newNomClasseTextBox, "newNomClasseTextBox");
            this.newNomClasseTextBox.Name = "newNomClasseTextBox";
            // 
            // newStatBaseDexTextBox
            // 
            this.newStatBaseDexTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "StatBaseDex", true));
            resources.ApplyResources(this.newStatBaseDexTextBox, "newStatBaseDexTextBox");
            this.newStatBaseDexTextBox.Name = "newStatBaseDexTextBox";
            // 
            // newStatBaseIntTextBox
            // 
            this.newStatBaseIntTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "StatBaseInt", true));
            resources.ApplyResources(this.newStatBaseIntTextBox, "newStatBaseIntTextBox");
            this.newStatBaseIntTextBox.Name = "newStatBaseIntTextBox";
            // 
            // newStatBaseStrTextBox
            // 
            this.newStatBaseStrTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "StatBaseStr", true));
            resources.ApplyResources(this.newStatBaseStrTextBox, "newStatBaseStrTextBox");
            this.newStatBaseStrTextBox.Name = "newStatBaseStrTextBox";
            // 
            // newStatBaseVitaliteTextBox
            // 
            this.newStatBaseVitaliteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.classeDTOBindingSource, "StatBaseVitalite", true));
            resources.ApplyResources(this.newStatBaseVitaliteTextBox, "newStatBaseVitaliteTextBox");
            this.newStatBaseVitaliteTextBox.Name = "newStatBaseVitaliteTextBox";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEditClass
            // 
            resources.ApplyResources(this.btnEditClass, "btnEditClass");
            this.btnEditClass.Name = "btnEditClass";
            this.btnEditClass.UseVisualStyleBackColor = true;
            this.btnEditClass.Click += new System.EventHandler(this.btnEditClass_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // mondeDTOBindingSource
            // 
            this.mondeDTOBindingSource.DataSource = typeof(HugoWorld_Client.HL_Services.MondeDTO);
            // 
            // mondeDTOComboBox
            // 
            this.mondeDTOComboBox.DataSource = this.mondeDTOBindingSource;
            this.mondeDTOComboBox.DisplayMember = "Description";
            this.mondeDTOComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.mondeDTOComboBox, "mondeDTOComboBox");
            this.mondeDTOComboBox.Name = "mondeDTOComboBox";
            this.mondeDTOComboBox.ValueMember = "Classes";
            // 
            // editMondeLabel
            // 
            resources.ApplyResources(this.editMondeLabel, "editMondeLabel");
            this.editMondeLabel.Name = "editMondeLabel";
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmClassList
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.editMondeLabel);
            this.Controls.Add(this.mondeDTOComboBox);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEditClass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.editDescriptionLabel);
            this.Controls.Add(this.newDescriptionTextBox);
            this.Controls.Add(this.editIdLabel);
            this.Controls.Add(this.newIdLabel);
            this.Controls.Add(this.editNomClasseLabel);
            this.Controls.Add(this.newNomClasseTextBox);
            this.Controls.Add(this.editStatBaseDexLabel);
            this.Controls.Add(this.newStatBaseDexTextBox);
            this.Controls.Add(this.editStatBaseIntLabel);
            this.Controls.Add(this.newStatBaseIntTextBox);
            this.Controls.Add(this.editStatBaseStrLabel);
            this.Controls.Add(this.newStatBaseStrTextBox);
            this.Controls.Add(this.editStatBaseVitaliteLabel);
            this.Controls.Add(this.newStatBaseVitaliteTextBox);
            this.Controls.Add(this.classeDTOGridView);
            this.Name = "frmClassList";
            ((System.ComponentModel.ISupportInitialize)(this.classeDTOGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classeDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mondeDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource classeDTOBindingSource;
        private System.Windows.Forms.DataGridView classeDTOGridView;
        private System.Windows.Forms.TextBox newDescriptionTextBox;
        private System.Windows.Forms.Label newIdLabel;
        private System.Windows.Forms.TextBox newNomClasseTextBox;
        private System.Windows.Forms.TextBox newStatBaseDexTextBox;
        private System.Windows.Forms.TextBox newStatBaseIntTextBox;
        private System.Windows.Forms.TextBox newStatBaseStrTextBox;
        private System.Windows.Forms.TextBox newStatBaseVitaliteTextBox;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEditClass;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label editIdLabel;
        private System.Windows.Forms.Label editNomClasseLabel;
        private System.Windows.Forms.Label editStatBaseDexLabel;
        private System.Windows.Forms.Label editStatBaseIntLabel;
        private System.Windows.Forms.Label editStatBaseStrLabel;
        private System.Windows.Forms.Label editStatBaseVitaliteLabel;
        private System.Windows.Forms.Label editDescriptionLabel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MondeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.BindingSource mondeDTOBindingSource;
        private System.Windows.Forms.ComboBox mondeDTOComboBox;
        private System.Windows.Forms.Label editMondeLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button btnExit;
    }
}