using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.CSGD
{
    public class DonViLienKetDaoTaoGiaoDucController : Controller
    {
        private readonly HemisContext _context;

        public DonViLienKetDaoTaoGiaoDucController(HemisContext context)
        {
            _context = context;
        }

        // GET: DonViLienKetDaoTaoGiaoDuc
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbDonViLienKetDaoTaoGiaoDucs.Include(t => t.IdCoSoGiaoDucNavigation).Include(t => t.IdLoaiLienKetNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs
                .Include(t => t.IdCoSoGiaoDucNavigation)
                .Include(t => t.IdLoaiLienKetNavigation)
                .FirstOrDefaultAsync(m => m.IdDonViLienKetDaoTaoGiaoDuc == id);
            if (tbDonViLienKetDaoTaoGiaoDuc == null)
            {
                return NotFound();
            }

            return View(tbDonViLienKetDaoTaoGiaoDuc);
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Create
        public IActionResult Create()
        {
            ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "IdCoSoGiaoDuc");
            ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "IdLoaiLienKet");
            return View();
        }

        // POST: DonViLienKetDaoTaoGiaoDuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDonViLienKetDaoTaoGiaoDuc,IdCoSoGiaoDuc,DiaChi,DienThoai,IdLoaiLienKet")] TbDonViLienKetDaoTaoGiaoDuc tbDonViLienKetDaoTaoGiaoDuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbDonViLienKetDaoTaoGiaoDuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "IdCoSoGiaoDuc", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
            ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "IdLoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
            return View(tbDonViLienKetDaoTaoGiaoDuc);
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs.FindAsync(id);
            if (tbDonViLienKetDaoTaoGiaoDuc == null)
            {
                return NotFound();
            }
            ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "IdCoSoGiaoDuc", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
            ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "IdLoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
            return View(tbDonViLienKetDaoTaoGiaoDuc);
        }

        // POST: DonViLienKetDaoTaoGiaoDuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDonViLienKetDaoTaoGiaoDuc,IdCoSoGiaoDuc,DiaChi,DienThoai,IdLoaiLienKet")] TbDonViLienKetDaoTaoGiaoDuc tbDonViLienKetDaoTaoGiaoDuc)
        {
            if (id != tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDonViLienKetDaoTaoGiaoDuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbDonViLienKetDaoTaoGiaoDucExists(tbDonViLienKetDaoTaoGiaoDuc.IdDonViLienKetDaoTaoGiaoDuc))
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
            ViewData["IdCoSoGiaoDuc"] = new SelectList(_context.TbCoSoGiaoDucs, "IdCoSoGiaoDuc", "IdCoSoGiaoDuc", tbDonViLienKetDaoTaoGiaoDuc.IdCoSoGiaoDuc);
            ViewData["IdLoaiLienKet"] = new SelectList(_context.DmLoaiLienKets, "IdLoaiLienKet", "IdLoaiLienKet", tbDonViLienKetDaoTaoGiaoDuc.IdLoaiLienKet);
            return View(tbDonViLienKetDaoTaoGiaoDuc);
        }

        // GET: DonViLienKetDaoTaoGiaoDuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs
                .Include(t => t.IdCoSoGiaoDucNavigation)
                .Include(t => t.IdLoaiLienKetNavigation)
                .FirstOrDefaultAsync(m => m.IdDonViLienKetDaoTaoGiaoDuc == id);
            if (tbDonViLienKetDaoTaoGiaoDuc == null)
            {
                return NotFound();
            }

            return View(tbDonViLienKetDaoTaoGiaoDuc);
        }

        // POST: DonViLienKetDaoTaoGiaoDuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDonViLienKetDaoTaoGiaoDuc = await _context.TbDonViLienKetDaoTaoGiaoDucs.FindAsync(id);
            if (tbDonViLienKetDaoTaoGiaoDuc != null)
            {
                _context.TbDonViLienKetDaoTaoGiaoDucs.Remove(tbDonViLienKetDaoTaoGiaoDuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbDonViLienKetDaoTaoGiaoDucExists(int id)
        {
            return _context.TbDonViLienKetDaoTaoGiaoDucs.Any(e => e.IdDonViLienKetDaoTaoGiaoDuc == id);
        }
    }
}
