using System;
using Doot.Models;

namespace Doot.Data;

public class BuildinKnowIssue
{
    public static readonly KnownIssue[] Get = new[]
    {
        new KnownIssue
        {
            Id = 1,
            Title = "Need manual cancel bet",
            Description = "When a bet is confirm to be errored on provider side, it needs to be manually cancelled.",
        },
    };
}
