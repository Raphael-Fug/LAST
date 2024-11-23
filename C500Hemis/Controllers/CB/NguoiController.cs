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
    public class NguoiController : Controller
    {
        private readonly HemisContext _context;

        public NguoiController(HemisContext context)
        {
            _context = context;
        }

        // GET: Nguoi
        public async Task<IActionResult> Index()
        {
            var hemisContext = 
                _context.TbNguois
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdChuyenMonDaoTaoNavigation)
                .Include(t => t.IdTonGiaoNavigation)
                .Include(t => t.IdDanTocNavigation)
                .Include(t => t.IdGiaDinhChinhSachNavigation)
                .Include(t => t.IdGioiTinhNavigation)
                .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                .Include(t => t.IdNgoaiNguNavigation)
                .Include(t => t.IdQuocTichNavigation)
                .Include(t => t.IdThuongBinhHangNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                .Include(t => t.IdTrinhDoTinHocNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: Nguoi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNguoi = await _context.TbNguois
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdChuyenMonDaoTaoNavigation)
                .Include(t => t.IdTonGiaoNavigation)
                .Include(t => t.IdDanTocNavigation)
                .Include(t => t.IdGiaDinhChinhSachNavigation)
                .Include(t => t.IdGioiTinhNavigation)
                .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                .Include(t => t.IdNgoaiNguNavigation)
                .Include(t => t.IdQuocTichNavigation)
                .Include(t => t.IdThuongBinhHangNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                .Include(t => t.IdTrinhDoTinHocNavigation)
                .FirstOrDefaultAsync(m => m.IdNguoi == id);
            if (tbNguoi == null)
            {
                return NotFound();
            }

            return View(tbNguoi);
        }

        // GET: Nguoi/Create
        public IActionResult Create()
        {
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "IdChucDanhKhoaHoc");
            ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "IdTonGiao");
            ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "IdDanToc");
            ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "IdHoGiaDinhChinhSach");
            ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "IdGioiTinh");
            ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu");
            ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "IdNgoaiNgu");
            ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich");
            ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "IdHangThuongBinh");
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao");
            ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "IdTrinhDoLyLuanChinhTri");
            ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "IdTrinhDoQuanLyNhaNuoc");
            ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "IdTrinhDoTinHoc");
            return View();
        }

        // POST: Nguoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNguoi,Ho,Ten,IdQuocTich,SoCccd,NgayCapCccd,NoiCapCccd,NgaySinh,IdGioiTinh,IdDanToc,IdTonGiao,NgayVaoDoan,NgayVaoDang,NgayVaoDangChinhThuc,NgayNhapNgu,NgayXuatNgu,IdThuongBinhHang,IdGiaDinhChinhSach,IdChucDanhKhoaHoc,IdTrinhDoDaoTao,IdChuyenMonDaoTao,IdNgoaiNgu,IdKhungNangLucNgoaiNguc,IdTrinhDoLyLuanChinhTri,IdTrinhDoQuanLyNhaNuoc,IdTrinhDoTinHoc")] TbNguoi tbNguoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbNguoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "IdChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
            ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
            ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "IdTonGiao", tbNguoi.IdDanToc);
            ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "IdDanToc", tbNguoi.IdDanToc);
            ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "IdHoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
            ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "IdGioiTinh", tbNguoi.IdGioiTinh);
            ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
            ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "IdNgoaiNgu", tbNguoi.IdNgoaiNgu);
            ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbNguoi.IdQuocTich);
            ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "IdHangThuongBinh", tbNguoi.IdThuongBinhHang);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
            ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "IdTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
            ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "IdTrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
            ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "IdTrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
            return View(tbNguoi);
        }

        // GET: Nguoi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNguoi = await _context.TbNguois.FindAsync(id);
            if (tbNguoi == null)
            {
                return NotFound();
            }
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "IdChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
            ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
            ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "IdTonGiao", tbNguoi.IdDanToc);
            ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "IdDanToc", tbNguoi.IdDanToc);
            ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "IdHoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
            ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "IdGioiTinh", tbNguoi.IdGioiTinh);
            ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
            ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "IdNgoaiNgu", tbNguoi.IdNgoaiNgu);
            ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbNguoi.IdQuocTich);
            ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "IdHangThuongBinh", tbNguoi.IdThuongBinhHang);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
            ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "IdTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
            ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "IdTrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
            ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "IdTrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
            return View(tbNguoi);
        }

        // POST: Nguoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoi,Ho,Ten,IdQuocTich,SoCccd,NgayCapCccd,NoiCapCccd,NgaySinh,IdGioiTinh,IdDanToc,IdTonGiao,NgayVaoDoan,NgayVaoDang,NgayVaoDangChinhThuc,NgayNhapNgu,NgayXuatNgu,IdThuongBinhHang,IdGiaDinhChinhSach,IdChucDanhKhoaHoc,IdTrinhDoDaoTao,IdChuyenMonDaoTao,IdNgoaiNgu,IdKhungNangLucNgoaiNguc,IdTrinhDoLyLuanChinhTri,IdTrinhDoQuanLyNhaNuoc,IdTrinhDoTinHoc")] TbNguoi tbNguoi)
        {
            if (id != tbNguoi.IdNguoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNguoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbNguoiExists(tbNguoi.IdNguoi))
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
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "IdChucDanhKhoaHoc", tbNguoi.IdChucDanhKhoaHoc);
            ViewData["IdChuyenMonDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbNguoi.IdChuyenMonDaoTao);
            ViewData["IdTonGiao"] = new SelectList(_context.DmTonGiaos, "IdTonGiao", "IdTonGiao", tbNguoi.IdDanToc);
            ViewData["IdDanToc"] = new SelectList(_context.DmDanTocs, "IdDanToc", "IdDanToc", tbNguoi.IdDanToc);
            ViewData["IdGiaDinhChinhSach"] = new SelectList(_context.DmHoGiaDinhChinhSaches, "IdHoGiaDinhChinhSach", "IdHoGiaDinhChinhSach", tbNguoi.IdGiaDinhChinhSach);
            ViewData["IdGioiTinh"] = new SelectList(_context.DmGioiTinhs, "IdGioiTinh", "IdGioiTinh", tbNguoi.IdGioiTinh);
            ViewData["IdKhungNangLucNgoaiNguc"] = new SelectList(_context.DmKhungNangLucNgoaiNgus, "IdKhungNangLucNgoaiNgu", "IdKhungNangLucNgoaiNgu", tbNguoi.IdKhungNangLucNgoaiNguc);
            ViewData["IdNgoaiNgu"] = new SelectList(_context.DmNgoaiNgus, "IdNgoaiNgu", "IdNgoaiNgu", tbNguoi.IdNgoaiNgu);
            ViewData["IdQuocTich"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbNguoi.IdQuocTich);
            ViewData["IdThuongBinhHang"] = new SelectList(_context.DmHangThuongBinhs, "IdHangThuongBinh", "IdHangThuongBinh", tbNguoi.IdThuongBinhHang);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbNguoi.IdTrinhDoDaoTao);
            ViewData["IdTrinhDoLyLuanChinhTri"] = new SelectList(_context.DmTrinhDoLyLuanChinhTris, "IdTrinhDoLyLuanChinhTri", "IdTrinhDoLyLuanChinhTri", tbNguoi.IdTrinhDoLyLuanChinhTri);
            ViewData["IdTrinhDoQuanLyNhaNuoc"] = new SelectList(_context.DmTrinhDoQuanLyNhaNuocs, "IdTrinhDoQuanLyNhaNuoc", "IdTrinhDoQuanLyNhaNuoc", tbNguoi.IdTrinhDoQuanLyNhaNuoc);
            ViewData["IdTrinhDoTinHoc"] = new SelectList(_context.DmTrinhDoTinHocs, "IdTrinhDoTinHoc", "IdTrinhDoTinHoc", tbNguoi.IdTrinhDoTinHoc);
            return View(tbNguoi);
        }

        // GET: Nguoi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNguoi = await _context.TbNguois
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdChuyenMonDaoTaoNavigation)
                .Include(t => t.IdTonGiaoNavigation)
                .Include(t => t.IdDanTocNavigation)
                .Include(t => t.IdGiaDinhChinhSachNavigation)
                .Include(t => t.IdGioiTinhNavigation)
                .Include(t => t.IdKhungNangLucNgoaiNgucNavigation)
                .Include(t => t.IdNgoaiNguNavigation)
                .Include(t => t.IdQuocTichNavigation)
                .Include(t => t.IdThuongBinhHangNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .Include(t => t.IdTrinhDoLyLuanChinhTriNavigation)
                .Include(t => t.IdTrinhDoQuanLyNhaNuocNavigation)
                .Include(t => t.IdTrinhDoTinHocNavigation)
                .FirstOrDefaultAsync(m => m.IdNguoi == id);
            if (tbNguoi == null)
            {
                return NotFound();
            }

            return View(tbNguoi);
        }

        // POST: Nguoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNguoi = await _context.TbNguois.FindAsync(id);
            if (tbNguoi != null)
            {
                _context.TbNguois.Remove(tbNguoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbNguoiExists(int id)
        {
            return _context.TbNguois.Any(e => e.IdNguoi == id);
        }
    }
}
