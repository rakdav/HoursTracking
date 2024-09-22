using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Teacher
{
    public int IdTeacher { get; set; }

    public string? Surname { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
