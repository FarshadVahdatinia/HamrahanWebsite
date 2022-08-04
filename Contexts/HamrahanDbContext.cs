using Hamrahan.Models;
using Hamrahan.Models.course;
using HamrahanTemplate.persistence.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Contexts
{
    public partial class HamrahanDbContext : IdentityDbContext<Person,IdentityRole,string>
    {
        public HamrahanDbContext()
        {
        }

        public HamrahanDbContext(DbContextOptions<HamrahanDbContext> options) : base(options) { }


        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EducationGrade> EducationGrades { get; set; }
        public virtual DbSet<Expenditure> Expenditures { get; set; }
        public virtual DbSet<SalaryPayment> SalaryPayments { get; set; }
        public virtual DbSet<UserCourse> UserCourses { get; set; }
        public virtual DbSet<StudentPayment> StudentPayments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<CourseEpisode> CourseEpisodes{ get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-U3JLLJF\\MSQ2019;Initial Catalog=HamrahanDb ; integrated security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Persian_100_CI_AI");
            modelBuilder.Entity<Person>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            //modelBuilder.Entity<Post>().HasQueryFilter(e => e.IsDeleted == true);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.ProviderKey, p.LoginProvider });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            modelBuilder.ApplyConfiguration(new ClassConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new CourseEpisodeConfig());
            modelBuilder.ApplyConfiguration(new EducationGradeConfig());
            modelBuilder.ApplyConfiguration(new ExpenditureConfig());
            modelBuilder.ApplyConfiguration(new KeywordConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new SalaryPaymentConfig());
            modelBuilder.ApplyConfiguration(new StudentPaymentConfig());
            modelBuilder.ApplyConfiguration(new UserCourseConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new CoursePriceConfig());
            OnModelCreatingPartial(modelBuilder);
            #region DeletedDbsets
            //modelBuilder.Entity<CourseEpisode>(entity =>
            //{
            //    entity.ToTable("CourseEpisode", "Education");
            //    entity.HasOne(d => d.Course)
            //        .WithMany(p => p.CourseEpisodes)
            //        .HasForeignKey(d => d.CourseId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CourseEpisode_Course");

            //});

            //modelBuilder.Entity<Class>(entity =>
            //{
            //    entity.HasKey(e => e.Code)
            //        .HasName("PK_Class_Code");

            //    entity.ToTable("Class", "Education");

            //    entity.Property(e => e.Describtion).HasMaxLength(100);

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasMaxLength(20);
            //});

            //modelBuilder.Entity<Course>(entity =>
            //{
            //    entity.ToTable("Course", "Education");
            //    entity.HasQueryFilter(e => e.IsDeleted == true);

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.CoursePrice).HasColumnType("decimal(15, 2)");

            //    entity.Property(e => e.StartingDay).HasColumnType("date");

            //    entity.Property(e => e.TeacherID).HasColumnName("TeacherID");

            //    entity.Property(e => e.TimeInWeek)
            //        .IsRequired()
            //        .HasMaxLength(150);

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasMaxLength(60);

            //    entity.HasOne(d => d.ClassCodeNavigation)
            //        .WithMany(p => p.Courses)
            //        .HasForeignKey(d => d.ClassCode)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Course_ClassCode");

            //    entity.HasOne(d => d.CourseGroupCodeNavigation)
            //        .WithMany(p => p.Courses)
            //        .HasForeignKey(d => d.CourseGroupCode)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Course_CourseGroupCode");

            //    entity.HasOne(d => d.Teacher)
            //        .WithMany(p => p.Courses)
            //        .HasForeignKey(d => d.TeacherID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Course_TeacherId");
            //});

            //modelBuilder.Entity<EducationGrade>(entity =>
            //{
            //    entity.HasKey(e => e.Code)
            //        .HasName("PK_Education");

            //    entity.ToTable("EducationGrade", "Education");

            //    entity.Property(e => e.Code).ValueGeneratedOnAdd();

            //    entity.Property(e => e.Grade)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            //modelBuilder.Entity<Expenditure>(entity =>
            //{
            //    entity.ToTable("Expenditure", "Payment");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");

            //    entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            //});

            //modelBuilder.Entity<CourseGroup>(entity =>
            //{
            //    entity.HasKey(e => e.Code)
            //        .HasName("PK_CourseGroup");

            //    entity.ToTable("CourseGroup", "Education");

            //    entity.Property(e => e.Code).ValueGeneratedNever();

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.HasOne(d => d.EducationGradeCodeNavigation)
            //        .WithMany(p => p.CourseGroups)
            //        .HasForeignKey(d => d.EducationGradeCode)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_CourseGroup_EducationGradeCode");
            //});



            //modelBuilder.Entity<StudentPayment>(entity =>
            //{
            //    entity.ToTable("StudentPayment", "Payment");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.CourseID).HasColumnName("CourseID");

            //    entity.Property(e => e.PaidAmount).HasColumnType("decimal(15, 2)");

            //    entity.Property(e => e.RemainAmount).HasColumnType("decimal(15, 2)");

            //    entity.Property(e => e.StudentID).HasColumnName("StudentID");

            //    entity.HasOne(d => d.Course)
            //        .WithMany(p => p.StudentPayments)
            //        .HasForeignKey(d => d.CourseID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__StudentPa__Cours__5535A963");

            //    entity.HasOne(d => d.Student)
            //        .WithMany(p => p.StudentPayments)
            //        .HasForeignKey(d => d.StudentID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_StudentPayment_Student");
            //});


            //modelBuilder.Entity<SalaryPayment>(entity =>
            //{
            //    entity.ToTable("SalaryPayment", "Payment");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");

            //    entity.Property(e => e.PaidAmount).HasColumnType("decimal(15, 2)");

            //    entity.Property(e => e.RemainAmount).HasColumnType("decimal(15, 2)");

            //    entity.HasOne(d => d.Employee)
            //        .WithMany(p => p.SalaryPayments)
            //        .HasForeignKey(d => d.EmployeeID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_SalaryPayment_Employee");
            //});

            //modelBuilder.Entity<UserCourse>(entity =>
            //{
            //    entity.ToTable("User_course", "Education");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.CourseID).HasColumnName("CourseID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.Course)
            //        .WithMany(p => p.UserCourses)
            //        .HasForeignKey(d => d.CourseID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_UserCourse_Course");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.UserCourses)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK__Student_c__Stude__5070F446");
            //});

            //modelBuilder.Entity<PostKeyWord>(entity =>
            //{
            //    entity.ToTable("PostKeyword", "Weblog");

            //    entity.Property(e => e.ID).HasColumnName("ID");


            //    entity.Property(e => e.PostID).HasColumnName("PostID");

            //    entity.Property(e => e.KeywordID).HasColumnName("KeywordID");

            //    entity.HasOne(d => d.Post)
            //        .WithMany(p => p.PostKeyWords)
            //        .HasForeignKey(d => d.PostID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Post_Keyword_PostID");

            //    entity.HasOne(d => d.Keyword)
            //        .WithMany(p => p.PostKeyWords)
            //        .HasForeignKey(d => d.KeywordID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Post_Keyword_KeywordID");
            //});
            //modelBuilder.Entity<Post>(entity =>
            //{
            //    entity.ToTable("Post", "Weblog");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.ImagesLink).HasColumnName("ImagesLink");
            //    entity.Property(e => e.Topic)
            //        .IsRequired()
            //        .HasMaxLength(150).IsUnicode(true);
            //    entity.Property(e => e.Content).IsRequired().IsUnicode(true);
            //    entity.Property(a => a.Published).HasComputedColumnSql("(getdate())", false);
            //    entity.Property(a => a.Updated).HasColumnName("Updated");
            //    entity.Property(a => a.PersonID).HasColumnName("PersonID");

            //    entity.HasOne(d => d.Person)
            //        .WithMany(p => p.PersonPosts)
            //        .HasForeignKey(d => d.PersonID)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Person_Post");
            //    entity.Property(s => s.Summary).HasColumnName("Summary");
            //    entity.Property(i => i.IsDeleted).HasColumnName("IsDeleted").HasDefaultValue(false);


            //});

            //modelBuilder.Entity<Keyword>(entity =>
            //{
            //    entity.ToTable("Keyword", "Weblog");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasMaxLength(100).IsUnicode(true);


            //});
  

          
            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.Property(e => e.TelePhone).HasColumnName("TelePhone");
            //    entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
            //    entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[Birthdate],getdate()))", false);
            //    entity.Property(e => e.FullName)
            //        .IsRequired()
            //        .HasMaxLength(101)
            //        .HasComputedColumnSql("(([FirstName]+'')+[Lastname])", false);
            //    entity.Property(a => a.RegisterDate).HasComputedColumnSql("(getdate())", false);
            //}
            //    );
          
            #endregion

            #region DeletedPersonAndRole



            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.ToTable("Person", "Person");

            //    entity.Property(e => e.ID).HasColumnName("ID");

            //    entity.Property(e => e.Age).HasComputedColumnSql("(datediff(year,[Birthdate],getdate()))", false);

            //    entity.Property(e => e.Birthdate).HasColumnType("date");

            //    entity.Property(e => e.FirstName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.FullName)
            //        .IsRequired()
            //        .HasMaxLength(101)
            //        .HasComputedColumnSql("(([FirstName]+'')+[Lastname])", false);

            //    entity.Property(e => e.Lastname)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Mobile)
            //        .IsRequired()
            //        .HasMaxLength(11)
            //        .IsUnicode(false)
            //        .IsFixedLength(true);

            //    entity.Property(e => e.NationalCode)
            //        .IsRequired()
            //        .HasMaxLength(10)
            //        .IsUnicode(false)
            //        .IsFixedLength(true);



            //    entity.HasOne(d => d.EducationGradecodeNavigation)
            //        .WithMany(p => p.People)
            //        .HasForeignKey(d => d.EducationGradecode)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Person_EducationGrade");


            //});

            //modelBuilder.Entity<Role>(entity =>
            //{
            //    entity.HasKey(e => e.Code)
            //        .HasName("PK__Role__A25C5AA6577DBDEF");

            //    entity.ToTable("Role", "Person");

            //    entity.Property(e => e.Title)
            //        .IsRequired()
            //        .HasMaxLength(70);
            //});
            #endregion





        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}

