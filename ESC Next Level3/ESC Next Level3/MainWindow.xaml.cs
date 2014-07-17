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
using System.IO;
using Microsoft.Win32;
using System.Xml;


namespace ESC_Next_Level3
{
    //-------Date: 06/16/2014--------------------------------------------------------
    //-------Author:Hugues-----------------------------------------------------------
    /*Present a datagrid which has an ability to add additional data.  The Model will have the same elements as question 1. 
     * Save and open the data in an xml file.  The collection will be a list.  */
    /*Status: Working properly-->This application display a list of Data from the controller Class on a Datagrid and 
     * save and open xml Data on  the 4 textboxs. I made a use of the xmlserialiser by implementing XmlSave and XmlLoad<T> class
     * The saving directory can be changed in btnSaveFile_Click;
     * The xml file name can be changed in the btnOpenFile_Click;
     */
    public partial class MainWindow : Window
    {
        //private Controller Control;
         List<Controller> list;

        public MainWindow()
        {
            InitializeComponent();
            // create a list to add to the Datagrid
            list = new List<Controller>();
            //
            list.Add(new Controller() { name = "Hughes ", power = 10, inputs = 20, outputs = 30 });
            list.Add(new Controller() { name = "Jeannette ", power = 10, inputs = 10, outputs = 20 });
            list.Add(new Controller() { name = "Nelson ", power = 10, inputs = 10, outputs = 10 });
            list.Add(new Controller() { name = "Brayan ", power = 10, inputs = 20, outputs = 30 });

            // add the data to the Datagrid
            dgSimple.ItemsSource = list;

        }
        
        // Handeln open data event
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            Controller controller = new Controller();
            XmlLoad<Controller> loadController = new XmlLoad<Controller>();
            //Give the name of the file that you like to load
            controller = loadController.LoadData("text2.xml");
            textBoxName.Text = controller.name;
            textBoxPower.Text = Convert.ToString(controller.power);
            textBoxInputs.Text = Convert.ToString(controller.inputs);
            textBoxOutputs.Text = Convert.ToString(controller.outputs);

         // Handeln save event   
        }
        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
           
              
              SaveFileDialog saveFileDialog = new SaveFileDialog();
            // Initial Directory can be changed to whatever you want
              saveFileDialog.InitialDirectory = @"C:\Users\Hugo\Desktop\ESC Next Level\ESC Next Level3\ESC Next Level3\bin\Debug"; 
              saveFileDialog.Filter = "XMl files (*.xml)|*.xml";
              saveFileDialog.FilterIndex = 4;
              saveFileDialog.RestoreDirectory = true;
              if (saveFileDialog.ShowDialog() == true)
              {
                  // Save Data
                  Controller controller = new Controller();
                  controller.name = "Hughes";
                  controller.power = 10;
                  controller.inputs = 20;
                  controller.outputs = 30;
                  XmlSave.SaveData(controller, saveFileDialog.FileName );
                        
              }
          
         
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //------------------------------
        }


        
    }

        
        
        }

    

