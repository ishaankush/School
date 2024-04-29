using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace School.Models;

public partial class StudentsContext : DbContext
{
    public StudentsContext()
    {
    }

    public StudentsContext(DbContextOptions<StudentsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<GaurdianPhone> GaurdianPhones { get; set; }

    public virtual DbSet<GaurdianType> GaurdianTypes { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<NoticeBoard> NoticeBoards { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<PhoneType> PhoneTypes { get; set; }

    public virtual DbSet<Rolemaster> Rolemasters { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAudit> StudentAudits { get; set; }

    public virtual DbSet<StudentAuditView> StudentAuditViews { get; set; }

    public virtual DbSet<StudentGuardian> StudentGuardians { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ABHISHEK;Database=Students;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK_Student.Addres");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("ADDRESS_ID");
            entity.Property(e => e.AddressLine1)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE_1");
            entity.Property(e => e.AddressLine2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ADDRESS_LINE_2");
            entity.Property(e => e.AddressTypeId).HasColumnName("ADDRESS_TYPE_ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CITY");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
            entity.Property(e => e.Zip)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ZIP");

            entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AddressTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_AddressType");

            entity.HasOne(d => d.Student).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Address_Student");
        });

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.HasKey(e => e.AddressTypeId).HasName("PK_Student.Address");

            entity.ToTable("AddressType");

            entity.Property(e => e.AddressTypeId).HasColumnName("ADDRESS_TYPE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("CITY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_StudentCourse");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("COURSE_ID");
            entity.Property(e => e.Cource)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COURCE");
            entity.Property(e => e.CourceFee).HasColumnName("COURCE_FEE");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK_Student.Email");

            entity.ToTable("Email");

            entity.Property(e => e.EmailId).HasColumnName("EMAIL_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.Email1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.Emails)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Email_Student");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeesId);

            entity.ToTable("Fee");

            entity.Property(e => e.FeesId).HasColumnName("Fees_Id");
            entity.Property(e => e.ModifiedBy)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");

            entity.HasOne(d => d.Student).WithMany(p => p.Fees)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Fee_Student");
        });

        modelBuilder.Entity<GaurdianPhone>(entity =>
        {
            entity.HasKey(e => e.GuardianPhoneId).HasName("PK_Student.Gaurdian.phone");

            entity.ToTable("GaurdianPhone");

            entity.Property(e => e.GuardianPhoneId).HasColumnName("GUARDIAN_PHONE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.GuardianId).HasColumnName("GUARDIAN_ID");
            entity.Property(e => e.GuardianPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("GUARDIAN_PHONE");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");

            entity.HasOne(d => d.Guardian).WithMany(p => p.GaurdianPhones)
                .HasForeignKey(d => d.GuardianId)
                .HasConstraintName("FK_GaurdianPhone_StudentGuardian");
        });

        modelBuilder.Entity<GaurdianType>(entity =>
        {
            entity.HasKey(e => e.GuardianTypeId).HasName("PK_GUARDIAN_TYPE");

            entity.ToTable("GaurdianType");

            entity.Property(e => e.GuardianTypeId).HasColumnName("GUARDIAN_TYPE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.GuardianType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GUARDIAN_TYPE");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.BookId);

            entity.ToTable("Library");

            entity.Property(e => e.AuthorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Author_Name");
            entity.Property(e => e.BookName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.StudentId).HasColumnName("Student_Id");
        });

        modelBuilder.Entity<NoticeBoard>(entity =>
        {
            entity.ToTable("NoticeBoard");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.NoticeBody)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NOTICE_BODY");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.PhoneId).HasName("PK_STUDENT.PHONE");

            entity.ToTable("Phone");

            entity.Property(e => e.PhoneId).HasColumnName("PHONE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PHONE_NUMBER");
            entity.Property(e => e.PhoneTypeId).HasColumnName("PHONE_TYPE_ID");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

            entity.HasOne(d => d.PhoneType).WithMany(p => p.Phones)
                .HasForeignKey(d => d.PhoneTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Phone_PhoneType1");

            entity.HasOne(d => d.Student).WithMany(p => p.Phones)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Phone_Student");
        });

        modelBuilder.Entity<PhoneType>(entity =>
        {
            entity.HasKey(e => e.PhoneTypeId).HasName("PK_Student.PhoneType");

            entity.ToTable("PhoneType");

            entity.Property(e => e.PhoneTypeId).HasColumnName("PHONE_TYPE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Rolemaster>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("Rolemaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.Property(e => e.StaffId).HasColumnName("STAFF_ID");
            entity.Property(e => e.CityId).HasColumnName("CITY_ID");
            entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PHONE");
            entity.Property(e => e.StaffType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STAFF_TYPE");
            entity.Property(e => e.StateId).HasColumnName("STATE_ID");

            entity.HasOne(d => d.City).WithMany(p => p.Staff)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Staff_City");

            entity.HasOne(d => d.Country).WithMany(p => p.Staff)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Staff_Country");

            entity.HasOne(d => d.State).WithMany(p => p.Staff)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Staff_State");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State");

            entity.Property(e => e.StateId).HasColumnName("STATE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__STUDENT__3214EC27E44F38F8");

            entity.ToTable("Student", tb => tb.HasTrigger("StudentAuditTrigger"));

            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("datetime")
                .HasColumnName("ADMISSION_DATE");
            entity.Property(e => e.CityId).HasColumnName("CITY_ID");
            entity.Property(e => e.Class)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CLASS");
            entity.Property(e => e.CountryId).HasColumnName("COUNTRY_ID");
            entity.Property(e => e.CourceId).HasColumnName("COURCE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.Dob)
                .HasColumnType("datetime")
                .HasColumnName("DOB");
            entity.Property(e => e.FeePayment).HasColumnName("FEE_PAYMENT");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.StateId).HasColumnName("STATE_ID");

            entity.HasOne(d => d.City).WithMany(p => p.Students)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Student_City");

            entity.HasOne(d => d.Country).WithMany(p => p.Students)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Student_Country");

            entity.HasOne(d => d.Cource).WithMany(p => p.Students)
                .HasForeignKey(d => d.CourceId)
                .HasConstraintName("FK_Student_Course");

            entity.HasOne(d => d.State).WithMany(p => p.Students)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Student_State");
        });

        modelBuilder.Entity<StudentAudit>(entity =>
        {
            entity.HasKey(e => e.AuditId).HasName("PK__StudentA__A17F23B8E1BCF4A4");

            entity.ToTable("StudentAudit");

            entity.Property(e => e.AuditId).HasColumnName("AuditID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NewCityId).HasColumnName("NewCityID");
            entity.Property(e => e.NewClass)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NewCountryId).HasColumnName("NewCountryID");
            entity.Property(e => e.NewDob)
                .HasColumnType("datetime")
                .HasColumnName("NewDOB");
            entity.Property(e => e.NewName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewStateId).HasColumnName("NewStateID");
            entity.Property(e => e.OldCityId).HasColumnName("OldCityID");
            entity.Property(e => e.OldClass)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OldCountryId).HasColumnName("OldCountryID");
            entity.Property(e => e.OldDob)
                .HasColumnType("datetime")
                .HasColumnName("OldDOB");
            entity.Property(e => e.OldName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldStateId).HasColumnName("OldStateID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
        });

        modelBuilder.Entity<StudentAuditView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("StudentAuditView");

            entity.Property(e => e.AuditId)
                .ValueGeneratedOnAdd()
                .HasColumnName("AuditID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.NewCityId).HasColumnName("NewCityID");
            entity.Property(e => e.NewClass)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NewCountryId).HasColumnName("NewCountryID");
            entity.Property(e => e.NewDob)
                .HasColumnType("datetime")
                .HasColumnName("NewDOB");
            entity.Property(e => e.NewName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NewStateId).HasColumnName("NewStateID");
            entity.Property(e => e.OldCityId).HasColumnName("OldCityID");
            entity.Property(e => e.OldClass)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.OldCountryId).HasColumnName("OldCountryID");
            entity.Property(e => e.OldDob)
                .HasColumnType("datetime")
                .HasColumnName("OldDOB");
            entity.Property(e => e.OldName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OldStateId).HasColumnName("OldStateID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
        });

        modelBuilder.Entity<StudentGuardian>(entity =>
        {
            entity.HasKey(e => e.GuardianId).HasName("PK_Student.Guardian");

            entity.ToTable("StudentGuardian");

            entity.Property(e => e.GuardianId).HasColumnName("GUARDIAN_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.GuardianName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GUARDIAN_NAME");
            entity.Property(e => e.GuardianTypeId).HasColumnName("GUARDIAN_TYPE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");

            entity.HasOne(d => d.GuardianType).WithMany(p => p.StudentGuardians)
                .HasForeignKey(d => d.GuardianTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StudentGuardian_GaurdianType");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentGuardians)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentGuardian_Student");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK_Student.Subject");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasColumnName("SUBJECT_ID");
            entity.Property(e => e.CourceId).HasColumnName("COURCE_ID");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("CREATED_ON");
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MODIFIED_BY");
            entity.Property(e => e.ModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("MODIFIED_ON");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");

            entity.HasOne(d => d.Cource).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.CourceId)
                .HasConstraintName("FK_Subject_Course");
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.Uid).HasName("PK__UserMast__C5B69A4AC27E60E9");

            entity.ToTable("UserMaster");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.UserMasters)
                .HasForeignKey(d => d.Role)
                .HasConstraintName("FK__UserMaster__Role__6497E884");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
