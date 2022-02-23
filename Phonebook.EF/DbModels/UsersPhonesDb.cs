using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.EF.DbModels
{
    [Table("UserPhones", Schema = "dbo")]
    public class UsersPhonesDb
    {
        [Required, ForeignKey(nameof(PhoneDb))]
        public int PhoneId { get; set; }

        [Required, ForeignKey(nameof(UserDb))]
        public Guid UserId { get; set; }
        public virtual PhoneDb Phone { get; set; }
        public virtual UserDb User { get; set; }
    }
}