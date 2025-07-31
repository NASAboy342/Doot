using Doot.Data;
using Doot.Models;
using Doot.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;
        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }
        public async Task<List<KnownIssue>> GetKnownIssues()
        {
            var allKnownIssuesFromBuildIn = BuildinKnowIssue.Get;

            return allKnownIssuesFromBuildIn.ToList();
        }
        public async Task<KnownIssue?> GetKnownIssuesById(int id)
        {
            var allKnownIssues = await GetKnownIssues();
            return allKnownIssues.FirstOrDefault(x => x.Id == id);
        }
    }
}
