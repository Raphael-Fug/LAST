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
    public class ThongTinHocBongController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinHocBongController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinHocBong
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinHocBongs.Include(t => t.IdHocVienNavigation).Include(t => t.IdLoaiHocBongNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinHocBong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHocBong = await _context.TbThongTinHocBongs
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiHocBongNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinHocBong == id);
            if (tbThongTinHocBong == null)
            {
                return NotFound();
            }

            return View(tbThongTinHocBong);
        }

        // GET: ThongTinHocBong/Create
        public IActionResult Create()
        {
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien");
            ViewData["IdLoaiHocBong"] = new SelectList(_context.DmLoaiHocBongs, "IdLoaiHocBong", "LoaiHocBong");
            return View();
        }

        // POST: ThongTinHocBong/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinHocBong,IdHocVien,TenHocBong,DonViTaiTro,ThoiGianTraoTangHocBong,IdLoaiHocBong,GiaTriHocBong")] TbThongTinHocBong tbThongTinHocBong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThongTinHocBong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinHocBong.IdHocVien);
            ViewData["IdLoaiHocBong"] = new SelectList(_context.DmLoaiHocBongs, "IdLoaiHocBong", "LoaiHocBong", tbThongTinHocBong.IdLoaiHocBong);
            return View(tbThongTinHocBong);
        }

        // GET: ThongTinHocBong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHocBong = await _context.TbThongTinHocBongs.FindAsync(id);
            if (tbThongTinHocBong == null)
            {
                return NotFound();
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinHocBong.IdHocVien);
            ViewData["IdLoaiHocBong"] = new SelectList(_context.DmLoaiHocBongs, "IdLoaiHocBong", "LoaiHocBong", tbThongTinHocBong.IdLoaiHocBong);
            return View(tbThongTinHocBong);
        }

        // POST: ThongTinHocBong/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinHocBong,IdHocVien,TenHocBong,DonViTaiTro,ThoiGianTraoTangHocBong,IdLoaiHocBong,GiaTriHocBong")] TbThongTinHocBong tbThongTinHocBong)
        {
            if (id != tbThongTinHocBong.IdThongTinHocBong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinHocBong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinHocBongExists(tbThongTinHocBong.IdThongTinHocBong))
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
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinHocBong.IdHocVien);
            ViewData["IdLoaiHocBong"] = new SelectList(_context.DmLoaiHocBongs, "IdLoaiHocBong", "LoaiHocBong", tbThongTinHocBong.IdLoaiHocBong);
            return View(tbThongTinHocBong);
        }

        // GET: ThongTinHocBong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinHocBong = await _context.TbThongTinHocBongs
                .Include(t => t.IdHocVienNavigation)
                .Include(t => t.IdLoaiHocBongNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinHocBong == id);
            if (tbThongTinHocBong == null)
            {
                return NotFound();
            }

            return View(tbThongTinHocBong);
        }

        // POST: ThongTinHocBong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinHocBong = await _context.TbThongTinHocBongs.FindAsync(id);
            if (tbThongTinHocBong != null)
            {
                _context.TbThongTinHocBongs.Remove(tbThongTinHocBong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinHocBongExists(int id)
        {
            return _context.TbThongTinHocBongs.Any(e => e.IdThongTinHocBong == id);
        }
    }
}
