$(function () {
	// Xử lý phần đăng nhập và đăng ký
	$('.DangNhap').click(function(event) {
		// xử lí class
		$('.HienDangNhap').addClass('HienForm');
		$('.lammo').addClass('HienForm');
	});
	
	$('.DangKy').click(function(event) {
		// xử lí class
		$('.HienDangKy').addClass('HienForm');
		$('.lammo').addClass('HienForm');
	});
	$('.lammo').click(function(event) {
        $('.HienDangNhap').removeClass('HienForm');
        $('.HienDangKy').removeClass('HienForm');
        $('.lammo').removeClass('HienForm');
        $('.ThongTinDatHang').removeClass('HienForm');
    });
    $('#ThanhToan').click(function (event) {   
        $('.ThongTinDatHang').addClass('HienForm');
        $('.lammo').addClass('HienForm');
    });
});