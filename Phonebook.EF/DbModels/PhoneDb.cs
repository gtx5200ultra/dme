using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.EF.DbModels
{
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
}