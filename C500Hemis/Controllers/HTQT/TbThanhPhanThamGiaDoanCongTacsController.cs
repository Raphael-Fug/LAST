using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.HTQT
{
    public class TbThanhPhanThamGiaDoanCongTacsController : Controller
    {
        private readonly HemisContext _context;

        public TbThanhPhanThamGiaDoanCongTacsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThanhPhanThamGiaDoanCongTacs.Include(t => t.IdCanBoNavigation).Include(t => t.IdDoanCongTacNavigation).Include(t => t.IdVaiTroThamGiaNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdDoanCongTacNavigation)
                .Include(t => t.IdVaiTroThamGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdThanhPhanThamGiaDoanCongTac == id);
            if (tbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }

            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "IdDoanCongTac");
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia");
            return View();
        }

        // POST: TbThanhPhanThamGiaDoanCongTacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThanhPhanThamGiaDoanCongTac,IdDoanCongTac,IdCanBo,IdVaiTroThamGia")] TbThanhPhanThamGiaDoanCongTac tbThanhPhanThamGiaDoanCongTac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThanhPhanThamGiaDoanCongTac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThanhPhanThamGiaDoanCongTac.IdCanBo);
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "IdDoanCongTac", tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac);
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia);
            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs.FindAsync(id);
            if (tbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThanhPhanThamGiaDoanCongTac.IdCanBo);
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "IdDoanCongTac", tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac);
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia);
            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // POST: TbThanhPhanThamGiaDoanCongTacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThanhPhanThamGiaDoanCongTac,IdDoanCongTac,IdCanBo,IdVaiTroThamGia")] TbThanhPhanThamGiaDoanCongTac tbThanhPhanThamGiaDoanCongTac)
        {
            if (id != tbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThanhPhanThamGiaDoanCongTac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThanhPhanThamGiaDoanCongTacExists(tbThanhPhanThamGiaDoanCongTac.IdThanhPhanThamGiaDoanCongTac))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbThanhPhanThamGiaDoanCongTac.IdCanBo);
            ViewData["IdDoanCongTac"] = new SelectList(_context.TbDoanCongTacs, "IdDoanCongTac", "IdDoanCongTac", tbThanhPhanThamGiaDoanCongTac.IdDoanCongTac);
            ViewData["IdVaiTroThamGia"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbThanhPhanThamGiaDoanCongTac.IdVaiTroThamGia);
            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // GET: TbThanhPhanThamGiaDoanCongTacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdDoanCongTacNavigation)
                .Include(t => t.IdVaiTroThamGiaNavigation)
                .FirstOrDefaultAsync(m => m.IdThanhPhanThamGiaDoanCongTac == id);
            if (tbThanhPhanThamGiaDoanCongTac == null)
            {
                return NotFound();
            }

            return View(tbThanhPhanThamGiaDoanCongTac);
        }

        // POST: TbThanhPhanThamGiaDoanCongTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThanhPhanThamGiaDoanCongTac = await _context.TbThanhPhanThamGiaDoanCongTacs.FindAsync(id);
            if (tbThanhPhanThamGiaDoanCongTac != null)
            {
                _context.TbThanhPhanThamGiaDoanCongTacs.Remove(tbThanhPhanThamGiaDoanCongTac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThanhPhanThamGiaDoanCongTacExists(int id)
        {
            return _context.TbThanhPhanThamGiaDoanCongTacs.Any(e => e.IdThanhPhanThamGiaDoanCongTac == id);
        }
    }
}
