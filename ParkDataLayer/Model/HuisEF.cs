using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        public int HuisId { get; set; }
        [Column(TypeName = "NVARCHAR(250)")]
        public string Straat { get; set; }
        [Required]
        public int Nummer { get; set; }
        [Required]
        public bool Actief { get; set; }
        public int ParkId { get; set; }
        public ParkEF Park { get; set; }
        public Dictionary<HuurderEF, List<HuurcontractEF>> HuurContracten { get; set; } = new();

        public HuisEF()
        {
        }

        public HuisEF(int huisId, string straat, int nummer, bool actief, int parkId, ParkEF park, Dictionary<HuurderEF, List<HuurcontractEF>> huurContracten)
        {
            HuisId = huisId;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            ParkId = parkId;
            Park = park;
            HuurContracten = huurContracten;
        }
    }
}
