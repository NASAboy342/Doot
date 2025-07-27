using Doot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Doot.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<KnownIssue> KnownIssue { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        private static string DatabasePath => Path.Combine(Microsoft.Maui.Storage.FileSystem.AppDataDirectory, "doot.db");

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DatabasePath}");
        }
        /// <summary>
        /// Truncates the KnownIssue table and inserts the provided issues.
        /// </summary>
        public static async Task SeedKnownIssuesAsync(IEnumerable<KnownIssue> issues)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite($"Data Source={DatabasePath}")
                .Options;

            using var context = new AppDbContext();
            // Remove all existing
            context.KnownIssue.RemoveRange(context.KnownIssue);
            await context.SaveChangesAsync();
            // Add new
            await context.KnownIssue.AddRangeAsync(issues);
            await context.SaveChangesAsync();
        }
    }
}
