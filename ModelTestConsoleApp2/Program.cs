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

            Console.WriteLine("+---------------+\n| Beheer Huizen |\n+---------------+");
            Console.WriteLine("Huis toevoegen");
            Park park = new("park1", "Park van Breivelde", "Zottegem");
            beheerHuizen.VoegNieuwHuisToe("Steenweg", 101, park);
            Huis huis = beheerHuizen.GeefHuis(1);
            Console.WriteLine(huis);

            Console.WriteLine("\nHuis updaten");
            huis.ZetNr(26);
            huis.ZetStraat("Sleistraat");
            beheerHuizen.UpdateHuis(huis);
            huis = beheerHuizen.GeefHuis(1);
            Console.WriteLine(huis);

            Console.WriteLine("\nHuis archiveren");
            beheerHuizen.ArchiveerHuis(huis);
            huis = beheerHuizen.GeefHuis(1);
            Console.WriteLine(huis);

            Console.WriteLine("\n+-----------------+\n| Beheer Huurders |\n+-----------------+");
            Console.WriteLine("Huurder toevoegen");
            beheerHuurders.VoegNieuweHuurderToe("Dirk", new("dirk@gmail.com", "+32 486 91 25 01", "Peer"));
            Huurder huurder = beheerHuurders.GeefHuurder(1);
            Console.WriteLine(huurder);

            Console.WriteLine("\nHuurder toevoegen");
            beheerHuurders.VoegNieuweHuurderToe("Dirk", new("dirk@outlook.com", "+32 481 64 59 82", "Koekelberg"));
            huurder = beheerHuurders.GeefHuurder(2);
            Console.WriteLine(huurder);

            Console.WriteLine("\nHuurder toevoegen");
            beheerHuurders.VoegNieuweHuurderToe("Jhony", new("jhony@yahoo.com", "+32 471 58 36 23", "Knokke"));
            huurder = beheerHuurders.GeefHuurder(3);
            Console.WriteLine(huurder);

            Console.WriteLine("\nHuurders opvragen - Naam: Dirk");
            foreach (Huurder huurder1 in beheerHuurders.GeefHuurders("Dirk"))
            {
                Console.WriteLine(huurder1);
            }

            Console.WriteLine("\nHuurder updaten");
            huurder.ZetContactgegevens(new("jhony@yahoo.com", "+32 471 58 36 23", "Overpoort"));
            beheerHuurders.UpdateHuurder(huurder);
            huurder = beheerHuurders.GeefHuurder(3);
            Console.WriteLine(huurder);

            Console.WriteLine("\n+-------------------+\n| Beheer Contracten |\n+-------------------+");
            Console.WriteLine("Contract toevoegen");
            Huurperiode huurperiode = new(DateTime.Now.AddDays(20), 365);
            beheerContracten.MaakContract("Contract1", huurperiode, huurder, huis);
            Huurcontract huurcontract = beheerContracten.GeefContract("Contract1");
            Console.WriteLine(huurcontract);

            Console.WriteLine("\nContract toevoegen");
            huurperiode = new(DateTime.Now.AddDays(20), 365);
            beheerContracten.MaakContract("Contract2", huurperiode, huurder, huis);
            Huurcontract huurcontract2 = beheerContracten.GeefContract("Contract2");
            Console.WriteLine(huurcontract2);

            Console.WriteLine("\nContract updaten");
            huurperiode = new(DateTime.Now.AddDays(10), 365 * 2);
            huurcontract.ZetHuurperiode(huurperiode);
            beheerContracten.UpdateContract(huurcontract);
            huurcontract = beheerContracten.GeefContract("Contract1");
            Console.WriteLine(huurcontract);

            Console.WriteLine($"\nContracten opvragen - StartDatum {DateTime.Now.AddDays(10)}");
            foreach (Huurcontract huurcontract1 in beheerContracten.GeefContracten(DateTime.Now.AddDays(10), null))
            {
                Console.WriteLine(huurcontract1);
            }

            Console.WriteLine($"\nContracten opvragen - StartDatum: {DateTime.Now.AddDays(10)} | EindDatum: {DateTime.Now.AddDays(731)}");
            foreach (Huurcontract huurcontract1 in beheerContracten.GeefContracten(DateTime.Now.AddDays(9), DateTime.Now.AddDays(731)))
            {
                Console.WriteLine(huurcontract1);
            }

            Console.WriteLine("\nContract annuleren");
            beheerContracten.AnnuleerContract(huurcontract);
            string contractNaam = huurcontract.Id;
            huurcontract = beheerContracten.GeefContract("Contract1");
            if (huurcontract == null)
            {
                Console.WriteLine($"Huurcontract \"{contractNaam}\" is succesvol geannuleerd");
            }
        }
    }
}
