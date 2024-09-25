using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HoursTracking.Model;

public partial class Subject: BaseViewModel
{
    public int IdSubject { get; set; }
    private string? nameSubject;
    public string? NameSubject 
    {
        get { return nameSubject; }
        set
        {
            nameSubject = value;
            OnPropertyChanged(nameof(NameSubject));
        }
    }
    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
