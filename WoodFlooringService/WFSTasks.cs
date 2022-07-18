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
    public partial class WFSTasks : Form
    {
        private MySQL mysql;

        private Dictionary<int, string> tasks;

        //Create a new instance of the MySQL class and connect to the database.
        //Initialise the tasks from the database.
        public WFSTasks(){
            InitializeComponent();

            mysql = new MySQL();

            mysql.Connect();
            InitTasks();
        }

        //Clear the list box and instantiate the tasks dictionary.
        //Get all tasks from the database and add them to the tasks dictionary to store the id of the task and the task itself.
        //Add the tasks to the list box.
        private void InitTasks(){ 
            lstTasks.Items.Clear();
            tasks = new Dictionary<int, string>();
            Dictionary<int, Dictionary<string, string>> search = mysql.Search("SELECT * FROM tasks");
            for(int i = 0; i < search.Count; i++){
                tasks.Add(int.Parse(search[i]["id"]), search[i]["task"]);
                lstTasks.Items.Add(search[i]["task"]);
            }
        }

        //Check if text is entered into the text box.
        //If this is not met, do nothing.
        //If this is met, add the task to the database, clear the text box and initialise tasks.
        private void btnAddTask_Click(object sender, EventArgs e){
            if(!string.IsNullOrWhiteSpace(txtTask.Text)){
                mysql.Insert("INSERT INTO tasks (task) VALUES (@0)", txtTask.Text);
                txtTask.Clear();
                InitTasks();
            }
        }

        //Check that something is selected in the list box.
        //If nothing is selected, do nothing.
        //If something is selected, cycle through the tasks dictionary until the correct id is found and delete the task from the database.
        private void btnDelTask_Click(object sender, EventArgs e){
            if(!string.IsNullOrWhiteSpace(lstTasks.Text)){
                foreach(KeyValuePair<int, string> kvp in tasks){
                    if(lstTasks.Text.Equals(kvp.Value)){
                        mysql.Remove("DELETE FROM tasks WHERE id = @0", kvp.Key.ToString());
                        InitTasks();
                    }
                }
            }
        }

        //Disconnect from the database on form close.
        private void WFSTasks_FormClosing(object sender, FormClosingEventArgs e){
            mysql.Disconnect();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new WFSHelp("tabTasks").ShowDialog();
        }
    }
}
