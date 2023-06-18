using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfControlsFiveApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Product> products = new List<Product>()
        {
            new(){ Title="Notebook", Brand="Acer", Price=35000 },
            new(){  Title="Computer", Brand="HP", Price=56000 },
            new(){  Title="Phone", Brand="Samsung", Price=17000 }
        };
        public MainWindow()
        {
            InitializeComponent();
            data.ItemsSource = products;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            foreach(var date in calendar.SelectedDates)
            {
                message += date.ToLongDateString() + "\n";
            }
            MessageBox.Show(message);
        }

        private void red_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Background = new SolidColorBrush(Color.FromRgb((byte)red.Value, (byte)green.Value, (byte)blue.Value));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += workerDoWork;
            worker.ProgressChanged += (sender, e) => { pgrBar.Value = e.ProgressPercentage; };

            worker.RunWorkerAsync();
        }

        private void workerDoWork(object? sender, DoWorkEventArgs e)
        {
            for(int i = 0; i <= 100; i++)
            {
                if (sender is BackgroundWorker wrk)
                    wrk.ReportProgress(i);
                Thread.Sleep(100);
            }
        }
    }
}
