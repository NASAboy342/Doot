using LLama;
using LLama.Common;

namespace Doot.Services;

public class BotService : IBotService
{
    private readonly InteractiveExecutor _executor;
    public BotService()
    {
        var relativePath = "BotModel/deepseek-coder-6.7b-instruct.Q4_K_M.gguf";
        var basePath = AppContext.BaseDirectory;
        var modelPath = Path.Combine(basePath, relativePath);

        var modelParams = new ModelParams(modelPath)
        {
            ContextSize = 1000,
            GpuLayerCount = 1,
        };

        var model = LLamaWeights.LoadFromFile(modelParams);
        using var context = model.CreateContext(modelParams);

        _executor = new InteractiveExecutor(context);
    }
    public async Task GetResponseAsync(List<string> messages)
    {
        while (true)
        {
            var prompt = messages.LastOrDefault() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(prompt)) continue;
            messages.Add("");
            await foreach (var result in _executor.InferAsync($"<|system|>\nYou are a helpful AI coding assistant that would come with code example.\n<|user|>\n{prompt}\n<|assistant|>\n"))
            {
                if(string.IsNullOrWhiteSpace(result)) break;
                Console.Write(result);
                messages[^1] += result;
            }
        }
    }
}