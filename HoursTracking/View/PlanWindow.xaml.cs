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
    /// Логика взаимодействия для PlanWindow.xaml
    /// </summary>
    public partial class PlanWindow : Window
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        public Plan ThisPlan { get; private set; }
        //public List<Speciality> SpecialistList { get; set; } = new();
        //public List<Group> GroupList { get; set; } = new();
        //public List<Teacher> TeacherList { get; set; } = new();
        public PlanWindow(Plan _plan)
        {
            InitializeComponent();
            ThisPlan = _plan;
            DataContext = ThisPlan;
            SpecList.ItemsSource = db.Specialities.ToList();
            if(_plan.IdGroup!=0)
                SpecList.SelectedValue = db.Groups.FirstOrDefault(p => p.IdGroup == _plan.IdGroup)!.IdSpeciality;
            GroupsComboBox.ItemsSource = db.Groups.ToList();
            TeachersComboBox.ItemsSource = db.Teachers.ToList();
            ОbjectComboBox.ItemsSource = db.Subjects.ToList();
            YearComboBox.ItemsSource = db.AcademicYears.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
