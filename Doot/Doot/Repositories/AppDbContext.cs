using Doot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Doot.Repositories
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        private static string DatabasePath => Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, "doot.db");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DatabasePath}");
        }
    }
}
