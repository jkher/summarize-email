using Microsoft.Extensions.Configuration;

class Settings
{
    public string? ClientId { get; set; }
    public string[]? GraphUserScopes { get; set; }
    public string? CognitiveApiUri { get; set; }
    public string? CognitiveApikey { get; set; }
    public int MessageSelectionCount { get; set; } = 10;
    public int PageSize { get; set; } = 10;

    public static Settings LoadSettings()
    {
        // Load settings
        IConfiguration config = new ConfigurationBuilder()
            // appsettings.json is required
            .AddJsonFile("appsettings.json", optional: false)
            // appsettings.Development.json" is optional, values override appsettings.json
            .AddJsonFile($"appsettings.Development.json", optional: true)
            // User secrets are optional, values override both JSON files
            .AddUserSecrets<Program>()
            .Build();
       
        return config.GetRequiredSection("Settings").Get<Settings>() ??
            throw new Exception("Could not load app settings. See README for configuration instructions.");
    }
}