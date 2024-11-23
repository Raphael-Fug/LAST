using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using C500Hemis.Models;

namespace C500Hemis.Controllers.KHCN
{
    public class TaiSanTriTueController : Controller
    {
        private readonly HemisContext _context;

        public TaiSanTriTueController(HemisContext context)
        {
            _context = context;
        }

        // GET: TaiSanTriTue
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbTaiSanTriTues.Include(t => t.IdLoaiTaiSanTriTueNavigation).Include(t => t.IdNhiemVuKhcnNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: TaiSanTriTue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                .Include(t => t.IdLoaiTaiSanTriTueNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id);
            if (tbTaiSanTriTue == null)
            {
                return NotFound();
            }

            return View(tbTaiSanTriTue);
        }

        // GET: TaiSanTriTue/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "IdLoaiTaiSanTriTue");
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn");
            return View();
        }

        // POST: TaiSanTriTue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTaiSanTriTue,IdNhiemVuKhcn,MaGiaiPhapSangChe,TenTaiSanTriTue,ToChucCapBangGiayChungNhan,IdLoaiTaiSanTriTue,NgayCapBangGiayChungNhan,ToChucCapBang,SoBang,NgayCap,SoDon,NgayNopDon,QuyetDinhCapBangGiayChungNhan,CongBoBang,Ipc,ChuSoHuu,TacGiaSangCheGiaiPhap,TomTatNoiDungTaiSanTriTue,NguoiChuTri,NamDuocChapNhanDonHopLe")] TbTaiSanTriTue tbTaiSanTriTue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTaiSanTriTue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "IdLoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbTaiSanTriTue.IdNhiemVuKhcn);
            return View(tbTaiSanTriTue);
        }

        // GET: TaiSanTriTue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);
            if (tbTaiSanTriTue == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "IdLoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbTaiSanTriTue.IdNhiemVuKhcn);
            return View(tbTaiSanTriTue);
        }

        // POST: TaiSanTriTue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTaiSanTriTue,IdNhiemVuKhcn,MaGiaiPhapSangChe,TenTaiSanTriTue,ToChucCapBangGiayChungNhan,IdLoaiTaiSanTriTue,NgayCapBangGiayChungNhan,ToChucCapBang,SoBang,NgayCap,SoDon,NgayNopDon,QuyetDinhCapBangGiayChungNhan,CongBoBang,Ipc,ChuSoHuu,TacGiaSangCheGiaiPhap,TomTatNoiDungTaiSanTriTue,NguoiChuTri,NamDuocChapNhanDonHopLe")] TbTaiSanTriTue tbTaiSanTriTue)
        {
            if (id != tbTaiSanTriTue.IdTaiSanTriTue)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTaiSanTriTue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTaiSanTriTueExists(tbTaiSanTriTue.IdTaiSanTriTue))
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
            ViewData["IdLoaiTaiSanTriTue"] = new SelectList(_context.DmLoaiTaiSanTriTues, "IdLoaiTaiSanTriTue", "IdLoaiTaiSanTriTue", tbTaiSanTriTue.IdLoaiTaiSanTriTue);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "IdNhiemVuKhcn", tbTaiSanTriTue.IdNhiemVuKhcn);
            return View(tbTaiSanTriTue);
        }

        // GET: TaiSanTriTue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTaiSanTriTue = await _context.TbTaiSanTriTues
                .Include(t => t.IdLoaiTaiSanTriTueNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .FirstOrDefaultAsync(m => m.IdTaiSanTriTue == id);
            if (tbTaiSanTriTue == null)
            {
                return NotFound();
            }

            return View(tbTaiSanTriTue);
        }

        // POST: TaiSanTriTue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTaiSanTriTue = await _context.TbTaiSanTriTues.FindAsync(id);
            if (tbTaiSanTriTue != null)
            {
                _context.TbTaiSanTriTues.Remove(tbTaiSanTriTue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTaiSanTriTueExists(int id)
        {
            return _context.TbTaiSanTriTues.Any(e => e.IdTaiSanTriTue == id);
        }
    }
}
