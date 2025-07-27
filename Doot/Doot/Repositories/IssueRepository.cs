using Doot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Repositories
{
    using Microsoft.EntityFrameworkCore;
    public class IssueRepository : BaseRepository, IIssueRepository
    {
        public IssueRepository(IDbContextFactory<AppDbContext> contextFactory) : base(contextFactory)
        {
        }

        public async Task<List<KnownIssue>> GetAllKnownIssues()
        {
            var allKnowIssues = await GetAllAsync<KnownIssue>();
            return allKnowIssues.ToList();
        }
    }
}
