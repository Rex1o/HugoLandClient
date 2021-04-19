using HugoWorld_Client.HL_Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hugoworld.Validators;

namespace HugoWorld.Vue
{
    public partial class ClassCreator : Form
    {

        private int _Strength;
        private int _Dexterity;
        private int _Vitality;
        private int _Integrity;
        private readonly ClasseDTOValidator ClasseValidator;
        private readonly MondeServiceClient ServiceMonde;

        public ClassCreator()
        {
            ClasseValidator = new ClasseDTOValidator();
            ServiceMonde = new MondeServiceClient();


            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.StartPosition = FormStartPosition.CenterParent;
            List<MondeDTO> Mondes = ServiceMonde.ListWorlds().ToList();
            CmbWorld.DataSource = Mondes.Select(x => x.Id + " : " + x.Description).ToArray();

            _Strength = 16;
            _Dexterity = 16;
            _Vitality = 16;
            _Integrity = 16;
        }

        private void ClassCreator_Load(object sender, EventArgs e)
        {

        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {

                string itemstr = CmbWorld.SelectedItem.ToString();
                int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));
                ClasseDTO ClassToAdd;
                ClassToAdd = new ClasseDTO()
                {
                    NomClasse = txtName.Text.Trim(),
                    Descrpition = txtDescription.Text.Trim(),
                    StatBaseStr = _Strength,
                    StatBaseDex = _Dexterity,
                    StatBaseVitalite = _Vitality,
                    StatBaseInt = _Integrity,
                    MondeId = id
                };

                //                var result = ClasseValidator.Validate(ClassToAdd);

                //                if (result.IsValid)
                //                {
                //                    try
                //                    {





                //                    }
                //                    catch
                //                    {
                //                        MessageBox.Show("ERROR", "An error occured while adding the class to the database",
                //MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                //                    }

                //                }
                //                else
                //                {
                //                    ShowErrorsMessageBox(result);
                //                }
            }
            else
            {
                MessageBox.Show("Please enter valid informations.");
            }
        }

        private void txtBaseForce_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();

        }

        private void txtBaseDexterity_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();

        }

        private void txtBaseVitality_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();

        }

        private void txtBaseIntegrity_TextChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private bool ValidateInput()
        {
            String strValue = txtBaseForce.Text.Trim();
            int nValue;

            if (int.TryParse(strValue, out nValue))
            {
                if (nValue < 1)
                {
                    _Strength = nValue;
                    return false;
                }
            }
            else
            {
                return false;
            }

            strValue = txtBaseDexterity.Text.Trim();
            if (int.TryParse(strValue, out nValue))
            {
                if (nValue < 1)
                {
                    _Dexterity = nValue;
                    return false;
                }
            }
            else
            {
                return false;
            }

            strValue = txtBaseVitality.Text.Trim();
            if (int.TryParse(strValue, out nValue))
            {
                if (nValue < 1)
                {
                    _Vitality = nValue;
                    return false;
                }
            }
            else
            {
                return false;
            }

            strValue = txtBaseIntegrity.Text.Trim();
            if (int.TryParse(strValue, out nValue))
            {
                if (nValue < 1)
                {
                    _Integrity = nValue;
                    return false;
                }
            }
            else
            {
                return false;
            }


            return true;
        }

        private static void ShowErrorsMessageBox(FluentValidation.Results.ValidationResult result)
        {
            MessageBox.Show(string.Join("\n", result.Errors.ToList()), "Errors");
        }

        private void UpdateUI()
        {
            btnAddClass.Enabled = ValidateInput();
        }
    }
}