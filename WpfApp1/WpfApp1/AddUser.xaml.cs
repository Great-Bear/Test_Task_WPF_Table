﻿using System;
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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    /// 
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();
            DataContext = new AddUserViewModel();
        }
    }
}
