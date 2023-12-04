using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
using System.Timers;
namespace processes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            Set_tim();
            FrameworkElement element = new FrameworkElement();
            Process[] procedures = Process.GetProcesses().OrderBy(process => process.ProcessName.ToString()).ToArray();
            DataContext = procedures;
        }
        static void Set_tim()
        {
            timer = new Timer(3000);
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void proc_kill_Click(object sender, RoutedEventArgs e)
        {
            Process selected = (Process)list.SelectedItem;
            selected.Kill();
        }
    }
}