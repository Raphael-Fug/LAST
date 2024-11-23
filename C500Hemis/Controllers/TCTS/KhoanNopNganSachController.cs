using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TCTS
{
    public class KhoanNopNganSachController : Controller
    {
        private readonly HemisContext _context;

        public KhoanNopNganSachController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoanNopNganSach
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoanNopNganSaches.ToListAsync());
        }

        // GET: KhoanNopNganSach/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches
                .FirstOrDefaultAsync(m => m.IdKhoanNopNganSach == id);
            if (tbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            return View(tbKhoanNopNganSach);
        }

        // GET: KhoanNopNganSach/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoanNopNganSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoanNopNganSach,MaKhoanNop,TenKhoanNopNganSach,SoTien,NamTaiChinh")] TbKhoanNopNganSach tbKhoanNopNganSach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhoanNopNganSach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKhoanNopNganSach);
        }

        // GET: KhoanNopNganSach/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches.FindAsync(id);
            if (tbKhoanNopNganSach == null)
            {
                return NotFound();
            }
            return View(tbKhoanNopNganSach);
        }

        // POST: KhoanNopNganSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoanNopNganSach,MaKhoanNop,TenKhoanNopNganSach,SoTien,NamTaiChinh")] TbKhoanNopNganSach tbKhoanNopNganSach)
        {
            if (id != tbKhoanNopNganSach.IdKhoanNopNganSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoanNopNganSach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoanNopNganSachExists(tbKhoanNopNganSach.IdKhoanNopNganSach))
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
            return View(tbKhoanNopNganSach);
        }

        // GET: KhoanNopNganSach/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches
                .FirstOrDefaultAsync(m => m.IdKhoanNopNganSach == id);
            if (tbKhoanNopNganSach == null)
            {
                return NotFound();
            }

            return View(tbKhoanNopNganSach);
        }

        // POST: KhoanNopNganSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoanNopNganSach = await _context.TbKhoanNopNganSaches.FindAsync(id);
            if (tbKhoanNopNganSach != null)
            {
                _context.TbKhoanNopNganSaches.Remove(tbKhoanNopNganSach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoanNopNganSachExists(int id)
        {
            return _context.TbKhoanNopNganSaches.Any(e => e.IdKhoanNopNganSach == id);
        }
    }
}
