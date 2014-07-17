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
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;



namespace ESC_Next_Level2
{
    /// <summary>
    /// Interaction logic for SecondProgressbar.xaml
    /// </summary>
    public partial class SecondProgressbar : Window
    {
        public SecondProgressbar()
        {
            InitializeComponent();
        }


     // Method to start the scond progressbar

       public void StartSecondProgressbar()
        {
           //Make a use of the dispatcher.Invoke to handeln the second progressbar
           this.Dispatcher.Invoke((Action)(() =>
    {
        for (int i = 0; i < 100; i++)
        {
            pbStatus2.Value++;
           

        }
    }));
           
        }

    }
}
