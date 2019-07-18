var router = "/WmsManage/PurchaseInStock";//当前页面路由
formSetting = {
    initFormEvent: function initControl() {
        $.ajax({
            url: "/WmsManage/StockMake/GetNum",
            type: "get",
            dataType: "json",
            success: function (data) {
                console.info(data);
                console.info(data.F_Id);
                $("#F_Number").val(data.F_Number);
                $("#F_Id").val(data.F_Id);
            }
        })
        dateInit("F_BuyDate");
    }
}

InitForm(router, formSetting);
//时间格式的设置
function dateInit(name) {
    var myDate = new Date();
    var month = myDate.getMonth() + 1;
    var day = myDate.getDate();
    var date = myDate.getFullYear() + "-" + (month < 10 ? '0' + month : month) + "-" + (day < 10 ? '0' + day : day);
    $("#" + name + "").val(date);
}


