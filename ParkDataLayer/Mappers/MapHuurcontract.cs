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
    public class MapHuurcontract
    {
        public static Huurcontract MapToDomain(HuurcontractEF huurcontractEF)
        {
            try
            {
                return new Huurcontract(huurcontractEF.HuurcontractId, MapHuurperiode.MapToDomain(huurcontractEF.Huurperiode), MapHuurder.MapToDomain(huurcontractEF.Huurder), MapHuis.MapToDomain(huurcontractEF.Huis));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontract - MapToDomain", ex);
            }
        }

        internal static HuurcontractEF MapToDB(Huurcontract contract)
        {
            try
            {
                return new HuurcontractEF(contract.Id, MapHuurperiode.MapToDB(contract.Huurperiode), MapHuurder.MapToDB(contract.Huurder), MapHuis.MapToDB(contract.Huis));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontract - MapToDB", ex);
            }
        }
    }
}
