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
    public class TbDoanCongTacsController : Controller
    {
        private readonly HemisContext _context;

        public TbDoanCongTacsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbDoanCongTacs
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDoanCongTacs.Include(t => t.IdPhanLoaiDoanRaDoanVaoNavigation).Include(t => t.IdQuocGiaDoanNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbDoanCongTacs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoanCongTac = await _context.TbDoanCongTacs
                .Include(t => t.IdPhanLoaiDoanRaDoanVaoNavigation)
                .Include(t => t.IdQuocGiaDoanNavigation)
                .FirstOrDefaultAsync(m => m.IdDoanCongTac == id);
            if (tbDoanCongTac == null)
            {
                return NotFound();
            }

            return View(tbDoanCongTac);
        }

        /// <summary>
        /// hàm khởi tạo
        /// </summary> tạo danh sách 
        /// <returns></returns> 
        public IActionResult Create()
        {
            ViewData["IdPhanLoaiDoanRaDoanVao"] = new SelectList(_context.DmPhanLoaiDoanRaDoanVaos, "IdPhanLoaiDoanRaDoanVao", "IdPhanLoaiDoanRaDoanVao");
            ViewData["IdQuocGiaDoan"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich");
            return View();
        }

        // POST: TbDoanCongTacs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoanCongTac,MaDoanCongTac,IdPhanLoaiDoanRaDoanVao,TenDoanCongTac,SoQuyetDinh,NgayQuyetDinh,IdQuocGiaDoan,ThoiGianBatDau,ThoiGianketThuc,MucDichCongTac,KetQuaCongTac")] TbDoanCongTac tbDoanCongTac)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDoanCongTac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPhanLoaiDoanRaDoanVao"] = new SelectList(_context.DmPhanLoaiDoanRaDoanVaos, "IdPhanLoaiDoanRaDoanVao", "IdPhanLoaiDoanRaDoanVao", tbDoanCongTac.IdPhanLoaiDoanRaDoanVao);
            ViewData["IdQuocGiaDoan"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbDoanCongTac.IdQuocGiaDoan);
            return View(tbDoanCongTac);
        }

        // GET: TbDoanCongTacs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoanCongTac = await _context.TbDoanCongTacs.FindAsync(id);
            if (tbDoanCongTac == null)
            {
                return NotFound();
            }
            ViewData["IdPhanLoaiDoanRaDoanVao"] = new SelectList(_context.DmPhanLoaiDoanRaDoanVaos, "IdPhanLoaiDoanRaDoanVao", "IdPhanLoaiDoanRaDoanVao", tbDoanCongTac.IdPhanLoaiDoanRaDoanVao);
            ViewData["IdQuocGiaDoan"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbDoanCongTac.IdQuocGiaDoan);
            return View(tbDoanCongTac);
        }

        // POST: TbDoanCongTacs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoanCongTac,MaDoanCongTac,IdPhanLoaiDoanRaDoanVao,TenDoanCongTac,SoQuyetDinh,NgayQuyetDinh,IdQuocGiaDoan,ThoiGianBatDau,ThoiGianketThuc,MucDichCongTac,KetQuaCongTac")] TbDoanCongTac tbDoanCongTac)
        {
            if (id != tbDoanCongTac.IdDoanCongTac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDoanCongTac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDoanCongTacExists(tbDoanCongTac.IdDoanCongTac))
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
            ViewData["IdPhanLoaiDoanRaDoanVao"] = new SelectList(_context.DmPhanLoaiDoanRaDoanVaos, "IdPhanLoaiDoanRaDoanVao", "IdPhanLoaiDoanRaDoanVao", tbDoanCongTac.IdPhanLoaiDoanRaDoanVao);
            ViewData["IdQuocGiaDoan"] = new SelectList(_context.DmQuocTiches, "IdQuocTich", "IdQuocTich", tbDoanCongTac.IdQuocGiaDoan);
            return View(tbDoanCongTac);
        }

        // GET: TbDoanCongTacs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDoanCongTac = await _context.TbDoanCongTacs
                .Include(t => t.IdPhanLoaiDoanRaDoanVaoNavigation)
                .Include(t => t.IdQuocGiaDoanNavigation)
                .FirstOrDefaultAsync(m => m.IdDoanCongTac == id);
            if (tbDoanCongTac == null)
            {
                return NotFound();
            }

            return View(tbDoanCongTac);
        }

        // POST: TbDoanCongTacs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDoanCongTac = await _context.TbDoanCongTacs.FindAsync(id);
            if (tbDoanCongTac != null)
            {
                _context.TbDoanCongTacs.Remove(tbDoanCongTac);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDoanCongTacExists(int id)
        {
            return _context.TbDoanCongTacs.Any(e => e.IdDoanCongTac == id);
        }
    }
}
