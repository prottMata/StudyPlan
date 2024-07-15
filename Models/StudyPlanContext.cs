using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class StudyPlanContext : DbContext
    {
        public StudyPlanContext()
        {
        }

        public StudyPlanContext(DbContextOptions<StudyPlanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ControlForm> ControlForms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Discipline> Disciplines { get; set; }
        public virtual DbSet<DisciplinesCompetency> DisciplinesCompetencies { get; set; }
        public virtual DbSet<EducationForm> EducationForms { get; set; }
        public virtual DbSet<HighEducType> HighEducTypes { get; set; }
        public virtual DbSet<ListCathedra> ListCathedras { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<RefBookCompetency> RefBookCompetencies { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<TrainingDirection> TrainingDirections { get; set; }
        public virtual DbSet<TypeOfControl> TypeOfControls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=StudyPlan;Username=postgres;Password=postgre");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<ControlForm>(entity =>
            {
                entity.ToTable("control_form");

                entity.HasComment("Форма контроля");

                entity.HasIndex(e => e.IdDiscip, "control_form_un")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Credit)
                    .HasColumnName("credit")
                    .HasComment("Зачет");

                entity.Property(e => e.Exam)
                    .HasColumnName("exam")
                    .HasComment("Экзамен");

                entity.Property(e => e.IdDiscip).HasColumnName("id_discip");

                entity.Property(e => e.Kp)
                    .HasColumnName("kp")
                    .HasComment("КП");

                entity.Property(e => e.Kt)
                    .HasColumnName("kt")
                    .HasComment("КР");

                entity.Property(e => e.ScoreCredit)
                    .HasColumnName("score credit")
                    .HasComment("Зачет с оценкой");

                entity.HasOne(d => d.IdDiscipNavigation)
                    .WithOne(p => p.ControlForm)
                    .HasForeignKey<ControlForm>(d => d.IdDiscip)
                    .HasConstraintName("control_form_fk");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("course");

                entity.HasComment("Курс");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.ToTable("disciplines");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.IdCathedra).HasColumnName("id_cathedra");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdCathedraNavigation)
                    .WithMany(p => p.Disciplines)
                    .HasForeignKey(d => d.IdCathedra)
                    .HasConstraintName("disciplines_fk");
            });

            modelBuilder.Entity<DisciplinesCompetency>(entity =>
            {
                entity.ToTable("disciplines-competencies");

                entity.HasComment("Формируемые компетенции");

                entity.HasIndex(e => new { e.IdRef, e.IdDiscip }, "formation_competencies_id_ref_idx")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IdDiscip).HasColumnName("id_discip");

                entity.Property(e => e.IdRef).HasColumnName("id_ref");

                entity.HasOne(d => d.IdDiscipNavigation)
                    .WithMany(p => p.DisciplinesCompetencies)
                    .HasForeignKey(d => d.IdDiscip)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("disciplines_competencies_fk");

                entity.HasOne(d => d.IdRefNavigation)
                    .WithMany(p => p.DisciplinesCompetencies)
                    .HasForeignKey(d => d.IdRef)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("formation_competencies_fk");
            });

            modelBuilder.Entity<EducationForm>(entity =>
            {
                entity.HasKey(e => e.IdEf)
                    .HasName("education_forms_pk");

                entity.ToTable("education-forms");

                entity.HasComment("Формы обучения");

                entity.Property(e => e.IdEf)
                    .HasColumnName("Id-EF")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<HighEducType>(entity =>
            {
                entity.HasKey(e => e.IdHet)
                    .HasName("high_educ_types_pk");

                entity.ToTable("high-educ-types");

                entity.HasComment("Виды высшего образования");

                entity.Property(e => e.IdHet)
                    .HasColumnName("Id-HET")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ListCathedra>(entity =>
            {
                entity.ToTable("list-cathedra");

                entity.HasComment("Список кафедр");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.NameCathedra)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name_cathedra")
                    .HasComment("Наименование кафедры");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasComment("Номер");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("plan");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IdDiscip).HasColumnName("id_discip");

                entity.Property(e => e.IdSemestr).HasColumnName("id_semestr");

                entity.Property(e => e.IdTypeControl).HasColumnName("id_type-control");

                entity.HasOne(d => d.IdDiscipNavigation)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.IdDiscip)
                    .HasConstraintName("plan_discip");

                entity.HasOne(d => d.IdSemestrNavigation)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.IdSemestr)
                    .HasConstraintName("plan_sem");

                entity.HasOne(d => d.IdTypeControlNavigation)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.IdTypeControl)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("plan_type-cont");
            });

            modelBuilder.Entity<RefBookCompetency>(entity =>
            {
                entity.ToTable("ref-book-competencies");

                entity.HasComment("Справочник компетенций");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("code")
                    .HasComment("Индекс компетенции");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasComment("Содержание");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasComment("Верхний Id");

                entity.Property(e => e.TypeCode)
                    .HasMaxLength(10)
                    .HasColumnName("type_code")
                    .HasComment("Тип");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("semester");

                entity.HasComment("Семестр");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.IdCourse).HasColumnName("id_course");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Semesters)
                    .HasForeignKey(d => d.IdCourse)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("semester_fk");
            });

            modelBuilder.Entity<TrainingDirection>(entity =>
            {
                entity.HasKey(e => e.IdTd)
                    .HasName("training_direction_pk");

                entity.ToTable("training-direction");

                entity.HasComment("Направление обучения");

                entity.Property(e => e.IdTd)
                    .HasColumnName("Id-TD")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TypeOfControl>(entity =>
            {
                entity.HasKey(e => e.IdToc)
                    .HasName("type_of_control_pk");

                entity.ToTable("type-of-control");

                entity.Property(e => e.IdToc)
                    .HasColumnName("Id-TOC")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.AttC)
                    .HasColumnName("att-c")
                    .HasComment("АттК");

                entity.Property(e => e.Aud)
                    .HasColumnName("aud")
                    .HasComment("Ауд");

                entity.Property(e => e.Aver)
                    .HasColumnName("aver")
                    .HasComment("СР");

                entity.Property(e => e.Control)
                    .HasColumnName("control")
                    .HasComment("Контроль");

                entity.Property(e => e.CreditUnits)
                    .HasColumnName("credit-units")
                    .HasComment("з.е.");

                entity.Property(e => e.Lab)
                    .HasColumnName("lab")
                    .HasComment("Лаб");

                entity.Property(e => e.Lection)
                    .HasColumnName("lection")
                    .HasComment("Лек");

                entity.Property(e => e.Pract)
                    .HasColumnName("pract")
                    .HasComment("Пр");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasComment("Итого");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
