using HoursTracking.Model;
using HoursTracking.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HoursTracking.ViewModel
{
    public class PlanViewModel:BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private Plan selectedPlan;
        public Plan SelectedPlan
        {
            get { return selectedPlan; }
            set
            {
                selectedPlan = value;
                OnPropertyChanged(nameof(SelectedPlan));
            }
        }
        private AcademicYear selectedAcademicYear;
        public AcademicYear SelectedAcademicYear
        {
            get { return selectedAcademicYear; }
            set
            {
                selectedAcademicYear = value;
                OnPropertyChanged(nameof(SelectedAcademicYear));
            }
        }
        public ObservableCollection<Plan> PlanList { get; set; } = new();
        public List<AcademicYear> AcademicYearList { get; set; }
        public PlanViewModel()
        {
            db.Database.EnsureCreated();
            AcademicYearList = db.AcademicYears.OrderBy(p=>p.NameYear).ToList();
            SelectedAcademicYear = AcademicYearList[AcademicYearList.Count-1];
            UpdateList();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      PlanWindow window = new PlanWindow(new Plan());
                      if (window.ShowDialog() == true)
                      {
                          try
                          {
                              Plan spec = window.ThisPlan;
                              db.Plans.Add(spec);
                              db.SaveChanges();
                              UpdateList();
                          }
                          catch(Exception e)
                          {
                              MessageBox.Show(e.Message);
                          }
                      }
                  }));
            }
        }
        private RelayCommand? editCommand;
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ??
                  (editCommand = new RelayCommand((selectedItem) =>
                  {
                      // получаем выделенный объект
                      Plan? user = selectedItem as Plan;
                      if (user == null) return;

                      Plan vm = new Plan
                      {
                          IdPlan = user.IdPlan,
                          IdAcademicYear = user.IdAcademicYear,
                          IdGroup = user.IdGroup,
                          IdTeacher=user.IdTeacher,
                          IdSubject=user.IdSubject,
                          Semestr=user.Semestr,
                          IndependentWork=user.IndependentWork,
                          NecessarilyWork=user.NecessarilyWork
                      };
                      PlanWindow userWindow = new PlanWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          try
                          {
                              user.IdAcademicYear = userWindow.ThisPlan.IdAcademicYear;
                              user.IdGroup = userWindow.ThisPlan.IdGroup;
                              user.IdSubject = userWindow.ThisPlan.IdSubject;
                              user.IdAcademicYear = userWindow.ThisPlan.IdAcademicYear;
                              user.Semestr = userWindow.ThisPlan.Semestr;
                              user.NecessarilyWork = userWindow.ThisPlan.NecessarilyWork;
                              user.IndependentWork = userWindow.ThisPlan.IndependentWork;
                              db.Entry(user).State = EntityState.Modified;
                              db.SaveChanges();
                              UpdateList();
                          }
                          catch
                          {
                              MessageBox.Show("Группа с таким названием уже существует");
                          }
                      }
                  }));
            }
        }
        private RelayCommand? deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand((selectedItem) =>
                  {
                      Plan? user = selectedItem as Plan;
                      if (user == null) return;
                      db.Plans.Remove(user);
                      db.SaveChanges();
                      UpdateList();
                  }));
            }
        }
        private RelayCommand? regionChangedCmd;
        public RelayCommand RegionChangedCmd
        {
            get
            {
                return regionChangedCmd ??
                  (regionChangedCmd = new RelayCommand((o) =>
                  {
                      UpdateList();
                  }));
            }
        }
        private void UpdateList()
        {
            var list = db.Plans.Where(p => p.IdAcademicYear == selectedAcademicYear.IdAcademicYear).ToList();
            ObservableCollection<Plan> obsList = new ObservableCollection<Plan>(list);
            PlanViewPage.Instance!.PlanListBox.ItemsSource = obsList;
        }
    }
}
