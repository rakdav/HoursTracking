using HoursTracking.Model;
using HoursTracking.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoursTracking.ViewModel
{
    internal class AcademicYearViewModel: BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
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
        public ObservableCollection<AcademicYear> AcademicYears { get; set; }
        public AcademicYearViewModel()
        {
            db.Database.EnsureCreated();
            db.AcademicYears.OrderBy(p=>p.NameYear).Load();
            AcademicYears = db.AcademicYears.Local.ToObservableCollection();
        }

        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      AcademicYearWindow window = new AcademicYearWindow(new AcademicYear());
                      if (window.ShowDialog() == true)
                      {
                          AcademicYear user = window.AcademicYear;
                          db.AcademicYears.Add(user);
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
                      AcademicYear? user = selectedItem as AcademicYear;
                      if (user == null) return;

                      AcademicYear vm = new AcademicYear
                      {
                          NameYear=user.NameYear,
                          Automn=user.Automn,
                          Winter=user.Winter
                      };
                      AcademicYearWindow userWindow = new AcademicYearWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          user.NameYear = userWindow.AcademicYear.NameYear;
                          user.Automn = userWindow.AcademicYear.Automn;
                          user.Winter = userWindow.AcademicYear.Winter;
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
                      AcademicYear? user = selectedItem as AcademicYear;
                      if (user == null) return;
                      db.AcademicYears.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
