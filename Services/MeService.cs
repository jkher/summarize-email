using Microsoft.Graph;

class MeService
{
    public async static Task<MeModel> GetMeAsync(GraphServiceClient graphServiceClient)
    {
        var me = await graphServiceClient.Me.GetAsync();

        return new MeModel {
            DisplayName = me?.DisplayName,
            EmailAddress = me?.Mail
        };
    }
}