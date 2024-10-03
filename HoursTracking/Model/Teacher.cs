using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HoursTracking.Model;

public partial class Teacher: BaseViewModel
{
    public int IdTeacher { get; set; }

    private string? surname;
    public string? Surname
    {
        get { return surname; }
        set
        {
            surname = value;
            OnPropertyChanged(nameof(Surname));
        }
    }

    private string? firstName;
    public string? FirstName 
    {
        get { return firstName; }
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string? lastName;
    public string? LastName 
    {
        get { return lastName; }
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }
    private string? fullName;
    public string? FullName
    {
        get { return fullName; }
        set
        {
            fullName = value;
            OnPropertyChanged(nameof(FullName));
        }
    }
    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();
}
