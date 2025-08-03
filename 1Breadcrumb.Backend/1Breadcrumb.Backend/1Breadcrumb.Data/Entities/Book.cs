namespace _1Breadcrumb.Data.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public DateTimeOffset PublishedDate { get; set; }
    public bool IsAvailable { get; set; }
    public string Owner { get; set; }
}