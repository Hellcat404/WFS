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
    public partial class WFSCost : Form
    {
        private MySQL mysql;

        private Dictionary<string, double> costs;

        //Create an new instance of the MySQL class and connect to the database.
        //Initialise the wood types and costs.
        //Disconnect from the database.
        public WFSCost()
        {
            InitializeComponent();

            mysql = new MySQL();

            mysql.Connect();
            InitWood();
            mysql.Disconnect();
        }

        //Instantiate the costs dictionary.
        //Get all data from the wood table and add the wood name and cost to the costs dictionary.
        //Add the wood name to the combo box.
        private void InitWood(){ 
            costs = new Dictionary<string, double>();
            Dictionary<int, Dictionary<string, string>> search = mysql.Search("SELECT * FROM wood");
            for(int i = 0; i < search.Count; i++){
                costs.Add(search[i]["name"], double.Parse(search[i]["cost"]));
                cmbWood.Items.Add(search[i]["name"]);
            }
        }

        //When a new type of wood is selected, attempt to calculate the cost.
        private void cmbWood_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        //When a new value is entered into the text box, attempt to calculate the cost.
        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            CalculateCost();
        }

        //Check to make sure the text box contains a value.
        //Check to make sure that all characters entered into the text box are digits.
        //Check to make sure that something is selected in the combo box.
        //If these conditions are NOT met, set the two outputs to 0.
        //If these conditions ARE met, get the cost of the wood from the dictionary and multiply the cost by the number in the text box.
        //The cost with vat is gotten by adding 20% of the cost to itself.
        //Output these values to the corresponding read-only text boxes.
        private void CalculateCost(){ 
            if(!string.IsNullOrWhiteSpace(txtArea.Text) && txtArea.Text.All(char.IsDigit) && cmbWood.SelectedIndex != -1){
                double cost = costs[cmbWood.Items[cmbWood.SelectedIndex].ToString()] * double.Parse(txtArea.Text);
                double vatCost = cost + (cost / 100 * 20);
                txtOut.Text = cost.ToString();
                txtOutVAT.Text = vatCost.ToString();
            }else{ 
                txtOut.Text = "0";
                txtOutVAT.Text = "0";
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new WFSHelp("tabCost").ShowDialog();
        }
    }
}
