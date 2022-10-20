using ElectronicLibrary.Entity;
using ElectronicLibrary.Repository;
using AppContext = ElectronicLibrary.Entity.AppContext;

using (AppContext db = new AppContext())
{
    // Пересоздаем базу
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}
var repositoryUser = new UserRepository();
var repositoryBook = new BookRepository();
//Создаем пользователей
var user1 = new User() { Name = "Иван Попов", Email = "ivan@gmail.com" };
var user2 = new User() { Name = "Петр Иванов", Email = "petro@gmail.com" };
var user3 = new User() { Name = "Ира Печенкина", Email = "ira@gmail.com" };
repositoryUser.AddSingleUser(user1);
repositoryUser.AddSingleUser(user2);
repositoryUser.AddSingleUser(user3);
//Создаем книги
var book1 = new Book { NameOfTheBook = "Мартин Иден", YearOfRelease = 1909 };
var book2 = new Book { NameOfTheBook = "Одноэтажная Америка", YearOfRelease = 1937 };
var book3 = new Book { NameOfTheBook = "Катализ", YearOfRelease = 1996 };
var book4 = new Book { NameOfTheBook = "Золотой теленок", YearOfRelease = 1933 };
var book5 = new Book { NameOfTheBook = "Белый клык", YearOfRelease = 1906 };
repositoryBook.AddSingleBook(book1);
repositoryBook.AddSingleBook(book2);
repositoryBook.AddSingleBook(book3);
repositoryBook.AddSingleBook(book4);
//Создаем жанры
var genre1 = new Genre { GenreBook = "Роман" };
var genre2 = new Genre { GenreBook = "Путевой очерк" };
var genre3 = new Genre { GenreBook = "Фантастика" };
repositoryBook.AddGenre(genre1);
repositoryBook.AddGenre(genre2);
repositoryBook.AddGenre(genre3);
//Создаем авторов
var author1 = new Author { NameAuthor = "Джек Лондон" };
var author2 = new Author { NameAuthor = "Илья Ильф и Евгений Петров" };
var author3 = new Author { NameAuthor = "Ант Скандалис" };
repositoryBook.AddAuthor(author1);
repositoryBook.AddAuthor(author2);
repositoryBook.AddAuthor(author3);
//Соотносим кониги с авторами и жанрами - связь один ко многим.
//У оного жанра и автора может быть несколько книг
using (AppContext db = new AppContext())
{
    book1.Author = author1;
    book1.Genre = genre1;
    book2.Author = author2;
    book2.Genre = genre2;
    book3.Author = author3;
    book3.Genre = genre3;
    book4.Author = author2;
    book4.Genre = genre1;
    book5.Author = author1;
    book5.Genre = genre1;

    db.Books?.UpdateRange(book1, book2, book3, book4, book5);
    db.SaveChanges();
}
//Выдаем книги пользователям - связь многие ко мнгогим
using (AppContext db = new AppContext())
{
    user1.Books.AddRange(new[] { book3, book1 });
    user2.Books.AddRange(new[] { book2, book4, book1 });
    user3.Books.AddRange(new[] { book1, book2 });
    db.Users?.UpdateRange(user1, user2, user3);
    db.SaveChanges();
}