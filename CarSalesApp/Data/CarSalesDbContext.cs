﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Data
{
    public class CarSalesDbContext: DbContext
    {
        public string DbPath { get; } //Will hold location of database filename

        public CarSalesDbContext()
        {
            // set the database filename (inc. full path to the user's Documents folder)
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "cars.db");
        }

        // Specify the database table(s)
        public DbSet<Car> Car => Set<Car>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //Set the database filename (inc. Path) for SQLite to use
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
