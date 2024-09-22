using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Certification
{
    public int IdCertification { get; set; }

    public int IdSubject { get; set; }

    public int IdTeacher { get; set; }

    public int IdGroup { get; set; }

    public DateOnly DateCertification { get; set; }

    public int Hours { get; set; }

    public string TypeCertification { get; set; } = null!;

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
