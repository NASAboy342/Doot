using Doot.Enums;

namespace Doot.Models;

public class Operation
{
    public EnumOperationType Type { get; set; }
    public string PlaceHolder { get; set; } = "";
    public Dictionary<string, string> Results { get; set; } = new Dictionary<string, string>();
}