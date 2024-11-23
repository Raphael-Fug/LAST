using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CTDT
{
    public class ChuongTrinhDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public ChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChuongTrinhDaoTao
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbChuongTrinhDaoTaos.Include(t => t.IdDonViCapBangNavigation).Include(t => t.IdHocCheDaoTaoNavigation).Include(t => t.IdLoaiChuongTrinhDaoTaoNavigation).Include(t => t.IdLoaiChuongTrinhLienKetDaoTaoNavigation).Include(t => t.IdNganhDaoTaoNavigation).Include(t => t.IdQuocGiaCuaTruSoChinhNavigation).Include(t => t.IdTrangThaiCuaChuongTrinhNavigation).Include(t => t.IdTrinhDoDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ChuongTrinhDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuongTrinhDaoTao = await _context.TbChuongTrinhDaoTaos
                .Include(t => t.IdDonViCapBangNavigation)
                .Include(t => t.IdHocCheDaoTaoNavigation)
                .Include(t => t.IdLoaiChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdLoaiChuongTrinhLienKetDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdQuocGiaCuaTruSoChinhNavigation)
                .Include(t => t.IdTrangThaiCuaChuongTrinhNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdChuongTrinhDaoTao == id);
            if (tbChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbChuongTrinhDaoTao);
        }

        // GET: ChuongTrinhDaoTao/Create
        public IActionResult Create()
        {
            ViewData["IdDonViCapBang"] = new SelectList(_context.DmDonViCapBangs, "IdDonViCapBang", "IdDonViCapBang");
            ViewData["IdHocCheDaoTao"] = new SelectList(_context.DmHocCheDaoTaos, "IdHocCheDaoTao", "IdHocCheDaoTao");
            ViewData["IdLoaiChuongTrinhDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhDaoTaos, "IdLoaiChuongTrinhDaoTao", "IdLoaiChuongTrinhDaoTao");
            ViewData["IdLoaiChuongTrinhLienKetDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhLienKetDaoTaos, "IdLoaiChuongTrinhLienKetDaoTao", "IdLoaiChuongTrinhLienKetDaoTao");
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao");
            ViewData["IdQuocGiaCuaTruSoChinh"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich");
            ViewData["IdTrangThaiCuaChuongTrinh"] = new SelectList(_context.DmTrangThaiChuongTrinhDaoTaos, "IdTrangThaiChuongTrinhDaoTao", "IdTrangThaiChuongTrinhDaoTao");
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao");
            return View();
        }

        // POST: ChuongTrinhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChuongTrinhDaoTao,MaChuongTrinhDaoTao,IdNganhDaoTao,TenChuongTrinh,TenChuongTrinhBangTiengAnh,NamBatDauTuyenSinh,TenCoSoDaoTaoNuocNgoai,IdLoaiChuongTrinhDaoTao,IdLoaiChuongTrinhLienKetDaoTao,DiaDiemDaoTao,IdHocCheDaoTao,IdQuocGiaCuaTruSoChinh,NgayBanHanhChuanDauRa,IdTrinhDoDaoTao,ThoiGianDaoTaoChuan,ChuanDauRa,IdDonViCapBang,LoaiChungChiDuocChapThuan,DonViThucHienChuongTrinh,IdTrangThaiCuaChuongTrinh,ChuanDauRaVeNgoaiNgu,ChuanDauRaVeTinHoc,HocPhiTaiVietNam,HocPhiTaiNuocNgoai")] TbChuongTrinhDaoTao tbChuongTrinhDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbChuongTrinhDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDonViCapBang"] = new SelectList(_context.DmDonViCapBangs, "IdDonViCapBang", "IdDonViCapBang", tbChuongTrinhDaoTao.IdDonViCapBang);
            ViewData["IdHocCheDaoTao"] = new SelectList(_context.DmHocCheDaoTaos, "IdHocCheDaoTao", "IdHocCheDaoTao", tbChuongTrinhDaoTao.IdHocCheDaoTao);
            ViewData["IdLoaiChuongTrinhDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhDaoTaos, "IdLoaiChuongTrinhDaoTao", "IdLoaiChuongTrinhDaoTao", tbChuongTrinhDaoTao.IdLoaiChuongTrinhDaoTao);
            ViewData["IdLoaiChuongTrinhLienKetDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhLienKetDaoTaos, "IdLoaiChuongTrinhLienKetDaoTao", "IdLoaiChuongTrinhLienKetDaoTao", tbChuongTrinhDaoTao.IdLoaiChuongTrinhLienKetDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbChuongTrinhDaoTao.IdNganhDaoTao);
            ViewData["IdQuocGiaCuaTruSoChinh"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbChuongTrinhDaoTao.IdQuocGiaCuaTruSoChinh);
            ViewData["IdTrangThaiCuaChuongTrinh"] = new SelectList(_context.DmTrangThaiChuongTrinhDaoTaos, "IdTrangThaiChuongTrinhDaoTao", "IdTrangThaiChuongTrinhDaoTao", tbChuongTrinhDaoTao.IdTrangThaiCuaChuongTrinh);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbChuongTrinhDaoTao.IdTrinhDoDaoTao);
            return View(tbChuongTrinhDaoTao);
        }

        // GET: ChuongTrinhDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuongTrinhDaoTao = await _context.TbChuongTrinhDaoTaos.FindAsync(id);
            if (tbChuongTrinhDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdDonViCapBang"] = new SelectList(_context.DmDonViCapBangs, "IdDonViCapBang", "IdDonViCapBang", tbChuongTrinhDaoTao.IdDonViCapBang);
            ViewData["IdHocCheDaoTao"] = new SelectList(_context.DmHocCheDaoTaos, "IdHocCheDaoTao", "IdHocCheDaoTao", tbChuongTrinhDaoTao.IdHocCheDaoTao);
            ViewData["IdLoaiChuongTrinhDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhDaoTaos, "IdLoaiChuongTrinhDaoTao", "IdLoaiChuongTrinhDaoTao", tbChuongTrinhDaoTao.IdLoaiChuongTrinhDaoTao);
            ViewData["IdLoaiChuongTrinhLienKetDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhLienKetDaoTaos, "IdLoaiChuongTrinhLienKetDaoTao", "IdLoaiChuongTrinhLienKetDaoTao", tbChuongTrinhDaoTao.IdLoaiChuongTrinhLienKetDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbChuongTrinhDaoTao.IdNganhDaoTao);
            ViewData["IdQuocGiaCuaTruSoChinh"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbChuongTrinhDaoTao.IdQuocGiaCuaTruSoChinh);
            ViewData["IdTrangThaiCuaChuongTrinh"] = new SelectList(_context.DmTrangThaiChuongTrinhDaoTaos, "IdTrangThaiChuongTrinhDaoTao", "IdTrangThaiChuongTrinhDaoTao", tbChuongTrinhDaoTao.IdTrangThaiCuaChuongTrinh);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbChuongTrinhDaoTao.IdTrinhDoDaoTao);
            return View(tbChuongTrinhDaoTao);
        }

        // POST: ChuongTrinhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChuongTrinhDaoTao,MaChuongTrinhDaoTao,IdNganhDaoTao,TenChuongTrinh,TenChuongTrinhBangTiengAnh,NamBatDauTuyenSinh,TenCoSoDaoTaoNuocNgoai,IdLoaiChuongTrinhDaoTao,IdLoaiChuongTrinhLienKetDaoTao,DiaDiemDaoTao,IdHocCheDaoTao,IdQuocGiaCuaTruSoChinh,NgayBanHanhChuanDauRa,IdTrinhDoDaoTao,ThoiGianDaoTaoChuan,ChuanDauRa,IdDonViCapBang,LoaiChungChiDuocChapThuan,DonViThucHienChuongTrinh,IdTrangThaiCuaChuongTrinh,ChuanDauRaVeNgoaiNgu,ChuanDauRaVeTinHoc,HocPhiTaiVietNam,HocPhiTaiNuocNgoai")] TbChuongTrinhDaoTao tbChuongTrinhDaoTao)
        {
            if (id != tbChuongTrinhDaoTao.IdChuongTrinhDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChuongTrinhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChuongTrinhDaoTaoExists(tbChuongTrinhDaoTao.IdChuongTrinhDaoTao))
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
            ViewData["IdDonViCapBang"] = new SelectList(_context.DmDonViCapBangs, "IdDonViCapBang", "IdDonViCapBang", tbChuongTrinhDaoTao.IdDonViCapBang);
            ViewData["IdHocCheDaoTao"] = new SelectList(_context.DmHocCheDaoTaos, "IdHocCheDaoTao", "IdHocCheDaoTao", tbChuongTrinhDaoTao.IdHocCheDaoTao);
            ViewData["IdLoaiChuongTrinhDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhDaoTaos, "IdLoaiChuongTrinhDaoTao", "IdLoaiChuongTrinhDaoTao", tbChuongTrinhDaoTao.IdLoaiChuongTrinhDaoTao);
            ViewData["IdLoaiChuongTrinhLienKetDaoTao"] = new SelectList(_context.DmLoaiChuongTrinhLienKetDaoTaos, "IdLoaiChuongTrinhLienKetDaoTao", "IdLoaiChuongTrinhLienKetDaoTao", tbChuongTrinhDaoTao.IdLoaiChuongTrinhLienKetDaoTao);
            ViewData["IdNganhDaoTao"] = new SelectList(_context.DmNganhDaoTaos, "IdNganhDaoTao", "IdNganhDaoTao", tbChuongTrinhDaoTao.IdNganhDaoTao);
            ViewData["IdQuocGiaCuaTruSoChinh"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbChuongTrinhDaoTao.IdQuocGiaCuaTruSoChinh);
            ViewData["IdTrangThaiCuaChuongTrinh"] = new SelectList(_context.DmTrangThaiChuongTrinhDaoTaos, "IdTrangThaiChuongTrinhDaoTao", "IdTrangThaiChuongTrinhDaoTao", tbChuongTrinhDaoTao.IdTrangThaiCuaChuongTrinh);
            ViewData["IdTrinhDoDaoTao"] = new SelectList(_context.DmTrinhDoDaoTaos, "IdTrinhDoDaoTao", "IdTrinhDoDaoTao", tbChuongTrinhDaoTao.IdTrinhDoDaoTao);
            return View(tbChuongTrinhDaoTao);
        }

        // GET: ChuongTrinhDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuongTrinhDaoTao = await _context.TbChuongTrinhDaoTaos
                .Include(t => t.IdDonViCapBangNavigation)
                .Include(t => t.IdHocCheDaoTaoNavigation)
                .Include(t => t.IdLoaiChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdLoaiChuongTrinhLienKetDaoTaoNavigation)
                .Include(t => t.IdNganhDaoTaoNavigation)
                .Include(t => t.IdQuocGiaCuaTruSoChinhNavigation)
                .Include(t => t.IdTrangThaiCuaChuongTrinhNavigation)
                .Include(t => t.IdTrinhDoDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdChuongTrinhDaoTao == id);
            if (tbChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbChuongTrinhDaoTao);
        }

        // POST: ChuongTrinhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChuongTrinhDaoTao = await _context.TbChuongTrinhDaoTaos.FindAsync(id);
            if (tbChuongTrinhDaoTao != null)
            {
                _context.TbChuongTrinhDaoTaos.Remove(tbChuongTrinhDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChuongTrinhDaoTaoExists(int id)
        {
            return _context.TbChuongTrinhDaoTaos.Any(e => e.IdChuongTrinhDaoTao == id);
        }
    }
}
