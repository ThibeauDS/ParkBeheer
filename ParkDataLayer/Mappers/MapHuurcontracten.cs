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
        public static Dictionary<Huurder, List<Huurcontract>> MapToDomain(Dictionary<HuurderEF, List<HuurcontractEF>> d)
        {
            try
            {
                //TODO: Dictionary<Huurder, List<Huurcontract>> MapToDomain(Dictionary<HuurderEF, List<HuurcontractEF>> d)
                Dictionary<Huurder, List<Huurcontract>> huurContracten = new();
                return huurContracten;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontracten - MapToDomain", ex);
            }
        }

        internal static Dictionary<HuurderEF, List<HuurcontractEF>> MapToDB(Func<IReadOnlyList<Huurcontract>> h)
        {
            try
            {
                //TODO: Dictionary<HuurderEF, List<HuurcontractEF>> MapToDB(Func<IReadOnlyList<Huurcontract>> h)
                Dictionary<HuurderEF, List<HuurcontractEF>> huurContracten = new();
                return huurContracten;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontracten - MapToDB", ex);
            }
        }
    }
}
