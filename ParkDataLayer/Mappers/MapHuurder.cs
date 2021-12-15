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
    public class MapHuurder
    {
        public static Huurder MapToDomain(HuurderEF db)
        {
            try
            {
                return new Huurder(db.HuurderId, db.Naam, MapContactgegevens.MapToDomain(db.Contactgegevens));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapToDomain", ex);
            }
        }

        public static HuurderEF MapToDB(Huurder huurder)
        {
            try
            {
                return new HuurderEF(huurder.Id, huurder.Naam, MapContactgegevens.MapToDB(huurder.Contactgegevens));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapToDB", ex);
            }
        }
    }
}
