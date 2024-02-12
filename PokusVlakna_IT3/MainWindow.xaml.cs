using System.ComponentModel;
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

namespace PokusVlakna_IT3
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private int x=50;
    private BackgroundWorker worker1;
    private BackgroundWorker worker2;

    public MainWindow()
    {
      InitializeComponent();
      Refresh();
      worker1 = new BackgroundWorker();
      worker1.DoWork += Worker1_DoWork;
      worker1.WorkerReportsProgress = true;
      worker1.ProgressChanged += Worker1_ProgressChanged;
      worker2 = new BackgroundWorker();
      worker2.DoWork += Worker2_DoWork;
      worker2.WorkerReportsProgress = true;
      worker2.ProgressChanged += Worker2_ProgressChanged; 
    }

    private void Worker2_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
      x--;
      Refresh();
    }

    private void Worker2_DoWork(object? sender, DoWorkEventArgs e)
    {
      while (x > -1000)
      {
        worker2.ReportProgress(1);
        Thread.Sleep(100);
      }
    }

    private void Worker1_ProgressChanged(object? sender, ProgressChangedEventArgs e)
    {
      x++;
      Refresh();
    }

    private void Worker1_DoWork(object? sender, DoWorkEventArgs e)
    {
      while (x < 1000)
      {
        worker1.ReportProgress(1);
        Thread.Sleep(200);
      }      
    }

    public void Refresh()
    {
      LabelX.Content = $"X={x}";
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      worker1.RunWorkerAsync();
      worker2.RunWorkerAsync();
    }
  }
}