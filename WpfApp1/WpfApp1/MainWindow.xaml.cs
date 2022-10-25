using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using WPFLocalizeExtension.Extensions;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame Frame;
        public MainWindow()
        {
            InitializeComponent();
            ListUsersBtn.Click += ListUsersClick;
            SettingsBtn.Click += SettingsClick;

            DataContext = new MainWindowViewModel();

            Frame = frame;
            var ViewModel = DataContext as MainWindowViewModel;
            frame.Navigate(new UserControll());


            lexLocalizatoin.SelectionChanged += LexLocalizatoin_SelectionChanged;

        }

        private void LexLocalizatoin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(GetLocalizedValue<string>("TestName"));
        }

        private void ListUsersClick(object sender, RoutedEventArgs e)
        {
            var ViewModel = DataContext as MainWindowViewModel;
            frame.Navigate(new UserControll());
        }

        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Settings());
        }

        public static T GetLocalizedValue<T>(string key)
        {
            return LocExtension.GetLocalizedValue<T>
            (Assembly.GetCallingAssembly().GetName().Name + @"\Dictionary\LanguageRESX\Default" + key);
        }

    }
}
