using Microsoft.Graph;
using Microsoft.Graph.Models;

class TeamsService
{
    public async static Task<TeamSelectionModel[]> GetMyTeamsAsync(GraphServiceClient graphClient)
    {
        var teams = await graphClient.Me.JoinedTeams.GetAsync();

        return (from team in teams?.Value!
                select new TeamSelectionModel
                {
                    Id = team.Id,
                    Name = team.DisplayName,
                    Description = team.Description
                }).ToArray();
    }

    public async static Task<TeamChannelSelectionModel[]> GetTeamChannelsAsync(GraphServiceClient graphClient, TeamSelectionModel team)
    {
        var channels = await graphClient.Teams[team.Id].Channels.GetAsync();

        return (from channel in channels?.Value!
                select new TeamChannelSelectionModel {
                    Id = channel.Id,
                    Name = channel.DisplayName,
                    Description= channel.Description
                }).ToArray();
    }

    public async static Task PostAMessageToChannelAsync(GraphServiceClient graphClient, TeamSelectionModel team, TeamChannelSelectionModel channel, MessageContentModel content)
    {
        var requestBody = new ChatMessage
        {
            Body = new ItemBody
            {
                Content = $"*Summary For '{content.SelectedMessage!.Subject}'*\n\n{content.Summary}",
            },
        };
        var result = await graphClient.Teams[team.Id].Channels[channel.Id].Messages.PostAsync(requestBody);
    }
}

