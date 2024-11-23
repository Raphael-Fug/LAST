using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.KHCN
{
    public class DoiTuongThamGiumController : Controller
    {
        private readonly HemisContext _context;

        public DoiTuongThamGiumController(HemisContext context)
        {
            _context = context;
        }

        // GET: DoiTuongThamGium
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDoiTuongThamGia.Include(t => t.IdLoaiThamGiaNavigation).Include(t => t.IdNguoiNavigation).Include(t => t.IdPhanLoaiNavigation).Include(t => t.IdVaiTroNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DoiTuongThamGium/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia
                .Include(t => t.IdLoaiThamGiaNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdPhanLoaiNavigation)
                .Include(t => t.IdVaiTroNavigation)
                .FirstOrDefaultAsync(m => m.IdDoiTuongThamGia == id);
            if (tbDoiTuongThamGium == null)
            {
                return NotFound();
            }

            return View(tbDoiTuongThamGium);
        }

        // GET: DoiTuongThamGium/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "IdLoaiThamGia");
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi");
            ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "IdPhanLoaiDoiNguNguoiHoc");
            ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia");
            return View();
        }

        // POST: DoiTuongThamGium/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoiTuongThamGia,IdLoaiThamGia,MaLoaiThamGia,IdNguoi,IdVaiTro,IdPhanLoai")] TbDoiTuongThamGium tbDoiTuongThamGium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDoiTuongThamGium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "IdLoaiThamGia", tbDoiTuongThamGium.IdLoaiThamGia);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbDoiTuongThamGium.IdNguoi);
            ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "IdPhanLoaiDoiNguNguoiHoc", tbDoiTuongThamGium.IdPhanLoai);
            ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbDoiTuongThamGium.IdVaiTro);
            return View(tbDoiTuongThamGium);
        }

        // GET: DoiTuongThamGium/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia.FindAsync(id);
            if (tbDoiTuongThamGium == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "IdLoaiThamGia", tbDoiTuongThamGium.IdLoaiThamGia);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbDoiTuongThamGium.IdNguoi);
            ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "IdPhanLoaiDoiNguNguoiHoc", tbDoiTuongThamGium.IdPhanLoai);
            ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbDoiTuongThamGium.IdVaiTro);
            return View(tbDoiTuongThamGium);
        }

        // POST: DoiTuongThamGium/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoiTuongThamGia,IdLoaiThamGia,MaLoaiThamGia,IdNguoi,IdVaiTro,IdPhanLoai")] TbDoiTuongThamGium tbDoiTuongThamGium)
        {
            if (id != tbDoiTuongThamGium.IdDoiTuongThamGia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDoiTuongThamGium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDoiTuongThamGiumExists(tbDoiTuongThamGium.IdDoiTuongThamGia))
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
            ViewData["IdLoaiThamGia"] = new SelectList(_context.DmLoaiThamGia, "IdLoaiThamGia", "IdLoaiThamGia", tbDoiTuongThamGium.IdLoaiThamGia);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "IdNguoi", tbDoiTuongThamGium.IdNguoi);
            ViewData["IdPhanLoai"] = new SelectList(_context.DmPhanLoaiDoiNguNguoiHocs, "IdPhanLoaiDoiNguNguoiHoc", "IdPhanLoaiDoiNguNguoiHoc", tbDoiTuongThamGium.IdPhanLoai);
            ViewData["IdVaiTro"] = new SelectList(_context.DmVaiTroThamGia, "IdVaiTroThamGia", "IdVaiTroThamGia", tbDoiTuongThamGium.IdVaiTro);
            return View(tbDoiTuongThamGium);
        }

        // GET: DoiTuongThamGium/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia
                .Include(t => t.IdLoaiThamGiaNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdPhanLoaiNavigation)
                .Include(t => t.IdVaiTroNavigation)
                .FirstOrDefaultAsync(m => m.IdDoiTuongThamGia == id);
            if (tbDoiTuongThamGium == null)
            {
                return NotFound();
            }

            return View(tbDoiTuongThamGium);
        }

        // POST: DoiTuongThamGium/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDoiTuongThamGium = await _context.TbDoiTuongThamGia.FindAsync(id);
            if (tbDoiTuongThamGium != null)
            {
                _context.TbDoiTuongThamGia.Remove(tbDoiTuongThamGium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDoiTuongThamGiumExists(int id)
        {
            return _context.TbDoiTuongThamGia.Any(e => e.IdDoiTuongThamGia == id);
        }
    }
}
