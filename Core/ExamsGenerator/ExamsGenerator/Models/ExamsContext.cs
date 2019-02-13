using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ExamsGenerator.Models
{
    public partial class ExamsContext : DbContext
    {
        public ExamsContext(DbContextOptions<ExamsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<AnswerToQuestion> AnswerToQuestion { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<DegreeOfDifficulty> DegreeOfDifficulty { get; set; }
        public virtual DbSet<DegreeOfDifficultyToLevel> DegreeOfDifficultyToLevel { get; set; }
        public virtual DbSet<DegreeOfDifficultyToLevelOfEducation> DegreeOfDifficultyToLevelOfEducation { get; set; }
        public virtual DbSet<EducationSystem> EducationSystem { get; set; }
        public virtual DbSet<ExamCandidateHeader> ExamCandidateHeader { get; set; }
        public virtual DbSet<ExamCandidateLine> ExamCandidateLine { get; set; }
        public virtual DbSet<ExamCompositionLine> ExamCompositionLine { get; set; }
        public virtual DbSet<ExamDeliveryHeader> ExamDeliveryHeader { get; set; }
        public virtual DbSet<ExamDeliveryLine> ExamDeliveryLine { get; set; }
        public virtual DbSet<ExamOrder> ExamOrder { get; set; }
        public virtual DbSet<ExamOrderItem> ExamOrderItem { get; set; }
        public virtual DbSet<ExamOrderShuffleHeader> ExamOrderShuffleHeader { get; set; }
        public virtual DbSet<ExamOrderShuffleLine> ExamOrderShuffleLine { get; set; }
        public virtual DbSet<ExamOrderStatus> ExamOrderStatus { get; set; }
        public virtual DbSet<ExamOrderStatusLog> ExamOrderStatusLog { get; set; }
        public virtual DbSet<ExamStatus> ExamStatus { get; set; }
        public virtual DbSet<Institute> Institute { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<LevelOfEducationInternational> LevelOfEducationInternational { get; set; }
        public virtual DbSet<LevelOfEducationLocal> LevelOfEducationLocal { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionToSubject> QuestionToSubject { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // TODO: move this to appsetings.json
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=Exams;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Text).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<AnswerToQuestion>(entity =>
            {
                entity.Property(e => e.AnswerToQuestionId).HasColumnName("AnswerToQuestionID");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.AnswerToQuestion)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerToQuestion_Answer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AnswerToQuestion)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnswerToQuestion_Question");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.LevelOfEducationInternationalId).HasColumnName("LevelOfEducationInternationalID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.InstituteId)
                    .HasConstraintName("FK_Class_Institute");

                entity.HasOne(d => d.LevelOfEducationInternational)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.LevelOfEducationInternationalId)
                    .HasConstraintName("FK_Class_LevelOfEducationInternational");
            });

            modelBuilder.Entity<DegreeOfDifficulty>(entity =>
            {
                entity.Property(e => e.DegreeOfDifficultyId)
                    .HasColumnName("DegreeOfDifficultyID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<DegreeOfDifficultyToLevel>(entity =>
            {
                entity.HasKey(e => e.DegreeOfDifficultyToLevelOfEductionId);

                entity.Property(e => e.DegreeOfDifficultyToLevelOfEductionId).HasColumnName("DegreeOfDifficultyToLevelOfEductionID");

                entity.Property(e => e.DegreeIdfrom).HasColumnName("DegreeIDFrom");

                entity.Property(e => e.DegreeIdto).HasColumnName("DegreeIDTo");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");
            });

            modelBuilder.Entity<DegreeOfDifficultyToLevelOfEducation>(entity =>
            {
                entity.HasKey(e => e.DegreeOfDifficultyToLevelOfEduction);

                entity.Property(e => e.DegreeIdfrom).HasColumnName("DegreeIDFrom");

                entity.Property(e => e.DegreeIdto).HasColumnName("DegreeIDTo");

                entity.Property(e => e.LevelOfEductionId).HasColumnName("LevelOfEductionID");

                entity.HasOne(d => d.DegreeIdfromNavigation)
                    .WithMany(p => p.DegreeOfDifficultyToLevelOfEducationDegreeIdfromNavigation)
                    .HasForeignKey(d => d.DegreeIdfrom)
                    .HasConstraintName("FK_DegreeOfDifficultyToLevelOfEducation_DegreeOfDifficulty");

                entity.HasOne(d => d.DegreeIdtoNavigation)
                    .WithMany(p => p.DegreeOfDifficultyToLevelOfEducationDegreeIdtoNavigation)
                    .HasForeignKey(d => d.DegreeIdto)
                    .HasConstraintName("FK_DegreeOfDifficultyToLevelOfEducation_DegreeOfDifficulty1");

                entity.HasOne(d => d.LevelOfEduction)
                    .WithMany(p => p.DegreeOfDifficultyToLevelOfEducation)
                    .HasForeignKey(d => d.LevelOfEductionId)
                    .HasConstraintName("FK_DegreeOfDifficultyToLevelOfEducation_LevelOfEducation");
            });

            modelBuilder.Entity<EducationSystem>(entity =>
            {
                entity.Property(e => e.EducationSystemId)
                    .HasColumnName("EducationSystemID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<ExamCandidateHeader>(entity =>
            {
                entity.HasIndex(e => new { e.ExamOrderId, e.UserId })
                    .HasName("NonClusteredIndex-20190106-164406")
                    .IsUnique();

                entity.Property(e => e.ExamCandidateHeaderId).HasColumnName("ExamCandidateHeaderID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.EvaluationDate).HasColumnType("date");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.SubmitDate).HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamCandidateHeader)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamCandidateHeader_ExamOrder");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamCandidateHeader)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExamCandidateHeader_Candidate");
            });

            modelBuilder.Entity<ExamCandidateLine>(entity =>
            {
                entity.HasKey(e => e.ExamCanditateLineId);

                entity.Property(e => e.ExamCanditateLineId).HasColumnName("ExamCanditateLineID");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamCandidateLine)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamCandidateLine_ExamOrder");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.ExamCandidateLine)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_ExamCandidateLine_Question");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamCandidateLine)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ExamCandidateLine_User");
            });

            modelBuilder.Entity<ExamCompositionLine>(entity =>
            {
                entity.Property(e => e.ExamCompositionLineId)
                    .HasColumnName("ExamCompositionLineID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Answer).HasMaxLength(1000);

                entity.Property(e => e.AnswerToQuestionId).HasColumnName("AnswerToQuestionID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.Question).HasMaxLength(1000);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.SortVersionId).HasColumnName("SortVersionID");
            });

            modelBuilder.Entity<ExamDeliveryHeader>(entity =>
            {
                entity.HasIndex(e => e.ExamOrderId)
                    .HasName("NonClusteredIndex-20190107-104550");

                entity.Property(e => e.ExamDeliveryHeaderId).HasColumnName("ExamDeliveryHeaderID");

                entity.Property(e => e.DegreeOfDifficultyId).HasColumnName("DegreeOfDifficultyID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");
            });

            modelBuilder.Entity<ExamDeliveryLine>(entity =>
            {
                entity.Property(e => e.ExamDeliveryLineId).HasColumnName("ExamDeliveryLineID");

                entity.Property(e => e.Answer).HasMaxLength(1000);

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.DegreeOfDifficultyId).HasColumnName("DegreeOfDifficultyID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.Question).HasMaxLength(1000);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.HasOne(d => d.AnswerNavigation)
                    .WithMany(p => p.ExamDeliveryLine)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_ExamDeliveryLine_Answer");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamDeliveryLine)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamDeliveryLine_ExamOrder");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.ExamDeliveryLine)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_ExamDeliveryLine_Question");
            });

            modelBuilder.Entity<ExamOrder>(entity =>
            {
                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.DegreeOfDifficultyId).HasColumnName("DegreeOfDifficultyID");

                entity.Property(e => e.Disclaimer).HasMaxLength(255);

                entity.Property(e => e.Instruction).HasMaxLength(255);

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.SubTitle).HasMaxLength(255);

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ExamOrder)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_ExamOrder_Class");

                entity.HasOne(d => d.DegreeOfDifficulty)
                    .WithMany(p => p.ExamOrder)
                    .HasForeignKey(d => d.DegreeOfDifficultyId)
                    .HasConstraintName("FK_ExamOrder_DegreeOfDifficulty");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ExamOrder)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_ExamOrder_Language");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ExamOrder)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_ExamOrder_Subject");
            });

            modelBuilder.Entity<ExamOrderItem>(entity =>
            {
                entity.Property(e => e.ExamOrderItemId).HasColumnName("ExamOrderItemID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamOrderItem)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamCompositionItem_ExamOrder");

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.ExamOrderItem)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_ExamCompositionItem_QuestionType");
            });

            modelBuilder.Entity<ExamOrderShuffleHeader>(entity =>
            {
                entity.HasIndex(e => new { e.ExamOrderId, e.ExamOrderShuffleId })
                    .HasName("NonClusteredIndex-20190107-104454")
                    .IsUnique();

                entity.Property(e => e.ExamOrderShuffleHeaderId).HasColumnName("ExamOrderShuffleHeaderID");

                entity.Property(e => e.DegreeOfDifficultyId).HasColumnName("DegreeOfDifficultyID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.ExamOrderShuffleId).HasColumnName("ExamOrderShuffleID");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamOrderShuffleHeader)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamOrderShuffleHeader_ExamOrder");
            });

            modelBuilder.Entity<ExamOrderShuffleLine>(entity =>
            {
                entity.Property(e => e.ExamOrderShuffleLineId).HasColumnName("ExamOrderShuffleLineID");

                entity.Property(e => e.Answer).HasMaxLength(1000);

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.DegreeOfDifficultyId).HasColumnName("DegreeOfDifficultyID");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.ExamOrderShuffleId).HasColumnName("ExamOrderShuffleID");

                entity.Property(e => e.Question).HasMaxLength(1000);

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.HasOne(d => d.AnswerNavigation)
                    .WithMany(p => p.ExamOrderShuffleLine)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_ExamOrderShuffleLine_Answer");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamOrderShuffleLine)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamOrderShuffleLine_ExamOrder");

                entity.HasOne(d => d.QuestionNavigation)
                    .WithMany(p => p.ExamOrderShuffleLine)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_ExamOrderShuffleLine_Question");
            });

            modelBuilder.Entity<ExamOrderStatus>(entity =>
            {
                entity.Property(e => e.ExamOrderStatusId)
                    .HasColumnName("ExamOrderStatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ExamOrderStatusLog>(entity =>
            {
                entity.Property(e => e.ExamOrderStatusLogId).HasColumnName("ExamOrderStatusLogID");

                entity.Property(e => e.Date).HasColumnType("nchar(10)");

                entity.Property(e => e.ExamOrderId).HasColumnName("ExamOrderID");

                entity.Property(e => e.ExamOrderStatusId).HasColumnName("ExamOrderStatusID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.ExamOrder)
                    .WithMany(p => p.ExamOrderStatusLog)
                    .HasForeignKey(d => d.ExamOrderId)
                    .HasConstraintName("FK_ExamOrderStatusLog_ExamOrder");

                entity.HasOne(d => d.ExamOrderStatus)
                    .WithMany(p => p.ExamOrderStatusLog)
                    .HasForeignKey(d => d.ExamOrderStatusId)
                    .HasConstraintName("FK_ExamOrderStatusLog_ExamOrderStatus");
            });

            modelBuilder.Entity<ExamStatus>(entity =>
            {
                entity.Property(e => e.ExamStatusId)
                    .HasColumnName("ExamStatusID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .HasColumnType("nchar(2)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Language1)
                    .HasColumnName("Language")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LevelOfEducationInternational>(entity =>
            {
                entity.Property(e => e.LevelOfEducationInternationalId)
                    .HasColumnName("LevelOfEducationInternationalID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Iscedcode)
                    .HasColumnName("ISCEDCode")
                    .HasMaxLength(10);

                entity.Property(e => e.ShortDescription).HasMaxLength(255);
            });

            modelBuilder.Entity<LevelOfEducationLocal>(entity =>
            {
                entity.HasKey(e => e.LevelOfEductionLocal);

                entity.Property(e => e.LevelOfEductionLocal).ValueGeneratedNever();

                entity.Property(e => e.Code).HasColumnType("nchar(10)");

                entity.Property(e => e.ShortDescription).HasMaxLength(255);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.DegreeOfDifficultyId).HasColumnName("DegreeOfDifficultyID");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("LanguageID")
                    .HasColumnType("nchar(2)");

                entity.Property(e => e.LevelOfEducationInternationalId).HasColumnName("LevelOfEducationInternationalID");

                entity.Property(e => e.QuestionTypeId).HasColumnName("QuestionTypeID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Text).HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.DegreeOfDifficulty)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.DegreeOfDifficultyId)
                    .HasConstraintName("FK_Question_DegreeOfDifficulty");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_Question_Language");

                entity.HasOne(d => d.LevelOfEducationInternational)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.LevelOfEducationInternationalId)
                    .HasConstraintName("FK_Question_LevelOfEducationInternational");

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .HasConstraintName("FK_Question_QuestionType");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Question_Subject");
            });

            modelBuilder.Entity<QuestionToSubject>(entity =>
            {
                entity.Property(e => e.QuestionToSubjectId).HasColumnName("QuestionToSubjectID");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.QuestionToSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_QuestionToSubject_Subject");
            });

            modelBuilder.Entity<QuestionType>(entity =>
            {
                entity.Property(e => e.QuestionTypeId)
                    .HasColumnName("QuestionTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .HasColumnName("RoleID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");
            });
        }
    }
}
