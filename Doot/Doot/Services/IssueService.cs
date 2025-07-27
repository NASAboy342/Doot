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
            var allKnowIssues = await _issueRepository.GetAllKnownIssues();
            return allKnowIssues;
        }
    }
}
