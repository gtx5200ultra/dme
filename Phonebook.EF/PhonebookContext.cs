using Microsoft.EntityFrameworkCore;
using Phonebook.EF.DbModels;

namespace Phonebook.EF
{
    public sealed class PhonebookContext : DbContext
    {
        public DbSet<LoginDb> Logins { get; set; }
        public DbSet<UserDb> Users { get; set; }
        public DbSet<PictureDb> Pictures { get; set; }
        public DbSet<LocationDb> Locations { get; set; }
        public DbSet<IdentityCardDb> PersonalIds { get; set; }
        public DbSet<TimezoneDb> Timezones { get; set; }
        public DbSet<StreetDb> Streets { get; set; }

        public PhonebookContext(DbContextOptions<PhonebookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public PhonebookContext(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersPhonesDb>()
                .HasKey(c => new { c.PhoneId, c.UserId });
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }
    }
}
