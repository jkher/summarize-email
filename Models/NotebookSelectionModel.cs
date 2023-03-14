class NotebookSelectionModel
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    
    public override string ToString()
    {
        return this.Name!;
    }
}