using Microsoft.Graph;
using Spectre.Console;

class WelcomeView
{
    public async static Task<MeModel> ShowAsync(GraphServiceClient graphClient)
    {
        //get me and welcome me
        var me = await MeService.GetMeAsync(graphClient);
        WriteUserWelcome(me);
        return me;
    }

    static void WriteUserWelcome(MeModel me)
    {
        AnsiConsole.WriteLine("");
        AnsiConsole.MarkupLine($"Hello [underline greenyellow]{me.DisplayName}[/]!");
        AnsiConsole.WriteLine("");
        AnsiConsole.MarkupLine(@"With this app, you can select any latest email message from your inbox " +
                                "and generate a concise summary of its contents. " +
                                "This summary will give you all the key information you need to know, " +
                                "without having to read through the entire email.:rocket:.");
        AnsiConsole.MarkupLine("Not only does this app save you time by summarizing email message for you, " +
                                "it also allows you to take action on the generated summary.:rocket:");
        AnsiConsole.WriteLine("");
        AnsiConsole.MarkupLine("Should you choose to quit from the app, then use [underline orchid1]ctrl+c[/].");
        AnsiConsole.WriteLine("");
    }
}