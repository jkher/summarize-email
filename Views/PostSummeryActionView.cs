using Microsoft.Graph;
using Spectre.Console;
using System.Runtime.CompilerServices;

class PostSummaryActionView
{
    public async static Task<bool> ShowAsync(GraphServiceClient graphClient, MessageContentModel contentSummary, MeModel me)
    {
        var actions = GetActions();
        bool loopContinue = true;

        while (loopContinue)
        {
            var selectedAction = WriteActionSelectionMenu(actions);

            switch (selectedAction.Id)
            {
                case 1:
                    await MessageService.SendMessageAsync(graphClient, me, contentSummary);
                    AnsiConsole.MarkupLine("[underline greenyellow]Email sent successfully![/]\n");
                    loopContinue = true;
                    break;
                case 2:
                    var selectedTeam = await TeamSelectionView.ShowAsync(graphClient);
                    var selectedChannel = await TeamChannelSelectionView.ShowAsync(graphClient, selectedTeam);
                    await TeamsService.PostAMessageToChannelAsync(graphClient, selectedTeam, selectedChannel, contentSummary);
                    AnsiConsole.MarkupLine($"[underline greenyellow]Summary posted on '{selectedChannel.Name}' channel![/]\n");
                    loopContinue = true;
                    break;
            }

            if (selectedAction.Id == 3) { return true; } //signal program to start over again
            else if(selectedAction.Id == 4) { return false; } //goodbye
        }

        return false;
    }

    static PostActionsModel WriteActionSelectionMenu(List<PostActionsModel> actions)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<PostActionsModel>()
            .Title("[underline]Please select an action for generated summary:[/]")
            .AddChoices<PostActionsModel>(actions)
        );
    }

    private static List<PostActionsModel> GetActions()
    {
        return new List<PostActionsModel>()
        {
            new PostActionsModel
            {
                Id = 1,
                Action = "Email generated message summary to me"
            },
            new PostActionsModel
            {
                Id = 2,
                Action = "Send generated message summary to a Teams channel"
            },
            new PostActionsModel
            {
                Id = 3,
                Action = "Select another message to generate summary"
            },
            new PostActionsModel
            {
                Id = 4,
                Action = "Quit app"
            }
        };
    }
}