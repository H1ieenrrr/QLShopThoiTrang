﻿	
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
		HinhAnh     varchar(400)  NOT NULL,
		VaiTro      tinyint       NOT NULL,
		isDelete	bit,
		MatKhau     varchar(50) CONSTRAINT [df_NV_MK] DEFAULT (3244185981728979115075721453575112) NOT NULL
)
go

create table KhachHang(
		DienThoai   varchar(15)  PRIMARY KEY NOT NULL,
		TenKH       nvarchar(50)   NOT NULL,
		DiaChi      nvarchar(100)  NOT NULL,
		GioiTinh    nvarchar(5)    NOT NULL,
		NgaySinh    date           NOT NULL,
		isDelete	bit,
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
		HinhAnh     varchar(400)  NOT NULL,
		MoTa        nvarchar(50)   NOT NULL,
	    MaNV        varchar(20)    NOT NULL,
	    FOREIGN KEY (MaNV) references NhanVien(MaNV)
);
GO
create table HoaDon(		
		MaHD		int IDENTITY(1,1) PRIMARY KEY NOT NULL,			
		NgayLapHD   datetime       NOT NULL,
		TongTien    decimal        NOT NULL,
		Thue		int			   NOT NULL,
		TongThanhToan decimal	   NOT NULL,
		DienThoai	varchar(15)	   NOT NULL,	
		MaNV        varchar(20)    NOT NULL,
		FOREIGN KEY (DienThoai) references KhachHang(DienThoai),	
	    FOREIGN KEY (MaNV) references NhanVien(MaNV)			
);
GO

create table HoaDonCT(
		MaHoaDonCT int IDENTITY(1,1)  PRIMARY KEY NOT NULL,
		MaHD	   int NOT NULL,
		MaSP       int NOT NULL,	
		SoLuong    int NOT NULL,
		DonGia     decimal NOT NULL,
		FOREIGN KEY (MaHD) references HoaDon(MaHD),
	    FOREIGN KEY (MaSP) references SanPham(MaSP)		
)
GO
-- procedure đăng nhập
CREATE PROCEDURE DangNhap @email varchar(50), @matkhau varchar(50)
AS
BEGIN
	Declare @status int
if exists(select * from NhanVien where Email = @email and MatKhau = @matkhau and isDelete != 'True')
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
GO 
--Nhân Viên ----------------------------------------------------

--Danh Sách NhanViên --

create PROCEDURE DanhSachNV 
as
Begin
  SELECT Email, TenNV, DiaChi, DienThoai, HinhAnh, VaiTro from NhanVien where isDelete != 'True' 
 END

 --Thêm Dữ Liệu Nhan Vien------
 GO
GO
 create PROCEDURE ThemNV
				@Email       varchar(50)   ,
				@TenNV       nvarchar(50)  ,
				@DiaChi      nvarchar(100) ,
				@DienThoai   varchar(15)   ,
				@HinhAnh     varchar(400) ,
				@VaiTro      tinyint       
AS
Begin
DECLARE @MaNV varchar(20);
DECLARE @ID INT;

SELECT @ID = ISNULL(MAX(ID),0) + 1 FROM NhanVien
SELECT @MaNV = 'NV' + RIGHT('0000' + CAST(@ID AS varchar(4)), 4)
INSERT INTO NhanVien(MaNV,Email, TenNV, DiaChi, DienThoai, HinhAnh, VaiTro,isDelete)
			VALUES (@MaNV,@Email,@TenNV,@DiaChi,@DienThoai,@HinhAnh,@VaiTro,'False')
END
go

-----------Sửa Nhân Viên-----------------------------------------------------------
Go
create PROCEDURE SuaNV
@Email       varchar(50)   ,
@TenNV       nvarchar(50)  ,
@DiaChi      nvarchar(100) ,
@DienThoai   varchar(15)   ,
@HinhAnh     varchar(400) ,
@VaiTro      tinyint       
AS
Begin
Update NhanVien SET TenNV=@TenNV, DiaChi=@DiaChi, DienThoai=@DienThoai, HinhAnh=@HinhAnh, VaiTro=@VaiTro
			  WHERE Email=@Email
END

------------Xóa Nhân Viên--------------------------------------------------------------
go
CREATE PROCEDURE XoaNV
  @Email   varchar (50)     
as
BEGIN
UPDATE NhanVien SET isDelete = 'True' where Email = @Email
END

