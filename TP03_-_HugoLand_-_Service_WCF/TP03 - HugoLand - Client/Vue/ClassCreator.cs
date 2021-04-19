using Hugoworld.Validators;
using HugoWorld_Client.HL_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Hugoworld.Validators;
using TP01_Library.Controllers;

namespace HugoWorld.Vue {
    public partial class ClassCreator : Form {
        private int _Strength;
        private int _Dexterity;
        private int _Vitality;
        private int _Integrity;
        private readonly ClasseDTOValidator ClasseValidator = new ClasseDTOValidator();
        private ClasseServiceClient classeService;
        private MondeServiceClient mondeService;

        public ClassCreator()
        {

            _Strength = 16;
            _Dexterity = 16;
            _Vitality = 16;
            _Integrity = 16;

            //Test
            //ClasseDTO c;
            //c = new ClasseDTO()
            //{
            //    NomClasse = "Test",
            //    Description = "Test",
            //    StatBaseStr = 16,
            //    StatBaseDex = 16,
            //    StatBaseVitalite = 16,
            //    StatBaseInt = 16,
            //    MondeId = 255
            //};
            //ServiceClass.AddClassToDataBase(c.StatBaseStr, c.StatBaseDex, c.StatBaseVitalite, c.StatBaseInt, c.MondeId);

            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            this.StartPosition = FormStartPosition.CenterParent;


            //Initialisation du clientMonde
            mondeService = new MondeServiceClient();
            classeService = new ClasseServiceClient();
        }

        private void ClassCreator_Load(object sender, EventArgs e)
        {
            CmbWorld.DataSource = mondeService.ListWorlds().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {

                string itemstr = CmbWorld.SelectedItem.ToString();
                int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));

                //Creation d'un objet
                ClasseDTO c = new ClasseDTO()
                {
                    NomClasse = txtName.Text,
                    Description = txtDescription.Text,
                    StatBaseStr = _Strength,
                    StatBaseDex = _Dexterity,
                    StatBaseVitalite = _Vitality,
                    StatBaseInt = _Integrity,
                    MondeId = id
                };

                var result = ClasseValidator.Validate(c);

                if (result.IsValid)
                {
                    try
                    {

                        //         ####################### controllers du TP01 #########################
                        ClasseController controller = new ClasseController();
                        controller.AjouterClasse(c.MondeId,c.NomClasse,c.Description,c.StatBaseStr,c.StatBaseDex,c.StatBaseInt,c.StatBaseVitalite);

						//Requêtes ####################### le programm crash ici #########################
                        //Création du ClientClasse
                        //ServiceClass = new ClasseServiceClient();
                        //c.NomClasse.ToString(), c.Description.ToString(),
                        //classeService.AddClassToDataBase(c.NomClasse, c.Description, c.StatBaseStr, c.StatBaseDex, c.StatBaseVitalite, c.StatBaseInt, c.MondeId);
                        //classeService.AddClassToDataBase(id, txtName.Text, txtDescription.Text, _Strength, _Dexterity, _Vitality, _Integrity);
                        //classeService.AddClassToDataBase(c);
                        //classeService.Abort();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured while adding the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }

                }
                else
                {
                    ShowErrorsMessageBox(result);
                }
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
                    return false;
                }
                
                    _Strength = nValue;
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
                    return false;
                }
                    _Dexterity = nValue;
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
                    return false;
                }
                    _Vitality = nValue;
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
                    return false;
                }
                    _Integrity = nValue;
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