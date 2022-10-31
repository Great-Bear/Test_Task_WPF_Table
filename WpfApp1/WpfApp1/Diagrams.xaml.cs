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
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Diagrams.xaml
    /// </summary>
    public partial class Diagrams : Page
    {
        public Diagrams()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 100, 500, 390, 500, 210, 120, 900, 800, 650 },
                    Fill = Brushes.Blue
                }
            };
            Labels = new[] { "Jan-22", "Feb-22", "Mar-22", "Apr-22", "Apr-23", "May-24", "Jun-25", "Jul-26", "Sep-27", };
            Formatter = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
