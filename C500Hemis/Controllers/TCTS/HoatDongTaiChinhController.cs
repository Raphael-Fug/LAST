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
    public class HoatDongTaiChinhController : Controller
    {
        private readonly HemisContext _context;

        public HoatDongTaiChinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: HoatDongTaiChinh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbHoatDongTaiChinhs.Include(t => t.IdLoaiHoatDongTaiChinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: HoatDongTaiChinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs
                .Include(t => t.IdLoaiHoatDongTaiChinhNavigation)
                .FirstOrDefaultAsync(m => m.IdHoatDongTaiChinh == id);
            if (tbHoatDongTaiChinh == null)
            {
                return NotFound();
            }

            return View(tbHoatDongTaiChinh);
        }

        // GET: HoatDongTaiChinh/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "IdHoatDongTaiChinh");
            return View();
        }

        // POST: HoatDongTaiChinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHoatDongTaiChinh,IdLoaiHoatDongTaiChinh,NamTaiChinh,KinhPhi,NoiDung")] TbHoatDongTaiChinh tbHoatDongTaiChinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbHoatDongTaiChinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "IdHoatDongTaiChinh", tbHoatDongTaiChinh.IdLoaiHoatDongTaiChinh);
            return View(tbHoatDongTaiChinh);
        }

        // GET: HoatDongTaiChinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs.FindAsync(id);
            if (tbHoatDongTaiChinh == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "IdHoatDongTaiChinh", tbHoatDongTaiChinh.IdLoaiHoatDongTaiChinh);
            return View(tbHoatDongTaiChinh);
        }

        // POST: HoatDongTaiChinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHoatDongTaiChinh,IdLoaiHoatDongTaiChinh,NamTaiChinh,KinhPhi,NoiDung")] TbHoatDongTaiChinh tbHoatDongTaiChinh)
        {
            if (id != tbHoatDongTaiChinh.IdHoatDongTaiChinh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbHoatDongTaiChinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbHoatDongTaiChinhExists(tbHoatDongTaiChinh.IdHoatDongTaiChinh))
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
            ViewData["IdLoaiHoatDongTaiChinh"] = new SelectList(_context.DmHoatDongTaiChinhs, "IdHoatDongTaiChinh", "IdHoatDongTaiChinh", tbHoatDongTaiChinh.IdLoaiHoatDongTaiChinh);
            return View(tbHoatDongTaiChinh);
        }

        // GET: HoatDongTaiChinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs
                .Include(t => t.IdLoaiHoatDongTaiChinhNavigation)
                .FirstOrDefaultAsync(m => m.IdHoatDongTaiChinh == id);
            if (tbHoatDongTaiChinh == null)
            {
                return NotFound();
            }

            return View(tbHoatDongTaiChinh);
        }

        // POST: HoatDongTaiChinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbHoatDongTaiChinh = await _context.TbHoatDongTaiChinhs.FindAsync(id);
            if (tbHoatDongTaiChinh != null)
            {
                _context.TbHoatDongTaiChinhs.Remove(tbHoatDongTaiChinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbHoatDongTaiChinhExists(int id)
        {
            return _context.TbHoatDongTaiChinhs.Any(e => e.IdHoatDongTaiChinh == id);
        }
    }
}
