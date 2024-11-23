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
    public class GiaHanChuongTrinhDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public GiaHanChuongTrinhDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: GiaHanChuongTrinhDaoTao
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbGiaHanChuongTrinhDaoTaos.Include(t => t.IdChuongTrinhDaoTaoNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: GiaHanChuongTrinhDaoTao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaHanChuongTrinhDaoTao == id);
            if (tbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // GET: GiaHanChuongTrinhDaoTao/Create
        public IActionResult Create()
        {
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao");
            return View();
        }

        // POST: GiaHanChuongTrinhDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGiaHanChuongTrinhDaoTao,IdChuongTrinhDaoTao,SoQuyetDinhGiaHan,NgayBanHanhVanBanGiaHan,GiaHanLanThu")] TbGiaHanChuongTrinhDaoTao tbGiaHanChuongTrinhDaoTao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGiaHanChuongTrinhDaoTao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbGiaHanChuongTrinhDaoTao.IdChuongTrinhDaoTao);
            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // GET: GiaHanChuongTrinhDaoTao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos.FindAsync(id);
            if (tbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbGiaHanChuongTrinhDaoTao.IdChuongTrinhDaoTao);
            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // POST: GiaHanChuongTrinhDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGiaHanChuongTrinhDaoTao,IdChuongTrinhDaoTao,SoQuyetDinhGiaHan,NgayBanHanhVanBanGiaHan,GiaHanLanThu")] TbGiaHanChuongTrinhDaoTao tbGiaHanChuongTrinhDaoTao)
        {
            if (id != tbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGiaHanChuongTrinhDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGiaHanChuongTrinhDaoTaoExists(tbGiaHanChuongTrinhDaoTao.IdGiaHanChuongTrinhDaoTao))
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
            ViewData["IdChuongTrinhDaoTao"] = new SelectList(_context.TbChuongTrinhDaoTaos, "IdChuongTrinhDaoTao", "IdChuongTrinhDaoTao", tbGiaHanChuongTrinhDaoTao.IdChuongTrinhDaoTao);
            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // GET: GiaHanChuongTrinhDaoTao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos
                .Include(t => t.IdChuongTrinhDaoTaoNavigation)
                .FirstOrDefaultAsync(m => m.IdGiaHanChuongTrinhDaoTao == id);
            if (tbGiaHanChuongTrinhDaoTao == null)
            {
                return NotFound();
            }

            return View(tbGiaHanChuongTrinhDaoTao);
        }

        // POST: GiaHanChuongTrinhDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGiaHanChuongTrinhDaoTao = await _context.TbGiaHanChuongTrinhDaoTaos.FindAsync(id);
            if (tbGiaHanChuongTrinhDaoTao != null)
            {
                _context.TbGiaHanChuongTrinhDaoTaos.Remove(tbGiaHanChuongTrinhDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGiaHanChuongTrinhDaoTaoExists(int id)
        {
            return _context.TbGiaHanChuongTrinhDaoTaos.Any(e => e.IdGiaHanChuongTrinhDaoTao == id);
        }
    }
}
