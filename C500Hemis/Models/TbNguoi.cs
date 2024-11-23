using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbNguoi
{
    public int IdNguoi { get; set; }

    [DisplayName("Họ ")]
    public string? Ho { get; set; }
    [DisplayName("Tên ")]
    public string? Ten { get; set; }

    [DisplayName("Quốc Tịch ")]
    public int? IdQuocTich { get; set; }
    [DisplayName("Số CCCD ")]

    public string? SoCccd { get; set; }
    [DisplayName("Ngày Cấp CCCD ")]
    public DateOnly? NgayCapCccd { get; set; }
    [DisplayName("Nơi Cấp CCCD ")]
    public string? NoiCapCccd { get; set; }
    [DisplayName("Ngày Sinh ")]
    public DateOnly? NgaySinh { get; set; }
    [DisplayName("Giới Tính ")]
    public int? IdGioiTinh { get; set; }
    [DisplayName("Dân Tộc ")]
    public int? IdDanToc { get; set; }
    [DisplayName("Tôn Giáo ")]
    public int? IdTonGiao { get; set; }
    [DisplayName("Ngày Vào Đoàn ")]
    public DateOnly? NgayVaoDoan { get; set; }
    [DisplayName("Ngày Vào Đảng ")]
    public DateOnly? NgayVaoDang { get; set; }
    [DisplayName("Ngày Vào Đảng Chính Thức ")]
    public DateOnly? NgayVaoDangChinhThuc { get; set; }
    [DisplayName("Ngày Nhập Ngũ ")]
    public DateOnly? NgayNhapNgu { get; set; }
    [DisplayName("Ngày Xuất Ngũ ")]
    public DateOnly? NgayXuatNgu { get; set; }
    [DisplayName("Thương Binh Hạng ")]
    public int? IdThuongBinhHang { get; set; }
    [DisplayName("Gia Đình Chính Sách ")]

    public int? IdGiaDinhChinhSach { get; set; }
    [DisplayName("Chức Danh Khoa Học ")]

    public int? IdChucDanhKhoaHoc { get; set; }
    [DisplayName("Trình Độ Đào Tạo ")]
    public int? IdTrinhDoDaoTao { get; set; }
    [DisplayName("Chuyên Môn Đào Tạo ")]
    public int? IdChuyenMonDaoTao { get; set; }
    [DisplayName("Ngoại Ngữ ")]
    public int? IdNgoaiNgu { get; set; }
    [DisplayName("Khung Năng Lực Ngoại Ngữ ")]
    public int? IdKhungNangLucNgoaiNguc { get; set; }
    [DisplayName("Trình Độ Lí luận Chính Trị ")]

    public int? IdTrinhDoLyLuanChinhTri { get; set; }
    [DisplayName("Trình Độ Quản Lí Nhà Nước ")]

    public int? IdTrinhDoQuanLyNhaNuoc { get; set; }
    [DisplayName("Trình Độ Tin Học ")]

    public int? IdTrinhDoTinHoc { get; set; }

    [DisplayName("Chức Danh Khoa Học Navigation ")]
    public virtual DmChucDanhKhoaHoc? IdChucDanhKhoaHocNavigation { get; set; }
    [DisplayName("Chuyên Môn Đào Tạo Navigation ")]
    public virtual DmNganhDaoTao? IdChuyenMonDaoTaoNavigation { get; set; }
    [DisplayName("Tôn Giáo Navigation ")]
    public virtual DmTonGiao? IdTonGiaoNavigation { get; set; }
    [DisplayName("Dân Tộc Navigation ")]
    public virtual DmDanToc? IdDanTocNavigation { get; set; }
    [DisplayName("Gia Đình Chính Sách Navigation ")]
    public virtual DmHoGiaDinhChinhSach? IdGiaDinhChinhSachNavigation { get; set; }
    [DisplayName("Giới Tính Navigation ")]
    public virtual DmGioiTinh? IdGioiTinhNavigation { get; set; }
    [DisplayName("Khung Năng Lực Ngoại Ngữ Navigation ")]
    public virtual DmKhungNangLucNgoaiNgu? IdKhungNangLucNgoaiNgucNavigation { get; set; }
    [DisplayName("Ngoại Ngữ Navigation ")]
    public virtual DmNgoaiNgu? IdNgoaiNguNavigation { get; set; }
    [DisplayName("Quốc Tịch Navigation ")]
    public virtual DmQuocTich? IdQuocTichNavigation { get; set; }
    [DisplayName("Thương Binh Hạng Navigation ")]
    public virtual DmHangThuongBinh? IdThuongBinhHangNavigation { get; set; }
    [DisplayName("Trình Độ Đào Tạo Navigation ")]
    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }
    [DisplayName("Trình Độ Lí Luận Chính Trị Navigation ")]
    public virtual DmTrinhDoLyLuanChinhTri? IdTrinhDoLyLuanChinhTriNavigation { get; set; }
    [DisplayName("Trình Độ Quản Lí Nhà Nước Navigation ")]
    public virtual DmTrinhDoQuanLyNhaNuoc? IdTrinhDoQuanLyNhaNuocNavigation { get; set; }
    [DisplayName("Trình Độ Tin Học Navigation  ")]
    public virtual DmTrinhDoTinHoc? IdTrinhDoTinHocNavigation { get; set; }
    [DisplayName("Cán Bộ ")]
    public virtual ICollection<TbCanBo> TbCanBos { get; set; } = new List<TbCanBo>();
    [DisplayName("Đối Tượng Tham Gia ")]
    public virtual ICollection<TbDoiTuongThamGium> TbDoiTuongThamGia { get; set; } = new List<TbDoiTuongThamGium>();
    [DisplayName("Học Viên ")]
    public virtual ICollection<TbHocVien> TbHocViens { get; set; } = new List<TbHocVien>();
    public string name { get => Ho + " " + Ten; }
}
