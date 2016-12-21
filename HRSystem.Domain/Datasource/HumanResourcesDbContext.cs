namespace HRSystem.Domain.Datasource
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;

    public partial class HumanResourcesDbContext : DbContext
    {
        public HumanResourcesDbContext()
            : base("name=HumanResourcesDbContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Vacations)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);
        }
    }
}
