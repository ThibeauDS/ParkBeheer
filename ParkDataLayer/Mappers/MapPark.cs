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
    public class MapPark
    {
        public static Park MapToDomain(ParkEF park)
        {
            try
            {
                return new Park(park.ParkId, park.Naam, park.Locatie, MapHuis.MapToDomain(park.Huis));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontracten - MapToDomain", ex);
            }
        }

        public static ParkEF MapToDB(Park park)
        {
            try
            {
                return new ParkEF(park.Id, park.Naam, park.Locatie, MapHuis.MapToDB(park.Huizen));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontracten - MapToDB", ex);
            }
        }
    }
}
