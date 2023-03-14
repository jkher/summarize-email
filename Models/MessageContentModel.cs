class MessageContentModel
{
    public string? Id { get; set; }

    public string? Content { get; set; }

    public string? Summary { get; set; } = string.Empty;

    public MessageSelectionModel? SelectedMessage { get; set; }
}