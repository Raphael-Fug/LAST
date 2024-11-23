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
    public class TbGvduocCuDiDaoTaosController : Controller
    {
        private readonly HemisContext _context;

        public TbGvduocCuDiDaoTaosController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbGvduocCuDiDaoTaos
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGvduocCuDiDaoTaos.Include(t => t.IdCanBoNavigation).Include(t => t.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation).Include(t => t.IdNguonKinhPhiCuaGvNavigation).Include(t => t.IdQuocGiaDenNavigation).Include(t => t.IdTinhTrangGvduocCuDiDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbGvduocCuDiDaoTaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation)
                .Include(t => t.IdNguonKinhPhiCuaGvNavigation)
                .Include(t => t.IdQuocGiaDenNavigation)
                .Include(t => t.IdTinhTrangGvduocCuDiDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGvduocCuDiDaoTao == id);
            if (tbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGvduocCuDiDaoTao);
        }

        // GET: TbGvduocCuDiDaoTaos/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "IdHinhThucThamGiaGvduocCuDiDaoTao");
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "IdNguonKinhPhiCuaGvduocCuDiDaoTao");
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich");
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "IdTinhTrangGiangVienDuocCuDiDaoTao");
            return View();
        }

        // POST: TbGvduocCuDiDaoTaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGvduocCuDiDaoTao,IdCanBo,IdHinhThucThamGiaGvduocCuDiDaoTao,IdQuocGiaDen,TenCoSoGiaoDucThamGiaOnn,ThoiGianBatDau,ThoiGianKetThuc,IdTinhTrangGvduocCuDiDaoTao,IdNguonKinhPhiCuaGv")] TbGvduocCuDiDaoTao tbGvduocCuDiDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGvduocCuDiDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGvduocCuDiDaoTao.IdCanBo);
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "IdHinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "IdNguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbGvduocCuDiDaoTao.IdQuocGiaDen);
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "IdTinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);
            return View(tbGvduocCuDiDaoTao);
        }

        // GET: TbGvduocCuDiDaoTaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos.FindAsync(id);
            if (tbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGvduocCuDiDaoTao.IdCanBo);
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "IdHinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "IdNguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbGvduocCuDiDaoTao.IdQuocGiaDen);
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "IdTinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);
            return View(tbGvduocCuDiDaoTao);
        }

        // POST: TbGvduocCuDiDaoTaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGvduocCuDiDaoTao,IdCanBo,IdHinhThucThamGiaGvduocCuDiDaoTao,IdQuocGiaDen,TenCoSoGiaoDucThamGiaOnn,ThoiGianBatDau,ThoiGianKetThuc,IdTinhTrangGvduocCuDiDaoTao,IdNguonKinhPhiCuaGv")] TbGvduocCuDiDaoTao tbGvduocCuDiDaoTao)
        {
            if (id != tbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGvduocCuDiDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGvduocCuDiDaoTaoExists(tbGvduocCuDiDaoTao.IdGvduocCuDiDaoTao))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbGvduocCuDiDaoTao.IdCanBo);
            ViewData["IdHinhThucThamGiaGvduocCuDiDaoTao"] = new SelectList(_context.DmHinhThucThamGiaGvduocCuDiDaoTaos, "IdHinhThucThamGiaGvduocCuDiDaoTao", "IdHinhThucThamGiaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdHinhThucThamGiaGvduocCuDiDaoTao);
            ViewData["IdNguonKinhPhiCuaGv"] = new SelectList(_context.DmNguonKinhPhiCuaGvduocCuDiDaoTaos, "IdNguonKinhPhiCuaGvduocCuDiDaoTao", "IdNguonKinhPhiCuaGvduocCuDiDaoTao", tbGvduocCuDiDaoTao.IdNguonKinhPhiCuaGv);
            ViewData["IdQuocGiaDen"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbGvduocCuDiDaoTao.IdQuocGiaDen);
            ViewData["IdTinhTrangGvduocCuDiDaoTao"] = new SelectList(_context.DmTinhTrangGiangVienDuocCuDiDaoTaos, "IdTinhTrangGiangVienDuocCuDiDaoTao", "IdTinhTrangGiangVienDuocCuDiDaoTao", tbGvduocCuDiDaoTao.IdTinhTrangGvduocCuDiDaoTao);
            return View(tbGvduocCuDiDaoTao);
        }

        // GET: TbGvduocCuDiDaoTaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdHinhThucThamGiaGvduocCuDiDaoTaoNavigation)
                .Include(t => t.IdNguonKinhPhiCuaGvNavigation)
                .Include(t => t.IdQuocGiaDenNavigation)
                .Include(t => t.IdTinhTrangGvduocCuDiDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGvduocCuDiDaoTao == id);
            if (tbGvduocCuDiDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGvduocCuDiDaoTao);
        }

        // POST: TbGvduocCuDiDaoTaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGvduocCuDiDaoTao = await _context.TbGvduocCuDiDaoTaos.FindAsync(id);
            if (tbGvduocCuDiDaoTao != null)
            {
                _context.TbGvduocCuDiDaoTaos.Remove(tbGvduocCuDiDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGvduocCuDiDaoTaoExists(int id)
        {
            return _context.TbGvduocCuDiDaoTaos.Any(e => e.IdGvduocCuDiDaoTao == id);
        }
    }
}

