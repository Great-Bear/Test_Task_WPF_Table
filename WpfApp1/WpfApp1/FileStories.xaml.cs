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
    /// Логика взаимодействия для FileStories.xaml
    /// </summary>
    public partial class FileStories : Page
    {
        public FileStories()
        {
            InitializeComponent();
        }
        public double MinWidth { get; set; } = 115;
        private void WrapPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var wrapPanel = sender as WrapPanel;

            double CountElemnts = Math.Floor(ContainerFiles.ActualWidth / MinWidth);

            if(CountElemnts > WrapPanel.Children.Count)
            {
                CountElemnts = WrapPanel.Children.Count;
            }
            if(CountElemnts == 1)
            {
                wrapPanel.ItemWidth = MinWidth;
                return;
            }
            if(CountElemnts == 0)
            {
                wrapPanel.ItemWidth = MinWidth;
                return;
            }

            double FreeWidth = ContainerFiles.ActualWidth - (CountElemnts * MinWidth);

            wrapPanel.ItemWidth = MinWidth + FreeWidth / CountElemnts;
        }
    }
}
