﻿using Map.ViewModels.Admin;
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
using System.Windows.Shapes;

namespace Map.Views.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminResident.xaml
    /// </summary>
    public partial class AdminResident : Window
    {
        public AdminResident()
        {
            InitializeComponent();
            AdminResidentVM residentModel = new AdminResidentVM();
            DataContext = residentModel;
            residentModel.ClosingRequest += (sender, e) => Close();
        }
    }
}
