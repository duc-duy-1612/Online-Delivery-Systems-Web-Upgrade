$connectionString = "Data Source=.\MAY1;Initial Catalog=FoodDeliveryDB;Integrated Security=True;"
$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
$connection.Open()

$queries = @(
    "UPDATE NhaHang SET DiaChi = N'102 Nguyễn Đình Chiểu, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH006';",
    "UPDATE NhaHang SET DiaChi = N'11 Nguyễn Thiện Thuật, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH007';",
    "UPDATE NhaHang SET TenNH = N'Cơm Niêu Sài Gòn', DiaChi = N'120 Lý Tự Trọng, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH008';",
    "UPDATE NhaHang SET TenNH = N'Lẩu Nướng Đại Phát', DiaChi = N'72 Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH009';",
    "UPDATE NhaHang SET TenNH = N'Gà Rán Tokyo', DiaChi = N'15 Võ Thị Sáu, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH010';",
    "UPDATE NhaHang SET DiaChi = N'21 Nguyễn Tri Phương, Quận 10, TP. Hồ Chí Minh' WHERE MaNH = 'NH012';",
    "UPDATE NhaHang SET DiaChi = N'88 Nguyễn Thông, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH013';",
    "UPDATE NhaHang SET DiaChi = N'29 Nguyễn Oanh, Quận Gò Vấp, TP. Hồ Chí Minh' WHERE MaNH = 'NH014';",
    "UPDATE NhaHang SET DiaChi = N'54 Phạm Văn Hai, Quận Tân Bình, TP. Hồ Chí Minh' WHERE MaNH = 'NH015';",
    "UPDATE NhaHang SET DiaChi = N'Vincom Đồng Khởi, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH016';",
    "UPDATE NhaHang SET DiaChi = N'26 Lê Thị Riêng, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH017';",
    "UPDATE NhaHang SET DiaChi = N'38 Trần Hưng Đạo, Quận 5, TP. Hồ Chí Minh' WHERE MaNH = 'NH019';",
    "UPDATE NhaHang SET DiaChi = N'45 Hai Bà Trưng, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH020';",
    "UPDATE NhaHang SET DiaChi = N'12 Trần Quốc Thảo, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH021';",
    "UPDATE NhaHang SET DiaChi = N'123 Nguyễn Trãi, Quận 5, TP. Hồ Chí Minh' WHERE MaNH = 'NH022';",
    "UPDATE NhaHang SET DiaChi = N'78 Nguyễn Gia Trí, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH023';",
    "UPDATE NhaHang SET DiaChi = N'60 Lê Quý Đôn, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH024';",
    "UPDATE NhaHang SET DiaChi = N'71 Trường Chinh, Quận Tân Bình, TP. Hồ Chí Minh' WHERE MaNH = 'NH025';",
    "UPDATE NhaHang SET DiaChi = N'91 Lê Lợi, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH026';",
    "UPDATE NhaHang SET DiaChi = N'17 Điện Biên Phủ, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH027';",
    "UPDATE NhaHang SET DiaChi = N'35 Nguyễn Du, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH028';",
    "UPDATE NhaHang SET DiaChi = N'83 Cách Mạng Tháng 8, Quận 10, TP. Hồ Chí Minh' WHERE MaNH = 'NH030';",
    "UPDATE NhaHang SET DiaChi = N'Vincom Lê Thánh Tôn, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH031';",
    "UPDATE NhaHang SET DiaChi = N'22 Võ Văn Tần, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH032';",
    "UPDATE NhaHang SET DiaChi = N'14 Nguyễn Văn Thủ, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH033';",
    "UPDATE NhaHang SET DiaChi = N'88 Nguyễn Văn Đậu, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH034';",
    "UPDATE NhaHang SET DiaChi = N'95 Nguyễn Tri Phương, Quận 10, TP. Hồ Chí Minh' WHERE MaNH = 'NH035';",
    "UPDATE NhaHang SET DiaChi = N'120 Trần Quang Diệu, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH036';",
    "UPDATE NhaHang SET DiaChi = N'42 Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH037';",
    "UPDATE NhaHang SET DiaChi = N'97 Nguyễn Văn Trỗi, Quận Phú Nhuận, TP. Hồ Chí Minh' WHERE MaNH = 'NH038';",
    "UPDATE NhaHang SET DiaChi = N'11 Phan Đăng Lưu, Quận Phú Nhuận, TP. Hồ Chí Minh' WHERE MaNH = 'NH039';",
    "UPDATE NhaHang SET DiaChi = N'29 Nguyễn Văn Lạc, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH041';",
    "UPDATE NhaHang SET DiaChi = N'66 Nguyễn Trãi, Quận 5, TP. Hồ Chí Minh' WHERE MaNH = 'NH042';",
    "UPDATE NhaHang SET DiaChi = N'98 Lý Chính Thắng, Quận 3, TP. Hồ Chí Minh' WHERE MaNH = 'NH043';",
    "UPDATE NhaHang SET DiaChi = N'11 Nguyễn Thị Minh Khai, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH046';",
    "UPDATE NhaHang SET DiaChi = N'Landmark 81, Quận Bình Thạnh, TP. Hồ Chí Minh' WHERE MaNH = 'NH047';",
    "UPDATE NhaHang SET DiaChi = N'44 Nguyễn Văn Cừ, Quận 5, TP. Hồ Chí Minh' WHERE MaNH = 'NH049';",
    "UPDATE NhaHang SET DiaChi = N'12 Nguyễn Huệ, Quận 1, TP. Hồ Chí Minh' WHERE MaNH = 'NH050';"
)

foreach ($q in $queries) {
    $command = $connection.CreateCommand()
    $command.CommandText = $q
    $command.ExecuteNonQuery() | Out-Null
}

$connection.Close()
Write-Output "Updates applied successfully."
