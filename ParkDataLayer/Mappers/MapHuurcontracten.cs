using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class MapHuurcontracten
    {
        public static Dictionary<Huurder, List<Huurcontract>> MapToDomain(List<HuurcontractEF> d)
        {
            try
            {
                List<Huurcontract> huurcontracts = new();
                foreach (HuurcontractEF EF in d)
                {
                    huurcontracts.Add(MapHuurcontract.MapToDomain(EF));
                }
                Dictionary<Huurder, List<Huurcontract>> huurContracten = huurcontracts.GroupBy(h => h.Huurder).ToDictionary(h => h.Key, h => h.ToList());
                return huurContracten;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontracten - MapToDomain", ex);
            }
        }

        public static List<HuurcontractEF> MapToDB(Func<IReadOnlyList<Huurcontract>> h)
        {
            try
            {
                //TODO: Dictionary<HuurderEF, List<HuurcontractEF>> MapToDB(Func<IReadOnlyList<Huurcontract>> h)
                List<HuurcontractEF> huurContracten = new();
                return huurContracten;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontracten - MapToDB", ex);
            }
        }
    }
}
