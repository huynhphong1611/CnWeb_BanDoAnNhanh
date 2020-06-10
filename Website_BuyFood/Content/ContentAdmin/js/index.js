function drawGrahp() {
    // Load google charts
    google.charts.load('current', {'packages':['corechart']});
    google.charts.setOnLoadCallback(drawChart);
    
    function drawChart() {
    var data = google.visualization.arrayToDataTable([
    ['Tháng', 'Triệu VNĐ'],
    ['Tháng 1', 0.3],
    ['Tháng 2', 0],
    ['Tháng 3', 0]
    ]);
     
    var options = {'title':'Doanh thu theo tháng năm 2020',
    series: {
        0: { color: '#ff9350' }
    }};
     
    var chart = new google.visualization.LineChart(document.getElementById('graph-doanh-thu'));
    chart.draw(data, options);
    }
}


function onClickMenuHeader() {
    console.log("Bạn đã click vào menu header ");
    var display = document.getElementById("overlay").style.getPropertyValue("display");
    console.log(display);
    if (display == 'block') {
        offOverlayPage();
    } else {
        onOverlayPage();
    }
    var element = document.getElementById("actionbar-menu");
    element.classList.toggle("action-bar-menu-hide");
}
function onClickNotificationIconHeader() {
    var element = document.getElementById("id-popup-notification");
    element.classList.toggle("popup-notification-click");
}
function onOverlayPage() {
    document.getElementById("overlay").style.display = "block";
}
  
function offOverlayPage() {
    document.getElementById("overlay").style.display = "none";
}
function hideTabHome() {
    document.getElementById("content-home").style.display = "none";
    document.getElementById("graph-home").style.display = "none";
}
function hideTabProduct() {
    document.getElementById("id-content-product").style.display = "none";
}
function hideTabUsers() {
    document.getElementById("id-content-user").style.display = "none";
}
function hideTabOrders() {
    document.getElementById("id-content-order").style.display = "none";
}
// khi click vào san phẩm 
function onClickProduct() {
    hideTabHome();
    hideTabUsers();
    hideTabOrders();
    document.getElementById("id-content-product").style.display = "inline";
    onClickMenuHeader();
}
//khi click vào khách hang ở actionbar 
function onClickUsers() {
    hideTabHome();
    hideTabProduct();
    hideTabOrders();
    document.getElementById("id-content-user").style.display = "inline";
    onClickMenuHeader();
}
//khi click vào đơn đặt hàng
function onClickOrders() {
    hideTabHome();
    hideTabProduct();
    hideTabUsers();
    document.getElementById("id-content-order").style.display = "inline";
    onClickMenuHeader();
}
//add san pham 
function addProduct() {
    console.log("them sp");
}

