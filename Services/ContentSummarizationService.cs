using Azure;
using Azure.AI.TextAnalytics;

class ContentSummarizationService
{
    public async static Task<ContentSummaryModel> GetContentSummary(
        string content, Settings settings, int maxSentenceCount = 3)
    {
        ContentSummaryModel returnValue  = new ContentSummaryModel();

        //text analysis and summary extraction
        var batchInput = new List<string>();
        batchInput.Add(content);

        var client = new TextAnalyticsClient(
            new Uri(settings.CognitiveApiUri!),
            new AzureKeyCredential(settings.CognitiveApikey!)
        );

        TextAnalyticsActions actions = new TextAnalyticsActions()
        {
            ExtractSummaryActions = new List<ExtractSummaryAction>() {
                new ExtractSummaryAction {
                    MaxSentenceCount = maxSentenceCount
                }
            }
        };

        //Start analysis process.
        AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchInput, actions);
        await operation.WaitForCompletionAsync();

        //generate model from operation results.
        await foreach (AnalyzeActionsResult documentsInPage in operation.Value)
        {
            IReadOnlyCollection<ExtractSummaryActionResult> summaryResults = documentsInPage.ExtractSummaryResults;

            foreach (ExtractSummaryActionResult summaryActionResults in summaryResults)
            {
                if (summaryActionResults.HasError)
                {
                    ExceptionHandlerService.HandleException(
                        summaryActionResults.Error.ErrorCode.ToString(),
                        summaryActionResults.Error.Message);

                    continue;
                }

                foreach (ExtractSummaryResult documentResults in summaryActionResults.DocumentsResults)
                {
                    if (documentResults.HasError)
                    {
                        ExceptionHandlerService.HandleException(
                            documentResults.Error.ErrorCode.ToString(),
                            documentResults.Error.Message);
                        
                        continue;
                    }

                    returnValue.Sentences = documentResults.Sentences.Select(p => p.Text).ToList();
                }
            }
        }

        return returnValue;
    }
}