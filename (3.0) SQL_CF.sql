create database  ProjectQLQuanCafe
go
use ProjectQLQuanCafe
go

CREATE TABLE NhanVien (
    MaNV varchar(20) PRIMARY KEY not null,
    TenNV NVARCHAR(100) not null,
    GioiTinh NVARCHAR(10) not null,
    NgaySinh DATE not null,
    DiaChi NVARCHAR(255) not null,
    SDT VARCHAR(20) not null,
    CCCD VARCHAR(20) not null,
    NgayTao DATETIME DEFAULT GETDATE() not null,
    NgayCapNhat DATETIME NULL,
    GhiChuNV NVARCHAR(255) null
);

INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SDT, CCCD) 
VALUES ('NV001', N'Nguyễn Văn A', N'Nam', '1990-01-01', N'123 Đường A, TP.HCM', '0912345678', '012345678901');


----------Lệnh Tạo Bảng Tài Khoản----------
CREATE TABLE TaiKhoan (
    MaTK varchar(20) PRIMARY KEY not null,
    MaNV varchar(20) UNIQUE not null,
    TenDangNhap VARCHAR(50) not null,
    MatKhau VARCHAR(255) not null,
    LoaiTaiKhoan NVARCHAR(20) not null,
    TrangThaiTK BIT DEFAULT 1 not null,
	Quyen NVARCHAR(50) DEFAULT N'Nhân viên',
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
); 

INSERT INTO TaiKhoan (MaTK, MaNV, TenDangNhap, MatKhau, LoaiTaiKhoan)
VALUES ('TK001', 'NV001', 'admin', '123456', N'Admin');

----------Lệnh Tạo Bảng Bàn----------
CREATE TABLE Ban (
    MaBan varchar(20) PRIMARY KEY not null, 
    TenBan NVARCHAR(50) not null,
    TrangThaiB NVARCHAR(20) not null,
    CONSTRAINT CK_Ban_TrangThai CHECK (TrangThaiB IN (N'Trống', N'Có người'))
);

INSERT INTO Ban (MaBan, TenBan, TrangThaiB)
VALUES (1, N'B001', N'Trống'), (2, N'B002', N'Trống'), (3, N'B003', N'Trống'), (4, N'B004', N'Trống'), (5, N'B005', N'Trống'), (6, N'B006', N'Trống'), (7, N'B007', N'Trống'), (8, N'B008', N'Trống'), (9, N'B009', N'Trống'), (10, N'B010', N'Trống');

select * from Ban
----------Lệnh Tạo Bảng Bán Hàng----------
CREATE TABLE HoaDon(
    MaHD varchar(20) PRIMARY KEY not null,
    MaBan varchar(20) not null,
    MaNV varchar(20) not null,
    NgayLap DATE not null,
    GioVaoHD DATETIME not null,
    GioRaHD DATETIME not null,
    TongTien DECIMAL(10,2) not null,
    TrangThaiHD NVARCHAR(50) DEFAULT N'Đang xử lý',
    GhiChuHD NVARCHAR(255) not null,
    FOREIGN KEY (MaBan) REFERENCES Ban(MaBan),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

----------Lệnh Tạo Bảng Menu Thực Đơn----------
CREATE TABLE MenuThucDon (                                                         
    MaMon varchar(20) PRIMARY KEY not null,    
    TenMon NVARCHAR(100)not null,              
    DonGia DECIMAL(10,2) not null,                    
    LoaiMon NVARCHAR(50) not null, 
);

----------Lệnh Tạo Bảng Chi Tiết Hóa Đơn----------
CREATE TABLE ChiTietHoaDon (
    MaHD varchar(20) not null,
    MaMon varchar(20) not null,
    SoLuong INT not null,
    DonGia DECIMAL(10,2) not null,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaMon) REFERENCES MenuThucDon(MaMon)
);

----------Lệnh Tạo Bảng Chấm Công----------
CREATE TABLE ChamCong (
    MaChamCong varchar(20) PRIMARY KEY not null,
    MaNV varchar(20) not null,
    NgayLamViec DATE not null,
    GioVaoCC DATETIME not null,
    GioRaCC DATETIME not null,
    GhiChuCC NVARCHAR(255) not null,
    CaLam NVARCHAR(20) not null,
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

----------Lệnh Tạo Bảng Chi Tiết Doanh Thu----------
CREATE TABLE DoanhThu (
    MaDoanhThu varchar(20) PRIMARY KEY not null,
	MaHD varchar(20) not null,
    Ngay DATE,
    DoanhThu DECIMAL(10,2),
    GhiChuDT NVARCHAR(255),
	FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD)
);


----------Trigger----------
----------Cập nhật trạng thái bàn khi tạo hóa đơn----------
GO
CREATE TRIGGER trg_CapNhatTrangThaiBan
ON HoaDon
AFTER INSERT
AS
BEGIN
    UPDATE Ban
    SET TrangThaiB = N'Đang dùng'
    WHERE MaBan IN (SELECT MaBan FROM inserted);
