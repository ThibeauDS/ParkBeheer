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
    public class MapHuis
    {
        public static Huis MapToDomain(HuisEF huisEF)
        {
            try
            {
                return new Huis(huisEF.HuisId, huisEF.Straat, huisEF.Nummer, huisEF.Actief, MapPark.MapToDomain(huisEF.Park), MapHuurcontracten.MapToDomain(huisEF.HuurContracten));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDomain", ex);
            }
        }

        public static List<Huis> MapToDomain(ICollection<HuisEF> huizenEF)
        {
            try
            {
                List<Huis> huizen = new();
                foreach (HuisEF huis in huizenEF)
                {
                    huizen.Add(MapToDomain(huis));
                }
                return huizen;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDomain", ex);
            }
        }

        public static List<HuisEF> MapToDB(Func<IReadOnlyList<Huis>> huizen)
        {
            try
            {
                IReadOnlyCollection<Huis> huizenDM = huizen.Invoke();
                List<HuisEF> huizenEF = new();
                foreach (Huis huis in huizenDM)
                {
                    huizenEF.Add(MapToDB(huis));
                }
                return huizenEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDB", ex);
            }
        }

        public static HuisEF MapToDB(Huis huis)
        {
            try
            {
                return new HuisEF(huis.Id, huis.Straat, huis.Nr, huis.Actief, int.Parse(huis.Park.Id), MapPark.MapToDB(huis.Park), MapHuurcontracten.MapToDB(huis.Huurcontracten));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDB", ex);
            }
        }

        public static List<HuisEF> MapToDB(ICollection<Huis> huizen)
        {
            try
            {
                List<HuisEF> huizenEF = new();
                foreach (Huis huis in huizen)
                {
                    huizenEF.Add(MapToDB(huis));
                }
                return huizenEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDB", ex);
            }
        }
    }
}
