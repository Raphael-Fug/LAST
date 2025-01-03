﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbNguoiHocVayTinDung
{
    [Display(Name = "Số CCCD")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public int IdNguoiHocVayTinDung { get; set; }

    [Display(Name = "Mã học viên")]
    public int? IdHocVien { get; set; }

    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [Display(Name = "Số tiền được vay")]
    public int? SoTienDuocVay { get; set; }

    [Display(Name = "Tên tổ chức tín dụng")]
    public string? TenToChucTinDung { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Ngày vay")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    public DateOnly? NgayVay { get; set; }

    [Display(Name = "Địa chỉ")]
    public string? DiaChi { get; set; }

    [Display(Name = "Thời hạn vay (tháng)")]
    [Required(ErrorMessage = "Bắt buộc phải nhập")]
    [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "Vui lòng nhập một số nguyên dương.")]
    public int? ThoiHanVay { get; set; }


    [Display(Name = "Tình trạng vay")]
    public int? TinhTrangVay { get; set; }

    [Display(Name = "Học viên")]
    public virtual TbHocVien? IdHocVienNavigation { get; set; }

    [Display(Name = "Tình trạng vay (chi tiết)")]
    public virtual DmTuyChon? TinhTrangVayNavigation { get; set; }
}