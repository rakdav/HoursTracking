using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Plan
{
    public int IdPlan { get; set; }

    public int IdAcademicYear { get; set; }

    public string Semestr { get; set; } = null!;

    public int NecessarilyWork { get; set; }

    public int IndependentWork { get; set; }

    public int IdGroup { get; set; }

    public int IdSubject { get; set; }

    public virtual AcademicYear IdAcademicYearNavigation { get; set; } = null!;

    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}
