using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbLichSuDoiTenTruong
{
    [Required(ErrorMessage = "Vui lòng nhập ID lịch sử")]
    public int IdLichSuDoiTenTruong { get; set; }

    [StringLength(70, ErrorMessage = "Tên trường cũ không quá 70 ký tự.")]
    public string? TenTruongCu { get; set; }

    [StringLength(70, ErrorMessage = "Tên trường cũ tiếng anh không quá 70 ký tự.")]
    public string? TenTruongCuTiengAnh { get; set; }
    [Required(ErrorMessage = "Vui lòng số quyết định đổi tên")]
    public string? SoQuyetDinhDoiTen { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Vui lòng ngày đổi tên")]
    public DateOnly? NgayKyQuyetDinhDoiTen { get; set; }
}
