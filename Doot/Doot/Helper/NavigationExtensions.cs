using System;
using System.Web;
using Microsoft.AspNetCore.Components;

namespace Doot.Helper;

public static class NavigationExtensions
{
    public static Dictionary<string, string> GetQueryParams(this NavigationManager nav)
    {
        var uri = new Uri(nav.Uri);
        var query = HttpUtility.ParseQueryString(uri.Query);
        return query.AllKeys
                    .Where(key => key != null)
                    .ToDictionary(key => key!, key => query[key]!);
    }
}
