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
    /// Логика взаимодействия для AdminStreet.xaml
    /// </summary>
    public partial class AdminStreet : Window
    {
        public AdminStreet()
        {
            InitializeComponent();
            AdminStreetVM viewModel = new AdminStreetVM();
            DataContext = viewModel;
            viewModel.ClosingRequest += (sender, e) => Close();
        }

        private void citySelector1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
