using HoursTracking.View;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursTracking.ViewModel
{
    internal class MainWindowViewModel
    {
        private RelayCommand? academicYearCommand;
        public RelayCommand AcademicYearCommand
        {
            get
            {
                return academicYearCommand ??
                  (academicYearCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new AcademicYearPage());
                  }));
            }
        }
        private RelayCommand? specialityCommand;
        public RelayCommand SpecialityCommand
        {
            get
            {
                return specialityCommand ??
                  (specialityCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new SpecialityPage());
                  }));
            }
        }
        private RelayCommand? groupCommand;
        public RelayCommand GroupCommand
        {
            get
            {
                return groupCommand ??
                  (groupCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new GroupPage());
                  }));
            }
        }
    }
}
