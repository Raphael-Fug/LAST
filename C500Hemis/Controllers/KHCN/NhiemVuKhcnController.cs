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
    public class NhiemVuKhcnController : Controller
    {
        private readonly HemisContext _context;

        public NhiemVuKhcnController(HemisContext context)
        {
            _context = context;
        }

        // GET: NhiemVuKhcn
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbNhiemVuKhcns.Include(t => t.IdCapQuanLyNhiemVuNavigation).Include(t => t.IdCoQuanChuQuanNavigation).Include(t => t.IdLinhVucNghienCuuNavigation).Include(t => t.IdNguonKinhPhiNavigation).Include(t => t.IdPhanLoaiNhiemVuNavigation).Include(t => t.IdTinhTrangNhiemVuNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: NhiemVuKhcn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns
                .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                .Include(t => t.IdCoQuanChuQuanNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNguonKinhPhiNavigation)
                .Include(t => t.IdPhanLoaiNhiemVuNavigation)
                .Include(t => t.IdTinhTrangNhiemVuNavigation)
                .FirstOrDefaultAsync(m => m.IdNhiemVuKhcn == id);
            if (tbNhiemVuKhcn == null)
            {
                return NotFound();
            }

            return View(tbNhiemVuKhcn);
        }

        // GET: NhiemVuKhcn/Create
        public IActionResult Create()
        {
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu");
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan");
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu");
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi");
            ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "IdLoaiNhiemVu");
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu");
            return View();
        }

        // POST: NhiemVuKhcn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNhiemVuKhcn,MaNhiemVu,TenNhiemVu,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,NguoiChuTri,IdPhanLoaiNhiemVu,ThuocNhiemVu,IdLinhVucNghienCuu,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,IdTinhTrangNhiemVu")] TbNhiemVuKhcn tbNhiemVuKhcn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNhiemVuKhcn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbNhiemVuKhcn.IdCapQuanLyNhiemVu);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbNhiemVuKhcn.IdCoQuanChuQuan);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbNhiemVuKhcn.IdLinhVucNghienCuu);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbNhiemVuKhcn.IdNguonKinhPhi);
            ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "IdLoaiNhiemVu", tbNhiemVuKhcn.IdPhanLoaiNhiemVu);
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbNhiemVuKhcn.IdTinhTrangNhiemVu);
            return View(tbNhiemVuKhcn);
        }

        // GET: NhiemVuKhcn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns.FindAsync(id);
            if (tbNhiemVuKhcn == null)
            {
                return NotFound();
            }
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbNhiemVuKhcn.IdCapQuanLyNhiemVu);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbNhiemVuKhcn.IdCoQuanChuQuan);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbNhiemVuKhcn.IdLinhVucNghienCuu);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbNhiemVuKhcn.IdNguonKinhPhi);
            ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "IdLoaiNhiemVu", tbNhiemVuKhcn.IdPhanLoaiNhiemVu);
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbNhiemVuKhcn.IdTinhTrangNhiemVu);
            return View(tbNhiemVuKhcn);
        }

        // POST: NhiemVuKhcn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNhiemVuKhcn,MaNhiemVu,TenNhiemVu,IdCapQuanLyNhiemVu,IdCoQuanChuQuan,CoQuanChuTri,NguoiChuTri,IdPhanLoaiNhiemVu,ThuocNhiemVu,IdLinhVucNghienCuu,TongKinhPhiCuaNhiemVu,IdNguonKinhPhi,ThoiGianBatDau,ThoiGianKetThuc,DanhGiaKetQuaNhiemVu,SanPhamChinhCuaNhiemVu,IdTinhTrangNhiemVu")] TbNhiemVuKhcn tbNhiemVuKhcn)
        {
            if (id != tbNhiemVuKhcn.IdNhiemVuKhcn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNhiemVuKhcn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNhiemVuKhcnExists(tbNhiemVuKhcn.IdNhiemVuKhcn))
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
            ViewData["IdCapQuanLyNhiemVu"] = new SelectList(_context.DmPhanCapNhiemVus, "IdPhanCapNhiemVu", "IdPhanCapNhiemVu", tbNhiemVuKhcn.IdCapQuanLyNhiemVu);
            ViewData["IdCoQuanChuQuan"] = new SelectList(_context.DmCoQuanChuQuans, "IdCoQuanChuQuan", "IdCoQuanChuQuan", tbNhiemVuKhcn.IdCoQuanChuQuan);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbNhiemVuKhcn.IdLinhVucNghienCuu);
            ViewData["IdNguonKinhPhi"] = new SelectList(_context.DmNguonKinhPhis, "IdNguonKinhPhi", "IdNguonKinhPhi", tbNhiemVuKhcn.IdNguonKinhPhi);
            ViewData["IdPhanLoaiNhiemVu"] = new SelectList(_context.DmLoaiNhiemVus, "IdLoaiNhiemVu", "IdLoaiNhiemVu", tbNhiemVuKhcn.IdPhanLoaiNhiemVu);
            ViewData["IdTinhTrangNhiemVu"] = new SelectList(_context.DmTinhTrangNhiemVus, "IdTinhTrangNhiemVu", "IdTinhTrangNhiemVu", tbNhiemVuKhcn.IdTinhTrangNhiemVu);
            return View(tbNhiemVuKhcn);
        }

        // GET: NhiemVuKhcn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns
                .Include(t => t.IdCapQuanLyNhiemVuNavigation)
                .Include(t => t.IdCoQuanChuQuanNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNguonKinhPhiNavigation)
                .Include(t => t.IdPhanLoaiNhiemVuNavigation)
                .Include(t => t.IdTinhTrangNhiemVuNavigation)
                .FirstOrDefaultAsync(m => m.IdNhiemVuKhcn == id);
            if (tbNhiemVuKhcn == null)
            {
                return NotFound();
            }

            return View(tbNhiemVuKhcn);
        }

        // POST: NhiemVuKhcn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNhiemVuKhcn = await _context.TbNhiemVuKhcns.FindAsync(id);
            if (tbNhiemVuKhcn != null)
            {
                _context.TbNhiemVuKhcns.Remove(tbNhiemVuKhcn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNhiemVuKhcnExists(int id)
        {
            return _context.TbNhiemVuKhcns.Any(e => e.IdNhiemVuKhcn == id);
        }
    }
}
