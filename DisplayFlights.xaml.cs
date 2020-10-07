using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for DisplayFlights.xaml, Displays the flights in a text box. 
    /// </summary>
    public partial class DisplayFlights : Window
    {
        Controller Controller;
        string listFlights = "FlightID " + "Origin " + "Destination " + "Passengers" + Environment.NewLine;

        public DisplayFlights(Controller controllerAdded)
        {
            InitializeComponent();

            Controller = controllerAdded;
        }

        private void displayTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void displayB_Click(object sender, RoutedEventArgs e)
        {
            displayText.Text += Controller.Display();
        }
    }
}
