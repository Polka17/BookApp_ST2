using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PollyBookApp_ST2.Models;
using PollyBookApp_ST2.Models.Enums;
using PollyBookApp_ST2.Models.ReadingItems;
using PollyBookApp_ST2.Repos;
using System.Drawing;

namespace PollyBookApp_ST2.Controllers
{
    public class ReadingItemsController : Controller
    {
        private readonly BookAppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ReadingItemsController(BookAppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(string itemType)
        {
            var items = string.IsNullOrEmpty(itemType)
             ? await _context.ReadingItems.ToListAsync()
             : _context.ReadingItems.AsEnumerable().Where(a => a.GetType().Name == itemType).ToList();

            ViewBag.ItemType = itemType;
            return View(items);
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


        public IActionResult Create()
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

        // POST: Albums/Delete/5
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
