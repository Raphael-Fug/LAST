using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc
{
    [Display(Name = "ID danh hiệu thi đua giải thưởng khen thưởng người học")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int IdDanhHieuThiDuaGiaiThuongKhenThuongNguoiHoc { get; set; }
    [Display(Name = "Học viên")]
    public int? IdHocVien { get; set; }
    [Display(Name = "Loại danh hiệu thi đua giải thưởng khen thưởng")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }
    [Display(Name = "Danh hiệu thi đua giải thưởng khen thưởng")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int? IdDanhHieuThiDuaGiaiThuongKhenThuong { get; set; }
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [Display(Name = "Số quyết định khen thưởng")]
    public string? SoQuyetDinhKhenThuong { get; set; }
    [Display(Name = "Phương thức khen thưởng")]
    public int? IdPhuongThucKhenThuong { get; set; }
    [Display(Name = "Năm khen thưởng")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Vui lòng nhập năm hợp lệ (ví dụ: 2022).")]
    public string? NamKhenThuong { get; set; }
    [Display(Name = "Cấp khen thưởng")]
    public int? IdCapKhenThuong { get; set; }
    [Display(Name = "Cấp khen thưởng")]
    public virtual DmCapKhenThuong? IdCapKhenThuongNavigation { get; set; }
    [Display(Name = "Danh hiệu thi đua giải thưởng khen thưởng")]
    public virtual DmThiDuaGiaiThuongKhenThuong? IdDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }
    [Display(Name = "Học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }
    [Display(Name = "Loại danh hiệu thi đua giải thưởng khen thưởng")]
    public virtual DmLoaiDanhHieuThiDuaGiaiThuongKhenThuong? IdLoaiDanhHieuThiDuaGiaiThuongKhenThuongNavigation { get; set; }
    [Display(Name = "Phương thức khen thưởng")]
    public virtual DmPhuongThucKhenThuong? IdPhuongThucKhenThuongNavigation { get; set; }
}