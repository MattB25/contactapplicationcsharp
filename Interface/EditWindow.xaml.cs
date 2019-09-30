﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppDev
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        //Links the database to the window
        private SimpleDataSource SDS = new SimpleDataSource("mysql.cs.bangor.ac.uk", "eeu829", 3306, "eeu829", "Bangor16");


        public EditWindow()
        {
            InitializeComponent();
        }

        //Goes back to the main window when the cancel button is pressed
        private void Cancel_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
            
        }

        //Clears the fields when the clear button is pressed
        private void Clear_Button(object sender, RoutedEventArgs e)
        {
            ContactID.Text = "";
            FirstName.Text = "";
            Surname.Text = "";
            Gender.Text = "";
            Age.Text = "";
            Address.Text = "";
            Postcode.Text = "";
            Email.Text = "";
            Phone.Text = "";
        }




        private void Update_Button(object sender, RoutedEventArgs e)
        {
            //sql query to update a contact
            DataTable Table = SDS.DataTableQuery("UPDATE AD_Contacts SET FirstName='" + FirstName.Text + "', Surname='" + Surname.Text + "', Gender='" +Gender.Text + "', Age='" + Age.Text + "', Address='" + Address.Text + "', Postcode= '" + Postcode.Text + "', Email='" + Email.Text + "', Phone='" + Phone.Text + "' WHERE contactID='" + ContactID.Text + "'");

            //checks if contact ID, age and phone number have the int data type entered into the text boxes
            int val;
            if (!int.TryParse(ContactID.Text, out val))
            {
                MessageBox.Show("The contact ID field  must only contain a number.");
                return;
            }
            if (!int.TryParse(Age.Text, out val))
            {
                MessageBox.Show("The age field must only contain a number.");
                return;
            }
            if (!int.TryParse(Phone.Text, out val))
            {
                MessageBox.Show("The phone field  must only contain numbers.");
                return;
            }

            //checks if textboxes are empty and prompts user to enter details if they are
            if (ContactID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Contact ID cannot be empty");
                return;
            }
            if (FirstName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("First name cannot be empty");
                return;
            }
            if (Surname.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Surname cannot be empty");
                return;
            }
            if (Gender.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Gender cannot be empty");
                return;
            }
            if (Age.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Age cannot be empty");
                return;
            }
            if (Address.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Address cannot be empty");
                return;
            }
            if (Postcode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Postcode cannot be empty");
                return;
            }
            if (Email.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Email cannot be empty");
                return;
            }
            if (Phone.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Phone number cannot be empty");
                return;
            }


            //Tells the user the command was successful and then clears the fields
            MessageBox.Show("Successfully Updated Contact");


            ContactID.Text = "";
            FirstName.Text = "";
            Surname.Text = "";
            Gender.Text = "";
            Age.Text = "";
            Address.Text = "";
            Postcode.Text = "";
            Email.Text = "";
            Phone.Text = "";
        }
    }
}
