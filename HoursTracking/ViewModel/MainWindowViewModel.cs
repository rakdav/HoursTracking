﻿using HoursTracking.View;
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
        public MainWindowViewModel()
        {
            MainWindow.Instance!.MainFrame.Navigate(new CertificationPage());
        }
        private RelayCommand? mainCommand;
        public RelayCommand MainCommand
        {
            get
            {
                return mainCommand ??
                  (mainCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new CertificationPage());
                  }));
            }
        }
        private RelayCommand? atestationCommand;
        public RelayCommand AtestationCommand
        {
            get
            {
                return atestationCommand ??
                  (atestationCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new AtestationPage());
                  }));
            }
        }
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

        private RelayCommand? teacherCommand;
        public RelayCommand TeacherCommand
        {
            get
            {
                return teacherCommand ??
                  (teacherCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new TeacherPage());
                  }));
            }
        }

        private RelayCommand? subjectCommand;
        public RelayCommand SubjectCommand
        {
            get
            {
                return subjectCommand ??
                  (subjectCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new SubjectPage());
                  }));
            }
        }
        private RelayCommand? planCommand;

        public RelayCommand PlanCommand
        {
            get
            {
                return planCommand ??
                  (planCommand = new RelayCommand((o) =>
                  {
                      MainWindow.Instance!.MainFrame.Navigate(new PlanViewPage());
                  }));
            }
        }
    }
}
