using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSGD
{
    public class KhoaHocController : Controller
    {
        private readonly HemisContext _context;

        public KhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoaHoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoaHocs.ToListAsync());
        }

        // GET: KhoaHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoaHoc = await _context.TbKhoaHocs
                .FirstOrDefaultAsync(m => m.IdKhoaHoc == id);
            if (tbKhoaHoc == null)
            {
                return NotFound();
            }

            return View(tbKhoaHoc);
        }

        // GET: KhoaHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoaHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoaHoc,TuNam,DenNam")] TbKhoaHoc tbKhoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKhoaHoc);
        }

        // GET: KhoaHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoaHoc = await _context.TbKhoaHocs.FindAsync(id);
            if (tbKhoaHoc == null)
            {
                return NotFound();
            }
            return View(tbKhoaHoc);
        }

        // POST: KhoaHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoaHoc,TuNam,DenNam")] TbKhoaHoc tbKhoaHoc)
        {
            if (id != tbKhoaHoc.IdKhoaHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoaHocExists(tbKhoaHoc.IdKhoaHoc))
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
            return View(tbKhoaHoc);
        }

        // GET: KhoaHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoaHoc = await _context.TbKhoaHocs
                .FirstOrDefaultAsync(m => m.IdKhoaHoc == id);
            if (tbKhoaHoc == null)
            {
                return NotFound();
            }

            return View(tbKhoaHoc);
        }

        // POST: KhoaHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoaHoc = await _context.TbKhoaHocs.FindAsync(id);
            if (tbKhoaHoc != null)
            {
                _context.TbKhoaHocs.Remove(tbKhoaHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoaHocExists(int id)
        {
            return _context.TbKhoaHocs.Any(e => e.IdKhoaHoc == id);
        }
    }
}
