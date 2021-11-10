
create database QLShopBanHang
go
use QLShopBanHang
go

create table NhanVien(
		ID          int IDENTITY(1,1)  NOT NULL,
		MaNV        varchar(20)   PRIMARY KEY NOT NULL,
		Email       varchar(50)   NOT NULL,
		TenNV       nvarchar(50)  NOT NULL,
		DiaChi      nvarchar(100) NOT NULL,
		DienThoai   varchar(15)   NOT NULL,
		VaiTro      tinyint       NOT NULL,
		MatKhau     varchar(50) CONSTRAINT [df_NV_MK] DEFAULT (23315424196402035621.) NOT NULL,
);
go
create table KhachHang(
		DienThoai   varchar(15)  PRIMARY KEY NOT NULL,
		TenKH       nvarchar(50)   NOT NULL,
		DiaChi      nvarchar(100)  NOT NULL,
		GioiTinh    nvarchar(5)    NOT NULL,
		MaNV        varchar(20)    NOT NULL,
		FOREIGN KEY (MaNV) references NhanVien(MaNV)  
);

GO
create table SanPham(
		MaSP        int IDENTITY(1,1) PRIMARY KEY NOT NULL,
		TenSP       nvarchar(50)   NOT NULL,
		GiaSP       float          NOT NULL,
		Size        nvarchar(5)    NOT NULL,
		NgayNhap    date           NOT NULL,
		SoLuong     int            NOT NULL,
		MoTa        nvarchar(50)   NOT NULL,
	    MaNV        varchar(20)    NOT NULL,
	    FOREIGN KEY (MaNV) references NhanVien(MaNV)
);
GO


create table HoaDon(		
		MaHoaDon    int     IDENTITY(1,1)  PRIMARY KEY NOT NULL,
		SoLuong     int            NOT NULL,
		TenNV       nvarchar(50)   NOT NULL,
		TenKH       nvarchar(50)   NOT NULL, 
		TenSP       nvarchar(50)   NOT NULL,
		NgayLapHD   date           NOT NULL,
		DonGia      float          NOT NULL,
		MaNV        varchar(20)    NOT NULL,
	    FOREIGN KEY (MaNV) references NhanVien(MaNV),		
);
Go
-- procedure đăng nhập
CREATE PROCEDURE DangNhap @email varchar(50), @matkhau varchar(50)
AS
BEGIN
	Declare @status int
if exists(select * from NhanVien where Email = @email and MatKhau = @matkhau)
	set @status = 1
else
	set @status = 0
select @status
end
go
-- procedure lấy vai trò nhân viên
Create PROCEDURE LayVaiTroNV @email varchar(50)
AS
BEGIN
      SELECT VaiTro FROM NhanVien
	  where Email = @email
	  SELECT VaiTro FROM NhanVien
	  
END
GO
-- Quên mật khẩu
CREATE PROCEDURE QuenMatKhau 
@email varchar(50)
AS
BEGIN
	Declare @status int
if exists(select MaNV from NhanVien where Email = @email)
	set @status = 1
else
	set @status = 0
	select @status
END
GO
-- Tạo mật khẩu mới
CREATE PROCEDURE TaoMatKhauMoi 
@email varchar(50),  @matkhau varchar(50)
AS
BEGIN
UPDATE NhanVien set MatKhau = @matkhau where Email = @email
END
GO
--list sản phẩm
CREATE PROCEDURE DanhMucSanPham
AS
BEGIN
SELECT TenSP from SanPham
END
GO

-- Đổi Mật Khẩu --------------------------------------

Create PROCEDURE DoiMatKhau 
    (@Email varchar(50),
     @opwd   nvarchar(50),
     @npwd   nvarchar(50)
    )
AS
    declare @op varchar(50)
	select @op= MatKhau from NhanVien where Email = @Email
	if @op = @opwd
BEGIN
    UPDATE NhanVien set MatKhau = @npwd where Email = @Email
return 1
end
else
return -1
   


insert into NhanVien values ('1','driverhuyhoa@gmail.com', N'Huy Hoà', N'Đồng Nai','0335592943', 1,'3244185981728979115075721453575112')
insert into NhanVien values ('2','tanhien@gmail.com', N'Tấn Hiển', N'Đồng Nai','02324232233', 1, 123)
delete NhanVien where MaNV = '1'
select * from NhanVien


select* from SanPham
insert into SanPham values(N'Áo Khoác', 250000, 'M','08-11-2021',10,N'Hàng mới',1)
insert into SanPham values(N'Áo Khỉ', 250000, 'M','08-11-2021',10,N'Hàng mới',1)

select TenSP from SanPham