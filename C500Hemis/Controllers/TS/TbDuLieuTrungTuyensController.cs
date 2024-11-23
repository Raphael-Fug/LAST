using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TS
{
    public class TbDuLieuTrungTuyensController : Controller
    {
        private readonly HemisContext _context;

        public TbDuLieuTrungTuyensController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbDuLieuTrungTuyens
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDuLieuTrungTuyens.Include(t => t.IdDoiTuongDauVaoNavigation).Include(t => t.IdDoiTuongUuTienNavigation).Include(t => t.IdHinhThucTuyenSinhNavigation).Include(t => t.IdKhuVucNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbDuLieuTrungTuyens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens
                .Include(t => t.IdDoiTuongDauVaoNavigation)
                .Include(t => t.IdDoiTuongUuTienNavigation)
                .Include(t => t.IdHinhThucTuyenSinhNavigation)
                .Include(t => t.IdKhuVucNavigation)
                .FirstOrDefaultAsync(m => m.IdDuLieuTrungTuyen == id);
            if (tbDuLieuTrungTuyen == null)
            {
                return NotFound();
            }

            return View(tbDuLieuTrungTuyen);
        }

        // GET: TbDuLieuTrungTuyens/Create
        public IActionResult Create()
        {
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao");
            ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "IdDoiTuongUuTien");
            ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "IdHinhThucTuyenSinh");
            ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "IdKhuVuc");
            return View();
        }

        // POST: TbDuLieuTrungTuyens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDuLieuTrungTuyen,Cccd,HoVaTen,MaTuyenSinh,KhoaDaoTaoTrungTuyen,IdDoiTuongDauVao,IdDoiTuongUuTien,IdHinhThucTuyenSinh,IdKhuVuc,TruongThpt,ToHopMonTrungTuyen,DiemMon1,DiemMon2,DiemMon3,DiemUuTien,TongDiemXetTuyen,SoQuyetDinhTrungTuyen,NgayBanHanhQuyetDinhTrungTuyen,ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc,NganhDaTotNghiepTrinhDoDaiHoc,ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi,NganhDaTotNghiepTrinhDoThacSi")] TbDuLieuTrungTuyen tbDuLieuTrungTuyen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDuLieuTrungTuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao", tbDuLieuTrungTuyen.IdDoiTuongDauVao);
            ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "IdDoiTuongUuTien", tbDuLieuTrungTuyen.IdDoiTuongUuTien);
            ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "IdHinhThucTuyenSinh", tbDuLieuTrungTuyen.IdHinhThucTuyenSinh);
            ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "IdKhuVuc", tbDuLieuTrungTuyen.IdKhuVuc);
            return View(tbDuLieuTrungTuyen);
        }

        // GET: TbDuLieuTrungTuyens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens.FindAsync(id);
            if (tbDuLieuTrungTuyen == null)
            {
                return NotFound();
            }
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao", tbDuLieuTrungTuyen.IdDoiTuongDauVao);
            ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "IdDoiTuongUuTien", tbDuLieuTrungTuyen.IdDoiTuongUuTien);
            ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "IdHinhThucTuyenSinh", tbDuLieuTrungTuyen.IdHinhThucTuyenSinh);
            ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "IdKhuVuc", tbDuLieuTrungTuyen.IdKhuVuc);
            return View(tbDuLieuTrungTuyen);
        }

        // POST: TbDuLieuTrungTuyens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDuLieuTrungTuyen,Cccd,HoVaTen,MaTuyenSinh,KhoaDaoTaoTrungTuyen,IdDoiTuongDauVao,IdDoiTuongUuTien,IdHinhThucTuyenSinh,IdKhuVuc,TruongThpt,ToHopMonTrungTuyen,DiemMon1,DiemMon2,DiemMon3,DiemUuTien,TongDiemXetTuyen,SoQuyetDinhTrungTuyen,NgayBanHanhQuyetDinhTrungTuyen,ChuongTrinhDaoTaoDaTotNghiepTrinhDoDaiHoc,NganhDaTotNghiepTrinhDoDaiHoc,ChuongTrinhDaoTaoDaTotNghiepTrinhDoThacSi,NganhDaTotNghiepTrinhDoThacSi")] TbDuLieuTrungTuyen tbDuLieuTrungTuyen)
        {
            if (id != tbDuLieuTrungTuyen.IdDuLieuTrungTuyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDuLieuTrungTuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDuLieuTrungTuyenExists(tbDuLieuTrungTuyen.IdDuLieuTrungTuyen))
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
            ViewData["IdDoiTuongDauVao"] = new SelectList(_context.DmDoiTuongDauVaos, "IdDoiTuongDauVao", "IdDoiTuongDauVao", tbDuLieuTrungTuyen.IdDoiTuongDauVao);
            ViewData["IdDoiTuongUuTien"] = new SelectList(_context.DmDoiTuongUuTiens, "IdDoiTuongUuTien", "IdDoiTuongUuTien", tbDuLieuTrungTuyen.IdDoiTuongUuTien);
            ViewData["IdHinhThucTuyenSinh"] = new SelectList(_context.DmHinhThucTuyenSinhs, "IdHinhThucTuyenSinh", "IdHinhThucTuyenSinh", tbDuLieuTrungTuyen.IdHinhThucTuyenSinh);
            ViewData["IdKhuVuc"] = new SelectList(_context.DmKhuVucs, "IdKhuVuc", "IdKhuVuc", tbDuLieuTrungTuyen.IdKhuVuc);
            return View(tbDuLieuTrungTuyen);
        }

        // GET: TbDuLieuTrungTuyens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens
                .Include(t => t.IdDoiTuongDauVaoNavigation)
                .Include(t => t.IdDoiTuongUuTienNavigation)
                .Include(t => t.IdHinhThucTuyenSinhNavigation)
                .Include(t => t.IdKhuVucNavigation)
                .FirstOrDefaultAsync(m => m.IdDuLieuTrungTuyen == id);
            if (tbDuLieuTrungTuyen == null)
            {
                return NotFound();
            }

            return View(tbDuLieuTrungTuyen);
        }

        // POST: TbDuLieuTrungTuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDuLieuTrungTuyen = await _context.TbDuLieuTrungTuyens.FindAsync(id);
            if (tbDuLieuTrungTuyen != null)
            {
                _context.TbDuLieuTrungTuyens.Remove(tbDuLieuTrungTuyen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDuLieuTrungTuyenExists(int id)
        {
            return _context.TbDuLieuTrungTuyens.Any(e => e.IdDuLieuTrungTuyen == id);
        }
    }
}
