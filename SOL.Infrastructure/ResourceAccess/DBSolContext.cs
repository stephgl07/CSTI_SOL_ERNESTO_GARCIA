using SOL.Domain.Models.BusinessEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SOL.Infrastructure.ResourceAccess
{
    public partial class DBSolContext : DbContext
    {
        public DBSolContext()
            : base("name=DBSolContext")
        {
        }

        public virtual DbSet<COURSES> COURSES { get; set; }
        public virtual DbSet<COURSESECTIONVACANCIES> COURSESECTIONVACANCIES { get; set; }
        public virtual DbSet<ENROLLMENTS> ENROLLMENTS { get; set; }
        public virtual DbSet<SECTIONS> SECTIONS { get; set; }
        public virtual DbSet<STUDENTS> STUDENTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COURSES>()
                .Property(e => e.COURSEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COURSES>()
                .Property(e => e.COURSEDESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<COURSES>()
                .Property(e => e.CREDITHOURS)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COURSES>()
                .HasMany(e => e.COURSESECTIONVACANCIES)
                .WithRequired(e => e.COURSES)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSESECTIONVACANCIES>()
                .Property(e => e.COURSEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COURSESECTIONVACANCIES>()
                .Property(e => e.SECTIONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<COURSESECTIONVACANCIES>()
                .Property(e => e.VACANCIES)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ENROLLMENTS>()
                .Property(e => e.ENROLLMENTID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ENROLLMENTS>()
                .Property(e => e.STUDENTDNI)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ENROLLMENTS>()
                .Property(e => e.COURSEID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ENROLLMENTS>()
                .Property(e => e.SECTIONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ENROLLMENTS>()
                .Property(e => e.ENROLLMENTTYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SECTIONS>()
                .Property(e => e.SECTIONID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<SECTIONS>()
                .Property(e => e.SECTIONNAME)
                .IsUnicode(false);

            modelBuilder.Entity<SECTIONS>()
                .HasMany(e => e.COURSESECTIONVACANCIES)
                .WithRequired(e => e.SECTIONS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STUDENTS>()
                .Property(e => e.DNI)
                .HasPrecision(38, 0);

            modelBuilder.Entity<STUDENTS>()
                .Property(e => e.STUDENTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENTS>()
                .Property(e => e.FIRSTNAMES)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENTS>()
                .Property(e => e.LASTNAMES)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENTS>()
                .HasMany(e => e.ENROLLMENTS)
                .WithOptional(e => e.STUDENTS)
                .HasForeignKey(e => e.STUDENTDNI);
        }
    }
}
