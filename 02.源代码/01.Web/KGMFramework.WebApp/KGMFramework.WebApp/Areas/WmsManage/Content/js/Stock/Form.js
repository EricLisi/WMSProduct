
var router = "/WmsManage/PurchaseOutStock";//当前页面路由
formSetting = {
    initFormEvent: function initControl() {
        //初始化供应商
        $("#F_TransferWarHouseId").bindSelect({
            url: "/WmsManage/Warehouse/GetSelectJson",
        }).on("select2:select", function () {
            $("#F_TransferCargoId").empty();
            $("#F_TransferCargoId").bindSelect({
                url:"/CargoPosition/GetSelectJson?keyword="+ $("#F_TransferWarHouseId").val()+"&searchFiled=F_WarehouseId"
                      });
            $("#F_TransferWarHouse").val($("#F_TransferWarHouseId").find("option:selected").text())
            $("#F_TransferCargo").val($("#F_TransferCargoId").find("option:selected").text())
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

