namespace GOOS_Sample.Models.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BudgetEntites : DbContext
    {
        public BudgetEntites()
            : base("name=BudgetEntities")
        {
        }

        public virtual DbSet<Budget> Budgets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Budget>()
                .Property(e => e.YearMonth)
                .IsUnicode(false);
        }
    }
}
