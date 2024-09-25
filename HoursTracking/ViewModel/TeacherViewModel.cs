using HoursTracking.Model;
using HoursTracking.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HoursTracking.ViewModel
{
    internal class TeacherViewModel: BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }
        public ObservableCollection<Teacher> TeachersList { get; set; }

        public TeacherViewModel()
        {
            db.Database.EnsureCreated();
            db.Teachers.OrderBy(p => p.FirstName).Load();
            TeachersList = db.Teachers.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      TeacherWindow window = new TeacherWindow(new Teacher());
                      if (window.ShowDialog() == true)
                      {
                          try
                          {
                              Teacher _teacher = window.ThisTeacher;
                              db.Teachers.Add(_teacher);
                              db.SaveChanges();
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
                      //// получаем выделенный объект
                      Teacher? user = selectedItem as Teacher;
                      if (user == null) return;

                      Teacher vm = new Teacher
                      {
                          IdTeacher = user.IdTeacher,
                          FirstName = user.FirstName,
                          Surname = user.Surname,
                          LastName=user.LastName
                      };
                      TeacherWindow userWindow = new TeacherWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          try
                          {
                              user.FirstName = userWindow.ThisTeacher.FirstName;
                              user.Surname = userWindow.ThisTeacher.Surname;
                              user.LastName = userWindow.ThisTeacher.LastName;
                              db.Entry(user).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                          catch(Exception e)
                          {
                              MessageBox.Show(e.Message);
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
                      Teacher? user = selectedItem as Teacher;
                      if (user == null) return;
                      db.Teachers.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
