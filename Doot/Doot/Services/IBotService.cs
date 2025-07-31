namespace Doot.Services;

public interface IBotService
{
    Task GetResponseAsync(List<string> messages);
}