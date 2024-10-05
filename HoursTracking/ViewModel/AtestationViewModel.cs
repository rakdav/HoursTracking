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
using System.Windows.Controls;

namespace HoursTracking.ViewModel
{
    internal class AtestationViewModel: BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private Certification? selectedCertification;
        public Certification? SelectedCertification
        {
            get { return selectedCertification; }
            set
            {
                selectedCertification = value;
                OnPropertyChanged(nameof(SelectedCertification));
            }
        }
        public string fieldFilter;
        public string FieldFilter
        {
            get { return fieldFilter; }
            set
            {
                fieldFilter = value;
                OnPropertyChanged(nameof(FieldFilter));
            }
        }
        public ObservableCollection<Certification> AtestationList { get; set; } = new();
        public AtestationViewModel()
        {
            db.Database.EnsureCreated();
            db.Certifications.Load();
            AtestationList = db.Certifications.Local.ToObservableCollection();
        }

        private RelayCommand? fieldChanged;
        public RelayCommand FieldChanged
        {
            get
            {
                return fieldChanged ??
                  (fieldChanged = new RelayCommand((o) =>
                  {
                      switch (fieldFilter)
                      {
                          case "Преподаватель":
                              try
                              {
                                  string text = (o as TextBox).Text;
                                  if (db.Teachers.FirstOrDefault(p => p.FullName!.StartsWith(text)) != null&&text.Length!=0)
                                  {
                                      int idTeacher = db.Teachers.FirstOrDefault(p => p.FullName!.StartsWith(text))!.IdTeacher;
                                      List<Certification> list = db.Certifications.Where(p => p.IdTeacher == idTeacher).OrderBy(p=>p.DateCertification).ToList();
                                      if (list != null)
                                      {
                                          AtestationPage.Instance.AtestationListBox.ItemsSource = null;
                                          AtestationPage.Instance.AtestationListBox.ItemsSource = list;
                                      }
                                  }
                                  else
                                  {
                                      AtestationPage.Instance.AtestationListBox.ItemsSource = null;
                                      AtestationPage.Instance.AtestationListBox.ItemsSource = db.Certifications.ToList();
                                  }
                              }
                              catch(Exception e) 
                              {
                                  
                              }
                              break;
                          case "Предмет":
                              try
                              {
                                  string text = (o as TextBox).Text;
                                  if (db.Subjects.FirstOrDefault(p => p.NameSubject!.StartsWith(text)) != null && text.Length != 0)
                                  {
                                      int idSubject = db.Subjects.FirstOrDefault(p => p.NameSubject!.StartsWith(text))!.IdSubject;
                                      List<Certification> list = db.Certifications.Where(p => p.IdSubject == idSubject).OrderBy(p => p.DateCertification).ToList();
                                      if (list != null)
                                      {
                                          AtestationPage.Instance.AtestationListBox.ItemsSource = null;
                                          AtestationPage.Instance.AtestationListBox.ItemsSource = list;
                                      }
                                  }
                                  else
                                  {
                                      AtestationPage.Instance.AtestationListBox.ItemsSource = null;
                                      AtestationPage.Instance.AtestationListBox.ItemsSource = db.Certifications.ToList();
                                  }
                              }
                              catch (Exception e)
                              {

                              }
                              break;
                      }
                   
                  }));
            }
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      AtestationWindow window = new AtestationWindow(new Certification());
                      if (window.ShowDialog() == true)
                      {
                          try
                          {
                              Certification spec = window.ThisCertification;
                              db.Certifications.Add(spec);
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
                      // получаем выделенный объект
                      Certification? user = selectedItem as Certification;
                      if (user == null) return;

                      Certification vm = new Certification
                      {
                          IdGroup = user.IdGroup,
                          DateCertification = user.DateCertification,
                          IdSubject = user.IdSubject,
                          IdTeacher=user.IdTeacher,
                          TypeCertification=user.TypeCertification,
                          Hours=user.Hours,
                          IdCertification=user.IdCertification
                      };
                      AtestationWindow userWindow = new AtestationWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          try
                          {
                              user.Hours = userWindow.ThisCertification.Hours;
                              user.IdGroup = userWindow.ThisCertification.IdGroup;
                              user.DateCertification = userWindow.ThisCertification.DateCertification;
                              user.TypeCertification = userWindow.ThisCertification.TypeCertification;
                              user.IdSubject = userWindow.ThisCertification.IdSubject;
                              user.IdTeacher = userWindow.ThisCertification.IdTeacher;
                              db.Entry(user).State = EntityState.Modified;
                              db.SaveChanges();
                          }
                          catch(Exception ex)
                          {
                              MessageBox.Show(ex.Message);
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
                      Certification? user = selectedItem as Certification;
                      if (user == null) return;
                      db.Certifications.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
