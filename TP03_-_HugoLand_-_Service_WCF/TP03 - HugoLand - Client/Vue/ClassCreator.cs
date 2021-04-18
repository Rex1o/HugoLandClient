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

namespace HugoWorld.Vue
{
    public partial class ClassCreator : Form
    {
        private readonly ClasseServiceClient serviceClient = new ClasseServiceClient();
        private readonly MondeServiceClient ServiceMonde = new MondeServiceClient();
        public ClassCreator()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            List<MondeDTO> Mondes = ServiceMonde.ListWorlds().ToList();
            CmbWorld.DataSource = Mondes.Select(x => x.Id + " : " + x.Description).ToArray();
        }

        private void ClassCreator_Load(object sender, EventArgs e)
        {

        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            string itemstr = CmbWorld.SelectedItem.ToString();
            int id = Int32.Parse(itemstr.Substring(0, itemstr.IndexOf(":")));
            
        }
    }
}
