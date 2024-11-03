using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PollyBookApp_ST2.Models;
using PollyBookApp_ST2.Models.Enums;
using PollyBookApp_ST2.Models.Observer;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Models.Strategy;
using PollyBookApp_ST2.Repos;
using System.Drawing;

namespace PollyBookApp_ST2.Controllers
{
    public class ReadingItemsController : Controller
    {
        private readonly BookAppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ReadingItemNotifier _notificationManager;
        private readonly SearchContext _searchContext;

        public ReadingItemsController(BookAppDbContext context, IWebHostEnvironment hostEnvironment, ReadingItemNotifier notificationManager, SearchContext searchContext)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            _notificationManager = notificationManager;
            _searchContext = searchContext;

            var consoleObserver = new ConsoleNotificationObserver();
            _notificationManager.Attach(consoleObserver);
        }

        public async Task<IActionResult> Index(string itemType)
        {
            var items = string.IsNullOrEmpty(itemType)
             ? await _context.ReadingItems.ToListAsync()
             : _context.ReadingItems.AsEnumerable().Where(a => a.GetType().Name == itemType).ToList();

            ViewBag.NotificationMessage = TempData["UserNotifications"] as string;
            ViewBag.ItemType = itemType;
            return View(items);
        }

        public async Task<IActionResult> Search(string query, string strategyType, decimal? minPrice = null, decimal? maxPrice = null)
        {
            var items =  await _context.ReadingItems.ToListAsync();

            if (strategyType == "Title")
            {
                _searchContext.SetSearchStrategy(new TitleSearchStrategy());
            }
            else if (strategyType == "PriceRange" && minPrice.HasValue && maxPrice.HasValue)
            {
                _searchContext.SetSearchStrategy(new PriceRangeSearchStrategy(minPrice.Value, maxPrice.Value));
            }
            else
            {
                return BadRequest("Invalid search strategy type or type mismatch.");
            }

            var searchResults = _searchContext.ExecuteSearch(items, query);

            return View(searchResults);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _context.ReadingItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Domain = Enum.GetValues(typeof(Domain)).Cast<Domain>();
            ViewBag.Edition = Enum.GetValues(typeof(Edition)).Cast<Edition>();
            ViewBag.Genre = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            ViewBag.Style = Enum.GetValues(typeof(Style)).Cast<Style>();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string itemType, string title, decimal price, string description, 
            IFormFile pictureFile, string author, string isbn, string publisher, Genre genre, Style style, Edition edition, 
            Domain domain)
        {
            var item = ReadingItemFactory.CreateReadingMaterial(itemType);
            item.Title = title;
            item.Price = price;
            item.Description = description;
         
            if (item is Book book)
            {
                book.Author = author;
                book.ISBN = isbn;
                book.Genre = genre;
            }
            else if (item is Magazine mag)
            {
                mag.Publisher = publisher;
                mag.Domain = domain;
            }
            else if (item is Comics com)
            {
                com.Style = style;
                com.Edition = edition;
            }


            if (pictureFile != null && pictureFile.Length > 0)
            {
                var fileName = Path.GetFileName(pictureFile.FileName);
                var path = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await pictureFile.CopyToAsync(stream);
                }
                item.PicturePath = "/images/" + fileName;
            }

            

            _context.ReadingItems.Add(item);
            await _context.SaveChangesAsync();

            string message = $"New {item.GetType().Name} added: \'{item.Title}\'";
            _notificationManager.Notify(message);

            TempData["UserNotifications"] = message;

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Domain = Enum.GetValues(typeof(Domain)).Cast<Domain>();
            ViewBag.Edition = Enum.GetValues(typeof(Edition)).Cast<Edition>();
            ViewBag.Genre = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            ViewBag.Style = Enum.GetValues(typeof(Style)).Cast<Style>();

            var item = await _context.ReadingItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string itemType, string title, decimal price, string description,
            IFormFile pictureFile, string author, string isbn, string publisher, Genre? genre, Style? style, Edition? edition,
            Domain? domain)
        {
            var item = await _context.ReadingItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Title = title;
            item.Price = price;
            item.Description = description;

            if (item is Book book)
            {
                book.Author = author;
                book.ISBN = isbn;
                book.Genre = genre ?? book.Genre;
            }
            else if (item is Magazine mag)
            {
                mag.Publisher = publisher;
                mag.Domain = domain ?? mag.Domain;
            }
            else if (item is Comics com)
            {
                com.Style = style ?? com.Style;
                com.Edition = edition ?? com.Edition;
            }

            if (pictureFile != null && pictureFile.Length > 0)
            {
                var fileName = Path.GetFileName(pictureFile.FileName);
                var path = Path.Combine(_hostEnvironment.WebRootPath, "images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await pictureFile.CopyToAsync(stream);
                }
                item.PicturePath = "/images/" + fileName;
            }

            ViewBag.Domain = Enum.GetValues(typeof(Domain)).Cast<Domain>();
            ViewBag.Edition = Enum.GetValues(typeof(Edition)).Cast<Edition>();
            ViewBag.Genre = Enum.GetValues(typeof(Genre)).Cast<Genre>();
            ViewBag.Style = Enum.GetValues(typeof(Style)).Cast<Style>();

            _context.Update(item);
            await _context.SaveChangesAsync();

            string message = $"The \'{item.Title}\' {item.GetType().Name} was updated!";
            _notificationManager.Notify(message);

            TempData["UserNotifications"] = message;

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.ReadingItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.ReadingItems.FindAsync(id);
            if (item != null)
            {
                _context.ReadingItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
