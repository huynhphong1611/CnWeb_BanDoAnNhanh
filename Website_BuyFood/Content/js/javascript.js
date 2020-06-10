$(function () {
	// Xử lý phần đăng nhập và đăng ký
	$('.DangNhap').click(function(event) {
		// xử lí class
		$('.HienDangNhap').addClass('HienForm');
		$('.lammo').addClass('HienForm');
	});
	$('.Close-DN,.lammo').click(function(event) {
		$('.HienDangNhap').removeClass('HienForm');
		$('.lammo').removeClass('HienForm');
	});
	$('.DangKy').click(function(event) {
		// xử lí class
		$('.HienDangKy').addClass('HienForm');
		$('.lammo').addClass('HienForm');
	});
	$('.Close-DK,.lammo').click(function(event) {
		$('.HienDangKy').removeClass('HienForm');
		$('.lammo').removeClass('HienForm');
	});
});