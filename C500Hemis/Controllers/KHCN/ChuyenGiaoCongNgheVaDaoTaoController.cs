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
    public class ChuyenGiaoCongNgheVaDaoTaoController : Controller
    {
        private readonly HemisContext _context;

        public ChuyenGiaoCongNgheVaDaoTaoController(HemisContext context)
        {
            _context = context;
        }

        // GET: ChuyenGiaoCongNgheVaDaoTao
        //#region Index và tìm kiếm (tìm kiếm theo tên)
        //public async Task<IActionResult> Index(string? Search)
        //{
        //    // Lấy danh sách chuyển giao công nghệ
        //    IQueryable<TbChuyenGiaoCongNgheVaDaoTao> query = _context.TbChuyenGiaoCongNgheVaDaoTaos
        //        .Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation)
        //        .Include(t => t.IdLinhVucNghienCuuNavigation)
        //        .Include(t => t.IdNganhKinhTeNavigation)
        //        .Include(t => t.IdNhiemVuKhcnNavigation)
        //        .Include(t => t.IdTrangThaiHopDongNavigation);

        //    // Nếu có giá trị tìm kiếm, lọc theo tên
        //    if (!string.IsNullOrEmpty(Search))
        //    {
        //        query = query.Where(s => s.Ten != null && s.Ten.Contains(Search));
        //        // Kiểm tra xem tên có khác null và chứa giá trị tìm kiếm không.
        //    }

        //    // Trả về view với danh sách đã lọc
        //    var result = await query.ToListAsync();
        //    return View(result);
        //}
        //#endregion
        #region Index và tìm kiếm (tìm kiếm theo ID)
        public async Task<IActionResult> Index(int? Search)
        {
            // Lấy danh sách chuyển giao công nghệ
            IQueryable<TbChuyenGiaoCongNgheVaDaoTao> query = _context.TbChuyenGiaoCongNgheVaDaoTaos
                //Khởi tạo một truy vấn từ bảng TbChuyenGiaoCongNgheVaDaoTaos trong cơ sở dữ liệu.
                .Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNganhKinhTeNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation);

            // Nếu có giá trị tìm kiếm, lọc theo IdChuyenGiaoCongNgheVaDaoTao
            if (Search.HasValue)
            {
                query = query.Where(s => s.IdChuyenGiaoCongNgheVaDaoTao == Search.Value);
                //Đây là một biểu thức lambda, trong đó s đại diện cho từng bản ghi trong query. Điều kiện kiểm tra xem IdChuyenGiaoCongNgheVaDaoTao của bản ghi có bằng với giá trị của Search hay không.
            }

            // Trả về view với danh sách đã lọc
            var result = await query.ToListAsync();
            //Sau khi áp dụng điều kiện lọc (nếu có), đoạn mã này sẽ thực hiện truy vấn và lấy danh sách các bản ghi thỏa mãn điều kiện.
            return View(result);
        }
        #endregion
        // GET: ChuyenGiaoCongNgheVaDaoTao/Details/5
        #region Hiển thị chi tiết
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Lấy danh sách chuyển giao công nghệ
            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos
                .Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNganhKinhTeNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdChuyenGiaoCongNgheVaDaoTao == id);
            if (tbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }
        #endregion
        // GET: ChuyenGiaoCongNgheVaDaoTao/Create
        #region Create đã chỉnh lại SelectList và bắt một số lỗi
        public IActionResult Create()
        {
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "HinhThucChuyenGiaoCongNghe");
            //Lấy danh sách lĩnh vực nghiên cứu, hiển thị cụ thể 
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu");
            //Lấy danh sách ngành kinh tế, hiển thị cụ thể
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "NganhKinhTe");
            //Lấy danh sách nhiệm vụ nckh, hiển thị cụ thể
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu");
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "TrangThaiHopDong");
            return View();
        }

        // POST: ChuyenGiaoCongNgheVaDaoTao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChuyenGiaoCongNgheVaDaoTao,IdNhiemVuKhcn,MaSoHopDong,Ten,TongChiPhiThucHien,TongThoiGianThucHien,IdHinhThucChuyenGiaoCongNghe,PhuongThucChuyenGiaoCongNghe,ChuSoHuu,DonViChuTri,DonViPhoiHop,DonViNhanChuyenGiao,TomTat,TenDuAn,GiaTriHopDong,IdNganhKinhTe,IdTrangThaiHopDong,SoNguoiDuocDaoTaoChuyenGiaoCn,IdLinhVucNghienCuu")] TbChuyenGiaoCongNgheVaDaoTao tbChuyenGiaoCongNgheVaDaoTao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Lưu vào csdl
                    _context.Add(tbChuyenGiaoCongNgheVaDaoTao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //Bắt lỗi trùng khoá chính
                catch (DbUpdateException ex)
                {
                    // Kiểm tra lỗi trùng khóa chính
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("duplicate key"))
                    {
                        ViewBag.ErrorMessage = "Bản ghi đã tồn tại. Vui lòng kiểm tra lại (trùng khoá chính)";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Có lỗi xảy ra khi lưu dữ liệu. Vui lòng thử lại.";
                    }
                }
                // bắt các lỗi ngoại lệ
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = "Có lỗi không xác định xảy ra: " + ex.Message;
                }
            }
            //Lấy danh sách chuyển giao truyền cho selectbox chuyển giao bên view
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "HinhThucChuyenGiaoCongNghe", tbChuyenGiaoCongNgheVaDaoTao.IdHinhThucChuyenGiaoCongNghe);
            //Lấy danh sách lĩnh vực nghiên cứu truyền cho selectbox chuyển giao bên view
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbChuyenGiaoCongNgheVaDaoTao.IdLinhVucNghienCuu);
            //Lấy danh sách ngành kinh tế truyền cho selectbox chuyển giao bên view
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "NganhKinhTe", tbChuyenGiaoCongNgheVaDaoTao.IdNganhKinhTe);
            //Tương tự
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbChuyenGiaoCongNgheVaDaoTao.IdNhiemVuKhcn);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "TrangThaiHopDong", tbChuyenGiaoCongNgheVaDaoTao.IdTrangThaiHopDong);
            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }
        #endregion
        // GET: ChuyenGiaoCongNgheVaDaoTao/Edit/5
        #region Edit 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);
            if (tbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }
            //Lấy danh sách chuyển giao truyền cho selectbox cán bộ bên view
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "HinhThucChuyenGiaoCongNghe", tbChuyenGiaoCongNgheVaDaoTao.IdHinhThucChuyenGiaoCongNghe);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbChuyenGiaoCongNgheVaDaoTao.IdLinhVucNghienCuu);
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "NganhKinhTe", tbChuyenGiaoCongNgheVaDaoTao.IdNganhKinhTe);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbChuyenGiaoCongNgheVaDaoTao.IdNhiemVuKhcn);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "TrangThaiHopDong", tbChuyenGiaoCongNgheVaDaoTao.IdTrangThaiHopDong);
            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // POST: ChuyenGiaoCongNgheVaDaoTao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChuyenGiaoCongNgheVaDaoTao,IdNhiemVuKhcn,MaSoHopDong,Ten,TongChiPhiThucHien,TongThoiGianThucHien,IdHinhThucChuyenGiaoCongNghe,PhuongThucChuyenGiaoCongNghe,ChuSoHuu,DonViChuTri,DonViPhoiHop,DonViNhanChuyenGiao,TomTat,TenDuAn,GiaTriHopDong,IdNganhKinhTe,IdTrangThaiHopDong,SoNguoiDuocDaoTaoChuyenGiaoCn,IdLinhVucNghienCuu")] TbChuyenGiaoCongNgheVaDaoTao tbChuyenGiaoCongNgheVaDaoTao)
        {
            if (id != tbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbChuyenGiaoCongNgheVaDaoTao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbChuyenGiaoCongNgheVaDaoTaoExists(tbChuyenGiaoCongNgheVaDaoTao.IdChuyenGiaoCongNgheVaDaoTao))
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
            ViewData["IdHinhThucChuyenGiaoCongNghe"] = new SelectList(_context.DmHinhThucChuyenGiaoCongNghes, "IdHinhThucChuyenGiaoCongNghe", "HinhThucChuyenGiaoCongNghe", tbChuyenGiaoCongNgheVaDaoTao.IdHinhThucChuyenGiaoCongNghe);
            ViewData["IdLinhVucNghienCuu"] = new SelectList(_context.DmLinhVucNghienCuus, "IdLinhVucNghienCuu", "LinhVucNghienCuu", tbChuyenGiaoCongNgheVaDaoTao.IdLinhVucNghienCuu);
            ViewData["IdNganhKinhTe"] = new SelectList(_context.DmNganhKinhTes, "IdNganhKinhTe", "NganhKinhTe", tbChuyenGiaoCongNgheVaDaoTao.IdNganhKinhTe);
            ViewData["IdNhiemVuKhcn"] = new SelectList(_context.TbNhiemVuKhcns, "IdNhiemVuKhcn", "TenNhiemVu", tbChuyenGiaoCongNgheVaDaoTao.IdNhiemVuKhcn);
            ViewData["IdTrangThaiHopDong"] = new SelectList(_context.DmTrangThaiHopDongs, "IdTrangThaiHopDong", "TrangThaiHopDong", tbChuyenGiaoCongNgheVaDaoTao.IdTrangThaiHopDong);
            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }
        #endregion
        // GET: ChuyenGiaoCongNgheVaDaoTao/Delete/5
        #region Delete 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos
                .Include(t => t.IdHinhThucChuyenGiaoCongNgheNavigation)
                .Include(t => t.IdLinhVucNghienCuuNavigation)
                .Include(t => t.IdNganhKinhTeNavigation)
                .Include(t => t.IdNhiemVuKhcnNavigation)
                .Include(t => t.IdTrangThaiHopDongNavigation)
                .FirstOrDefaultAsync(m => m.IdChuyenGiaoCongNgheVaDaoTao == id);
            if (tbChuyenGiaoCongNgheVaDaoTao == null)
            {
                return NotFound();
            }

            return View(tbChuyenGiaoCongNgheVaDaoTao);
        }

        // POST: ChuyenGiaoCongNgheVaDaoTao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbChuyenGiaoCongNgheVaDaoTao = await _context.TbChuyenGiaoCongNgheVaDaoTaos.FindAsync(id);
            if (tbChuyenGiaoCongNgheVaDaoTao != null)
            {
                _context.TbChuyenGiaoCongNgheVaDaoTaos.Remove(tbChuyenGiaoCongNgheVaDaoTao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
        //Kiểm tra xem id Chuyển giao đã tồn tại chưa
        private bool TbChuyenGiaoCongNgheVaDaoTaoExists(int id)
        {
            return _context.TbChuyenGiaoCongNgheVaDaoTaos.Any(e => e.IdChuyenGiaoCongNgheVaDaoTao == id);
        }
    }
}
