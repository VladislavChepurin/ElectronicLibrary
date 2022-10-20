namespace ElectronicLibrary.Entity;

public class Author
{
    public int Id { get; set; }
    public string? NameAuthor { get; set; }
    // Навигационное свойство
    public List<Book> Books { get; set; } = new();
}