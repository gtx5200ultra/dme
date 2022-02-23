using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

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

        //public string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=phonebook;Trusted_Connection=True;MultipleActiveResultSets=true";

        //public MobileContext(DbContextOptions<MobileContext> options, string connectionString)
        //    : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsersPhonesDb>()
                .HasKey(c => new { c.PhoneId, c.UserId });
        }

        public PhonebookContext(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
        }

        [Table("Logins", Schema = "dbo")]
        public class LoginDb
        {
            [Key, Required]
            [Column("Id")]
            public Guid Uuid { get; set; }
            public string Username { get; set; }
            public string Salt { get; set; }
            public string Md5 { get; set; }
            public string Sha1 { get; set; }
            public string Sha256 { get; set; }
        }

        [Table("Phones", Schema = "dbo")]
        public class PhoneDb
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }

            public string Number { get; set; }
            public int Type { get; set; }
            public virtual ICollection<UsersPhonesDb> UsersPhonesDb { get; set; }
        }

        [Table("UserPhones", Schema = "dbo")]
        public class UsersPhonesDb
        {
            [Required, ForeignKey(nameof(PhoneDb))]
            public int PhoneId { get; set; }

            [Required, ForeignKey(nameof(UserDb))]
            public int UserId { get; set; }
            public virtual PhoneDb Phone { get; set; }
            public virtual UserDb User { get; set; }
        }

        [Table("Users", Schema = "dbo")]
        public class UserDb
        {
            [Key, Required, ForeignKey(nameof(LoginDb))]
            public Guid Id { get; set; }
            public string Gender { get; set; }
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
            public string Email { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTimeOffset Registered { get; set; }
            public string Nationality { get; set; }

            [ForeignKey(nameof(LocationDb))]
            public int LocationId { get; set; }

            [ForeignKey(nameof(PictureDb))]
            public int PictureId { get; set; }

            [ForeignKey(nameof(IdentityCardDb))]
            public int IdentityCardId { get; set; }

            public virtual IdentityCardDb IdentityCard { get; set; }
            public virtual LoginDb LoginDb { get; set; }
            public virtual LocationDb LocationDb { get; set; }
            public virtual ICollection<UsersPhonesDb> UsersPhonesDb { get; set; }
        }

        [Table("Pictures", Schema = "dbo")]
        public class PictureDb
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }

            public string Large { get; set; }
            public string Medium { get; set; }
            public string Thumbnail { get; set; }
        }

        [Table("Locations", Schema = "dbo")]
        public class LocationDb
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }


            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public int Postcode { get; set; }
            
            public string Latitude { get; set; }
            public string Longitude { get; set; }

            [ForeignKey(nameof(TimezoneDb))]
            public int TimezoneId { get; set; }

            [ForeignKey(nameof(StreetDb))]
            public int StreetId { get; set; }

            public virtual StreetDb StreetDb { get; set; }
            public virtual TimezoneDb TimezoneDb { get; set; }
        }

        [Table("IdentityCards", Schema = "dbo")]
        public class IdentityCardDb
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }

            public string Name { get; set; }
            public string Value { get; set; }
        }

        [Table("Timezones", Schema = "dbo")]
        public class TimezoneDb
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }

            public string Offset { get; set; }
            public string Description { get; set; }
        }

        [Table("Streets", Schema = "dbo")]
        public class StreetDb
        {
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }

            public int Number { get; set; }
            public string Name { get; set; }
        }
    }
}
