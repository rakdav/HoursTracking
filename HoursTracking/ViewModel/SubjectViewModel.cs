using HoursTracking.Model;
using HoursTracking.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HoursTracking.ViewModel
{
    internal class SubjectViewModel:BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private Subject selectedSubject;
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        public ObservableCollection<Subject> SubjectList { get; set; }
        public SubjectViewModel()
        {
            db.Database.EnsureCreated();
            db.Subjects.OrderBy(p => p.NameSubject).Load();
            SubjectList = db.Subjects.Local.ToObservableCollection();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      SubjectWindow window = new SubjectWindow(new Subject());
                      if (window.ShowDialog() == true)
                      {
                          try
                          {
                              Subject spec = window.ThisSubject;
                              db.Subjects.Add(spec);
                              db.SaveChanges();
                          }
                          catch
                          {
                              MessageBox.Show("Группа с таким названием уже существует");
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
                      //// получаем выделенный объект
                      Subject? user = selectedItem as Subject;
                      if (user == null) return;

                      Subject vm = new Subject
                      {
                          IdSubject = user.IdSubject,
                          NameSubject = user.NameSubject
                      };
                      SubjectWindow userWindow = new SubjectWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          try
                          {
                              user.NameSubject = userWindow.ThisSubject.NameSubject;
                              db.Entry(user).State = EntityState.Modified;
                              db.SaveChanges();
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
                      Subject? user = selectedItem as Subject;
                      if (user == null) return;
                      db.Subjects.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
