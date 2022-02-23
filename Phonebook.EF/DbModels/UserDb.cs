using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.EF.DbModels
{
    [Table("Users", Schema = "dbo")]
    public class UserDb
    {
        [Key, Required, ForeignKey(nameof(LoginDb))]
        public Guid Id { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        public virtual PictureDb Picture { get; set; }
        public virtual ICollection<UsersPhonesDb> UsersPhonesDb { get; set; }
    }
}