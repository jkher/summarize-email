using Microsoft.Graph;
using Spectre.Console;

class TeamChannelSelectionView
{
    public async static Task<TeamChannelSelectionModel> ShowAsync(GraphServiceClient graphClient, TeamSelectionModel selectedTeam)
    {
        var channels = await TeamsService.GetTeamChannelsAsync(graphClient, selectedTeam);
        var selectedChannel = WriteTeamSelectionMenu(channels, selectedTeam);

        return selectedChannel;
    }

    static TeamChannelSelectionModel WriteTeamSelectionMenu(TeamChannelSelectionModel[] channels, TeamSelectionModel selectedTeam)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<TeamChannelSelectionModel>()
            .Title($"[underline]Please select a channel from team '{selectedTeam.Name}':[/]")
            .AddChoices<TeamChannelSelectionModel>(channels)
        );
    }
}
