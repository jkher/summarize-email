using Microsoft.Graph;
class MessageService
{
    public async static Task<MessageSelectionModel[]> GetLatestMessages(
        GraphServiceClient graphClient, int top)
    {
        var emails = await graphClient.Me.MailFolders["inbox"].Messages.GetAsync((config) =>
        {
            config.QueryParameters.Top = top;
            config.QueryParameters.Select = new[] { "id", "sender", "sentDateTime",
                                                    "subject", "importance" };

            config.QueryParameters.Orderby = new[] { "sentDateTime desc" };
        });

        return (from email in emails?.Value!
                select new MessageSelectionModel
                {
                    Id = email.Id,
                    Subject = email.Subject,
                    Sender = email.Sender!.EmailAddress!.Name,
                    Importance = email.Importance!.Value.ToString(),
                    SentDateTime = email.SentDateTime!.Value
                }).ToArray();

    }

    public async static Task<MessageContentModel> GetMessageContentAsync(
        GraphServiceClient graphClient, MessageSelectionModel selectedMessage)
    {
        var emailContent = await graphClient.Me.Messages[selectedMessage.Id].GetAsync((config) =>
        {
            config.Headers.Add("Prefer", "outlook.body-content-type='text'"); //always get plain text in content
            config.QueryParameters.Select = new[] { "body" };
        });

        return new MessageContentModel {
            Id = selectedMessage.Id!,
            Content = emailContent?.Body?.Content!,
            SelectedMessage = selectedMessage
        };
    }

    public async static Task SendMessageAsync(GraphServiceClient graphClient, MeModel me, MessageContentModel contentSummary)
    {
        var requestBody = new Microsoft.Graph.Me.SendMail.SendMailPostRequestBody
        {
            Message = new Microsoft.Graph.Models.Message
            {
                Subject = $"Message Summary - {contentSummary.SelectedMessage!.Subject}",
                Body = new Microsoft.Graph.Models.ItemBody
                {
                    ContentType = Microsoft.Graph.Models.BodyType.Text,
                    Content = contentSummary.Summary
                },
                ToRecipients = new List<Microsoft.Graph.Models.Recipient>
                {
                    new Microsoft.Graph.Models.Recipient
                    {
                        EmailAddress = new Microsoft.Graph.Models.EmailAddress
                        {
                            Address = me.EmailAddress
                        }
                    }
                }
            },
            SaveToSentItems = false
        };

        await graphClient.Me.SendMail.PostAsync(requestBody);
    }
}