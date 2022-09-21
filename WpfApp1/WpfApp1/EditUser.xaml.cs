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
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        public EditUser(ApplicationViewModel _applicationContext)
        {
            InitializeComponent();
            DataContext = _applicationContext;
            ResetBtn.Click += ResetUserClick;
            SaveBtn.Click += SaveUserClick;
        }

        private void SaveUserClick(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void ResetUserClick(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            NameTbx.Text = String.Empty;
            SurNameTbx.Text = String.Empty;
            DescriptionTbx.Text = String.Empty;
        }
    }
}
