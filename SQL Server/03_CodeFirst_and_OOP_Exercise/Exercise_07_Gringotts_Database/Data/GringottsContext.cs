namespace Exercise_07_Gringotts_Database
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GringottsContext : DbContext
    {
        public GringottsContext()
            : base("name=GringottsContext")
        {
        }

        public virtual DbSet<WizardDeposit> WizardDeposits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.FirstName)
                .IsUnicode(false);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.LastName)
                .IsUnicode(false);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.Notes)
                .IsUnicode(false);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.MagicWandCreator)
                .IsUnicode(false);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.DepositGroup)
                .IsUnicode(false);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.DepositAmount)
                .HasPrecision(8, 2);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.DepositInterest)
                .HasPrecision(8, 2);
            modelBuilder.Entity<WizardDeposit>()
                .Property(e => e.DepositCharge)
                .HasPrecision(8, 2);
        }
    }
}