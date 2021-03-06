using FluentValidation.Results;
using Hugoworld.Validators;
using HugoWorld.BLL;
using HugoWorld_Client.HL_Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HugoWorld.Vue {

    public partial class ClassCreator : Form {
        private int _Strength;
        private int _Dexterity;
        private int _Vitality;
        private int _Integrity;
        private readonly ClasseDTOValidator ClasseValidator = new ClasseDTOValidator();
        private ClasseServiceClient classeService;
        private MondeServiceClient mondeService;
        public ClasseDTO classeDTO { get; set; }

        public ClassCreator() {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Initialisation du clientMonde
            mondeService = new MondeServiceClient();
            classeService = new ClasseServiceClient();
        }

        private void ClassCreator_Load(object sender, EventArgs e) {
            CmbWorld.DataSource = mondeService.GetWorldsForSelection().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
        }

        private void btnAddClass_Click(object sender, EventArgs e) {
            if (ValidateInput()) {
                string itemstr = CmbWorld.SelectedItem.ToString();
                int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

                //Creation d'un objet
                ClasseDTO c = new ClasseDTO() {
                    NomClasse = txtName.Text,
                    Description = txtDescription.Text,
                    StatBaseStr = _Strength,
                    StatBaseDex = _Dexterity,
                    StatBaseVitalite = _Vitality,
                    StatBaseInt = _Integrity,
                    MondeId = id
                };

                ValidationResult result = ClasseValidator.Validate(c);

                if (result.IsValid) {
                    try {
                        classeService.AddClassToDataBase(c);
                        classeDTO = c;

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    } catch (Exception) {
                        Outils.ShowErrorMessage("An error occured while adding the class to the database\n", "ERROR");
                    }
                } else {
                    Outils.ShowErrorMessage(string.Join("\n", result.Errors.ToList()), "Errors");
                }
            } else {
                MessageBox.Show("Please enter valid informations.");
            }
        }

        #region UI Methods

        private void txtBaseForce_TextChanged(object sender, EventArgs e) {
            UpdateUI();
        }

        private void txtBaseDexterity_TextChanged(object sender, EventArgs e) {
            UpdateUI();
        }

        private void txtBaseVitality_TextChanged(object sender, EventArgs e) {
            UpdateUI();
        }

        private void txtBaseIntegrity_TextChanged(object sender, EventArgs e) {
            UpdateUI();
        }

        private bool ValidateInput() {
            string strValue = txtBaseForce.Text.Trim();
            int nValue;

            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }

                _Strength = nValue;
            } else {
                return false;
            }

            strValue = txtBaseDexterity.Text.Trim();
            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }
                _Dexterity = nValue;
            } else {
                return false;
            }

            strValue = txtBaseVitality.Text.Trim();
            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }
                _Vitality = nValue;
            } else {
                return false;
            }

            strValue = txtBaseIntegrity.Text.Trim();
            if (int.TryParse(strValue, out nValue)) {
                if (nValue < 1) {
                    return false;
                }
                _Integrity = nValue;
            } else {
                return false;
            }

            return true;
        }

        private void UpdateUI() {
            btnAddClass.Enabled = ValidateInput();
        }

        #endregion UI Methods
    }
}