------------Tìm Kiếm Nhân Viên----------------------------------------------------------------
go
CREATE PROCEDURE TimKiemNV
@TenNV nvarchar(50)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT Email, TenNV, DiaChi, DienThoai, HinhAnh, VaiTro from NhanVien 
       where TenNV like '%' + @TenNV + '%'
END
Go
-- kiểm tra khoá chính
Create PROCEDURE NV_KiemTraKhoaChinh
@email varchar(55)
AS
BEGIN
DECLARE @status int
if exists(select * from NhanVien where Email = @email)
			set @status = 1
else
			set @status = 0
select @status
END
GO
-- kiêm tra tài khoản admin
Create PROCEDURE NV_KiemTraAdmin
AS
BEGIN
select * from NhanVien where Email = '123@123'
END
GO
-----------------------------------------------------------------------------------------------------------------
-----------------------------Khách Hàng---------------------------------------------------------
----Kiểm tra sdt trùng--------------------
CREATE PROCEDURE KH_KiemTraKhoaChinh
@dienThoai  varchar(15)
AS
BEGIN
	Declare @status int
if exists(select * from KhachHang where DienThoai = @dienThoai )
	set @status = 1
else
	set @status = 0
select @status
end


-- Hiển thị danh sách khách hàng
go
CREATE PROCEDURE ListKH
AS
BEGIN
Select DienThoai, TenKH, DiaChi,GioiTinh,NgaySinh from KhachHang where isDelete = 'False'
END
Go
--Thêm khách hàng
Create PROCEDURE ThemKH
@dienthoai varchar(15), @tenkh nvarchar(50), @diachi nvarchar(50), @gioitinh nvarchar(50),@ngaysinh date, @email varchar(100)
AS
BEGIN
declare @MaNV varchar(20);
select @MaNV = MaNV from NhanVien where Email = @email
insert into KhachHang(DienThoai, TenKH, DiaChi,GioiTinh,NgaySinh,isDelete,MaNV) 
values(@dienthoai,@tenkh,@diachi,@gioitinh,@ngaysinh,'False',@MaNV)
END
GO
--Sửa khách hàng
CREATE PROCEDURE SuaKH
@dienthoai varchar(15), @tenkh nvarchar(50), @diachi nvarchar(50), @gioitinh nvarchar(50), @ngaysinh date
AS
BEGIN
UPDATE KhachHang set TenKH = @tenkh,DiaChi =@diachi, GioiTinh = @gioitinh ,NgaySinh = @ngaysinh
WHERE DienThoai = @dienthoai
END
GO
-- Xoá khách hàng
CREATE PROCEDURE XoaKH
@dienthoai varchar(15)
AS
BEGIN
delete from KhachHang where DienThoai = @dienthoai
UPDATE KhachHang set isDelete = 'True' where DienThoai = @dienthoai
END
GO
-- Tìm kiếm khách hàng
CREATE PROCEDURE TimKH
@dienthoai varchar(11)
AS
BEGIN
Select DienThoai,TenKH,DiaChi,GioiTinh,NgaySinh from KhachHang 
where DienThoai like '%' + @dienthoai +'%'
END
GO
-----------------------------------------------------------------------------------------------------------------
-----------------------------Sản Phẩm---------------------------------------------------------
--------------Danh Sách---------------------
go
create PROCEDURE DanhSachSP
as
Begin
  SELECT MaSP, TenSP, GiaSP, Size, NgayNhap, SoLuong, HinhAnh, MoTa From SanPham

 END

-----------------Thêm SP--------------------------
go
Create PROCEDURE ThemSP
			@TenSP       nvarchar(50) ,
			@GiaSP       float         ,
			@Size        nvarchar(5)   ,
			@NgayNhap    date         ,
			@SoLuong     int           ,
			@HinhAnh     varchar(400)  ,
			@MoTa        nvarchar(50) ,
			@Email       varchar(20)
as
begin 
declare @MaNV varchar(20);
select @MaNV = MaNV from NhanVien where Email = @Email
Insert into SanPham(TenSP, GiaSP, Size, NgayNhap, SoLuong, HinhAnh,MoTa,MaNV)
		values(@TenSP, @GiaSP, @Size, @NgayNhap, @SoLuong, @HinhAnh,@MoTa,@MaNV)
END

------------------Sửa SP--------------------------------------------------------------
go

Create PROCEDURE SuaSP
            @MaSP        int,
		    @TenSP       nvarchar(50) ,
			@GiaSP       float         ,
			@Size        nvarchar(5)   ,
			@NgayNhap    date         ,
			@SoLuong     int           ,
			@HinhAnh     varchar(400)  ,
			@MoTa        nvarchar(50) 
