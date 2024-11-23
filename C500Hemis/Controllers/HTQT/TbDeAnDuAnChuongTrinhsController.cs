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
    public class TbDeAnDuAnChuongTrinhsController : Controller
    {
        private readonly HemisContext _context;

        public TbDeAnDuAnChuongTrinhsController(HemisContext context)
        {
            _context = context;
        }

        // GET: TbDeAnDuAnChuongTrinhs
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDeAnDuAnChuongTrinhs.Include(t => t.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TbDeAnDuAnChuongTrinhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs
                .Include(t => t.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation)
                .FirstOrDefaultAsync(m => m.IdDeAnDuAnChuongTrinh == id);
            if (tbDeAnDuAnChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbDeAnDuAnChuongTrinh);
        }

        // GET: TbDeAnDuAnChuongTrinhs/Create
        public IActionResult Create()
        {
            ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "IdNguonKinhPhiChoDeAn");
            return View();
        }

        // POST: TbDeAnDuAnChuongTrinhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDeAnDuAnChuongTrinh,MaDeAnDuAnChuongTrinh,TenDeAnDuAnChuongTrinh,NoiDungTomTat,MucTieu,ThoiGianHopTacTu,ThoiGianHopTacDen,TongKinhPhi,IdNguonKinhPhiDeAnDuAnChuongTrinh")] TbDeAnDuAnChuongTrinh tbDeAnDuAnChuongTrinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDeAnDuAnChuongTrinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "IdNguonKinhPhiChoDeAn", tbDeAnDuAnChuongTrinh.IdNguonKinhPhiDeAnDuAnChuongTrinh);
            return View(tbDeAnDuAnChuongTrinh);
        }

        // GET: TbDeAnDuAnChuongTrinhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs.FindAsync(id);
            if (tbDeAnDuAnChuongTrinh == null)
            {
                return NotFound();
            }
            ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "IdNguonKinhPhiChoDeAn", tbDeAnDuAnChuongTrinh.IdNguonKinhPhiDeAnDuAnChuongTrinh);
            return View(tbDeAnDuAnChuongTrinh);
        }

        // POST: TbDeAnDuAnChuongTrinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDeAnDuAnChuongTrinh,MaDeAnDuAnChuongTrinh,TenDeAnDuAnChuongTrinh,NoiDungTomTat,MucTieu,ThoiGianHopTacTu,ThoiGianHopTacDen,TongKinhPhi,IdNguonKinhPhiDeAnDuAnChuongTrinh")] TbDeAnDuAnChuongTrinh tbDeAnDuAnChuongTrinh)
        {
            if (id != tbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDeAnDuAnChuongTrinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDeAnDuAnChuongTrinhExists(tbDeAnDuAnChuongTrinh.IdDeAnDuAnChuongTrinh))
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
            ViewData["IdNguonKinhPhiDeAnDuAnChuongTrinh"] = new SelectList(_context.DmNguonKinhPhiChoDeAns, "IdNguonKinhPhiChoDeAn", "IdNguonKinhPhiChoDeAn", tbDeAnDuAnChuongTrinh.IdNguonKinhPhiDeAnDuAnChuongTrinh);
            return View(tbDeAnDuAnChuongTrinh);
        }

        // GET: TbDeAnDuAnChuongTrinhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs
                .Include(t => t.IdNguonKinhPhiDeAnDuAnChuongTrinhNavigation)
                .FirstOrDefaultAsync(m => m.IdDeAnDuAnChuongTrinh == id);
            if (tbDeAnDuAnChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbDeAnDuAnChuongTrinh);
        }

        // POST: TbDeAnDuAnChuongTrinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDeAnDuAnChuongTrinh = await _context.TbDeAnDuAnChuongTrinhs.FindAsync(id);
            if (tbDeAnDuAnChuongTrinh != null)
            {
                _context.TbDeAnDuAnChuongTrinhs.Remove(tbDeAnDuAnChuongTrinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDeAnDuAnChuongTrinhExists(int id)
        {
            return _context.TbDeAnDuAnChuongTrinhs.Any(e => e.IdDeAnDuAnChuongTrinh == id);
        }
    }
}
