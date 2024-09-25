using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HoursTracking.Model;

public partial class Group: BaseViewModel
{
    public int IdGroup { get; set; }

    private string? nameGroup;
    public string? NameGroup 
    {
        get { return nameGroup; }
        set
        {
            nameGroup = value;
            OnPropertyChanged(nameof(NameGroup));
        }
    }
    private int idSpeciality;
    public int IdSpeciality 
    {
        get { return idSpeciality; }
        set
        {
            idSpeciality = value;
            OnPropertyChanged(nameof(IdSpeciality));
        }
    }

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual Speciality IdSpecialityNavigation { get; set; } = null!;

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
