using Doot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Repositories
{
    public class IssueRepository : BaseRepository, IIssueRepository
    {
        public IssueRepository() : base(new AppDbContext())
        {
            
        }

        public async Task<List<KnownIssue>> GetAllKnownIssues()
        {
            var allKnowIssues = await GetAllAsync<KnownIssue>();
            return allKnowIssues.ToList();
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<KnownIssue> KnownIssue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var appDirectory = AppContext.BaseDirectory;
            var dbPath = Path.Combine("../", appDirectory, "app.db");
            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
