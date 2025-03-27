-- Tạo CSDL Thuê Xe Trực Tuyến
Create DATABASE QuanLyThueXe;
GO

USE QuanLyThueXe;
GO

-- Bảng Loại Xe
CREATE TABLE LoaiXe (
    MaLoaiXe INT PRIMARY KEY IDENTITY(1,1),
    TenLoaiXe NVARCHAR(50) NOT NULL,
    MoTa NVARCHAR(255)
);

-- Bảng Xe
CREATE TABLE Xe (
    MaXe INT PRIMARY KEY IDENTITY(1,1),
    BienSoXe NVARCHAR(20) NOT NULL UNIQUE,
    MaLoaiXe INT FOREIGN KEY REFERENCES LoaiXe(MaLoaiXe),
    HangXe NVARCHAR(50) NOT NULL,
    MauXe NVARCHAR(50) NOT NULL,
    NamSanXuat INT NOT NULL,
    TrangThai NVARCHAR(20) NOT NULL CHECK (TrangThai IN (N'Sẵn Sàng', N'Đang Thuê', N'Bảo Dưỡng')),
    GiaThueMotNgay DECIMAL(10,2) NOT NULL,
    SoChoNgoi INT NOT NULL,
    HinhAnh NVARCHAR(255)
);

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKhachHang INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL,
    SoCMND NVARCHAR(20) NOT NULL,
    DiaChi NVARCHAR(255) NOT NULL,
    NgaySinh DATE NOT NULL
);

-- Bảng Đơn Thuê Xe
CREATE TABLE DonThueXe (
    MaDonThue INT PRIMARY KEY IDENTITY(1,1),
    MaKhachHang INT FOREIGN KEY REFERENCES KhachHang(MaKhachHang),
    MaXe INT FOREIGN KEY REFERENCES Xe(MaXe),
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL,
    TongGiaThue DECIMAL(10,2) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL CHECK (TinhTrang IN (N'Đã Đặt', N'Đang Thuê', N'Đã Trả', N'Hủy')),
    DiaDiemNhanXe NVARCHAR(255) NOT NULL,
    DiaDiemTraXe NVARCHAR(255) NOT NULL
);

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNhanVien INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL,
    ChucVu NVARCHAR(50) NOT NULL,
    NgayVaoLam DATE NOT NULL
);

-- Bảng Thanh Toán
CREATE TABLE ThanhToan (
    MaThanhToan INT PRIMARY KEY IDENTITY(1,1),
    MaDonThue INT FOREIGN KEY REFERENCES DonThueXe(MaDonThue),
    SoTienThanhToan DECIMAL(10,2) NOT NULL,
    PhuongThucThanhToan NVARCHAR(50) NOT NULL,
    NgayThanhToan DATETIME NOT NULL,
    TrangThaiThanhToan NVARCHAR(20) NOT NULL CHECK (TrangThaiThanhToan IN (N'Thành Công', N'Thất Bại', N'Đang Xử Lý'))
);

-- Bảng Bảo Hiểm
CREATE TABLE BaoHiem (
    MaBaoHiem INT PRIMARY KEY IDENTITY(1,1),
    MaDonThue INT FOREIGN KEY REFERENCES DonThueXe(MaDonThue),
    LoaiBaoHiem NVARCHAR(100) NOT NULL,
    MucPhiBaoHiem DECIMAL(10,2) NOT NULL,
    NgayBatDau DATE NOT NULL,
    NgayKetThuc DATE NOT NULL
);

-- Thêm một số ràng buộc và chỉ mục
ALTER TABLE DonThueXe 
ADD CONSTRAINT CHK_NgayThue CHECK (NgayBatDau < NgayKetThuc);

CREATE INDEX IX_Xe_TrangThai ON Xe(TrangThai);
CREATE INDEX IX_DonThueXe_TinhTrang ON DonThueXe(TinhTrang);

-- Thêm dữ liệu mẫu cho bảng LoaiXe
INSERT INTO LoaiXe (TenLoaiXe, MoTa) VALUES 
(N'Sedan', N'Xe du lịch 4 chỗ'),
(N'SUV', N'Xe địa hình 7 chỗ'),
(N'Hatchback', N'Xe nhỏ gọn 5 chỗ'),
(N'Xe Sang', N'Xe hạng sang cao cấp');

