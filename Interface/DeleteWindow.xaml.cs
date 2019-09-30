using System;
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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        //Links the database to the window
        private SimpleDataSource SDS = new SimpleDataSource("mysql.cs.bangor.ac.uk", "eeu829", 3306, "eeu829", "Bangor16");

        public DeleteWindow()
        {
            InitializeComponent();
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            //Opens link to the main window and closes current window
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Delete_Button1(object sender, RoutedEventArgs e)
        {
            //Deletes the contact associated with the contact ID entered intot the textbox
            DataTable Table = SDS.DataTableQuery("DELETE FROM AD_Contacts WHERE contactID='" + ContactID.Text + "'");

            //If the contact ID is empty it will prompt the user to enter one
            if (ContactID.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Contact ID cannot be empty");
                return;
            }

            MessageBox.Show("Successfully Deleted Contact");

        }
    }
}
