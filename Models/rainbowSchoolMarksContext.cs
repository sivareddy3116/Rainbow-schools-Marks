using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RainbowSchoolsApi.Models
{
    public partial class rainbowSchoolMarksContext : DbContext
    {
        public rainbowSchoolMarksContext()
        {
        }

        public rainbowSchoolMarksContext(DbContextOptions<rainbowSchoolMarksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mark> Marks { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-EBTO5CT;database=rainbowSchoolMarks;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("marks");

                entity.Property(e => e.MarkId)
                    .ValueGeneratedNever()
                    .HasColumnName("mark_id");

                entity.Property(e => e.MarksObtained)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("marks_obtained");

                entity.Property(e => e.StudentId).HasColumnName("student_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TeacherId).HasColumnName("teacher_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__marks__student_i__3D5E1FD2");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__marks__subject_i__3E52440B");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Marks)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__marks__teacher_i__3F466844");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("student_id");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("student_name");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subjects");

                entity.Property(e => e.SubjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("subject_id");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("subject_name");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId)
                    .ValueGeneratedNever()
                    .HasColumnName("Teacher_id");

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Teacher_name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
