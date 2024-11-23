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
    public class ThongTinNguoiHocGdtcController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinNguoiHocGdtcController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinNguoiHocGdtc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinNguoiHocGdtcs.Include(t => t.IdHocVienNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinNguoiHocGdtc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinNguoiHocGdtc = await _context.TbThongTinNguoiHocGdtcs
                .Include(t => t.IdHocVienNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinNguoiHocGdtc == id);
            if (tbThongTinNguoiHocGdtc == null)
            {
                return NotFound();
            }

            return View(tbThongTinNguoiHocGdtc);
        }

        // GET: ThongTinNguoiHocGdtc/Create
        public IActionResult Create()
        {
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien");
            return View();
        }

        // POST: ThongTinNguoiHocGdtc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinNguoiHocGdtc,IdHocVien,KetQuaHocTap,TieuChuanDanhGiaXepLoaiTheLuc")] TbThongTinNguoiHocGdtc tbThongTinNguoiHocGdtc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThongTinNguoiHocGdtc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinNguoiHocGdtc.IdHocVien);
            return View(tbThongTinNguoiHocGdtc);
        }

        // GET: ThongTinNguoiHocGdtc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinNguoiHocGdtc = await _context.TbThongTinNguoiHocGdtcs.FindAsync(id);
            if (tbThongTinNguoiHocGdtc == null)
            {
                return NotFound();
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinNguoiHocGdtc.IdHocVien);
            return View(tbThongTinNguoiHocGdtc);
        }

        // POST: ThongTinNguoiHocGdtc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinNguoiHocGdtc,IdHocVien,KetQuaHocTap,TieuChuanDanhGiaXepLoaiTheLuc")] TbThongTinNguoiHocGdtc tbThongTinNguoiHocGdtc)
        {
            if (id != tbThongTinNguoiHocGdtc.IdThongTinNguoiHocGdtc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinNguoiHocGdtc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinNguoiHocGdtcExists(tbThongTinNguoiHocGdtc.IdThongTinNguoiHocGdtc))
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
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens, "IdHocVien", "IdHocVien", tbThongTinNguoiHocGdtc.IdHocVien);
            return View(tbThongTinNguoiHocGdtc);
        }

        // GET: ThongTinNguoiHocGdtc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinNguoiHocGdtc = await _context.TbThongTinNguoiHocGdtcs
                .Include(t => t.IdHocVienNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinNguoiHocGdtc == id);
            if (tbThongTinNguoiHocGdtc == null)
            {
                return NotFound();
            }

            return View(tbThongTinNguoiHocGdtc);
        }

        // POST: ThongTinNguoiHocGdtc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinNguoiHocGdtc = await _context.TbThongTinNguoiHocGdtcs.FindAsync(id);
            if (tbThongTinNguoiHocGdtc != null)
            {
                _context.TbThongTinNguoiHocGdtcs.Remove(tbThongTinNguoiHocGdtc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinNguoiHocGdtcExists(int id)
        {
            return _context.TbThongTinNguoiHocGdtcs.Any(e => e.IdThongTinNguoiHocGdtc == id);
        }
    }
}
