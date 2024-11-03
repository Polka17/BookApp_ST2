using Microsoft.AspNetCore.Mvc;
using PollyBookApp_ST2.Models.Enums;
using PollyBookApp_ST2.Models.Users;
using PollyBookApp_ST2.Repos;

namespace PollyBookApp_ST2.Controllers
{
    public class UsersController : Controller
    {
        // Instance UserRepo in order to use its methods for the CRUD operations.
        // I will not go into details about the different Actions. We night do that at Lab.
        //But you can see that in comparison to the other Controller this is much simplified :)
        private readonly UsersRepo _usersRepo;

        public UsersController(UsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }
        public IActionResult Index(User model)
        {
            var users = _usersRepo.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.UserType = Enum.GetValues(typeof(UserType)).Cast<UserType>();
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _usersRepo.Add(user);
                _usersRepo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.UserType = Enum.GetValues(typeof(UserType)).Cast<UserType>();
            var user = _usersRepo.GetById(id);
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                ViewBag.UserType = Enum.GetValues(typeof(UserType)).Cast<UserType>();
                _usersRepo.Update(user);
                _usersRepo.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult DeleteConfirmed(int id)
        {
            _usersRepo.Remove(id);
            _usersRepo.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
