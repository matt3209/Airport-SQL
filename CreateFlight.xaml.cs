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
    /// Interaction logic for CreateFlight.xaml. Adds flights to the sql database. Uses error class to check.
    /// </summary>
    public partial class CreateFlight : Window
    {
        Error E = new Error();

        Controller Controller;

        public CreateFlight(Controller controllerAdded)
        {
            InitializeComponent();
            Controller = controllerAdded;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = idTB.Text;
            string org = orgTB.Text;
            string dest = destTB.Text;
            string pass = passTB.Text;

            bool checkID = E.SameId(id);

            if (checkID == true)
            {
                MessageBox.Show("This ID already exists in the database.");
                Close();
            }

            bool error1 = E.ErrorID(id);
            if (error1 == true)
            {
                MessageBox.Show("ERROR: ID needs to be 3 letters exactly followed by 3 integers exactly. Please Restart.");

            }

            bool error2 = E.ErrorFour(org);
            if (error2 == true)
            {
                MessageBox.Show("ERROR: Origin needs to be 4 Letters Exactly. Please Restart.");

            }

            bool error3 = E.ErrorFour(dest);
            if (error3 == true)
            {
                MessageBox.Show("ERROR: Origin needs to be 4 Letters Exactly. Please Restart.");

            }

            bool error4 = E.ErrorInt(pass);
            if (error4 == true)
            {
                MessageBox.Show("ERROR: Passengers needs to be an integer. Please Restart.");

            }

            if (checkID == false && error1 == false && error2 == false && error3 == false && error4 == false)
            {

                App.Controller.Add(org, dest, id, pass);
                Close();
            }

        }
    }
}
