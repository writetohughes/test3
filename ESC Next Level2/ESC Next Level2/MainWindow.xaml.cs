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
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;


namespace ESC_Next_Level2
{
    //-------Date: 06/16/2014--------------------------------------------------------
    //-------Author:Hugues-----------------------------------------------------------
    /*2)	Program a button event that will count down a number from an entered number with a pause of another entered value on a form.
     * When the button is pressed, have two progress bars, one determinant and one indeterminant on separate threads show up in a separate view. 
     * Handle a cancel event to stop the countdown with a separate button.  */
    /*Status: Working -->: except that the cancel Button, which is supposed to stop the countdown also stop the Backgroungworker that I used for the 
     * first Progressbar giving an InvalidOperation Exception: This BackgroundWorker is currently busy and cannot run multiple tasks concurrently.
     The rest seems to be okay: The user just has to enter two Value and click on the countdown Button*/

    public partial class MainWindow: Window

    {   
        SecondProgressbar SPB;
        private int count = 0;
        // Create a  BackgroundWorker object for the first Progressbar
        BackgroundWorker worker = new BackgroundWorker();
        //Declare a dispatcher varaiable, wich will be use to create an object DispatcherTimer for the countdown
        private DispatcherTimer dispatcherTimer;

        public MainWindow()
        {
            InitializeComponent();

            // Using of BackgroundWorker object
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            //Create and display the second progressbar object
            SPB = new SecondProgressbar();
            SPB.Show();


           

        }
        
        // Handeln the countdown event
        private void CountDown_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text == null)
                MessageBox.Show("please enter a value");
            if (textBox2.Text == null)
                MessageBox.Show("please enter a value");
            string s = textBox1.Text;
            count = Convert.ToInt32(s);
            // If textBox2 is empty, assigns it the value 1
            int pause = int.TryParse(textBox2.Text, out pause) ? pause : 1;
            // Create a new Thread for the secondProgressbar
            Thread P = new Thread(SPB.StartSecondProgressbar);
            // Start the worker( the first progressbar)
            worker.RunWorkerAsync();
            // Start the second progressbar
            P.Start();
            //Create and start the dispatcherTimer for the countdown.
             dispatcherTimer = new DispatcherTimer();

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);

            dispatcherTimer.Interval = new TimeSpan(0, 0, pause);

            dispatcherTimer.Start();
        }
            // The Dowork event for the first progressbar
      private  void worker_DoWork(object sender, DoWorkEventArgs e)
                {
                        for(int i = 0; i < 100; i++)
                        {
                                (sender as BackgroundWorker).ReportProgress(i);
                                Thread.Sleep(100);
                        }

                }
            // The progresschanged event for the first progressbar
         private  void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
                {
                        pbStatus1.Value = e.ProgressPercentage;
                }

         // The complete event for the first progressba
         void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
         {
              if (e.Cancelled == false)
            {
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }
         }

               
                private void dispatcherTimer_Tick(object sender, EventArgs e)
                {
                    
                    
                    count -= 1;
                    textBox3.Text = count.ToString();                     
                   


                }

                private void Cancel_Click(object sender, RoutedEventArgs e)
                {
                    //  worker.CancelAsync();

                    dispatcherTimer.Stop();

                    //trying to manage the worker state
                    if (worker.IsBusy)
                    {
                        worker.CancelAsync();
                    }
                    else
                    {
                        worker.RunWorkerAsync();

                    }
                 
                }

        }
}
   

    