END

----------Khôi phục trạng thái bàn nếu hóa đơn bị xóa----------
GO
CREATE TRIGGER trg_KhoiPhucTrangThaiBan
ON HoaDon
AFTER DELETE
AS
BEGIN
    UPDATE Ban
    SET TrangThaiB = N'Trống'
    WHERE MaBan IN (SELECT MaBan FROM deleted);
END

----------Stored Procedure----------
----------Thêm nhân viên mới----------
GO
CREATE PROCEDURE sp_ThemNhanVien
    @MaNV int,
    @TenNV NVARCHAR(100),
    @GioiTinh nvarchar(10),
    @NgaySinh date,
    @DiaChi NVARCHAR(255),
    @SDT VARCHAR(20),
    @CCCD VARCHAR(20),
	@NgayTao DATETIME,
	@NgayCapNhat datetime,
	@GhiChuNV nvarchar(255) null
AS
BEGIN
    INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, NgaySinh, DiaChi, SDT, CCCD , NgayTao , NgayCapNhat, GhiChuNV)
    VALUES (@MaNV, @TenNV, @GioiTinh, @NgaySinh, @DiaChi, @SDT, @CCCD , @NgayTao , @NgayCapNhat , @GhiChuNV);
END

----------Đăng nhập tài khoản----------
GO
CREATE PROCEDURE sp_DangNhap
    @TenDangNhap NVARCHAR(50),
    @MatKhau NVARCHAR(255)
AS
BEGIN
    SELECT TenDangNhap, Quyen
    FROM TaiKhoan
    WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau;
END

-- Tạo hóa đơn bán hàng mới
GO
CREATE PROCEDURE sp_TaoHoaDon
    @NgayBan DATE,
    @MaNV INT,
    @MaBan INT,
    @TongTien DECIMAL(10,2) OUTPUT,
    @MaHD INT OUTPUT
AS
BEGIN
    INSERT INTO HoaDon(NgayLap, MaNV, MaBan, TongTien)
    VALUES (@NgayBan, @MaNV, @MaBan, 0);

    SET @MaHD = SCOPE_IDENTITY();
    SET @TongTien = 0;
END

-- Thêm chi tiết hóa đơn
GO
CREATE PROCEDURE sp_ThemChiTietHoaDon
    @MaHD INT,
    @MaMon INT,
    @SoLuong INT,
    @DonGia DECIMAL(10,2)
AS
BEGIN
    INSERT INTO ChiTietHoaDon (MaHD, MaMon, SoLuong, DonGia)
    VALUES (@MaHD, @MaMon, @SoLuong, @DonGia);

    UPDATE HoaDon
	SET TongTien = TongTien + @SoLuong * @DonGia
	WHERE MaHD = @MaHD;
END

----------Thống kê doanh thu theo ngày----------
GO
CREATE PROCEDURE sp_ThongKeDoanhThuTheoNgay
    @Ngay DATE
AS
BEGIN
    SELECT 
        NgayLap,
        SUM(TongTien) AS TongDoanhThu
    FROM HoaDon
    WHERE NgayLap = @Ngay
    GROUP BY NgayLap;
END

----------Thống kê doanh thu theo khoảng ngày----------
GO
CREATE PROCEDURE sp_ThongKeDoanhThuTheoKhoang
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SELECT 
        NgayLap,
        SUM(TongTien) AS TongDoanhThu
    FROM HoaDon 
    WHERE NgayLap BETWEEN @TuNgay AND @DenNgay
    GROUP BY NgayLap
    ORDER BY NgayLap;
END

----------Top món bán chạy----------
GO
CREATE PROCEDURE sp_TopMonBanChay
    @TuNgay DATE,
    @DenNgay DATE,
    @Top INT
AS
BEGIN
    SELECT TOP(@Top)
        td.TenMon,
        SUM(ct.SoLuong) AS TongSoLuong,
        SUM(ct.SoLuong * ct.DonGia) AS DoanhThu
    FROM ChiTietHoaDon ct
    JOIN HoaDon bh ON ct.MaHD = bh.MaHD
    JOIN MenuThucDon td ON ct.MaMon = td.MaMon
    WHERE bh.NgayLap BETWEEN @TuNgay AND @DenNgay
    GROUP BY td.TenMon
    ORDER BY TongSoLuong DESC;
END

----------Thống kê doanh thu theo nhân viên----------
GO
CREATE PROCEDURE sp_DoanhThuTheoNhanVien
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SELECT 
        nv.TenNV,
        COUNT(bh.MaHD) AS SoLuongHoaDon,
        SUM(bh.TongTien) AS TongDoanhThu
    FROM HoaDon bh
    JOIN NhanVien nv ON bh.MaNV = nv.MaNV
    WHERE bh.NgayLap BETWEEN @TuNgay AND @DenNgay
    GROUP BY nv.TenNV
    ORDER BY TongDoanhThu DESC;
END

