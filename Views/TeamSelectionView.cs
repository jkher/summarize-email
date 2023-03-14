using Microsoft.Graph;
using Spectre.Console;

class TeamSelectionView
{
    public async static Task<TeamSelectionModel> ShowAsync(GraphServiceClient graphClient)
    {
        var teams = await TeamsService.GetMyTeamsAsync(graphClient);
        var selectedTeam = WriteTeamSelectionMenu(teams);

        return selectedTeam;
    }

    static TeamSelectionModel WriteTeamSelectionMenu(TeamSelectionModel[] teams)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<TeamSelectionModel>()
            .Title("[underline]Please select a team:[/]")
            .AddChoices<TeamSelectionModel>(teams)
        );
    }
}

