using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Certification:BaseViewModel
{
    public int IdCertification { get; set; }

    private int idSubject { get; set; }
    public int IdSubject
    {
        get { return idSubject; }
        set
        {
            idSubject = value;
            OnPropertyChanged(nameof(IdSubject));
        }
    }

    private int idTeacher { get; set; }
    public int IdTeacher
    {
        get { return idTeacher; }
        set
        {
            idTeacher = value;
            OnPropertyChanged(nameof(IdTeacher));
        }
    }
    private int idGroup { get; set; }
    public int IdGroup
    {
        get { return idGroup; }
        set
        {
            idGroup = value;
            OnPropertyChanged(nameof(IdGroup));
        }
    }

    private DateOnly dateCertification;
    public DateOnly DateCertification
    {
        get { return dateCertification; }
        set
        {
            dateCertification = value;
            OnPropertyChanged(nameof(DateCertification));
        }
    }

    private int hours;
    public int Hours
    {
        get { return hours; }
        set
        {
            hours = value;
            OnPropertyChanged(nameof(Hours));
        }
    }
    private string? typeCertification;
    public string? TypeCertification
    {
        get { return typeCertification; }
        set
        {
            typeCertification = value;
            OnPropertyChanged(nameof(TypeCertification));
        }
    }
    public virtual Group IdGroupNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
