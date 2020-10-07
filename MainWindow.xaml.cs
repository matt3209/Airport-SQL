using System;
using System.Collections.Generic;
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

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml It opens and closes the program, based on user selection. 
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        public void createButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFlight createFlight = new CreateFlight(App.Controller);
            createFlight.Show();


        }

        public void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateFlight updateFlight = new UpdateFlight(App.Controller);
            updateFlight.Show();
        }

        public void displayButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayFlights displayFlights = new DisplayFlights(App.Controller);
            displayFlights.Show();
        }

        public void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteFlight deleteFlight = new DeleteFlight(App.Controller);
            deleteFlight.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}


