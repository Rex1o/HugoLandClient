using HugoWorld_Client.HL_Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HugoWorld.Vue {

    public partial class frmCharacterSelector : Form {
        public HeroDTO Hero { get; set; }
        public string ErrorMsg { get; set; }
        private HeroDTO _selectedHero = new HeroDTO();
        private CompteJoueurDTO _user;
        private readonly JoueurServiceClient joueurService;

        public frmCharacterSelector(CompteJoueurDTO j)
        {
            _user = j;



            herosDataGridView.DataSource = j.Heros;
            InitializeComponent();
            joueurService = new JoueurServiceClient();
            this.StartPosition = FormStartPosition.CenterScreen;

            //Remplir la liste selon le user
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnOk.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add character
        }

        private void herosDataGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (herosDataGridView.SelectedCells.Count > 0)
                {
                    int rowIndex = herosDataGridView.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = herosDataGridView.Rows[rowIndex];
                    if (int.TryParse(Convert.ToString(selectedRow.Cells["Id"].Value), out int heroId))
                    {
                        _selectedHero = joueurService.GetHeroById(heroId);
                        //int HeroID = int.Parse(lstCharacters.SelectedItem.ToString().Substring(4, lstCharacters.SelectedItem.ToString().IndexOf(' ', 4)));
                        //_selectedHero = GetHeroById();
                        btnOk.Enabled = true;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        this.ErrorMsg = "Please a choose a character!";
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                this.ErrorMsg = ex.Message;
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //Start game with selected hero
            Hero = _selectedHero;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}