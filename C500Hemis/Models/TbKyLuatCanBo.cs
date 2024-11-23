using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbKyLuatCanBo
{
    public int IdKyLuatCanBo { get; set; }

    public int? IdCanBo { get; set; }

    public int? IdLoaiKyLuat { get; set; }

    public string? LyDo { get; set; }

    public int? IdCapQuyetDinh { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NgayThangNamQuyetDinh { get; set; }

    public string? SoQuyetDinh { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly? NamBiKyLuat { get; set; }

    public virtual TbCanBo? IdCanBoNavigation { get; set; }

    public virtual DmCapKhenThuong? IdCapQuyetDinhNavigation { get; set; }

    public virtual DmLoaiKyLuat? IdLoaiKyLuatNavigation { get; set; }
}
