using System;
using System.Collections.Generic;
using C500Hemis.Models.DM;
using System.ComponentModel.DataAnnotations;


namespace C500Hemis.Models;

public partial class TbThongTinHocTapSinhVien
{
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [Display(Name = "Id thông tin học tập")]
    public int IdThongTinHocTapHocVien { get; set; }

    [Display(Name = "Học viên")]
    public int? IdHocVien { get; set; }

    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [Display(Name = "Đối tượng đầu vào")]
    public int? IdDoiTuongDauVao { get; set; }

    [Display(Name = "Số quyết định trúng tuyển")]
    public string? SoQuyetDinhTrungTuyen { get; set; }

    [Display(Name = "Ngày ký quyết định trúng tuyển")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayKyQuyetDinhTrungTuyen { get; set; }

    [Display(Name = "Sinh viên năm")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int? IdSinhVienNam { get; set; }

    [Display(Name = "Kết quả tuyển sinh")]
    [DataType(DataType.Text)]
    public string? KetQuaTuyenSinh { get; set; }

    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [Display(Name = "Mã chương trình đào tạo")]
    public int? IdChuongTrinhDaoTao { get; set; }

    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [Display(Name = "Loại hình đào tạo")]
    public int? IdLoaiHinhDaoTao { get; set; }

    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "Vui lòng nhập thời gian theo định dạng dd/MM/yyyy (ví dụ: 10/10/2020).")]
    [Display(Name = "Đào tạo từ năm")]
    public DateOnly? DaoTaoTuNam { get; set; }
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$", ErrorMessage = "Vui lòng nhập thời gian theo định dạng dd/MM/yyyy (ví dụ: 10/10/2020).")]
    [Display(Name = "Đào tạo đến năm")]
    public DateOnly? DaoTaoDenNam { get; set; }

    [Display(Name = "Khoa")]
    public string? Khoa { get; set; }

    [Display(Name = "Lớp sinh hoạt/Lớp niên chế")]
    public string? Lop { get; set; }
    [Display(Name = "Bằng tốt nghiệp liên thông")]
    public int? BangTotNghiepLienThong { get; set; }
    [Display(Name = "Đang ở nội trú")]
    public int? DangOnoiTru { get; set; }

    [Display(Name = "Ngày nhập học")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public DateOnly? NgayNhapHoc { get; set; }
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int? IdTrangThaiHoc { get; set; }
    [Display(Name = "Ngày chuyển trạng thái")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayChuyenTrangThai { get; set; }
    [Display(Name = "Số quyết định(Thôi học/Buộc thôi học/Bảo lưu...)\r\n")]
    public string? SoQuyetDinhThoiHoc { get; set; }
    [Display(Name = "Thời gian tốt nghiệp")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? ThoiGianTotNghiep { get; set; }
    [Display(Name = "Loại tốt nghiệp")]
    public int? IdLoaiTotNghiep { get; set; }
    [Display(Name = "Số quyết định tốt nghiệp")]
    public string? SoQuyetDinhTotNghiep { get; set; }
    [Display(Name = "Ngày quyết định công nhận tốt nghiệp")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayQuyetDinhCongNhanTotNghiep { get; set; }

    public virtual DmTuyChon? BangTotNghiepLienThongNavigation { get; set; }

    public virtual DmTuyChon? DangOnoiTruNavigation { get; set; }

    public virtual DmChuongTrinhDaoTao? IdChuongTrinhDaoTaoNavigation { get; set; }

    public virtual DmDoiTuongDauVao? IdDoiTuongDauVaoNavigation { get; set; }

    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    public virtual DmLoaiHinhDaoTao? IdLoaiHinhDaoTaoNavigation { get; set; }

    public virtual DmLoaiTotNghiep? IdLoaiTotNghiepNavigation { get; set; }

    public virtual DmSinhVienNam? IdSinhVienNamNavigation { get; set; }

    public virtual DmTrangThaiHoc? IdTrangThaiHocNavigation { get; set; }
}
