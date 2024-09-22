using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Group
{
    public int IdGroup { get; set; }

    public string NameGroup { get; set; } = null!;

    public int IdSpeciality { get; set; }

    public virtual ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    public virtual Speciality IdSpecialityNavigation { get; set; } = null!;

    public virtual ICollection<Plan> Plans { get; set; } = new List<Plan>();

    public virtual ICollection<Statement> Statements { get; set; } = new List<Statement>();
}
