using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.EF.DbModels
{
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