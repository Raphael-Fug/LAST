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
    public class DatDaiController : Controller
    {
        private readonly HemisContext _context;

        public DatDaiController(HemisContext context)
        {
            _context = context;
        }

        // GET: DatDai
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDatDais.Include(t => t.IdHinhThucSoHuuNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DatDai/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDatDai = await _context.TbDatDais
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .FirstOrDefaultAsync(m => m.IdDatDai == id);
            if (tbDatDai == null)
            {
                return NotFound();
            }

            return View(tbDatDai);
        }

        // GET: DatDai/Create
        public IActionResult Create()
        {
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu");
            return View();
        }

        // POST: DatDai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDatDai,MaGiayChungNhanQuyenSoHuu,DienTichDat,IdHinhThucSoHuu,TenDonViSoHuu,MinhChungQuyenSoHuuDatDai,MucDichSuDungDat,NamBatDauSuDungDat,ThoiGianSuDungDat,DienTichDatDaSuDung")] TbDatDai tbDatDai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDatDai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbDatDai.IdHinhThucSoHuu);
            return View(tbDatDai);
        }

        // GET: DatDai/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDatDai = await _context.TbDatDais.FindAsync(id);
            if (tbDatDai == null)
            {
                return NotFound();
            }
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbDatDai.IdHinhThucSoHuu);
            return View(tbDatDai);
        }

        // POST: DatDai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDatDai,MaGiayChungNhanQuyenSoHuu,DienTichDat,IdHinhThucSoHuu,TenDonViSoHuu,MinhChungQuyenSoHuuDatDai,MucDichSuDungDat,NamBatDauSuDungDat,ThoiGianSuDungDat,DienTichDatDaSuDung")] TbDatDai tbDatDai)
        {
            if (id != tbDatDai.IdDatDai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDatDai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDatDaiExists(tbDatDai.IdDatDai))
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
            ViewData["IdHinhThucSoHuu"] = new SelectList(_context.DmHinhThucSoHuus, "IdHinhThucSoHuu", "IdHinhThucSoHuu", tbDatDai.IdHinhThucSoHuu);
            return View(tbDatDai);
        }

        // GET: DatDai/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDatDai = await _context.TbDatDais
                .Include(t => t.IdHinhThucSoHuuNavigation)
                .FirstOrDefaultAsync(m => m.IdDatDai == id);
            if (tbDatDai == null)
            {
                return NotFound();
            }

            return View(tbDatDai);
        }

        // POST: DatDai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDatDai = await _context.TbDatDais.FindAsync(id);
            if (tbDatDai != null)
            {
                _context.TbDatDais.Remove(tbDatDai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDatDaiExists(int id)
        {
            return _context.TbDatDais.Any(e => e.IdDatDai == id);
        }
    }
}