as
Begin
    UPDATE SanPham SET TenSP=@TenSP, GiaSP=@GiaSP, Size=@Size, NgayNhap=@NgayNhap, SoLuong=@SoLuong,
							HinhAnh=@HinhAnh, MoTa=@MoTa
			WHERE MaSP=@MaSP
END

----------------Xóa Sản Phẩm ----------------------------
go

Create PROCEDURE XoaSP
             @MaSP varchar(5)
as
BEGIN
     DELETE FROM SanPham WHERE MaSP = @MaSP

END

-----------------Tìm Kiếm Sản Phẩm ---------------------
go
Create PROCEDURE TimKiemSP
			@TenSP nvarchar(50)
as
begin
			SET NOCOUNT ON;
			SELECT MaSP, TenSP, GiaSP, Size, NgayNhap, SoLuong, HinhAnh, MoTa 
			From SanPham WHERE TenSP like '%' + @TenSP + '%'
END
go
------------------

--------------- Tạo Hoá đơn
-- hiện danh sách sản phẩm
CREATE PROCEDURE HienThiDanhSachSP
AS
BEGIN
Select MaSP, TenSP, GiaSP, SoLuong from SanPham
END
GO
-- Hiện tên nhân viên
CREATE PROCEDURE HienThiTenNV
@email varchar(55)
AS
BEGIN
Select TenNV from NhanVien where Email = @email
END
GO
-- hiển thong tín khách hàng
CREATE PROCEDURE HienThiThongTinKH
@dienthoai varchar(15)
AS
BEGIN
select TenKH, DiaChi from KhachHang where DienThoai = @dienthoai
END
GO
-- hiển thị tên sản phẩm lên combobox
CREATE PROCEDURE HoaDon_LoadTenSP
AS
BEGIN
Select TenSP from SanPham
END
GO
--hiển thị giá
CREATE PROCEDURE HoaDon_GiaSP
@TenSP nvarchar(50) 
AS
BEGIN
Select MaSP, GiaSP from SanPham
where TenSP = @TenSP 
END
GO



--procdure tìm hoá đơn
go
CREATE PROCEDURE TimHoaDon
AS
BEGIN
DECLARE @ngaybatdau datetime, @ngayketthuc datetime
select * from HoaDon where Cast(NgayLapHD as date) between @ngaybatdau and @ngayketthuc
END
GO
--procedure list hoá đơn
CREATE PROCEDURE DanhSachHoaDon
AS
BEGIN
Select HoaDon.MaHD,HoaDon.NgayLapHD,NhanVien.TenNV,KhachHang.TenKH,
HoaDon.TongTien,HoaDon.Thue,HoaDon.TongThanhToan from HoaDon,NhanVien,KhachHang
Where HoaDon.MaNV = NhanVien.MaNV and HoaDon.DienThoai = KhachHang.DienThoai 
END
go
--------------------------------

CREATE PROCEDURE HD_TimHDTheoTenNV
@tennv nvarchar(50)
AS
BEGIN
Select HoaDon.MaHD,HoaDon.NgayLapHD,NhanVien.TenNV,KhachHang.TenKH,
HoaDon.TongTien,HoaDon.Thue,HoaDon.TongThanhToan from HoaDon,NhanVien,KhachHang
Where HoaDon.MaNV = NhanVien.MaNV and HoaDon.DienThoai = KhachHang.DienThoai and TenNV like '%' + @tennv + '%'
END
go
--procedure thêm hoá đơn
go
CREATE PROCEDURE HD_ThemHoaDon
@ngaylaphd datetime, 
@thue int,
@tongtien decimal, 
@tongthanhtoan decimal,
@dienthoai varchar(15), 
@email varchar(50)
AS
BEGIN
	DECLARE @manv VARCHAR(20);
	select @manv = MaNV from NhanVien where Email = @email
	INSERT INTO HoaDon(NgayLapHD,Thue,TongTien,TongThanhToan,DienThoai,MaNV) 
	values(@ngaylaphd,@thue,@tongtien,@tongthanhtoan,@dienthoai,@MaNV)
END
go
-- procedure thêm chi tiết hoá đơn


-----Hoá đơn chi tiết
--thêm hoá đơn CT
CREATE PROCEDURE HDCT_ThemHDCT
@masp int,@soluong int,@dongia decimal,@ngaylap datetime
AS
BEGIN
		DECLARE @mahd int;
