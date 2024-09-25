using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HoursTracking.Model;

public partial class HoursTrackingContext : DbContext
{
    public HoursTrackingContext()
    {
    }

    public HoursTrackingContext(DbContextOptions<HoursTrackingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademicYear> AcademicYears { get; set; }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Plan> Plans { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Statement> Statements { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=HomePC\\SQLEXPRESS;Initial Catalog=HoursTracking;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcademicYear>(entity =>
        {
            entity.HasKey(e => e.IdAcademicYear);

            entity.ToTable("AcademicYear");

            entity.Property(e => e.Automn).HasColumnName("automn");
            entity.Property(e => e.NameYear).HasMaxLength(50);
            entity.Property(e => e.Winter).HasColumnName("winter");
        });

        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.IdCertification);

            entity.ToTable("Certification");

            entity.Property(e => e.IdGroup).HasColumnName("idGroup");
            entity.Property(e => e.IdSubject).HasColumnName("idSubject");
            entity.Property(e => e.IdTeacher).HasColumnName("idTeacher");
            entity.Property(e => e.TypeCertification).HasMaxLength(50);

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certification_Group");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certification_Subject");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certification_Teacher");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("Group");

            entity.Property(e => e.NameGroup).HasMaxLength(50);

            entity.HasOne(d => d.IdSpecialityNavigation).WithMany(p => p.Groups)
                .HasForeignKey(d => d.IdSpeciality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Group_Speciality");
            entity.HasAlternateKey(u => new { u.NameGroup });
        });

        modelBuilder.Entity<Plan>(entity =>
        {
            entity.HasKey(e => e.IdPlan);

            entity.ToTable("Plan");

            entity.Property(e => e.Semestr).HasMaxLength(5);

            entity.HasOne(d => d.IdAcademicYearNavigation).WithMany(p => p.Plans)
                .HasForeignKey(d => d.IdAcademicYear)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plan_AcademicYear");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Plans)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plan_Group");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Plans)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plan_Subject");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.Plans)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Plan_Teacher_IdTeacher");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.IdSpeciality);

            entity.ToTable("Speciality");

            entity.Property(e => e.NameSpeciality).HasMaxLength(50);
        });

        modelBuilder.Entity<Statement>(entity =>
        {
            entity.HasKey(e => e.IdStatement);

            entity.ToTable("Statement");

            entity.HasOne(d => d.IdAcademicYearNavigation).WithMany(p => p.Statements)
                .HasForeignKey(d => d.IdAcademicYear)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Statement_AcademicYear");

            entity.HasOne(d => d.IdAcademicYear1).WithMany(p => p.Statements)
                .HasForeignKey(d => d.IdAcademicYear)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Statement_Group");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Statements)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Statement_Subject");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.Statements)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Statement_Teacher");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.IdSubject);

            entity.ToTable("Subject");

            entity.Property(e => e.IdSubject).HasColumnName("idSubject");
            entity.Property(e => e.NameSubject).HasMaxLength(50);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher);

            entity.ToTable("Teacher");

            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
