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
                if (huurcontractEF == null)
                {
                    return null;
                }
                return new Huurcontract(huurcontractEF.HuurcontractId, MapHuurperiode.MapToDomain(huurcontractEF.Huurperiode), MapHuurder.MapToDomain(huurcontractEF.Huurder), MapHuis.MapToDomain(huurcontractEF.Huis));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontract - MapToDomain", ex);
            }
        }

        public static HuurcontractEF MapToDB(Huurcontract contract, ParkbeheerContext ctx)
        {
            try
            {
                HuisEF huisEF = ctx.Huizen.Find(contract.Huis.Id);
                if (huisEF == null)
                {
                    huisEF = MapHuis.MapToDB(contract.Huis, contract.Huurder, ctx);
                }
                HuurderEF huurderEF = ctx.Huurders.Find(contract.Huurder.Id);
                if (huurderEF == null)
                {
                    huurderEF = MapHuurder.MapToDB(contract.Huurder);
                }
                return new HuurcontractEF(contract.Id, MapHuurperiode.MapToDB(contract.Huurperiode), huurderEF, huisEF);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontract - MapToDB", ex);
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
