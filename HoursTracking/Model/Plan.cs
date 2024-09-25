using System;
using System.Collections.Generic;

namespace HoursTracking.Model;

public partial class Plan:BaseViewModel
{
    public int IdPlan { get; set; }
    private int idAcademicYear;
    public int IdAcademicYear 
    {
        get { return idAcademicYear; }
        set
        {
            idAcademicYear = value;
            OnPropertyChanged(nameof(IdAcademicYear));
        }
    }
    private string? semestr;
    public string? Semestr 
    {
        get { return semestr; }
        set
        {
            semestr = value;
            OnPropertyChanged(nameof(Semestr));
        }
    }
    private int necessarilyWork;
    public int NecessarilyWork 
    {
        get { return necessarilyWork; }
        set
        {
            necessarilyWork = value;
            OnPropertyChanged(nameof(NecessarilyWork));
        }
    }
    private int independentWork;
    public int IndependentWork 
    {
        get { return independentWork; }
        set
        {
            independentWork = value;
            OnPropertyChanged(nameof(IndependentWork));
        }
    }
    private int idGroup;
    public int IdGroup
    {
        get { return idGroup; }
        set
        {
            idGroup = value;
            OnPropertyChanged(nameof(IdGroup));
        }
    }
    private int idSubject;
    public int IdSubject
    {
        get { return idSubject; }
        set
        {
            idSubject = value;
            OnPropertyChanged(nameof(IdSubject));
        }
    }
    private int idTeacher;
    public int IdTeacher
    {
        get { return idTeacher; }
        set
        {
            idTeacher = value;
            OnPropertyChanged(nameof(IdTeacher));
        }
    }
    public virtual AcademicYear IdAcademicYearNavigation { get; set; } = null!;
    public virtual Group IdGroupNavigation { get; set; } = null!;
    public virtual Subject IdSubjectNavigation { get; set; } = null!;
    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
