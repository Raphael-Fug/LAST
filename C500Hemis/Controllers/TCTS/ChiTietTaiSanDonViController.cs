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
    public class ChiTietTaiSanDonViController : Controller
    {
        private readonly HemisContext _context;

        public ChiTietTaiSanDonViController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChiTietTaiSanDonVi
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbChiTietTaiSanDonVis.Include(t => t.IdChuSoHuuNavigation).Include(t => t.IdTaiSanDonViNavigation).Include(t => t.IdTinhTrangThietBiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ChiTietTaiSanDonVi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis
                .Include(t => t.IdChuSoHuuNavigation)
                .Include(t => t.IdTaiSanDonViNavigation)
                .Include(t => t.IdTinhTrangThietBiNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTietTaiSanDonVi == id);
            if (tbChiTietTaiSanDonVi == null)
            {
                return NotFound();
            }

            return View(tbChiTietTaiSanDonVi);
        }

        // GET: ChiTietTaiSanDonVi/Create
        public IActionResult Create()
        {
            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "IdChuSoHuu");
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi");
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "IdTinhTrangThietBi");
            return View();
        }

        // POST: ChiTietTaiSanDonVi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiTietTaiSanDonVi,IdTaiSanDonVi,MaTaiSan,TenTaiSan,NguyenGia,IdTinhTrangThietBi,IdChuSoHuu")] TbChiTietTaiSanDonVi tbChiTietTaiSanDonVi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChiTietTaiSanDonVi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "IdChuSoHuu", tbChiTietTaiSanDonVi.IdChuSoHuu);
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi", tbChiTietTaiSanDonVi.IdTaiSanDonVi);
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "IdTinhTrangThietBi", tbChiTietTaiSanDonVi.IdTinhTrangThietBi);
            return View(tbChiTietTaiSanDonVi);
        }

        // GET: ChiTietTaiSanDonVi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis.FindAsync(id);
            if (tbChiTietTaiSanDonVi == null)
            {
                return NotFound();
            }
            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "IdChuSoHuu", tbChiTietTaiSanDonVi.IdChuSoHuu);
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi", tbChiTietTaiSanDonVi.IdTaiSanDonVi);
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "IdTinhTrangThietBi", tbChiTietTaiSanDonVi.IdTinhTrangThietBi);
            return View(tbChiTietTaiSanDonVi);
        }

        // POST: ChiTietTaiSanDonVi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiTietTaiSanDonVi,IdTaiSanDonVi,MaTaiSan,TenTaiSan,NguyenGia,IdTinhTrangThietBi,IdChuSoHuu")] TbChiTietTaiSanDonVi tbChiTietTaiSanDonVi)
        {
            if (id != tbChiTietTaiSanDonVi.IdChiTietTaiSanDonVi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChiTietTaiSanDonVi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChiTietTaiSanDonViExists(tbChiTietTaiSanDonVi.IdChiTietTaiSanDonVi))
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
            ViewData["IdChuSoHuu"] = new SelectList(_context.DmChuSoHuus, "IdChuSoHuu", "IdChuSoHuu", tbChiTietTaiSanDonVi.IdChuSoHuu);
            ViewData["IdTaiSanDonVi"] = new SelectList(_context.TbTaiSanDonVis, "IdTaiSanDonVi", "IdTaiSanDonVi", tbChiTietTaiSanDonVi.IdTaiSanDonVi);
            ViewData["IdTinhTrangThietBi"] = new SelectList(_context.DmTinhTrangThietBis, "IdTinhTrangThietBi", "IdTinhTrangThietBi", tbChiTietTaiSanDonVi.IdTinhTrangThietBi);
            return View(tbChiTietTaiSanDonVi);
        }

        // GET: ChiTietTaiSanDonVi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis
                .Include(t => t.IdChuSoHuuNavigation)
                .Include(t => t.IdTaiSanDonViNavigation)
                .Include(t => t.IdTinhTrangThietBiNavigation)
                .FirstOrDefaultAsync(m => m.IdChiTietTaiSanDonVi == id);
            if (tbChiTietTaiSanDonVi == null)
            {
                return NotFound();
            }

            return View(tbChiTietTaiSanDonVi);
        }

        // POST: ChiTietTaiSanDonVi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChiTietTaiSanDonVi = await _context.TbChiTietTaiSanDonVis.FindAsync(id);
            if (tbChiTietTaiSanDonVi != null)
            {
                _context.TbChiTietTaiSanDonVis.Remove(tbChiTietTaiSanDonVi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChiTietTaiSanDonViExists(int id)
        {
            return _context.TbChiTietTaiSanDonVis.Any(e => e.IdChiTietTaiSanDonVi == id);
        }
    }
}
