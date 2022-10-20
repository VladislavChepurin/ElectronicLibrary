using ElectronicLibrary.Entity;
using Microsoft.EntityFrameworkCore;
using AppContext = ElectronicLibrary.Entity.AppContext;

namespace ElectronicLibrary.Repository
{
    public class UserRepository
    {
        /// <summary>
        /// Возврат пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public User? GetUserForId(int id)
        {
            using var db = new AppContext();
            return db.Users?.FirstOrDefault(user => user!.Id == id);
        }
        /// <summary>
        /// Возврат всех пользователей
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<User?> GetAllUsersList()
        {
            using var db = new AppContext();
            return db.Users!.ToList()!;
        }
        /// <summary>
        /// Добавление пользователя
        /// </summary>
        /// <param name="user"></param>
        public void AddSingleUser(User? user)
        {
            using var db = new AppContext();
            if (user != null) db.Users?.Add(user);
            db.SaveChanges();
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="user"></param>
        public void RemoveSingleUser(User? user)
        {
            using var db = new AppContext();
            if (user != null) db.Users?.Remove(user);
            db.SaveChanges();
        }
        /// <summary>
        /// Обновление имени пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        public void NameUpdateForId(int id, string newName)
        {
            using var db = new AppContext();
            var user = db.Users?.FirstOrDefault(user => user!.Id == id);
            if (user != null) user.Name = newName;
            if (user != null) db.Users?.Update(user);
            db.SaveChanges();
        }

        /// <summary>
        /// 5. Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool GetFlagsBookHandUsers(string book)
        {
            using var db = new AppContext();
            var variable = db.Users!.Include(u => u.Books);
            return Enumerable.Any(variable.SelectMany(varUser => varUser.Books), b => b.NameOfTheBook == book);
        }

        /// <summary>
        /// 6. Получать количество книг на руках у пользователя.
        /// </summary>
        /// <param name="nameUser"></param>
        /// <returns></returns>
        public int GetCountBookHandCurrentUsers(string nameUser)
        {
            using var db = new AppContext();
            var variable = db.Users!.Include(u => u.Books);
            return variable.Where(u => u.Name == nameUser).Select(g => g.Books.Count()).FirstOrDefault();
        }
    }
}
