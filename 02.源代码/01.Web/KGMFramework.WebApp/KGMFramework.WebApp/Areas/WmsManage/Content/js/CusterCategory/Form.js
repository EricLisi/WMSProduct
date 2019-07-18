var router = "/WmsManage/CusterCategory";    //当前页面路由

//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_ParentId").bindSelect({
            url: "/WmsManage/CusterCategory/GetTreeSelectJson"
        });
        $("#F_Unit").select2({
            minimumResultsForSearch: -1
        });
    }
}
//初始化窗体
InitForm(router, formSetting);