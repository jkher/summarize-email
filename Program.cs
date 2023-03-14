using Azure.Identity;
using Microsoft.Graph;
using Spectre.Console;
using Azure.AI.TextAnalytics;
using Azure;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

try
{
    //load required settings
    var settings = Settings.LoadSettings();

    GraphServiceClient? graphClient = null;

    AnsiConsole.Status().Spinner(Spinner.Known.Triangle).Start("[yellow]Waiting for interactive authentication from browser...[/]", ctx =>
    {
        //initialize graph client
        graphClient = GraphClientService.GetGraphClient(settings);
    });

    //authenticate and welcome user
    var me = await WelcomeView.ShowAsync(graphClient!);

    while (true)
    {
        //email message selection menu
        var messageContent = await MessageSelectionView.ShowAsync(graphClient!, settings);

        //display summary
        var conentSummary = await SummaryView.ShowAsync(graphClient!, settings, messageContent);
        messageContent.Summary = conentSummary.ToString();

        //Post actions
        var startOver = await PostSummaryActionView.ShowAsync(graphClient!, messageContent, me);

        if (!startOver) break;
    }
}
catch (Exception ex)
{
    ExceptionHandlerService.HandleException("UNHANDLED EXCEPTION", ex.ToString());
}

Shared.SayGoodbye();

//display Microsoft Hack-Togehter badge
Shared.WriteHackTogetherBadge();




