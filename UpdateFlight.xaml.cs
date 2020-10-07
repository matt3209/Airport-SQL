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
    /// Interaction logic for UpdateFlight.xaml. Will update the database. Cgecks to make sure ID is valid, using error class. 
    /// </summary>
    public partial class UpdateFlight : Window
    {

        Controller Controller;
        Error E = new Error();

        public UpdateFlight(Controller addController)
        {
            InitializeComponent();
            Controller = addController;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = idTB.Text;
            string org = orgTB.Text;
            string dest = destTB.Text;
            string pass = passTB.Text;

            bool checkID = E.SameId(id);

            if (checkID == false)
            {
                MessageBox.Show("This ID doesn't exist in the database.");
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

            if (checkID == true && error2 == false && error3 == false && error4 == false)
            {
                App.Controller.Update(org, dest, id, pass);
                Close();
            }



        }


    }
}
