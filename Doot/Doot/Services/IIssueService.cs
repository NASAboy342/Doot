using Doot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Services
{
    public interface IIssueService
    {
        Task<List<KnownIssue>> GetKnownIssues();
        Task<KnownIssue?> GetKnownIssuesById(int id);
    }
}
