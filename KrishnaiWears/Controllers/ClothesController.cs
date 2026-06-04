using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KrishnaiWears.Shared;

namespace KrishnaiWears.Controllers
{
    public class ClothesController : Controller
    {
        private readonly KrishnaiWearsContext _context;

        public ClothesController(KrishnaiWearsContext context)
        {
            _context = context;
        }

        // GET: Clothes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cloth.ToListAsync());
        }

        // GET: Clothes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // GET: Clothes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PName,PDescription,PPrice,PCatagoryId,PQuantity")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cloth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cloth);
        }

        // GET: Clothes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth.FindAsync(id);
            if (cloth == null)
            {
                return NotFound();
            }
            return View(cloth);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PName,PDescription,PPrice,PCatagoryId,PQuantity")] Cloth cloth)
        {
            if (id != cloth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cloth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClothExists(cloth.Id))
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
            return View(cloth);
        }

        // GET: Clothes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cloth = await _context.Cloth
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cloth == null)
            {
                return NotFound();
            }

            return View(cloth);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cloth = await _context.Cloth.FindAsync(id);
            if (cloth != null)
            {
                _context.Cloth.Remove(cloth);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClothExists(int id)
        {
            return _context.Cloth.Any(e => e.Id == id);
        }
    }
}
