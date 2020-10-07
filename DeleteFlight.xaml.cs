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
    /// Interaction logic for DeleteFlight.xaml. Deletes a flight. 
    /// </summary>
    /// 

    public partial class DeleteFlight : Window
    {
        Error E = new Error();
        Controller Controller;
        public DeleteFlight(Controller addController)
        {
            InitializeComponent();
            Controller = addController;
        }

        private void deleteB_Click(object sender, RoutedEventArgs e)
        {

            string id = idTB.Text;

            bool checkID = E.SameId(id);

            if (checkID == false)
            {
                MessageBox.Show("This ID doesn't exist in the database.");
            }

            if (checkID == true)
            {
                Controller.Destroy(id);
                Close();
            }
        }

        private void idTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
