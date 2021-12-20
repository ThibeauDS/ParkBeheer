using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Repositories;
using System;
using System.Configuration;

namespace ModelTestConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connectionParkbeheerSDB"].ConnectionString;
            ParkbeheerContext ctx = new(connectionString);
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            BeheerHuizen beheerHuizen = new(new HuizenRepositoryEF(connectionString));
            BeheerHuurders beheerHuurders = new(new HuurderRepositoryEF(connectionString));
            BeheerContracten beheerContracten = new(new ContractenRepositoryEF(connectionString));

            Console.WriteLine("----------\nBeheerHuizen\n----------");
            Park park = new("park1", "Park van Breivelde", "Zottegem");
            beheerHuizen.VoegNieuwHuisToe("Steenweg", 101, park);
            Huis huis = beheerHuizen.GeefHuis(1);
            Console.WriteLine(huis);

            huis.ZetNr(26);
            huis.ZetStraat("Sleistraat");
            beheerHuizen.UpdateHuis(huis);
            huis = beheerHuizen.GeefHuis(1);
            Console.WriteLine(huis);

            beheerHuizen.ArchiveerHuis(huis);
            huis = beheerHuizen.GeefHuis(1);
            Console.WriteLine(huis);

            Console.WriteLine("----------\nBeheerHuurders\n----------");
            beheerHuurders.VoegNieuweHuurderToe("Dirk", new("dirk@gmail.com", "+32 486 91 25 01", "Peer"));
            Huurder huurder = beheerHuurders.GeefHuurder(1);
            Console.WriteLine(huurder);

            beheerHuurders.VoegNieuweHuurderToe("Dirk", new("dirk@outlook.com", "+32 481 64 59 82", "Koekelberg"));
            huurder = beheerHuurders.GeefHuurder(2);
            Console.WriteLine(huurder);

            beheerHuurders.VoegNieuweHuurderToe("Jhony", new("jhony@yahoo.com", "+32 471 58 36 23", "Knokke"));
            huurder = beheerHuurders.GeefHuurder(3);
            Console.WriteLine(huurder);

            //TODO: fix voor meerdere huurders op te vragen.
            //foreach (Huurder huurder1 in beheerHuurders.GeefHuurders("Dirk"))
            //{
            //    Console.WriteLine(huurder1);
            //}

            huurder.ZetContactgegevens(new("jhony@yahoo.com", "+32 471 58 36 23", "Overpoort"));
            beheerHuurders.UpdateHuurder(huurder);
            huurder = beheerHuurders.GeefHuurder(3);
            Console.WriteLine(huurder);

            Console.WriteLine("----------\nBeheerContracten\n----------");
            //TODO: beginnen aan BeheerContracten
        }
    }
}
