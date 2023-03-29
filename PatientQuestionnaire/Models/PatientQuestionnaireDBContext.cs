using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PatientQuestionnaire.Models
{
    public partial class PatientQuestionnaireDBContext : DbContext
    {
        public PatientQuestionnaireDBContext()
        {
        }

        public PatientQuestionnaireDBContext(DbContextOptions<PatientQuestionnaireDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrentPatient> CurrentPatients { get; set; } = null!;
        public virtual DbSet<DrugList> DrugLists { get; set; } = null!;
        public virtual DbSet<DrugQuestionnaire> DrugQuestionnaires { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrentPatient>(entity =>
            {
                entity.HasKey(e => e.PatientId)
                    .HasName("PK__CurrentP__C1A88B793F916135");

                entity.ToTable("CurrentPatient");

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.ActivePatient)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalAdmittedDate).HasColumnType("datetime");

                entity.Property(e => e.HospitalDischargeDate).HasColumnType("datetime");

                entity.Property(e => e.HospitalLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HospitalWard)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PateintBirthDate).HasColumnType("datetime");

                entity.Property(e => e.PatientFname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PatientFName");

                entity.Property(e => e.PatientLname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PatientLName");

                entity.Property(e => e.PatientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DrugList>(entity =>
            {
                entity.ToTable("DrugList");

                entity.HasIndex(e => e.FkQuestionnaireId, "UQ__DrugList__BDC3FAA4210E98A1")
                    .IsUnique();

                entity.Property(e => e.DrugListId)
                    .ValueGeneratedNever()
                    .HasColumnName("DrugList_Id");

                entity.Property(e => e.DrugName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FkQuestionnaireId).HasColumnName("FK_Questionnaire_Id");

                entity.HasOne(d => d.FkQuestionnaire)
                    .WithOne(p => p.DrugList)
                    .HasForeignKey<DrugList>(d => d.FkQuestionnaireId)
                    .HasConstraintName("FK__DrugList__FK_Que__4CA06362");
            });

            modelBuilder.Entity<DrugQuestionnaire>(entity =>
            {
                entity.HasKey(e => e.QuestionnaireId)
                    .HasName("PK__DrugQues__F74AAA0CEFDDE96C");

                entity.ToTable("DrugQuestionnaire");

                entity.Property(e => e.QuestionnaireId).HasColumnName("Questionnaire_Id");

                entity.Property(e => e.CompletedQuestionnaire)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.InsertedDate).HasColumnType("datetime");

                entity.Property(e => e.InterestedInTherapy)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsDrugUser)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsHappy)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsSuicidal)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.ParticipatedInQuestionnaire)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PatientNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
