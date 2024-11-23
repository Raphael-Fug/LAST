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
    public class ThongTinViecLamSauTotNghiepController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinViecLamSauTotNghiepController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinViecLamSauTotNghiep
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinViecLamSauTotNghieps.Include(t => t.IdHinhThucTuyenDungNavigation).Include(t => t.IdHocVienNavigation).Include(t => t.IdViTriViecLamNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinViecLamSauTotNghiep/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinViecLamSauTotNghiep = await _context.TbThongTinViecLamSauTotNghieps
                .Include(t => t.IdHinhThucTuyenDungNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdViTriViecLamNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinViecLamSauTotNghiep == id);
            if (tbThongTinViecLamSauTotNghiep == null)
            {
                return NotFound();
            }

            return View(tbThongTinViecLamSauTotNghiep);
        }

        // GET: ThongTinViecLamSauTotNghiep/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucTuyenDung"] = new SelectList(_context.DmHinhThucTuyenDungs, "IdHinhThucTuyenDung", "HinhThucTuyenDung");
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien");
            ViewData["IdViTriViecLam"] = new SelectList(_context.DmViTriViecLams, "IdViTriViecLam", "ViTriViecLam");
            return View();
        }

        // POST: ThongTinViecLamSauTotNghiep/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinViecLamSauTotNghiep,IdHocVien,TenDonViCapBang,DonViTuyenDung,IdHinhThucTuyenDung,ThoiGianTuyenDung,IdViTriViecLam,MucLuongKhoiDiem")] TbThongTinViecLamSauTotNghiep tbThongTinViecLamSauTotNghiep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThongTinViecLamSauTotNghiep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucTuyenDung"] = new SelectList(_context.DmHinhThucTuyenDungs, "IdHinhThucTuyenDung", "HinhThucTuyenDung", tbThongTinViecLamSauTotNghiep.IdHinhThucTuyenDung);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinViecLamSauTotNghiep.IdHocVien);
            ViewData["IdViTriViecLam"] = new SelectList(_context.DmViTriViecLams, "IdViTriViecLam", "ViTriViecLam", tbThongTinViecLamSauTotNghiep.IdViTriViecLam);
            return View(tbThongTinViecLamSauTotNghiep);
        }

        // GET: ThongTinViecLamSauTotNghiep/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinViecLamSauTotNghiep = await _context.TbThongTinViecLamSauTotNghieps.FindAsync(id);
            if (tbThongTinViecLamSauTotNghiep == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucTuyenDung"] = new SelectList(_context.DmHinhThucTuyenDungs, "IdHinhThucTuyenDung", "HinhThucTuyenDung", tbThongTinViecLamSauTotNghiep.IdHinhThucTuyenDung);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinViecLamSauTotNghiep.IdHocVien);
            ViewData["IdViTriViecLam"] = new SelectList(_context.DmViTriViecLams, "IdViTriViecLam", "ViTriViecLam", tbThongTinViecLamSauTotNghiep.IdViTriViecLam);
            return View(tbThongTinViecLamSauTotNghiep);
        }

        // POST: ThongTinViecLamSauTotNghiep/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinViecLamSauTotNghiep,IdHocVien,TenDonViCapBang,DonViTuyenDung,IdHinhThucTuyenDung,ThoiGianTuyenDung,IdViTriViecLam,MucLuongKhoiDiem")] TbThongTinViecLamSauTotNghiep tbThongTinViecLamSauTotNghiep)
        {
            if (id != tbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinViecLamSauTotNghiep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinViecLamSauTotNghiepExists(tbThongTinViecLamSauTotNghiep.IdThongTinViecLamSauTotNghiep))
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
            ViewData["IdHinhThucTuyenDung"] = new SelectList(_context.DmHinhThucTuyenDungs, "IdHinhThucTuyenDung", "HinhThucTuyenDung", tbThongTinViecLamSauTotNghiep.IdHinhThucTuyenDung);
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinViecLamSauTotNghiep.IdHocVien);
            ViewData["IdViTriViecLam"] = new SelectList(_context.DmViTriViecLams, "IdViTriViecLam", "ViTriViecLam", tbThongTinViecLamSauTotNghiep.IdViTriViecLam);
            return View(tbThongTinViecLamSauTotNghiep);
        }

        // GET: ThongTinViecLamSauTotNghiep/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinViecLamSauTotNghiep = await _context.TbThongTinViecLamSauTotNghieps
                .Include(t => t.IdHinhThucTuyenDungNavigation)
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdViTriViecLamNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinViecLamSauTotNghiep == id);
            if (tbThongTinViecLamSauTotNghiep == null)
            {
                return NotFound();
            }

            return View(tbThongTinViecLamSauTotNghiep);
        }

        // POST: ThongTinViecLamSauTotNghiep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinViecLamSauTotNghiep = await _context.TbThongTinViecLamSauTotNghieps.FindAsync(id);
            if (tbThongTinViecLamSauTotNghiep != null)
            {
                _context.TbThongTinViecLamSauTotNghieps.Remove(tbThongTinViecLamSauTotNghiep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinViecLamSauTotNghiepExists(int id)
        {
            return _context.TbThongTinViecLamSauTotNghieps.Any(e => e.IdThongTinViecLamSauTotNghiep == id);
        }
    }
}
