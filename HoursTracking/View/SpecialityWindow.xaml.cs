using HoursTracking.Model;
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
    /// Логика взаимодействия для SpecialityWindow.xaml
    /// </summary>
    public partial class SpecialityWindow : Window
    {
        public Speciality Speciality { get; private set; }
        public SpecialityWindow(Speciality _speciality)
        {
            InitializeComponent();
            Speciality = _speciality;
            DataContext = Speciality;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
