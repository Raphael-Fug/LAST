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
    public class LoaiThuChiController : Controller
    {
        private readonly HemisContext _context;

        public LoaiThuChiController(HemisContext context)
        {
            _context = context;
        }

        // GET: LoaiThuChi
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbLoaiThuChis.Include(t => t.IdPhanLoaiThuChiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: LoaiThuChi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiThuChi = await _context.TbLoaiThuChis
                .Include(t => t.IdPhanLoaiThuChiNavigation)
                .FirstOrDefaultAsync(m => m.IdLoaiThuChi == id);
            if (tbLoaiThuChi == null)
            {
                return NotFound();
            }

            return View(tbLoaiThuChi);
        }

        // GET: LoaiThuChi/Create
        public IActionResult Create()
        {
            ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "IdPhanLoaiThuChi");
            return View();
        }

        // POST: LoaiThuChi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLoaiThuChi,MaLoaiThuChi,IdPhanLoaiThuChi,TenLoaiThuChi,MoTa")] TbLoaiThuChi tbLoaiThuChi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLoaiThuChi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "IdPhanLoaiThuChi", tbLoaiThuChi.IdPhanLoaiThuChi);
            return View(tbLoaiThuChi);
        }

        // GET: LoaiThuChi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiThuChi = await _context.TbLoaiThuChis.FindAsync(id);
            if (tbLoaiThuChi == null)
            {
                return NotFound();
            }
            ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "IdPhanLoaiThuChi", tbLoaiThuChi.IdPhanLoaiThuChi);
            return View(tbLoaiThuChi);
        }

        // POST: LoaiThuChi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLoaiThuChi,MaLoaiThuChi,IdPhanLoaiThuChi,TenLoaiThuChi,MoTa")] TbLoaiThuChi tbLoaiThuChi)
        {
            if (id != tbLoaiThuChi.IdLoaiThuChi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLoaiThuChi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLoaiThuChiExists(tbLoaiThuChi.IdLoaiThuChi))
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
            ViewData["IdPhanLoaiThuChi"] = new SelectList(_context.DmPhanLoaiThuChis, "IdPhanLoaiThuChi", "IdPhanLoaiThuChi", tbLoaiThuChi.IdPhanLoaiThuChi);
            return View(tbLoaiThuChi);
        }

        // GET: LoaiThuChi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLoaiThuChi = await _context.TbLoaiThuChis
                .Include(t => t.IdPhanLoaiThuChiNavigation)
                .FirstOrDefaultAsync(m => m.IdLoaiThuChi == id);
            if (tbLoaiThuChi == null)
            {
                return NotFound();
            }

            return View(tbLoaiThuChi);
        }

        // POST: LoaiThuChi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLoaiThuChi = await _context.TbLoaiThuChis.FindAsync(id);
            if (tbLoaiThuChi != null)
            {
                _context.TbLoaiThuChis.Remove(tbLoaiThuChi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLoaiThuChiExists(int id)
        {
            return _context.TbLoaiThuChis.Any(e => e.IdLoaiThuChi == id);
        }
    }
}
