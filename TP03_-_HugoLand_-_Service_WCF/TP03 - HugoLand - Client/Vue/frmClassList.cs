using HugoWorld.BLL;
using HugoWorld.Vue;
using HugoWorld_Client.HL_Services;
using System;
using System.Collections;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HugoWorld_Client.Vue
{
    public partial class frmClassList : Form
    {
        private readonly ClasseServiceClient classeService;
        private readonly MondeServiceClient mondeService;
        private CompteJoueurDTO connectedPlayer;
        public frmClassList()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            classeService = new ClasseServiceClient();
            mondeService = new MondeServiceClient();
            connectedPlayer = Outils.GetActiveUser();

            Init();

            SwitchMode();
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            try
            {
                if (classeDTOGridView.SelectedRows.Count > 0)
                {
                    SwitchMode();
                    FillEditForm(classeDTOGridView.SelectedRows[0].DataBoundItem as ClasseDTO);
                }
                else
                {
                    MessageBox.Show("Please choose a character!",
                        "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while modifying the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int dex = 0;
            int intel = 0;
            int str = 0;
            int vit = 0;

            if (int.TryParse(newStatBaseDexTextBox.Text, out dex))
            {
                ErreurIntegerMsgBox();
                return;
            }
            else if (int.TryParse(newStatBaseIntTextBox.Text, out intel))
            {
                ErreurIntegerMsgBox();
                return;
            }
            else if (int.TryParse(newStatBaseStrTextBox.Text, out str))
            {
                ErreurIntegerMsgBox();
                return;
            }
            else if (int.TryParse(newStatBaseVitaliteTextBox.Text, out vit))
            {
                ErreurIntegerMsgBox();
                return;
            }

            ClasseDTO classeDTO = new ClasseDTO()
            {
                Id = int.Parse(newIdLabel.Text),
                NomClasse = newNomClasseTextBox.Text,
                Description = newDescriptionTextBox.Text,
                StatBaseDex = dex,
                StatBaseInt = intel,
                StatBaseStr = str,
                StatBaseVitalite = vit,
                MondeId = ((MondeDTO)mondeDTOComboBox.SelectedItem).Id
            };

            try
            {
                classeService.EditClass(classeDTO);

                SwitchMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while modifying the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SwitchMode();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ClassCreator classCreator = new ClassCreator();
            this.Enabled = false;
            classCreator.ShowDialog();

            if (classCreator.DialogResult == DialogResult.OK)
                Init();

            this.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (classeDTOGridView.SelectedRows.Count > 0)
                {

                    if (!classeService.DeleteClass(classeDTOGridView.SelectedRows[0].DataBoundItem as ClasseDTO))
                    {
                        MessageBox.Show("Heroes are bound to this class delete them before deleting the class", "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                    Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while modifying the class to the database\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ErreurIntegerMsgBox()
        {
            MessageBox.Show("Please enter a number!", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        private void FillEditForm(ClasseDTO classeDTO)
        {
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

        private void SwitchMode()
        {
            if (classeDTOGridView.Visible)
            {
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
            }
            else
            {
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

                if (connectedPlayer.TypeUtilisateur > 0)
                {
                    btnEditClass.Visible = true;
                    btnDelete.Visible = true;
                    btnCreate.Visible = true;
                }

                Refresh();
            }
        }

        void Init()
        {
            try
            {
                classeDTOGridView.DataSource = classeService.GetClasseDTOs();
                classeDTOGridView.Refresh();

                mondeDTOComboBox.DataSource = mondeService.GetWorldsForSelection().ToList().Select(x => x.Id + " : " + x.Description).ToArray();
                mondeDTOComboBox.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading the classes\n" + ex.Message, "ERROR",
MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

    }
}
