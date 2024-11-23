using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbThongTinViecLamSauTotNghiep
{
    [Display(Name = "Id việc làm sau tốt nghiệp")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int IdThongTinViecLamSauTotNghiep { get; set; }

    [Display(Name = "Id học viên")]
    public int? IdHocVien { get; set; }

    [Display(Name = "Tên đơn vị cấp bằng")]
    public string? TenDonViCapBang { get; set; }

    [Display(Name = "Đơn vị tuyển dụng")]

    public string? DonViTuyenDung { get; set; }

    [Display(Name = "hình thức tuyển dụng")]
    public int? IdHinhThucTuyenDung { get; set; }
    [Display(Name = "Thời gian tuyển dụng")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? ThoiGianTuyenDung { get; set; }

    [Display(Name = "Id vị trí việc làm")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int? IdViTriViecLam { get; set; }

    [Display(Name = "Mức lương khởi điểm")]

    public int? MucLuongKhoiDiem { get; set; }

    [Display(Name = "Id hình thức tuyển dụng")]

    public virtual DmHinhThucTuyenDung? IdHinhThucTuyenDungNavigation { get; set; }

    [Display(Name = "Id học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "Id vị trí việc làm")]
    public virtual DmViTriViecLam? IdViTriViecLamNavigation { get; set; }
}
