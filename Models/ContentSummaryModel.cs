class ContentSummaryModel 
{
    public ContentSummaryModel()
    {
        Sentences = new List<string>();
    }
    public List<string>? Sentences { get; set; }

    public override string ToString()
    {
        return string.Join("\n", this.Sentences!);
    }
}