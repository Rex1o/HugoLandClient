using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP01_Library.Models;

namespace HugoWorld.Vue
{
    public partial class frmCharacterSelector : Form
    {
        public Hero Hero { get; set; }
        public string ErrorMsg { get; set; }
        Hero _selectedHero;
        CompteJoueur _user;

        public frmCharacterSelector(CompteJoueur j)
        {
            _user = j;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnOk.Enabled = false;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add character

        }

        private void lstCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                int HeroID = int.Parse(lstCharacters.SelectedItem.ToString().Substring(4, lstCharacters.SelectedItem.ToString().IndexOf(' ')));
                //_selectedHero = GetHeroById();
                btnOk.Enabled = true;
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
