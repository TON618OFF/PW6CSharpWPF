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

namespace PW6CSharpWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainPageViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainPageViewModel();
            DataContext = _viewModel;
        }

        private void CalendarControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.SetCurrentDate();
        }

        private void CalendarControl_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedDateChanged();
        }

        private void DaySquare_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _viewModel.ShowContextMenu();
        }
    }
}
