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
    public class TapChiKhoaHocController : Controller
    {
        private readonly HemisContext _context;

        public TapChiKhoaHocController(HemisContext context)
        {
            _context = context;
        }

        // GET: TapChiKhoaHoc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbTapChiKhoaHocs.Include(t => t.IdLinhVucXuatBanNavigation).Include(t => t.IdXepLoaiTapChiNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TapChiKhoaHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs
                .Include(t => t.IdLinhVucXuatBanNavigation)
                .Include(t => t.IdXepLoaiTapChiNavigation)
                .FirstOrDefaultAsync(m => m.IdTapChiKhoaHoc == id);
            if (tbTapChiKhoaHoc == null)
            {
                return NotFound();
            }

            return View(tbTapChiKhoaHoc);
        }

        // GET: TapChiKhoaHoc/Create
        public IActionResult Create()
        {
            ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu");
            ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "IdTapChiTrongNuoc");
            return View();
        }

        // POST: TapChiKhoaHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTapChiKhoaHoc,MaTapChi,TenTapChiTiengViet,TenTapChiTiengAnh,MaChuanIssn,IdLinhVucXuatBan,IdXepLoaiTapChi,SoBaiBao1Nam")] TbTapChiKhoaHoc tbTapChiKhoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTapChiKhoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbTapChiKhoaHoc.IdLinhVucXuatBan);
            ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "IdTapChiTrongNuoc", tbTapChiKhoaHoc.IdXepLoaiTapChi);
            return View(tbTapChiKhoaHoc);
        }

        // GET: TapChiKhoaHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs.FindAsync(id);
            if (tbTapChiKhoaHoc == null)
            {
                return NotFound();
            }
            ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbTapChiKhoaHoc.IdLinhVucXuatBan);
            ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "IdTapChiTrongNuoc", tbTapChiKhoaHoc.IdXepLoaiTapChi);
            return View(tbTapChiKhoaHoc);
        }

        // POST: TapChiKhoaHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTapChiKhoaHoc,MaTapChi,TenTapChiTiengViet,TenTapChiTiengAnh,MaChuanIssn,IdLinhVucXuatBan,IdXepLoaiTapChi,SoBaiBao1Nam")] TbTapChiKhoaHoc tbTapChiKhoaHoc)
        {
            if (id != tbTapChiKhoaHoc.IdTapChiKhoaHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTapChiKhoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTapChiKhoaHocExists(tbTapChiKhoaHoc.IdTapChiKhoaHoc))
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
            ViewData["IdLinhVucXuatBan"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbTapChiKhoaHoc.IdLinhVucXuatBan);
            ViewData["IdXepLoaiTapChi"] = new SelectList(_context.DmTapChiTrongNuocs, "IdTapChiTrongNuoc", "IdTapChiTrongNuoc", tbTapChiKhoaHoc.IdXepLoaiTapChi);
            return View(tbTapChiKhoaHoc);
        }

        // GET: TapChiKhoaHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs
                .Include(t => t.IdLinhVucXuatBanNavigation)
                .Include(t => t.IdXepLoaiTapChiNavigation)
                .FirstOrDefaultAsync(m => m.IdTapChiKhoaHoc == id);
            if (tbTapChiKhoaHoc == null)
            {
                return NotFound();
            }

            return View(tbTapChiKhoaHoc);
        }

        // POST: TapChiKhoaHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTapChiKhoaHoc = await _context.TbTapChiKhoaHocs.FindAsync(id);
            if (tbTapChiKhoaHoc != null)
            {
                _context.TbTapChiKhoaHocs.Remove(tbTapChiKhoaHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTapChiKhoaHocExists(int id)
        {
            return _context.TbTapChiKhoaHocs.Any(e => e.IdTapChiKhoaHoc == id);
        }
    }
}
