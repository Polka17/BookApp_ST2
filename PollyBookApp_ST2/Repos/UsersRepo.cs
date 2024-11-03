using PollyBookApp_ST2.Models;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Models.Users;
using System.Linq.Expressions;

namespace PollyBookApp_ST2.Repos
{
    public class UsersRepo
    {
        private readonly BookAppDbContext _context;

        public UsersRepo(BookAppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll() => _context.Set<User>().ToList();
        public User GetById(int id) => _context.Set<User>().Find(id);

        public void Add(User user) => _context.Add(user);

        public void Update(User user)
        {
            _context.Update(user);
        }
        
        public void Remove(int id)
        {
            var user = _context.Set<User>().Find(id);
            if (user != null) _context.Remove(user);
        }
        public void SaveChanges() => _context.SaveChanges();
    }
}
