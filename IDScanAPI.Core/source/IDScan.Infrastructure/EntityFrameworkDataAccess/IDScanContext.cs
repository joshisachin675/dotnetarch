namespace IDScan.Infrastructure.EntityFrameworkDataAccess {
    using Microsoft.EntityFrameworkCore;
    using Entities;
    public sealed class IDScanContext : DbContext {
        public IDScanContext (DbContextOptions options) : base (options) {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Debit> Debits { get; set; }
        public  DbSet<User> Users { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Account> ()
                .ToTable ("Account");

            modelBuilder.Entity<Customer> ()
                .ToTable ("Customer");

            modelBuilder.Entity<Debit> ()
                .ToTable ("Debit");

            modelBuilder.Entity<Credit> ()
                .ToTable ("Credit");

            modelBuilder.Entity<Credit>()
             .ToTable("Users");
        }
    }
}