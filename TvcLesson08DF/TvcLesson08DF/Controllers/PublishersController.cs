using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TvcLesson08DF.Models;

namespace TvcLesson08DF.Controllers
{
    public class PublishersController : Controller
    {
        private readonly BookStoreDbContext _context;

        public PublishersController(BookStoreDbContext context)
        {
            _context = context;
        }

        // GET: Publishers
        public async Task<IActionResult> Index(string? searchString)
        {
            var query = _context.Publishers.Include(p => p.Books).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => (p.PublisherName != null && p.PublisherName.Contains(searchString)) ||
                                         (p.Phone != null && p.Phone.Contains(searchString)) ||
                                         (p.Address != null && p.Address.Contains(searchString)));
                ViewBag.SearchString = searchString;
            }

            return View(await query.ToListAsync());
        }

        // GET: Publishers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefaultAsync(m => m.PublisherId == id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm mới nhà xuất bản thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (id != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật thông tin nhà xuất bản thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefaultAsync(m => m.PublisherId == id);

            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisher = await _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefaultAsync(m => m.PublisherId == id);

            if (publisher != null)
            {
                if (publisher.Books.Any())
                {
                    TempData["ErrorMessage"] = $"Không thể xóa nhà xuất bản '{publisher.PublisherName}' vì đang có {publisher.Books.Count} cuốn sách thuộc nhà xuất bản này!";
                    return RedirectToAction(nameof(Index));
                }

                _context.Publishers.Remove(publisher);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa nhà xuất bản thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PublisherExists(int id)
        {
            return _context.Publishers.Any(e => e.PublisherId == id);
        }
    }
}
