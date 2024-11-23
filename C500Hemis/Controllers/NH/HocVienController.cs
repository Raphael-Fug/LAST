using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.NH
{
    public class HocVienController : Controller
    {
        private readonly HemisContext _context;

        public HocVienController(HemisContext context)
        {
            _context = context;
        }

        // GET: HocVien
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHocViens
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdLoaiKhuyetTatNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdXaNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: HocVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHocVien = await _context.TbHocViens
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdLoaiKhuyetTatNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdXaNavigation)
                .FirstOrDefaultAsync(m => m.IdHocVien == id);
            if (tbHocVien == null)
            {
                return NotFound();
            }

            return View(tbHocVien);
        }

        // GET: HocVien/Create
        public IActionResult Create()
        {
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen");
            ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat");
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name");
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh");
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa");
            return View();
        }

        // POST: HocVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHocVien,MaHocVien,IdNguoi,Email,Sdt,SoSoBaoHiem,IdLoaiKhuyetTat,IdTinh,IdHuyen,IdXa,NoiSinh,QueQuan")] TbHocVien tbHocVien)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tbHocVien);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ViewBag.ErrorMessage = "Lỗi cơ sở dữ liệu: " + ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Lỗi không xác định: " + ex.Message;
                }
            }
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
            ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbHocVien.IdNguoi);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh", tbHocVien.IdTinh);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa", tbHocVien.IdXa);
            return View(tbHocVien);
        }

        // GET: HocVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHocVien = await _context.TbHocViens.FindAsync(id);
            if (tbHocVien == null)
            {
                return NotFound();
            }
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
            ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbHocVien.IdNguoi);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh", tbHocVien.IdTinh);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa", tbHocVien.IdXa);
            return View(tbHocVien);
        }

        // POST: HocVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHocVien,MaHocVien,IdNguoi,Email,Sdt,SoSoBaoHiem,IdLoaiKhuyetTat,IdTinh,IdHuyen,IdXa,NoiSinh,QueQuan")] TbHocVien tbHocVien)
        {
            if (id != tbHocVien.IdHocVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHocVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHocVienExists(tbHocVien.IdHocVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Lỗi không xác định: " + ex.Message;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHuyen"] = new SelectList(_context.DmHuyens, "IdHuyen", "TenHuyen", tbHocVien.IdHuyen);
            ViewData["IdLoaiKhuyetTat"] = new SelectList(_context.DmLoaiKhuyetTats, "IdLoaiKhuyetTat", "LoaiKhuyetTat", tbHocVien.IdLoaiKhuyetTat);
            ViewData["IdNguoi"] = new SelectList(_context.TbNguois, "IdNguoi", "name", tbHocVien.IdNguoi);
            ViewData["IdTinh"] = new SelectList(_context.DmTinhs, "IdTinh", "TenTinh", tbHocVien.IdTinh);
            ViewData["IdXa"] = new SelectList(_context.DmXas, "IdXa", "TenXa", tbHocVien.IdXa);
            return View(tbHocVien);
        }

        // GET: HocVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHocVien = await _context.TbHocViens
                .Include(t => t.IdHuyenNavigation)
                .Include(t => t.IdLoaiKhuyetTatNavigation)
                .Include(t => t.IdNguoiNavigation)
                .Include(t => t.IdTinhNavigation)
                .Include(t => t.IdXaNavigation)
                .FirstOrDefaultAsync(m => m.IdHocVien == id);
            if (tbHocVien == null)
            {
                return NotFound();
            }

            return View(tbHocVien);
        }

        // POST: HocVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHocVien = await _context.TbHocViens.FindAsync(id);
            if (tbHocVien != null)
            {
                _context.TbHocViens.Remove(tbHocVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHocVienExists(int id)
        {
            return _context.TbHocViens.Any(e => e.IdHocVien == id);
        }
    }
}
