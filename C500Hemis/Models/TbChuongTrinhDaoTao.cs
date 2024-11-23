using System;
using System.Collections.Generic;
using System.ComponentModel;
using C500Hemis.Models.DM;

namespace C500Hemis.Models;

public partial class TbChuongTrinhDaoTao
{
    [DisplayName("Chương Trình Đào Tạo")]   
    
    public int IdChuongTrinhDaoTao { get; set; }
    [DisplayName("Mã Chương Trình Đào Tạo ")]

    public string? MaChuongTrinhDaoTao { get; set; }
    [DisplayName("Ngành Đào Tạo ")]
    public int? IdNganhDaoTao { get; set; }
    [DisplayName("Tên Chương Trình ")]
    public string? TenChuongTrinh { get; set; }
    [DisplayName("Tên Chương Trình Bằng Tiếng Anh ")]
    public string? TenChuongTrinhBangTiengAnh { get; set; }
    [DisplayName("Năm Bắt Đầu Tuyển Sinh ")]
    public DateOnly? NamBatDauTuyenSinh { get; set; }
    [DisplayName("Tên Cơ Sở Đào Tạo Nước Ngoài ")]
    public string? TenCoSoDaoTaoNuocNgoai { get; set; }
    [DisplayName("Loại Chương Trình Đào Tạo ")]
    public int? IdLoaiChuongTrinhDaoTao { get; set; }
    [DisplayName("Loại Chương Trình Liên Kết Đào Tạo ")]

    public int? IdLoaiChuongTrinhLienKetDaoTao { get; set; }
    [DisplayName("Địa Điểm Đào Tạo ")]
    public string? DiaDiemDaoTao { get; set; }
    [DisplayName("Học Chế Đào Tạo ")]
    public int? IdHocCheDaoTao { get; set; }
    [DisplayName("Quốc Gia Trụ Sở Chính ")]
    public int? IdQuocGiaCuaTruSoChinh { get; set; }
    [DisplayName("Ngày Ban Hành Chuẩn Đầu Ra ")]
    public DateOnly? NgayBanHanhChuanDauRa { get; set; }
    [DisplayName("Trình Độ Đào Tạo ")]
    public int? IdTrinhDoDaoTao { get; set; }
    [DisplayName("Thời Gian Đào Tạo Chuẩn ")]
    public int? ThoiGianDaoTaoChuan { get; set; }
    [DisplayName("Chuẩn Đầu Ra ")]
    public string? ChuanDauRa { get; set; }
    [DisplayName("Đơn Vị Cấp Bằng ")]

    public int? IdDonViCapBang { get; set; }
    [DisplayName("Loại Chứng Chỉ Được Chấp Nhận ")]
    public string? LoaiChungChiDuocChapThuan { get; set; }
    [DisplayName("Đơn Vị Thực Hiện Chương Trình ")]
    public string? DonViThucHienChuongTrinh { get; set; }
    [DisplayName("Trạng Thái Của Chương Trình ")]
    public int? IdTrangThaiCuaChuongTrinh { get; set; }
    [DisplayName("Chuẩn Đầu Ra Về Ngoại Ngữ ")]
    public string? ChuanDauRaVeNgoaiNgu { get; set; }
    [DisplayName("Chuẩn Đầu Ra Về Tin Học ")]
    public string? ChuanDauRaVeTinHoc { get; set; }
    [DisplayName("Học Phí Tại Việt Nam ")]
    public int? HocPhiTaiVietNam { get; set; }
    [DisplayName("Học Phí Tại Nước Ngoài ")]
    public int? HocPhiTaiNuocNgoai { get; set; }
    [DisplayName("Đơn Vị Cấp Bằng Navigation ")]

    public virtual DmDonViCapBang? IdDonViCapBangNavigation { get; set; }
    [DisplayName("Học Chế Đào Tạo Navigation ")]
    public virtual DmHocCheDaoTao? IdHocCheDaoTaoNavigation { get; set; }
    [DisplayName("Loại Chương Trình Đào Tạo Navigation ")]
    public virtual DmLoaiChuongTrinhDaoTao? IdLoaiChuongTrinhDaoTaoNavigation { get; set; }
    [DisplayName("Loại Chương Trình Liên Kết Đào Tạo Navigation ")]
    public virtual DmLoaiChuongTrinhLienKetDaoTao? IdLoaiChuongTrinhLienKetDaoTaoNavigation { get; set; }
    [DisplayName("Ngành Đào Tạo Navigation ")]
    public virtual DmNganhDaoTao? IdNganhDaoTaoNavigation { get; set; }
    [DisplayName("Quốc Gia Của Trụ Sở Chính Navigation ")]
    public virtual DmQuocTich? IdQuocGiaCuaTruSoChinhNavigation { get; set; }
    [DisplayName("Trạng Thái Của Chương Trình Navigation ")]
    public virtual DmTrangThaiChuongTrinhDaoTao? IdTrangThaiCuaChuongTrinhNavigation { get; set; }
    [DisplayName(" Trình Độ Đào Tạo Navigation ")]
    public virtual DmTrinhDoDaoTao? IdTrinhDoDaoTaoNavigation { get; set; }
    [DisplayName("Gia Chương Trình Đào Tạo ")]
    public virtual ICollection<TbGiaHanChuongTrinhDaoTao> TbGiaHanChuongTrinhDaoTaos { get; set; } = new List<TbGiaHanChuongTrinhDaoTao>();
    [DisplayName("Năm Áp Dụng Chương Trình ")]
    public virtual ICollection<TbNamApDungChuongTrinh> TbNamApDungChuongTrinhs { get; set; } = new List<TbNamApDungChuongTrinh>();
    [DisplayName("Ngôn Ngữ Giảng Dạy ")]
    public virtual ICollection<TbNgonNguGiangDay> TbNgonNguGiangDays { get; set; } = new List<TbNgonNguGiangDay>();
    [DisplayName("Quyết Định Cấp Phép Chương Trình Dùng Cho Chương Trình Nước Ngoài ")]
    public virtual ICollection<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai> TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoais { get; set; } = new List<TbQuyetDinhCapPhepChuongTrinhDungChoChuongTrinhNuocNgoai>();
    [DisplayName("Thông Tin Kiểm Định Của Chương Tình ")]
    public virtual ICollection<TbThongTinKiemDinhCuaChuongTrinh> TbThongTinKiemDinhCuaChuongTrinhs { get; set; } = new List<TbThongTinKiemDinhCuaChuongTrinh>();
}
