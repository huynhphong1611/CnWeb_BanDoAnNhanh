$(document).ready(function () {
    $("#btn-DangNhap").click(function () {
        DangNhap();
    });
    $("#btn-DangKy").click(function () {
        DangKy();
    });
    $(".GioHang").click(function () {
        maKH = $(this).data('id');
        if (maKH == 0) {
            alert('Bạn chưa đăng nhập');
        } else {
            LoadGioHang(maKH);
        }
    });
    $("#btn-TimKiem").click(function () {
        var tenMon = $("#txt-TenMon").val();        
        TimKiemMonAn(tenMon);
    });
});  
function DangNhap() {
    var TaiKhoan = {
        TenDangNhap: $('#TenDangNhap').val(),
        MatKhau: $('#MatKhau').val()
    };
    $.ajax({
        url: "/Home/DangNhap",
        data: JSON.stringify(TaiKhoan),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status == true) {
                alert('Đăng nhập thành công');
                $('.HienDangNhap').removeClass('HienForm');
                $('.lammo').removeClass('HienForm');
                $("#DangNhap").hide();
            } else {
                alert('Đăng nhập không chính xác bạn ơi');
            }          
        }
    });
}
function DangKy() {
    var ThongTinDangKyTaiKhoan = {
        HoTen: $('#HoTen').val(),
        SDT: $('#sdt').val(),
        TenDangNhap: $('#TenDangNhapDK').val(),
        MatKhau: $('#MatKhauDK1').val()
    };
    $.ajax({
        url: "/Home/DangKy",
        data: JSON.stringify(ThongTinDangKyTaiKhoan),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status == true) {
                alert('Đăng ký thành công');
                $('.HienDangNhap').removeClass('HienForm');
                $('.lammo').removeClass('HienForm');                
            } else {
                alert('Đăng ký thất bại');
            }
        }
    });
}
function LoadGioHang(maKH) {
    $.ajax({
        type: 'POST',
        url: "/GioHang/ChiTietGioHang",
        data: { MaKH: maKH },
        success: function (response) {
            $("#ChiTietGioHang").html(response);
            $("#MacDinh").hide();        
        }
    });
}

function TimKiemMonAn(tenMon) {
    $.ajax({
        type: 'POST',
        url: "/GioHang/TimKiemMonAn",
        data: { TenMon: tenMon },
        success: function (response) {
            $("#DanhSachMon").html(response);     
        }
    });
}