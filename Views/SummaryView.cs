using Microsoft.Graph;
using Spectre.Console;

class SummaryView
{
    public async static Task<ContentSummaryModel> ShowAsync(GraphServiceClient graphClient, Settings settings, MessageContentModel messageContent)
    {
        ContentSummaryModel? returnValue = null;
        
        await AnsiConsole.Status().Spinner(Spinner.Known.Triangle).StartAsync("[yellow]Summarizing email...[/]", async ctx =>
        {
            //Generate content summary
            returnValue = await ContentSummarizationService.GetContentSummary(messageContent.Content!, settings);
            var summary = returnValue.ToString();
            Shared.WritePanel(messageContent.SelectedMessage!.Subject!, summary);
            AnsiConsole.WriteLine("");
        });

        return returnValue!;
    }
}