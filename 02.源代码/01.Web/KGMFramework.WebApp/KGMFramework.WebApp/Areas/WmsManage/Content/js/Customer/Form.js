var router = "/WmsManage/Customer";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_CusterCategoryId").bindSelect({
            url: "/WmsManage/CusterCategory/GetTreeSelectJson"
        });
        $("#F_AreaId").bindSelect({
            url: "/SystemManage/Area/GetTreeSelectJson"
        });
    },
    doBeforeSubmit: function (params) {
        //提交前操作，将itemId 设置为当前ItemId
        params["F_CusterCategoryId"] = $.request("itemId");
        return true;
    }
}

//初始化窗体
InitForm(router, formSetting);