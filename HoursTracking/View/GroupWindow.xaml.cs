﻿using HoursTracking.Model;
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

namespace HoursTracking.View
{
    /// <summary>
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public Group Group { get; private set; }
        private HoursTrackingContext db = new HoursTrackingContext();
        private List<Speciality> SpecialistList { get; set; } = new();
        public GroupWindow(Group _group)
        {
            InitializeComponent();
            Group = _group;
            DataContext = Group;
            SpecialistList= db.Specialities.ToList();
            SpecList.ItemsSource = SpecialistList;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
