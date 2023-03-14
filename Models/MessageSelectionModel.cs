class MessageSelectionModel
{
    public string? Id { get; set; }
    public string? Subject { get; set; }
    public string? Sender { get; set; }
    public DateTimeOffset SentDateTime { get; set; }
    public string? Importance { get; set; }

    public override string ToString()
    {
        return $"{this.Subject!} [[From: {this.Sender} on {this.SentDateTime.ToLocalTime()}]]";
    }
}