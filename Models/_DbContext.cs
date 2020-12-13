using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamenMVC.Models
{
    public class _DbContext:DbContext
    {
        public _DbContext(String con):base(con) {
            Database.SetInitializer<_DbContext>(null);
        }

        //Migraciones
        public _DbContext() : base("DefaultConection")
        {
            Database.SetInitializer<_DbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeName)
                .HasColumnName("EmployeeName")
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .HasColumnName("Position")
                .IsRequired();

            modelBuilder.Entity<Employee>()
               .Property(e => e.Departament)
               .HasColumnName("Departament")
               .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Version)
                .HasColumnName("Version")
                .IsRequired();

        }

        public System.Data.Entity.DbSet<ExamenMVC.Models.Employee> Employees { get; set; }
    }
}