using FluentValidation.Results;
using Hugoworld.Validators;
using HugoWorld.BLL;
using HugoWorld.Vue;
using HugoWorld_Client.HL_Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HugoWorld_Client.Vue {

    public partial class frmClassList : Form {
        private int _Strength;
        private int _Dexterity;
        private int _Vitality;
        private int _Intelligence;

        private readonly ClasseServiceClient classeService;
        private readonly MondeServiceClient mondeService;
        private readonly ClasseDTOValidator classeValidator;
        private CompteJoueurDTO connectedPlayer;

        public frmClassList() {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            classeService = new ClasseServiceClient();
            mondeService = new MondeServiceClient();
            classeValidator = new ClasseDTOValidator();
            connectedPlayer = Outils.GetActiveUser();

            Init();
            SwitchMode();
        }

        private void btnEditClass_Click(object sender, EventArgs e) {
            try {
                if (classeDTOGridView.SelectedRows.Count > 0) {
                    SwitchMode();
                    FillEditForm(classeDTOGridView.SelectedRows[0].DataBoundItem as ClasseDTO);
                } else {
                    Outils.ShowErrorMessage("Please choose a character!", "WARNING!");
                }
            } catch (Exception) {
                Outils.ShowErrorMessage("An error occured while modifying the class to the database", "ERROR");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e) {

            if (ValidateInput()) {

                ClasseDTO classeDTO = new ClasseDTO() {
                    Id = int.Parse(newIdLabel.Text),
                    NomClasse = newNomClasseTextBox.Text,
                    Description = newDescriptionTextBox.Text,
                    StatBaseDex = _Dexterity,
                    StatBaseInt = _Intelligence,
                    StatBaseStr = _Strength,
                    StatBaseVitalite = _Vitality
                };

                ValidationResult result = classeValidator.Validate(classeDTO);

                if (result.IsValid) {
                    try {
                        classeService.EditClass(classeDTO);
                        SwitchMode();
                        Init();
                    } catch (Exception) {
                        Outils.ShowErrorMessage("An error occured while modifying the class to the database", "ERROR");
                    }
                } else {
                    Outils.ShowErrorMessage(string.Join("\n", result.Errors.ToList()), "Errors");
                }
            } else {
                Outils.ShowErrorMessage("Please enter valid informations.", "Errors");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e) {
            SwitchMode();
        }

        private void btnCreate_Click(object sender, EventArgs e) {
            ClassCreator classCreator = new ClassCreator();
            this.Enabled = false;
            classCreator.ShowDialog();

            if (classCreator.DialogResult == DialogResult.OK)
                Init();

            this.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            DialogResult confirmation = Outils.ShowInfoMessage("Please confirm", "Confirmation", MessageBoxButtons.YesNo);

            if (confirmation == DialogResult.Yes) {
                try {
                    if (classeDTOGridView.SelectedRows.Count > 0) {
                        if (!classeService.DeleteClass(classeDTOGridView.SelectedRows[0].DataBoundItem as ClasseDTO)) {
                            Outils.ShowErrorMessage("Heroes are bound to this class delete them before deleting the class", "ERROR");
                        }
                        Init();
                    }
                } catch (Exception) {
                    Outils.ShowErrorMessage("An error occured while modifying the class to the database", "ERROR");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FillEditForm(ClasseDTO classeDTO) {
            newIdLabel.Text = classeDTO.Id.ToString();
            newNomClasseTextBox.Text = classeDTO.NomClasse;
            newDescriptionTextBox.Text = classeDTO.Description;
            newStatBaseDexTextBox.Text = classeDTO.StatBaseDex.ToString();
            newStatBaseIntTextBox.Text = classeDTO.StatBaseInt.ToString();
            newStatBaseStrTextBox.Text = classeDTO.StatBaseStr.ToString();
            newStatBaseVitaliteTextBox.Text = classeDTO.StatBaseVitalite.ToString();

            mondeDTOComboBox.DataSource = mondeService.GetMondeDTOs().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
            mondeDTOComboBox.Refresh();
        }

        private void Init() {
            try {
                classeDTOGridView.DataSource = classeService.GetClasseDTOs();
                classeDTOGridView.Refresh();

                mondeDTOComboBox.DataSource = mondeService
                    .GetWorldsForSelection()
                    .ToList().Select(x => x.Id + " : " + x.Description).ToArray();

                mondeDTOComboBox.Refresh();
            } catch (Exception) {
                Outils.ShowErrorMessage("An error occured while loading the classes", "ERROR");
            }
        }

        #region UI Methods

        private bool ValidateInput() {
            string strValue = newStatBaseStrTextBox.Text.Trim();
            int nValue;

            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }

                _Strength = nValue;
            } else {
                return false;
            }

            strValue = newStatBaseDexTextBox.Text.Trim();
            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }
                _Dexterity = nValue;
            } else {
                return false;
            }

            strValue = newStatBaseVitaliteTextBox.Text.Trim();
            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }
                _Vitality = nValue;
            } else {
                return false;
            }

            strValue = newStatBaseIntTextBox.Text.Trim();
            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }
                _Intelligence = nValue;
            } else {
                return false;
            }

            return true;
        }

        private void SwitchMode() {
            if (classeDTOGridView.Visible) {
                // change pour modif
                titleLabel.Text = "Class Editor";

                editIdLabel.Visible = true;
                editNomClasseLabel.Visible = true;
                editDescriptionLabel.Visible = true;
                editStatBaseDexLabel.Visible = true;
                editStatBaseIntLabel.Visible = true;
                editStatBaseStrLabel.Visible = true;
                editStatBaseVitaliteLabel.Visible = true;
                newIdLabel.Visible = true;
                newNomClasseTextBox.Visible = true;
                newDescriptionTextBox.Visible = true;
                newStatBaseDexTextBox.Visible = true;
                newStatBaseIntTextBox.Visible = true;
                newStatBaseStrTextBox.Visible = true;
                newStatBaseVitaliteTextBox.Visible = true;
                btnCancel.Visible = true;
                btnConfirm.Visible = true;
                editMondeLabel.Visible = true;
                mondeDTOComboBox.Visible = true;

                btnEditClass.Visible = false;
                btnDelete.Visible = false;
                btnCreate.Visible = false;
                classeDTOGridView.Visible = false;
                Refresh();
            } else {
                // change pour lister
                titleLabel.Text = "Class Selector";

                editIdLabel.Visible = false;
                editNomClasseLabel.Visible = false;
                editDescriptionLabel.Visible = false;
                editStatBaseDexLabel.Visible = false;
                editStatBaseIntLabel.Visible = false;
                editStatBaseStrLabel.Visible = false;
                editStatBaseVitaliteLabel.Visible = false;

                newIdLabel.Visible = false;
                newNomClasseTextBox.Visible = false;
                newDescriptionTextBox.Visible = false;
                newStatBaseDexTextBox.Visible = false;
                newStatBaseIntTextBox.Visible = false;
                newStatBaseStrTextBox.Visible = false;
                newStatBaseVitaliteTextBox.Visible = false;
                editMondeLabel.Visible = false;
                mondeDTOComboBox.Visible = false;

                btnCancel.Visible = false;
                btnConfirm.Visible = false;

                classeDTOGridView.Visible = true;

                if (connectedPlayer.TypeUtilisateur > 0) {
                    btnEditClass.Visible = true;
                    btnDelete.Visible = true;
                    btnCreate.Visible = true;
                }

                Refresh();
            }
        }

        #endregion
    }
}