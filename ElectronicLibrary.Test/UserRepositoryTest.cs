using ElectronicLibrary.Repository;

namespace ElectronicLibrary.test
{
    public class UserRepositoryTest
    {
        [Test]
        public void GetFlagsBookHandUsersMustReturnCorrectValue()
        {
            var repository = new UserRepository();
            Assert.IsTrue(repository.GetFlagsBookHandUsers("Катализ"));
            Assert.IsTrue(repository.GetFlagsBookHandUsers("Золотой теленок"));
            Assert.IsFalse(repository.GetFlagsBookHandUsers("Белый клык"));
        }

        [Test]
        public void GetCountBookHandCurrentUsersMustReturnCorrectValue()
        {
            var repository = new UserRepository();
            Assert.IsTrue(repository.GetCountBookHandCurrentUsers("Петр Иванов") == 3);
            Assert.IsTrue(repository.GetCountBookHandCurrentUsers("Ира Печенкина") == 2);
            Assert.IsFalse(repository.GetCountBookHandCurrentUsers("Иван Попов") == 1);
        }
    }
}
