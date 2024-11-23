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
    public class ThongTinViPhamController : Controller
    {
        private readonly HemisContext _context;

        public ThongTinViPhamController(HemisContext context)
        {
            _context = context;
        }

        // GET: ThongTinViPham
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbThongTinViPhams
                .Include(t => t.IdHocVienNavigation)
                .ThenInclude(t => t.IdNguoiNavigation)
                .Include(t => t.IdLoaiViPhamNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ThongTinViPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinViPham = await _context.TbThongTinViPhams
                .Include(t => t.IdHocVienNavigation)
                .ThenInclude(t => t.IdNguoiNavigation)
                .Include(t => t.IdLoaiViPhamNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinViPham == id);
            if (tbThongTinViPham == null)
            {
                return NotFound();
            }

            return View(tbThongTinViPham);
        }

        // GET: ThongTinViPham/Create
        public IActionResult Create()
        {
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(t => t.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name");
            ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham");
            return View();
        }

        // POST: ThongTinViPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdThongTinViPham,IdHocVien,ThoiGianViPham,NoiDungViPham,HinhThucXuLy,IdLoaiViPham")] TbThongTinViPham tbThongTinViPham)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tbThongTinViPham);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ViewBag.ErrorMessage = "Lỗi cơ sở dữ liệu: " + ex.Message;
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Lỗi không xác định: " + ex.Message;
                }
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(t => t.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbThongTinViPham.IdHocVien);
            ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
            return View(tbThongTinViPham);
        }

        // GET: ThongTinViPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinViPham = await _context.TbThongTinViPhams.FindAsync(id);
            if (tbThongTinViPham == null)
            {
                return NotFound();
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(t => t.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbThongTinViPham.IdHocVien);
            ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
            return View(tbThongTinViPham);
        }

        // POST: ThongTinViPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdThongTinViPham,IdHocVien,ThoiGianViPham,NoiDungViPham,HinhThucXuLy,IdLoaiViPham")] TbThongTinViPham tbThongTinViPham)
        {
            if (id != tbThongTinViPham.IdThongTinViPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbThongTinViPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbThongTinViPhamExists(tbThongTinViPham.IdThongTinViPham))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Lỗi không xác định: " + ex.Message;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHocVien"] = new SelectList(_context.TbHocViens.Include(t => t.IdNguoiNavigation), "IdHocVien", "IdNguoiNavigation.name", tbThongTinViPham.IdHocVien);
            ViewData["IdLoaiViPham"] = new SelectList(_context.DmLoaiViPhams, "IdLoaiViPham", "LoaiViPham", tbThongTinViPham.IdLoaiViPham);
            return View(tbThongTinViPham);
        }

        // GET: ThongTinViPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbThongTinViPham = await _context.TbThongTinViPhams
                .Include(t => t.IdHocVienNavigation)
                .ThenInclude(t => t.IdNguoiNavigation)
                .Include(t => t.IdLoaiViPhamNavigation)
                .FirstOrDefaultAsync(m => m.IdThongTinViPham == id);
            if (tbThongTinViPham == null)
            {
                return NotFound();
            }

            return View(tbThongTinViPham);
        }

        // POST: ThongTinViPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbThongTinViPham = await _context.TbThongTinViPhams.FindAsync(id);
            if (tbThongTinViPham != null)
            {
                _context.TbThongTinViPhams.Remove(tbThongTinViPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbThongTinViPhamExists(int id)
        {
            return _context.TbThongTinViPhams.Any(e => e.IdThongTinViPham == id);
        }
    }
}
