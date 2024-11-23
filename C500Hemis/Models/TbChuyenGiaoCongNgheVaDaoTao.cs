using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;
using Newtonsoft.Json.Serialization;

namespace C500Hemis.Models;

public partial class TbChuyenGiaoCongNgheVaDaoTao
{
    //Bắt buộc phải nhập
    [Required(ErrorMessage = "Vui lòng nhập ID và không trùng với các ID trước")]
    public int IdChuyenGiaoCongNgheVaDaoTao { get; set; }
    public int? IdNhiemVuKhcn { get; set; }

    //Bắt buộc phải nhập và giới hạn ký tự
    [Required(ErrorMessage = "Vui lòng nhập mã số hợp đồng")]
    [StringLength(36, ErrorMessage = "Mã hợp đồng không được vượt quá 36 ký tự.")]
    public string? MaSoHopDong { get; set; }
    //Bắt buộc phải nhập và giới hạn ký tự
    [Required(ErrorMessage = "Vui lòng nhập tên công nghệ chuyển giao")]
    public string? Ten { get; set; }

    //Giới hạn giá trị và chỉnh đúng form
    [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn hoặc bằng 0.")]
    [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Chỉ được chứa ký tự số.")]
    public int? TongChiPhiThucHien { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn hoặc bằng 0.")]
    public int? TongThoiGianThucHien { get; set; }

    public int? IdHinhThucChuyenGiaoCongNghe { get; set; }

    public string? PhuongThucChuyenGiaoCongNghe { get; set; }

    public string? ChuSoHuu { get; set; }

    public string? DonViChuTri { get; set; }

    public string? DonViPhoiHop { get; set; }

    public string? DonViNhanChuyenGiao { get; set; }

    //Giới hạn ký tự
    [StringLength(100, ErrorMessage = "Tóm tắt dự án không được vượt quá 100 ký tự.")]
    public string? TomTat { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên dự án")]
    public string? TenDuAn { get; set; }

    //Giới hạn giá trị và chỉnh đúng form
    [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn hoặc bằng 0.")]
    [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "Chỉ được chứa ký tự số.")]
    public int? GiaTriHopDong { get; set; }
    
    public int? IdNganhKinhTe { get; set; }

    public int? IdTrangThaiHopDong { get; set; }

    //Giới hạn giá trị và chỉnh đúng form
    [Range(0, double.MaxValue, ErrorMessage = "Giá trị phải lớn hơn hoặc bằng 0.")]
    [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
    public int? SoNguoiDuocDaoTaoChuyenGiaoCn { get; set; }

    public int? IdLinhVucNghienCuu { get; set; }

    public virtual DmHinhThucChuyenGiaoCongNghe? IdHinhThucChuyenGiaoCongNgheNavigation { get; set; }

    public virtual DmLinhVucNghienCuu? IdLinhVucNghienCuuNavigation { get; set; }

    public virtual DmNganhKinhTe? IdNganhKinhTeNavigation { get; set; }

    public virtual TbNhiemVuKhcn? IdNhiemVuKhcnNavigation { get; set; }

    public virtual DmTrangThaiHopDong? IdTrangThaiHopDongNavigation { get; set; }
}
