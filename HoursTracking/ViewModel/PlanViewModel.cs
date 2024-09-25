using HoursTracking.Model;
using HoursTracking.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursTracking.ViewModel
{
    internal class PlanViewModel:BaseViewModel
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
        public ObservableCollection<Plan> PlanList { get; set; }
        public PlanViewModel()
        {
            db.Database.EnsureCreated();
            db.Plans.Load();
            PlanList = db.Plans.Local.ToObservableCollection();
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
                      //    try
                      //    {
                      //        Group spec = window.Group;
                      //        db.Groups.Add(spec);
                      //        db.SaveChanges();
                      //    }
                      //    catch
                      //    {
                      //        MessageBox.Show("Группа с таким названием уже существует");
                      //    }
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
                      //Group? user = selectedItem as Group;
                      //if (user == null) return;

                      //Group vm = new Group
                      //{
                      //    IdGroup = user.IdGroup,
                      //    NameGroup = user.NameGroup,
                      //    IdSpeciality = user.IdSpeciality
                      //};
                      //GroupWindow userWindow = new GroupWindow(vm);

                      //if (userWindow.ShowDialog() == true)
                      //{
                      //    try
                      //    {
                      //        user.NameGroup = userWindow.Group.NameGroup;
                      //        user.IdSpeciality = userWindow.Group.IdSpeciality;
                      //        db.Entry(user).State = EntityState.Modified;
                      //        db.SaveChanges();
                      //    }
                      //    catch
                      //    {
                      //        MessageBox.Show("Группа с таким названием уже существует");
                      //    }
                      //}
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
                      //Group? user = selectedItem as Group;
                      //if (user == null) return;
                      //db.Groups.Remove(user);
                      //db.SaveChanges();
                  }));
            }
        }
    }
}
