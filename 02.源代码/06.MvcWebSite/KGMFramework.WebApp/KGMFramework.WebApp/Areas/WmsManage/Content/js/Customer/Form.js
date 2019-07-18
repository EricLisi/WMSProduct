var router = "/WmsManage/Customer";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_OrganizationId").select2({
            minimumResultsForSearch: -1
        });
        $("#F_OrganizationId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson"
        });
    }
}

//初始化窗体
InitForm(router, formSetting);


 