using ElectronicLibrary.Repository;

namespace ElectronicLibrary.test
{
    public class BookRepositoryTest
    {
        [Test]
        public void GetListBooksGenreAndYearsReleaseMustReturnCorrectValue()
        {
            var repository = new BookRepository();
            var listBook = repository.GetListBooksGenreAndYearsRelease("Путевой очерк");
            foreach (var varBook in listBook)
            {
                Assert.IsTrue(varBook.NameOfTheBook == "Одноэтажная Америка");
                Assert.IsTrue(varBook.YearOfRelease == 1937);
            }
        }

        [Test]
        public void GetListBooksGenreAndYearsReleaseMustContainCorrectCount()
        {
            var repository = new BookRepository();
            var listBook = repository.GetListBooksGenreAndYearsRelease("Роман", 1900, 1915);
            Assert.IsTrue(listBook.Count == 2);
        }

        [Test]
        public void GetCountBooksAuthorsMustContainCorrectCount()
        {
            var repositoryBook = new BookRepository();
            Assert.IsTrue(repositoryBook.GetCountBooksAuthors("Илья Ильф и Евгений Петров") == 2);
            Assert.IsTrue(repositoryBook.GetCountBooksAuthors("Ант Скандалис") == 1);
        }
        [Test]
        public void GetCountBooksGenreMustContainCorrectCount()
        {
            var repository = new BookRepository();
            Assert.IsTrue(repository.GetCountBooksGenre("Роман") == 3);
            Assert.IsTrue(repository.GetCountBooksGenre("Путевой очерк") == 1);
        }

        [Test]
        public void GetFlagsBooksAuthorAndNameBookMustReturnCorrectValue()
        {
            var repository = new BookRepository();
            Assert.IsTrue(repository.GetFlagsBooksAuthorAndNameBook("Ант Скандалис", "Катализ"));
            Assert.IsFalse(repository.GetFlagsBooksAuthorAndNameBook("Лев Толстой", "Война и мир"));
            Assert.IsFalse(repository.GetFlagsBooksAuthorAndNameBook("Джек Лондон", "Золотой теленок"));
        }

       
        [Test]
        public void GetLastPublishedBookMustReturnCorrectValue()
        {
            var repository = new BookRepository();
            var listBook = repository.GetLastPublishedBook();
            Assert.IsTrue(listBook.NameOfTheBook == "Катализ");
            Assert.IsTrue(listBook.YearOfRelease == 1996);
        }





    }
}
