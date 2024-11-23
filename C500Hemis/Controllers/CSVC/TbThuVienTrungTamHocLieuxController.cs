using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSVC
{
    public class TbThuVienTrungTamHocLieuxController : Controller
    {
        private readonly HemisContext _context;

        public TbThuVienTrungTamHocLieuxController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbThuVienTrungTamHocLieux
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThuVienTrungTamHocLieus.Include(t => t.IdHinhThucSoHuuNavigation).Include(t => t.IdTinhTrangCsvcNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbThuVienTrungTamHocLieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThuVienTrungTamHocLieu = await _context.TbThuVienTrungTamHocLieus
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdTinhTrangCsvcNavigation)
                .FirstOrDefaultAsync(m => m.IdThuVienTrungTamHocLieu == id);
            if (tbThuVienTrungTamHocLieu == null)
            {
                return NotFound();
            }

            return View(tbThuVienTrungTamHocLieu);
        }

        // GET: TbThuVienTrungTamHocLieux/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu");
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat");
            return View();
        }

        // POST: TbThuVienTrungTamHocLieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThuVienTrungTamHocLieu,MaThuVienTrungTamHocLieu,TenThuVienTrungTamHocLieu,NamDuaVaoSuDung,DienTich,DienTichPhongDoc,SoPhongDoc,SoLuongMayTinh,SoLuongChoNgoi,SoLuongSach,SoLuongTapChi,SoLuongSachDienTu,SoLuongTapChiDienTu,SoLuonngThuVienDienTuLienKetNn,IdTinhTrangCsvc,IdHinhThucSoHuu,SoLuongDauSach,SoLuongDauTapChi,SoLuongDauSachDienTu,SoLuongDauTapChiDienTu")] TbThuVienTrungTamHocLieu tbThuVienTrungTamHocLieu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThuVienTrungTamHocLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbThuVienTrungTamHocLieu.IdHinhThucSoHuu);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbThuVienTrungTamHocLieu.IdTinhTrangCsvc);
            return View(tbThuVienTrungTamHocLieu);
        }

        // GET: TbThuVienTrungTamHocLieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThuVienTrungTamHocLieu = await _context.TbThuVienTrungTamHocLieus.FindAsync(id);
            if (tbThuVienTrungTamHocLieu == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbThuVienTrungTamHocLieu.IdHinhThucSoHuu);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbThuVienTrungTamHocLieu.IdTinhTrangCsvc);
            return View(tbThuVienTrungTamHocLieu);
        }

        // POST: TbThuVienTrungTamHocLieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThuVienTrungTamHocLieu,MaThuVienTrungTamHocLieu,TenThuVienTrungTamHocLieu,NamDuaVaoSuDung,DienTich,DienTichPhongDoc,SoPhongDoc,SoLuongMayTinh,SoLuongChoNgoi,SoLuongSach,SoLuongTapChi,SoLuongSachDienTu,SoLuongTapChiDienTu,SoLuonngThuVienDienTuLienKetNn,IdTinhTrangCsvc,IdHinhThucSoHuu,SoLuongDauSach,SoLuongDauTapChi,SoLuongDauSachDienTu,SoLuongDauTapChiDienTu")] TbThuVienTrungTamHocLieu tbThuVienTrungTamHocLieu)
        {
            if (id != tbThuVienTrungTamHocLieu.IdThuVienTrungTamHocLieu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThuVienTrungTamHocLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThuVienTrungTamHocLieuExists(tbThuVienTrungTamHocLieu.IdThuVienTrungTamHocLieu))
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
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbThuVienTrungTamHocLieu.IdHinhThucSoHuu);
            ViewData["IdTinhTrangCsvc"] = new SelectList(_context.DmTinhTrangCoSoVatChats, "IdTinhTrangCoSoVatChat", "IdTinhTrangCoSoVatChat", tbThuVienTrungTamHocLieu.IdTinhTrangCsvc);
            return View(tbThuVienTrungTamHocLieu);
        }

        // GET: TbThuVienTrungTamHocLieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThuVienTrungTamHocLieu = await _context.TbThuVienTrungTamHocLieus
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .Include(t => t.IdTinhTrangCsvcNavigation)
                .FirstOrDefaultAsync(m => m.IdThuVienTrungTamHocLieu == id);
            if (tbThuVienTrungTamHocLieu == null)
            {
                return NotFound();
            }

            return View(tbThuVienTrungTamHocLieu);
        }

        // POST: TbThuVienTrungTamHocLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThuVienTrungTamHocLieu = await _context.TbThuVienTrungTamHocLieus.FindAsync(id);
            if (tbThuVienTrungTamHocLieu != null)
            {
                _context.TbThuVienTrungTamHocLieus.Remove(tbThuVienTrungTamHocLieu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThuVienTrungTamHocLieuExists(int id)
        {
            return _context.TbThuVienTrungTamHocLieus.Any(e => e.IdThuVienTrungTamHocLieu == id);
        }
    }
}
