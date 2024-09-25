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

namespace HoursTracking.ViewModel
{
    internal class SpecialityViewModel : BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private Speciality selectedSpeciality;
        public Speciality SelectedSpeciality
        {
            get { return selectedSpeciality; }
            set
            {
                selectedSpeciality = value;
                OnPropertyChanged(nameof(SelectedSpeciality));
            }
        }
        public ObservableCollection<Speciality> Specialities { get; set; }
        public SpecialityViewModel()
        {
            db.Database.EnsureCreated();
            db.Specialities.OrderBy(p => p.NameSpeciality).Load();
            Specialities = db.Specialities.Local.ToObservableCollection();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      SpecialityWindow window = new SpecialityWindow(new Speciality());
                      if (window.ShowDialog() == true)
                      {
                          Speciality spec = window.Speciality;
                          db.Specialities.Add(spec);
                          db.SaveChanges();
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
                      Speciality? user = selectedItem as Speciality;
                      if (user == null) return;

                      Speciality vm = new Speciality
                      {
                          NameSpeciality = user.NameSpeciality,
                          SpecialityCode=user.specialityCode
                      };
                      SpecialityWindow userWindow = new SpecialityWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          user.NameSpeciality = userWindow.Speciality.NameSpeciality;
                          user.SpecialityCode = userWindow.Speciality.SpecialityCode;
                          db.Entry(user).State = EntityState.Modified;
                          db.SaveChanges();
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
                      Speciality? user = selectedItem as Speciality;
                      if (user == null) return;
                      db.Specialities.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
