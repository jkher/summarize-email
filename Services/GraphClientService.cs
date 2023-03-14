using Azure.Identity;
using Microsoft.Graph;

class GraphClientService
{
    public static GraphServiceClient GetGraphClient(Settings settings)
    {
        var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
        {
            ClientId = settings.ClientId
        };
        var tokenCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

        return new GraphServiceClient(tokenCredential, settings.GraphUserScopes);
    }
}