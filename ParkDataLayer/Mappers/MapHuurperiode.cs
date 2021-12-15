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
    public class MapHuurperiode
    {
        public static Huurperiode MapToDomain(HuurperiodeEF huurperiode)
        {
            try
            {
                return new Huurperiode(huurperiode.StartDatum, huurperiode.Aantaldagen);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurperiode - MapToDomain", ex);
            }
        }

        internal static HuurperiodeEF MapToDB(Huurperiode huurperiode)
        {
            try
            {
                return new HuurperiodeEF(huurperiode.StartDatum, huurperiode.EindDatum, huurperiode.Aantaldagen);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurperiode - MapToDomain", ex);
            }
        }
    }
}
