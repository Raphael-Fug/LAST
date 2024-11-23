using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CB
{
    public class PhuCapController : Controller
    {
        private readonly HemisContext _context;

        public PhuCapController(HemisContext context)
        {
            _context = context;
        }

        // GET: PhuCap
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbPhuCaps.Include(t => t.IdBacLuongNavigation).Include(t => t.IdCanBoNavigation).Include(t => t.IdHeSoLuongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: PhuCap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhuCap = await _context.TbPhuCaps
                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation)
                .FirstOrDefaultAsync(m => m.IdPhuCap == id);
            if (tbPhuCap == null)
            {
                return NotFound();
            }

            return View(tbPhuCap);
        }

        // GET: PhuCap/Create
        public IActionResult Create()
        {
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong");
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong");
            return View();
        }

        // POST: PhuCap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPhuCap,IdCanBo,PhuCapThuHutNghe,PhuCapThamNien,PhuCapUuDaiNghe,PhuCapChucVu,PhuCapDocHai,PhuCapKhac,IdBacLuong,PhanTramVuotKhung,IdHeSoLuong,NgayThangNamHuongLuong")] TbPhuCap tbPhuCap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbPhuCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong", tbPhuCap.IdBacLuong);
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbPhuCap.IdCanBo);
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong", tbPhuCap.IdHeSoLuong);
            return View(tbPhuCap);
        }

        // GET: PhuCap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhuCap = await _context.TbPhuCaps.FindAsync(id);
            if (tbPhuCap == null)
            {
                return NotFound();
            }
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong", tbPhuCap.IdBacLuong);
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbPhuCap.IdCanBo);
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong", tbPhuCap.IdHeSoLuong);
            return View(tbPhuCap);
        }

        // POST: PhuCap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPhuCap,IdCanBo,PhuCapThuHutNghe,PhuCapThamNien,PhuCapUuDaiNghe,PhuCapChucVu,PhuCapDocHai,PhuCapKhac,IdBacLuong,PhanTramVuotKhung,IdHeSoLuong,NgayThangNamHuongLuong")] TbPhuCap tbPhuCap)
        {
            if (id != tbPhuCap.IdPhuCap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPhuCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPhuCapExists(tbPhuCap.IdPhuCap))
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
            ViewData["IdBacLuong"] = new SelectList(_context.DmBacLuongs1, "IdBacLuong", "IdBacLuong", tbPhuCap.IdBacLuong);
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbPhuCap.IdCanBo);
            ViewData["IdHeSoLuong"] = new SelectList(_context.DmHeSoLuongs, "IdHeSoLuong", "IdHeSoLuong", tbPhuCap.IdHeSoLuong);
            return View(tbPhuCap);
        }

        // GET: PhuCap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPhuCap = await _context.TbPhuCaps
                .Include(t => t.IdBacLuongNavigation)
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHeSoLuongNavigation)
                .FirstOrDefaultAsync(m => m.IdPhuCap == id);
            if (tbPhuCap == null)
            {
                return NotFound();
            }

            return View(tbPhuCap);
        }

        // POST: PhuCap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbPhuCap = await _context.TbPhuCaps.FindAsync(id);
            if (tbPhuCap != null)
            {
                _context.TbPhuCaps.Remove(tbPhuCap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPhuCapExists(int id)
        {
            return _context.TbPhuCaps.Any(e => e.IdPhuCap == id);
        }
    }
}
