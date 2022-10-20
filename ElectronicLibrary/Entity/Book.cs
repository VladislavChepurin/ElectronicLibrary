namespace ElectronicLibrary.Entity;

public class Book
{
    public int Id { get; set; }
    public string? NameOfTheBook { get; set; }
    public int YearOfRelease { get; set; }

    // Внешний ключ
    public int? GenreId { get; set; }
    // Навигационное свойство
    public Genre? Genre { get; set; }

    // Внешний ключ
    public int? AuthorId { get; set; }
    // Навигационное свойство
    public Author? Author { get; set; }

    // Навигационное свойство
    public List<User>? Users { get; set; } = new();
}