using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.TCTS
{
    public class KhoanTrichLapQuyController : Controller
    {
        private readonly HemisContext _context;

        public KhoanTrichLapQuyController(HemisContext context)
        {
            _context = context;
        }

        // GET: KhoanTrichLapQuy
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbKhoanTrichLapQuies.ToListAsync());
        }

        // GET: KhoanTrichLapQuy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies
                .FirstOrDefaultAsync(m => m.IdKhoanTrichLapQuy == id);
            if (tbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            return View(tbKhoanTrichLapQuy);
        }

        // GET: KhoanTrichLapQuy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhoanTrichLapQuy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKhoanTrichLapQuy,MaKhoanTrichLapQuy,TenKhoanTrichLapQuy,NamTaiChinh,SoTien")] TbKhoanTrichLapQuy tbKhoanTrichLapQuy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbKhoanTrichLapQuy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbKhoanTrichLapQuy);
        }

        // GET: KhoanTrichLapQuy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies.FindAsync(id);
            if (tbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }
            return View(tbKhoanTrichLapQuy);
        }

        // POST: KhoanTrichLapQuy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKhoanTrichLapQuy,MaKhoanTrichLapQuy,TenKhoanTrichLapQuy,NamTaiChinh,SoTien")] TbKhoanTrichLapQuy tbKhoanTrichLapQuy)
        {
            if (id != tbKhoanTrichLapQuy.IdKhoanTrichLapQuy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbKhoanTrichLapQuy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbKhoanTrichLapQuyExists(tbKhoanTrichLapQuy.IdKhoanTrichLapQuy))
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
            return View(tbKhoanTrichLapQuy);
        }

        // GET: KhoanTrichLapQuy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies
                .FirstOrDefaultAsync(m => m.IdKhoanTrichLapQuy == id);
            if (tbKhoanTrichLapQuy == null)
            {
                return NotFound();
            }

            return View(tbKhoanTrichLapQuy);
        }

        // POST: KhoanTrichLapQuy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbKhoanTrichLapQuy = await _context.TbKhoanTrichLapQuies.FindAsync(id);
            if (tbKhoanTrichLapQuy != null)
            {
                _context.TbKhoanTrichLapQuies.Remove(tbKhoanTrichLapQuy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbKhoanTrichLapQuyExists(int id)
        {
            return _context.TbKhoanTrichLapQuies.Any(e => e.IdKhoanTrichLapQuy == id);
        }
    }
}
