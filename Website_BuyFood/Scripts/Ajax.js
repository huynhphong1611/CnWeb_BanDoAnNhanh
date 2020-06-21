$(document).ready(function () {
    $("#btn-DangNhap").click(function () {
        DangNhap();
    })
    $("#btn-DangKy").click(function () {
        DangKy();
    })

    $("#btn-TimKiem").click(function () {
        var tenMon = $("#txt-TenMon").val();
        TimKiemMonAn(tenMon);
    })   
    $(".GioHang").click(function () {
       maKH = $(this).data('id');
       if (maKH != 0) {
           LoadGioHang(maKH);
       }
    })  
    $('.Giam').click(function () {
        MaMon = $(this).data('id');
        GiamSoLuong(maKH, MaMon);        
    })
    $('.Tang').click(function () {
        MaMon = $(this).data('id');
        ThemSoLuong(maKH, MaMon);
    })
    $(".XoaMonAn").click(function () {        
        MaMonAn = $(this).data('ma');
        XoaMonAnTrongGioHang(maKH, MaMonAn);
    })
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
                    $('.HienDangNhap').removeClass('HienForm');
                    $('.lammo').removeClass('HienForm');
                    location.reload();
                    
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
                    $('.HienDangKy').removeClass('HienForm');
                    $('.lammo').removeClass('HienForm');
                    location.reload();
                } else {
                    alert('Đăng ký thất bại');
                }
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

    function XoaMonAnTrongGioHang(MaKH, MaMon) {
        var ThemVaoGio = {
            MaKH: MaKH,
            MaMon: MaMon
        };
        $.ajax({
            url: "/GioHang/XoaMonAnTrongGioHang",
            data: JSON.stringify(ThemVaoGio),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result.status == true) {
                    LoadGioHang(MaKH);
                }
            }
        });
}
function ThemSoLuong(MaKH, MaMon) {
    var ThemVaoGio = {
        MaKH: MaKH,
        MaMon: MaMon
    };
    $.ajax({
        url: "/GioHang/ThemSoLuong",
        data: JSON.stringify(ThemVaoGio),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status == true) {
                LoadGioHang(MaKH);
            }
        }
    });
}
function GiamSoLuong(MaKH, MaMon) {
    var ThemVaoGio = {
        MaKH: MaKH,
        MaMon: MaMon
    };
    $.ajax({
        url: "/GioHang/GiamSoLuong",
        data: JSON.stringify(ThemVaoGio),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.status == true) {
                LoadGioHang(MaKH);
            }
        }
    });
}
