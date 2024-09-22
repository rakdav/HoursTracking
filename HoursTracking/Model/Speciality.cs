using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HoursTracking.Model;

public partial class Speciality: INotifyPropertyChanged
{
    public int IdSpeciality { get; set; }

    public string? nameSpeciality;
    public string? NameSpeciality 
    {
        get { return nameSpeciality; }
        set 
        {
            nameSpeciality = value;
            OnPropertyChanged(nameof(NameSpeciality));
        } 
    }
    public string? specialityCode;
    public string? SpecialityCode 
    {
        get 
        {
            return specialityCode;
        }
        set 
        {
            specialityCode = value;
            OnPropertyChanged(nameof(SpecialityCode));
        } 
    }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
