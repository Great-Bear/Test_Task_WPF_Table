﻿using System;
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

        private void WrapPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var wrapPanel = sender as WrapPanel;

           
        }
    }
}
