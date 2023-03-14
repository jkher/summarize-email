internal class PostActionsModel
{
    public int Id { get; set; }
    public string? Action { get; set; }

    public override string ToString()
    {
        return this.Action!;
    }
}

