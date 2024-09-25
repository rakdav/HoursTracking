using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HoursTracking.Model;

public partial class Speciality: BaseViewModel
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
    
}
