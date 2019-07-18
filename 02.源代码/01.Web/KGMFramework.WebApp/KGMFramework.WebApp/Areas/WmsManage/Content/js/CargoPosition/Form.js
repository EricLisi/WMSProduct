var router = "/WmsManage/CargoPosition";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {

    }
}
$(function () {
    $("#F_WarehouseId").bindSelect({
        url: "/WmsManage/Warehouse/GetSelectJson",
    });

  
})
//初始化窗体
InitForm(router, formSetting);
