var router = "/WmsManage/Suppliers";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_SperCategoryId").bindSelect({
            url: "/WmsManage/SperCategory/GetTreeSelectJson"
        });
        $("#F_AreaId").bindSelect({
            url: "/SystemManage/Area/GetTreeSelectJson"
        });
    },
    doBeforeSubmit: function (params) {
        //提交前操作，将itemId 设置为当前ItemId
        params["F_SperCategoryId"] = $.request("itemId");
        return true;
    }
}

//初始化窗体
InitForm(router, formSetting);