namespace ElectronicLibrary.Entity;

public class Genre
{
    public int Id { get; set; }
    public string? GenreBook { get; set; }
    // Навигационное свойство
    public List<Book>? Books { get; set; } = new();
}