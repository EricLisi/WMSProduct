var router = "/WmsManage/SperCategory";    //当前页面路由

//自己的初始化事件
formSetting = {
    initFormEvent: function initControl() {
        $("#F_ParentId").bindSelect({
            url: "/WmsManage/SperCategory/GetTreeSelectJson"
        });
    }
}
//初始化窗体
InitForm(router, formSetting);