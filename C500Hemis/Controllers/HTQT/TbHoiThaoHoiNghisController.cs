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
    public class TbHoiThaoHoiNghisController : Controller
    {
        private readonly HemisContext _context;

        public TbHoiThaoHoiNghisController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbHoiThaoHoiNghis
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHoiThaoHoiNghis.Include(t => t.IdNguonKinhPhiHoiThaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbHoiThaoHoiNghis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis
                .Include(t => t.IdNguonKinhPhiHoiThaoNavigation)
                .FirstOrDefaultAsync(m => m.IdHoiThaoHoiNghi == id);
            if (tbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            return View(tbHoiThaoHoiNghi);
        }

        // GET: TbHoiThaoHoiNghis/Create
        public IActionResult Create()
        {
            ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi");
            return View();
        }

        // POST: TbHoiThaoHoiNghis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoiThaoHoiNghi,MaHoiThaoHoiNghi,TenHoiThaoHoiNghi,CoQuanCoThamQuyenCapPhep,MucTieu,NoiDung,SoLuongDaiBieuThamDu,SoLuongDaiBieuQuocTeThamDu,ThoiGianToChuc,DiaDiemToChuc,IdNguonKinhPhiHoiThao,DonViChuTri")] TbHoiThaoHoiNghi tbHoiThaoHoiNghi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbHoiThaoHoiNghi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoiThaoHoiNghi.IdNguonKinhPhiHoiThao);
            return View(tbHoiThaoHoiNghi);
        }

        // GET: TbHoiThaoHoiNghis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis.FindAsync(id);
            if (tbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }
            ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoiThaoHoiNghi.IdNguonKinhPhiHoiThao);
            return View(tbHoiThaoHoiNghi);
        }

        // POST: TbHoiThaoHoiNghis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoiThaoHoiNghi,MaHoiThaoHoiNghi,TenHoiThaoHoiNghi,CoQuanCoThamQuyenCapPhep,MucTieu,NoiDung,SoLuongDaiBieuThamDu,SoLuongDaiBieuQuocTeThamDu,ThoiGianToChuc,DiaDiemToChuc,IdNguonKinhPhiHoiThao,DonViChuTri")] TbHoiThaoHoiNghi tbHoiThaoHoiNghi)
        {
            if (id != tbHoiThaoHoiNghi.IdHoiThaoHoiNghi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHoiThaoHoiNghi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHoiThaoHoiNghiExists(tbHoiThaoHoiNghi.IdHoiThaoHoiNghi))
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
            ViewData["IdNguonKinhPhiHoiThao"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoiThaoHoiNghi.IdNguonKinhPhiHoiThao);
            return View(tbHoiThaoHoiNghi);
        }

        // GET: TbHoiThaoHoiNghis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis
                .Include(t => t.IdNguonKinhPhiHoiThaoNavigation)
                .FirstOrDefaultAsync(m => m.IdHoiThaoHoiNghi == id);
            if (tbHoiThaoHoiNghi == null)
            {
                return NotFound();
            }

            return View(tbHoiThaoHoiNghi);
        }

        // POST: TbHoiThaoHoiNghis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHoiThaoHoiNghi = await _context.TbHoiThaoHoiNghis.FindAsync(id);
            if (tbHoiThaoHoiNghi != null)
            {
                _context.TbHoiThaoHoiNghis.Remove(tbHoiThaoHoiNghi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHoiThaoHoiNghiExists(int id)
        {
            return _context.TbHoiThaoHoiNghis.Any(e => e.IdHoiThaoHoiNghi == id);
        }
    }
}
