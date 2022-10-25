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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();

            List<string> styles = new List<string> { "light", "dark" };
            styleBox.SelectionChanged += ThemeChange;
            styleBox.ItemsSource = styles;
            styleBox.SelectedItem = "dark";

            List<string> language = new List<string> { "EN", "UK" };
            styleBox_Language.ItemsSource = language;
            styleBox_Language.SelectedItem = "EN";
            styleBox_Language.SelectionChanged += LanguageChange;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = styleBox.SelectedItem as string;
            var uri = new Uri(@"\Dictionary\Themes\" + style + ".xaml", UriKind.Relative);

            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void LanguageChange(object sender, SelectionChangedEventArgs e)
        {
           string style = styleBox_Language.SelectedItem as string;
              /* var uri = new Uri(@"\Dictionary\Language\" + style + ".xaml", UriKind.Relative);

             ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
             Application.Current.Resources.Clear();
             Application.Current.Resources.MergedDictionaries.Add(resourceDict);*/

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("UK");

           // MainWindow.Frame.Navigate(new Settings());
           
        }

    }
}