select @mahd = MaHD from HoaDon where NgayLapHD = @ngaylap
INSERT INTO HoaDonCT(MaSP,SoLuong,DonGia,MaHD) values(@masp,@soluong,@dongia,@mahd) 
END
go
-- Danh sách hoá đơn chi tiết
CREATE PROCEDURE HDCT_DanhSachHDCT
@mahd int
AS
BEGIN
SELECT hdct.MaHD, sp.TenSP, hdct.SoLuong, hdct.DonGia,hd.TongTien FROM HoaDonCT hdct,SanPham sp,HoaDon hd 
where (hdct.MaHD = hd.MaHD and hdct.MaSP = sp.MaSP) and hdct.MaHD = @mahd
END
GO

---- Danh Sach Tong Hop
Create proc ThongKeTongHop
@TuNgay date, @DenNgay date
as
begin
	select	ROW_NUMBER() OVER (ORDER BY convert(date, NgayLapHD)) AS 'STT',
	convert(date, NgayLapHD) as 'Ngày Lập Hóa Đơn',count(MaHD) as 'Tổng Số Hóa Đơn',
			SUM(TongTien) as 'Tổng Tiền Không VAT',SUM(TongTien)*0.1 as 'Tổng VAT',
			SUM(TongThanhToan)as 'Tổng Tiền Có VAT'
	from HOADON 
	where convert(date,NgayLapHD) between @TuNgay and @DenNgay
	group by convert(date, NgayLapHD)
end
go

-- PROCRDURE SoLuong Sản phẩm
create procedure KiemTraHang
@TenSP nvarchar(50),
@SoLuong float,
@Soluongdat float
as
begin      
        SELECT @SoLuong = Soluong from SanPham where TenSP = @TenSP
        IF(@SoLuongdat > @SoLuong )
		Begin
				RollBack
		End	
end
go
--Thay đổi số lượng sản phẩm trong kho
CREATE TRIGGER trg_SanPham ON HoaDonCT AFTER INSERT AS 
BEGIN
  DECLARE @SoLuong int;
  DECLARE @SoLuongDat int;
  select  @SoLuong = SoLuong from SanPham
  select  @SoLuongDat = SoLuong from HoaDonCT
  
  IF( @SoLuongDat > @SoLuong)
  BEGIN
	    RollBack Tran
  END
	UPDATE SanPham
	SET SoLuong = SanPham.SoLuong - (
		SELECT SoLuong
		FROM inserted
		WHERE MaSP = SanPham.MaSP
	)
	FROM SanPham
	JOIN inserted ON SanPham.MaSP = inserted.MaSP	
END
GO

--
CREATE PROCEDURE ThongKeKhachHang
AS
BEGIN
select kh.TenKH as 'Tên Khách Hàng',kh.DienThoai as 'Số Điện Thoại',COUNT(*) as 'Số hoá đơn'
from KhachHang kh, HoaDon hd 
where kh.DienThoai = hd.DienThoai
GROUP BY kh.DienThoai, kh.TenKH
order by COUNT(*) desc
END
GO

CREATE PROCEDURE ThongKeKhachHangTheoNam
AS
BEGIN
select YEAR(hd.NgayLapHD) as 'Năm' ,kh.TenKH as 'Tên Khách Hàng', 
kh.DienThoai as 'Số Điện Thoại',COUNT(*) as 'Số hoá đơn'
from KhachHang kh, HoaDon hd 
where kh.DienThoai = hd.DienThoai
GROUP BY kh.DienThoai, kh.TenKH, YEAR(hd.NgayLapHD)
order by 1 ASC;
END
GO

CREATE PROCEDURE ThongKeKhachHangTheoThang
AS
BEGIN
select FORMAT(hd.NgayLapHD,'MM / yyyy')  as 'Tháng' ,kh.TenKH as 'Tên Khách Hàng', 
kh.DienThoai as 'Số Điện Thoại',COUNT(*) as 'Số hoá đơn'
from KhachHang kh, HoaDon hd 
where kh.DienThoai = hd.DienThoai
GROUP BY kh.DienThoai, kh.TenKH, hd.NgayLapHD
order by 1 ASC
END
GO


--Tài Khoản ADMIN
insert into NhanVien values ('1','chinhchu@gmail.com', N'Huy Hoà', N'Đồng Nai','0335592943','', 1,'False','1962026656160185351301320480154111117132155')






