using PollyBookApp_ST2.Models;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Models.Users;
using System.Linq.Expressions;

namespace PollyBookApp_ST2.Repos
{
    // Here we come with the Repository pattern. We have not gone into detail with it, but I just decided to add it for "spice" jk, jk.
    // Because I used the Factory pattern for the main object in my project I wanted to show that the repository pattern will actually reallt simplify
    //  and group the functionality in one place. 
    // It provides flexibilty and consistency, since the changes can be made in only place.
    // And of course. reduces the need for thorough code.

    //For the implementation see the UsersController
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
