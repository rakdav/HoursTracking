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

namespace HoursTracking.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для AtestationWindow.xaml
    /// </summary>
    public partial class AtestationWindow : Window
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        public Certification ThisCertification { get; private set; }
        public AtestationWindow(Certification _cert)
        {
            InitializeComponent();
            ThisCertification = _cert;
            DataContext = ThisCertification;
            TeacherComboBox.ItemsSource = db.Teachers.ToList();
            SubjectComboBox.ItemsSource = db.Subjects.ToList();
            GroupComboBox.ItemsSource = db.Groups.ToList();
            if (_cert.IdCertification != 0)
                DateCertDatePicker.Text =_cert.DateCertification.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThisCertification.DateCertification =DateOnly.FromDateTime(DateCertDatePicker.SelectedDate!.Value);
            DialogResult = true;
        }
    }
}
