using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CTDT
{
    public class ThongTinKiemDinhCuaChuongTrinhController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinKiemDinhCuaChuongTrinhController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinKiemDinhCuaChuongTrinhs.Include(t => t.IdChuongTrinhDaoTaoNavigation).Include(t => t.IdKetQuaKiemDinhNavigation).Include(t => t.IdToChucKiemDinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdKetQuaKiemDinhNavigation)
                .Include(t => t.IdToChucKiemDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinKiemDinhCuaChuongTrinh == id);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao");
            ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh");
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh");
            return View();
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinKiemDinhCuaChuongTrinh,IdChuongTrinhDaoTao,IdToChucKiemDinh,IdKetQuaKiemDinh,SoQuyetDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbThongTinKiemDinhCuaChuongTrinh tbThongTinKiemDinhCuaChuongTrinh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbThongTinKiemDinhCuaChuongTrinh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
            ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
            ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinKiemDinhCuaChuongTrinh,IdChuongTrinhDaoTao,IdToChucKiemDinh,IdKetQuaKiemDinh,SoQuyetDinh,NgayCapChungNhanKiemDinh,ThoiHanKiemDinh")] TbThongTinKiemDinhCuaChuongTrinh tbThongTinKiemDinhCuaChuongTrinh)
        {
            if (id != tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinKiemDinhCuaChuongTrinh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinKiemDinhCuaChuongTrinhExists(tbThongTinKiemDinhCuaChuongTrinh.IdThongTinKiemDinhCuaChuongTrinh))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbThongTinKiemDinhCuaChuongTrinh.IdChuongTrinhDaoTao);
            ViewData["IdKetQuaKiemDinh"] = new SelectList(_context.DmKetQuaKiemDinhs, "IdKetQuaKiemDinh", "IdKetQuaKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdKetQuaKiemDinh);
            ViewData["IdToChucKiemDinh"] = new SelectList(_context.DmToChucKiemDinhs, "IdToChucKiemDinh", "IdToChucKiemDinh", tbThongTinKiemDinhCuaChuongTrinh.IdToChucKiemDinh);
            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // GET: ThongTinKiemDinhCuaChuongTrinh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .Include(t => t.IdKetQuaKiemDinhNavigation)
                .Include(t => t.IdToChucKiemDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinKiemDinhCuaChuongTrinh == id);
            if (tbThongTinKiemDinhCuaChuongTrinh == null)
            {
                return NotFound();
            }

            return View(tbThongTinKiemDinhCuaChuongTrinh);
        }

        // POST: ThongTinKiemDinhCuaChuongTrinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinKiemDinhCuaChuongTrinh = await _context.TbThongTinKiemDinhCuaChuongTrinhs.FindAsync(id);
            if (tbThongTinKiemDinhCuaChuongTrinh != null)
            {
                _context.TbThongTinKiemDinhCuaChuongTrinhs.Remove(tbThongTinKiemDinhCuaChuongTrinh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinKiemDinhCuaChuongTrinhExists(int id)
        {
            return _context.TbThongTinKiemDinhCuaChuongTrinhs.Any(e => e.IdThongTinKiemDinhCuaChuongTrinh == id);
        }
    }
}
