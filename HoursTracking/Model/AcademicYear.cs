using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HoursTracking.Model;

public partial class AcademicYear:INotifyPropertyChanged
{
    public int IdAcademicYear { get; set; }

    private string? nameYear;
    public string? NameYear 
    {
        get { return nameYear; }
        set
        {
            nameYear = value;
            OnPropertyChanged(nameof(NameYear));
        }
    }

    private int automn;
    public int Automn 
    {
        get { return automn; } 
        set
        {
            automn = value;
            OnPropertyChanged(nameof(Automn));
        }
    }

    private int winter;
    public int Winter 
    {
        get { return winter; }
        set
        {
            winter = value;
            OnPropertyChanged(nameof(Winter));
        }
    }
    
    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
