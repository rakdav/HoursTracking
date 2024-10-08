﻿using BespokeFusion;
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
    internal class GroupViewModel: BaseViewModel
    {
        private HoursTrackingContext db = new HoursTrackingContext();
        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }
        public ObservableCollection<Group> GroupsList { get; set; }
        public GroupViewModel()
        {
            db.Database.EnsureCreated();
            db.Groups.OrderBy(p=>p.NameGroup).Load();
            GroupsList= db.Groups.Local.ToObservableCollection();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      GroupWindow window = new GroupWindow(new Group());
                      if (window.ShowDialog() == true)
                      {
                          try
                          {
                              Group spec = window.Group;
                              db.Groups.Add(spec);
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
                      Group? user = selectedItem as Group;
                      if (user == null) return;

                      Group vm = new Group
                      {
                          IdGroup=user.IdGroup,
                          NameGroup = user.NameGroup,
                          IdSpeciality= user.IdSpeciality
                      };
                      GroupWindow userWindow = new GroupWindow(vm);

                      if (userWindow.ShowDialog() == true)
                      {
                          try
                          {
                              user.NameGroup = userWindow.Group.NameGroup;
                              user.IdSpeciality = userWindow.Group.IdSpeciality;
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
                      Group? user = selectedItem as Group;
                      if (user == null) return;
                      db.Groups.Remove(user);
                      db.SaveChanges();
                  }));
            }
        }
    }
}
