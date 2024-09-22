using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Statement
{
    public int IdStatement { get; set; }

    public int IdSubject { get; set; }

    public int IdTeacher { get; set; }

    public int Hours { get; set; }

    public DateOnly DateStatement { get; set; }

    public int IdGroup { get; set; }

    public int IdAcademicYear { get; set; }

    public virtual Group IdAcademicYear1 { get; set; } = null!;

    public virtual AcademicYear IdAcademicYearNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
