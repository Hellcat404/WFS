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
    public partial class WFSLogin : Form
    {
        private MySQL mysql;
        private WFSMenu menu;

        private bool loggedIn = false;

        //Creates an instance of the MySQL class and connects to the database.
        //Setting the menu allows for me to redirect to the menu after logging it correctly.
        public WFSLogin(WFSMenu menu)
        {
            InitializeComponent();
            mysql = new MySQL();
            this.menu = menu;
            if(!mysql.Connect()){
                MessageBox.Show("There was an issue connecting to the database, please try again later!", "Database connection failed!");
                Application.Exit();
            }
        }

        //When cancelled close the whole application.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Search the users table for an entry where the username and password match the entered values.
        //If the values match, redirect to the menu and close this form.
        //If the values do not match, tell the user.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> search = mysql.Search("SELECT id FROM users WHERE user=@0 AND pass=@1", txtUsername.Text, txtPassword.Text);
            if(search.Count > 0){
                menu.Show();
                mysql.Disconnect();
                loggedIn = true;
                this.Close();
            } else{
                txtUsername.Clear();
                txtPassword.Clear();
                MessageBox.Show("Username or password is incorrect!", "Incorrect Login!");
            }
        }

        //If the form is closing and the user did not login, disconnect from the database.
        //Close the whole application otherwise the menu will be visible.
        private void WFSLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!loggedIn){
                mysql.Disconnect();
                Application.Exit();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new WFSHelp("tabLogin").ShowDialog();
        }
    }
}
