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
    public class ChucDanhKhoaHocCuaCanBoController : Controller
    {
        private readonly HemisContext _context;

        public ChucDanhKhoaHocCuaCanBoController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChucDanhKhoaHocCuaCanBo
        public async Task<IActionResult> Index()
        {
            var hemisContext = _context.TbChucDanhKhoaHocCuaCanBos.Include(t => t.IdCanBoNavigation).Include(t => t.IdChucDanhKhoaHocNavigation).Include(t => t.IdThamQuyenQuyetDinhNavigation);
            return View(await hemisContext.ToListAsync());
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdThamQuyenQuyetDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdChucDanhKhoaHocCuaCanBo == id);
            if (tbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Create
        /// Hàm khởi tạo thông tin Chức Danh Khoa Học của Cán Bộ
        public IActionResult Create()
        {
            //Lấy danh sách cán bộ truyền cho selectbox cán bộ bên view
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo");
            //Lấy danh sách Chức danh khoa học, hiển thị cụ thể chức danh khoa học
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "IdChucDanhKhoaHoc");
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "IdLoaiQuyetDinh");
            return View();
        }

        // POST: ChucDanhKhoaHocCuaCanBo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        // gửi dữ liệu về server xử lí sau khi người dùng nhập thông tin vào form và thực hiện submit
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create([Bind("IdChucDanhKhoaHocCuaCanBo,IdCanBo,IdChucDanhKhoaHoc,IdThamQuyenQuyetDinh,SoQuyetDinh,NgayQuyetDinh")] TbChucDanhKhoaHocCuaCanBo tbChucDanhKhoaHocCuaCanBo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tbChucDanhKhoaHocCuaCanBo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi lưu vào database
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi lưu dữ liệu: " + ex.Message);
                }
            }

            // Kiểm tra xem các trường bắt buộc có bị thiếu hay không
            if (string.IsNullOrEmpty(tbChucDanhKhoaHocCuaCanBo.SoQuyetDinh))
            {
                ModelState.AddModelError("SoQuyetDinh", "Số quyết định là bắt buộc.");
            }

            if (tbChucDanhKhoaHocCuaCanBo.NgayQuyetDinh == default(DateTime))
            {
                ModelState.AddModelError("NgayQuyetDinh", "Ngày quyết định là bắt buộc.");
            }

            if (!tbChucDanhKhoaHocCuaCanBo.IdCanBo.HasValue)
            {
                ModelState.AddModelError("IdCanBo", "Cán bộ là bắt buộc.");
            }

            if (!tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHoc.HasValue)
            {
                ModelState.AddModelError("IdChucDanhKhoaHoc", "Chức danh khoa học là bắt buộc.");
            }

            if (!tbChucDanhKhoaHocCuaCanBo.IdThamQuyenQuyetDinh.HasValue)
            {
                ModelState.AddModelError("IdThamQuyenQuyetDinh", "Thẩm quyền quyết định là bắt buộc.");
            }

            // Nếu có lỗi, trả lại view với dữ liệu hiện tại
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "TenCanBo", tbChucDanhKhoaHocCuaCanBo.IdCanBo);
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "TenChucDanhKhoaHoc", tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHoc);
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "TenLoaiQuyetDinh", tbChucDanhKhoaHocCuaCanBo.IdThamQuyenQuyetDinh);

            return View(tbChucDanhKhoaHocCuaCanBo);
        }


        // POST: ChucDanhKhoaHocCuaCanBo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChucDanhKhoaHocCuaCanBo,IdCanBo,IdChucDanhKhoaHoc,IdThamQuyenQuyetDinh,SoQuyetDinh,NgayQuyetDinh")] TbChucDanhKhoaHocCuaCanBo tbChucDanhKhoaHocCuaCanBo)
        {
            if (id != tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChucDanhKhoaHocCuaCanBo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChucDanhKhoaHocCuaCanBoExists(tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHocCuaCanBo))
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
            ViewData["IdCanBo"] = new SelectList(_context.TbCanBos, "IdCanBo", "IdCanBo", tbChucDanhKhoaHocCuaCanBo.IdCanBo);
            ViewData["IdChucDanhKhoaHoc"] = new SelectList(_context.DmChucDanhKhoaHocs, "IdChucDanhKhoaHoc", "IdChucDanhKhoaHoc", tbChucDanhKhoaHocCuaCanBo.IdChucDanhKhoaHoc);
            ViewData["IdThamQuyenQuyetDinh"] = new SelectList(_context.DmLoaiQuyetDinhs, "IdLoaiQuyetDinh", "IdLoaiQuyetDinh", tbChucDanhKhoaHocCuaCanBo.IdThamQuyenQuyetDinh);
            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // GET: ChucDanhKhoaHocCuaCanBo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos
                .Include(t => t.IdCanBoNavigation)
                .Include(t => t.IdChucDanhKhoaHocNavigation)
                .Include(t => t.IdThamQuyenQuyetDinhNavigation)
                .FirstOrDefaultAsync(m => m.IdChucDanhKhoaHocCuaCanBo == id);
            if (tbChucDanhKhoaHocCuaCanBo == null)
            {
                return NotFound();
            }

            return View(tbChucDanhKhoaHocCuaCanBo);
        }

        // POST: ChucDanhKhoaHocCuaCanBo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChucDanhKhoaHocCuaCanBo = await _context.TbChucDanhKhoaHocCuaCanBos.FindAsync(id);
            if (tbChucDanhKhoaHocCuaCanBo != null)
            {
                _context.TbChucDanhKhoaHocCuaCanBos.Remove(tbChucDanhKhoaHocCuaCanBo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbChucDanhKhoaHocCuaCanBoExists(int id)
        {
            return _context.TbChucDanhKhoaHocCuaCanBos.Any(e => e.IdChucDanhKhoaHocCuaCanBo == id);
        }
    }
}
