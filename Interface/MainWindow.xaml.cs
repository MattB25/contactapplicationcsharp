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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppDev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private SimpleDataSource SDS = new SimpleDataSource("mysql.cs.bangor.ac.uk", "eeu829", 3306, "eeu829", "Bangor16");

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = SDS.DataTableQuery("SELECT * FROM AD_Contacts").DefaultView;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            //Opens link to the add window and closes current window
            AddWindow aw = new AddWindow();
            aw.Show();
            this.Close();
        }

        private void Edit_Button(object sender, RoutedEventArgs e)
        {

            //Opens link to the edit window and closes current window
            EditWindow ew = new EditWindow();
            ew.Show();
            this.Close();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {

            //Opens link to the delete window and closes current window
            DeleteWindow dw = new DeleteWindow();
            dw.Show();
            this.Close();
        }

        private void Search_Button(object sender, RoutedEventArgs e)
        {
            //Searches through the data table and brings back any result matching the search bar
            DataTable Table = SDS.DataTableQuery("SELECT * FROM AD_Contacts WHERE CONCAT(contactID, FirstName, Surname, Gender, Age, Address, Postcode, Email, Phone) LIKE '%" + SearchBar.Text + "%'");
            dataGrid.ItemsSource = Table.DefaultView;
        }
    }
}
