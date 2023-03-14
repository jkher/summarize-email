using Microsoft.Graph;
using Spectre.Console;

class MessageSelectionView
{
    public async static Task<MessageContentModel> ShowAsync(GraphServiceClient graphClient, Settings settings)
    {
        //get latest 'n' mail messages (n = settings.MessageSelectionCount)
        var messages = await MessageService.GetLatestMessages(graphClient, settings.MessageSelectionCount);

        //allow user to select a message and get content of the message
        var selectedMessage = WriteMessageSelectionMenu(messages, settings);
        var messageContent = await MessageService.GetMessageContentAsync(graphClient, selectedMessage);

        return messageContent;
    }

    static MessageSelectionModel WriteMessageSelectionMenu(MessageSelectionModel[] messages, Settings settings)
    {
        return AnsiConsole.Prompt(new SelectionPrompt<MessageSelectionModel>()
            .Title("[underline]Please select a mail message:[/]")
            .PageSize(settings.PageSize)
            .MoreChoicesText("[grey](Move up and down to reveal more messages)[/]")
            .AddChoices<MessageSelectionModel>(messages)
        );
    }
}