using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.EF.DbModels
{
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
}