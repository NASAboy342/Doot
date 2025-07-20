using Doot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doot.Repositories
{
    public interface IIssueRepository
    {
        Task<List<KnownIssue>> GetAllKnownIssues();
    }
}