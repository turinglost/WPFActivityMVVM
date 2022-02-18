using System;
using System.Collections.Generic;
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
using WPFActivityMVVM.MVVM;

namespace WPFActivityMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAntiPattern_Click(object sender, RoutedEventArgs e)
        {
            AntiPattern win = new AntiPattern();
            win.Show();
        }

        private void BtnMVVMBindings_Click(object sender, RoutedEventArgs e)
        {
            ActivityView window = new ActivityView();
            ActivityViewModel viewModel = new ActivityViewModel();
            window.DataContext = viewModel;
            window.Show();
        }
    }
}
