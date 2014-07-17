using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESC_Next_Level1
{
        //-------Date: 06/16/2014--------------------------------------------------------
        //-------Author:Hugues-----------------------------------------------------------
        /*Goal: Create a singleton object named controller with elements of int power, string name, int inputs and int outputs.
         * Bind this to a View to contain the information.  In this View Model, handle a click event that will take the name and reverse it,
         * displaying it in another textbox on the View.  */
        /*Status: Working properly--> The default assign name is Hughes, by clicking on the button(reverse)
         It will reverse the name and show it up in the textbox.*/
  
    public partial class MainWindow : Window
    {

        private Controller Control;

        public MainWindow()
        {
            InitializeComponent();

            // Create an object controller
            Control = new Controller { power = 10, name = "Hughes ", inputs = 20, outputs = 30 };
            this.DataContext = Control;
        }
           // handeln Button click event to reverse the name

        private void btnReverseName_Click(object sender, RoutedEventArgs e)
        {

            txtNameReverse.Text = ReverseString(Control.name);

        }
           // The Reverse method
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //------------------------------
        }

    }

}
