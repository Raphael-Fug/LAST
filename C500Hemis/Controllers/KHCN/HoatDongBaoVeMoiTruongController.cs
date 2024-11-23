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
    public class HoatDongBaoVeMoiTruongController : Controller
    {
        private readonly HemisContext _context;

        public HoatDongBaoVeMoiTruongController(HemisContext context)
        {
            _context = context;
        }

        // GET: HoatDongBaoVeMoiTruong
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHoatDongBaoVeMoiTruongs.Include(t => t.IdCapQuanLyNhiemVuNavigation).Include(t => t.IdCoQuanChuQuanNavigation).Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation).Include(t => t.IdNguonKinhPhiNavigation).Include(t => t.IdNhiemVuKhcnNavigation).Include(t => t.IdTinhTrangNhiemVuNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: HoatDongBaoVeMoiTruong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs
                .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                .Include(t => t.IdCoQuanChuQuanNavigation)
                .Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation)
                .Include(t => t.IdNguonKinhPhiNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTinhTrangNhiemVuNavigation)
                .FirstOrDefaultAsync(m => m.IdHoatDongBaoVeMoiTruong == id);
            if (tbHoatDongBaoVeMoiTruong == null)
            {
                return NotFound();
            }

            return View(tbHoatDongBaoVeMoiTruong);
        }

        // GET: HoatDongBaoVeMoiTruong/Create
        public IActionResult Create()
        {
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu");
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan");
            ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong");
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi");
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn");
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu");
            return View();
        }

        // POST: HoatDongBaoVeMoiTruong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoatDongBaoVeMoiTruong,IdNhiemVuKhcn,TenNhiemVuBvmt,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,IdLoaiNhiemVuBaoVeMoiTruong,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,DonViThucHienLuuTruSanPham,IdTinhTrangNhiemVu")] TbHoatDongBaoVeMoiTruong tbHoatDongBaoVeMoiTruong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbHoatDongBaoVeMoiTruong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbHoatDongBaoVeMoiTruong.IdCapQuanLyNhiemVu);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbHoatDongBaoVeMoiTruong.IdCoQuanChuQuan);
            ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong", tbHoatDongBaoVeMoiTruong.IdLoaiNhiemVuBaoVeMoiTruong);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoatDongBaoVeMoiTruong.IdNguonKinhPhi);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbHoatDongBaoVeMoiTruong.IdNhiemVuKhcn);
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbHoatDongBaoVeMoiTruong.IdTinhTrangNhiemVu);
            return View(tbHoatDongBaoVeMoiTruong);
        }

        // GET: HoatDongBaoVeMoiTruong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs.FindAsync(id);
            if (tbHoatDongBaoVeMoiTruong == null)
            {
                return NotFound();
            }
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbHoatDongBaoVeMoiTruong.IdCapQuanLyNhiemVu);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbHoatDongBaoVeMoiTruong.IdCoQuanChuQuan);
            ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong", tbHoatDongBaoVeMoiTruong.IdLoaiNhiemVuBaoVeMoiTruong);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoatDongBaoVeMoiTruong.IdNguonKinhPhi);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbHoatDongBaoVeMoiTruong.IdNhiemVuKhcn);
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbHoatDongBaoVeMoiTruong.IdTinhTrangNhiemVu);
            return View(tbHoatDongBaoVeMoiTruong);
        }

        // POST: HoatDongBaoVeMoiTruong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoatDongBaoVeMoiTruong,IdNhiemVuKhcn,TenNhiemVuBvmt,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,IdLoaiNhiemVuBaoVeMoiTruong,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,DonViThucHienLuuTruSanPham,IdTinhTrangNhiemVu")] TbHoatDongBaoVeMoiTruong tbHoatDongBaoVeMoiTruong)
        {
            if (id != tbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHoatDongBaoVeMoiTruong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHoatDongBaoVeMoiTruongExists(tbHoatDongBaoVeMoiTruong.IdHoatDongBaoVeMoiTruong))
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
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbHoatDongBaoVeMoiTruong.IdCapQuanLyNhiemVu);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbHoatDongBaoVeMoiTruong.IdCoQuanChuQuan);
            ViewData["IdLoaiNhiemVuBaoVeMoiTruong"] = new SelectList(_context.DmLoaiNhiemVuBaoVeMoiTruongs, "IdLoaiNhiemVuBaoVeMoiTruong", "IdLoaiNhiemVuBaoVeMoiTruong", tbHoatDongBaoVeMoiTruong.IdLoaiNhiemVuBaoVeMoiTruong);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbHoatDongBaoVeMoiTruong.IdNguonKinhPhi);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbHoatDongBaoVeMoiTruong.IdNhiemVuKhcn);
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbHoatDongBaoVeMoiTruong.IdTinhTrangNhiemVu);
            return View(tbHoatDongBaoVeMoiTruong);
        }

        // GET: HoatDongBaoVeMoiTruong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs
                .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                .Include(t => t.IdCoQuanChuQuanNavigation)
                .Include(t => t.IdLoaiNhiemVuBaoVeMoiTruongNavigation)
                .Include(t => t.IdNguonKinhPhiNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTinhTrangNhiemVuNavigation)
                .FirstOrDefaultAsync(m => m.IdHoatDongBaoVeMoiTruong == id);
            if (tbHoatDongBaoVeMoiTruong == null)
            {
                return NotFound();
            }

            return View(tbHoatDongBaoVeMoiTruong);
        }

        // POST: HoatDongBaoVeMoiTruong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHoatDongBaoVeMoiTruong = await _context.TbHoatDongBaoVeMoiTruongs.FindAsync(id);
            if (tbHoatDongBaoVeMoiTruong != null)
            {
                _context.TbHoatDongBaoVeMoiTruongs.Remove(tbHoatDongBaoVeMoiTruong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHoatDongBaoVeMoiTruongExists(int id)
        {
            return _context.TbHoatDongBaoVeMoiTruongs.Any(e => e.IdHoatDongBaoVeMoiTruong == id);
        }
    }
}
