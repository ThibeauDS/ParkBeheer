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
                Dictionary<Huurder, List<Huurcontract>> huurContracten = (Dictionary<Huurder, List<Huurcontract>>)d.GroupBy(e => e.Huurder);
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
