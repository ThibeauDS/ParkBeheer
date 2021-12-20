using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ParkId { get; set; }
        [Required, Column(TypeName = "NVARCHAR(250)")]
        public string Naam { get; set; }
        [Column(TypeName = "NVARCHAR(500)")]
        public string Locatie { get; set; }
        public List<HuisEF> Huis { get; set; } = new();

        public ParkEF()
        {
        }

        public ParkEF(string id, string naam, string locatie, List<HuisEF> huis)
        {
            ParkId = id;
            Naam = naam;
            Locatie = locatie;
            Huis = huis;
        }

        public ParkEF(string parkId, string naam, string locatie)
        {
            ParkId = parkId;
            Naam = naam;
            Locatie = locatie;
        }
    }
}