INSERT INTO LoaiXe (TenLoaiXe, MoTa) VALUES 
(N'Coupe', N'Xe thể thao 2 cửa'),
(N'Convertible', N'Xe mui trần'),
(N'Pickup', N'Xe bán tải đa dụng'),
(N'Van', N'Xe chở nhiều người, rộng rãi'),
(N'Crossover', N'Xe kết hợp giữa sedan và SUV'),
(N'MPV', N'Xe đa dụng 7 chỗ'),
(N'Electric', N'Xe điện công nghệ cao');

-- Thêm dữ liệu mẫu cho bảng Xe
INSERT INTO Xe (BienSoXe, MaLoaiXe, HangXe, MauXe, NamSanXuat, TrangThai, GiaThueMotNgay, SoChoNgoi, HinhAnh) VALUES 
(N'30A-12345', 1, N'Toyota', N'Trắng', 2020, N'Sẵn Sàng', 500000, 4, N'/images/toyota-sedan.jpg'),
(N'29H-67890', 2, N'Ford', N'Đen', 2019, N'Sẵn Sàng', 800000, 7, N'/images/ford-suv.jpg');
INSERT INTO Xe (BienSoXe, MaLoaiXe, HangXe, MauXe, NamSanXuat, TrangThai, GiaThueMotNgay, SoChoNgoi, HinhAnh) VALUES 
(N'51G-99999', 1, N'Honda', N'Xanh', 2021, N'Sẵn Sàng', 600000, 5, N'/images/honda-city.jpg'),  -- Sedan
(N'60A-88888', 2, N'Hyundai', N'Bạc', 2018, N'Đang Thuê', 750000, 7, N'/images/hyundai-santafe.jpg'),  -- SUV
(N'79D-12345', 3, N'Mazda', N'Đỏ', 2022, N'Sẵn Sàng', 900000, 5, N'/images/mazda-3.jpg'),  -- Hatchback
(N'43B-67890', 3, N'Kia', N'Vàng', 2020, N'Sẵn Sàng', 550000, 4, N'/images/kia-morning.jpg'),  -- Hatchback
(N'92C-24680', 2, N'Chevrolet', N'Xám', 2017, N'Bảo Dưỡng', 700000, 7, N'/images/chevrolet-captiva.jpg'),  -- SUV
(N'30E-13579', 4, N'VinFast', N'Xanh Dương', 2023, N'Sẵn Sàng', 950000, 5, N'/images/vinfast-lux-a.jpg'),  -- Xe Sang
(N'29F-98765', 4, N'Mercedes', N'Trắng', 2021, N'Sẵn Sàng', 1200000, 5, N'/images/mercedes-c-class.jpg'),  -- Xe Sang
(N'51H-54321', 2, N'BMW', N'Đen', 2022, N'Đang Thuê', 1300000, 7, N'/images/bmw-x5.jpg'),  -- SUV
(N'50A-11223', 4, N'Audi', N'Đen', 2021, N'Sẵn Sàng', 1400000, 5, N'/images/audi-a6.jpg'),  -- Xe Sang
(N'65B-33445', 4, N'Lexus', N'Trắng', 2022, N'Đang Thuê', 1600000, 7, N'/images/lexus-rx.jpg'),  -- Xe Sang
(N'18C-55667', 5, N'Porsche', N'Xanh', 2023, N'Sẵn Sàng', 2500000, 4, N'/images/porsche-911.jpg'),  -- Coupe
(N'72D-77889', 1, N'Nissan', N'Bạc', 2020, N'Sẵn Sàng', 850000, 5, N'/images/nissan-altima.jpg'),  -- Sedan
(N'34E-99001', 2, N'Suzuki', N'Xám', 2019, N'Bảo Dưỡng', 700000, 7, N'/images/suzuki-xl7.jpg'),  -- SUV
(N'99F-22334', 6, N'Tesla', N'Đỏ', 2023, N'Sẵn Sàng', 1800000, 5, N'/images/tesla-model-3.jpg'),  -- Electric
(N'45G-44556', 7, N'Peugeot', N'Xanh Lá', 2021, N'Sẵn Sàng', 950000, 5, N'/images/peugeot-3008.jpg'),  -- Crossover
(N'37H-66778', 2, N'Jeep', N'Vàng', 2018, N'Đang Thuê', 1200000, 7, N'/images/jeep-wrangler.jpg'),  -- SUV
(N'23I-88990', 4, N'Volvo', N'Trắng', 2022, N'Sẵn Sàng', 1500000, 5, N'/images/volvo-xc60.jpg'),  -- Xe Sang
(N'11K-10112', 2, N'Land Rover', N'Đen', 2023, N'Sẵn Sàng', 2000000, 7, N'/images/landrover-discovery.jpg'); -- SUV
GO