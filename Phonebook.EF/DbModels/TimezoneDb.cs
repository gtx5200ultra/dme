using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Phonebook.EF.DbModels
{
    [Table("Timezones", Schema = "dbo")]
    public class TimezoneDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Offset { get; set; }
        public string Description { get; set; }
    }
}
