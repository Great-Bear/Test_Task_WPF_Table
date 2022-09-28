using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Test_Task_WPF_Table.Classes;
using WpfApp1.Classes.ViewModels;
using WpfApp1.ClassesConverter;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListUsersBtn.Click += ListUsersClick;
            DataContext = new MainWindowViewModel();

            var ViewModel = DataContext as MainWindowViewModel;
            frame.Navigate(new ListUsers());
        }

        private void ListUsersClick(object sender, RoutedEventArgs e)
        {
            var ViewModel = DataContext as MainWindowViewModel;
            frame.Navigate(new ListUsers());
        }
    }
}
