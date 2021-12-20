﻿using Microsoft.EntityFrameworkCore;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer
{
    public class ParkbeheerContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<HuisEF> Huizen { get; set; }
        public DbSet<HuurderEF> Huurders { get; set; }
        public DbSet<HuurcontractEF> Huurcontracten { get; set; }
        public DbSet<ContactgegevensEF> Contactgegevens { get; set; }
        public DbSet<HuurperiodeEF> Huurperiodes { get; set; }
        public DbSet<ParkEF> Parken { get; set; }

        public ParkbeheerContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
