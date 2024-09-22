using HoursTracking.Model;
using Microsoft.VisualBasic.ApplicationServices;
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
    /// Логика взаимодействия для AcademicYearWindow.xaml
    /// </summary>
    public partial class AcademicYearWindow : Window
    {
        public AcademicYear AcademicYear { get; private set; }
        public AcademicYearWindow(AcademicYear _academicYear)
        {
            InitializeComponent();
            AcademicYear = _academicYear;
            DataContext = AcademicYear;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
