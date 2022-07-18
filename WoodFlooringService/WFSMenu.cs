using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoodFlooringService
{
    public partial class WFSMenu : Form
    {
        //When the menu is created, hide it to allow for the login form load.
        public WFSMenu(){
            InitializeComponent();
            this.Hide();
        }

        //Open the login form as a dialogue menu.
        private void WFSMenu_Load(object sender, EventArgs e)
        {
            new WFSLogin(this).ShowDialog();
        }

        //Open the customer form as a dialog menu.
        private void btnAddCustomer_Click(object sender, EventArgs e){
            new WFSCustomer().ShowDialog();
        }

        //Open the cost form as a dialogue menu.
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            new WFSCost().ShowDialog();
        }

        //Open the task form as a dialogue menu.
        private void btnTasks_Click(object sender, EventArgs e)
        {
            new WFSTasks().ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new WFSHelp("tabMenu").ShowDialog();
        }
    }
}
