using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoodFlooringService
{
    public partial class WFSCustomer : Form
    {
        private MySQL mysql;

        //Create an instance of the MySQL class and connect to the database.
        //Set the max date of the date of birth selector to today's date.
        public WFSCustomer()
        {
            InitializeComponent();
            mysql = new MySQL();
            datDob.MaxDate = DateTime.Now;
            mysql.Connect();
        }

        //Close the form.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Check all inputs for entered text and check them against regex.
        //Using sql, add the entered data to the database.
        //If anything fails, report the error to the user and highlight the incorrect boxes.
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(CheckInputs()){
                if(TestRegex())
                {
                    if(!string.IsNullOrWhiteSpace(txtAddr2.Text)){
                        mysql.Insert("INSERT INTO customers (surname, forename, address1, address2, town, postcode, tel, email, dob) VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)",
                            txtSurname.Text,
                            txtForename.Text,
                            txtAddr1.Text,
                            txtAddr2.Text,
                            txtCity.Text,
                            txtPostcode.Text,
                            txtTel.Text,
                            txtEmail.Text,
                            (datDob.Value.Year.ToString()+"-"+datDob.Value.Month.ToString()+"-"+datDob.Value.Day.ToString())
                        );
                    }else{
                        mysql.Insert("INSERT INTO customers (surname, forename, address1, town, postcode, tel, email, dob) VALUES (@0, @1, @2, @3, @4, @5, @6, @7)",
                            txtSurname.Text,
                            txtForename.Text,
                            txtAddr1.Text,
                            txtCity.Text,
                            txtPostcode.Text,
                            txtTel.Text,
                            txtEmail.Text,
                            (datDob.Value.Year.ToString()+"-"+datDob.Value.Month.ToString()+"-"+datDob.Value.Day.ToString())
                        );
                    }
                    ClearInputs();
                } else{
                    MessageBox.Show("One or more values are incorrect!", "Incorrect values!");
                }
            } else{
                MessageBox.Show("All boxes marked with an asterisk must be filled!", "Missing information!");
            }
        }

        //Cycle through all controls on the form and add all text boxes to a list.
        //Cycle through the list and check each box for text.
        //If any box has no text, change its background colour to red and return false.
        //If all boxes have text, return true.
        private bool CheckInputs(){
            bool retval = true;
            List<TextBox> inputs = new List<TextBox>();
            foreach(Control control in this.Controls){
                if(control is TextBox){ 
                    inputs.Add((TextBox)control);
                    control.BackColor = Color.White;
                }
            }
            foreach(TextBox input in inputs){
                if(!input.Name.Equals("txtAddr2")){
                    if(string.IsNullOrWhiteSpace(input.Text)){
                        input.BackColor = Color.Red;
                        retval = false;
                    }
                }
            }
            return retval;
        }

        //Using regex patterns, compare the postcode and telephone entries.
        //If any do not match, change the background colours to red and return false.
        //If both match, return true;
        private bool TestRegex(){ 
            bool retval = true;
            string postcodePattern = @"([Gg][Ii][Rr] 0[Aa]{2})|((([A-Za-z][0-9]{1,2})|(([A-Za-z][A-Ha-hJ-Yj-y][0-9]{1,2})|(([A-Za-z][0-9][A-Za-z])|([A-Za-z][A-Ha-hJ-Yj-y][0-9]?[A-Za-z]))))\s?[0-9][A-Za-z]{2})";
            Regex postcodeRegex = new Regex(postcodePattern);
            if(!postcodeRegex.IsMatch(txtPostcode.Text)){
                txtPostcode.BackColor = Color.Red;
                retval = false;
            }
            string telephonePattern = @"^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$";
            Regex telephoneRegex = new Regex(telephonePattern);
            if(!telephoneRegex.IsMatch(txtTel.Text)){ 
                txtTel.BackColor = Color.Red;
                retval = false;
            }
            return retval;
        }

        //Cycle through the controls on the page and add the text boxes to a list.
        //Clear all text boxes, set the max date of the date of birth selector and set the value of the date of birth selector to today's date.
        private void ClearInputs(){
            List<TextBox> inputs = new List<TextBox>();
            foreach(Control control in this.Controls){
                if(control.Name.StartsWith("txt")){ 
                    inputs.Add((TextBox)control);
                }
            }
            foreach(TextBox input in inputs){
                input.Clear();
            }
            datDob.MaxDate = DateTime.Now;
            datDob.Value = DateTime.Now;
        }

        //Disconnect from the database on form close.
        private void WFSCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            mysql.Disconnect();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            new WFSHelp("tabCustomer").ShowDialog();
        }
    }
}
