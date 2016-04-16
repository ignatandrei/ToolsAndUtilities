using System.Data.Entity.Infrastructure;
using SQLite.CodeFirst;

namespace EFSwitch
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer<Model1>(new CreateDatabaseIfNotExists<Model1>());
            
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<Model1>(new SqliteCreateDatabaseIfNotExists<Model1>(modelBuilder));
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employee)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.IDDepartment)
                .WillCascadeOnDelete(false);
        }
    }
}
