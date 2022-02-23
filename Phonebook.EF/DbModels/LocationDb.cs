using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook.EF.DbModels
{
    [Table("Locations", Schema = "dbo")]
    public class LocationDb
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }


        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        [ForeignKey(nameof(TimezoneDb))]
        public int TimezoneId { get; set; }

        [ForeignKey(nameof(StreetDb))]
        public int StreetId { get; set; }

        public virtual StreetDb StreetDb { get; set; }
        public virtual TimezoneDb TimezoneDb { get; set; }
    }
}