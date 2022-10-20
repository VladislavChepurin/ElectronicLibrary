using ElectronicLibrary.Entity;
using AppContext = ElectronicLibrary.Entity.AppContext;

namespace ElectronicLibrary.Repository;

public class BookRepository
{
    /// <summary>
    /// Возврат книги по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Book? GetBookForId(int id)
    {
        using var db = new AppContext();
        return db.Books?.FirstOrDefault(book => book!.Id == id);
    }

    /// <summary>
    /// Возврат всех книг
    /// </summary>
    /// <returns></returns>
    public List<Book?> GetAllBooksList()
    {
        using var db = new AppContext();
        return db.Books!.ToList()!;
    }

    /// <summary>
    /// Добавление книги
    /// </summary>
    /// <param name="book"></param>
    public void AddSingleBook(Book? book)
    {
        using var db = new AppContext();
        if (book != null) db.Books?.Add(book);
        db.SaveChanges();
    }

    /// <summary>
    /// Удаление книги
    /// </summary>
    /// <param name="book"></param>
    public void RemoveSingleBook(Book? book)
    {
        using var db = new AppContext();
        if (book != null) db.Books?.Remove(book);
        db.SaveChanges();
    }

    /// <summary>
    /// Обновление года выпуска книги по Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newYear"></param>
    public void NameUpdateForId(int id, int newYear)
    {
        using var db = new AppContext();
        var book = db.Books?.FirstOrDefault(book => book!.Id == id);
        if (book != null) book.YearOfRelease = newYear;
        if (book != null) db.Books?.Update(book);
        db.SaveChanges();
    }

    /// <summary>
    /// Добавление авторов
    /// </summary>
    /// <param name="author"></param>
    public void AddAuthor(Author author)
    {
        using var db = new AppContext();
        db.Authors?.Add(author);
        db.SaveChanges();
    }

    /// <summary>
    /// Добавление жанра
    /// </summary>
    /// <param name="genre"></param>
    public void AddGenre(Genre genre)
    {
        using var db = new AppContext();
        db.Genres?.Add(genre);
        db.SaveChanges();
    }

    /// <summary>
    /// 1. Получать список книг определенного жанра и вышедших между определенными годами.
    /// </summary>
    /// <param name="genre"></param>
    /// <param name="initialYear"></param>
    /// <param name="finalYear"></param>
    /// <returns></returns>
    public List<Book> GetListBooksGenreAndYearsRelease(string? genre, int initialYear = Int32.MinValue, int finalYear = Int32.MaxValue)
    {
        using var db = new AppContext();
        return db.Books!.Where(b => b.Genre!.GenreBook == genre && initialYear <= b.YearOfRelease && finalYear >= b.YearOfRelease).ToList();
    }

    /// <summary>
    /// 2. Получать количество книг определенного автора в библиотеке.
    /// </summary>
    /// <param name="nameAuthors"></param>
    /// <returns></returns>
    public int GetCountBooksAuthors(string nameAuthors)
    {
        using var db = new AppContext();
        return db.Books!.Count(b => b.Author!.NameAuthor== nameAuthors);
    }

    /// <summary>
    /// 3. Получение количества книг определенного жанра в библиотеке.
    /// </summary>
    /// <param name="genre"></param>
    /// <returns></returns>
    public int GetCountBooksGenre(string genre)
    {
        using var db = new AppContext();
        return db.Books!.Count(b => b.Genre!.GenreBook == genre);
    }

    /// <summary>
    /// 4. Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
    /// </summary>
    /// <param name="nameAuthor"></param>
    /// <param name="nameBook"></param>
    /// <returns></returns>
    public bool GetFlagsBooksAuthorAndNameBook(string nameAuthor, string nameBook)
    {
        using var db = new AppContext();
        return db.Books!.Any(b=> b.Author!.NameAuthor == nameAuthor && b.NameOfTheBook == nameBook);
    }

    /// <summary>
    /// 7. Получение последней вышедшей книги.
    /// </summary>
    /// <returns></returns>
    public Book GetLastPublishedBook()
    {
        using var db = new AppContext();
        return db.Books!.OrderByDescending(p=> p.YearOfRelease).FirstOrDefault()!;
    }

    /// <summary>
    /// 8. Получение списка всех книг, отсортированного в алфавитном порядке по названию.
    /// </summary>
    /// <returns></returns>
    public List<Book> GetListBookOrderName() //not test
    {
        using var db = new AppContext();
        return db.Books!.OrderBy(p => p.NameOfTheBook).ToList();
    }

    /// <summary>
    /// 9. Получение списка всех книг, отсортированного в порядке убывания года их выхода.
    /// </summary>
    /// <returns></returns>
    public List<Book> GetListBookOrderDeskYearRelease() //not test
    {
        using var db = new AppContext();
        return db.Books!.OrderByDescending(p => p.YearOfRelease).ToList();
    }
}