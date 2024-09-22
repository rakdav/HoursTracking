using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Subject
{
    public int IdSubject { get; set; }

    public string NameSubject { get; set; } = null!;

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
