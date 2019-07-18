var router = "/WmsManage/Supplier";    //当前页面路由
//自己的初始化事件
formSetting = {
    initFormEvent: function () {
        $("#F_Gender").bindSelect()
        $("#F_IsAdministrator").bindSelect()
        $("#F_EnabledMark").bindSelect()
        $("#F_OrganizationId").bindSelect({
            url: "/SystemManage/Organize/GetTreeSelectJson"
        });
  
    }
}

//初始化窗体
InitForm(router, formSetting);


 