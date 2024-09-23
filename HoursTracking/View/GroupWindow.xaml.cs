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
    /// Логика взаимодействия для GroupWindow.xaml
    /// </summary>
    public partial class GroupWindow : Window
    {
        public Group Group { get; private set; }
        private HoursTrackingContext db = new HoursTrackingContext();
        public GroupWindow(Group _group)
        {
            InitializeComponent();
            Group = _group;
            DataContext = Group;
            SpecList.ItemsSource = db.Specialities.ToList();
            if (Group.IdGroup != 0)
            {
                List<Speciality> list = db.Specialities.ToList();
                SpecList.Text = list.FirstOrDefault(p=>p.IdSpeciality==Group.IdSpeciality)!.NameSpeciality;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Group.NameGroup = GroupNameText.Text;
            Group.IdSpeciality =db.Specialities.ToList()[SpecList.SelectedIndex].IdSpeciality;
            DialogResult = true;
        }
    }
}
