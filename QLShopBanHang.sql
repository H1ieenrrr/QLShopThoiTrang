
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
		HinhAnh     varchar(400) NOT NULL,
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
		HinhAnh     varchar(400)  NOT NULL,
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
 go
-- KiemTra Email trùng---------------------------------------
CREATE PROCEDURE NV_KiemTraKhoaChinh
@email  varchar(50)
AS
BEGIN
	Declare @status int
if exists(select * from NhanVien where Email = @email )
	set @status = 1
else
	set @status = 0
select @status
end


--Nhân Viên ----------------------------------------------------

--Danh Sách NhanViên --
go
create PROCEDURE DanhSachNV 
as
Begin
  SELECT Email, TenNV, DiaChi, DienThoai, HinhAnh, VaiTro from NhanVien

 END

 --Thêm Dữ Liệu Nhan Vien------
 
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
INSERT INTO NhanVien(MaNV,Email, TenNV, DiaChi, DienThoai, HinhAnh, VaiTro)
			VALUES (@MaNV,@Email,@TenNV,@DiaChi,@DienThoai,@HinhAnh,@VaiTro)
END
go
-----------Sửa Nhân Viên-----------------------------------------------------------
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
go
------------Xóa Nhân Viên--------------------------------------------------------------
CREATE PROCEDURE XoaNV

            @Email   varchar (50)     
as
BEGIN
DELETE FROM NhanVien WHERE Email=@Email

END
go
------------Tìm Kiếm Nhân Viên----------------------------------------------------------------
CREATE PROCEDURE TimKiemNV
@TenNV nvarchar(50)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT Email, TenNV, DiaChi, DienThoai, HinhAnh, VaiTro from NhanVien 
       where TenNV like '%' + @TenNV + '%'
END


go
-----------------------------------------------------------------------------------------------------------------
-----------------------------Khách Hàng------------------------------------------------------------
------Kiểm tra Khách Hàng trùng-----
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

go
-- Hiển thị danh sách khách hàng
CREATE PROCEDURE ListKH
AS
BEGIN
Select DienThoai, TenKH, DiaChi,GioiTinh from KhachHang
END
Go
--Thêm khách hàng
CREATE PROCEDURE ThemKH
@dienthoai varchar(15), @tenkh nvarchar(50), @diachi nvarchar(50), @gioitinh nvarchar(50), @email varchar(100)
AS
BEGIN
declare @MaNV varchar(20);
select @MaNV = MaNV from NhanVien where @email = Email
insert into KhachHang(DienThoai, TenKH, DiaChi,GioiTinh,MaNV) values(@dienthoai,@tenkh,@diachi,@gioitinh,@MaNV)
END
GO
--Sửa khách hàng
CREATE PROCEDURE SuaKH
@dienthoai varchar(15), @tenkh nvarchar(50), @diachi nvarchar(50), @gioitinh nvarchar(50)
AS
BEGIN
UPDATE KhachHang set TenKH = @tenkh,DiaChi =@diachi, GioiTinh = @gioitinh
WHERE DienThoai = @dienthoai
END
GO
-- Xoá khách hàng
CREATE PROCEDURE XoaKH
@dienthoai varchar(15)
AS
BEGIN
delete from KhachHang where DienThoai = @dienthoai
END
GO

-----------------------------------------------------------------------------------------------------------------
-----------------------------Sản Phẩm---------------------------------------------------------
--------------Danh Sách---------------------
create PROCEDURE DanhSachSP
as
Begin
  SELECT MaSP, TenSP, GiaSP, Size, NgayNhap, SoLuong, HinhAnh, MoTa From SanPham

 END
 go
-----------------Thêm SP--------------------------
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
go
------------------Sửa SP--------------------------------------------------------------

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
go
-----------------Tìm Kiếm Sản Phẩm ---------------------
Create PROCEDURE TimKiemSP
			@TenSP nvarchar(50)
as
begin
			SET NOCOUNT ON;
			SELECT MaSP, TenSP, GiaSP, Size, NgayNhap, SoLuong, HinhAnh, MoTa 
			From SanPham WHERE TenSP like '%' + @TenSP + '%'
END
go
--------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE HienThiDanhSachSP
AS
BEGIN
Select MaSP, TenSP, GiaSP, SoLuong from SanPham
END
GO



insert into NhanVien values ('1','driverhuyhoa@gmail.com', N'Huy Hoà', N'Đồng Nai','0335592943', 1,'3244185981728979115075721453575112')
insert into NhanVien values ('2','tanhien@gmail.com', N'Tấn Hiển', N'Đồng Nai','02324232233', 1, 123)
delete NhanVien where MaNV = '1'
select * from NhanVien


select* from SanPham
insert into SanPham values(N'Áo Khoác', 250000, 'M','08-11-2021',10,N'Hàng mới',1)
insert into SanPham values(N'Áo Khỉ', 250000, 'M','08-11-2021',10,N'Hàng mới',1)

select TenSP from SanPham