using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebTestApi.Models;

public partial class TestDbContext : DbContext
{
    public TestDbContext()
    {
    }

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AnswerVariant> AnswerVariants { get; set; } = null!;

    public virtual DbSet<Question> Questions { get; set; } = null!;

    public virtual DbSet<QuestionType> QuestionTypes { get; set; } = null!;

    public virtual DbSet<Student> Students { get; set; } = null!;

    public virtual DbSet<StudentsTest> StudentsTests { get; set; } = null!;

    public virtual DbSet<Subject> Subjects { get; set; } = null!;

    public virtual DbSet<Teacher> Teachers { get; set; } = null!;

    public virtual DbSet<Test> Tests { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MYDESKTOP-ANATO\\MSSQL_ANATOLY;Database=TestDB;Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnswerVariant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnswerVa__3213E83F2109F2EF");

            entity.ToTable("AnswerVariant");

            entity.Property(e => e.Id)
                .HasColumnOrder(0)
                .HasColumnName("id");
            entity.Property(e => e.IdQuestion)
                .HasColumnOrder(1)
                .HasColumnName("idQuestion");
            entity.Property(e => e.IsCorrect)
                .HasColumnOrder(3)
                .HasColumnName("isCorrect");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .HasColumnName("name");

            entity.HasOne(d => d.IdQuestionNavigation).WithMany(p => p.AnswerVariants)
                .HasForeignKey(d => d.IdQuestion)
                .HasConstraintName("FK__AnswerVar__idQue__282DF8C2");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC074417AA55");

            entity.ToTable("Question");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasColumnOrder(3)
                .HasColumnName("picture");
            entity.Property(e => e.QuestionTypeId).HasColumnOrder(4);
            entity.Property(e => e.TestId)
                .HasColumnOrder(1)
                .HasColumnName("TestID");
            entity.Property(e => e.Value)
                .HasColumnOrder(5)
                .HasColumnName("value");

            //entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
            //    .HasForeignKey(d => d.QuestionTypeId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Question__Questi__25518C17");

            //entity.HasOne(d => d.Test).WithMany(p => p.Questions)
            //    .HasForeignKey(d => d.TestId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasConstraintName("FK__Question__TestID__245D67DE");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07A014A365");

            entity.ToTable("QuestionType");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnOrder(1)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC076D04587B");

            entity.ToTable("Student");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.StudentLogin)
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .HasColumnName("studentLogin");
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .HasColumnOrder(1)
                .HasColumnName("studentName");
            entity.Property(e => e.StudentPassword)
                .HasColumnOrder(3)
                .HasColumnName("studentPassword");
        });

        modelBuilder.Entity<StudentsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0762FC2779");

            entity.ToTable("StudentsTest");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.AttemtsLeft)
                .HasColumnOrder(4)
                .HasDefaultValueSql("((3))")
                .HasColumnName("attemtsLeft");
            entity.Property(e => e.Result)
                .HasColumnOrder(3)
                .HasDefaultValueSql("((0))")
                .HasColumnName("result");
            entity.Property(e => e.StudentId).HasColumnOrder(2);
            entity.Property(e => e.TestId)
                .HasColumnOrder(1)
                .HasColumnName("TestID");
            entity.Property(e => e.Time)
                .HasColumnOrder(5)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("time");

            //entity.HasOne(d => d.Student).WithMany(p => p.StudentsTests)
            //    .HasForeignKey(d => d.StudentId)
            //    .HasConstraintName("FK__StudentsT__Stude__32AB8735");

            //entity.HasOne(d => d.Test).WithMany(p => p.StudentsTests)
            //    .HasForeignKey(d => d.TestId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasConstraintName("FK__StudentsT__TestI__31B762FC");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subject__3214EC07FFF409DF");

            entity.ToTable("Subject");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnOrder(1)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC07153649DD");

            entity.ToTable("Teacher");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.TeacherLogin)
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .HasColumnName("teacherLogin");
            entity.Property(e => e.TeacherName)
                .HasMaxLength(50)
                .HasColumnOrder(1)
                .HasColumnName("teacherName");
            entity.Property(e => e.TeacherPassword)
                .HasColumnOrder(3)
                .HasColumnName("teacherPassword");
            //entity.Property(e => e.TeacherPasswordStr)
            //   .HasColumnOrder(3)
            //   .HasColumnName("teacherPasswordStr");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Test__3214EC07C2EF340F");

            entity.ToTable("Test");

            entity.Property(e => e.Id).HasColumnOrder(0);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnOrder(3)
                .HasColumnName("name");
            entity.Property(e => e.SubjectId).HasColumnOrder(2);
            entity.Property(e => e.TeacherId)
                .HasColumnOrder(1)
                .HasColumnName("TeacherID");

            //entity.HasOne(d => d.Subject).WithMany(p => p.Tests)
            //    .HasForeignKey(d => d.SubjectId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__Test__SubjectId__17F790F9");

           /* entity.HasOne(d => d.Teacher).WithMany(p => p.Tests)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Test__TeacherID__17036CC0");*/
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
