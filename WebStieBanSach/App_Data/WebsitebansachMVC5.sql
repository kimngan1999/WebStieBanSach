create database QuanLyBanSachMVC5

USE QuanLyBanSachMVC5


CREATE TABLE KhachHang (
	MaKH INT IDENTITY PRIMARY KEY,
	HoTen NVARCHAR(50),
	TaiKhoan NVARCHAR(50),
	MatKhau NVARCHAR(50),
	Email NVARCHAR(50),
	DiaChi NVARCHAR(100),
	DienThoai VARCHAR(10),
	GioiTinh NVARCHAR(3),
	NgaySinh DATETIME
)

CREATE TABLE ChuDe (
	MaChuDe INT IDENTITY PRIMARY KEY,
	TenChuDe NVARCHAR(50)
	)

CREATE TABLE NhaXuatBan (
	MaNXB INT IDENTITY PRIMARY KEY,
	TenNXB NVARCHAR(50),
	DiaChi NVARCHAR(50),
	DienThoai VARBINARY(10)
	)

CREATE TABLE TacGia (
	MaTacGia INT IDENTITY PRIMARY KEY,
	TenTacGia NVARCHAR(50),
	DiaChi NVARCHAR(100),
	TieuSu NVARCHAR(MAX),
	DienThoai VARCHAR(10)
	)
CREATE TABLE Sach (
	MaSach INT IDENTITY PRIMARY KEY,
	TenSach NVARCHAR(50),
	GiaBan DECIMAL(18,0),
	MoTa NVARCHAR(MAX),
	AnhBia NVARCHAR(50),
	NgayCapNhat DATETIME,
	SoLuongTon INT,
	MaNXB INT,
	MaChuDe INT
	)

CREATE TABLE ThamGia (
	MaSach INT,
	MaTacGia INT,
	VaiTro NVARCHAR(50),
	ViTri NVARCHAR(50),
	PRIMARY KEY(MaSach,MaTacGia)
	)

CREATE TABLE DonHang (
	MaDonHang INT PRIMARY KEY,
	DaThanhToan INT,
	TinhTrangDonHang INT,
	NgayDat DATETIME,
	NgayGiao DATETIME,
	MaKH INT
)

CREATE TABLE ChiTietDonHang (
	MaDonHang INT,
	MaSach INT,
	SoLuong INT,
	DonGia NCHAR(10),
	PRIMARY KEY(MaDonHang,MaSach)
)

insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Nhà xuất bản trẻ',N'124 Nguyễn Văn Cừ',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Thống kê',N'Biên Hòa - Đồng Nai',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Kim Đồng',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Đại học quốc gia',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Văn hóa nghệ thuật',N'Đà Nẵng',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Văn hóa',N'Bình Dương',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Lao động',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Khoa học & Kỹ thuật',N'Hà Nội',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'Thanh niên',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Tài chính',N'Huế',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB phụ nữ',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Hồng Đức',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Phương Đông',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Thời đại',N'Tp.HCM',0123456789)
insert into NhaXuatBan(TenNXB,DiaChi ,DienThoai)
values (N'NXB Tổng hợp',N'',0123456789)


insert into ChuDe(TenChuDe)
values (N'Công nghệ phần mềm')
insert into ChuDe(TenChuDe)
values (N'Ngoại ngữ')
insert into ChuDe(TenChuDe)
values (N'Phật giáo')
insert into ChuDe(TenChuDe)
values (N'Sách học làm người')
insert into ChuDe(TenChuDe)
values (N'Văn hóa nước ngoài')
insert into ChuDe(TenChuDe)
values (N'Kinh tế')
insert into ChuDe(TenChuDe)
values (N'Khao học vật lý')
insert into ChuDe(TenChuDe)
values (N'Khoa học xã hội')
insert into ChuDe(TenChuDe)
values (N'Luật')
insert into ChuDe(TenChuDe)
values (N'Từ điển')
insert into ChuDe(TenChuDe)
values (N'Lịch sử, địa lý')
insert into ChuDe(TenChuDe)
values (N'Vật nuôi - cây cối')
insert into ChuDe(TenChuDe)
values (N'Khoa học kỹ thuật')
insert into ChuDe(TenChuDe)
values (N'Mỹ thuật')
insert into ChuDe(TenChuDe)
values (N'Nghệ thuật')
insert into ChuDe(TenChuDe)
values (N'Ân nhạc')
insert into ChuDe(TenChuDe)
values (N'Sách giáo khoa')
insert into ChuDe(TenChuDe)
values (N'Danh nhân')
insert into ChuDe(TenChuDe)
values (N'Tâm lý giáo dục')
insert into ChuDe(TenChuDe)
values (N'Thể thao - võ thuật')
insert into ChuDe(TenChuDe)
values (N'Văn hóa - xã hội')
insert into ChuDe(TenChuDe)
values (N'Nữ công giá chánh')
insert into ChuDe(TenChuDe)
values (N'Du lịch')
insert into ChuDe(TenChuDe)
values (N'Y học dân tộc vn')


insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Sketchup', 30000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','01.jpg', 100, 1,1 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Thủ thuật bấn máy tính',124353 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','02.jpg',50 ,1 ,2 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Tự học design',56000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','03.jpg',10 , 1, 3)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Đắc nhân tâm', 47000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','04.jpg',10 ,4 ,4 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Tự học photoshop',32000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','05.jpg',10 ,1 , 1)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'180 thủ thật vẽ', 31000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','06.jpg', 10, 1,5 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Tự học c#', 36000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','07.jpg', 10, 1, 6)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'C# Dành cho người mới bắt đầu 1', 19000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','08.jpg',10 ,1 ,7 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'C# Dành cho người mới bắt đầu 1',100000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','09.jpg',10 , 1,8 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Nghệ thuật sống đẹp',37000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','10.jpg',10 , 1, 2)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Phương pháp giảng dạy', 76000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','11.jpg',10 , 3,3 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Ngọc sáng trong lòng', 64000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','12.jpg',10 ,6 , 8)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Hành trình vũ trụ',49000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','13.jpg', 10, 3, 7)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Lập bản đồ tư liệu', 57000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','14.jpg',10 ,3 , 6)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Nhũng quy luật ngầm', 83000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','15.jpg', 10, 4,3 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Đơn giản và th',38000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','16.jpg',10 ,3 , 8)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Tích phân',87000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','17.jpg',50 ,6 , 7)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Luyện tập anh văn', 77300,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','18.jpg',50 , 6,6 )
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'80 chiêu thức',35000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','19.jpg',50 ,5 , 5)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Tiếng hàn trong tàm tay',76000 ,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','20.jpg', 50,6 , 2)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'17 nguyên tắc vàng', 34000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','21.jpg',50 , 6, 3)
insert into Sach (TenSach,GiaBan ,MoTa ,NgayCapNhat,AnhBia,SoLuongTon,MaChuDe,MaNXB)
values(N'Những công cụ', 23000,N'Nội dung sach rất hay tại vì quá dài nên đếch viết vào để làm bí mật ','03/31/2012','22.jpg', 50, 2,1 )