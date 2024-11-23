using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CB
{
    public class LinhVucNghienCuuCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public LinhVucNghienCuuCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: LinhVucNghienCuuCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbLinhVucNghienCuuCuaCanBos.Include(t => t.IdCanBoNavigation).ThenInclude(human => human.IdNguoiNavigation).Include(t => t.IdLinhVucNghienCuuNavigation);
            return View(await hemisContext.ToListAsync());
        }
      
        // GET: LinhVucNghienCuuCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .ThenInclude(human => human.IdNguoiNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .FirstOrDefaultAsync(m => m.IdLinhVucNghienCuuCuaCanBo == id);
            if (tbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }
         
            ViewBag.Hoten =
                _context.TbNguois.FirstOrDefault(p => p.IdNguoi == tbLinhVucNghienCuuCuaCanBo.IdCanBoNavigation.IdNguoi).Ho;
                 
            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // GET: LinhVucNghienCuuCuaCanBo/Create
        public IActionResult Create()
        {
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu");
            return View();
        }

        // POST: LinhVucNghienCuuCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLinhVucNghienCuuCuaCanBo,IdCanBo,IdLinhVucNghienCuu,LaLinhVucNghienCuuChuyenSau,SoNamNghienCuu")] TbLinhVucNghienCuuCuaCanBo tbLinhVucNghienCuuCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbLinhVucNghienCuuCuaCanBo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbLinhVucNghienCuuCuaCanBo.IdCanBo);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuu);
            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // GET: LinhVucNghienCuuCuaCanBo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos.FindAsync(id);
            if (tbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbLinhVucNghienCuuCuaCanBo.IdCanBo);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuu);
            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // POST: LinhVucNghienCuuCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLinhVucNghienCuuCuaCanBo,IdCanBo,IdLinhVucNghienCuu,LaLinhVucNghienCuuChuyenSau,SoNamNghienCuu")] TbLinhVucNghienCuuCuaCanBo tbLinhVucNghienCuuCuaCanBo)
        {
            if (id != tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbLinhVucNghienCuuCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbLinhVucNghienCuuCuaCanBoExists(tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuuCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbLinhVucNghienCuuCuaCanBo.IdCanBo);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "IdLinhVucNghienCuu", tbLinhVucNghienCuuCuaCanBo.IdLinhVucNghienCuu);
            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // GET: LinhVucNghienCuuCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .FirstOrDefaultAsync(m => m.IdLinhVucNghienCuuCuaCanBo == id);
            if (tbLinhVucNghienCuuCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbLinhVucNghienCuuCuaCanBo);
        }

        // POST: LinhVucNghienCuuCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbLinhVucNghienCuuCuaCanBo = await _context.TbLinhVucNghienCuuCuaCanBos.FindAsync(id);
            if (tbLinhVucNghienCuuCuaCanBo != null)
            {
                _context.TbLinhVucNghienCuuCuaCanBos.Remove(tbLinhVucNghienCuuCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbLinhVucNghienCuuCuaCanBoExists(int id)
        {
            return _context.TbLinhVucNghienCuuCuaCanBos.Any(e => e.IdLinhVucNghienCuuCuaCanBo == id);
        }
    }
}
